Option Strict On

Imports System.Windows.Forms
Imports System.Security.Permissions

Public Class BaseTextBox : Inherits System.Windows.Forms.TextBox

    Public Sub New()
        MyBase.New()
    End Sub

    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)>
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_CHAR As Integer = &H0102
        Const WM_PASTE As Integer = &H0302

        Select Case m.Msg
            Case WM_CHAR
                Dim eKeyPress As New KeyPressEventArgs(Microsoft.VisualBasic.ChrW(m.WParam.ToInt32()))
                Me.OnChar(eKeyPress)

                If eKeyPress.Handled Then
                    Return
                End If

            Case WM_PASTE
                Me.OnPaste(New System.EventArgs())
                Return

        End Select

        MyBase.WndProc(m)
    End Sub


    Protected Overridable Sub OnChar(ByVal e As KeyPressEventArgs)
        Debug.WriteLine("OnChar")


    End Sub

    Protected Overridable Sub OnPaste(ByVal e As System.EventArgs)
        Debug.WriteLine("OnPaste")

        Dim clipboardString As String = Clipboard.GetDataObject().GetData(System.Windows.Forms.DataFormats.Text).ToString()
        If Not clipboardString Is Nothing Then
            Me.SelectedText = clipboardString
        End If

    End Sub

End Class
