Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '' 起動時の位置を手動に変更
        Me.StartPosition = FormStartPosition.Manual

        '' マウスがあるスクリーンを取得
        Dim screenIndex As Integer = ConvertMousePointToScreenIndex(Cursor.Position)

        '' スクリーンの中央に位置づける
        Me.DesktopLocation = CenterPosition(screenIndex)

    End Sub


    ''' <summary>
    ''' マウスの位置にあるスクリーンのインデックスを返却する
    ''' </summary>
    ''' <param name="mousePoint"></param>
    ''' <returns></returns>
    Private Function ConvertMousePointToScreenIndex(ByVal mousePoint As Point) As Integer
        '' ディスプレイの範囲
        Dim ret As Rectangle

        For i As Integer = 0 To Screen.AllScreens.Count - 1
            ret = Screen.AllScreens(i).Bounds

            If ret.Contains(mousePoint) Then
                '' ディスプレイの範囲にマウスポインタがあるディスプレイのIndexを返却
                Return i
            End If
        Next
        Return 0
    End Function

    ''' <summary>
    ''' 中央の位置を返却する
    ''' </summary>
    ''' <param name="screenIndex"></param>
    ''' <returns></returns>
    Private Function CenterPosition(screenIndex As Integer) As Point
        '' マウスの位置のスクリーンを取得
        Dim screen As Screen = Screen.AllScreens(ConvertMousePointToScreenIndex(Cursor.Position))

        '' 自身のフォームのサイズとスクリーンのサイズから中央に位置するロケーションを計算
        Return New Point(screen.Bounds.X + (screen.Bounds.Width - Me.Width) \ 2, screen.Bounds.Y + (screen.Bounds.Height - Me.Height) \ 2)
    End Function


End Class
