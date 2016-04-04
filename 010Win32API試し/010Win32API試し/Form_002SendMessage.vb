

Public Class Form_002SendMessage
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Interval = 5000
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.TextBox2.Text = User32.GetForegroundWindow().ToString

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        User32.SendMessage(CType(Me.TextBox2.Text, IntPtr), User32.WM_CLOSE, IntPtr.Zero, IntPtr.Zero)
    End Sub
End Class