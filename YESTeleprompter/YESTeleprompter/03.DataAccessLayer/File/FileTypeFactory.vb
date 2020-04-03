''' <summary>
''' 文件类型工厂类
''' </summary>
Public NotInheritable Class FileTypeFactory
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 根据文件类型创建对应类
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    Public Shared Function Create(filePath As String) As FileBaseInfo
        Dim fileTypeStr As String = IO.Path.GetExtension(filePath).ToLower

        Select Case fileTypeStr
            Case ".txt"
                Return New FileTypeTxt(filePath)

            Case ".lrc"
                Return New FileTypeLrc(filePath)

            Case ".docx"
                Return New FileTypeDocx(filePath)

            Case Else
                Throw New Exception($"不支持的文件类型: { filePath}")

        End Select

    End Function

End Class
