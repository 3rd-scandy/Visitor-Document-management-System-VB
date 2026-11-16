Imports System.IO
Imports System.Net
Imports System.Text

Public Module SMSGatewayModule
    ' Receipt SMS (sent when an officer accepts a document)
    Public Sub SendSMSAlert(recipientPhone As String, trackingID As String, officerName As String)
        SendSms(recipientPhone, trackingID,
            $"Registrar's Office: Your document is received. Tracking ID: {trackingID}. Received by Officer {officerName}.")
    End Sub

    ' Status-change SMS (used by "Update & Send SMS Alert")
    Public Sub SendStatusSMS(recipientPhone As String, trackingID As String, newStatus As String)
        SendSms(recipientPhone, trackingID,
            $"Registrar's Office: Document {trackingID} status is now '{newStatus}'.")
    End Sub

    Private Sub SendSms(phone As String, trackingID As String, body As String)
        Try
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim sid As String = Setting("TwilioAccountSid")
            Dim token As String = Setting("TwilioAuthToken")
            Dim fromNum As String = Setting("TwilioFromNumber")

            Dim req = CType(WebRequest.Create($"https://api.twilio.com/2010-04-01/Accounts/{sid}/Messages.json"), HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/x-www-form-urlencoded"
            ' send credentials up front (Credentials property alone waits for a 401 challenge)
            req.Headers("Authorization") = "Basic " & Convert.ToBase64String(Encoding.ASCII.GetBytes(sid & ":" & token))

            Dim data = Encoding.UTF8.GetBytes(
                $"To={Uri.EscapeDataString(phone)}&From={Uri.EscapeDataString(fromNum)}&Body={Uri.EscapeDataString(body)}")
            req.ContentLength = data.Length
            Using s As Stream = req.GetRequestStream()
                s.Write(data, 0, data.Length)
            End Using

            ' GetResponse throws on non-2xx, so reaching the next line means Twilio accepted it
            Using resp = CType(req.GetResponse(), HttpWebResponse)
                LogNotificationAudit(trackingID, "SMS", phone, "Sent")
            End Using
        Catch ex As Exception
            LogNotificationAudit(trackingID, "SMS", phone, "Failed", ex.Message)
        End Try
    End Sub
End Module
