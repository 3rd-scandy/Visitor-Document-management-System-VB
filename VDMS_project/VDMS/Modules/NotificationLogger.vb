Imports MySql.Data.MySqlClient

' FIX 1: shared and Public, so both gateway modules can call it
Public Module NotificationLogger
    Public Sub LogNotificationAudit(trackingID As String, channel As String, recipient As String,
                                    status As String, Optional detail As String = Nothing)
        Try
            If detail IsNot Nothing AndAlso detail.Length > 255 Then detail = detail.Substring(0, 255)
            Using conn = GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "INSERT INTO Notification_Logs (Tracking_ID, Channel, Recipient_Contact, Delivery_Status, Error_Detail) " &
                    "VALUES (@t, @c, @r, @s, @d)", conn)
                    cmd.Parameters.AddWithValue("@t", trackingID)
                    cmd.Parameters.AddWithValue("@c", channel)
                    cmd.Parameters.AddWithValue("@r", recipient)
                    cmd.Parameters.AddWithValue("@s", status)
                    cmd.Parameters.AddWithValue("@d", If(detail, CObj(DBNull.Value)))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Audit log failed: " & ex.Message)   ' logging must never crash the app
        End Try
    End Sub
End Module
