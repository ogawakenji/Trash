<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_005EnumChildWindows
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.lblScreen = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(528, 82)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "https://msdn.microsoft.com/ja-jp/library/cc411004.aspx" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "キーストローク、マウスの動き、ボタンのクリックなど" &
    "を合成します。"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 100)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 30)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "タイマースタート"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("ＭＳ ゴシック", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(16, 170)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(524, 30)
        Me.TextBox2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ ゴシック", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(394, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "作業しているウィンドウのハンドル"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(145, 100)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(127, 30)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "タイマーストップ"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(712, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(218, 30)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "EnumChildWindows"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(712, 48)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(317, 196)
        Me.DataGridView1.TabIndex = 7
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(712, 250)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(152, 30)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "GetWindowLong"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Location = New System.Drawing.Point(712, 286)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(152, 30)
        Me.Button5.TabIndex = 9
        Me.Button5.Text = "明細SendMessage"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(290, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 24)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "●"
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Location = New System.Drawing.Point(712, 322)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(152, 30)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "TextSendMessage"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.Location = New System.Drawing.Point(712, 358)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(152, 30)
        Me.Button7.TabIndex = 12
        Me.Button7.Text = "GetWindowLong"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'lblScreen
        '
        Me.lblScreen.AutoSize = True
        Me.lblScreen.Location = New System.Drawing.Point(336, 108)
        Me.lblScreen.Name = "lblScreen"
        Me.lblScreen.Size = New System.Drawing.Size(90, 15)
        Me.lblScreen.TabIndex = 13
        Me.lblScreen.Text = "スクリーン座標"
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.Location = New System.Drawing.Point(712, 394)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(152, 30)
        Me.Button8.TabIndex = 14
        Me.Button8.Text = "GetWindowRect"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(445, 100)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(100, 50)
        Me.RichTextBox1.TabIndex = 15
        Me.RichTextBox1.Text = "1" & Global.Microsoft.VisualBasic.ChrW(10) & "2" & Global.Microsoft.VisualBasic.ChrW(10) & "3" & Global.Microsoft.VisualBasic.ChrW(10) & "4" & Global.Microsoft.VisualBasic.ChrW(10) & "5" & Global.Microsoft.VisualBasic.ChrW(10) & "6"
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button9.Location = New System.Drawing.Point(870, 250)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(152, 30)
        Me.Button9.TabIndex = 16
        Me.Button9.Text = "GetScrollInfo"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button10.Location = New System.Drawing.Point(870, 286)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(152, 30)
        Me.Button10.TabIndex = 17
        Me.Button10.Text = "SetCursorPos"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button11.Location = New System.Drawing.Point(870, 321)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(69, 30)
        Me.Button11.TabIndex = 19
        Me.Button11.Text = "BitBlt"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 211)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(694, 218)
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
        'Button12
        '
        Me.Button12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button12.Location = New System.Drawing.Point(945, 321)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(77, 30)
        Me.Button12.TabIndex = 21
        Me.Button12.Text = "BitBlt2"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button13.Location = New System.Drawing.Point(870, 357)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(152, 30)
        Me.Button13.TabIndex = 22
        Me.Button13.Text = "GetWindow"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button14.Location = New System.Drawing.Point(870, 393)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(152, 30)
        Me.Button14.TabIndex = 23
        Me.Button14.Text = "GetAncestor"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button15.Location = New System.Drawing.Point(1028, 250)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(74, 66)
        Me.Button15.TabIndex = 24
        Me.Button15.Text = "GetWindowInfo"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Form_005EnumChildWindows
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1114, 441)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.lblScreen)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form_005EnumChildWindows"
        Me.Text = "_001GetForeGroundWindow"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents lblScreen As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
End Class
