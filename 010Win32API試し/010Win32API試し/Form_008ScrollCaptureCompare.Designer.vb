<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_008ScrollCaptureCompare
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
        Me.btnCapture = New System.Windows.Forms.Button()
        Me.lblDragAndDrop = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCapturehWnd = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRoothWnd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtScrollhWnd = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'btnCapture
        '
        Me.btnCapture.Location = New System.Drawing.Point(655, 12)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(127, 63)
        Me.btnCapture.TabIndex = 8
        Me.btnCapture.Text = "キャプチャ"
        Me.btnCapture.UseVisualStyleBackColor = True
        '
        'lblDragAndDrop
        '
        Me.lblDragAndDrop.AutoSize = True
        Me.lblDragAndDrop.Font = New System.Drawing.Font("MS UI Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblDragAndDrop.Location = New System.Drawing.Point(12, 15)
        Me.lblDragAndDrop.Name = "lblDragAndDrop"
        Me.lblDragAndDrop.Size = New System.Drawing.Size(34, 24)
        Me.lblDragAndDrop.TabIndex = 10
        Me.lblDragAndDrop.Text = "●"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 98)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(787, 167)
        Me.Panel1.TabIndex = 20
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(228, 146)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(49, 9)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(229, 19)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "キャプチャするハンドル"
        '
        'txtCapturehWnd
        '
        Me.txtCapturehWnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtCapturehWnd.Location = New System.Drawing.Point(301, 6)
        Me.txtCapturehWnd.Margin = New System.Windows.Forms.Padding(0)
        Me.txtCapturehWnd.Name = "txtCapturehWnd"
        Me.txtCapturehWnd.Size = New System.Drawing.Size(139, 25)
        Me.txtCapturehWnd.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(49, 34)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(249, 19)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "ルートウィンドウハンドル"
        '
        'txtRoothWnd
        '
        Me.txtRoothWnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtRoothWnd.Location = New System.Drawing.Point(301, 34)
        Me.txtRoothWnd.Margin = New System.Windows.Forms.Padding(0)
        Me.txtRoothWnd.Name = "txtRoothWnd"
        Me.txtRoothWnd.Size = New System.Drawing.Size(139, 25)
        Me.txtRoothWnd.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 63)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 19)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "スクロールハンドル"
        '
        'txtScrollhWnd
        '
        Me.txtScrollhWnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtScrollhWnd.Location = New System.Drawing.Point(301, 60)
        Me.txtScrollhWnd.Margin = New System.Windows.Forms.Padding(0)
        Me.txtScrollhWnd.Name = "txtScrollhWnd"
        Me.txtScrollhWnd.Size = New System.Drawing.Size(139, 25)
        Me.txtScrollhWnd.TabIndex = 27
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Location = New System.Drawing.Point(12, 271)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(787, 167)
        Me.Panel2.TabIndex = 21
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(228, 146)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 19
        Me.PictureBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(455, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 63)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "キャプチャ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(546, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 63)
        Me.Button2.TabIndex = 29
        Me.Button2.Text = "比較"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form_008ScrollCaptureCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 441)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtScrollhWnd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblDragAndDrop)
        Me.Controls.Add(Me.btnCapture)
        Me.Controls.Add(Me.txtRoothWnd)
        Me.Controls.Add(Me.txtCapturehWnd)
        Me.Name = "Form_008ScrollCaptureCompare"
        Me.Text = "_001GetForeGroundWindow"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnCapture As Button
    Friend WithEvents lblDragAndDrop As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCapturehWnd As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRoothWnd As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtScrollhWnd As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
