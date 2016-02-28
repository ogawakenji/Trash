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

    ''' <summary>
    ''' FindWindow 指定された文字列と一致するクラス名をウィンドウのタイトルを持つ
    ''' トップレベルウィンドウを探す
    ''' </summary>
    ''' <param name="lpClassName"></param>
    ''' <param name="lpWindowName"></param>
    ''' <returns></returns>
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(
        lpClassName As String,
        lpWindowName As String) As System.IntPtr
    End Function



    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        '' カーソルを手に変更
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        '' カーソルをデフォルトに戻す
        Me.Cursor = Cursors.Default

        '' マウス座標よりハンドル取得
        Dim hwnd As IntPtr
        hwnd = WindowFromPoint(Cursor.Position)

        '' ハンドルをメッセージボックスに表示
        MessageBox.Show(hwnd.ToString)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        '' フォーム2を表示
        Dim form As New Form2
        form.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        '' フォームのタイトルからハンドル取得
        Dim hwnd As IntPtr = FindWindow(Nothing, "ハンドル表示フォーム")
        '' ハンドルをメッセージボックスに表示
        MessageBox.Show(hwnd.ToString)
    End Sub


End Class
