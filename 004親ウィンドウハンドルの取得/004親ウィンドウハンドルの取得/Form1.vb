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

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim form As New Form2
        form.Show()
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        '' カーソルをデフォルトに戻す
        Me.Cursor = Cursors.Default

        '' マウス座標よりハンドル取得
        Dim hwnd As IntPtr
        hwnd = WindowFromPoint(Cursor.Position)

        Dim parentHwnd As IntPtr
        parentHwnd = GetParent(hwnd)

        '' ハンドルをメッセージボックスに表示
        MessageBox.Show(String.Format("ハンドル{0} 親ハンドル{1}", hwnd.ToString(), parentHwnd.ToString()))
    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        '' カーソルを十字に変更
        Me.Cursor = Cursors.Cross
    End Sub

End Class
