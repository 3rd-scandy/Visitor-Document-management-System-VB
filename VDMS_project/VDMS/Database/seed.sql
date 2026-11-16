USE vdms_db;
-- Test password for both officers: ChangeMe123!  (change it!)
INSERT INTO Users (Officer_ID, Full_Name, Role, Email, Terminal_Station, Password_Hash) VALUES
('OFF-101','John Doe','Desk Officer','jdoe@registrar.edu','Desk-01','$2b$12$psePPoKAqr8hbRiXMyJqG.RNTCInXvV8dl.N6HCwRDNDpL5u0Qu0K'),
('OFF-102','Sarah Smith','Desk Officer','ssmith@registrar.edu','Desk-02','$2b$12$psePPoKAqr8hbRiXMyJqG.RNTCInXvV8dl.N6HCwRDNDpL5u0Qu0K');

INSERT INTO Visitors (Visitor_ID, Full_Name, Phone_Number, Email, QR_Code_Hash) VALUES
('VIS-5001','Alice Johnson','+233240000001','alice@student.edu','HASH_QR_9823471'),
('VIS-5002','Kwame Mensah','+233240000002','kwame@student.edu','HASH_QR_9823472');

INSERT INTO Tracking_Sequence () VALUES (),();   -- reserves IDs 1 and 2 used below

INSERT INTO Document_Logs (Tracking_ID, Visitor_ID, Receiving_Officer_ID, Document_Type, Desk_Station, Current_Status) VALUES
('DOC-2026-0001','VIS-5001','OFF-101','Transcript Request','Desk-01','Received'),
('DOC-2026-0002','VIS-5002',NULL,'Deferment Form','Desk-02','Pending');

INSERT INTO Notification_Logs (Tracking_ID, Channel, Recipient_Contact, Delivery_Status) VALUES
('DOC-2026-0001','SMS','+233240000001','Sent'),
('DOC-2026-0001','Email','alice@student.edu','Sent');
