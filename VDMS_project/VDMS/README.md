# VDMS - how to run

## How the pieces fit
- **Visitor:** scans the QR code on the officer's desk with their phone -> the web form (`web/form.php`) opens -> submits -> gets a Tracking ID. The document is saved as *Pending*.
- **Officer:** logs in to the desktop app (`VDMS.sln`), sees the Pending submission (refreshes every 15 s), clicks **Accept Document** -> their name is stamped and the visitor gets SMS + email.
- Both use the same MySQL database.

## Setup (XAMPP)
1. Start **Apache** and **MySQL** in XAMPP.
2. phpMyAdmin: run `Database/schema.sql`, then `Database/seed.sql`.
   (Already ran the old schema? Run: `ALTER TABLE Document_Logs ADD COLUMN Desk_Station VARCHAR(30) NULL AFTER Document_Type;`)
3. Copy the `web` folder to `C:\xampp\htdocs\` and rename it `vdms`. Test: http://localhost/vdms/form.php?desk=Desk-01
4. Find this PC's IP (`ipconfig` -> IPv4, e.g. 192.168.1.20). Open http://192.168.1.20/vdms/desk_qr.html, check the address, click Generate, then Print one QR per desk.
5. Phones must be on the same network as this PC, and Windows Firewall must allow Apache (port 80).
6. Open `VDMS.sln` in Visual Studio 2022 (".NET desktop development" workload), edit `App.config` if needed, press F5.
   Login: **OFF-101 / ChangeMe123!**

Before going live: run `Database/web_user.sql` and use that limited user in `web/config.php`, and put real Twilio/SMTP keys in `App.config`.
