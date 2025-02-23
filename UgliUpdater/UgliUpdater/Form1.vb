Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net
Imports System.Threading

Public Class Form1
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Checking for updates..."
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim workingFolder As String = Path.Combine(appDataPath, "UgliLauncher\content")
        Dim workingFile As String = Path.Combine(appDataPath, "UgliLauncher\content\UgliLauncher.exe")
        Dim workingTempFile As String = Path.Combine(appDataPath, "UgliLauncher\content\temp.exe")
        Dim updateFlag As String = "--ignoreUpdate2" ' Change the number when introducing an update you want pushed out to clients
        Thread.Sleep(1000)
        If Not Directory.Exists(workingFolder) Then
            Directory.CreateDirectory(workingFolder)
        End If
        If File.Exists(workingTempFile) Then
            File.Delete(workingTempFile)
        End If
        Dim client As New WebClient()
        Try
            Await Task.Run(Sub() client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/UgliLauncher.exe", workingTempFile))
        Catch ex As Exception
            Process.Start(workingFile, updateFlag)
            Me.Close()
            Return
        End Try
        If File.Exists(workingFile) Then
            File.Delete(workingFile)
        End If
        File.Move(workingTempFile, workingFile)
        Process.Start(workingFile, updateFlag)
        Me.Close()
        Return
    End Sub
End Class
