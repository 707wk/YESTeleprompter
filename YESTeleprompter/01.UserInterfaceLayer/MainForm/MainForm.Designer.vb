<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.RibbonControl1 = New DevComponents.DotNetBar.RibbonControl()
        Me.RibbonPanel1 = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBar4 = New DevComponents.DotNetBar.RibbonBar()
        Me.HotkeysButton = New DevComponents.DotNetBar.ButtonItem()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.HidePlayWindowButton = New DevComponents.DotNetBar.SwitchButtonItem()
        Me.RibbonBar3 = New DevComponents.DotNetBar.RibbonBar()
        Me.TranscribeButton = New DevComponents.DotNetBar.ButtonItem()
        Me.ClearTranscribeButton = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar2 = New DevComponents.DotNetBar.RibbonBar()
        Me.PlayButton = New DevComponents.DotNetBar.ButtonItem()
        Me.ManualPlayButton = New DevComponents.DotNetBar.ButtonItem()
        Me.PauseButton = New DevComponents.DotNetBar.ButtonItem()
        Me.StopButton = New DevComponents.DotNetBar.ButtonItem()
        Me.PageUpButton = New DevComponents.DotNetBar.ButtonItem()
        Me.PageDnButton = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBar1 = New DevComponents.DotNetBar.RibbonBar()
        Me.NewProgramButton = New DevComponents.DotNetBar.ButtonItem()
        Me.ImportProgramButton = New DevComponents.DotNetBar.ButtonItem()
        Me.ExportProgramButton = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonTabItem1 = New DevComponents.DotNetBar.RibbonTabItem()
        Me.QatCustomizeItem1 = New DevComponents.DotNetBar.QatCustomizeItem()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ProgramList = New Wangk.Resource.CheckBoxDataGridView()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.DeleteProgramButton = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.IsFullScreen = New System.Windows.Forms.CheckBox()
        Me.WindowLocationY = New System.Windows.Forms.NumericUpDown()
        Me.WindowLocationX = New System.Windows.Forms.NumericUpDown()
        Me.WindowSizeHeight = New System.Windows.Forms.NumericUpDown()
        Me.WindowSizeWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PrintDefaultShowTimestamp = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PrintMirror = New System.Windows.Forms.CheckBox()
        Me.SelectPrintFontButton = New System.Windows.Forms.Button()
        Me.PrintFontText = New System.Windows.Forms.TextBox()
        Me.PrintBackColor = New System.Windows.Forms.Label()
        Me.PrintFontColor = New System.Windows.Forms.Label()
        Me.PreviewLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ParagraphList = New Wangk.Resource.CheckBoxDataGridView()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.InsertParagraphButton = New System.Windows.Forms.ToolStripButton()
        Me.DeleteParagraphButton = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.InfoLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RibbonControl1.SuspendLayout()
        Me.RibbonPanel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ProgramList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.WindowLocationY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WindowLocationX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WindowSizeHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WindowSizeWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PrintDefaultShowTimestamp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ParagraphList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.AutoExpand = False
        Me.RibbonControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        '
        '
        '
        Me.RibbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonControl1.Controls.Add(Me.RibbonPanel1)
        Me.RibbonControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonControl1.ForeColor = System.Drawing.Color.White
        Me.RibbonControl1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.RibbonTabItem1})
        Me.RibbonControl1.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.QuickToolbarItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.QatCustomizeItem1})
        Me.RibbonControl1.Size = New System.Drawing.Size(1264, 110)
        Me.RibbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
        Me.RibbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
        Me.RibbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
        Me.RibbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
        Me.RibbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
        Me.RibbonControl1.SystemText.QatDialogAddButton = "&Add >>"
        Me.RibbonControl1.SystemText.QatDialogCancelButton = "Cancel"
        Me.RibbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
        Me.RibbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
        Me.RibbonControl1.SystemText.QatDialogOkButton = "OK"
        Me.RibbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl1.SystemText.QatDialogRemoveButton = "&Remove"
        Me.RibbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
        Me.RibbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
        Me.RibbonControl1.TabGroupHeight = 14
        Me.RibbonControl1.TabIndex = 0
        Me.RibbonControl1.Text = "RibbonControl1"
        '
        'RibbonPanel1
        '
        Me.RibbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar4)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar3)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar2)
        Me.RibbonPanel1.Controls.Add(Me.RibbonBar1)
        Me.RibbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanel1.Location = New System.Drawing.Point(0, 27)
        Me.RibbonPanel1.Name = "RibbonPanel1"
        Me.RibbonPanel1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 2)
        Me.RibbonPanel1.Size = New System.Drawing.Size(1264, 83)
        '
        '
        '
        Me.RibbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanel1.TabIndex = 1
        '
        'RibbonBar4
        '
        Me.RibbonBar4.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar4.ContainerControlProcessDialogKey = True
        Me.RibbonBar4.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar4.DragDropSupport = True
        Me.RibbonBar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.HotkeysButton, Me.ItemContainer1})
        Me.RibbonBar4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar4.Location = New System.Drawing.Point(764, 0)
        Me.RibbonBar4.Name = "RibbonBar4"
        Me.RibbonBar4.Size = New System.Drawing.Size(262, 81)
        Me.RibbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar4.TabIndex = 3
        Me.RibbonBar4.Text = "RibbonBar4"
        '
        '
        '
        Me.RibbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar4.TitleVisible = False
        '
        'HotkeysButton
        '
        Me.HotkeysButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.HotkeysButton.Image = Global.YESTeleprompter.My.Resources.Resources.hotkeys_32px
        Me.HotkeysButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.HotkeysButton.Name = "HotkeysButton"
        Me.HotkeysButton.SubItemsExpandWidth = 14
        Me.HotkeysButton.Text = "快捷键设置"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.HidePlayWindowButton})
        '
        '
        '
        Me.ItemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'HidePlayWindowButton
        '
        Me.HidePlayWindowButton.Name = "HidePlayWindowButton"
        Me.HidePlayWindowButton.OffBackColor = System.Drawing.Color.LimeGreen
        Me.HidePlayWindowButton.OffText = "显示"
        Me.HidePlayWindowButton.OnText = "隐藏"
        Me.HidePlayWindowButton.Text = "播放窗口"
        '
        'RibbonBar3
        '
        Me.RibbonBar3.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar3.ContainerControlProcessDialogKey = True
        Me.RibbonBar3.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar3.DragDropSupport = True
        Me.RibbonBar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.TranscribeButton})
        Me.RibbonBar3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar3.Location = New System.Drawing.Point(632, 0)
        Me.RibbonBar3.Name = "RibbonBar3"
        Me.RibbonBar3.Size = New System.Drawing.Size(132, 81)
        Me.RibbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar3.TabIndex = 2
        Me.RibbonBar3.Text = "RibbonBar3"
        '
        '
        '
        Me.RibbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar3.TitleVisible = False
        '
        'TranscribeButton
        '
        Me.TranscribeButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.TranscribeButton.Image = Global.YESTeleprompter.My.Resources.Resources.transcribe_32px
        Me.TranscribeButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.TranscribeButton.Name = "TranscribeButton"
        Me.TranscribeButton.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ClearTranscribeButton})
        Me.TranscribeButton.SubItemsExpandWidth = 14
        Me.TranscribeButton.Text = "录制播放演示"
        '
        'ClearTranscribeButton
        '
        Me.ClearTranscribeButton.Image = Global.YESTeleprompter.My.Resources.Resources.close_20px
        Me.ClearTranscribeButton.Name = "ClearTranscribeButton"
        Me.ClearTranscribeButton.Text = "清除当前素材录制信息"
        '
        'RibbonBar2
        '
        Me.RibbonBar2.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar2.ContainerControlProcessDialogKey = True
        Me.RibbonBar2.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar2.DragDropSupport = True
        Me.RibbonBar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.PlayButton, Me.PauseButton, Me.StopButton, Me.PageUpButton, Me.PageDnButton})
        Me.RibbonBar2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar2.Location = New System.Drawing.Point(256, 0)
        Me.RibbonBar2.Name = "RibbonBar2"
        Me.RibbonBar2.Size = New System.Drawing.Size(376, 81)
        Me.RibbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar2.TabIndex = 1
        Me.RibbonBar2.Text = "RibbonBar2"
        '
        '
        '
        Me.RibbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar2.TitleVisible = False
        '
        'PlayButton
        '
        Me.PlayButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.PlayButton.Image = Global.YESTeleprompter.My.Resources.Resources.play_32px
        Me.PlayButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ManualPlayButton})
        Me.PlayButton.SubItemsExpandWidth = 14
        Me.PlayButton.Text = "播放"
        '
        'ManualPlayButton
        '
        Me.ManualPlayButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ManualPlayButton.Image = Global.YESTeleprompter.My.Resources.Resources.manualPlay_20px
        Me.ManualPlayButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ManualPlayButton.Name = "ManualPlayButton"
        Me.ManualPlayButton.SubItemsExpandWidth = 14
        Me.ManualPlayButton.Text = "手动控制播放"
        '
        'PauseButton
        '
        Me.PauseButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.PauseButton.Image = Global.YESTeleprompter.My.Resources.Resources.pause_32px
        Me.PauseButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.PauseButton.Name = "PauseButton"
        Me.PauseButton.SubItemsExpandWidth = 14
        Me.PauseButton.Text = "暂停"
        '
        'StopButton
        '
        Me.StopButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.StopButton.Image = Global.YESTeleprompter.My.Resources.Resources.stop_32px
        Me.StopButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.StopButton.Name = "StopButton"
        Me.StopButton.SubItemsExpandWidth = 14
        Me.StopButton.Text = "停止"
        '
        'PageUpButton
        '
        Me.PageUpButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.PageUpButton.Image = Global.YESTeleprompter.My.Resources.Resources.PageUP_32px
        Me.PageUpButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.PageUpButton.Name = "PageUpButton"
        Me.PageUpButton.SubItemsExpandWidth = 14
        Me.PageUpButton.Text = "上一行"
        '
        'PageDnButton
        '
        Me.PageDnButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.PageDnButton.Image = Global.YESTeleprompter.My.Resources.Resources.PageDn_32px
        Me.PageDnButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.PageDnButton.Name = "PageDnButton"
        Me.PageDnButton.SubItemsExpandWidth = 14
        Me.PageDnButton.Text = "下一行"
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.ContainerControlProcessDialogKey = True
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBar1.DragDropSupport = True
        Me.RibbonBar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.NewProgramButton, Me.ImportProgramButton, Me.ExportProgramButton})
        Me.RibbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBar1.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.Size = New System.Drawing.Size(253, 81)
        Me.RibbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBar1.TabIndex = 0
        Me.RibbonBar1.Text = "RibbonBar1"
        '
        '
        '
        Me.RibbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBar1.TitleVisible = False
        '
        'NewProgramButton
        '
        Me.NewProgramButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.NewProgramButton.Image = Global.YESTeleprompter.My.Resources.Resources.new_32px
        Me.NewProgramButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.NewProgramButton.Name = "NewProgramButton"
        Me.NewProgramButton.SubItemsExpandWidth = 14
        Me.NewProgramButton.Text = "新建素材"
        '
        'ImportProgramButton
        '
        Me.ImportProgramButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ImportProgramButton.Image = Global.YESTeleprompter.My.Resources.Resources.import_32px
        Me.ImportProgramButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ImportProgramButton.Name = "ImportProgramButton"
        Me.ImportProgramButton.SubItemsExpandWidth = 14
        Me.ImportProgramButton.Text = "导入素材"
        '
        'ExportProgramButton
        '
        Me.ExportProgramButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ExportProgramButton.Image = Global.YESTeleprompter.My.Resources.Resources.export_32px
        Me.ExportProgramButton.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ExportProgramButton.Name = "ExportProgramButton"
        Me.ExportProgramButton.SubItemsExpandWidth = 14
        Me.ExportProgramButton.Text = "导出当前素材"
        '
        'RibbonTabItem1
        '
        Me.RibbonTabItem1.Checked = True
        Me.RibbonTabItem1.Name = "RibbonTabItem1"
        Me.RibbonTabItem1.Panel = Me.RibbonPanel1
        Me.RibbonTabItem1.Text = "开始"
        '
        'QatCustomizeItem1
        '
        Me.QatCustomizeItem1.Name = "QatCustomizeItem1"
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Dark
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer)))
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 110)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 549)
        Me.SplitContainer1.SplitterDistance = 311
        Me.SplitContainer1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ProgramList)
        Me.GroupBox1.Controls.Add(Me.ToolStrip1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 540)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "素材列表"
        '
        'ProgramList
        '
        Me.ProgramList.AllowUserToAddRows = False
        Me.ProgramList.AllowUserToDeleteRows = False
        Me.ProgramList.AllowUserToOrderColumns = True
        Me.ProgramList.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ProgramList.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProgramList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ProgramList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProgramList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn2, Me.Column1})
        Me.ProgramList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgramList.Location = New System.Drawing.Point(3, 46)
        Me.ProgramList.Name = "ProgramList"
        Me.ProgramList.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProgramList.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.ProgramList.RowTemplate.Height = 23
        Me.ProgramList.Size = New System.Drawing.Size(299, 491)
        Me.ProgramList.TabIndex = 1
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.Frozen = True
        Me.DataGridViewCheckBoxColumn2.HeaderText = ""
        Me.DataGridViewCheckBoxColumn2.MinimumWidth = 48
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.ReadOnly = True
        Me.DataGridViewCheckBoxColumn2.Width = 48
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "名称"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteProgramButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 19)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(299, 27)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'DeleteProgramButton
        '
        Me.DeleteProgramButton.Image = Global.YESTeleprompter.My.Resources.Resources.close_20px
        Me.DeleteProgramButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DeleteProgramButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteProgramButton.Name = "DeleteProgramButton"
        Me.DeleteProgramButton.Size = New System.Drawing.Size(56, 24)
        Me.DeleteProgramButton.Text = "删除"
        Me.DeleteProgramButton.ToolTipText = "删除"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.IsFullScreen)
        Me.GroupBox4.Controls.Add(Me.WindowLocationY)
        Me.GroupBox4.Controls.Add(Me.WindowLocationX)
        Me.GroupBox4.Controls.Add(Me.WindowSizeHeight)
        Me.GroupBox4.Controls.Add(Me.WindowSizeWidth)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(638, 295)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(308, 251)
        Me.GroupBox4.TabIndex = 47
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "播放窗口设置"
        '
        'IsFullScreen
        '
        Me.IsFullScreen.AutoSize = True
        Me.IsFullScreen.Location = New System.Drawing.Point(107, 169)
        Me.IsFullScreen.Name = "IsFullScreen"
        Me.IsFullScreen.Size = New System.Drawing.Size(51, 21)
        Me.IsFullScreen.TabIndex = 2
        Me.IsFullScreen.Text = "启用"
        Me.IsFullScreen.UseVisualStyleBackColor = True
        '
        'WindowLocationY
        '
        Me.WindowLocationY.Location = New System.Drawing.Point(107, 132)
        Me.WindowLocationY.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.WindowLocationY.Name = "WindowLocationY"
        Me.WindowLocationY.Size = New System.Drawing.Size(100, 23)
        Me.WindowLocationY.TabIndex = 1
        '
        'WindowLocationX
        '
        Me.WindowLocationX.Location = New System.Drawing.Point(107, 99)
        Me.WindowLocationX.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.WindowLocationX.Name = "WindowLocationX"
        Me.WindowLocationX.Size = New System.Drawing.Size(100, 23)
        Me.WindowLocationX.TabIndex = 1
        '
        'WindowSizeHeight
        '
        Me.WindowSizeHeight.Location = New System.Drawing.Point(107, 53)
        Me.WindowSizeHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.WindowSizeHeight.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.WindowSizeHeight.Name = "WindowSizeHeight"
        Me.WindowSizeHeight.Size = New System.Drawing.Size(100, 23)
        Me.WindowSizeHeight.TabIndex = 1
        Me.WindowSizeHeight.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'WindowSizeWidth
        '
        Me.WindowSizeWidth.Location = New System.Drawing.Point(107, 22)
        Me.WindowSizeWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.WindowSizeWidth.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.WindowSizeWidth.Name = "WindowSizeWidth"
        Me.WindowSizeWidth.Size = New System.Drawing.Size(100, 23)
        Me.WindowSizeWidth.TabIndex = 1
        Me.WindowSizeWidth.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(64, 135)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 17)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Y"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(63, 102)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 17)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "X"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 17)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "全屏显示"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 17)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "位置"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(61, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(20, 17)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "高"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(61, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(20, 17)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "宽"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(19, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 17)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "尺寸"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.PrintDefaultShowTimestamp)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.PrintMirror)
        Me.GroupBox3.Controls.Add(Me.SelectPrintFontButton)
        Me.GroupBox3.Controls.Add(Me.PrintFontText)
        Me.GroupBox3.Controls.Add(Me.PrintBackColor)
        Me.GroupBox3.Controls.Add(Me.PrintFontColor)
        Me.GroupBox3.Controls.Add(Me.PreviewLabel)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(638, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(308, 283)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "播放效果设置"
        '
        'PrintDefaultShowTimestamp
        '
        Me.PrintDefaultShowTimestamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrintDefaultShowTimestamp.DecimalPlaces = 2
        Me.PrintDefaultShowTimestamp.Location = New System.Drawing.Point(107, 143)
        Me.PrintDefaultShowTimestamp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PrintDefaultShowTimestamp.Maximum = New Decimal(New Integer() {5999, 0, 0, 131072})
        Me.PrintDefaultShowTimestamp.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.PrintDefaultShowTimestamp.Name = "PrintDefaultShowTimestamp"
        Me.PrintDefaultShowTimestamp.Size = New System.Drawing.Size(100, 23)
        Me.PrintDefaultShowTimestamp.TabIndex = 5
        Me.PrintDefaultShowTimestamp.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 17)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "每行默认显示"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(213, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(14, 17)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "s"
        '
        'PrintMirror
        '
        Me.PrintMirror.AutoSize = True
        Me.PrintMirror.Location = New System.Drawing.Point(107, 182)
        Me.PrintMirror.Name = "PrintMirror"
        Me.PrintMirror.Size = New System.Drawing.Size(51, 21)
        Me.PrintMirror.TabIndex = 3
        Me.PrintMirror.Text = "启用"
        Me.PrintMirror.UseVisualStyleBackColor = True
        '
        'SelectPrintFontButton
        '
        Me.SelectPrintFontButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SelectPrintFontButton.Location = New System.Drawing.Point(213, 27)
        Me.SelectPrintFontButton.Name = "SelectPrintFontButton"
        Me.SelectPrintFontButton.Size = New System.Drawing.Size(75, 25)
        Me.SelectPrintFontButton.TabIndex = 2
        Me.SelectPrintFontButton.Text = "选择 ..."
        Me.SelectPrintFontButton.UseVisualStyleBackColor = True
        '
        'PrintFontText
        '
        Me.PrintFontText.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.PrintFontText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrintFontText.ForeColor = System.Drawing.Color.White
        Me.PrintFontText.Location = New System.Drawing.Point(107, 29)
        Me.PrintFontText.Name = "PrintFontText"
        Me.PrintFontText.ReadOnly = True
        Me.PrintFontText.Size = New System.Drawing.Size(100, 23)
        Me.PrintFontText.TabIndex = 1
        '
        'PrintBackColor
        '
        Me.PrintBackColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.PrintBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrintBackColor.Location = New System.Drawing.Point(107, 104)
        Me.PrintBackColor.Name = "PrintBackColor"
        Me.PrintBackColor.Size = New System.Drawing.Size(100, 23)
        Me.PrintBackColor.TabIndex = 0
        Me.PrintBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PrintFontColor
        '
        Me.PrintFontColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.PrintFontColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PrintFontColor.Location = New System.Drawing.Point(107, 66)
        Me.PrintFontColor.Name = "PrintFontColor"
        Me.PrintFontColor.Size = New System.Drawing.Size(100, 23)
        Me.PrintFontColor.TabIndex = 0
        Me.PrintFontColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PreviewLabel
        '
        Me.PreviewLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PreviewLabel.Location = New System.Drawing.Point(107, 221)
        Me.PreviewLabel.Name = "PreviewLabel"
        Me.PreviewLabel.Size = New System.Drawing.Size(131, 47)
        Me.PreviewLabel.TabIndex = 0
        Me.PreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "效果预览"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "镜像显示"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "背景颜色"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "字体颜色"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "字体"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.ParagraphList)
        Me.GroupBox2.Controls.Add(Me.ToolStrip2)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(629, 540)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "素材内容"
        '
        'ParagraphList
        '
        Me.ParagraphList.AllowUserToAddRows = False
        Me.ParagraphList.AllowUserToDeleteRows = False
        Me.ParagraphList.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ParagraphList.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ParagraphList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ParagraphList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ParagraphList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.Column2, Me.Column3})
        Me.ParagraphList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ParagraphList.Location = New System.Drawing.Point(3, 46)
        Me.ParagraphList.Name = "ParagraphList"
        Me.ParagraphList.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ParagraphList.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.ParagraphList.RowTemplate.Height = 23
        Me.ParagraphList.Size = New System.Drawing.Size(623, 491)
        Me.ParagraphList.TabIndex = 1
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.Frozen = True
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.MinimumWidth = 48
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxColumn1.Width = 48
        '
        'Column2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "显示时长"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.Width = 80
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "段落内容"
        Me.Column3.MinimumWidth = 320
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InsertParagraphButton, Me.DeleteParagraphButton})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 19)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(623, 27)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'InsertParagraphButton
        '
        Me.InsertParagraphButton.Image = Global.YESTeleprompter.My.Resources.Resources.insertUp_20px
        Me.InsertParagraphButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.InsertParagraphButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InsertParagraphButton.Name = "InsertParagraphButton"
        Me.InsertParagraphButton.Size = New System.Drawing.Size(56, 24)
        Me.InsertParagraphButton.Text = "插入"
        Me.InsertParagraphButton.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.InsertParagraphButton.ToolTipText = "插入"
        '
        'DeleteParagraphButton
        '
        Me.DeleteParagraphButton.Image = Global.YESTeleprompter.My.Resources.Resources.close_20px
        Me.DeleteParagraphButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DeleteParagraphButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteParagraphButton.Name = "DeleteParagraphButton"
        Me.DeleteParagraphButton.Size = New System.Drawing.Size(56, 24)
        Me.DeleteParagraphButton.Text = "删除"
        Me.DeleteParagraphButton.ToolTipText = "删除"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 659)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1264, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'InfoLabel
        '
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(68, 17)
        Me.InfoLabel.Text = "无操作信息"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.RibbonControl1.ResumeLayout(False)
        Me.RibbonControl1.PerformLayout()
        Me.RibbonPanel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ProgramList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.WindowLocationY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WindowLocationX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WindowSizeHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WindowSizeWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PrintDefaultShowTimestamp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ParagraphList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevComponents.DotNetBar.RibbonControl
    Friend WithEvents RibbonPanel1 As DevComponents.DotNetBar.RibbonPanel
    Friend WithEvents RibbonBar2 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents PlayButton As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents StopButton As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar1 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents ImportProgramButton As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonTabItem1 As DevComponents.DotNetBar.RibbonTabItem
    Friend WithEvents QatCustomizeItem1 As DevComponents.DotNetBar.QatCustomizeItem
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents DeleteProgramButton As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents InsertParagraphButton As ToolStripButton
    Friend WithEvents DeleteParagraphButton As ToolStripButton
    Friend WithEvents ProgramList As Wangk.Resource.CheckBoxDataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As DataGridViewCheckBoxColumn
    Friend WithEvents ParagraphList As Wangk.Resource.CheckBoxDataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents InfoLabel As ToolStripStatusLabel
    Friend WithEvents PageUpButton As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents PageDnButton As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SelectPrintFontButton As Button
    Friend WithEvents PrintFontText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PrintMirror As CheckBox
    Friend WithEvents PreviewLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents RibbonBar4 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents HotkeysButton As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBar3 As DevComponents.DotNetBar.RibbonBar
    Friend WithEvents TranscribeButton As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents PrintBackColor As Label
    Friend WithEvents PrintFontColor As Label
    Friend WithEvents ClearTranscribeButton As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ExportProgramButton As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents HidePlayWindowButton As DevComponents.DotNetBar.SwitchButtonItem
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents PrintDefaultShowTimestamp As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents IsFullScreen As CheckBox
    Friend WithEvents WindowLocationY As NumericUpDown
    Friend WithEvents WindowLocationX As NumericUpDown
    Friend WithEvents WindowSizeHeight As NumericUpDown
    Friend WithEvents WindowSizeWidth As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents NewProgramButton As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents PauseButton As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents ManualPlayButton As DevComponents.DotNetBar.ButtonItem
End Class
