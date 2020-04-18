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
    ''' 播放快捷键
    ''' </summary>
    Public HotKeyForPlay As Keys = Keys.F5
    ''' <summary>
    ''' 停止播放快捷键
    ''' </summary>
    Public HotKeyForStop As Keys = Keys.F6
    ''' <summary>
    ''' 隐藏播放窗口快捷键
    ''' </summary>
    Public HotKeyForHideWindow As Keys = Keys.F8

    ''' <summary>
    ''' 素材集合
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public ProgramItems As New List(Of ProgramInfo)

End Class
