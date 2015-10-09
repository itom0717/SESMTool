<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
    Me.CloseButton = New System.Windows.Forms.Button()
    Me.ModIDListBox = New System.Windows.Forms.ListBox()
    Me.ModIDLabel = New System.Windows.Forms.Label()
    Me.GetModButton = New System.Windows.Forms.Button()
    Me.SetModButton = New System.Windows.Forms.Button()
    Me.LoadModButton = New System.Windows.Forms.Button()
    Me.SaveModButton = New System.Windows.Forms.Button()
    Me.SessionNameLabel = New System.Windows.Forms.Label()
    Me.SessionNameTextBox = New System.Windows.Forms.TextBox()
    Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
    Me.NewModIDListBox = New System.Windows.Forms.ListBox()
    Me.NewModIDLabel = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'CloseButton
    '
    Me.CloseButton.Location = New System.Drawing.Point(345, 335)
    Me.CloseButton.Name = "CloseButton"
    Me.CloseButton.Size = New System.Drawing.Size(61, 26)
    Me.CloseButton.TabIndex = 0
    Me.CloseButton.Text = "閉じる"
    Me.CloseButton.UseVisualStyleBackColor = True
    '
    'ModIDListBox
    '
    Me.ModIDListBox.FormattingEnabled = True
    Me.ModIDListBox.ItemHeight = 12
    Me.ModIDListBox.Location = New System.Drawing.Point(16, 100)
    Me.ModIDListBox.Name = "ModIDListBox"
    Me.ModIDListBox.Size = New System.Drawing.Size(123, 232)
    Me.ModIDListBox.TabIndex = 1
    '
    'ModIDLabel
    '
    Me.ModIDLabel.AutoSize = True
    Me.ModIDLabel.Location = New System.Drawing.Point(12, 82)
    Me.ModIDLabel.Name = "ModIDLabel"
    Me.ModIDLabel.Size = New System.Drawing.Size(120, 12)
    Me.ModIDLabel.TabIndex = 2
    Me.ModIDLabel.Text = "現在のMOD一覧({0}件)"
    '
    'GetModButton
    '
    Me.GetModButton.Location = New System.Drawing.Point(16, 52)
    Me.GetModButton.Name = "GetModButton"
    Me.GetModButton.Size = New System.Drawing.Size(123, 25)
    Me.GetModButton.TabIndex = 3
    Me.GetModButton.Text = "Load SaveData"
    Me.GetModButton.UseVisualStyleBackColor = True
    '
    'SetModButton
    '
    Me.SetModButton.Location = New System.Drawing.Point(206, 52)
    Me.SetModButton.Name = "SetModButton"
    Me.SetModButton.Size = New System.Drawing.Size(123, 25)
    Me.SetModButton.TabIndex = 4
    Me.SetModButton.Text = "Save SaveData"
    Me.SetModButton.UseVisualStyleBackColor = True
    '
    'LoadModButton
    '
    Me.LoadModButton.Location = New System.Drawing.Point(206, 336)
    Me.LoadModButton.Name = "LoadModButton"
    Me.LoadModButton.Size = New System.Drawing.Size(123, 26)
    Me.LoadModButton.TabIndex = 5
    Me.LoadModButton.Text = "Mod一覧読込"
    Me.LoadModButton.UseVisualStyleBackColor = True
    '
    'SaveModButton
    '
    Me.SaveModButton.Location = New System.Drawing.Point(16, 336)
    Me.SaveModButton.Name = "SaveModButton"
    Me.SaveModButton.Size = New System.Drawing.Size(123, 26)
    Me.SaveModButton.TabIndex = 6
    Me.SaveModButton.Text = "Mod一覧保存"
    Me.SaveModButton.UseVisualStyleBackColor = True
    '
    'SessionNameLabel
    '
    Me.SessionNameLabel.AutoSize = True
    Me.SessionNameLabel.Location = New System.Drawing.Point(12, 9)
    Me.SessionNameLabel.Name = "SessionNameLabel"
    Me.SessionNameLabel.Size = New System.Drawing.Size(74, 12)
    Me.SessionNameLabel.TabIndex = 7
    Me.SessionNameLabel.Text = "SessionName"
    '
    'SessionNameTextBox
    '
    Me.SessionNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.SessionNameTextBox.BackColor = System.Drawing.SystemColors.Window
    Me.SessionNameTextBox.Location = New System.Drawing.Point(16, 27)
    Me.SessionNameTextBox.Name = "SessionNameTextBox"
    Me.SessionNameTextBox.ReadOnly = True
    Me.SessionNameTextBox.Size = New System.Drawing.Size(388, 19)
    Me.SessionNameTextBox.TabIndex = 8
    Me.SessionNameTextBox.Text = "SessionNameTextBox"
    '
    'NewModIDListBox
    '
    Me.NewModIDListBox.FormattingEnabled = True
    Me.NewModIDListBox.ItemHeight = 12
    Me.NewModIDListBox.Location = New System.Drawing.Point(206, 100)
    Me.NewModIDListBox.Name = "NewModIDListBox"
    Me.NewModIDListBox.Size = New System.Drawing.Size(123, 232)
    Me.NewModIDListBox.TabIndex = 10
    '
    'NewModIDLabel
    '
    Me.NewModIDLabel.AutoSize = True
    Me.NewModIDLabel.Location = New System.Drawing.Point(204, 85)
    Me.NewModIDLabel.Name = "NewModIDLabel"
    Me.NewModIDLabel.Size = New System.Drawing.Size(129, 12)
    Me.NewModIDLabel.TabIndex = 11
    Me.NewModIDLabel.Text = "置換するMOD一覧({0}件)"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(155, 197)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(35, 12)
    Me.Label1.TabIndex = 12
    Me.Label1.Text = "---->"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(416, 373)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.NewModIDLabel)
    Me.Controls.Add(Me.NewModIDListBox)
    Me.Controls.Add(Me.SessionNameTextBox)
    Me.Controls.Add(Me.SessionNameLabel)
    Me.Controls.Add(Me.SaveModButton)
    Me.Controls.Add(Me.LoadModButton)
    Me.Controls.Add(Me.SetModButton)
    Me.Controls.Add(Me.GetModButton)
    Me.Controls.Add(Me.ModIDLabel)
    Me.Controls.Add(Me.ModIDListBox)
    Me.Controls.Add(Me.CloseButton)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.MinimumSize = New System.Drawing.Size(300, 300)
    Me.Name = "MainForm"
    Me.Text = "MainForm"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents CloseButton As Button
  Friend WithEvents ModIDListBox As ListBox
  Friend WithEvents ModIDLabel As Label
  Friend WithEvents GetModButton As Button
  Friend WithEvents SetModButton As Button
  Friend WithEvents LoadModButton As Button
  Friend WithEvents SaveModButton As Button
  Friend WithEvents SessionNameLabel As Label
  Friend WithEvents SessionNameTextBox As TextBox
  Friend WithEvents ToolTip As ToolTip
  Friend WithEvents NewModIDListBox As ListBox
  Friend WithEvents NewModIDLabel As Label
  Friend WithEvents Label1 As Label
End Class
