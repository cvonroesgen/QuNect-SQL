Public Class frmResults
    Private Sub dgvSQL_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSQL.RowLeave
        Dim cmdbuilder As New Odbc.OdbcCommandBuilder(frmSQL.Adpt)
        'Dim i As Integer
        Try
            'i = frmSQL.Adpt.Update(frmSQL.ds)
            'MsgBox("Records Updated= " & i)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmResults_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        dgvSQL.Width = Me.ClientSize.Width
        dgvSQL.Height = Me.ClientSize.Height
    End Sub
End Class