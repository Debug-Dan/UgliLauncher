<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Label2 = New Label()
        Label3 = New Label()
        Label1 = New Label()
        Button2 = New Button()
        Button3 = New Button()
        Button1 = New Button()
        Label4 = New Label()
        CheckBox1 = New CheckBox()
        Panel1 = New Panel()
        Label6 = New Label()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        CheckBox2 = New CheckBox()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(194, 27)
        Label2.Name = "Label2"
        Label2.Size = New Size(31, 15)
        Label2.TabIndex = 1
        Label2.Text = "1.6.4"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(12, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(186, 37)
        Label3.TabIndex = 2
        Label3.Text = "UgliLauncher"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(32, 63)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 30)
        Label1.TabIndex = 4
        Label1.Text = "TST 2"
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(32, 96)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 5
        Button2.Text = "Install"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Enabled = False
        Button3.Location = New Point(113, 96)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 6
        Button3.Text = "Open Files"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Enabled = False
        Button1.Location = New Point(194, 96)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 7
        Button1.Text = "Delete"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.Font = New Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(53, 0)
        Label4.Name = "Label4"
        Label4.RightToLeft = RightToLeft.No
        Label4.Size = New Size(322, 15)
        Label4.TabIndex = 8
        Label4.Text = "Failed to retrieve update log................"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBox1.Location = New Point(41, 125)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(227, 17)
        CheckBox1.TabIndex = 10
        CheckBox1.Text = "Fix Create items missing from JEI search"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(Label4)
        Panel1.Location = New Point(289, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(375, 369)
        Panel1.TabIndex = 12
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(32, 154)
        Label6.Name = "Label6"
        Label6.Size = New Size(175, 30)
        Label6.TabIndex = 13
        Label6.Text = "Optimized Vanilla"
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(32, 187)
        Button4.Name = "Button4"
        Button4.Size = New Size(75, 23)
        Button4.TabIndex = 14
        Button4.Text = "Install"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(113, 187)
        Button5.Name = "Button5"
        Button5.Size = New Size(75, 23)
        Button5.TabIndex = 15
        Button5.Text = "Open Files"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(194, 187)
        Button6.Name = "Button6"
        Button6.Size = New Size(75, 23)
        Button6.TabIndex = 16
        Button6.Text = "Delete"
        Button6.UseVisualStyleBackColor = True
        ' 
        ' CheckBox2
        ' 
        CheckBox2.AutoSize = True
        CheckBox2.Checked = True
        CheckBox2.CheckState = CheckState.Checked
        CheckBox2.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBox2.Location = New Point(41, 216)
        CheckBox2.Name = "CheckBox2"
        CheckBox2.Size = New Size(207, 17)
        CheckBox2.TabIndex = 17
        CheckBox2.Text = "Set some options to server defaults"
        CheckBox2.UseVisualStyleBackColor = True
        CheckBox2.Visible = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(676, 393)
        Controls.Add(CheckBox2)
        Controls.Add(Button6)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Label6)
        Controls.Add(Panel1)
        Controls.Add(CheckBox1)
        Controls.Add(Button1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Label1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        ForeColor = SystemColors.ControlText
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "UgliLauncher"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents CheckBox2 As CheckBox

End Class
