-- OPTIONAL but recommended: the public web form should not connect as root.
-- Run once, then put these credentials in web/config.php
CREATE USER IF NOT EXISTS 'vdms_web'@'localhost' IDENTIFIED BY 'change_this_password';
GRANT SELECT, INSERT ON vdms_db.Visitors TO 'vdms_web'@'localhost';
GRANT INSERT ON vdms_db.Document_Logs TO 'vdms_web'@'localhost';
GRANT INSERT ON vdms_db.Tracking_Sequence TO 'vdms_web'@'localhost';
FLUSH PRIVILEGES;
