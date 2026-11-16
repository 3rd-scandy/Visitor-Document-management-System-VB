<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblTerminal = New System.Windows.Forms.Label()
        Me.cmbTerminal = New System.Windows.Forms.ComboBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        ' pnlHeader
        '
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(440, 85)
        Me.pnlHeader.TabIndex = 0
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(31, 78, 121)
        '
        ' lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.Location = New System.Drawing.Point(20, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.AutoSize = True
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "REGISTRAR'S OFFICE VDMS"
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(31, 78, 121)
        '
        ' lblSubtitle
        '
        Me.lblSubtitle.Location = New System.Drawing.Point(20, 50)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.TabIndex = 2
        Me.lblSubtitle.Text = "Officer Login"
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(200, 220, 240)
        Me.lblSubtitle.BackColor = System.Drawing.Color.FromArgb(31, 78, 121)
        '
        ' lblUser
        '
        Me.lblUser.Location = New System.Drawing.Point(40, 110)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.AutoSize = True
        Me.lblUser.TabIndex = 3
        Me.lblUser.Text = "Staff ID / Username:"
        '
        ' txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(40, 134)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(360, 27)
        Me.txtUsername.TabIndex = 4
        '
        ' lblPass
        '
        Me.lblPass.Location = New System.Drawing.Point(40, 176)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.AutoSize = True
        Me.lblPass.TabIndex = 5
        Me.lblPass.Text = "Password:"
        '
        ' txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(40, 200)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(360, 27)
        Me.txtPassword.TabIndex = 6
        Me.txtPassword.UseSystemPasswordChar = True
        '
        ' lblTerminal
        '
        Me.lblTerminal.Location = New System.Drawing.Point(40, 242)
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.AutoSize = True
        Me.lblTerminal.TabIndex = 7
        Me.lblTerminal.Text = "Terminal Station:"
        '
        ' cmbTerminal
        '
        Me.cmbTerminal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTerminal.FormattingEnabled = True
        Me.cmbTerminal.Items.AddRange(New Object() {"Desk-01", "Desk-02", "Desk-03", "Desk-04"})
        Me.cmbTerminal.Location = New System.Drawing.Point(40, 266)
        Me.cmbTerminal.Name = "cmbTerminal"
        Me.cmbTerminal.Size = New System.Drawing.Size(360, 28)
        Me.cmbTerminal.TabIndex = 8
        Me.cmbTerminal.SelectedIndex = 0
        '
        ' btnLogin
        '
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.UseVisualStyleBackColor = False
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnLogin.Location = New System.Drawing.Point(40, 312)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(360, 42)
        Me.btnLogin.TabIndex = 9
        Me.btnLogin.Text = "LOG IN"
        Me.btnLogin.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(46, 117, 182)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblTerminal)
        Me.Controls.Add(Me.cmbTerminal)
        Me.Controls.Add(Me.btnLogin)
        '
        ' frmLogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(440, 380)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VDMS - Officer Login"
        Me.AcceptButton = Me.btnLogin
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSubtitle As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblTerminal As System.Windows.Forms.Label
    Friend WithEvents cmbTerminal As System.Windows.Forms.ComboBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button

End Class
