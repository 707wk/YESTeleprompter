<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartForm
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
        Me.TitleLable = New System.Windows.Forms.Label()
        Me.ProductVersionLable = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TitleLable
        '
        Me.TitleLable.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TitleLable.AutoSize = True
        Me.TitleLable.BackColor = System.Drawing.Color.Transparent
        Me.TitleLable.Font = New System.Drawing.Font("微软雅黑", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TitleLable.ForeColor = System.Drawing.SystemColors.Control
        Me.TitleLable.Location = New System.Drawing.Point(12, 9)
        Me.TitleLable.Name = "TitleLable"
        Me.TitleLable.Size = New System.Drawing.Size(51, 25)
        Me.TitleLable.TabIndex = 0
        Me.TitleLable.Text = "Title"
        Me.TitleLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductVersionLable
        '
        Me.ProductVersionLable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProductVersionLable.BackColor = System.Drawing.Color.Transparent
        Me.ProductVersionLable.ForeColor = System.Drawing.SystemColors.Control
        Me.ProductVersionLable.Location = New System.Drawing.Point(4, 77)
        Me.ProductVersionLable.Name = "ProductVersionLable"
        Me.ProductVersionLable.Size = New System.Drawing.Size(504, 40)
        Me.ProductVersionLable.TabIndex = 1
        Me.ProductVersionLable.Text = "ProductVersion" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Copyright"
        Me.ProductVersionLable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StartForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.YESTeleprompter.My.Resources.Resources.startBackground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(512, 126)
        Me.Controls.Add(Me.TitleLable)
        Me.Controls.Add(Me.ProductVersionLable)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StartForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "StartForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TitleLable As Label
    Friend WithEvents ProductVersionLable As Label
End Class
