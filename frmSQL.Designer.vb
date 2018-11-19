<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSQL
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSQL))
        Me.ckbDetectProxy = New System.Windows.Forms.CheckBox()
        Me.lblAppToken = New System.Windows.Forms.Label()
        Me.txtAppToken = New System.Windows.Forms.TextBox()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.cmbDSN = New System.Windows.Forms.ComboBox()
        Me.lblDSN = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.gbSQL = New System.Windows.Forms.GroupBox()
        Me.btnFields = New System.Windows.Forms.Button()
        Me.cmbCatalogs = New System.Windows.Forms.ComboBox()
        Me.ListBoxColumns = New System.Windows.Forms.ListBox()
        Me.GroupBoxTables = New System.Windows.Forms.GroupBox()
        Me.btnALTER = New System.Windows.Forms.Button()
        Me.btnDROP = New System.Windows.Forms.Button()
        Me.btnCREATE = New System.Windows.Forms.Button()
        Me.btnINSERT = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnUPDATE = New System.Windows.Forms.Button()
        Me.chkWrap = New System.Windows.Forms.CheckBox()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.btnCheckSQL = New System.Windows.Forms.Button()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.btnText = New System.Windows.Forms.Button()
        Me.cmbTables = New System.Windows.Forms.ComboBox()
        Me.btnTime = New System.Windows.Forms.Button()
        Me.dateForm = New System.Windows.Forms.DateTimePicker()
        Me.TimeForm = New System.Windows.Forms.DateTimePicker()
        Me.btnDate = New System.Windows.Forms.Button()
        Me.btnDateTime = New System.Windows.Forms.Button()
        Me.DateTimeForm = New System.Windows.Forms.DateTimePicker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbPassword = New System.Windows.Forms.ComboBox()
        Me.btnAppToken = New System.Windows.Forms.Button()
        Me.btnUserToken = New System.Windows.Forms.Button()
        Me.gbSQL.SuspendLayout()
        Me.GroupBoxTables.SuspendLayout()
        Me.SuspendLayout()
        '
        'ckbDetectProxy
        '
        Me.ckbDetectProxy.AutoSize = True
        Me.ckbDetectProxy.Location = New System.Drawing.Point(842, 39)
        Me.ckbDetectProxy.Name = "ckbDetectProxy"
        Me.ckbDetectProxy.Size = New System.Drawing.Size(188, 17)
        Me.ckbDetectProxy.TabIndex = 52
        Me.ckbDetectProxy.Text = "Automatically detect proxy settings"
        Me.ckbDetectProxy.UseVisualStyleBackColor = True
        '
        'lblAppToken
        '
        Me.lblAppToken.AutoSize = True
        Me.lblAppToken.Location = New System.Drawing.Point(13, 71)
        Me.lblAppToken.Name = "lblAppToken"
        Me.lblAppToken.Size = New System.Drawing.Size(148, 13)
        Me.lblAppToken.TabIndex = 50
        Me.lblAppToken.Text = "QuickBase Application Token"
        '
        'txtAppToken
        '
        Me.txtAppToken.Location = New System.Drawing.Point(10, 90)
        Me.txtAppToken.Name = "txtAppToken"
        Me.txtAppToken.Size = New System.Drawing.Size(258, 20)
        Me.txtAppToken.TabIndex = 49
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(607, 18)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(93, 13)
        Me.lblServer.TabIndex = 48
        Me.lblServer.Text = "QuickBase Server"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(610, 37)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(212, 20)
        Me.txtServer.TabIndex = 47
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(285, 35)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(276, 20)
        Me.txtPassword.TabIndex = 45
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(13, 18)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(110, 13)
        Me.lblUsername.TabIndex = 44
        Me.lblUsername.Text = "QuickBase Username"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(-1, 37)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(269, 20)
        Me.txtUsername.TabIndex = 43
        '
        'cmbDSN
        '
        Me.cmbDSN.FormattingEnabled = True
        Me.cmbDSN.Location = New System.Drawing.Point(284, 89)
        Me.cmbDSN.Name = "cmbDSN"
        Me.cmbDSN.Size = New System.Drawing.Size(350, 21)
        Me.cmbDSN.TabIndex = 57
        '
        'lblDSN
        '
        Me.lblDSN.AutoSize = True
        Me.lblDSN.Location = New System.Drawing.Point(287, 71)
        Me.lblDSN.Name = "lblDSN"
        Me.lblDSN.Size = New System.Drawing.Size(30, 13)
        Me.lblDSN.TabIndex = 58
        Me.lblDSN.Text = "DSN"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(655, 89)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(73, 20)
        Me.btnConnect.TabIndex = 59
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'gbSQL
        '
        Me.gbSQL.Controls.Add(Me.btnFields)
        Me.gbSQL.Controls.Add(Me.cmbCatalogs)
        Me.gbSQL.Controls.Add(Me.ListBoxColumns)
        Me.gbSQL.Controls.Add(Me.GroupBoxTables)
        Me.gbSQL.Controls.Add(Me.chkWrap)
        Me.gbSQL.Controls.Add(Me.btnGo)
        Me.gbSQL.Controls.Add(Me.btnCheckSQL)
        Me.gbSQL.Controls.Add(Me.txtText)
        Me.gbSQL.Controls.Add(Me.txtSQL)
        Me.gbSQL.Controls.Add(Me.btnText)
        Me.gbSQL.Controls.Add(Me.cmbTables)
        Me.gbSQL.Controls.Add(Me.btnTime)
        Me.gbSQL.Controls.Add(Me.dateForm)
        Me.gbSQL.Controls.Add(Me.TimeForm)
        Me.gbSQL.Controls.Add(Me.btnDate)
        Me.gbSQL.Controls.Add(Me.btnDateTime)
        Me.gbSQL.Controls.Add(Me.DateTimeForm)
        Me.gbSQL.Location = New System.Drawing.Point(10, 116)
        Me.gbSQL.Name = "gbSQL"
        Me.gbSQL.Size = New System.Drawing.Size(1030, 566)
        Me.gbSQL.TabIndex = 75
        Me.gbSQL.TabStop = False
        Me.gbSQL.Visible = False
        '
        'btnFields
        '
        Me.btnFields.Location = New System.Drawing.Point(643, 18)
        Me.btnFields.Name = "btnFields"
        Me.btnFields.Size = New System.Drawing.Size(103, 22)
        Me.btnFields.TabIndex = 90
        Me.btnFields.Text = "Insert Fields"
        Me.btnFields.UseVisualStyleBackColor = True
        Me.btnFields.Visible = False
        '
        'cmbCatalogs
        '
        Me.cmbCatalogs.FormattingEnabled = True
        Me.cmbCatalogs.Location = New System.Drawing.Point(436, 46)
        Me.cmbCatalogs.Name = "cmbCatalogs"
        Me.cmbCatalogs.Size = New System.Drawing.Size(310, 21)
        Me.cmbCatalogs.TabIndex = 89
        '
        'ListBoxColumns
        '
        Me.ListBoxColumns.FormattingEnabled = True
        Me.ListBoxColumns.Location = New System.Drawing.Point(752, 8)
        Me.ListBoxColumns.Name = "ListBoxColumns"
        Me.ListBoxColumns.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBoxColumns.Size = New System.Drawing.Size(272, 134)
        Me.ListBoxColumns.TabIndex = 88
        '
        'GroupBoxTables
        '
        Me.GroupBoxTables.Controls.Add(Me.btnALTER)
        Me.GroupBoxTables.Controls.Add(Me.btnDROP)
        Me.GroupBoxTables.Controls.Add(Me.btnCREATE)
        Me.GroupBoxTables.Controls.Add(Me.btnINSERT)
        Me.GroupBoxTables.Controls.Add(Me.btnDelete)
        Me.GroupBoxTables.Controls.Add(Me.btnSelect)
        Me.GroupBoxTables.Controls.Add(Me.btnUPDATE)
        Me.GroupBoxTables.Location = New System.Drawing.Point(8, 13)
        Me.GroupBoxTables.Name = "GroupBoxTables"
        Me.GroupBoxTables.Size = New System.Drawing.Size(430, 31)
        Me.GroupBoxTables.TabIndex = 86
        Me.GroupBoxTables.TabStop = False
        Me.GroupBoxTables.Visible = False
        '
        'btnALTER
        '
        Me.btnALTER.Location = New System.Drawing.Point(302, 7)
        Me.btnALTER.Name = "btnALTER"
        Me.btnALTER.Size = New System.Drawing.Size(60, 24)
        Me.btnALTER.TabIndex = 84
        Me.btnALTER.Text = "ALTER"
        Me.btnALTER.UseVisualStyleBackColor = True
        '
        'btnDROP
        '
        Me.btnDROP.Location = New System.Drawing.Point(362, 7)
        Me.btnDROP.Name = "btnDROP"
        Me.btnDROP.Size = New System.Drawing.Size(60, 24)
        Me.btnDROP.TabIndex = 83
        Me.btnDROP.Text = "DROP"
        Me.btnDROP.UseVisualStyleBackColor = True
        '
        'btnCREATE
        '
        Me.btnCREATE.Location = New System.Drawing.Point(241, 7)
        Me.btnCREATE.Name = "btnCREATE"
        Me.btnCREATE.Size = New System.Drawing.Size(60, 24)
        Me.btnCREATE.TabIndex = 82
        Me.btnCREATE.Text = "CREATE"
        Me.btnCREATE.UseVisualStyleBackColor = True
        '
        'btnINSERT
        '
        Me.btnINSERT.Location = New System.Drawing.Point(60, 7)
        Me.btnINSERT.Name = "btnINSERT"
        Me.btnINSERT.Size = New System.Drawing.Size(58, 24)
        Me.btnINSERT.TabIndex = 78
        Me.btnINSERT.Text = "INSERT"
        Me.btnINSERT.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(181, 7)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 24)
        Me.btnDelete.TabIndex = 81
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(0, 7)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(58, 24)
        Me.btnSelect.TabIndex = 75
        Me.btnSelect.Text = "SELECT"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnUPDATE
        '
        Me.btnUPDATE.Location = New System.Drawing.Point(120, 7)
        Me.btnUPDATE.Name = "btnUPDATE"
        Me.btnUPDATE.Size = New System.Drawing.Size(60, 24)
        Me.btnUPDATE.TabIndex = 79
        Me.btnUPDATE.Text = "UPDATE"
        Me.btnUPDATE.UseVisualStyleBackColor = True
        '
        'chkWrap
        '
        Me.chkWrap.AutoSize = True
        Me.chkWrap.Checked = True
        Me.chkWrap.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWrap.Location = New System.Drawing.Point(13, 524)
        Me.chkWrap.Name = "chkWrap"
        Me.chkWrap.Size = New System.Drawing.Size(81, 17)
        Me.chkWrap.TabIndex = 77
        Me.chkWrap.Text = "Word Wrap"
        Me.chkWrap.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(388, 524)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(86, 22)
        Me.btnGo.TabIndex = 56
        Me.btnGo.Text = "Execute SQL"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'btnCheckSQL
        '
        Me.btnCheckSQL.Location = New System.Drawing.Point(255, 524)
        Me.btnCheckSQL.Name = "btnCheckSQL"
        Me.btnCheckSQL.Size = New System.Drawing.Size(119, 22)
        Me.btnCheckSQL.TabIndex = 74
        Me.btnCheckSQL.Text = "Check SQL Syntax"
        Me.btnCheckSQL.UseVisualStyleBackColor = True
        '
        'txtText
        '
        Me.txtText.Location = New System.Drawing.Point(394, 109)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(352, 20)
        Me.txtText.TabIndex = 73
        '
        'txtSQL
        '
        Me.txtSQL.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSQL.Location = New System.Drawing.Point(11, 148)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSQL.Size = New System.Drawing.Size(1013, 359)
        Me.txtSQL.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtSQL, "Type your SQL statement here")
        '
        'btnText
        '
        Me.btnText.Location = New System.Drawing.Point(393, 80)
        Me.btnText.Name = "btnText"
        Me.btnText.Size = New System.Drawing.Size(75, 23)
        Me.btnText.TabIndex = 72
        Me.btnText.Text = "Insert Text"
        Me.btnText.UseVisualStyleBackColor = True
        '
        'cmbTables
        '
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Location = New System.Drawing.Point(5, 46)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(425, 21)
        Me.cmbTables.TabIndex = 61
        Me.cmbTables.Text = "Please choose a table"
        '
        'btnTime
        '
        Me.btnTime.Location = New System.Drawing.Point(285, 80)
        Me.btnTime.Name = "btnTime"
        Me.btnTime.Size = New System.Drawing.Size(75, 23)
        Me.btnTime.TabIndex = 69
        Me.btnTime.Text = "Insert Time"
        Me.btnTime.UseVisualStyleBackColor = True
        '
        'dateForm
        '
        Me.dateForm.CustomFormat = "yyyy-MM-dd"
        Me.dateForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateForm.Location = New System.Drawing.Point(5, 109)
        Me.dateForm.Name = "dateForm"
        Me.dateForm.Size = New System.Drawing.Size(101, 20)
        Me.dateForm.TabIndex = 64
        '
        'TimeForm
        '
        Me.TimeForm.CustomFormat = "hh:mm:ss"
        Me.TimeForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TimeForm.Location = New System.Drawing.Point(285, 109)
        Me.TimeForm.Name = "TimeForm"
        Me.TimeForm.ShowUpDown = True
        Me.TimeForm.Size = New System.Drawing.Size(91, 20)
        Me.TimeForm.TabIndex = 68
        '
        'btnDate
        '
        Me.btnDate.Location = New System.Drawing.Point(5, 80)
        Me.btnDate.Name = "btnDate"
        Me.btnDate.Size = New System.Drawing.Size(75, 23)
        Me.btnDate.TabIndex = 65
        Me.btnDate.Text = "Insert Date"
        Me.btnDate.UseVisualStyleBackColor = True
        '
        'btnDateTime
        '
        Me.btnDateTime.Location = New System.Drawing.Point(112, 80)
        Me.btnDateTime.Name = "btnDateTime"
        Me.btnDateTime.Size = New System.Drawing.Size(94, 23)
        Me.btnDateTime.TabIndex = 67
        Me.btnDateTime.Text = "Insert DateTime"
        Me.btnDateTime.UseVisualStyleBackColor = True
        '
        'DateTimeForm
        '
        Me.DateTimeForm.CustomFormat = "yyyy-MM-dd hh:mm:ss"
        Me.DateTimeForm.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeForm.Location = New System.Drawing.Point(112, 109)
        Me.DateTimeForm.Name = "DateTimeForm"
        Me.DateTimeForm.Size = New System.Drawing.Size(166, 20)
        Me.DateTimeForm.TabIndex = 66
        '
        'cmbPassword
        '
        Me.cmbPassword.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPassword.FormattingEnabled = True
        Me.cmbPassword.Items.AddRange(New Object() {"Please choose...", "QuickBase Password", "QuickBase User Token"})
        Me.cmbPassword.Location = New System.Drawing.Point(284, 10)
        Me.cmbPassword.Name = "cmbPassword"
        Me.cmbPassword.Size = New System.Drawing.Size(277, 21)
        Me.cmbPassword.TabIndex = 76
        '
        'btnAppToken
        '
        Me.btnAppToken.Location = New System.Drawing.Point(160, 65)
        Me.btnAppToken.Name = "btnAppToken"
        Me.btnAppToken.Size = New System.Drawing.Size(19, 20)
        Me.btnAppToken.TabIndex = 79
        Me.btnAppToken.Text = "?"
        Me.btnAppToken.UseVisualStyleBackColor = True
        '
        'btnUserToken
        '
        Me.btnUserToken.Location = New System.Drawing.Point(567, 11)
        Me.btnUserToken.Name = "btnUserToken"
        Me.btnUserToken.Size = New System.Drawing.Size(19, 20)
        Me.btnUserToken.TabIndex = 80
        Me.btnUserToken.Text = "?"
        Me.btnUserToken.UseVisualStyleBackColor = True
        '
        'frmSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 706)
        Me.Controls.Add(Me.btnUserToken)
        Me.Controls.Add(Me.btnAppToken)
        Me.Controls.Add(Me.cmbPassword)
        Me.Controls.Add(Me.gbSQL)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.lblDSN)
        Me.Controls.Add(Me.cmbDSN)
        Me.Controls.Add(Me.ckbDetectProxy)
        Me.Controls.Add(Me.lblAppToken)
        Me.Controls.Add(Me.txtAppToken)
        Me.Controls.Add(Me.lblServer)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.txtUsername)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSQL"
        Me.Text = "QuNect SQL"
        Me.gbSQL.ResumeLayout(False)
        Me.gbSQL.PerformLayout()
        Me.GroupBoxTables.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ckbDetectProxy As CheckBox
    Friend WithEvents lblAppToken As Label
    Friend WithEvents txtAppToken As TextBox
    Friend WithEvents lblServer As Label
    Friend WithEvents txtServer As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents cmbDSN As ComboBox
    Friend WithEvents lblDSN As Label
    Friend WithEvents btnConnect As Button
    Friend WithEvents gbSQL As GroupBox
    Friend WithEvents btnGo As Button
    Friend WithEvents btnCheckSQL As Button
    Friend WithEvents txtText As TextBox
    Friend WithEvents txtSQL As TextBox
    Friend WithEvents btnText As Button
    Friend WithEvents cmbTables As ComboBox
    Friend WithEvents btnTime As Button
    Friend WithEvents dateForm As DateTimePicker
    Friend WithEvents TimeForm As DateTimePicker
    Friend WithEvents btnDate As Button
    Friend WithEvents btnDateTime As Button
    Friend WithEvents DateTimeForm As DateTimePicker
    Friend WithEvents btnSelect As Button
    Friend WithEvents chkWrap As CheckBox
    Friend WithEvents btnINSERT As Button
    Friend WithEvents btnUPDATE As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents GroupBoxTables As GroupBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ListBoxColumns As ListBox
    Friend WithEvents cmbCatalogs As ComboBox
    Friend WithEvents btnALTER As Button
    Friend WithEvents btnDROP As Button
    Friend WithEvents btnCREATE As Button
    Friend WithEvents btnFields As Button
    Friend WithEvents cmbPassword As ComboBox
    Friend WithEvents btnAppToken As Button
    Friend WithEvents btnUserToken As Button
End Class
