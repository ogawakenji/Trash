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

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

        ' 1000ミリ秒スリープ
        System.Threading.Thread.Sleep(1000)

        Dim hWnd As IntPtr = CType(Me.TextBox1.Text, IntPtr)
        SetForegroundWindow(hWnd)

        ' 1000ミリ秒スリープ
        System.Threading.Thread.Sleep(1000)

        '' マウスホイール
        MouseScroll()


    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim form As New Form2
        form.Show()
    End Sub


    '' ========================================================================================================================


    ' マウスイベント(mouse_eventの引数と同様のデータ)
    <StructLayout(LayoutKind.Sequential)>
    Private Structure MOUSEINPUT
        Public dx As Integer
        Public dy As Integer
        Public mouseData As Integer
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

    ' キーボードイベント(keybd_eventの引数と同様のデータ)
    <StructLayout(LayoutKind.Sequential)>
    Private Structure KEYBDINPUT
        Public wVk As Short
        Public wScan As Short
        Public dwFlags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure

    ' ハードウェアイベント
    <StructLayout(LayoutKind.Sequential)>
    Private Structure HARDWAREINPUT
        Public uMsg As Integer
        Public wParamL As Short
        Public wParamH As Short
    End Structure

    ' 各種イベント(SendInputの引数データ)
    <StructLayout(LayoutKind.Explicit)>
    Private Structure INPUT
        <FieldOffset(0)> Public type As Integer
        <FieldOffset(4)> Public mi As MOUSEINPUT
        <FieldOffset(4)> Public ki As KEYBDINPUT
        <FieldOffset(4)> Public hi As HARDWAREINPUT
    End Structure

    ' キー操作、マウス操作をシミュレート(擬似的に操作する)
    <DllImport("user32.dll")>
    Private Shared Sub SendInput(
        ByVal nInputs As Integer, ByRef pInputs As INPUT, ByVal cbsize As Integer)
    End Sub

    ' 仮想キーコードをスキャンコードに変換
    <DllImport("user32.dll", EntryPoint:="MapVirtualKeyA")>
    Private Shared Function MapVirtualKey(
        ByVal wCode As Integer, ByVal wMapType As Integer) As Integer
    End Function

    Private Const INPUT_MOUSE = 0                   ' マウスイベント
    Private Const INPUT_KEYBOARD = 1                ' キーボードイベント
    Private Const INPUT_HARDWARE = 2                ' ハードウェアイベント

    Private Const MOUSEEVENTF_MOVE = &H1            ' マウスを移動する
    Private Const MOUSEEVENTF_ABSOLUTE = &H8000     ' 絶対座標指定
    Private Const MOUSEEVENTF_LEFTDOWN = &H2        ' 左　ボタンを押す
    Private Const MOUSEEVENTF_LEFTUP = &H4          ' 左　ボタンを離す
    Private Const MOUSEEVENTF_RIGHTDOWN = &H8       ' 右　ボタンを押す
    Private Const MOUSEEVENTF_RIGHTUP = &H10        ' 右　ボタンを離す
    Private Const MOUSEEVENTF_MIDDLEDOWN = &H20     ' 中央ボタンを押す
    Private Const MOUSEEVENTF_MIDDLEUP = &H40       ' 中央ボタンを離す
    Private Const MOUSEEVENTF_WHEEL = &H800         ' ホイールを回転する
    Private Const WHEEL_DELTA = 120                 ' ホイール回転値

    Private Const KEYEVENTF_KEYDOWN = &H0           ' キーを押す
    Private Const KEYEVENTF_KEYUP = &H2             ' キーを離す
    Private Const KEYEVENTF_EXTENDEDKEY = &H1       ' 拡張コード
    Private Const VK_SHIFT = &H10                   ' SHIFTキー


    Private Sub MouseScroll()

        ' マウス操作実行用のデータ
        Const num As Integer = 2
        Dim inp As INPUT() = New INPUT(num - 1) {}

        ' (1)マウスカーソルを移動する(スクリーン座標でX座標=800ピクセル,Y=400ピクセルの位置)
        inp(0).type = INPUT_MOUSE
        inp(0).mi.dwFlags = MOUSEEVENTF_MOVE Or MOUSEEVENTF_ABSOLUTE
        inp(0).mi.dx = CInt(800 * (65535 / Screen.PrimaryScreen.Bounds.Width))
        inp(0).mi.dy = CInt(400 * (65535 / Screen.PrimaryScreen.Bounds.Height))
        inp(0).mi.mouseData = 0
        inp(0).mi.dwExtraInfo = 0
        inp(0).mi.time = 0

        ' (1)マウスホイールを前方(近づく方向)へ回転する
        inp(1).type = INPUT_MOUSE
        inp(1).mi.dwFlags = MOUSEEVENTF_WHEEL
        inp(1).mi.dx = 0
        inp(1).mi.dy = 0
        inp(1).mi.mouseData = -1 * WHEEL_DELTA * 10
        inp(1).mi.dwExtraInfo = 0
        inp(1).mi.time = 0

        ' マウス操作実行
        SendInput(num, inp(0), Marshal.SizeOf(inp(0)))

        ' 1000ミリ秒スリープ
        System.Threading.Thread.Sleep(1000)

        ' マウス操作実行用のデータ
        Const nu2 As Integer = 1
        Dim in2 As INPUT() = New INPUT(num - 1) {}

        ' (1)マウスホイールを後方(離れる方向)へ回転する
        in2(0).type = INPUT_MOUSE
        in2(0).mi.dwFlags = MOUSEEVENTF_WHEEL
        in2(0).mi.dx = 0
        in2(0).mi.dy = 0
        in2(0).mi.mouseData = +1 * WHEEL_DELTA * 10
        in2(0).mi.dwExtraInfo = 0
        in2(0).mi.time = 0

        ' マウス操作実行
        SendInput(nu2, in2(0), Marshal.SizeOf(in2(0)))

        ' 1000ミリ秒スリープ
        System.Threading.Thread.Sleep(1000)



    End Sub


End Class
