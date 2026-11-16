<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeskDashboard
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblActiveOfficer = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblGrid = New System.Windows.Forms.Label()
        Me.dgvDocumentLogs = New System.Windows.Forms.DataGridView()
        Me.grpDetails = New System.Windows.Forms.GroupBox()
        Me.lblTracking = New System.Windows.Forms.Label()
        Me.txtTrackingID = New System.Windows.Forms.TextBox()
        Me.lblStamped = New System.Windows.Forms.Label()
        Me.lblReceivingOfficer = New System.Windows.Forms.Label()
        Me.lblUpdate = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.btnUpdateStatus = New System.Windows.Forms.Button()
        CType(Me.dgvDocumentLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.grpDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        ' pnlHeader
        '
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(920, 60)
        Me.pnlHeader.TabIndex = 0
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(31, 78, 121)
        '
        ' lblActiveOfficer
        '
        Me.lblActiveOfficer.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblActiveOfficer.Location = New System.Drawing.Point(20, 17)
        Me.lblActiveOfficer.Name = "lblActiveOfficer"
        Me.lblActiveOfficer.AutoSize = True
        Me.lblActiveOfficer.TabIndex = 1
        Me.lblActiveOfficer.Text = "Logged In: "
        Me.lblActiveOfficer.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblActiveOfficer.BackColor = System.Drawing.Color.FromArgb(31, 78, 121)
        '
        ' lblSearch
        '
        Me.lblSearch.Location = New System.Drawing.Point(20, 81)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.AutoSize = True
        Me.lblSearch.TabIndex = 2
        Me.lblSearch.Text = "Search Tracking ID:"
        '
        ' txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(170, 77)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(200, 27)
        Me.txtSearch.TabIndex = 3
        '
        ' btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.UseVisualStyleBackColor = False
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.Location = New System.Drawing.Point(380, 75)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(90, 31)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(46, 117, 182)
        '
        ' btnRefresh
        '
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.UseVisualStyleBackColor = False
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.Location = New System.Drawing.Point(480, 75)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 31)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(110, 125, 145)
        '
        ' lblGrid
        '
        Me.lblGrid.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblGrid.Location = New System.Drawing.Point(20, 122)
        Me.lblGrid.Name = "lblGrid"
        Me.lblGrid.AutoSize = True
        Me.lblGrid.TabIndex = 6
        Me.lblGrid.Text = "REAL-TIME SUBMISSIONS"
        '
        ' dgvDocumentLogs
        '
        Me.dgvDocumentLogs.Location = New System.Drawing.Point(20, 148)
        Me.dgvDocumentLogs.Name = "dgvDocumentLogs"
        Me.dgvDocumentLogs.Size = New System.Drawing.Size(880, 265)
        Me.dgvDocumentLogs.TabIndex = 7
        Me.dgvDocumentLogs.ReadOnly = True
        Me.dgvDocumentLogs.AllowUserToAddRows = False
        Me.dgvDocumentLogs.AllowUserToDeleteRows = False
        Me.dgvDocumentLogs.MultiSelect = False
        Me.dgvDocumentLogs.RowHeadersVisible = False
        Me.dgvDocumentLogs.BackgroundColor = System.Drawing.Color.White
        Me.dgvDocumentLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDocumentLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        '
        ' grpDetails
        '
        Me.grpDetails.Location = New System.Drawing.Point(20, 428)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(880, 210)
        Me.grpDetails.TabIndex = 8
        Me.grpDetails.Text = "SELECTED DOCUMENT DETAILS"
        '
        ' lblTracking
        '
        Me.lblTracking.Location = New System.Drawing.Point(20, 40)
        Me.lblTracking.Name = "lblTracking"
        Me.lblTracking.AutoSize = True
        Me.lblTracking.TabIndex = 9
        Me.lblTracking.Text = "Tracking Code:"
        '
        ' txtTrackingID
        '
        Me.txtTrackingID.Location = New System.Drawing.Point(170, 36)
        Me.txtTrackingID.Name = "txtTrackingID"
        Me.txtTrackingID.Size = New System.Drawing.Size(250, 27)
        Me.txtTrackingID.TabIndex = 10
        Me.txtTrackingID.ReadOnly = True
        '
        ' lblStamped
        '
        Me.lblStamped.Location = New System.Drawing.Point(20, 86)
        Me.lblStamped.Name = "lblStamped"
        Me.lblStamped.AutoSize = True
        Me.lblStamped.TabIndex = 11
        Me.lblStamped.Text = "Auto-Stamped By:"
        '
        ' lblReceivingOfficer
        '
        Me.lblReceivingOfficer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblReceivingOfficer.Location = New System.Drawing.Point(170, 86)
        Me.lblReceivingOfficer.Name = "lblReceivingOfficer"
        Me.lblReceivingOfficer.AutoSize = True
        Me.lblReceivingOfficer.TabIndex = 12
        Me.lblReceivingOfficer.Text = "-"
        '
        ' lblUpdate
        '
        Me.lblUpdate.Location = New System.Drawing.Point(20, 132)
        Me.lblUpdate.Name = "lblUpdate"
        Me.lblUpdate.AutoSize = True
        Me.lblUpdate.TabIndex = 13
        Me.lblUpdate.Text = "Update Status:"
        '
        ' cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(170, 128)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(250, 28)
        Me.cmbStatus.TabIndex = 14
        '
        ' btnAccept
        '
        Me.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccept.FlatAppearance.BorderSize = 0
        Me.btnAccept.UseVisualStyleBackColor = False
        Me.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAccept.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnAccept.Location = New System.Drawing.Point(460, 36)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(400, 48)
        Me.btnAccept.TabIndex = 15
        Me.btnAccept.Text = "ACCEPT DOCUMENT"
        Me.btnAccept.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnAccept.BackColor = System.Drawing.Color.FromArgb(39, 150, 90)
        '
        ' btnUpdateStatus
        '
        Me.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateStatus.FlatAppearance.BorderSize = 0
        Me.btnUpdateStatus.UseVisualStyleBackColor = False
        Me.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdateStatus.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnUpdateStatus.Location = New System.Drawing.Point(460, 110)
        Me.btnUpdateStatus.Name = "btnUpdateStatus"
        Me.btnUpdateStatus.Size = New System.Drawing.Size(400, 48)
        Me.btnUpdateStatus.TabIndex = 16
        Me.btnUpdateStatus.Text = "UPDATE && SEND SMS ALERT"
        Me.btnUpdateStatus.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(46, 117, 182)
        Me.pnlHeader.Controls.Add(Me.lblActiveOfficer)
        Me.grpDetails.Controls.Add(Me.lblTracking)
        Me.grpDetails.Controls.Add(Me.txtTrackingID)
        Me.grpDetails.Controls.Add(Me.lblStamped)
        Me.grpDetails.Controls.Add(Me.lblReceivingOfficer)
        Me.grpDetails.Controls.Add(Me.lblUpdate)
        Me.grpDetails.Controls.Add(Me.cmbStatus)
        Me.grpDetails.Controls.Add(Me.btnAccept)
        Me.grpDetails.Controls.Add(Me.btnUpdateStatus)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.lblSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lblGrid)
        Me.Controls.Add(Me.dgvDocumentLogs)
        Me.Controls.Add(Me.grpDetails)
        '
        ' frmDeskDashboard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(920, 660)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmDeskDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VDMS Dashboard"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        CType(Me.dgvDocumentLogs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblActiveOfficer As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblGrid As System.Windows.Forms.Label
    Friend WithEvents dgvDocumentLogs As System.Windows.Forms.DataGridView
    Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
    Friend WithEvents lblTracking As System.Windows.Forms.Label
    Friend WithEvents txtTrackingID As System.Windows.Forms.TextBox
    Friend WithEvents lblStamped As System.Windows.Forms.Label
    Friend WithEvents lblReceivingOfficer As System.Windows.Forms.Label
    Friend WithEvents lblUpdate As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnUpdateStatus As System.Windows.Forms.Button

End Class
