''' <summary>
''' 段落内容
''' </summary>
Public Class ParagraphInfo
    ''' <summary>
    ''' 内容
    ''' </summary>
    Public value As String

    ''' <summary>
    ''' 显示时长
    ''' </summary>
    Public ShowTimestamp As TimeSpan

    ''' <summary>
    ''' 是否有显示时长
    ''' </summary>
    Public HaveTimestamp As Boolean

    ''' <summary>
    ''' 是否选中
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public Checked As Boolean

    ''' <summary>
    ''' 录制的时长
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public TranscribeTimestamp As TimeSpan

End Class
