Imports System.Runtime.InteropServices

Public Class User32

    <DllImport("user32.dll", CharSet:=CharSet.Auto, ExactSpelling:=False, SetLastError:=False)>
    Public Shared Function GetForegroundWindow() As IntPtr

    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.Winapi)>
    Public Shared Function SendMessage(hwnd As IntPtr, msg As Int32, wParam As IntPtr, lParam As IntPtr) As IntPtr

    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SetForegroundWindow(hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean

    End Function

    <DllImport("user32.dll")>
    Public Shared Sub SendInput(ByVal nInputs As Integer, ByRef pInputs As INPUT, ByVal cbsize As Integer)

    End Sub

    <DllImport("user32.dll")>
    Public Shared Function GetScrollPos(hWnd As IntPtr, <MarshalAs(UnmanagedType.I4)> nBar As SBOrientation) As Int16

    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function EnumChildWindows(ByVal hWndParent As System.IntPtr, ByVal lpEnumFunc As EnumWindowsProc, ByVal lParam As Integer) As Boolean
    End Function

    Public Delegate Function EnumWindowsProc(ByVal hWnd As IntPtr, ByRef lParam As IntPtr) As Boolean


    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function GetWindowLong(hWnd As IntPtr, <MarshalAs(UnmanagedType.I4)> nIndex As WindowLongFlags) As Integer
    End Function

    Public Enum WindowLongFlags As Integer
        GWL_EXSTYLE = -20
        GWLP_HINSTANCE = -6
        GWLP_HWNDPARENT = -8
        GWL_ID = -12
        GWL_STYLE = -16
        GWL_USERDATA = -21
        GWL_WNDPROC = -4
        DWLP_USER = &H8
        DWLP_MSGRESULT = &H0
        DWLP_DLGPROC = &H4
    End Enum

    Public Enum SBOrientation As Integer
        SB_HORZ = &H0
        SB_VERT = &H1
        SB_CTL = &H2
        SB_BOTH = &H3
    End Enum

    Public Const WS_VSCROLL As Integer = &H200000

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function GetScrollInfo(ByVal hWnd As IntPtr,
                                        ByVal nBar As Integer,
        <MarshalAs(UnmanagedType.Struct)> ByRef lpScrollInfo As SCROLLINFO) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential)> Public Structure SCROLLINFO

        Public cbSize As Integer

        Public fMask As Integer

        Public nMin As Integer

        Public nMax As Integer

        Public nPage As Integer

        Public nPos As Integer

        Public nTrackPos As Integer

    End Structure

    Public Enum ScrollInfoMask As Integer
        SIF_RANGE = &H1
        SIF_PAGE = &H2
        SIF_POS = &H4
        SIF_DISABLENOSCROLL = &H8
        SIF_TRACKPOS = &H10
        SIF_ALL = (SIF_RANGE Or SIF_PAGE Or SIF_POS Or SIF_TRACKPOS)
    End Enum


    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function WindowFromPoint(ByVal lpPoint As Point) As IntPtr

    End Function


    <Flags()>
    Public Enum KEYEVENTF As Integer
        KEYDOWN = 0
        EXTENDEDKEY = 1
        KEYUP = 2
        [UNICODE] = 4
        SCANCODE = 8
    End Enum

    Public Enum InputType As Integer
        Mouse = 0
        Keyboard = 1
        Hardware = 2
    End Enum

    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Public Structure KEYBDINPUT
        Public wVk As Int16
        Public wScan As Int16
        Public dwFlags As KEYEVENTF
        Public time As Int32
        Public dwExtraInfo As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Public Structure HARDWAREINPUT
        Public uMsg As Int32
        Public wParamL As Int16
        Public wParamH As Int16
    End Structure

    <StructLayout(LayoutKind.Explicit, Pack:=1)>
    Public Structure INPUT
        <FieldOffset(0)> Public dwType As InputType
        <FieldOffset(4)> Public mi As MOUSEINPUT
        <FieldOffset(4)> Public ki As KEYBDINPUT
        <FieldOffset(4)> Public hi As HARDWAREINPUT
    End Structure

    <Flags()>
    Public Enum MOUSEEVENTF As Integer
        MOVE = &H1
        LEFTDOWN = &H2
        LEFTUP = &H4
        RIGHTDOWN = &H8
        RIGHTUP = &H10
        MIDDLEDOWN = &H20
        MIDDLEUP = &H40
        XDOWN = &H80
        XUP = &H100
        VIRTUALDESK = &H400
        WHEEL = &H800
        ABSOLUTE = &H8000
    End Enum

    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Public Structure MOUSEINPUT
        Public dx As Int32
        Public dy As Int32
        Public mouseData As Int32
        Public dwFlags As MOUSEEVENTF
        Public time As Int32
        Public dwExtraInfo As IntPtr
    End Structure


    ''https://autohotkey.com/docs/misc/SendMessageList.htm
    Public Const WM_NULL As Int32 = &H00
    Public Const WM_CREATE As Int32 = &H01
    Public Const WM_DESTROY As Int32 = &H02
    Public Const WM_MOVE As Int32 = &H03
    Public Const WM_SIZE As Int32 = &H05
    Public Const WM_ACTIVATE As Int32 = &H06
    Public Const WM_SETFOCUS As Int32 = &H07
    Public Const WM_KILLFOCUS As Int32 = &H08
    Public Const WM_ENABLE As Int32 = &H0A
    Public Const WM_SETREDRAW As Int32 = &H0B
    Public Const WM_SETTEXT As Int32 = &H0C
    Public Const WM_GETTEXT As Int32 = &H0D
    Public Const WM_GETTEXTLENGTH As Int32 = &H0E
    Public Const WM_PAINT As Int32 = &H0F
    Public Const WM_CLOSE As Int32 = &H10
    Public Const WM_QUERYENDSESSION As Int32 = &H11
    Public Const WM_QUIT As Int32 = &H12
    Public Const WM_QUERYOPEN As Int32 = &H13
    Public Const WM_ERASEBKGND As Int32 = &H14
    Public Const WM_SYSCOLORCHANGE As Int32 = &H15
    Public Const WM_ENDSESSION As Int32 = &H16
    Public Const WM_SYSTEMERROR As Int32 = &H17
    Public Const WM_SHOWWINDOW As Int32 = &H18
    Public Const WM_CTLCOLOR As Int32 = &H19
    Public Const WM_WININICHANGE As Int32 = &H1A
    Public Const WM_SETTINGCHANGE As Int32 = &H1A
    Public Const WM_DEVMODECHANGE As Int32 = &H1B
    Public Const WM_ACTIVATEAPP As Int32 = &H1C
    Public Const WM_FONTCHANGE As Int32 = &H1D
    Public Const WM_TIMECHANGE As Int32 = &H1E
    Public Const WM_CANCELMODE As Int32 = &H1F
    Public Const WM_SETCURSOR As Int32 = &H20
    Public Const WM_MOUSEACTIVATE As Int32 = &H21
    Public Const WM_CHILDACTIVATE As Int32 = &H22
    Public Const WM_QUEUESYNC As Int32 = &H23
    Public Const WM_GETMINMAXINFO As Int32 = &H24
    Public Const WM_PAINTICON As Int32 = &H26
    Public Const WM_ICONERASEBKGND As Int32 = &H27
    Public Const WM_NEXTDLGCTL As Int32 = &H28
    Public Const WM_SPOOLERSTATUS As Int32 = &H2A
    Public Const WM_DRAWITEM As Int32 = &H2B
    Public Const WM_MEASUREITEM As Int32 = &H2C
    Public Const WM_DELETEITEM As Int32 = &H2D
    Public Const WM_VKEYTOITEM As Int32 = &H2E
    Public Const WM_CHARTOITEM As Int32 = &H2F
    Public Const WM_SETFONT As Int32 = &H30
    Public Const WM_GETFONT As Int32 = &H31
    Public Const WM_SETHOTKEY As Int32 = &H32
    Public Const WM_GETHOTKEY As Int32 = &H33
    Public Const WM_QUERYDRAGICON As Int32 = &H37
    Public Const WM_COMPAREITEM As Int32 = &H39
    Public Const WM_COMPACTING As Int32 = &H41
    Public Const WM_WINDOWPOSCHANGING As Int32 = &H46
    Public Const WM_WINDOWPOSCHANGED As Int32 = &H47
    Public Const WM_POWER As Int32 = &H48
    Public Const WM_COPYDATA As Int32 = &H4A
    Public Const WM_CANCELJOURNAL As Int32 = &H4B
    Public Const WM_NOTIFY As Int32 = &H4E
    Public Const WM_INPUTLANGCHANGEREQUEST As Int32 = &H50
    Public Const WM_INPUTLANGCHANGE As Int32 = &H51
    Public Const WM_TCARD As Int32 = &H52
    Public Const WM_HELP As Int32 = &H53
    Public Const WM_USERCHANGED As Int32 = &H54
    Public Const WM_NOTIFYFORMAT As Int32 = &H55
    Public Const WM_CONTEXTMENU As Int32 = &H7B
    Public Const WM_STYLECHANGING As Int32 = &H7C
    Public Const WM_STYLECHANGED As Int32 = &H7D
    Public Const WM_DISPLAYCHANGE As Int32 = &H7E
    Public Const WM_GETICON As Int32 = &H7F
    Public Const WM_SETICON As Int32 = &H80
    Public Const WM_NCCREATE As Int32 = &H81
    Public Const WM_NCDESTROY As Int32 = &H82
    Public Const WM_NCCALCSIZE As Int32 = &H83
    Public Const WM_NCHITTEST As Int32 = &H84
    Public Const WM_NCPAINT As Int32 = &H85
    Public Const WM_NCACTIVATE As Int32 = &H86
    Public Const WM_GETDLGCODE As Int32 = &H87
    Public Const WM_NCMOUSEMOVE As Int32 = &HA0
    Public Const WM_NCLBUTTONDOWN As Int32 = &HA1
    Public Const WM_NCLBUTTONUP As Int32 = &HA2
    Public Const WM_NCLBUTTONDBLCLK As Int32 = &HA3
    Public Const WM_NCRBUTTONDOWN As Int32 = &HA4
    Public Const WM_NCRBUTTONUP As Int32 = &HA5
    Public Const WM_NCRBUTTONDBLCLK As Int32 = &HA6
    Public Const WM_NCMBUTTONDOWN As Int32 = &HA7
    Public Const WM_NCMBUTTONUP As Int32 = &HA8
    Public Const WM_NCMBUTTONDBLCLK As Int32 = &HA9
    Public Const WM_KEYFIRST As Int32 = &H100
    Public Const WM_KEYDOWN As Int32 = &H100
    Public Const WM_KEYUP As Int32 = &H101
    Public Const WM_CHAR As Int32 = &H102
    Public Const WM_DEADCHAR As Int32 = &H103
    Public Const WM_SYSKEYDOWN As Int32 = &H104
    Public Const WM_SYSKEYUP As Int32 = &H105
    Public Const WM_SYSCHAR As Int32 = &H106
    Public Const WM_SYSDEADCHAR As Int32 = &H107
    Public Const WM_KEYLAST As Int32 = &H108
    Public Const WM_IME_STARTCOMPOSITION As Int32 = &H10D
    Public Const WM_IME_ENDCOMPOSITION As Int32 = &H10E
    Public Const WM_IME_COMPOSITION As Int32 = &H10F
    Public Const WM_IME_KEYLAST As Int32 = &H10F
    Public Const WM_INITDIALOG As Int32 = &H110
    Public Const WM_COMMAND As Int32 = &H111
    Public Const WM_SYSCOMMAND As Int32 = &H112
    Public Const WM_TIMER As Int32 = &H113
    Public Const WM_HSCROLL As Int32 = &H114
    Public Const WM_VSCROLL As Int32 = &H115
    Public Const WM_INITMENU As Int32 = &H116
    Public Const WM_INITMENUPOPUP As Int32 = &H117
    Public Const WM_MENUSELECT As Int32 = &H11F
    Public Const WM_MENUCHAR As Int32 = &H120
    Public Const WM_ENTERIDLE As Int32 = &H121
    Public Const WM_CTLCOLORMSGBOX As Int32 = &H132
    Public Const WM_CTLCOLOREDIT As Int32 = &H133
    Public Const WM_CTLCOLORLISTBOX As Int32 = &H134
    Public Const WM_CTLCOLORBTN As Int32 = &H135
    Public Const WM_CTLCOLORDLG As Int32 = &H136
    Public Const WM_CTLCOLORSCROLLBAR As Int32 = &H137
    Public Const WM_CTLCOLORSTATIC As Int32 = &H138
    Public Const WM_MOUSEFIRST As Int32 = &H200
    Public Const WM_MOUSEMOVE As Int32 = &H200
    Public Const WM_LBUTTONDOWN As Int32 = &H201
    Public Const WM_LBUTTONUP As Int32 = &H202
    Public Const WM_LBUTTONDBLCLK As Int32 = &H203
    Public Const WM_RBUTTONDOWN As Int32 = &H204
    Public Const WM_RBUTTONUP As Int32 = &H205
    Public Const WM_RBUTTONDBLCLK As Int32 = &H206
    Public Const WM_MBUTTONDOWN As Int32 = &H207
    Public Const WM_MBUTTONUP As Int32 = &H208
    Public Const WM_MBUTTONDBLCLK As Int32 = &H209
    Public Const WM_MOUSEWHEEL As Int32 = &H20A
    Public Const WM_MOUSEHWHEEL As Int32 = &H20E
    Public Const WM_PARENTNOTIFY As Int32 = &H210
    Public Const WM_ENTERMENULOOP As Int32 = &H211
    Public Const WM_EXITMENULOOP As Int32 = &H212
    Public Const WM_NEXTMENU As Int32 = &H213
    Public Const WM_SIZING As Int32 = &H214
    Public Const WM_CAPTURECHANGED As Int32 = &H215
    Public Const WM_MOVING As Int32 = &H216
    Public Const WM_POWERBROADCAST As Int32 = &H218
    Public Const WM_DEVICECHANGE As Int32 = &H219
    Public Const WM_MDICREATE As Int32 = &H220
    Public Const WM_MDIDESTROY As Int32 = &H221
    Public Const WM_MDIACTIVATE As Int32 = &H222
    Public Const WM_MDIRESTORE As Int32 = &H223
    Public Const WM_MDINEXT As Int32 = &H224
    Public Const WM_MDIMAXIMIZE As Int32 = &H225
    Public Const WM_MDITILE As Int32 = &H226
    Public Const WM_MDICASCADE As Int32 = &H227
    Public Const WM_MDIICONARRANGE As Int32 = &H228
    Public Const WM_MDIGETACTIVE As Int32 = &H229
    Public Const WM_MDISETMENU As Int32 = &H230
    Public Const WM_ENTERSIZEMOVE As Int32 = &H231
    Public Const WM_EXITSIZEMOVE As Int32 = &H232
    Public Const WM_DROPFILES As Int32 = &H233
    Public Const WM_MDIREFRESHMENU As Int32 = &H234
    Public Const WM_IME_SETCONTEXT As Int32 = &H281
    Public Const WM_IME_NOTIFY As Int32 = &H282
    Public Const WM_IME_CONTROL As Int32 = &H283
    Public Const WM_IME_COMPOSITIONFULL As Int32 = &H284
    Public Const WM_IME_SELECT As Int32 = &H285
    Public Const WM_IME_CHAR As Int32 = &H286
    Public Const WM_IME_KEYDOWN As Int32 = &H290
    Public Const WM_IME_KEYUP As Int32 = &H291
    Public Const WM_MOUSEHOVER As Int32 = &H2A1
    Public Const WM_NCMOUSELEAVE As Int32 = &H2A2
    Public Const WM_MOUSELEAVE As Int32 = &H2A3
    Public Const WM_CUT As Int32 = &H300
    Public Const WM_COPY As Int32 = &H301
    Public Const WM_PASTE As Int32 = &H302
    Public Const WM_CLEAR As Int32 = &H303
    Public Const WM_UNDO As Int32 = &H304
    Public Const WM_RENDERFORMAT As Int32 = &H305
    Public Const WM_RENDERALLFORMATS As Int32 = &H306
    Public Const WM_DESTROYCLIPBOARD As Int32 = &H307
    Public Const WM_DRAWCLIPBOARD As Int32 = &H308
    Public Const WM_PAINTCLIPBOARD As Int32 = &H309
    Public Const WM_VSCROLLCLIPBOARD As Int32 = &H30A
    Public Const WM_SIZECLIPBOARD As Int32 = &H30B
    Public Const WM_ASKCBFORMATNAME As Int32 = &H30C
    Public Const WM_CHANGECBCHAIN As Int32 = &H30D
    Public Const WM_HSCROLLCLIPBOARD As Int32 = &H30E
    Public Const WM_QUERYNEWPALETTE As Int32 = &H30F
    Public Const WM_PALETTEISCHANGING As Int32 = &H310
    Public Const WM_PALETTECHANGED As Int32 = &H311
    Public Const WM_HOTKEY As Int32 = &H312
    Public Const WM_PRINT As Int32 = &H317
    Public Const WM_PRINTCLIENT As Int32 = &H318
    Public Const WM_HANDHELDFIRST As Int32 = &H358
    Public Const WM_HANDHELDLAST As Int32 = &H35F
    Public Const WM_PENWINFIRST As Int32 = &H380
    Public Const WM_PENWINLAST As Int32 = &H38F
    Public Const WM_COALESCE_FIRST As Int32 = &H390
    Public Const WM_COALESCE_LAST As Int32 = &H39F
    Public Const WM_DDE_FIRST As Int32 = &H3E0
    Public Const WM_DDE_INITIATE As Int32 = &H3E0
    Public Const WM_DDE_TERMINATE As Int32 = &H3E1
    Public Const WM_DDE_ADVISE As Int32 = &H3E2
    Public Const WM_DDE_UNADVISE As Int32 = &H3E3
    Public Const WM_DDE_ACK As Int32 = &H3E4
    Public Const WM_DDE_DATA As Int32 = &H3E5
    Public Const WM_DDE_REQUEST As Int32 = &H3E6
    Public Const WM_DDE_POKE As Int32 = &H3E7
    Public Const WM_DDE_EXECUTE As Int32 = &H3E8
    Public Const WM_DDE_LAST As Int32 = &H3E8
    Public Const WM_USER As Int32 = &H400
    Public Const WM_APP As Int32 = &H8000


    <StructLayout(LayoutKind.Sequential)>
    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As IntPtr

    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function SetCursorPos(x As Integer, y As Integer) As Integer

    End Function

    <DllImport("user32.dll")>
    Public Shared Function GetScrollRange(ByVal hWnd As IntPtr, ByVal nBar As Integer, ByRef lpMinPos As Integer, ByRef lpMaxPos As Integer) As Boolean
    End Function

    Public Const SRCCOPY As Integer = 13369376
    Public Const CAPTUREBLT As Integer = 1073741824

    <DllImport("user32.dll")>
    Public Shared Function GetDC(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("gdi32.dll")>
    Public Shared Function BitBlt(ByVal hDestDC As IntPtr,
        ByVal x As Integer, ByVal y As Integer,
        ByVal nWidth As Integer, ByVal nHeight As Integer,
        ByVal hSrcDC As IntPtr,
        ByVal xSrc As Integer, ByVal ySrc As Integer,
        ByVal dwRop As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Public Shared Function ReleaseDC(ByVal hWnd As IntPtr,
        ByVal hdc As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Shared Function GetWindowDC(ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Shared Function GetWindow(ByVal hWnd As IntPtr, ByVal uCmd As UInt32) As IntPtr
    End Function

    Public Enum GetWindow_Cmd As UInt32
        GW_HWNDFIRST = 0
        GW_HWNDLAST = 1
        GW_HWNDNEXT = 2
        GW_HWNDPREV = 3
        GW_OWNER = 4
        GW_CHILD = 5
        GW_ENABLEDPOPUP = 6
    End Enum

    <DllImport("user32.dll", ExactSpelling:=True)>
    Public Shared Function GetAncestor(ByVal hwnd As IntPtr, ByVal gaFlags As GetAncestor_Flags) As IntPtr
    End Function

    <Flags()>
    Public Enum GetAncestor_Flags As Integer
        GetParent = 1
        GetRoot = 2
        GetRootOwner = 3
    End Enum

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function GetWindowInfo(ByVal hwnd As IntPtr, ByRef pwi As WINDOWINFO) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Public Structure WINDOWINFO
        Dim cbSize As Integer
        Dim rcWindow As RECT
        Dim rcClient As RECT
        Dim dwStyle As Integer
        Dim dwExStyle As Integer
        Dim dwWindowStatus As UInt32
        Dim cxWindowBorders As UInt32
        Dim cyWindowBorders As UInt32
        Dim atomWindowType As UInt16
        Dim wCreatorVersion As Short
    End Structure


    '<DllImport("user32.dll")>
    'Public Shared Function CallWindowProc(lpPrevWndFunc As WndProcDelegate, hWnd As IntPtr, Msg As UInteger, wParam As IntPtr, lParam As IntPtr) As IntPtr
    'End Function

    Public Delegate Function WndProcDelegate(ByVal hWnd As IntPtr, ByVal msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr


    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function GetClientRect(ByVal hWnd As System.IntPtr,
   ByRef lpRECT As RECT) As Integer
        ' Leave function empty     
    End Function


    ''' <summary>
    ''' Changes an attribute of the specified window. The function also sets the 32-bit (long) value at the specified offset into the extra window memory.
    ''' </summary>
    ''' <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs..</param>
    ''' <param name="nIndex">The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer. To set any other value, specify one of the following values: GWL_EXSTYLE, GWL_HINSTANCE, GWL_ID, GWL_STYLE, GWL_USERDATA, GWL_WNDPROC </param>
    ''' <param name="dwNewLong">The replacement value.</param>
    ''' <returns>If the function succeeds, the return value is the previous value of the specified 32-bit integer. 
    ''' If the function fails, the return value is zero. To get extended error information, call GetLastError. </returns>
    <DllImport("user32.dll")>
    Public Shared Function SetWindowLong(hWnd As IntPtr,
         <MarshalAs(UnmanagedType.I4)> nIndex As WindowLongFlags,
         dwNewLong As IntPtr) As Integer
    End Function

    Public Declare Function SetWindowLong _
    Lib "user32.dll" Alias "SetWindowLongA" (
        ByVal hWnd As IntPtr,
        ByVal nIndex As Int32,
        ByVal dwNewLong As IntPtr) As Int32

    Public Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" _
    (ByVal lpPrevWndFunc As IntPtr, ByVal hWnd As IntPtr, ByVal msg As Integer,
     ByVal wParam As Integer, ByVal lParam As Integer) As Integer


    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)>
    Public Structure TEXTMETRIC
        Public tmHeight As Integer
        Public tmAscent As Integer
        Public tmDescent As Integer
        Public tmInternalLeading As Integer
        Public tmExternalLeading As Integer
        Public tmAveCharWidth As Integer
        Public tmMaxCharWidth As Integer
        Public tmWeight As Integer
        Public tmOverhang As Integer
        Public tmDigitizedAspectX As Integer
        Public tmDigitizedAspectY As Integer
        <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=1)>
        Public tmFirstChar As String
        <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=1)>
        Public tmLastChar As String
        <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=1)>
        Public tmDefaultChar As String
        <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=1)>
        Public tmBreakChar As String
        Public tmItalic As Byte
        Public tmUnderlined As Byte
        Public tmStruckOut As Byte
        Public tmPitchAndFamily As Byte
        Public tmCharSet As Byte
    End Structure

    <DllImport("gdi32.dll")>
    Public Shared Function GetTextMetrics(ByVal hdc As IntPtr, ByRef lptm As TEXTMETRIC) As Integer

    End Function

    Public Declare Function GetOutlineTextMetricsA Lib "gdi32" (
     ByVal hdc As IntPtr,
     ByVal cbData As Integer,
     ByVal lpOtm As IntPtr
     ) As Integer

    Public Declare Function SelectObject Lib "gdi32" (
     ByVal hdc As IntPtr,
     ByVal hObj As IntPtr
     ) As IntPtr

End Class
