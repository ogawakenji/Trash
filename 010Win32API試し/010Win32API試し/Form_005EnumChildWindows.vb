

Imports System.Runtime.InteropServices

Public Class Form_005EnumChildWindows

    Private hWndList As New List(Of hWndEntity)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Interval = 5000
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.TextBox2.Text = User32.GetForegroundWindow().ToString
        lblScreen.Text = Cursor.Position.ToString()



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)

        Dim lparam As Integer

        Me.DataGridView1.DataSource = Nothing

        hWndList.Clear()

        User32.EnumChildWindows(hWnd, AddressOf EnumChildProc, lparam)

        Me.DataGridView1.DataSource = hWndList


    End Sub

    Function EnumChildProc(ByVal hWnd As IntPtr, ByRef lparam As IntPtr) As Boolean

        hWndList.Add(New hWndEntity With {.hWnd = hWnd, .scrollbar = ""})

        Return True
    End Function

    Private Class hWndEntity
        Public Property hWnd As IntPtr
        Public Property scrollbar As String
    End Class

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim ret As Integer = 0
        For Each r In hWndList.ToList
            ret = User32.GetWindowLong(r.hWnd, User32.WindowLongFlags.GWL_STYLE)
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)
        'User32.SetForegroundWindow(hWnd)

        For Each r In hWndList.ToList
            Threading.Thread.Sleep(1000)
            'User32.SetForegroundWindow(r.hWnd)
            User32.SendMessage(r.hWnd, User32.WM_MOUSEWHEEL, CType((120 * -1) << 16, IntPtr), IntPtr.Zero)
        Next

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click


    End Sub

    Private Sub Label2_MouseDown(sender As Object, e As MouseEventArgs) Handles Label2.MouseDown
        '' カーソルを十字に変更
        Me.Cursor = Cursors.Cross
    End Sub

    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs) Handles Label2.MouseUp
        '' カーソルをデフォルトに戻す
        Me.Cursor = Cursors.Default

        '' マウス座標よりハンドル取得
        Dim hwnd As IntPtr
        hwnd = User32.WindowFromPoint(Cursor.Position)
        Me.TextBox2.Text = CType(hwnd, String)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)
        User32.SendMessage(hWnd, User32.WM_MOUSEWHEEL, CType((120 * -1) << 16, IntPtr), IntPtr.Zero)

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim rect As User32.RECT

        Dim hWnd As IntPtr = CType(Me.TextBox2.Text, IntPtr)
        User32.GetWindowRect(hWnd, rect)

        Debug.WriteLine(String.Format("left={0} top={1} right={2} bottom={3}", rect.left, rect.top, rect.right, rect.bottom))

        User32.SetCursorPos(rect.left, rect.top)

    End Sub
End Class


