Imports System.IO
Imports System.Net
Imports System.Reflection.Emit
Imports System.Threading

Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.operationErrorCode = 1 Then
            Button1.Visible = False
            Label1.Location = New Point(23, 46)
            Label1.Text = "Internet is required for first-time install."
        End If
        If Form1.operationErrorCode = 2 Then
            Button1.Visible = False
            Label1.Location = New Point(16, 46)
            Label1.Text = "Failed to perform update. Please try again."
        End If
        If Form1.operationErrorCode = 3 Then
            Button1.Visible = False
            Label1.Location = New Point(36, 46)
            Label1.Text = "Failed to delete selected modpack."
        End If
        If Form1.operationErrorCode = 4 Then
            Button1.Visible = True
            Button1.Enabled = True
            Label1.Location = New Point(12, 9)
            Label1.Text = "UgliLauncher Updater needs an update." & Environment.NewLine & Environment.NewLine & Environment.NewLine & "If you keep seeing this even after updating," & Environment.NewLine & "make sure you're starting the launcher via" & Environment.NewLine & "the desktop shortcut or windows search."
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Thread.Sleep(1000)
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim targetFile As String = Path.Combine(appDataPath, "UgliLauncher\content\UpdateUgliUpdater.bat")
        If IO.File.Exists(targetFile) Then
            IO.File.Delete(targetFile)
        End If
        Try
            Using client As New WebClient()
                client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/UpdateUgliUpdater.bat", targetFile)
                Dim startInfo As New ProcessStartInfo()
                startInfo.FileName = targetFile
                startInfo.UseShellExecute = True
                startInfo.Verb = "runas"
                Process.Start(startInfo)
                Application.Exit()
            End Using
        Catch ex As Exception
            Button1.Visible = False
            Label1.Location = New Point(16, 46)
            Label1.Text = "Failed to perform update. Please try again."
        End Try
    End Sub
End Class