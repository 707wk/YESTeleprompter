''' <summary>
''' 文件基础信息
''' </summary>
Public MustInherit Class FileBaseInfo
    ''' <summary>
    ''' 源文件路径
    ''' </summary>
    Public SourceFilePath As String

    ''' <summary>
    ''' 段落内容
    ''' </summary>
    Public ParagraphItems As New List(Of ParagraphInfo)

    ''' <summary>
    ''' 是否允许编辑
    ''' </summary>
    Public EnabledEdit As Boolean

    ''' <summary>
    ''' 是否有时间戳
    ''' </summary>
    Public HaveTimestamp As Boolean

    Public Sub New(filePath As String)
        SourceFilePath = filePath
    End Sub

End Class
