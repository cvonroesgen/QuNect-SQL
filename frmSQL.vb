Imports System.ComponentModel
Imports System.Data.Odbc
Imports System.Text.RegularExpressions
Public Class frmSQL
    Private Const AppName = "QuNectSQL"
    Public Adpt As OdbcDataAdapter
    Public ds As DataSet
    Public connection As OdbcConnection
    Private WithEvents dtp As New DateTimePicker
    Private Class qdbVersion
        Public year As Integer
        Public major As Integer
        Public minor As Integer
    End Class
    Private qdbVer As qdbVersion = New qdbVersion

    Private Sub frmSQL_Load(sender As Object, e As EventArgs) Handles Me.Load
        Text = "QuNect SQL 1.0.0.10" ' & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        txtUsername.Text = GetSetting(AppName, "Credentials", "username")
        txtPassword.Text = GetSetting(AppName, "Credentials", "password")
        txtServer.Text = GetSetting(AppName, "Credentials", "server", "www.quickbase.com")
        txtAppToken.Text = GetSetting(AppName, "Credentials", "apptoken", "b2fr52jcykx3tnbwj8s74b8ed55b")
        txtSQL.Text = GetSetting(AppName, "SQL", "sql", "select * from ")
        txtSQL.SelectionStart = CInt(GetSetting(AppName, "SQL", "selectionStart", ""))
        txtSQL.SelectionLength = CInt(GetSetting(AppName, "SQL", "selectionLength", ""))
        Dim detectProxySetting As String = GetSetting(AppName, "Credentials", "detectproxysettings", "0")
        If detectProxySetting = "1" Then
            ckbDetectProxy.Checked = True
        Else
            ckbDetectProxy.Checked = False
        End If

        GetDSNs()
        Me.Show()
        txtSQL.Focus()
    End Sub
    Private Function buildConnectionString() As String
        If cmbDSN.SelectedIndex = 0 Then
            Return "Driver={QuNect ODBC For QuickBase};uid=" & txtUsername.Text & ";pwd=" & txtPassword.Text & ";QUICKBASESERVER=" & txtServer.Text & ";APPTOKEN=" & txtAppToken.Text
        Else
            Return "DSN=" & cmbDSN.Text
        End If
    End Function
    Private Sub checkExecuteSQL(checkOnly As Boolean)
        Dim Sql As String = txtSQL.Text
        If CBool(txtSQL.SelectedText.Length) Then
            Sql = txtSQL.SelectedText
        End If
        Me.Cursor = Cursors.WaitCursor
        Try

            Dim selectRegex As New Regex("^\s*SELECT ", RegexOptions.IgnoreCase)
            If selectRegex.IsMatch(Sql) And Not checkOnly Then
                Adpt = New OdbcDataAdapter(Sql, connection)

                ds = New DataSet()
                Adpt.Fill(ds)
                If checkOnly Then
                    Adpt.Dispose()
                    Me.Cursor = Cursors.Default
                    MsgBox("Syntax OK!")
                    txtSQL.Focus()
                    Exit Sub
                End If
                Adpt.Dispose()
                frmResults.dgvSQL.DataSource = ds.Tables(0)
                frmResults.Text = Sql
                frmResults.Show()
            Else
                Using command As OdbcCommand = New OdbcCommand(Sql, connection)
                    If checkOnly Then
                        command.Prepare()
                        command.Dispose()
                        Me.Cursor = Cursors.Default
                        MsgBox("Syntax OK!")
                        txtSQL.Focus()
                        Exit Sub
                    End If
                    Dim i As Integer = command.ExecuteNonQuery()
                    Dim deleteRegex As New Regex("^\s*DELETE ", RegexOptions.IgnoreCase)
                    Dim updateRegex As New Regex("^\s*UPDATE ", RegexOptions.IgnoreCase)
                    Dim insertRegex As New Regex("^\s*INSERT ", RegexOptions.IgnoreCase)
                    Dim verb As String = "processed"
                    If deleteRegex.IsMatch(Sql) Then
                        verb = "deleted"
                    ElseIf updateRegex.IsMatch(Sql) Then
                        verb = "updated"
                    ElseIf insertRegex.IsMatch(Sql) Then
                        verb = "inserted/updated"
                    End If
                    Dim msg As String = i & " records were " & verb & "."
                    If i = -1 Then msg = "Success!"
                    MsgBox(msg)
                End Using
                txtSQL.Focus()
            End If
        Catch excpt As Exception
            txtSQL.Focus()
            MsgBox(excpt.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        checkExecuteSQL(False)
    End Sub

    Private Function getquNectConn(connectionString As String) As OdbcConnection
        Me.Cursor = Cursors.WaitCursor
        Dim quNectConn As OdbcConnection = New OdbcConnection(connectionString)
        Try
            quNectConn.Open()
        Catch excpt As Exception
            Me.Cursor = Cursors.Default
            If excpt.Message.StartsWith("Error [IM003]") Or excpt.Message.Contains("Data source name Not found") Then
                MsgBox("Please install QuNect ODBC For QuickBase from http://qunect.com/download/QuNect.exe and try again.")
            Else
                MsgBox(excpt.Message.Substring(13))
            End If
            Return Nothing
            Exit Function
        End Try

        Dim ver As String = quNectConn.ServerVersion
        Dim m As Match = Regex.Match(ver, "\d+\.(\d+)\.(\d+)\.(\d+)")
        qdbVer.year = CInt(m.Groups(1).Value)
        qdbVer.major = CInt(m.Groups(2).Value)
        qdbVer.minor = CInt(m.Groups(3).Value)
        If (qdbVer.major < 6) Or (qdbVer.major = 6 And qdbVer.minor < 84) Then
            MsgBox("You are running the " & ver & " version of QuNect ODBC for QuickBase. Please install the latest version from http://qunect.com/download/QuNect.exe")
            quNectConn.Close()
            Me.Cursor = Cursors.Default
            Return Nothing
            Exit Function
        End If
        Me.Cursor = Cursors.Default
        Return quNectConn
    End Function
    Private Sub txtAppToken_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAppToken.TextChanged
        SaveSetting(AppName, "Credentials", "apptoken", txtAppToken.Text)
        closeConnection()
    End Sub
    Private Sub txtServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServer.TextChanged
        SaveSetting(AppName, "Credentials", "server", txtServer.Text)
        closeConnection()
    End Sub
    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged
        SaveSetting(AppName, "Credentials", "username", txtUsername.Text)
        closeConnection()
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        SaveSetting(AppName, "Credentials", "password", txtPassword.Text)
        closeConnection()
    End Sub

    Private Sub txtSQL_LostFocus(sender As Object, e As EventArgs) Handles txtSQL.LostFocus
        SaveSetting(AppName, "SQL", "selectionStart", CType(txtSQL.SelectionStart, String))
        SaveSetting(AppName, "SQL", "selectionLength", CType(txtSQL.SelectionLength, String))
    End Sub

    Private Sub txtSQL_GotFocus(sender As Object, e As EventArgs) Handles txtSQL.GotFocus
        txtSQL.SelectionStart = CInt(GetSetting(AppName, "SQL", "selectionStart", ""))
        txtSQL.SelectionLength = CInt(GetSetting(AppName, "SQL", "selectionLength", ""))
    End Sub

    Private Sub txtSQL_TextChanged(sender As Object, e As EventArgs) Handles txtSQL.TextChanged
        SaveSetting(AppName, "SQL", "sql", txtSQL.Text)
    End Sub


    Private Sub frmSQL_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtSQL.Focus()
    End Sub
    Private Sub GetDSNs()
        Dim strKeyNames() As String
        Dim intKeyValues As Integer
        Dim intCount As Integer
        Dim key As Microsoft.Win32.RegistryKey
        cmbDSN.Items.Add("Use a DSN-less connection")
        key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("software\odbc\odbc.ini\odbc data sources")
        strKeyNames = key.GetValueNames() 'Get an array of the value names
        intKeyValues = key.ValueCount() 'Get the number of values
        For intCount = 0 To intKeyValues - 1
            cmbDSN.Items.Add(strKeyNames(intCount))
        Next
        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\odbc\odbc.ini\odbc data sources")
        strKeyNames = key.GetValueNames() 'Get an array of the value names
        intKeyValues = key.ValueCount() 'Get the number of values
        For intCount = 0 To intKeyValues - 1
            cmbDSN.Items.Add(strKeyNames(intCount))
        Next
        cmbDSN.SelectedIndex = 0
    End Sub

    Private Sub cmbDSN_TextChanged(sender As Object, e As EventArgs) Handles cmbDSN.TextChanged
        If cmbDSN.SelectedIndex = 0 Then
            txtPassword.Enabled = True
            txtUsername.Enabled = True
            txtAppToken.Enabled = True
            txtServer.Enabled = True
            ckbDetectProxy.Enabled = True
        Else
            txtPassword.Enabled = False
            txtUsername.Enabled = False
            txtAppToken.Enabled = False
            txtServer.Enabled = False
            ckbDetectProxy.Enabled = False
        End If
        closeConnection()
        GroupBoxTables.Visible = False
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If Not connection Is Nothing Then
            connection.Close()
        End If
        Me.Cursor = Cursors.WaitCursor
        Try
        Dim connectionString As String = buildConnectionString()
            connection = getquNectConn(connectionString)
            If connection Is Nothing Then Exit Sub
            'need to get a list of tables
            cmbTables.Items.Clear()
            cmbTables.Items.Add("Please choose a table")
            Dim tables As DataTable = connection.GetSchema("Tables")
            For i = 0 To tables.Rows.Count - 1
                cmbTables.Items.Add(tables.Rows(i)(2))
            Next
            cmbTables.SelectedIndex = 0
            showSQLControls(True)
            txtSQL.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub closeConnection()
        showSQLControls(False)

        If Not connection Is Nothing Then
            connection.Close()
            connection = Nothing
        End If

    End Sub
    Private Sub cmbTables_TextChanged(sender As Object, e As EventArgs) Handles cmbTables.TextChanged
        If cmbTables.SelectedIndex <= 0 Then
            GroupBoxTables.Visible = False
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor

        cmbFields.Items.Clear()
        cmbFields.Items.Add("Please choose a column")
        Dim restrictions(2) As String
        restrictions(2) = CType(cmbTables.SelectedItem, String)
        Dim columns As DataTable = connection.GetSchema("Columns", restrictions)
        For i = 0 To columns.Rows.Count - 1
            cmbFields.Items.Add(columns.Rows(i)(3))
        Next
        cmbFields.SelectedIndex = 0
        GroupBoxTables.Visible = True

        Me.Cursor = Cursors.Default
    End Sub
    Sub insertReplaceText(ByRef txtBox As TextBox, insertText As String)
        Dim selectionStart As Integer = txtBox.SelectionStart
        txtBox.Text = txtBox.Text.Substring(0, selectionStart) & insertText & txtBox.Text.Substring(selectionStart + txtBox.SelectionLength)
        txtBox.Focus()
        txtBox.SelectionStart = selectionStart + insertText.Length

    End Sub
    Sub showSQLControls(show As Boolean)
        gbSQL.Visible = show
    End Sub

    Private Sub btnDate_Click(sender As Object, e As EventArgs) Handles btnDate.Click
        insertReplaceText(txtSQL, "{d '" & dateForm.Text & "'}")
    End Sub

    Private Sub btnDateTime_Click(sender As Object, e As EventArgs) Handles btnDateTime.Click
        insertReplaceText(txtSQL, "{ts '" & DateTimeForm.Text & "'}")
    End Sub

    Private Sub btnTime_Click(sender As Object, e As EventArgs) Handles btnTime.Click
        insertReplaceText(txtSQL, "{t '" & TimeForm.Text & "'}")
    End Sub

    Private Sub btnText_Click(sender As Object, e As EventArgs) Handles btnText.Click
        insertReplaceText(txtSQL, "'" & txtText.Text & "'")
    End Sub

    Private Sub btnColumn_Click(sender As Object, e As EventArgs) Handles btnColumn.Click
        If cmbFields.SelectedIndex <= 0 Then Exit Sub
        insertReplaceText(txtSQL, """" & cmbFields.Text & """")
    End Sub

    Private Sub btnTable_Click(sender As Object, e As EventArgs) Handles btnTable.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        insertReplaceText(txtSQL, """" & cmbTables.Text & """")
    End Sub

    Private Sub btnCheckSQL_Click(sender As Object, e As EventArgs) Handles btnCheckSQL.Click
        checkExecuteSQL(True)
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "SELECT "
        Dim comma As String = """"
        For i = 1 To cmbFields.Items.Count - 1
            sql &= comma & cmbFields.Items(i).ToString
            comma = """, """
        Next
        sql &= """ FROM """ & cmbTables.SelectedItem.ToString & """"
        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub btnSelectOneColumn_Click(sender As Object, e As EventArgs) Handles btnSelectOneColumn.Click
        If cmbFields.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "SELECT """
        sql &= cmbFields.SelectedItem.ToString
        sql &= """ FROM """ & cmbTables.SelectedItem.ToString & """"
        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub chkWrap_CheckedChanged(sender As Object, e As EventArgs) Handles chkWrap.CheckedChanged
        txtSQL.WordWrap = chkWrap.Checked
    End Sub

    Private Function createCommaSeparatedValues(ByRef columns As DataTable, withColumns As Boolean, onlyThisOne As Integer) As String
        Dim charRegex As New Regex("char", RegexOptions.IgnoreCase)
        Dim dateRegex As New Regex("date$", RegexOptions.IgnoreCase)
        Dim dateTimeRegex As New Regex("datetime", RegexOptions.IgnoreCase)
        Dim TimeRegex As New Regex("^time", RegexOptions.IgnoreCase)
        createCommaSeparatedValues = ""
        For i = 0 To columns.Rows.Count - 1
            If onlyThisOne > 0 And i <> onlyThisOne - 1 Then
                Continue For
            End If
            If withColumns Then
                    createCommaSeparatedValues &= """" & columns.Rows(i)(3).ToString & """ = "
                End If
                Dim type As String = columns.Rows(i)(5).ToString
                If charRegex.IsMatch(type) Then
                    createCommaSeparatedValues &= "'" & txtText.Text & "', "
                ElseIf dateRegex.IsMatch(type) Then
                    createCommaSeparatedValues &= "{d '" & dateForm.Text & "'}, "
                ElseIf dateTimeRegex.IsMatch(type) Then
                    createCommaSeparatedValues &= "{ts '" & DateTimeForm.Text & "'}, "
                ElseIf TimeRegex.IsMatch(type) Then
                    createCommaSeparatedValues &= "{t '" & TimeForm.Text & "'}, "
                Else
                    createCommaSeparatedValues &= "0, "
                End If
        Next
        createCommaSeparatedValues = createCommaSeparatedValues.TrimEnd(New Char() {CType(",", Char), CType(" ", Char)})
    End Function
    Private Function createCommaSeparatedColumns(ByRef columns As DataTable) As String
        createCommaSeparatedColumns = ""
        Dim comma As String = """"
        For i = 0 To columns.Rows.Count - 1
            createCommaSeparatedColumns &= comma & columns.Rows(i)(3).ToString
            comma = """, """
        Next
    End Function

    Private Sub btnINSERT_Click(sender As Object, e As EventArgs) Handles btnINSERT.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "INSERT INTO " & """" & cmbTables.SelectedItem.ToString & """ ("

        Dim restrictions(2) As String
        restrictions(2) = CType(cmbTables.SelectedItem, String)
        Dim columns As DataTable = connection.GetSchema("Columns", restrictions)
        sql &= createCommaSeparatedColumns(columns)
        sql &= """) VALUES ( "
        sql &= createCommaSeparatedValues(columns, False, 0)
        sql = sql.TrimEnd(New Char() {CType(",", Char), CType(" ", Char)})
        sql &= ")"
        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub btnUPDATE_Click(sender As Object, e As EventArgs) Handles btnUPDATE.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "UPDATE " & """" & cmbTables.SelectedItem.ToString & """ SET "

        Dim restrictions(2) As String
        restrictions(2) = CType(cmbTables.SelectedItem, String)
        Dim columns As DataTable = connection.GetSchema("Columns", restrictions)
        sql &= createCommaSeparatedValues(columns, True, 0)
        sql = sql.TrimEnd(New Char() {CType(",", Char), CType(" ", Char)})
        sql &= " WHERE """ & columns.Rows(2)(3).ToString & """ = 0"

        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "DELETE FROM " & """" & cmbTables.SelectedItem.ToString & """"

        Dim restrictions(2) As String
        restrictions(2) = CType(cmbTables.SelectedItem, String)
        Dim columns As DataTable = connection.GetSchema("Columns", restrictions)
        sql &= " WHERE """ & columns.Rows(2)(3).ToString & """ = 0"

        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub btnUPDATEColumn_Click(sender As Object, e As EventArgs) Handles btnUPDATEColumn.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        If cmbFields.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "UPDATE " & """" & cmbTables.SelectedItem.ToString & """ SET "

        Dim restrictions(2) As String
        restrictions(2) = CType(cmbTables.SelectedItem, String)
        Dim columns As DataTable = connection.GetSchema("Columns", restrictions)
        sql &= createCommaSeparatedValues(columns, True, cmbFields.SelectedIndex)
        sql = sql.TrimEnd(New Char() {CType(",", Char), CType(" ", Char)})
        sql &= " WHERE """ & columns.Rows(2)(3).ToString & """ = 0"

        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub btnINSERTColumn_Click(sender As Object, e As EventArgs) Handles btnINSERTColumn.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        If cmbFields.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "INSERT INTO " & """" & cmbTables.SelectedItem.ToString & """ ("

        Dim restrictions(2) As String
        restrictions(2) = CType(cmbTables.SelectedItem, String)
        Dim columns As DataTable = connection.GetSchema("Columns", restrictions)
        sql &= """" & cmbFields.Text
        sql &= """) VALUES ("
        sql &= createCommaSeparatedValues(columns, False, cmbFields.SelectedIndex)
        sql = sql.TrimEnd(New Char() {CType(",", Char), CType(" ", Char)})
        sql &= ")"
        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub cmbFields_TextChanged(sender As Object, e As EventArgs) Handles cmbFields.TextChanged
        If cmbFields.SelectedIndex = 0 Then
            GroupBoxColumn.Visible = False
        Else
            GroupBoxColumn.Visible = True
        End If

    End Sub
End Class

