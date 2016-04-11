<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_006PDFScrollCapture
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
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'btnCapture
        '
        Me.btnCapture.Location = New System.Drawing.Point(525, 12)
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
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 345)
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
        Me.Label3.Font = New System.Drawing.Font("ＭＳ ゴシック", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(64, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(274, 24)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "キャプチャするハンドル"
        '
        'txtCapturehWnd
        '
        Me.txtCapturehWnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtCapturehWnd.Location = New System.Drawing.Point(381, 12)
        Me.txtCapturehWnd.Name = "txtCapturehWnd"
        Me.txtCapturehWnd.Size = New System.Drawing.Size(139, 30)
        Me.txtCapturehWnd.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("ＭＳ ゴシック", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(64, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(298, 24)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "ルートウィンドウハンドル"
        '
        'txtRoothWnd
        '
        Me.txtRoothWnd.Font = New System.Drawing.Font("ＭＳ ゴシック", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtRoothWnd.Location = New System.Drawing.Point(381, 48)
        Me.txtRoothWnd.Name = "txtRoothWnd"
        Me.txtRoothWnd.Size = New System.Drawing.Size(139, 30)
        Me.txtRoothWnd.TabIndex = 3
        '
        'Form_006PDFScrollCapture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 441)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblDragAndDrop)
        Me.Controls.Add(Me.btnCapture)
        Me.Controls.Add(Me.txtRoothWnd)
        Me.Controls.Add(Me.txtCapturehWnd)
        Me.Name = "Form_006PDFScrollCapture"
        Me.Text = "_001GetForeGroundWindow"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
