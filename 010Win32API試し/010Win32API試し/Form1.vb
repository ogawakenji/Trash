Public Class Form1
    Private Sub lblGetForeGroundWindow_Click(sender As Object, e As EventArgs) Handles lblGetForeGroundWindow.Click
        Dim frm As New Form_001GetForeGroundWindow()
        frm.Show(Me)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim frm As New Form_002SendMessage()
        frm.Show(Me)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim frm As New Form_003SendInput()
        frm.Show(Me)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim frm As New Form_004SetWindowsHookEx()
        frm.Show(Me)
    End Sub
End Class
