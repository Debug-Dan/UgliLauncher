Imports System.IO
Imports System.Net
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class Form1
    Public selectedModpack As Integer
    Public operationErrorCode As Integer
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim targetFile As String = "null"
        If Not Environment.GetCommandLineArgs().Contains("--ignoreCheck") Then
            If Not Environment.GetCommandLineArgs().Contains("--ignoreUpdate2") Then ' Change number to current updater version
                operationErrorCode = 4
                Dim form3 As New Form3()
                form3.Owner = Me
                form3.StartPosition = FormStartPosition.CenterParent
                form3.ShowDialog()
                Me.Close()
            End If
        End If
        CheckBox2.Checked = True
        Dim targetDirectory As String = Path.Combine(appDataPath, "UgliLauncher\instances\TST2\mods")
        Panel1.Controls.Add(Label4)
        If Directory.Exists(targetDirectory) Then
            Button2.Text = "Launch"
            Button3.Enabled = True
            Button1.Enabled = True
        Else
            Button2.Text = "Install"
            Button3.Enabled = False
            Button1.Enabled = False
        End If
        CheckBox1.Checked = False
        targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\OV\mods")
        If Directory.Exists(targetDirectory) Then
            Button4.Text = "Launch"
            Button5.Enabled = True
            Button6.Enabled = True
        Else
            Button4.Text = "Install"
            Button5.Enabled = False
            Button6.Enabled = False
        End If
        targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\TST3\mods")
        If Directory.Exists(targetDirectory) Then
            Button7.Text = "Launch"
            Button8.Enabled = True
            Button9.Enabled = True
        Else
            Button7.Text = "Install"
            Button8.Enabled = False
            Button9.Enabled = False
        End If
        CheckBox1.Checked = False
        targetFile = Path.Combine(appDataPath, "UgliLauncher\loc.txt")
        If IO.File.Exists(targetFile) Then
            Await Task.Run(Sub() IO.File.Delete(targetFile))
        End If
        targetFile = Path.Combine(appDataPath, "UgliLauncher\content.bat")
        If IO.File.Exists(targetFile) Then
            Await Task.Run(Sub() IO.File.Delete(targetFile))
        End If
        Try
            Using client As New WebClient()
                targetFile = Path.Combine(appDataPath, "UgliLauncher\updatelist.txt")
                client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/updatelist.txt", targetFile)
                Label4.Text = IO.File.ReadAllText(targetFile)
            End Using
        Catch ex As Exception
            Label4.Text = "Failed to retrieve update list."
        End Try
        targetFile = Path.Combine(appDataPath, "UgliLauncher\instances\OV\SetDefaults.txt") ' Checks if file exists for setting server options
        If IO.File.Exists(targetFile) Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        selectedModpack = 1
        Dim form2 As New Form2()
        form2.Owner = Me
        form2.StartPosition = FormStartPosition.CenterParent
        form2.ShowDialog()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\TST2")
        If Directory.Exists(targetDirectory) Then
            Process.Start("explorer.exe", targetDirectory)
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        selectedModpack = 1
        Dim form4 As New Form4()
        form4.Owner = Me
        form4.StartPosition = FormStartPosition.CenterParent
        form4.ShowDialog()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        selectedModpack = 2
        Dim form2 As New Form2()
        form2.Owner = Me
        form2.StartPosition = FormStartPosition.CenterParent
        form2.ShowDialog()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\OV")
        If Directory.Exists(targetDirectory) Then
            Process.Start("explorer.exe", targetDirectory)
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        selectedModpack = 2
        Dim form4 As New Form4()
        form4.Owner = Me
        form4.StartPosition = FormStartPosition.CenterParent
        form4.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        selectedModpack = 3
        Dim form2 As New Form2()
        form2.Owner = Me
        form2.StartPosition = FormStartPosition.CenterParent
        form2.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\TST3")
        If Directory.Exists(targetDirectory) Then
            Process.Start("explorer.exe", targetDirectory)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        selectedModpack = 3
        Dim form4 As New Form4()
        form4.Owner = Me
        form4.StartPosition = FormStartPosition.CenterParent
        form4.ShowDialog()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Process.Start(New ProcessStartInfo("https://github.com/Debug-Dan/UgliLauncher/releases/download/Latest/UgliLauncher.bat") With {.UseShellExecute = True})
    End Sub
End Class