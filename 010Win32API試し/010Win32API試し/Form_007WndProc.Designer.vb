<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_007WndProc
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(12, 875)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(218, 30)
        Me.Button16.TabIndex = 25
        Me.Button16.Text = "スクロール"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Location = New System.Drawing.Point(12, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(332, 185)
        Me.Panel2.TabIndex = 26
        Me.Panel2.TabStop = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(92, 163)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(74, 66)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "スクロール"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form_007WndProc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(398, 441)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button16)
        Me.Name = "Form_007WndProc"
        Me.Text = "_001GetForeGroundWindow"
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button16 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button3 As Button
End Class
