<?php
require __DIR__ . '/config.php';

function h($s) { return htmlspecialchars((string)$s, ENT_QUOTES, 'UTF-8'); }

$docTypes = ['Transcript Request', 'Deferment Form', 'Request Letter', 'Certificate Verification', 'Other'];

// Which desk's QR code was scanned (?desk=Desk-01)
$desk = trim($_GET['desk'] ?? $_POST['desk'] ?? '');
$deskOk = (bool)preg_match('/^[A-Za-z0-9 _-]{1,30}$/', $desk);

// Confirmation screen after a successful submit
$done = $_GET['done'] ?? '';
$showDone = (bool)preg_match('/^DOC-\d{4}-\d{4,}$/', $done);

$errors = [];
$v = ['name' => '', 'phone' => '', 'email' => '', 'doc' => ''];

if ($_SERVER['REQUEST_METHOD'] === 'POST' && $deskOk) {
    $v['name']  = trim($_POST['name'] ?? '');
    $v['phone'] = trim($_POST['phone'] ?? '');
    $v['email'] = trim($_POST['email'] ?? '');
    $v['doc']   = $_POST['doc'] ?? '';

    // Normalise phone to +233... (Ghana 0XXXXXXXXX -> +233XXXXXXXXX) because the SMS gateway needs it
    $digits = preg_replace('/[^0-9+]/', '', $v['phone']);
    if (preg_match('/^0\d{9}$/', $digits)) { $digits = '+233' . substr($digits, 1); }

    if ($v['name'] === '' || mb_strlen($v['name']) > 100)          $errors[] = 'Please enter your full name.';
    if (!preg_match('/^\+?\d{9,15}$/', $digits))                   $errors[] = 'Please enter a valid phone number.';
    if (!filter_var($v['email'], FILTER_VALIDATE_EMAIL) || strlen($v['email']) > 100) $errors[] = 'Please enter a valid email address.';
    if (!in_array($v['doc'], $docTypes, true))                      $errors[] = 'Please choose a document type.';

    if (!$errors) {
        try {
            $pdo = new PDO(DB_DSN, DB_USER, DB_PASS, [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]);
            $pdo->beginTransaction();

            // Reuse the visitor if the same phone + email was used before
            $st = $pdo->prepare('SELECT Visitor_ID FROM Visitors WHERE Phone_Number = ? AND Email = ? LIMIT 1');
            $st->execute([$digits, $v['email']]);
            $vid = $st->fetchColumn();
            if (!$vid) {
                $vid = 'VIS-' . strtoupper(bin2hex(random_bytes(4)));
                $pdo->prepare('INSERT INTO Visitors (Visitor_ID, Full_Name, Phone_Number, Email) VALUES (?,?,?,?)')
                    ->execute([$vid, $v['name'], $digits, $v['email']]);
            }

            // Unique tracking ID from the database counter
            $pdo->exec('INSERT INTO Tracking_Sequence () VALUES ()');
            $tid = sprintf('DOC-%d-%04d', (int)date('Y'), (int)$pdo->lastInsertId());

            $pdo->prepare("INSERT INTO Document_Logs (Tracking_ID, Visitor_ID, Receiving_Officer_ID, Document_Type, Desk_Station, Current_Status)
                           VALUES (?, ?, NULL, ?, ?, 'Pending')")
                ->execute([$tid, $vid, $v['doc'], $desk]);
            $pdo->commit();

            header('Location: form.php?desk=' . urlencode($desk) . '&done=' . urlencode($tid));  // stops double-submit on refresh
            exit;
        } catch (Exception $e) {
            if (isset($pdo) && $pdo->inTransaction()) $pdo->rollBack();
            error_log('VDMS form error: ' . $e->getMessage());
            $errors[] = 'Sorry, we could not save your submission. Please tell the desk officer.';
        }
    }
}
?><!doctype html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>Registrar's Office - Submit Document</title>
<style>
  body{margin:0;font-family:Segoe UI,Arial,sans-serif;background:#f0f3f7;color:#222}
  header{background:#1f4e79;color:#fff;padding:20px}
  header h1{margin:0;font-size:20px} header p{margin:6px 0 0;color:#c8dcf0;font-size:14px}
  main{max-width:480px;margin:0 auto;padding:20px}
  label{display:block;margin:16px 0 6px;font-weight:600}
  input,select{width:100%;box-sizing:border-box;padding:13px;font-size:16px;border:1px solid #9aa5b1;border-radius:6px;background:#fff}
  button{width:100%;margin-top:24px;padding:15px;font-size:17px;font-weight:700;color:#fff;background:#27965a;border:0;border-radius:6px}
  .err{background:#fde8e8;border:1px solid #e2a1a1;padding:10px 14px;border-radius:6px;margin-top:16px}
  .ok{background:#fff;border-radius:8px;padding:24px;text-align:center;margin-top:20px}
  .ok .id{font-size:28px;font-weight:700;color:#1f4e79;margin:12px 0}
</style>
</head>
<body>
<header><h1>REGISTRAR'S OFFICE</h1><p>Submit your document<?= $deskOk ? ' &middot; ' . h($desk) : '' ?></p></header>
<main>
<?php if (!$deskOk): ?>
  <div class="err">This QR code is not valid. Please scan the QR code on the officer's desk again.</div>
<?php elseif ($showDone): ?>
  <div class="ok">
    <div>&#10004; Your submission was received</div>
    <div class="id"><?= h($done) ?></div>
    <p>Keep this Tracking ID. Hand your document to the officer at <b><?= h($desk) ?></b>. You will get an SMS and email once it is received.</p>
  </div>
<?php else: ?>
  <?php foreach ($errors as $e): ?><div class="err"><?= h($e) ?></div><?php endforeach; ?>
  <form method="post" autocomplete="on">
    <input type="hidden" name="desk" value="<?= h($desk) ?>">
    <label for="name">Full Name</label>
    <input id="name" name="name" autocomplete="name" required maxlength="100" value="<?= h($v['name']) ?>">
    <label for="phone">Phone Number (for SMS)</label>
    <input id="phone" name="phone" type="tel" inputmode="tel" autocomplete="tel" required placeholder="024 000 0000" value="<?= h($v['phone']) ?>">
    <label for="email">Email Address</label>
    <input id="email" name="email" type="email" autocomplete="email" required maxlength="100" value="<?= h($v['email']) ?>">
    <label for="doc">Document Type</label>
    <select id="doc" name="doc" required>
      <option value="">Choose...</option>
      <?php foreach ($docTypes as $d): ?><option<?= $v['doc'] === $d ? ' selected' : '' ?>><?= h($d) ?></option><?php endforeach; ?>
    </select>
    <button type="submit">SUBMIT</button>
  </form>
<?php endif; ?>
</main>
</body>
</html>
