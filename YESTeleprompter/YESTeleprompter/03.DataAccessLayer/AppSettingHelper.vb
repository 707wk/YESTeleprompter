Imports System.IO
Imports Newtonsoft.Json
''' <summary>
''' 全局配置辅助类
''' </summary>
Public Class AppSettingHelper
    Private Sub New()
    End Sub

#Region "程序集GUID"
    <Newtonsoft.Json.JsonIgnore>
    Private _GUID As String
    ''' <summary>
    ''' 程序集GUID
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public ReadOnly Property GUID As String
        Get
            Return _GUID
        End Get
    End Property
#End Region

#Region "程序集文件版本"
    <Newtonsoft.Json.JsonIgnore>
    Private _ProductVersion As String
    ''' <summary>
    ''' 程序集文件版本
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public ReadOnly Property ProductVersion As String
        Get
            Return _ProductVersion
        End Get
    End Property
#End Region

#Region "配置参数"
    ''' <summary>
    ''' 实例
    ''' </summary>
    Private Shared instance As AppSettingHelper
    ''' <summary>
    ''' 获取实例
    ''' </summary>
    Public Shared ReadOnly Property GetInstance As AppSettingHelper
        Get
            If instance Is Nothing Then
                LoadFromLocaltion()

                '程序集GUID
                Dim guid_attr As Attribute = Attribute.GetCustomAttribute(Reflection.Assembly.GetExecutingAssembly(), GetType(Runtime.InteropServices.GuidAttribute))
                instance._GUID = CType(guid_attr, Runtime.InteropServices.GuidAttribute).Value

                '程序集文件版本
                Dim assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location
                instance._ProductVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).ProductVersion

            End If

            Return instance
        End Get
    End Property
#End Region

#Region "从本地读取配置"
    ''' <summary>
    ''' 从本地读取配置
    ''' </summary>
    Private Shared Sub LoadFromLocaltion()
        Dim Path As String = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)

        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech")
        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}")
        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}\Data")

        '反序列化
        Try
            instance = JsonConvert.DeserializeObject(Of AppSettingHelper)(
                System.IO.File.ReadAllText($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}\Data\Setting.json",
                                           System.Text.Encoding.UTF8))

        Catch ex As Exception
            '使用默认参数
            instance = New AppSettingHelper

        End Try

        '读取素材
        Try
            Dim tmpDirectoryInfo As New DirectoryInfo("./Data")
            If tmpDirectoryInfo.Exists Then
                For Each item In tmpDirectoryInfo.GetFiles()
                    Dim tmpProgramInfo = JsonConvert.DeserializeObject(Of ProgramInfo)(
                        System.IO.File.ReadAllText(item.FullName,
                                                   System.Text.Encoding.UTF8))
                    AppSettingHelper.GetInstance.ProgramItems.Add(tmpProgramInfo)
                Next

            End If
        Catch ex As Exception
        End Try

    End Sub
#End Region

#Region "保存配置到本地"
    ''' <summary>
    ''' 保存配置到本地
    ''' </summary>
    Public Shared Sub SaveToLocaltion()
        Dim Path As String = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)

        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech")
        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}")
        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}\Data")

        '序列化
        Try
            Using t As System.IO.StreamWriter = New System.IO.StreamWriter(
                    $"{Path}\Hunan Yestech\{My.Application.Info.ProductName}\Data\Setting.json",
                    False,
                    System.Text.Encoding.UTF8)

                t.Write(JsonConvert.SerializeObject(instance))
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, My.Application.Info.Title)

        End Try

        '保存素材
        Try
            System.IO.Directory.CreateDirectory("./Data")
            For Each item In AppSettingHelper.GetInstance.ProgramItems

                Using t As System.IO.StreamWriter = New System.IO.StreamWriter(
                $"./Data/{item.ID}",
                False,
                System.Text.Encoding.UTF8)

                    t.Write(JsonConvert.SerializeObject(item))
                End Using

            Next

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, My.Application.Info.Title)
        End Try

    End Sub
#End Region

#Region "日志记录"
    ''' <summary>
    ''' 日志记录
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public Logger As NLog.Logger = NLog.LogManager.GetCurrentClassLogger()
#End Region

    ''' <summary>
    ''' 主窗口尺寸
    ''' </summary>
    Public WindowSize As Size
    ''' <summary>
    ''' 主窗口位置
    ''' </summary>
    Public WindowLocation As Point

    ''' <summary>
    ''' 当前编辑的素材
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public ActiveProgram As ProgramInfo

    ''' <summary>
    ''' 播放快捷键
    ''' </summary>
    Public HotKeyForPlay As Keys = Keys.F5
    ''' <summary>
    ''' 暂停播放快捷键
    ''' </summary>
    Public HotKeyForPause As Keys = Keys.F6
    ''' <summary>
    ''' 停止播放快捷键
    ''' </summary>
    Public HotKeyForStop As Keys = Keys.F7
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
