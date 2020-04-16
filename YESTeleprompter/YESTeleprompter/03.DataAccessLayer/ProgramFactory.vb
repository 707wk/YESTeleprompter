Imports System.IO
Imports Newtonsoft.Json
Imports NPOI.XWPF.Usermodel
''' <summary>
''' 文件类型工厂类
''' </summary>
Public NotInheritable Class ProgramFactory
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 根据文件类型创建对应类
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    Public Shared Function Create(filePath As String) As ProgramInfo
        Dim fileTypeStr As String = IO.Path.GetExtension(filePath).ToLower

        Select Case fileTypeStr
            Case ".txt"
                Return GetTxtInfo(filePath)

            Case ".lrc"
                Return GetLrcInfo(filePath)

            Case ".docx"
                Return GetDocxInfo(filePath)

            Case ".lrcy"
                Return JsonConvert.DeserializeObject(Of ProgramInfo)(
                    System.IO.File.ReadAllText(filePath,
                                               System.Text.Encoding.UTF8))

            Case Else
                Throw New Exception($"不支持的文件类型: { filePath}")

        End Select

    End Function

#Region "GetTxtInfo"
    Public Shared Function GetTxtInfo(filePath As String)
        Dim tmpProgramInfo As New ProgramInfo With {
            .Name = IO.Path.GetFileNameWithoutExtension(filePath)
        }

        Dim tmpDetectionResult = UtfUnknown.CharsetDetector.DetectFromFile(filePath)
        If tmpDetectionResult.Detected.Encoding Is Nothing Then
            Throw New Exception("不支持的文本编码")
        End If

        Using reader As New IO.StreamReader(filePath, tmpDetectionResult.Detected.Encoding)
            Do

                Dim tmpStr = reader.ReadLine()
                If tmpStr Is Nothing Then
                    Exit Do
                End If

                tmpProgramInfo.ParagraphItems.Add(New ParagraphInfo With {
                                   .value = tmpStr
                                   })

            Loop
        End Using

        Return tmpProgramInfo
    End Function
#End Region

#Region "GetLrcInfo"
    Public Shared Function GetLrcInfo(filePath As String)
        Dim tmpProgramInfo As New ProgramInfo With {
            .Name = IO.Path.GetFileNameWithoutExtension(filePath)
        }

        Dim tmpDetectionResult = UtfUnknown.CharsetDetector.DetectFromFile(filePath)
        If tmpDetectionResult.Detected.Encoding Is Nothing Then
            Throw New Exception("不支持的文本编码")
        End If

        Using reader As New IO.StreamReader(filePath, tmpDetectionResult.Detected.Encoding)
            Do

                Dim tmpStrArray = reader.ReadLine()?.Split("]")
                If tmpStrArray Is Nothing Then
                    Exit Do
                End If

                Dim timeStr = tmpStrArray(0).Substring(1, tmpStrArray(0).Length - 1)

                Try
                    DateTime.ParseExact(timeStr, "mm:ss.ff", Nothing)
                Catch ex As Exception
                    Continue Do
                End Try

                tmpProgramInfo.ParagraphItems.Add(New ParagraphInfo With {
                                   .Timestamp = DateTime.ParseExact(timeStr, "mm:ss.ff", Nothing).TimeOfDay,
                                   .value = tmpStrArray(1)
                                   })

            Loop
        End Using

        Return tmpProgramInfo
    End Function
#End Region

#Region "GetDocxInfo"
    Public Shared Function GetDocxInfo(filePath As String)
        Dim tmpProgramInfo As New ProgramInfo With {
            .Name = IO.Path.GetFileNameWithoutExtension(filePath)
        }

        Using tmpFS = File.OpenRead(filePath)
            Dim docx As XWPFDocument = New XWPFDocument(tmpFS)
            For Each paragraph In docx.Paragraphs
                tmpProgramInfo.ParagraphItems.Add(New ParagraphInfo With {
                                   .value = paragraph.ParagraphText
                                   })
            Next

            docx.Close()
        End Using

        Return tmpProgramInfo
    End Function
#End Region

End Class
