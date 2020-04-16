''' <summary>
''' 全局配置类
''' </summary>
Public Class AppSetting
    ''' <summary>
    ''' 主窗口尺寸
    ''' </summary>
    Public WindowSize As Size
    ''' <summary>
    ''' 主窗口位置
    ''' </summary>
    Public WindowLocation As Point

    '''' <summary>
    '''' 激活的素材
    '''' </summary>
    '<Newtonsoft.Json.JsonIgnore>
    'Public ActiveProgram As ProgramInfo

    ''' <summary>
    ''' 素材集合
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public ProgramItems As New List(Of ProgramInfo)

End Class
