''' <summary>
''' 素材信息
''' </summary>
Public Class ProgramInfo
    ''' <summary>
    ''' 源文件路径
    ''' </summary>
    Public SourceFilePath As String

    ''' <summary>
    ''' 段落内容
    ''' </summary>
    Public ParagraphItems As New List(Of ParagraphInfo)

    ''' <summary>
    ''' 显示字体
    ''' </summary>
    Public PrintFont As Font
    ''' <summary>
    ''' 显示字体颜色
    ''' </summary>
    Public PrintFontColor As Color
    ''' <summary>
    ''' 显示背景色
    ''' </summary>
    Public PrintBackColor As Color
    ''' <summary>
    ''' 默认显示时长
    ''' </summary>
    Public PrintIntervalSec As Double
    ''' <summary>
    ''' 镜像显示
    ''' </summary>
    Public PrintMirror As Boolean

    ''' <summary>
    ''' 播放窗口尺寸
    ''' </summary>
    Public WindowSize As Size
    ''' <summary>
    ''' 播放窗口位置
    ''' </summary>
    Public WindowLocation As Point
    ''' <summary>
    ''' 全屏显示
    ''' </summary>
    Public IsFullScreen As Boolean

End Class
