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

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SetForegroundWindow(hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean

    End Function

    Const WM_VSCROLL As Integer = &H115I

    Const WM_PAINT As Integer = &HFI

    Const WM_SETREDRAW As Integer = &HBI



    Const SB_LINEUP As Short = &H0S

    Const SB_LINELEFT As Short = &H0S

    Const SB_LINEDOWN As Short = &H1S

    Const SB_LINERIGHT As Short = &H1S

    Const SB_PAGEUP As Short = &H2S

    Const SB_PAGELEFT As Short = &H2S

    Const SB_PAGEDOWN As Short = &H3S

    Const SB_PAGERIGHT As Short = &H3S

    Const SB_THUMBPOSITION As Short = &H4S

    Const SB_THUMBTRACK As Short = &H5S

    Const SB_TOP As Short = &H6S

    Const SB_LEFT As Short = &H6S

    Const SB_BOTTOM As Short = &H7S

    Const SB_RIGHT As Short = &H7S

    Const SB_ENDSCROLL As Short = &H8S



    <StructLayout(LayoutKind.Sequential)> Public Structure SCROLLINFO

        Public cbSize As Integer

        Public fMask As Integer

        Public nMin As Integer

        Public nMax As Integer

        Public nPage As Integer

        Public nPos As Integer

        Public nTrackPos As Integer

    End Structure



    Private Const SB_HORZ = 0    '標準水平スクロールバーを指定する

    Private Const SB_VERT = 1     '標準垂直スクロールバーを指定する

    Private Const SB_CTL = 2     'スクロールバーコントロールを指定する



    Private Const SIF_RANGE = &H1

    Private Const SIF_PAGE = &H2

    Private Const SIF_POS = &H4

    Private Const SIF_DISABLENOSCROLL = &H8

    Private Const SIF_TRACKPOS = &H10

    Private Const SIF_ALL = (SIF_RANGE Or SIF_PAGE Or SIF_POS Or SIF_TRACKPOS)



    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetScrollInfo(ByVal hWnd As IntPtr,
                                        ByVal nBar As Integer,
        <MarshalAs(UnmanagedType.Struct)> ByRef lpScrollInfo As SCROLLINFO) As Integer
    End Function



    <DllImport("user32.dll")>
    Private Shared Function SetScrollInfo(ByVal hWnd As IntPtr,
                                        ByVal nBar As Integer,
        <MarshalAs(UnmanagedType.Struct)> ByRef lpScrollInfo As SCROLLINFO) As Integer
    End Function

    'Private Const WM_VSCROLL As Integer = &H115
    Private Const WM_MOUSEWHEEL As Integer = &H020A


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

        ' 1000ミリ秒スリープ
        System.Threading.Thread.Sleep(1000)

        Dim hWnd As IntPtr = CType(Me.TextBox1.Text, IntPtr)
        SetForegroundWindow(hWnd)

        ' 1000ミリ秒スリープ
        System.Threading.Thread.Sleep(1000)

        Dim si As SCROLLINFO
        si.cbSize = Len(si)
        si.fMask = ScrollInfoMask.SIF_ALL

        GetScrollInfo(CType(Me.TextBox1.Text, IntPtr), 1, si)

        Me.TextBox2.Text = si.nPos.ToString


        'SendMessage(CType(Me.TextBox1.Text, IntPtr), WM_VSCROLL, CType(7, IntPtr), CType(0, IntPtr))
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        SendMessage(CType(Me.TextBox1.Text, IntPtr), WM_MOUSEWHEEL, CType(-1000, IntPtr), CType(0, IntPtr))
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Public Enum ScrollInfoMask As Integer
        SIF_RANGE = &H1
        SIF_PAGE = &H2
        SIF_POS = &H4
        SIF_DISABLENOSCROLL = &H8
        SIF_TRACKPOS = &H10
        SIF_ALL = (SIF_RANGE Or SIF_PAGE Or SIF_POS Or SIF_TRACKPOS)
    End Enum

    Private Sub RichTextBox1_VScroll(sender As Object, e As EventArgs) Handles RichTextBox1.VScroll
        Dim si As SCROLLINFO
        si.cbSize = Len(si)
        si.fMask = ScrollInfoMask.SIF_ALL
        Dim lRet As Integer = GetScrollInfo(RichTextBox1.Handle, 1, si)
        If si.nPage + si.nPos = si.nMax Then
            MessageBox.Show("最終スクロール")
        End If

    End Sub
End Class
