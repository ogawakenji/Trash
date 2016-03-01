Imports System.Runtime.InteropServices

Public Class Form2
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal msg As UInteger, ByVal mParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    End Function

    Private Const WM_VSCROLL As Integer = &H115
    Private Const WM_MOUSEWHEEL As Integer = &H020A
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DataGridView1.Columns.Add("col1", "col1")
        Me.DataGridView1.Columns.Add("col2", "col2")
        Me.DataGridView1.RowCount = 20
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_HSCROLL As Integer = &H114
        Const WM_VSCROLL As Integer = &H115

        Select Case m.Msg
            Case WM_HSCROLL
                Console.WriteLine("水平スクロールバーがスクロールされました。")
            Case WM_VSCROLL
                Console.WriteLine("垂直スクロールバーがスクロールされました。")
        End Select
        MyBase.WndProc(m)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        SendMessage(CType(Me.TextBox1.Text, IntPtr), WM_MOUSEWHEEL, CType(-1000, IntPtr), CType(0, IntPtr))
    End Sub
End Class