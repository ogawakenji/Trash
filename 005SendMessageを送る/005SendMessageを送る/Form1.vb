Imports System.Runtime.InteropServices

Public Class Form1

    ''' <summary>
    ''' WindowFormPoint 指定された座標を含むウィンドウのハンドルを取得 の宣言
    ''' </summary>
    ''' <param name="lpPoint"></param>
    ''' <returns></returns>
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function WindowFromPoint(ByVal lpPoint As Point) _
                                            As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetParent(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal msg As UInteger, ByVal mParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    End Function

    Private Const WM_VSCROLL As Integer = &H115
    Private Const WM_MOUSEWHEEL As Integer = &H020A


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim form As New Form2
        form.Show()
    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        '' カーソルを十字に変更
        Me.Cursor = Cursors.Cross
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        '' カーソルをデフォルトに戻す
        Me.Cursor = Cursors.Default

        '' マウス座標よりハンドル取得
        Dim hwnd As IntPtr
        hwnd = WindowFromPoint(Cursor.Position)

        Me.TextBox1.Text = hwnd.ToString()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        SendMessage(CType(Me.TextBox1.Text, IntPtr), WM_VSCROLL, CType(7, IntPtr), CType(0, IntPtr))
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        SendMessage(CType(Me.TextBox1.Text, IntPtr), WM_MOUSEWHEEL, CType(-1000, IntPtr), CType(0, IntPtr))
    End Sub
End Class
