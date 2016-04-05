

Imports System.Runtime.InteropServices

Public Class Form_003SendInput
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
        User32.SetForegroundWindow(CType(Me.TextBox2.Text, IntPtr))

        Dim input As New User32.INPUT
        input.dwType = User32.InputType.Mouse
        input.mi.dwFlags = User32.MOUSEEVENTF.WHEEL
        input.mi.dx = 0
        input.mi.dy = 0
        input.mi.mouseData = -1 * 120 * 10
        input.mi.dwExtraInfo = CType(0, IntPtr)
        input.mi.time = 0

        For i As Integer = 0 To 10
            User32.SendInput(1, input, Marshal.SizeOf(input))
            Threading.Thread.Sleep(1000)
        Next




    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        User32.SetForegroundWindow(CType(Me.TextBox2.Text, IntPtr))
        User32.SendMessage(CType(Me.TextBox2.Text, IntPtr), User32.WM_MOUSEWHEEL, CType((120 * -1) << 16, IntPtr), IntPtr.Zero)
    End Sub
End Class