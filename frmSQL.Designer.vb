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
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.ckbDetectProxy = New System.Windows.Forms.CheckBox()
        Me.lblAppToken = New System.Windows.Forms.Label()
        Me.txtAppToken = New System.Windows.Forms.TextBox()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.cmbDSN = New System.Windows.Forms.ComboBox()
        Me.lblDSN = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.gbSQL = New System.Windows.Forms.GroupBox()
        Me.GroupBoxTables = New System.Windows.Forms.GroupBox()
        Me.btnINSERT = New System.Windows.Forms.Button()
        Me.btnTable = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.lblInsert = New System.Windows.Forms.Label()
        Me.btnUPDATE = New System.Windows.Forms.Button()
        Me.GroupBoxColumn = New System.Windows.Forms.GroupBox()
        Me.lblSelect2 = New System.Windows.Forms.Label()
        Me.btnINSERTColumn = New System.Windows.Forms.Button()
        Me.btnUPDATEColumn = New System.Windows.Forms.Button()
        Me.btnColumn = New System.Windows.Forms.Button()
        Me.btnSelectOneColumn = New System.Windows.Forms.Button()
        Me.chkWrap = New System.Windows.Forms.CheckBox()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.btnCheckSQL = New System.Windows.Forms.Button()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.btnText = New System.Windows.Forms.Button()
        Me.cmbTables = New System.Windows.Forms.ComboBox()
        Me.cmbFields = New System.Windows.Forms.ComboBox()
        Me.btnTime = New System.Windows.Forms.Button()
        Me.dateForm = New System.Windows.Forms.DateTimePicker()
        Me.TimeForm = New System.Windows.Forms.DateTimePicker()
        Me.btnDate = New System.Windows.Forms.Button()
        Me.btnDateTime = New System.Windows.Forms.Button()
        Me.DateTimeForm = New System.Windows.Forms.DateTimePicker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbSQL.SuspendLayout()
        Me.GroupBoxTables.SuspendLayout()
        Me.GroupBoxColumn.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(186, 17)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(0, 13)
        Me.lblProgress.TabIndex = 54
        '
        'ckbDetectProxy
        '
        Me.ckbDetectProxy.AutoSize = True
        Me.ckbDetectProxy.Location = New System.Drawing.Point(541, 39)
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
        Me.lblServer.Location = New System.Drawing.Point(287, 18)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(93, 13)
        Me.lblServer.TabIndex = 48
        Me.lblServer.Text = "QuickBase Server"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(284, 37)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(237, 20)
        Me.txtServer.TabIndex = 47
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(151, 18)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(108, 13)
        Me.lblPassword.TabIndex = 46
        Me.lblPassword.Text = "QuickBase Password"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(148, 37)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(120, 20)
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
        Me.txtUsername.Location = New System.Drawing.Point(10, 37)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(120, 20)
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
        Me.gbSQL.Controls.Add(Me.GroupBoxTables)
        Me.gbSQL.Controls.Add(Me.GroupBoxColumn)
        Me.gbSQL.Controls.Add(Me.chkWrap)
        Me.gbSQL.Controls.Add(Me.btnGo)
        Me.gbSQL.Controls.Add(Me.btnCheckSQL)
        Me.gbSQL.Controls.Add(Me.txtText)
        Me.gbSQL.Controls.Add(Me.txtSQL)
        Me.gbSQL.Controls.Add(Me.btnText)
        Me.gbSQL.Controls.Add(Me.cmbTables)
        Me.gbSQL.Controls.Add(Me.cmbFields)
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
        'GroupBoxTables
        '
        Me.GroupBoxTables.Controls.Add(Me.btnINSERT)
        Me.GroupBoxTables.Controls.Add(Me.btnTable)
        Me.GroupBoxTables.Controls.Add(Me.btnDelete)
        Me.GroupBoxTables.Controls.Add(Me.btnSelect)
        Me.GroupBoxTables.Controls.Add(Me.lblInsert)
        Me.GroupBoxTables.Controls.Add(Me.btnUPDATE)
        Me.GroupBoxTables.Location = New System.Drawing.Point(8, 13)
        Me.GroupBoxTables.Name = "GroupBoxTables"
        Me.GroupBoxTables.Size = New System.Drawing.Size(366, 31)
        Me.GroupBoxTables.TabIndex = 86
        Me.GroupBoxTables.TabStop = False
        Me.GroupBoxTables.Visible = False
        '
        'btnINSERT
        '
        Me.btnINSERT.Location = New System.Drawing.Point(153, 7)
        Me.btnINSERT.Name = "btnINSERT"
        Me.btnINSERT.Size = New System.Drawing.Size(58, 24)
        Me.btnINSERT.TabIndex = 78
        Me.btnINSERT.Text = "INSERT"
        Me.btnINSERT.UseVisualStyleBackColor = True
        '
        'btnTable
        '
        Me.btnTable.Location = New System.Drawing.Point(47, 7)
        Me.btnTable.Name = "btnTable"
        Me.btnTable.Size = New System.Drawing.Size(44, 25)
        Me.btnTable.TabIndex = 70
        Me.btnTable.Text = "Table"
        Me.btnTable.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(274, 7)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 24)
        Me.btnDelete.TabIndex = 81
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(93, 7)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(58, 24)
        Me.btnSelect.TabIndex = 75
        Me.btnSelect.Text = "SELECT"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'lblInsert
        '
        Me.lblInsert.AutoSize = True
        Me.lblInsert.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsert.Location = New System.Drawing.Point(-2, 11)
        Me.lblInsert.Name = "lblInsert"
        Me.lblInsert.Size = New System.Drawing.Size(51, 16)
        Me.lblInsert.TabIndex = 80
        Me.lblInsert.Text = "Insert->"
        '
        'btnUPDATE
        '
        Me.btnUPDATE.Location = New System.Drawing.Point(213, 7)
        Me.btnUPDATE.Name = "btnUPDATE"
        Me.btnUPDATE.Size = New System.Drawing.Size(60, 24)
        Me.btnUPDATE.TabIndex = 79
        Me.btnUPDATE.Text = "UPDATE"
        Me.btnUPDATE.UseVisualStyleBackColor = True
        '
        'GroupBoxColumn
        '
        Me.GroupBoxColumn.Controls.Add(Me.lblSelect2)
        Me.GroupBoxColumn.Controls.Add(Me.btnINSERTColumn)
        Me.GroupBoxColumn.Controls.Add(Me.btnUPDATEColumn)
        Me.GroupBoxColumn.Controls.Add(Me.lblProgress)
        Me.GroupBoxColumn.Controls.Add(Me.btnColumn)
        Me.GroupBoxColumn.Controls.Add(Me.btnSelectOneColumn)
        Me.GroupBoxColumn.Location = New System.Drawing.Point(399, 13)
        Me.GroupBoxColumn.Name = "GroupBoxColumn"
        Me.GroupBoxColumn.Size = New System.Drawing.Size(336, 31)
        Me.GroupBoxColumn.TabIndex = 85
        Me.GroupBoxColumn.TabStop = False
        Me.GroupBoxColumn.Visible = False
        '
        'lblSelect2
        '
        Me.lblSelect2.AutoSize = True
        Me.lblSelect2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelect2.Location = New System.Drawing.Point(-3, 10)
        Me.lblSelect2.Name = "lblSelect2"
        Me.lblSelect2.Size = New System.Drawing.Size(51, 16)
        Me.lblSelect2.TabIndex = 82
        Me.lblSelect2.Text = "Insert->"
        '
        'btnINSERTColumn
        '
        Me.btnINSERTColumn.Location = New System.Drawing.Point(160, 7)
        Me.btnINSERTColumn.Name = "btnINSERTColumn"
        Me.btnINSERTColumn.Size = New System.Drawing.Size(57, 24)
        Me.btnINSERTColumn.TabIndex = 84
        Me.btnINSERTColumn.Text = "INSERT"
        Me.btnINSERTColumn.UseVisualStyleBackColor = True
        '
        'btnUPDATEColumn
        '
        Me.btnUPDATEColumn.Location = New System.Drawing.Point(220, 7)
        Me.btnUPDATEColumn.Name = "btnUPDATEColumn"
        Me.btnUPDATEColumn.Size = New System.Drawing.Size(59, 24)
        Me.btnUPDATEColumn.TabIndex = 83
        Me.btnUPDATEColumn.Text = "UPDATE"
        Me.btnUPDATEColumn.UseVisualStyleBackColor = True
        '
        'btnColumn
        '
        Me.btnColumn.Location = New System.Drawing.Point(50, 6)
        Me.btnColumn.Name = "btnColumn"
        Me.btnColumn.Size = New System.Drawing.Size(50, 25)
        Me.btnColumn.TabIndex = 71
        Me.btnColumn.Text = "Column"
        Me.btnColumn.UseVisualStyleBackColor = True
        '
        'btnSelectOneColumn
        '
        Me.btnSelectOneColumn.Location = New System.Drawing.Point(103, 7)
        Me.btnSelectOneColumn.Name = "btnSelectOneColumn"
        Me.btnSelectOneColumn.Size = New System.Drawing.Size(56, 24)
        Me.btnSelectOneColumn.TabIndex = 76
        Me.btnSelectOneColumn.Text = "SELECT"
        Me.btnSelectOneColumn.UseVisualStyleBackColor = True
        '
        'chkWrap
        '
        Me.chkWrap.AutoSize = True
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
        Me.txtText.Size = New System.Drawing.Size(353, 20)
        Me.txtText.TabIndex = 73
        '
        'txtSQL
        '
        Me.txtSQL.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSQL.Location = New System.Drawing.Point(11, 148)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSQL.Size = New System.Drawing.Size(987, 359)
        Me.txtSQL.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtSQL, "Type your SQL statement here")
        Me.txtSQL.WordWrap = False
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
        Me.cmbTables.Size = New System.Drawing.Size(371, 21)
        Me.cmbTables.TabIndex = 61
        Me.cmbTables.Text = "Please choose a table"
        '
        'cmbFields
        '
        Me.cmbFields.FormattingEnabled = True
        Me.cmbFields.Location = New System.Drawing.Point(393, 46)
        Me.cmbFields.Name = "cmbFields"
        Me.cmbFields.Size = New System.Drawing.Size(354, 21)
        Me.cmbFields.TabIndex = 63
        Me.cmbFields.Text = "Please choose a table first"
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
        Me.dateForm.Size = New System.Drawing.Size(91, 20)
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
        'frmSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 706)
        Me.Controls.Add(Me.gbSQL)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.lblDSN)
        Me.Controls.Add(Me.cmbDSN)
        Me.Controls.Add(Me.ckbDetectProxy)
        Me.Controls.Add(Me.lblAppToken)
        Me.Controls.Add(Me.txtAppToken)
        Me.Controls.Add(Me.lblServer)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.txtUsername)
        Me.Name = "frmSQL"
        Me.Text = "QuNect SQL"
        Me.gbSQL.ResumeLayout(False)
        Me.gbSQL.PerformLayout()
        Me.GroupBoxTables.ResumeLayout(False)
        Me.GroupBoxTables.PerformLayout()
        Me.GroupBoxColumn.ResumeLayout(False)
        Me.GroupBoxColumn.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblProgress As Label
    Friend WithEvents ckbDetectProxy As CheckBox
    Friend WithEvents lblAppToken As Label
    Friend WithEvents txtAppToken As TextBox
    Friend WithEvents lblServer As Label
    Friend WithEvents txtServer As TextBox
    Friend WithEvents lblPassword As Label
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
    Friend WithEvents btnColumn As Button
    Friend WithEvents btnTable As Button
    Friend WithEvents cmbFields As ComboBox
    Friend WithEvents btnTime As Button
    Friend WithEvents dateForm As DateTimePicker
    Friend WithEvents TimeForm As DateTimePicker
    Friend WithEvents btnDate As Button
    Friend WithEvents btnDateTime As Button
    Friend WithEvents DateTimeForm As DateTimePicker
    Friend WithEvents btnSelect As Button
    Friend WithEvents btnSelectOneColumn As Button
    Friend WithEvents chkWrap As CheckBox
    Friend WithEvents btnINSERT As Button
    Friend WithEvents btnUPDATE As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents lblInsert As Label
    Friend WithEvents btnUPDATEColumn As Button
    Friend WithEvents lblSelect2 As Label
    Friend WithEvents btnINSERTColumn As Button
    Friend WithEvents GroupBoxTables As GroupBox
    Friend WithEvents GroupBoxColumn As GroupBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
