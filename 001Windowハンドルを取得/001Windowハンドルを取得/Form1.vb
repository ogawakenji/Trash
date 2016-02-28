Imports System.Runtime.InteropServices

Public Class Form1


    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function WindowFromPoint(ByVal lpPoint As Point) _
                                            As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(
        lpClassName As String,
        lpWindowName As String) As System.IntPtr
    End Function








    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        Me.Cursor = Cursors.Default

        'MessageBox.Show(Cursor.Position.ToString)
        'MessageBox.Show(String.Format("e.X={0},e.Y={1}", e.X, e.Y))
        'Dim lpPoint As New Point(e.X, e.Y)

        ''マウス座標よりハンドル取得
        Dim hwnd As IntPtr
        'hwnd = WindowFromPoint(lpPoint)
        'MessageBox.Show(hwnd.ToString)

        'If hwnd.ToInt32() <= 0 Then
        '    'ハンドル取得失敗
        '    Me.Label2.Text = ""
        '    Exit Sub
        'End If
        hwnd = WindowFromPoint(Cursor.Position)
        MessageBox.Show(hwnd.ToString)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim form As New Form2
        form.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        ' Program Manager のハンドルを取得する
        Dim hProgramManagerHandle As System.IntPtr = FindWindow(Nothing, "ハンドル表示フォーム")
        MessageBox.Show(hProgramManagerHandle.ToString)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
