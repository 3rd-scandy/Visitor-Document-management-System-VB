Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class frmLogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUsername.Text.Trim() = "" OrElse txtPassword.Text = "" OrElse cmbTerminal.Text = "" Then
            MessageBox.Show("Enter your ID, password and terminal.") : Return
        End If
        Try
            Using conn = GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT Officer_ID, Full_Name, Password_Hash FROM Users WHERE Officer_ID=@u", conn)
                    cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim())
                    Using r = cmd.ExecuteReader()
                        If r.Read() AndAlso VerifyPassword(txtPassword.Text, r.GetString("Password_Hash")) Then
                            GlobalSession.OfficerID = r.GetString("Officer_ID")
                            GlobalSession.OfficerName = r.GetString("Full_Name")
                            GlobalSession.TerminalStation = cmbTerminal.Text
                        Else
                            MessageBox.Show("Invalid ID or password.", "Login failed") : Return
                        End If
                    End Using
                End Using
            End Using
            Dim dash As New frmDeskDashboard()
            AddHandler dash.FormClosed, Sub() Application.Exit()
            dash.Show()
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show("Could not log in: " & ex.Message)
        End Try
    End Sub

End Class
