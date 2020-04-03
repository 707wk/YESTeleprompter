''' <summary>
''' txt文本类型
''' </summary>
Public Class FileTypeTxt
    Inherits FileBaseInfo

    Public Sub New(filePath As String)
        MyBase.New(filePath)

        EnabledEdit = True
        HaveTimestamp = False

        Dim tmpDetectionResult = UtfUnknown.CharsetDetector.DetectFromFile(SourceFilePath)
        If tmpDetectionResult.Detected.Encoding Is Nothing Then
            Throw New Exception("不支持的文本编码")
        End If

        Using reader As New IO.StreamReader(SourceFilePath, tmpDetectionResult.Detected.Encoding)
            Do

                Dim tmpStr = reader.ReadLine()
                If tmpStr Is Nothing Then
                    Exit Do
                End If

                ParagraphItems.Add(New ParagraphInfo With {
                                   .value = tmpStr
                                   })

            Loop
        End Using

    End Sub
End Class
