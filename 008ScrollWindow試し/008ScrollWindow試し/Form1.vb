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

    'クライアント領域等の矩形を指定する構造体
    Private Structure RECT
        Dim Left As Integer
        Dim Top As Integer
        Dim Right As Integer
        Dim Bottom As Integer
    End Structure

    '指定の条件でクライアント領域をスクロールする(97)
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function ScrollWindowEx(
   ByVal hwnd As IntPtr,
   ByVal dx As Integer,
   ByVal dy As Integer,
   ByVal lprcScroll As Integer,
   ByRef lprcClip As RECT,
   ByVal hrgnUpdate As Integer,
   ByRef lprcUpdate As RECT,
   ByVal fuScroll As Integer) As Integer
    End Function

    Private Const SW_SCROLLCHILDREN As Integer = &H1   'すべての子ウインドウをスクロール

    '********1*********2*********3*********4*********5*********6*********7*********8
    '*: scX  : 水平方向の移動量 (Pixel)　負数の時は左に移動するから右側の画面が表示
    '*: scY  : 垂直方向の移動量 (Pixel)　負数の時は上に移動するから下側の画面が表示
    '*: 備考 :
    '********1*********2*********3*********4*********5*********6*********7*********8
    Private Sub ScrollWindow(ByVal hwnd As IntPtr, ByVal scX As Integer, ByVal scY As Integer)
        Dim rc As Integer
        Dim Rect1 As RECT, Update1 As Integer, Rect2 As RECT
        '第二引数は、水平方向の移動量　　第三引数は、垂直方向の移動量
        rc = ScrollWindowEx(hwnd, scX, scY, 0, Rect1,
                           Update1, Rect2, SW_SCROLLCHILDREN)
        Me.Refresh()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


    Const SRCCOPY As Integer = 13369376
    Const CAPTUREBLT As Integer = 1073741824

    <DllImport("user32.dll")>
    Private Shared Function GetDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("gdi32.dll")>
    Private Shared Function BitBlt(ByVal hDestDC As IntPtr,
        ByVal x As Integer, ByVal y As Integer,
        ByVal nWidth As Integer, ByVal nHeight As Integer,
        ByVal hSrcDC As IntPtr,
        ByVal xSrc As Integer, ByVal ySrc As Integer,
        ByVal dwRop As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function ReleaseDC(ByVal hwnd As IntPtr,
        ByVal hdc As IntPtr) As IntPtr
    End Function


    <DllImport("user32.dll")>
    Private Shared Function GetWindowDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function GetWindowRect(ByVal hwnd As IntPtr,
        ByRef lpRect As RECT) As Integer
    End Function


    <DllImport("gdi32.dll")>
    Private Shared Function GetCurrentObject(ByVal hdc As IntPtr, objecType As Short) As IntPtr
    End Function

    Public Shared Function CapturehWnd(hWnd As IntPtr) As Bitmap
        ' 指定ウィンドウハンドルの画像を取得
        Dim winDC As IntPtr = GetWindowDC(hWnd)
        'ウィンドウの大きさを取得
        Dim winRect As New RECT
        GetWindowRect(hWnd, winRect)
        'Bitmapの作成
        Dim bmp As New Bitmap(winRect.Right - winRect.Left,
            winRect.Bottom - winRect.Top)
        'Graphicsの作成
        Dim g As Graphics = Graphics.FromImage(bmp)
        'Graphicsのデバイスコンテキストを取得
        Dim hDC As IntPtr = g.GetHdc()
        'Bitmapに画像をコピーする
        BitBlt(hDC, 0, 0, bmp.Width, bmp.Height, winDC, 0, 0, SRCCOPY)
        '解放
        g.ReleaseHdc(hDC)
        g.Dispose()
        ReleaseDC(hWnd, winDC)

        Return bmp
    End Function




    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

        '上に移動のボタンの処理
        ScrollWindow(CType(Me.TextBox1.Text, IntPtr), 0, -60)  '(単位は、Pixel)


    End Sub



    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim bmp As Bitmap = CapturehWnd(CType(Me.TextBox1.Text, IntPtr))

        Me.PictureBox1.Image = bmp
    End Sub
End Class
