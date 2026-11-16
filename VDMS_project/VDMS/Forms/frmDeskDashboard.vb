Imports System.Windows.Forms
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class frmDeskDashboard
    Private Sub frmDeskDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblActiveOfficer.Text = $"Logged In: {GlobalSession.OfficerName} ({GlobalSession.TerminalStation})"
        lblReceivingOfficer.Text = GlobalSession.OfficerName
        txtTrackingID.ReadOnly = True
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.Items.AddRange(AppConstants.Statuses.Where(Function(s) s <> "Pending").ToArray())
        LoadDocumentGrid()
        ' phone submissions arrive by themselves, so refresh every 15 seconds
        refreshTimer.Interval = 15000
        AddHandler refreshTimer.Tick, Sub() LoadDocumentGrid(txtSearch.Text.Trim())
        refreshTimer.Start()
    End Sub

    Private refreshTimer As New System.Windows.Forms.Timer()

    Private Sub LoadDocumentGrid(Optional filter As String = "")
        Using conn = GetConnection()
            Dim sql As String =
                "SELECT d.Tracking_ID, v.Full_Name AS Visitor_Name, d.Document_Type, d.Current_Status, " &
                "IFNULL(u.Full_Name,'-') AS Received_By, d.Desk_Station AS Desk, d.Submission_Timestamp AS Submitted " &
                "FROM Document_Logs d JOIN Visitors v ON v.Visitor_ID=d.Visitor_ID " &
                "LEFT JOIN Users u ON u.Officer_ID=d.Receiving_Officer_ID " &
                "WHERE d.Tracking_ID LIKE @f ORDER BY d.Submission_Timestamp DESC"
            Using da As New MySqlDataAdapter(sql, conn)
                da.SelectCommand.Parameters.AddWithValue("@f", "%" & filter & "%")
                Dim dt As New DataTable()
                da.Fill(dt)
                Dim sel As String = txtTrackingID.Text
                dgvDocumentLogs.DataSource = dt
                If sel <> "" Then
                    For Each row As DataGridViewRow In dgvDocumentLogs.Rows
                        If row.Cells("Tracking_ID").Value.ToString() = sel Then
                            dgvDocumentLogs.CurrentCell = row.Cells(0)
                            Exit For
                        End If
                    Next
                End If
            End Using
        End Using
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadDocumentGrid(txtSearch.Text.Trim())
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDocumentGrid()
    End Sub

    Private Sub dgvDocumentLogs_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDocumentLogs.SelectionChanged
        If dgvDocumentLogs.CurrentRow Is Nothing Then Return
        txtTrackingID.Text = dgvDocumentLogs.CurrentRow.Cells("Tracking_ID").Value.ToString()
        cmbStatus.Text = dgvDocumentLogs.CurrentRow.Cells("Current_Status").Value.ToString()
    End Sub

    ' Officer accepts a Pending phone submission: stamps THEIR session details, then notifies the visitor
    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        If txtTrackingID.Text = "" Then Return
        Dim rows As Integer
        Using conn = GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand(
                "UPDATE Document_Logs SET Receiving_Officer_ID=@o, Current_Status='Received' " &
                "WHERE Tracking_ID=@t AND Current_Status='Pending'", conn)
                cmd.Parameters.AddWithValue("@o", GlobalSession.OfficerID)
                cmd.Parameters.AddWithValue("@t", txtTrackingID.Text)
                rows = cmd.ExecuteNonQuery()
            End Using
        End Using
        If rows = 0 Then
            MessageBox.Show("This document was already accepted.") : LoadDocumentGrid() : Return
        End If
        Dim c = GetVisitorContact(txtTrackingID.Text)
        SendSMSAlert(c.Phone, txtTrackingID.Text, GlobalSession.OfficerName)
        SendEmailReceipt(c.Email, txtTrackingID.Text, GlobalSession.OfficerName)
        MessageBox.Show("Document accepted and visitor notified.")
        LoadDocumentGrid()
    End Sub

    ' FIX 7: btnUpdateStatus now actually works ("Update & Send SMS Alert")
    Private Sub btnUpdateStatus_Click(sender As Object, e As EventArgs) Handles btnUpdateStatus.Click
        If txtTrackingID.Text = "" OrElse cmbStatus.SelectedItem Is Nothing Then
            MessageBox.Show("Select a document and a status.") : Return
        End If
        Dim newStatus As String = cmbStatus.SelectedItem.ToString()
        Using conn = GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand(
                "UPDATE Document_Logs SET Current_Status=@s WHERE Tracking_ID=@t AND Current_Status<>'Pending'", conn)
                cmd.Parameters.AddWithValue("@s", newStatus)
                cmd.Parameters.AddWithValue("@t", txtTrackingID.Text)
                If cmd.ExecuteNonQuery() = 0 Then
                    MessageBox.Show("Accept the document first (it is still Pending).") : Return
                End If
            End Using
        End Using
        Dim c = GetVisitorContact(txtTrackingID.Text)
        SendStatusSMS(c.Phone, txtTrackingID.Text, newStatus)
        LoadDocumentGrid()
    End Sub

    Private Function GetVisitorContact(trackingID As String) As (Phone As String, Email As String)
        Using conn = GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand(
                "SELECT v.Phone_Number, v.Email FROM Document_Logs d JOIN Visitors v ON v.Visitor_ID=d.Visitor_ID WHERE d.Tracking_ID=@t", conn)
                cmd.Parameters.AddWithValue("@t", trackingID)
                Using r = cmd.ExecuteReader()
                    If r.Read() Then Return (r.GetString(0), r.GetString(1))
                End Using
            End Using
        End Using
        Return (Nothing, Nothing)
    End Function
End Class
