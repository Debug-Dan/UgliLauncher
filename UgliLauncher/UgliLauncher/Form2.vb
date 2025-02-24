Imports System.DirectoryServices.ActiveDirectory
Imports System.IO
Imports System.Net
Imports System.Net.WebRequestMethods
Imports System.Text.Json
Imports System.Text.Json.Nodes
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ExplorerBar

Public Class Form2
    Private Async Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Checking..."
        ProgressBar1.Value = 0
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim targetDirectory As String
        Dim targetFile As String = Path.Combine(appDataPath, "UgliLauncher\Minecraft.exe")
        Dim currentVersion As String
        Dim localVersion As String
        Dim localCheck As String
        If Not IO.File.Exists(targetFile) Then
            Try
                Using client As New WebClient()
                    Await Task.Run(Sub() client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/Minecraft.exe", targetFile))
                End Using
            Catch ex As Exception
                Form1.operationErrorCode = 1
                Dim form3 As New Form3()
                form3.Owner = Form1
                form3.StartPosition = FormStartPosition.CenterParent
                form3.ShowDialog()
                Me.Close()
                Return
            End Try
        End If

        If Form1.selectedModpack = 1 Then ' TST 2 modpack
            targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\TST2\mods")
            If Not Directory.Exists(targetDirectory) Then
                Label1.Text = "Installing..."
                targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\TST2")
                If Directory.Exists(targetDirectory) Then
                    Await Task.Run(Sub() Directory.Delete(targetDirectory, True))
                End If
                Directory.CreateDirectory(targetDirectory)
                Try
                    Using client As New WebClient()
                        targetFile = Path.Combine(targetDirectory, "InstallArchive.zip")
                        Await Task.Run(Sub() client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/TST2-main.zip", targetFile))
                        ProgressBar1.Value = 100
                        Await Task.Run(Sub() Compression.ZipFile.ExtractToDirectory(targetFile, targetDirectory))
                        Await Task.Run(Sub() IO.File.Delete(targetFile))
                    End Using
                Catch ex As Exception
                    Form1.operationErrorCode = 1
                    Dim form3 As New Form3()
                    form3.Owner = Form1
                    form3.StartPosition = FormStartPosition.CenterParent
                    form3.ShowDialog()
                    Me.Close()
                    Return
                End Try
            End If
            targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\TST2")
            Label1.Text = "Checking..."
            ProgressBar1.Value = 100
            Try
                Using client As New WebClient()
                    targetFile = Path.Combine(targetDirectory, "CurrentVersion.txt")
                    localCheck = Path.Combine(targetDirectory, "LocalVersion.txt")
                    Await Task.Run(Sub() client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/TST2-CV.txt", targetFile))
                    currentVersion = IO.File.ReadAllText(targetFile)
                    If IO.File.Exists(localCheck) Then
                        localVersion = IO.File.ReadAllText(localCheck)
                    Else
                        localVersion = "none"
                    End If
                End Using
            Catch ex As Exception
                currentVersion = "unknown"
                localVersion = "none"
            End Try
            If Not currentVersion = "unknown" Then
                If Not currentVersion.Trim() = localVersion.Trim() Then
                    Label1.Text = "Updating..."
                    ProgressBar1.Value = 0
                    Try
                        Using client As New WebClient()
                            targetFile = Path.Combine(targetDirectory, "UpdateArchive.zip")
                            Dim modsFolder As String = Path.Combine(targetDirectory, "mods")
                            Await Task.Run(Sub() client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/TST2-mods.zip", targetFile))
                            If Directory.Exists(modsFolder) Then
                                Await Task.Run(Sub() Directory.Delete(modsFolder, True))
                            End If
                            ProgressBar1.Value = 100
                            Dim launcherProfile As String = Path.Combine(targetDirectory, "launcher_profiles.json")
                            If IO.File.Exists(launcherProfile) Then
                                Await Task.Run(Sub() IO.File.Delete(launcherProfile))
                            End If
                            Await Task.Run(Sub() Compression.ZipFile.ExtractToDirectory(targetFile, targetDirectory))
                            Await Task.Run(Sub() IO.File.Delete(targetFile))
                        End Using
                    Catch ex As Exception
                        Form1.operationErrorCode = 2
                        Dim form3 As New Form3()
                        form3.Owner = Form1
                        form3.StartPosition = FormStartPosition.CenterParent
                        form3.ShowDialog()
                        Me.Close()
                        Return
                    End Try
                    targetFile = Path.Combine(targetDirectory, "CurrentVersion.txt")
                    localCheck = Path.Combine(targetDirectory, "LocalVersion.txt")
                    Await Task.Run(Sub() IO.File.Delete(localCheck))
                    Await Task.Run(Sub() IO.File.Move(targetFile, localCheck))
                Else
                    targetFile = Path.Combine(targetDirectory, "CurrentVersion.txt")
                    Await Task.Run(Sub() IO.File.Delete(targetFile))
                End If
            End If
            If Form1.CheckBox1.Checked = True Then
                targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\TST2\config\jei")
                If Directory.Exists(targetDirectory) Then
                    Await Task.Run(Sub() Directory.Delete(targetDirectory, True))
                End If
            End If
            targetFile = Path.Combine(appDataPath, "UgliLauncher\instances\TST2\config\xaeroworldmap.txt")
            If IO.File.Exists(targetFile) Then
                Dim lines As List(Of String) = IO.File.ReadAllLines(targetFile).ToList()
                For i As Integer = 0 To lines.Count - 1
                    If lines(i) = "updateNotification:true" Then
                        lines(i) = "updateNotification:false"
                    End If
                    If lines(i) = "allowInternetAccess:true" Then
                        lines(i) = "allowInternetAccess:false"
                    End If
                Next
                IO.File.WriteAllLines(targetFile, lines)
            End If
            targetFile = Path.Combine(appDataPath, "UgliLauncher\instances\TST2\config\xaerominimap.txt")
            If IO.File.Exists(targetFile) Then
                Dim lines As List(Of String) = IO.File.ReadAllLines(targetFile).ToList()
                For i As Integer = 0 To lines.Count - 1
                    If lines(i) = "updateNotification:true" Then
                        lines(i) = "updateNotification:false"
                    End If
                    If lines(i) = "allowInternetAccess:true" Then
                        lines(i) = "allowInternetAccess:false"
                    End If
                Next
                IO.File.WriteAllLines(targetFile, lines)
            End If
            targetFile = Path.Combine(appDataPath, "UgliLauncher\instances\TST2\config\securitycraft-client.toml")
            If IO.File.Exists(targetFile) Then
                Dim lines As List(Of String) = IO.File.ReadAllLines(targetFile).ToList()
                For i As Integer = 0 To lines.Count - 1
                    If lines(i) = "sayThanksMessage = true" Then
                        lines(i) = "sayThanksMessage = false"
                    End If
                Next
                IO.File.WriteAllLines(targetFile, lines)
            End If
            targetFile = Path.Combine(appDataPath, "UgliLauncher\instances\TST2\servers.dat")
            Try
                Using client As New WebClient()
                    Await Task.Run(Sub() client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/servers.dat", targetFile))
                End Using
            Catch ex As Exception
            End Try
            targetFile = Path.Combine(appDataPath, "UgliLauncher\Minecraft.exe")
            targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\TST2")
            Dim launcherQuickPlay As String = Path.Combine(targetDirectory, "launcher_quick_play.json")
            If IO.File.Exists(launcherQuickPlay) Then
                Await Task.Run(Sub() IO.File.Delete(launcherQuickPlay))
            End If
            Dim startMC As New ProcessStartInfo()
            startMC.FileName = targetFile
            startMC.Arguments = "--workDir """ & targetDirectory & """"
            startMC.UseShellExecute = True
            Process.Start(startMC)
            Me.Close()
            Form1.Close()
            Return
        End If

        If Form1.selectedModpack = 2 Then ' Optimized Vanilla modpack
            targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\OV\mods")
            If Not Directory.Exists(targetDirectory) Then
                Label1.Text = "Installing..."
                targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\OV")
                If Directory.Exists(targetDirectory) Then
                    Await Task.Run(Sub() Directory.Delete(targetDirectory, True))
                End If
                Directory.CreateDirectory(targetDirectory)
                Try
                    Using client As New WebClient()
                        targetFile = Path.Combine(targetDirectory, "InstallArchive.zip")
                        Await Task.Run(Sub() client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/OV-main.zip", targetFile))
                        ProgressBar1.Value = 100
                        Await Task.Run(Sub() Compression.ZipFile.ExtractToDirectory(targetFile, targetDirectory))
                        Await Task.Run(Sub() IO.File.Delete(targetFile))
                    End Using
                Catch ex As Exception
                    Form1.operationErrorCode = 1
                    Dim form3 As New Form3()
                    form3.Owner = Form1
                    form3.StartPosition = FormStartPosition.CenterParent
                    form3.ShowDialog()
                    Me.Close()
                    Return
                End Try
            End If
            targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\OV")
            Label1.Text = "Checking..."
            ProgressBar1.Value = 100
            Try
                Using client As New WebClient()
                    targetFile = Path.Combine(targetDirectory, "CurrentVersion.txt")
                    localCheck = Path.Combine(targetDirectory, "LocalVersion.txt")
                    Await Task.Run(Sub() client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/OV-CV.txt", targetFile))
                    currentVersion = IO.File.ReadAllText(targetFile)
                    If IO.File.Exists(localCheck) Then
                        localVersion = IO.File.ReadAllText(localCheck)
                    Else
                        localVersion = "none"
                    End If
                End Using
            Catch ex As Exception
                currentVersion = "unknown"
                localVersion = "none"
            End Try
            If Not currentVersion = "unknown" Then
                If Not currentVersion.Trim() = localVersion.Trim() Then
                    Label1.Text = "Updating..."
                    ProgressBar1.Value = 0
                    Try
                        Using client As New WebClient()
                            targetFile = Path.Combine(targetDirectory, "UpdateArchive.zip")
                            Dim modsFolder As String = Path.Combine(targetDirectory, "mods")
                            Await Task.Run(Sub() client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/OV-mods.zip", targetFile))
                            If Directory.Exists(modsFolder) Then
                                Await Task.Run(Sub() Directory.Delete(modsFolder, True))
                            End If
                            ProgressBar1.Value = 100
                            Dim launcherProfile As String = Path.Combine(targetDirectory, "launcher_profiles.json")
                            If IO.File.Exists(launcherProfile) Then
                                Await Task.Run(Sub() IO.File.Delete(launcherProfile))
                            End If
                            Await Task.Run(Sub() Compression.ZipFile.ExtractToDirectory(targetFile, targetDirectory))
                            Await Task.Run(Sub() IO.File.Delete(targetFile))
                        End Using
                    Catch ex As Exception
                        Form1.operationErrorCode = 2
                        Dim form3 As New Form3()
                        form3.Owner = Form1
                        form3.StartPosition = FormStartPosition.CenterParent
                        form3.ShowDialog()
                        Me.Close()
                        Return
                    End Try
                    targetFile = Path.Combine(targetDirectory, "CurrentVersion.txt")
                    localCheck = Path.Combine(targetDirectory, "LocalVersion.txt")
                    Await Task.Run(Sub() IO.File.Delete(localCheck))
                    Await Task.Run(Sub() IO.File.Move(targetFile, localCheck))
                Else
                    targetFile = Path.Combine(targetDirectory, "CurrentVersion.txt")
                    Await Task.Run(Sub() IO.File.Delete(targetFile))
                End If
            End If
            targetFile = Path.Combine(appDataPath, "UgliLauncher\instances\OV\config\coordinatesdisplay.json")
            Try
                Using client As New WebClient()
                    Await Task.Run(Sub() client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/coordinatesdisplay.json", targetFile))
                End Using
            Catch ex As Exception
            End Try
            targetFile = Path.Combine(appDataPath, "UgliLauncher\instances\OV\servers.dat")
            Try
                Using client As New WebClient()
                    Await Task.Run(Sub() client.DownloadFile("https://github.com/Debug-Dan/UgliLauncher/releases/download/Files/servers.dat", targetFile))
                End Using
            Catch ex As Exception
            End Try
            targetFile = Path.Combine(appDataPath, "UgliLauncher\Minecraft.exe")
            targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\OV")
            Dim launcherQuickPlay As String = Path.Combine(targetDirectory, "launcher_quick_play.json")
            If IO.File.Exists(launcherQuickPlay) Then
                Await Task.Run(Sub() IO.File.Delete(launcherQuickPlay))
            End If
            Dim startMC As New ProcessStartInfo()
            startMC.FileName = targetFile
            startMC.Arguments = "--workDir """ & targetDirectory & """"
            startMC.UseShellExecute = True
            Process.Start(startMC)
            Me.Close()
            Form1.Close()
            Return
        End If
    End Sub
End Class