Imports System.IO
Imports System.Reflection.Emit

Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Button1.Text = "Delete"
        CheckBox1.Checked = False
        CheckBox1.Enabled = True
        If Form1.selectedModpack = 1 Then
            Label3.Text = "TST 2"
        End If
        If Form1.selectedModpack = 2 Then
            Label3.Text = "Optimized Vanilla"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        CheckBox1.Enabled = False
        Button1.Text = "Deleting..."
        Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim targetDirectory As String
        If Form1.selectedModpack = 1 Then
            targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\TST2")
            If Directory.Exists(targetDirectory) Then
                Await Task.Run(Sub() Directory.Delete(targetDirectory, True))
            Else
                Form1.operationErrorCode = 3
                Dim form3 As New Form3()
                form3.Owner = Form1
                form3.StartPosition = FormStartPosition.CenterParent
                form3.ShowDialog()
                Me.Close()
                Return
            End If
        End If
        If Form1.selectedModpack = 2 Then
            targetDirectory = Path.Combine(appDataPath, "UgliLauncher\instances\OV")
            If Directory.Exists(targetDirectory) Then
                Await Task.Run(Sub() Directory.Delete(targetDirectory, True))
            Else
                Form1.operationErrorCode = 3
                Dim form3 As New Form3()
                form3.Owner = Form1
                form3.StartPosition = FormStartPosition.CenterParent
                form3.ShowDialog()
                Me.Close()
                Return
            End If
        End If
        Me.Close()
        Form1.Close()
        Return
    End Sub
End Class