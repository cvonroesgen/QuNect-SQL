Public Class frmResults
    Private Sub dgvSQL_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSQL.RowLeave
        Dim cmdbuilder As New Odbc.OdbcCommandBuilder(frmSQL.Adpt)
        'Dim i As Integer
        Try
            'i = frmSQL.Adpt.Update(frmSQL.ds)
            'MsgBox("Records Updated= " & i)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "QuNect SQL")
        End Try
    End Sub


End Class