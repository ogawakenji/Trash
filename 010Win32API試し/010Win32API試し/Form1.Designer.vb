<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblGetForeGroundWindow = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblGetForeGroundWindow
        '
        Me.lblGetForeGroundWindow.Font = New System.Drawing.Font("ＭＳ ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblGetForeGroundWindow.Location = New System.Drawing.Point(12, 9)
        Me.lblGetForeGroundWindow.Name = "lblGetForeGroundWindow"
        Me.lblGetForeGroundWindow.Size = New System.Drawing.Size(222, 25)
        Me.lblGetForeGroundWindow.TabIndex = 0
        Me.lblGetForeGroundWindow.Text = "GetForeGroundWindow"
        Me.lblGetForeGroundWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1210, 517)
        Me.Controls.Add(Me.lblGetForeGroundWindow)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblGetForeGroundWindow As Label
End Class
