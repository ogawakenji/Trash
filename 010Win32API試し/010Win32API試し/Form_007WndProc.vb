

Imports System.Runtime.InteropServices

Public Class Form_007WndProc

    Private hWndList As New List(Of hWndEntity)
    Private scrollhWndList As New List(Of scrollwHndList)

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Timer1.Interval = 5000
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Me.TextBox2.Text = User32.GetForegroundWindow().ToString
        'lblScreen.Text = Cursor.Position.ToString()



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)

        'Dim lparam As Integer

        'Me.DataGridView1.DataSource = Nothing

        'hWndList.Clear()

        'User32.EnumChildWindows(hWnd, AddressOf EnumChildProc, lparam)

        'Me.DataGridView1.DataSource = hWndList


    End Sub

    Function EnumChildProc(ByVal hWnd As IntPtr, ByRef lparam As IntPtr) As Boolean

        hWndList.Add(New hWndEntity With {.hWnd = hWnd, .scrollbar = ""})

        Return True
    End Function

    Private Class hWndEntity
        Public Property hWnd As IntPtr

        Public Property scrollbar As String
    End Class

    Private Class scrollwHndList
        Public Property hWnd As IntPtr
        Public Property scrollInfo As User32.SCROLLINFO
    End Class

    Private Sub Button4_Click(sender As Object, e As EventArgs)

        Dim ret As Integer = 0
        For Each r In hWndList.ToList
            ret = User32.GetWindowLong(r.hWnd, User32.WindowLongFlags.GWL_STYLE)
            Debug.WriteLine(ret.ToString())
            If (ret And User32.WS_VSCROLL) <> 0 Then
                r.scrollbar = "○"
            End If

            'Dim si As User32.SCROLLINFO
            'si.cbSize = Len(si)
            'si.fMask = User32.ScrollInfoMask.SIF_ALL

            'User32.GetScrollInfo(r.hWnd, 1, si)

            'r.scrollbar = si.nPos.ToString

        Next

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

    Private Sub Label2_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Label2_MouseDown(sender As Object, e As MouseEventArgs)
        '' カーソルを十字に変更
        Me.Cursor = Cursors.Cross
    End Sub

    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs)
        '' カーソルをデフォルトに戻す
        Me.Cursor = Cursors.Default

        '' マウス座標よりハンドル取得
        Dim hwnd As IntPtr
        'hwnd = User32.WindowFromPoint(Cursor.Position)
        'Me.TextBox2.Text = CType(hwnd, String)
    End Sub

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

    Private Sub Button15_Click(sender As Object, e As EventArgs)
        'Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)

        'Dim info As New User32.WINDOWINFO
        'info.cbSize = Marshal.SizeOf(info)
        'User32.GetWindowInfo(hWnd, info)

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)

        Select Case m.Msg
            Case User32.WM_MOUSEWHEEL
                Dim wDelta As Integer
                wDelta = HIWORD(m.WParam)

                Debug.WriteLine(String.Format("{0} {1} {2} {3} {4}", m.Msg, m.LParam, m.WParam, m.Result, wDelta))

        End Select




        MyBase.WndProc(m)
    End Sub

    Private Function LOWORD(ByVal value As IntPtr) As Integer
        Return CInt((value.ToInt32 And &HFFFF&))
    End Function
    Private Function HIWORD(ByVal value As IntPtr) As Integer
        Return (value.ToInt32 And &HFFFF0000%) \ &H10000%
    End Function

    Private Sub Form_005EnumChildWindows_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form_005EnumChildWindows_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        'Debug.WriteLine("Form_005EnumChildWindows_MouseWheel")

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel2_MouseWheel(sender As Object, e As MouseEventArgs) Handles Panel2.MouseWheel
        Panel2.Focus()
    End Sub
End Class


