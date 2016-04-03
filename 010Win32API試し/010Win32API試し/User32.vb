Imports System.Runtime.InteropServices

Public Class User32

    <DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=False, SetLastError:=False)>
    Public Shared Function GetForegroundWindow() As IntPtr

    End Function




End Class
