''' <summary>
''' 段落内容
''' </summary>
Public Class ParagraphInfo
    ''' <summary>
    ''' 内容
    ''' </summary>
    Public value As String

    ''' <summary>
    ''' 时间戳
    ''' </summary>
    Public Timestamp As TimeSpan

    ''' <summary>
    ''' 是否有时间戳
    ''' </summary>
    Public HaveTimestamp As Boolean

    ''' <summary>
    ''' 是否选中
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public Checked As Boolean

End Class
