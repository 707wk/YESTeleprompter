''' <summary>
''' lrc歌词类型
''' </summary>
Public Class FileTypeLrc
    Inherits FileBaseInfo

    Public Sub New(filePath As String)
        MyBase.New(filePath)

        EnabledEdit = False
        HaveTimestamp = True

        Dim tmpDetectionResult = UtfUnknown.CharsetDetector.DetectFromFile(SourceFilePath)
        If tmpDetectionResult.Detected.Encoding Is Nothing Then
            Throw New Exception("不支持的文本编码")
        End If

        Using reader As New IO.StreamReader(SourceFilePath, tmpDetectionResult.Detected.Encoding)
            Do

                Dim tmpStrArray = reader.ReadLine()?.Split("]")
                If tmpStrArray Is Nothing Then
                    Exit Do
                End If

                Dim timeStr = tmpStrArray(0).Substring(1, 5)

                Try
                    DateTime.Parse(timeStr)
                Catch ex As Exception
                    Continue Do
                End Try

                ParagraphItems.Add(New ParagraphInfo With {
                                   .Timestamp = DateTime.Parse(timeStr),
                                   .value = tmpStrArray(1)
                                   })

            Loop
        End Using

    End Sub
End Class
