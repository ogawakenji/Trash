Imports System.Runtime.InteropServices

Public Class Form1

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetDesktopWindow() As IntPtr
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = GetDesktopWindow().ToString()
    End Sub

End Class
