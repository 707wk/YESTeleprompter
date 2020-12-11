''' <summary>
''' 素材信息
''' </summary>
Public Class ProgramInfo
    '''' <summary>
    '''' 源文件路径
    '''' </summary>
    'Public SourceFilePath As String

    ''' <summary>
    ''' 识别标识
    ''' </summary>
    Public ID As Guid = Guid.NewGuid

    ''' <summary>
    ''' 名称
    ''' </summary>
    Public Name As String

    ''' <summary>
    ''' 段落内容
    ''' </summary>
    Public ParagraphItems As New List(Of ParagraphInfo)

    '''' <summary>
    '''' 是否有显示时长
    '''' </summary>
    'Public HaveTimestamp As Boolean

    ''' <summary>
    ''' 显示字体
    ''' </summary>
    Public PrintFont As Font
    ''' <summary>
    ''' 显示字体颜色
    ''' </summary>
    Public PrintFontColor As Color = Color.Green
    ''' <summary>
    ''' 显示背景色
    ''' </summary>
    Public PrintBackColor As Color = Color.Black
    ''' <summary>
    ''' 默认显示时长
    ''' </summary>
    Public PrintDefaultShowTimestamp As TimeSpan = New TimeSpan(0, 0, 1)
    ''' <summary>
    ''' 镜像显示
    ''' </summary>
    Public PrintMirror As Boolean

    ''' <summary>
    ''' 播放窗口尺寸
    ''' </summary>
    Public WindowSize As Size = New Size(320, 240)
    ''' <summary>
    ''' 播放窗口位置
    ''' </summary>
    Public WindowLocation As Point
    ''' <summary>
    ''' 全屏显示
    ''' </summary>
    Public IsFullScreen As Boolean

End Class
