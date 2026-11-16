Imports System.Net
Imports System.Net.Mail

Public Module EmailGatewayModule
    Public Sub SendEmailReceipt(recipientEmail As String, trackingID As String, officerName As String)
        Try
            Dim sender As String = Setting("SmtpSender")
            Using mail As New MailMessage()
                mail.From = New MailAddress(sender, "Central Registrar's Office")
                mail.To.Add(recipientEmail)
                mail.Subject = $"Document Logged Confirmation - [{trackingID}]"
                mail.IsBodyHtml = True
                mail.Body = "<h2>Registrar's Office Document Receipt</h2>" &
                    "<p>Dear Student/Visitor,</p>" &
                    "<p>Your document has been logged successfully.</p><ul>" &
                    $"<li><b>Tracking ID:</b> {WebUtility.HtmlEncode(trackingID)}</li>" &
                    $"<li><b>Receiving Officer:</b> {WebUtility.HtmlEncode(officerName)}</li>" &
                    $"<li><b>Date/Time:</b> {DateTime.Now:yyyy-MM-dd HH:mm:ss}</li></ul>" &
                    "<p>Keep your Tracking ID to check processing status.</p>"

                Using smtp As New SmtpClient(Setting("SmtpHost"), CInt(Setting("SmtpPort")))
                    smtp.Credentials = New NetworkCredential(sender, Setting("SmtpPassword"))
                    smtp.EnableSsl = True
                    smtp.Send(mail)
                End Using
            End Using
            LogNotificationAudit(trackingID, "Email", recipientEmail, "Sent")
        Catch ex As Exception
            LogNotificationAudit(trackingID, "Email", recipientEmail, "Failed", ex.Message)
        End Try
    End Sub
End Module
