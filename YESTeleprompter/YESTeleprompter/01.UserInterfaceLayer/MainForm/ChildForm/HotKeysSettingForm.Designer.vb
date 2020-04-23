<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HotKeysSettingForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.AddOrSaveButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PlayComboBox = New System.Windows.Forms.ComboBox()
        Me.PlayLabel = New System.Windows.Forms.Label()
        Me.HideComboBox = New System.Windows.Forms.ComboBox()
        Me.StopComboBox = New System.Windows.Forms.ComboBox()
        Me.HideLabel = New System.Windows.Forms.Label()
        Me.StopLabel = New System.Windows.Forms.Label()
        Me.PauseLabel = New System.Windows.Forms.Label()
        Me.PauseComboBox = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancelButton
        '
        Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton.Image = Global.YESTeleprompter.My.Resources.Resources.no_16px
        Me.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CancelButton.Location = New System.Drawing.Point(269, 179)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(96, 25)
        Me.CancelButton.TabIndex = 42
        Me.CancelButton.Text = "取消"
        Me.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'AddOrSaveButton
        '
        Me.AddOrSaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddOrSaveButton.Image = Global.YESTeleprompter.My.Resources.Resources.yes_16px
        Me.AddOrSaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AddOrSaveButton.Location = New System.Drawing.Point(167, 179)
        Me.AddOrSaveButton.Name = "AddOrSaveButton"
        Me.AddOrSaveButton.Size = New System.Drawing.Size(96, 25)
        Me.AddOrSaveButton.TabIndex = 41
        Me.AddOrSaveButton.Text = "保存修改"
        Me.AddOrSaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AddOrSaveButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 17)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "播放"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 17)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "停止"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 17)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "隐藏/显示播放窗口"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PlayComboBox, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PlayLabel, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.HideComboBox, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.StopComboBox, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.HideLabel, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.StopLabel, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PauseLabel, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PauseComboBox, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(51, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(287, 147)
        Me.TableLayoutPanel1.TabIndex = 45
        '
        'PlayComboBox
        '
        Me.PlayComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PlayComboBox.FormattingEnabled = True
        Me.PlayComboBox.Location = New System.Drawing.Point(118, 5)
        Me.PlayComboBox.Name = "PlayComboBox"
        Me.PlayComboBox.Size = New System.Drawing.Size(121, 25)
        Me.PlayComboBox.TabIndex = 44
        '
        'PlayLabel
        '
        Me.PlayLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PlayLabel.Image = Global.YESTeleprompter.My.Resources.Resources.yes_16px
        Me.PlayLabel.Location = New System.Drawing.Point(258, 6)
        Me.PlayLabel.Name = "PlayLabel"
        Me.PlayLabel.Size = New System.Drawing.Size(24, 24)
        Me.PlayLabel.TabIndex = 45
        '
        'HideComboBox
        '
        Me.HideComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.HideComboBox.FormattingEnabled = True
        Me.HideComboBox.Location = New System.Drawing.Point(118, 117)
        Me.HideComboBox.Name = "HideComboBox"
        Me.HideComboBox.Size = New System.Drawing.Size(121, 25)
        Me.HideComboBox.TabIndex = 44
        '
        'StopComboBox
        '
        Me.StopComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.StopComboBox.FormattingEnabled = True
        Me.StopComboBox.Location = New System.Drawing.Point(118, 80)
        Me.StopComboBox.Name = "StopComboBox"
        Me.StopComboBox.Size = New System.Drawing.Size(121, 25)
        Me.StopComboBox.TabIndex = 44
        '
        'HideLabel
        '
        Me.HideLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.HideLabel.Image = Global.YESTeleprompter.My.Resources.Resources.yes_16px
        Me.HideLabel.Location = New System.Drawing.Point(258, 115)
        Me.HideLabel.Name = "HideLabel"
        Me.HideLabel.Size = New System.Drawing.Size(24, 24)
        Me.HideLabel.TabIndex = 45
        '
        'StopLabel
        '
        Me.StopLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.StopLabel.Image = Global.YESTeleprompter.My.Resources.Resources.yes_16px
        Me.StopLabel.Location = New System.Drawing.Point(258, 78)
        Me.StopLabel.Name = "StopLabel"
        Me.StopLabel.Size = New System.Drawing.Size(24, 24)
        Me.StopLabel.TabIndex = 45
        '
        'PauseLabel
        '
        Me.PauseLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PauseLabel.Image = Global.YESTeleprompter.My.Resources.Resources.yes_16px
        Me.PauseLabel.Location = New System.Drawing.Point(258, 42)
        Me.PauseLabel.Name = "PauseLabel"
        Me.PauseLabel.Size = New System.Drawing.Size(24, 24)
        Me.PauseLabel.TabIndex = 45
        '
        'PauseComboBox
        '
        Me.PauseComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PauseComboBox.FormattingEnabled = True
        Me.PauseComboBox.Location = New System.Drawing.Point(118, 44)
        Me.PauseComboBox.Name = "PauseComboBox"
        Me.PauseComboBox.Size = New System.Drawing.Size(121, 25)
        Me.PauseComboBox.TabIndex = 44
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 17)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "暂停"
        '
        'HotKeysSettingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 216)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.AddOrSaveButton)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HotKeysSettingForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HotKeysForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend Shadows WithEvents CancelButton As Button
    Friend WithEvents AddOrSaveButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PlayComboBox As ComboBox
    Friend WithEvents StopComboBox As ComboBox
    Friend WithEvents HideComboBox As ComboBox
    Friend WithEvents PlayLabel As Label
    Friend WithEvents StopLabel As Label
    Friend WithEvents HideLabel As Label
    Friend WithEvents PauseLabel As Label
    Friend WithEvents PauseComboBox As ComboBox
    Friend WithEvents Label8 As Label
End Class
