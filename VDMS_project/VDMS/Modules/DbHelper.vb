Imports System.Configuration
Imports MySql.Data.MySqlClient

' Add a reference to System.Configuration and NuGet packages: MySql.Data, BCrypt.Net-Next
Public Module AppConstants
    Public ReadOnly Statuses As String() = {"Pending", "Received", "In-Review", "Ready for Pickup", "Completed"}
End Module

Public Module DbHelper
    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(ConfigurationManager.ConnectionStrings("VDMS").ConnectionString)
    End Function

    Public Function Setting(key As String) As String
        Dim v As String = ConfigurationManager.AppSettings(key)
        If String.IsNullOrEmpty(v) Then Throw New ConfigurationErrorsException("Missing setting: " & key)
        Return v
    End Function

    ' FIX 6: unique, collision-free Tracking ID from a database counter
    Public Function NextTrackingID(conn As MySqlConnection, tx As MySqlTransaction) As String
        Using cmd As New MySqlCommand("INSERT INTO Tracking_Sequence () VALUES ()", conn, tx)
            cmd.ExecuteNonQuery()
            Return "DOC-" & Date.Now.Year & "-" & cmd.LastInsertedId.ToString("D4")
        End Using
    End Function
End Module

Public Module PasswordHelper
    Public Function HashPassword(plain As String) As String
        Return BCrypt.Net.BCrypt.HashPassword(plain)
    End Function
    Public Function VerifyPassword(plain As String, hash As String) As Boolean
        Return BCrypt.Net.BCrypt.Verify(plain, hash)
    End Function
End Module
