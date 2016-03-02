Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DataGridView1.Columns.Add("col1", "col1")
        Me.DataGridView1.Columns.Add("col2", "col2")
        Me.DataGridView1.RowCount = 20

    End Sub
End Class