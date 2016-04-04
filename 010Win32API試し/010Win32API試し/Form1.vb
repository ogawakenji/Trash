Public Class Form1
    Private Sub lblGetForeGroundWindow_Click(sender As Object, e As EventArgs) Handles lblGetForeGroundWindow.Click
        Dim frm As New Form_001GetForeGroundWindow()
        frm.Show(Me)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim frm As New Form_002SendMessage()
        frm.Show(Me)
    End Sub
End Class
