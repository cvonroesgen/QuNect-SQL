Imports System.ComponentModel
Imports System.Data.Odbc
Imports System.Text.RegularExpressions
Public Class frmSQL
    Private Const AppName = "QuNectSQL"
    Private cmdLineArgs() As String
    Public Adpt As OdbcDataAdapter
    Public ds As DataSet
    Public connection As OdbcConnection
    Private WithEvents dtp As New DateTimePicker
    Private Shared fidRegex As New Regex(".* fid(\d+)$", RegexOptions.IgnoreCase)
    Private Class qdbVersion
        Public year As Integer
        Public major As Integer
        Public minor As Integer
    End Class
    Private Class qdbAppTable
        Public Sub New(_catalog As String, _dbid As String, _Name As String)
            dbid = _dbid
            Name = _Name
            catalog = _catalog
        End Sub
        Public dbid As String
        Public Name As String
        Public catalog As String
        Overrides Function toString() As String
            Return Name
        End Function

    End Class
    Private Class qdbColumn
        Public Sub New(_Catalog As String, _Name As String, _type As String, _size As String, _decimalPlaces As String, _remark As String)
            Dim m As Match = fidRegex.Match(_remark)
            If m.Success Then
                fid = m.Groups(1).Value
            Else
                fid = "0"
            End If
            Name = _Name
            remark = _remark
            type = _type
            catalog = _Catalog
            size = _size
            decimalPlaces = _decimalPlaces
        End Sub
        Public fid As String
        Public Name As String
        Public remark As String
        Public type As String
        Public catalog As String
        Public size As String
        Public decimalPlaces As String
        Overrides Function toString() As String
            Return Name
        End Function

    End Class
    Private qdbVer As qdbVersion = New qdbVersion

    Private Sub frmSQL_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dsn As String
        cmdLineArgs = System.Environment.GetCommandLineArgs()
        If cmdLineArgs.Length >= 3 And cmdLineArgs.Length <= 4 Then
            dsn = cmdLineArgs(1)
            Dim sqlFile As String = cmdLineArgs(2)
            Dim SqlStatement As String
            Try
                SqlStatement = My.Computer.FileSystem.ReadAllText(sqlFile)
                connection = getquNectConn("DSN=" & dsn & ";")
            Catch ex As Exception
                Console.WriteLine(Now & " " & ex.Message)
                Me.Close()
                Exit Sub
            End Try
            If cmdLineArgs.Length = 4 Then
                checkExecuteSQL(SqlStatement, False, False, cmdLineArgs(3))
            Else
                checkExecuteSQL(SqlStatement, False, False)
            End If
            If Not connection Is Nothing Then
                connection.Close()
            End If
            Me.Close()
            Exit Sub
        End If
        Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
        Me.Text = "QuNect SQL " & myBuildInfo.ProductVersion
        txtUsername.Text = GetSetting(AppName, "Credentials", "username")
        cmbPassword.SelectedIndex = CInt(GetSetting(AppName, "Credentials", "passwordOrToken", "0"))
        txtPassword.Text = GetSetting(AppName, "Credentials", "password")
        txtServer.Text = GetSetting(AppName, "Credentials", "server", "")
        txtAppToken.Text = GetSetting(AppName, "Credentials", "apptoken", "")
        txtSQL.Text = GetSetting(AppName, "SQL", "sql", "")
        txtSQL.SelectionStart = CInt(GetSetting(AppName, "SQL", "selectionStart", "0"))
        txtSQL.SelectionLength = CInt(GetSetting(AppName, "SQL", "selectionLength", "0"))
        Dim detectProxySetting As String = GetSetting(AppName, "Credentials", "detectproxysettings", "0")
        If detectProxySetting = "1" Then
            ckbDetectProxy.Checked = True
        Else
            ckbDetectProxy.Checked = False
        End If
        dsn = GetSetting(AppName, "Connection", "DSN", "")


        GetDSNs()
        cmbDSN.SelectedIndex = cmbDSN.FindStringExact(dsn)
        Me.Show()
        txtSQL.Focus()
    End Sub
    Private Function buildConnectionString() As String
        If cmbDSN.SelectedIndex = 0 Then
            If txtPassword.Text.Contains(";") Then
                Throw New System.Exception("Although Quick Base allows semicolons in passwords the ODBC standard does not permit semicolons." & vbCrLf & "Please change your Quick Base password to eliminate semicolons or use a Quick Base user token instead of a password.")
                Return ""
            End If

            Dim connectionString As String = ""
            If cmbPassword.SelectedIndex = 0 Then
                cmbPassword.Focus()
                Throw New System.Exception("Please indicate whether you are using a password or a user token.")
                Return ""
            ElseIf cmbPassword.SelectedIndex = 1 Then
                connectionString = ";PWDISPASSWORD=1"
            Else
                connectionString = ";PWDISPASSWORD=0"
            End If
            Return "Driver={QuNect ODBC For QuickBase};uid=" & txtUsername.Text & ";pwd=" & txtPassword.Text & ";QUICKBASESERVER=" & txtServer.Text & ";APPTOKEN=" & txtAppToken.Text & connectionString
        Else
            Return "DSN=" & cmbDSN.Text
        End If
    End Function
    Private Sub checkExecuteSQL(Sql As String, checkOnly As Boolean, uiAvailable As Boolean)
        checkExecuteSQL(Sql, checkOnly, uiAvailable, Nothing)
    End Sub
    Private Sub checkExecuteSQL(Sql As String, checkOnly As Boolean, uiAvailable As Boolean, csvOutput As String)
        If uiAvailable Then
            startStopElapsedTime(True)
            Me.Cursor = Cursors.WaitCursor
        End If
        Try

            Dim selectRegex As New Regex("^\s*SELECT\s", RegexOptions.IgnoreCase)
            If selectRegex.IsMatch(Sql) And Not checkOnly Then
                Adpt = New OdbcDataAdapter(Sql, connection)
                ds = New DataSet()
                Adpt.Fill(ds)
                Adpt.Dispose()
                If csvOutput IsNot Nothing Then
                    Dim comma As String = ""
                    Dim objWriter As System.IO.StreamWriter
                    objWriter = New System.IO.StreamWriter(csvOutput)
                    For Each Coll As DataColumn In ds.Tables(0).Columns
                        objWriter.Write(comma & """")
                        objWriter.Write(Replace(Coll.ColumnName, """", """"""))
                        objWriter.Write("""")
                        comma = ","
                    Next
                    comma = ""
                    objWriter.Write(vbCrLf)
                    For Each Row As DataRow In ds.Tables(0).Rows
                        For Each Coll As DataColumn In ds.Tables(0).Columns
                            objWriter.Write(comma & """")
                            objWriter.Write(Replace(CStr(Row(Coll.ColumnName).ToString()), """", """"""))
                            objWriter.Write("""")
                            comma = ","
                        Next
                        objWriter.Write(vbCrLf)
                        comma = ""
                    Next
                    objWriter.Close()
                    Return
                ElseIf uiAvailable Then
                    frmResults.dgvSQL.DataSource = ds.Tables(0)
                    frmResults.Text = CStr(ds.Tables(0).Rows.Count) + " rows from  " + Sql
                    frmResults.Show()
                    frmResults.TopMost = True
                End If
            Else
                Using command As OdbcCommand = New OdbcCommand(Sql, connection)
                    If checkOnly Then
                        command.Prepare()
                        command.Dispose()
                        Me.Cursor = Cursors.Default
                        MsgBox("Syntax OK!", MsgBoxStyle.OkOnly, AppName)
                        txtSQL.Focus()
                        Exit Sub
                    End If
                    Dim i As Integer = command.ExecuteNonQuery()
                    If uiAvailable Then
                        Dim deleteRegex As New Regex("^\s*DELETE\s", RegexOptions.IgnoreCase)
                        Dim updateRegex As New Regex("^\s*UPDATE\s", RegexOptions.IgnoreCase)
                        Dim insertRegex As New Regex("^\s*INSERT\s", RegexOptions.IgnoreCase)
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
                        MsgBox(msg, MsgBoxStyle.OkOnly, AppName)
                    End If
                End Using
                If uiAvailable Then
                    txtSQL.Focus()
                End If
            End If
        Catch excpt As Exception
            If uiAvailable Then
                txtSQL.Focus()
                MsgBox(excpt.Message, MsgBoxStyle.OkOnly, AppName)
            Else
                Console.WriteLine(Now & " " & excpt.Message)
            End If
        End Try
        If uiAvailable Then
            startStopElapsedTime(False)
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Dim SqlStatement As String = txtSQL.Text
        If CBool(txtSQL.SelectedText.Length) Then
            SqlStatement = txtSQL.SelectedText
        End If
        checkExecuteSQL(SqlStatement, False, True)
    End Sub

    Private Function getquNectConn(connectionString As String) As OdbcConnection
        Me.Cursor = Cursors.WaitCursor
        Dim quNectConn As OdbcConnection = New OdbcConnection(connectionString)
        Try
            quNectConn.Open()
        Catch excpt As Exception
            Me.Cursor = Cursors.Default
            If excpt.Message.StartsWith("Error [IM003]") Or excpt.Message.Contains("Data source name Not found") Then
                MsgBox("Please install QuNect ODBC For QuickBase from http://qunect.com/download/QuNect.exe and try again.", MsgBoxStyle.OkOnly, AppName)
            Else
                MsgBox(excpt.Message.Substring(13), MsgBoxStyle.OkOnly, AppName)
            End If
            Return Nothing
            Exit Function
        End Try

        Dim ver As String = quNectConn.ServerVersion
        Dim m As Match = Regex.Match(ver, "\d+\.(\d+)\.(\d+)\.(\d+)")
        qdbVer.year = CInt(m.Groups(1).Value)
            qdbVer.major = CInt(m.Groups(2).Value)
            qdbVer.minor = CInt(m.Groups(3).Value)
        If (qdbVer.major < 7) Or (qdbVer.major = 7 And qdbVer.minor < 10) Then
            MsgBox("You are running the " & ver & " version of QuNect ODBC for QuickBase. Please install the latest version from http://qunect.com/download/QuNect.exe", MsgBoxStyle.OkOnly, AppName)
            quNectConn.Close()
            Me.Cursor = Cursors.Default
            Return Nothing
            Exit Function
        End If
        Me.Cursor = Cursors.Default
        Return quNectConn
    End Function
    Sub showHideControls()
        txtUsername.Visible = cmbDSN.SelectedIndex = 0
        lblUsername.Visible = txtUsername.Visible
        cmbPassword.Visible = txtUsername.Visible And txtUsername.Text.Length > 0
        txtPassword.Visible = cmbPassword.Visible And cmbPassword.SelectedIndex <> 0
        txtServer.Visible = txtPassword.Visible And txtPassword.Text.Length > 0
        lblServer.Visible = txtServer.Visible
        ckbDetectProxy.Visible = lblServer.Visible
        lblAppToken.Visible = cmbPassword.Visible And cmbPassword.SelectedIndex = 1
        txtAppToken.Visible = lblAppToken.Visible
        btnAppToken.Visible = lblAppToken.Visible
        btnUserToken.Visible = cmbPassword.Visible And cmbPassword.SelectedIndex = 2
    End Sub
    Private Sub txtAppToken_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAppToken.TextChanged
        SaveSetting(AppName, "Credentials", "apptoken", txtAppToken.Text)
        showHideControls()
        closeConnection()
    End Sub
    Private Sub txtServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServer.TextChanged
        SaveSetting(AppName, "Credentials", "server", txtServer.Text)
        showHideControls()
        closeConnection()
    End Sub
    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged
        SaveSetting(AppName, "Credentials", "username", txtUsername.Text)
        showHideControls()
        closeConnection()
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        SaveSetting(AppName, "Credentials", "password", txtPassword.Text)
        showHideControls()
        closeConnection()
    End Sub

    Private Sub txtSQL_LostFocus(sender As Object, e As EventArgs) Handles txtSQL.LostFocus
        SaveSetting(AppName, "SQL", "selectionStart", CType(txtSQL.SelectionStart, String))
        SaveSetting(AppName, "SQL", "selectionLength", CType(txtSQL.SelectionLength, String))
    End Sub

    Private Sub txtSQL_GotFocus(sender As Object, e As EventArgs) Handles txtSQL.GotFocus
        txtSQL.SelectionStart = CInt(GetSetting(AppName, "SQL", "selectionStart", "0"))
        txtSQL.SelectionLength = CInt(GetSetting(AppName, "SQL", "selectionLength", "0"))
    End Sub

    Private Sub txtSQL_TextChanged(sender As Object, e As EventArgs) Handles txtSQL.TextChanged
        SaveSetting(AppName, "SQL", "sql", txtSQL.Text)
    End Sub
    Private Sub cmbDSN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDSN.SelectedIndexChanged
        SaveSetting(AppName, "Connection", "DSN", cmbDSN.Text)
        cmbDSN_TextChanged(sender, e)
    End Sub

    Private Sub frmSQL_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtSQL.Focus()
    End Sub
    Private Sub GetDSNs()
        Dim strKeyNames() As String
        Dim intKeyCount As Integer
        Dim intCount As Integer
        Dim key As Microsoft.Win32.RegistryKey
        cmbDSN.Items.Add("Use a DSN-less connection")
        key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("software\odbc\odbc.ini\odbc data sources")
        strKeyNames = key.GetValueNames() 'Get an array of the key names
        intKeyCount = key.ValueCount() 'Get the number of keys
        For intCount = 0 To intKeyCount - 1
            If key.GetValue(strKeyNames(intCount)) = "QuNect ODBC for QuickBase" Then
                cmbDSN.Items.Add(strKeyNames(intCount))
            End If
        Next
        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\odbc\odbc.ini\odbc data sources")
        strKeyNames = key.GetValueNames() 'Get an array of the value names
        intKeyCount = key.ValueCount() 'Get the number of values
        For intCount = 0 To intKeyCount - 1
            If key.GetValue(strKeyNames(intCount)) = "QuNect ODBC for QuickBase" Then
                cmbDSN.Items.Add(strKeyNames(intCount))
            End If
        Next
        cmbDSN.SelectedIndex = 0
    End Sub

    Private Sub cmbDSN_TextChanged(sender As Object, e As EventArgs) Handles cmbDSN.TextChanged
        If cmbDSN.SelectedIndex = 0 Then
            cmbPassword.Enabled = True
            txtPassword.Enabled = True
            txtUsername.Enabled = True
            txtAppToken.Enabled = True
            txtServer.Enabled = True
            ckbDetectProxy.Enabled = True
        Else
            cmbPassword.Enabled = False
            txtPassword.Enabled = False
            txtUsername.Enabled = False
            txtAppToken.Enabled = False
            txtServer.Enabled = False
            ckbDetectProxy.Enabled = False
        End If
        closeConnection()
        GroupBoxTables.Visible = False
        showHideControls()
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
            Using tables As DataTable = connection.GetSchema("Tables")
                For i = 0 To tables.Rows.Count - 1
                    cmbTables.Items.Add(New qdbAppTable(tables.Rows(i)(0).ToString(), tables.Rows(i)(4).ToString(), tables.Rows(i)(2).ToString()))
                Next
            End Using
            Using tables As DataTable = connection.GetSchema("Views")
                For i = 0 To tables.Rows.Count - 1
                    cmbTables.Items.Add(New qdbAppTable(tables.Rows(i)(0).ToString(), tables.Rows(i)(4).ToString(), tables.Rows(i)(2).ToString()))
                Next
            End Using
            cmbTables.SelectedIndex = 0
            cmbCatalogs.Items.Clear()
            cmbCatalogs.Items.Add("Please choose an Application")
            Using quNectCmd = New OdbcCommand("SELECT * FROM CATALOGS", connection)
                Dim dr As OdbcDataReader = quNectCmd.ExecuteReader()
                While (dr.Read())
                    If dr.FieldCount = 3 Then
                        cmbCatalogs.Items.Add(New qdbAppTable(dr.GetString(0), dr.GetString(2), dr.GetString(0)))
                    Else
                        cmbCatalogs.Items.Add(New qdbAppTable(dr.GetString(0), dr.GetString(4), dr.GetString(0)))
                    End If
                End While
            End Using
            cmbCatalogs.SelectedIndex = 0
            showSQLControls(True)
            txtSQL.Focus()
        Catch ex As Exception
            showSQLControls(False)
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, AppName)
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
        btnFields.Visible = True
        ListBoxColumns.Items.Clear()
        Dim restrictions(2) As String
        restrictions(2) = cmbTables.SelectedItem.ToString()
        Dim columns As DataTable = connection.GetSchema("Columns", restrictions)
        For i = 0 To columns.Rows.Count - 1
            ListBoxColumns.Items.Add(New qdbColumn(columns.Rows(i)(0), columns.Rows(i)(3), columns.Rows(i)(5), columns.Rows(i)(6), columns.Rows(i)(8), columns.Rows(i)(11)))
        Next
        ListBoxColumns.SelectedIndex = -1
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
    Private Sub btnCheckSQL_Click(sender As Object, e As EventArgs) Handles btnCheckSQL.Click
        Dim SqlStatement As String = txtSQL.Text
        If CBool(txtSQL.SelectedText.Length) Then
            SqlStatement = txtSQL.SelectedText
        End If
        checkExecuteSQL(SqlStatement, True, True)
    End Sub

    Private Sub chkWrap_CheckedChanged(sender As Object, e As EventArgs) Handles chkWrap.CheckedChanged
        txtSQL.WordWrap = chkWrap.Checked
    End Sub

    Private Function createCommaSeparatedValues(ByRef columns As ListBox.SelectedObjectCollection, withColumns As Boolean) As String
        If columns.Count = 0 Then
            For i As Integer = 0 To ListBoxColumns.Items.Count - 1
                ListBoxColumns.SetSelected(i, True)
            Next
        End If
        Dim charRegex As New Regex("char", RegexOptions.IgnoreCase)
        Dim dateRegex As New Regex("date$", RegexOptions.IgnoreCase)
        Dim dateTimeRegex As New Regex("datetime", RegexOptions.IgnoreCase)
        Dim TimeRegex As New Regex("^time", RegexOptions.IgnoreCase)
        createCommaSeparatedValues = ""
        For i = 0 To columns.Count - 1
            If withColumns Then
                createCommaSeparatedValues &= """" & columns(i).Name.ToString & """ = "
            End If
            Dim type As String = columns(i).type
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
    Private Function createCommaSeparatedColumns(ByRef columns As ListBox.SelectedObjectCollection, fromCreateSelect As Boolean, addType As Boolean, useAliases As Boolean) As String
        Dim strFID As String
        If fromCreateSelect And columns.Count = 0 Then
            Return "*"
        End If
        createCommaSeparatedColumns = ""
        Dim comma As String = ""
        If columns.Count = 0 Then
            For i As Integer = 0 To ListBoxColumns.Items.Count - 1
                ListBoxColumns.SetSelected(i, True)
            Next
        End If
        For i = 0 To columns.Count - 1
            If useAliases Then
                strFID = Regex.Replace(columns(i).Remark, "^.*\s", "")
                strFID = strFID & " AS "
            Else
                strFID = ""
            End If
            createCommaSeparatedColumns &= comma & strFID & """" & columns(i).Name & """"
            If addType Then
                createCommaSeparatedColumns &= " " & columns(i).type
                If Regex.Match(columns(i).type, "varchar", RegexOptions.IgnoreCase).Success Then
                    createCommaSeparatedColumns &= "(" + columns(i).size & ")"
                End If
                If Regex.Match(columns(i).type, "numeric", RegexOptions.IgnoreCase).Success Then
                    createCommaSeparatedColumns &= "(" + columns(i).size & ", " & columns(i).decimalPlaces & ")"
                End If
            End If
            comma = ", "
        Next
    End Function
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "SELECT "
        sql &= createCommaSeparatedColumns(ListBoxColumns.SelectedItems, True, False, chkAliases.Checked)
        sql &= " FROM """ & cmbTables.SelectedItem.ToString & """"
        insertReplaceText(txtSQL, sql)
    End Sub
    Private Sub btnINSERT_Click(sender As Object, e As EventArgs) Handles btnINSERT.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "INSERT INTO " & """" & cmbTables.SelectedItem.ToString & """ ("

        sql &= createCommaSeparatedColumns(ListBoxColumns.SelectedItems, False, False, False)
        sql &= ") VALUES ( "
        sql &= createCommaSeparatedValues(ListBoxColumns.SelectedItems, False)
        sql = sql.TrimEnd(New Char() {CType(",", Char), CType(" ", Char)})
        sql &= ")"
        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub btnUPDATE_Click(sender As Object, e As EventArgs) Handles btnUPDATE.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "UPDATE " & """" & cmbTables.SelectedItem.ToString & """ SET "
        sql &= createCommaSeparatedValues(ListBoxColumns.SelectedItems, True)
        sql = sql.TrimEnd(New Char() {CType(",", Char), CType(" ", Char)})
        sql &= " WHERE """ & ListBoxColumns.Items(2).name & """ = 0"

        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "DELETE FROM " & """" & cmbTables.SelectedItem.ToString & """"
        sql &= " WHERE """ & ListBoxColumns.Items(2).name & """ = 0"

        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub btnCREATE_Click(sender As Object, e As EventArgs) Handles btnCREATE.Click
        If cmbCatalogs.SelectedIndex = 0 Then
            MsgBox("Please choose an application in which the new table will be created.", MsgBoxStyle.OkOnly)
            Return
        End If
        Dim tableName As String = cmbTables.Text
        Dim catalog As String = cmbTables.SelectedItem.catalog
        Dim m = Regex.Match(tableName, "^(.*)[ _][a-kmnp-z2-9]+$")
        Dim sql As String = "CREATE TABLE ""Copy of " & m.Groups(1).Value.Substring(catalog.Length + 2) & " " & cmbCatalogs.Items(cmbCatalogs.SelectedIndex).dbid & """ (" & createCommaSeparatedColumns(ListBoxColumns.SelectedItems, False, True, False) & ")"
        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub btnDROP_Click(sender As Object, e As EventArgs) Handles btnDROP.Click
        If cmbTables.SelectedIndex <= 0 Then Exit Sub
        Dim sql As String = "DROP TABLE " & """" & cmbTables.SelectedItem.ToString & """"
        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub btnALTER_Click(sender As Object, e As EventArgs) Handles btnALTER.Click
        Dim sql As String = "ALTER TABLE """ & cmbTables.Text & """ ADD " & createCommaSeparatedColumns(ListBoxColumns.SelectedItems, False, True, False)
        insertReplaceText(txtSQL, sql)
    End Sub

    Private Sub btnFields_Click(sender As Object, e As EventArgs) Handles btnFields.Click
        insertReplaceText(txtSQL, createCommaSeparatedColumns(ListBoxColumns.SelectedItems, False, False, False))
    End Sub
    Private Sub cmbPassword_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPassword.SelectedIndexChanged
        SaveSetting(AppName, "Credentials", "passwordOrToken", cmbPassword.SelectedIndex)
        showHideControls()
    End Sub

    Private Sub btnAppToken_Click(sender As Object, e As EventArgs) Handles btnAppToken.Click
        Process.Start("https://qunect.com/flash/AppToken.html")
    End Sub
    Private Sub btnUserToken_Click(sender As Object, e As EventArgs) Handles btnUserToken.Click
        Process.Start("https://qunect.com/flash/UserToken.html")
    End Sub

    Private Sub startStopElapsedTime(start As Boolean)
        Static start_time As DateTime
        Static stop_time As DateTime
        Dim elapsed_time As TimeSpan

        If start Then
            lblElapsed.Text = ""
            start_time = Now
        Else
            stop_time = Now
            elapsed_time = stop_time.Subtract(start_time)
            lblElapsed.Text = "Elapsed Time: " & elapsed_time.TotalSeconds.ToString("0.000000")
        End If
    End Sub


End Class

