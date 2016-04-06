
Imports System.Runtime.InteropServices
Public Delegate Function CallBack(
    ByVal nCode As Integer,
    ByVal wParam As IntPtr,
    ByVal lParam As IntPtr) As Integer

Public Class Form_004SetWindowsHookEx
    'Declare the mouse hook constant.
    'For other hook types, obtain these values from Winuser.h in Microsoft SDK.
    Dim WH_MOUSE As Integer = 7
    Shared hHook As Integer = 0

    'Keep the reference so that the delegate is not garbage collected.
    Private hookproc As CallBack

    'Import for the SetWindowsHookEx function.
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Overloads Shared Function SetWindowsHookEx _
          (ByVal idHook As Integer, ByVal HookProc As CallBack,
           ByVal hInstance As IntPtr, ByVal wParam As Integer) As Integer
    End Function

    'Import for the CallNextHookEx function.
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Overloads Shared Function CallNextHookEx _
          (ByVal idHook As Integer, ByVal nCode As Integer,
           ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function
    'Import for the UnhookWindowsHookEx function.
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Overloads Shared Function UnhookWindowsHookEx _
              (ByVal idHook As Integer) As Boolean
    End Function

    'Point structure declaration.
    <StructLayout(LayoutKind.Sequential)> Public Structure Point
        Public x As Integer
        Public y As Integer
    End Structure

    'MouseHookStruct structure declaration.
    <StructLayout(LayoutKind.Sequential)> Public Structure MouseHookStruct
        Public pt As Point
        Public hwnd As Integer
        Public wHitTestCode As Integer
        Public dwExtraInfo As Integer
    End Structure

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If hHook.Equals(0) Then
            hookproc = AddressOf MouseHookProc
            hHook = SetWindowsHookEx(WH_MOUSE,
                                     hookproc,
                                     IntPtr.Zero,
AppDomain.CurrentDomain.GetCurrentThreadId())
            If hHook.Equals(0) Then
                MsgBox("SetWindowsHookEx Failed")
                Return
            Else
                Button1.Text = "UnHook Windows Hook"
            End If
        Else
            Dim ret As Boolean = UnhookWindowsHookEx(hHook)

            If ret.Equals(False) Then
                MsgBox("UnhookWindowsHookEx Failed")
                Return
            Else
                hHook = 0
                Button1.Text = "Set Windows Hook"
                Me.Text = "Mouse Hook"
            End If
        End If

    End Sub

    Public Shared Function MouseHookProc(
   ByVal nCode As Integer,
   ByVal wParam As IntPtr,
   ByVal lParam As IntPtr) As Integer
        Dim MyMouseHookStruct As New MouseHookStruct()

        Dim ret As Integer

        If (nCode < 0) Then
            Return CallNextHookEx(hHook, nCode, wParam, lParam)
        End If

        MyMouseHookStruct = CType(Marshal.PtrToStructure(lParam, MyMouseHookStruct.GetType()), MouseHookStruct)

        Dim tempForm As Form
        tempForm = Form.ActiveForm()

        Dim strCaption As String
        strCaption = "x = " & MyMouseHookStruct.pt.x & " y = " & MyMouseHookStruct.pt.y

        tempForm.Text = strCaption
        Return CallNextHookEx(hHook, nCode, wParam, lParam)

    End Function
End Class