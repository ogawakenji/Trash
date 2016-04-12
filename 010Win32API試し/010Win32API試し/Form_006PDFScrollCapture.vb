

Imports System.Runtime.InteropServices

Public Class Form_006PDFScrollCapture

    Private hWndList As New List(Of hWndEntity)
    Private childhWndList As New List(Of IntPtr)
    Private scrollhWndList As New List(Of scrollhWndEntity)
    Private oneScrollList As New List(Of scrollhWndEntity)


    Private Class scrollhWndEntity
        Public Property hWnd As IntPtr
        Public Property scrollInfo As User32.SCROLLINFO
    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Timer1.Interval = 5000
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Me.TextBox2.Text = User32.GetForegroundWindow().ToString
        ''lblScreen.Text = Cursor.Position.ToString()



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)

        'Dim lparam As Integer

        ''Me.DataGridView1.DataSource = Nothing

        'hWndList.Clear()

        'User32.EnumChildWindows(hWnd, AddressOf EnumChildProc, lparam)

        ''Me.DataGridView1.DataSource = hWndList


    End Sub

    Function EnumChildProc(ByVal hWnd As IntPtr, ByRef lparam As IntPtr) As Boolean

        childhWndList.Add(hWnd)

        Return True

    End Function

    Private Class hWndEntity
        Public Property hWnd As IntPtr
        Public Property scrollbar As String
    End Class

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click

        If String.IsNullOrEmpty(Me.txtCapturehWnd.Text) Then
            Return
        End If

        If String.IsNullOrEmpty(Me.txtRoothWnd.Text) Then
            Return
        End If

        Dim rect As User32.RECT

        Dim hWnd As IntPtr = CType(Me.txtCapturehWnd.Text, IntPtr)
        User32.SetForegroundWindow(hWnd)
        User32.GetWindowRect(hWnd, rect)
        User32.SetCursorPos(rect.left, rect.top)


        '' ============================================================
        '' ルートのウィンドウハンドルの子ウィンドウハンドルを取得する
        '' ============================================================
        Dim roothWnd As IntPtr = CType(Me.txtRoothWnd.Text, IntPtr)
        Dim lparam As Integer
        childhWndList.Clear()
        User32.EnumChildWindows(roothWnd, AddressOf EnumChildProc, lparam)


        '' ============================================================
        '' スクロールをもつウィンドウハンドルを探す
        '' ============================================================
        Dim scrollhWnd As IntPtr = Nothing
        scrollhWndList.Clear()
        oneScrollList.Clear()

        '' ルートウィンドウからスクロールをもつウィンドウハンドルを探す
        AddScrollhWndList(roothWnd, scrollhWndList)

        '' 子ウィンドウハンドルからスクロールをもつウィンドウハンドルを探す
        For Each childhWnd In childhWndList
            AddScrollhWndList(childhWnd, scrollhWndList)
        Next

        Dim hasScroll As Boolean = True
        If scrollhWndList.Count = 0 Then
            '' スクロールをもつウィンドウハンドルが存在しない。
            hasScroll = False
        End If


        '' ==============================
        '' キャプチャするウィンドウハンドルの画像を取得
        '' ==============================

        Dim baseImage As Image = CapturehWnd(hWnd)


        '' ==============================
        '' スクロールをもつウィンドウハンドルがある場合の処理
        '' ==============================
        If hasScroll = False Then
            '' スクロールなければ次へ
        Else
            '' スクロールがあれば以下処理する
            Dim scrollSi As User32.SCROLLINFO

            '' ==================================================
            '' キャプチャウィンドウハンドルにマウスホイールのメッセージを送る
            '' ==================================================
            User32.SendMessage(hWnd, User32.WM_MOUSEWHEEL, CType((120 * -1) << 16, IntPtr), IntPtr.Zero)

            '' ルートウィンドウからスクロールをもつウィンドウハンドルを探す
            AddScrollhWndList(roothWnd, oneScrollList)

            '' 子ウィンドウハンドルからスクロールをもつウィンドウハンドルを探す
            For Each childhWnd In childhWndList
                AddScrollhWndList(childhWnd, oneScrollList)
            Next

            '' 変動があるウィンドウハンドルを探す
            For Each sl In scrollhWndList
                For Each osl In oneScrollList
                    If sl.hWnd = osl.hWnd Then
                        If sl.scrollInfo.nPos <> osl.scrollInfo.nPos Then
                            scrollhWnd = sl.hWnd
                            Exit For
                        End If
                    End If
                Next
                If scrollhWnd <> CType(0, IntPtr) Then
                    Exit For
                End If
            Next

            Dim tmpSi As User32.SCROLLINFO = Nothing


            ' 移動量を取得
            Dim scrollHeight As Integer = 0
            For Each sl In scrollhWndList
                If sl.hWnd = scrollhWnd Then
                    scrollHeight = sl.scrollInfo.nPos
                End If
            Next
            For Each osl In oneScrollList
                If osl.hWnd = scrollhWnd Then
                    scrollHeight = osl.scrollInfo.nPos - scrollHeight
                    tmpSi = osl.scrollInfo
                End If
            Next
            If scrollHeight = 0 Then
                Me.PictureBox1.Image = baseImage

            Else

                'Dim mixImage As Image = CaptureScrollHeight(hWnd, scrollHeight)
                Dim mixImage As Image = CaptureScrollHeight(hWnd, 48)

                Dim newImage As Image = ImageMix(baseImage, mixImage)


                While tmpSi.nPos < (tmpSi.nMax - tmpSi.nMin + 1) - tmpSi.nPage
                    scrollHeight = tmpSi.nPos

                    User32.SendMessage(hWnd, User32.WM_MOUSEWHEEL, CType((120 * -1) << 16, IntPtr), IntPtr.Zero)

                    GetScrollInfo(scrollhWnd, tmpSi)
                    scrollHeight = tmpSi.nPos - scrollHeight

                    'mixImage = CaptureScrollHeight(hWnd, scrollHeight)
                    mixImage = CaptureScrollHeight(hWnd, 48)
                    newImage = ImageMix(newImage, mixImage)

                    'Threading.Thread.Sleep(100)
                End While


                Me.PictureBox1.Image = newImage
            End If





        End If





        'Dim ret As Integer = 0
        'For Each r In hWndList.ToList
        '    ret = User32.GetWindowLong(r.hWnd, User32.WindowLongFlags.GWL_STYLE)
        '    Debug.WriteLine(ret.ToString())
        '    If (ret And User32.WS_VSCROLL) <> 0 Then
        '        r.scrollbar = "○"
        '    End If

        '    'Dim si As User32.SCROLLINFO
        '    'si.cbSize = Len(si)
        '    'si.fMask = User32.ScrollInfoMask.SIF_ALL

        '    'User32.GetScrollInfo(r.hWnd, 1, si)

        '    'r.scrollbar = si.nPos.ToString

        'Next

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)
        ''User32.SetForegroundWindow(hWnd)

        'For Each r In hWndList.ToList
        '    Threading.Thread.Sleep(1000)
        '    'User32.SetForegroundWindow(r.hWnd)
        '    User32.SendMessage(r.hWnd, User32.WM_MOUSEWHEEL, CType((120 * -1) << 16, IntPtr), IntPtr.Zero)
        'Next

    End Sub



    Private Sub lblDragAndDrop_MouseDown(sender As Object, e As MouseEventArgs) Handles lblDragAndDrop.MouseDown
        '' カーソルを十字に変更
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub lblDragAndDrop_MouseUp(sender As Object, e As MouseEventArgs) Handles lblDragAndDrop.MouseUp
        '' カーソルをデフォルトに戻す
        Me.Cursor = Cursors.Default

        '' ==============================================
        '' マウスの座標にあるウィンドウハンドルを取得する
        '' ==============================================
        Dim hWnd As IntPtr
        hWnd = User32.WindowFromPoint(Cursor.Position)
        Me.txtCapturehWnd.Text = CType(hWnd, String)

        '' ==============================================
        '' 取得したウィンドウハンドルのルートのウィンドウハンドルを取得する
        '' ==============================================
        Dim roothWnd As IntPtr = User32.GetAncestor(hWnd, User32.GetAncestor_Flags.GetRoot)
        Me.txtRoothWnd.Text = CType(roothWnd, String)


    End Sub

    Private Sub AddScrollhWndList(hWnd As IntPtr, list As List(Of scrollhWndEntity))
        Dim si As User32.SCROLLINFO
        si.cbSize = Len(si)
        si.fMask = User32.ScrollInfoMask.SIF_ALL

        Dim ret As Integer = 0

        ret = User32.GetScrollInfo(hWnd, User32.SBOrientation.SB_HORZ, si)
        If ret <> 0 Then
            list.Add(New scrollhWndEntity() With {.hWnd = hWnd, .scrollInfo = si})
            Return
        End If

        ret = User32.GetScrollInfo(hWnd, User32.SBOrientation.SB_VERT, si)
        If ret <> 0 Then
            list.Add(New scrollhWndEntity() With {.hWnd = hWnd, .scrollInfo = si})
            Return
        End If

        ret = User32.GetScrollInfo(hWnd, User32.SBOrientation.SB_CTL, si)
        If ret <> 0 Then
            list.Add(New scrollhWndEntity() With {.hWnd = hWnd, .scrollInfo = si})
            Return
        End If

        ret = User32.GetScrollInfo(hWnd, User32.SBOrientation.SB_BOTH, si)
        If ret <> 0 Then
            list.Add(New scrollhWndEntity() With {.hWnd = hWnd, .scrollInfo = si})
            Return
        End If

    End Sub

    Private Function GetScrollInfo(hWnd As IntPtr, ByRef si As User32.SCROLLINFO) As Integer
        si.cbSize = Len(si)
        si.fMask = User32.ScrollInfoMask.SIF_ALL

        Dim ret As Integer = 0

        ret = User32.GetScrollInfo(hWnd, User32.SBOrientation.SB_HORZ, si)
        If ret <> 0 Then
            Return ret
        End If

        ret = User32.GetScrollInfo(hWnd, User32.SBOrientation.SB_VERT, si)
        If ret <> 0 Then
            Return ret
        End If

        ret = User32.GetScrollInfo(hWnd, User32.SBOrientation.SB_CTL, si)
        If ret <> 0 Then
            Return ret
        End If

        ret = User32.GetScrollInfo(hWnd, User32.SBOrientation.SB_BOTH, si)
        If ret <> 0 Then
            Return ret
        End If

        Return 0

    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)
        'User32.SendMessage(hWnd, User32.WM_MOUSEWHEEL, CType((120 * -1) << 16, IntPtr), IntPtr.Zero)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        'Dim rect As User32.RECT


        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)




        'User32.SetForegroundWindow(hWnd)

        'User32.GetWindowRect(hWnd, rect)

        'Debug.WriteLine(String.Format("left={0} top={1} right={2} bottom={3}", rect.left, rect.top, rect.right, rect.bottom))

        'User32.SetCursorPos(rect.left, rect.top)

        'User32.SendMessage(hWnd, User32.WM_MOUSEWHEEL, CType((120 * -1) << 16, IntPtr), IntPtr.Zero)

        'Threading.Thread.Sleep(1000)

        'Dim lpMinPos As Integer = 0
        'Dim lpMaxPos As Integer = 0
        'Dim b As Boolean = User32.GetScrollRange(hWnd, 1, lpMinPos, lpMaxPos)
        'Debug.WriteLine(String.Format("hWnd={0} GetScrollRange={1} lpMinPos={2} lpMaxPos={3}", hWnd, b, lpMinPos, lpMaxPos))

        'Dim input As New User32.INPUT
        'input.dwType = User32.InputType.Mouse
        'input.mi.dwFlags = User32.MOUSEEVENTF.WHEEL
        'input.mi.dx = 0
        'input.mi.dy = 0
        'input.mi.mouseData = -1 * 120
        'input.mi.dwExtraInfo = CType(0, IntPtr)
        'input.mi.time = 0

        'For i As Integer = 0 To 10
        '    User32.SendInput(1, input, Marshal.SizeOf(input))
        '    Threading.Thread.Sleep(1000)
        'Next


        'For Each r In hWndList.ToList
        '    User32.SetForegroundWindow(r.hWnd)

        '    User32.GetWindowRect(r.hWnd, rect)

        '    User32.SetCursorPos(rect.left, rect.top)

        '    User32.SendMessage(r.hWnd, User32.WM_MOUSEWHEEL, CType((120 * -1) << 16, IntPtr), IntPtr.Zero)

        '    Threading.Thread.Sleep(1000)

        '    Dim ret As Integer = User32.GetScrollPos(r.hWnd, User32.SBOrientation.SB_VERT)
        '    Debug.WriteLine(ret.ToString())

        '    b = User32.GetScrollRange(r.hWnd, 1, lpMinPos, lpMaxPos)
        '    Debug.WriteLine(String.Format("hWnd={0} GetScrollRange={1} lpMinPos={2} lpMaxPos={3}", r.hWnd, b, lpMinPos, lpMaxPos))

        'Next

        'User32.SetForegroundWindow(Me.Handle)

        'User32.GetWindowRect(Me.Handle, rect)

        'User32.SetCursorPos(rect.left, rect.top)

        'MessageBox.Show("終了")

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)

        'Dim si As New User32.SCROLLINFO
        'si.cbSize = Len(si)
        'si.fMask = User32.ScrollInfoMask.SIF_ALL

        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)
        'DebugGetScrollInfo(hWnd)

        'For Each r In hWndList.ToList

        '    DebugGetScrollInfo(r.hWnd)
        'Next

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        'Dim rect As User32.RECT

        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)
        'User32.SetForegroundWindow(hWnd)

        'User32.GetWindowRect(hWnd, rect)

        'User32.SetCursorPos(rect.left, rect.top)

    End Sub

    Private Sub DebugGetScrollInfo(hWnd As IntPtr)
        Dim si As New User32.SCROLLINFO
        si.cbSize = Len(si)
        si.fMask = User32.ScrollInfoMask.SIF_ALL
        Dim ret As Integer = 0
        ret = User32.GetScrollInfo(hWnd, 0, si)
        If si.nPos <> 0 Then
            Debug.WriteLine(String.Format("hWnd={0} GetScrollInfo0={1} si.nPos={2} nMin={3} nMax={4} nPage={5} nTrackPos={6}", hWnd, ret, si.nPos, si.nMin, si.nMax, si.nPage, si.nTrackPos))
        End If

        si = New User32.SCROLLINFO
        si.cbSize = Len(si)
        si.fMask = User32.ScrollInfoMask.SIF_ALL
        ret = User32.GetScrollInfo(hWnd, 1, si)
        If si.nPos <> 0 Then
            Debug.WriteLine(String.Format("hWnd={0} GetScrollInfo1={1} si.nPos={2} nMin={3} nMax={4} nPage={5} nTrackPos={6}", hWnd, ret, si.nPos, si.nMin, si.nMax, si.nPage, si.nTrackPos))
        End If

        si = New User32.SCROLLINFO
        si.cbSize = Len(si)
        si.fMask = User32.ScrollInfoMask.SIF_ALL
        ret = User32.GetScrollInfo(hWnd, 2, si)
        If si.nPos <> 0 Then
            Debug.WriteLine(String.Format("hWnd={0} GetScrollInfo2={1} si.nPos={2} nMin={3} nMax={4} nPage={5} nTrackPos={6}", hWnd, ret, si.nPos, si.nMin, si.nMax, si.nPage, si.nTrackPos))
        End If


    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)
        'PictureBox1.Image = CapturehWnd(hWnd)

    End Sub

    Private Function CapturehWnd(hWnd As IntPtr) As Bitmap
        ' 指定ウィンドウハンドルの画像を取得
        Dim winDC As IntPtr = User32.GetWindowDC(hWnd)
        'ウィンドウの大きさを取得
        Dim winRect As New User32.RECT
        User32.GetWindowRect(hWnd, winRect)
        'Bitmapの作成
        Dim bmp As New Bitmap(winRect.right - winRect.left,
            winRect.bottom - winRect.top)
        'Graphicsの作成
        Dim g As Graphics = Graphics.FromImage(bmp)
        'Graphicsのデバイスコンテキストを取得
        Dim hDC As IntPtr = g.GetHdc()
        'Bitmapに画像をコピーする
        User32.BitBlt(hDC, 0, 0, bmp.Width, bmp.Height, winDC, 0, 0, User32.SRCCOPY)
        '解放
        g.ReleaseHdc(hDC)
        g.Dispose()
        User32.ReleaseDC(hWnd, winDC)

        Return bmp
    End Function

    Private Function CapturehWnd5pix(hWnd As IntPtr) As Bitmap
        ' 指定ウィンドウハンドルの画像を取得
        Dim winDC As IntPtr = User32.GetWindowDC(hWnd)
        'ウィンドウの大きさを取得
        Dim winRect As New User32.RECT
        User32.GetWindowRect(hWnd, winRect)
        'Bitmapの作成
        Dim bmp As New Bitmap(winRect.right - winRect.left, 48)
        'Graphicsの作成
        Dim g As Graphics = Graphics.FromImage(bmp)
        'Graphicsのデバイスコンテキストを取得
        Dim hDC As IntPtr = g.GetHdc()
        'Bitmapに画像をコピーする
        User32.BitBlt(hDC, 0, 0, bmp.Width, 48, winDC, 0, winRect.bottom - winRect.top - 48, User32.SRCCOPY)
        '解放
        g.ReleaseHdc(hDC)
        g.Dispose()
        User32.ReleaseDC(hWnd, winDC)

        Return bmp
    End Function

    Private Sub Button12_Click(sender As Object, e As EventArgs)
        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)

        'For i As Integer = 0 To 50
        '    User32.SendMessage(hWnd, User32.WM_MOUSEWHEEL, CType((120 * -1) << 16, IntPtr), IntPtr.Zero)
        '    imageMix()

        'Next



    End Sub

    Private Function CaptureScrollHeight(hWnd As IntPtr, height As Integer) As Bitmap
        ' 指定ウィンドウハンドルの画像を取得
        Dim winDC As IntPtr = User32.GetWindowDC(hWnd)
        'ウィンドウの大きさを取得
        Dim winRect As New User32.RECT
        User32.GetWindowRect(hWnd, winRect)
        'Bitmapの作成
        Dim bmp As New Bitmap(winRect.right - winRect.left, height)
        'Graphicsの作成
        Dim g As Graphics = Graphics.FromImage(bmp)
        'Graphicsのデバイスコンテキストを取得
        Dim hDC As IntPtr = g.GetHdc()
        'Bitmapに画像をコピーする
        User32.BitBlt(hDC, 0, 0, bmp.Width, height, winDC, 0, winRect.bottom - winRect.top - height, User32.SRCCOPY)
        '解放
        g.ReleaseHdc(hDC)
        g.Dispose()
        User32.ReleaseDC(hWnd, winDC)

        Return bmp
    End Function


    Private Function ImageMix(baseImage As Image, mixImage As Image) As Image
        Dim baseBitmap As System.Drawing.Bitmap = CType(baseImage, Bitmap)
        Dim tmpGr As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(baseImage)
        Dim mixBitmap As System.Drawing.Bitmap = CType(mixImage, Bitmap)
        Dim canvas As New Bitmap(baseBitmap.Width, baseBitmap.Height + mixBitmap.Height)
        Dim g As Graphics = Graphics.FromImage(canvas)

        g.DrawImage(baseBitmap, 0, 0, baseBitmap.Width, baseBitmap.Height)
        g.DrawImage(mixBitmap, 0, baseBitmap.Height, mixBitmap.Width, mixBitmap.Height)

        g.Dispose()
        tmpGr.Dispose()
        baseBitmap.Dispose()
        mixBitmap.Dispose()
        baseImage.Dispose()
        mixImage.Dispose()

        GC.Collect()


        Return canvas

    End Function

    Private Sub imageMix()
        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)


        'Dim mixImage As System.Drawing.Bitmap = CType(Me.PictureBox1.Image, Bitmap)
        'Dim tmpGr As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(mixImage)
        'Dim foreimage As System.Drawing.Bitmap = CType(CapturehWnd5pix(hWnd), Bitmap)
        'Dim canvas As New Bitmap(mixImage.Width, mixImage.Height + foreimage.Height)
        'Dim g As Graphics = Graphics.FromImage(canvas)

        'g.DrawImage(mixImage, 0, 0, mixImage.Width, mixImage.Height)
        'g.DrawImage(foreimage, 0, mixImage.Height, foreimage.Width, foreimage.Height)

        'g.Dispose()
        'tmpGr.Dispose()

        'Me.PictureBox1.Image = canvas

        'mixImage.Dispose()
        'foreimage.Dispose()




    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)
        'Dim ownerhWnd As IntPtr = User32.GetWindow(hWnd, User32.GetWindow_Cmd.GW_OWNER)
        'Debug.WriteLine("hWnd={0} OwnerhWnd={1}", hWnd, ownerhWnd)

        'For Each r In hWndList.ToList
        '    ownerhWnd = User32.GetWindow(r.hWnd, User32.GetWindow_Cmd.GW_OWNER)
        '    Debug.WriteLine("hWnd={0} OwnerhWnd={1}", r.hWnd, ownerhWnd)

        'Next

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)
        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)
        'Dim roothWnd As IntPtr = User32.GetAncestor(hWnd, User32.GetAncestor_Flags.GetRoot)
        'Debug.WriteLine("hWnd={0} roothWnd={1}", hWnd, roothWnd)

        'For Each r In hWndList.ToList
        '    roothWnd = User32.GetAncestor(r.hWnd, User32.GetAncestor_Flags.GetRoot)
        '    Debug.WriteLine("hWnd={0} roothWnd={1}", r.hWnd, roothWnd)

        'Next
    End Sub
End Class


