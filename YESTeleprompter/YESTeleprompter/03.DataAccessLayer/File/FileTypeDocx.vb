Imports System.IO
Imports NPOI.XWPF.Usermodel

''' <summary>
''' docx文档类型
''' </summary>
Public Class FileTypeDocx
    Inherits FileBaseInfo

    Public Sub New(filePath As String)
        MyBase.New(filePath)

        EnabledEdit = False
        HaveTimestamp = False

        Using tmpFS = File.OpenRead(SourceFilePath)
            Dim docx As XWPFDocument = New XWPFDocument(tmpFS)
            For Each paragraph In docx.Paragraphs
                ParagraphItems.Add(New ParagraphInfo With {
                                   .value = paragraph.ParagraphText
                                   })
            Next

            docx.Close()
        End Using

    End Sub
End Class
