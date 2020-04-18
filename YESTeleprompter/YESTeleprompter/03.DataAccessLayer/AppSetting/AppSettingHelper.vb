﻿Imports System.IO
Imports Newtonsoft.Json
''' <summary>
''' 全局配置辅助类
''' </summary>
Public Class AppSettingHelper
    Private Sub New()
    End Sub

#Region "程序标志"
    Private Shared _GUID As String
    ''' <summary>
    ''' 程序标志
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property GUID As String
        Get
            If String.IsNullOrEmpty(_GUID) Then
                Dim guid_attr As Attribute = Attribute.GetCustomAttribute(Reflection.Assembly.GetExecutingAssembly(), GetType(Runtime.InteropServices.GuidAttribute))
                _GUID = CType(guid_attr, Runtime.InteropServices.GuidAttribute).Value
            End If

            Return _GUID
        End Get
    End Property
#End Region

#Region "程序版本"
    Private Shared _ProductVersion As String
    ''' <summary>
    ''' 程序版本
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property ProductVersion As String
        Get
            If String.IsNullOrEmpty(_ProductVersion) Then
                Dim assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location
                _ProductVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).ProductVersion
            End If

            Return _ProductVersion
        End Get
    End Property
#End Region

#Region "配置参数"
    ''' <summary>
    ''' 实例
    ''' </summary>
    Private Shared instance As AppSetting
    ''' <summary>
    ''' 参数
    ''' </summary>
    Public Shared ReadOnly Property Settings As AppSetting
        Get
            If instance Is Nothing Then

                LoadFromLocaltion()

                '初始化
                With instance
                    ''语言包
                    'Wangk.Resource.MultiLanguageHelper.Init(.SelectLang, My.Application.Info.Title)

                    ''日志
                    'Wangk.Tools.LoggerHelper.Init(saveDaysMax:=90)
                End With

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
            instance = JsonConvert.DeserializeObject(Of AppSetting)(
                System.IO.File.ReadAllText($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}\Data\Setting.json",
                                           System.Text.Encoding.UTF8))

        Catch ex As Exception
            '使用默认参数
            instance = New AppSetting

        End Try

        Try
            Dim tmpDirectoryInfo As New DirectoryInfo("./Data")
            If tmpDirectoryInfo.Exists Then
                For Each item In tmpDirectoryInfo.GetFiles()
                    Dim tmpProgramInfo = JsonConvert.DeserializeObject(Of ProgramInfo)(
                        System.IO.File.ReadAllText(item.FullName,
                                                   System.Text.Encoding.UTF8))
                    AppSettingHelper.Settings.ProgramItems.Add(tmpProgramInfo)
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

        Try
            System.IO.Directory.CreateDirectory("./Data")
            For Each item In AppSettingHelper.Settings.ProgramItems

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
    Public Shared Logger As NLog.Logger = NLog.LogManager.GetCurrentClassLogger()
#End Region

End Class
