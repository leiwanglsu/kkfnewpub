<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCovariogram
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ComboBoxFunction1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonReady = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyAllTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonRead = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.ComboBoxFunction2 = New System.Windows.Forms.ComboBox()
        Me.TextBoxSill = New System.Windows.Forms.TextBox()
        Me.TextBoxNuget = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxRange = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ButtonCreate = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxRangefactor = New System.Windows.Forms.TextBox()
        Me.ButtonFit = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 38)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Bin size"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(152, 30)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(225, 22)
        Me.TextBox2.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 78)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 17)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Number of bins"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(152, 69)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(225, 22)
        Me.TextBox3.TabIndex = 11
        '
        'ComboBoxFunction1
        '
        Me.ComboBoxFunction1.FormattingEnabled = True
        Me.ComboBoxFunction1.Items.AddRange(New Object() {"Gaussian", "Linear", "Spherical", "Exponential"})
        Me.ComboBoxFunction1.Location = New System.Drawing.Point(152, 146)
        Me.ComboBoxFunction1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboBoxFunction1.Name = "ComboBoxFunction1"
        Me.ComboBoxFunction1.Size = New System.Drawing.Size(225, 24)
        Me.ComboBoxFunction1.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 153)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Function"
        '
        'ButtonReady
        '
        Me.ButtonReady.Location = New System.Drawing.Point(401, 117)
        Me.ButtonReady.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonReady.Name = "ButtonReady"
        Me.ButtonReady.Size = New System.Drawing.Size(100, 28)
        Me.ButtonReady.TabIndex = 18
        Me.ButtonReady.Text = "Variograph"
        Me.ButtonReady.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(821, 331)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(100, 28)
        Me.ButtonCancel.TabIndex = 21
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOk
        '
        Me.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOk.Location = New System.Drawing.Point(627, 331)
        Me.ButtonOk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(100, 28)
        Me.ButtonOk.TabIndex = 22
        Me.ButtonOk.Text = "Confirm"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyAllTextToolStripMenuItem, Me.ClearTextToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(162, 52)
        '
        'CopyAllTextToolStripMenuItem
        '
        Me.CopyAllTextToolStripMenuItem.Name = "CopyAllTextToolStripMenuItem"
        Me.CopyAllTextToolStripMenuItem.Size = New System.Drawing.Size(161, 24)
        Me.CopyAllTextToolStripMenuItem.Text = "Copy all text"
        '
        'ClearTextToolStripMenuItem
        '
        Me.ClearTextToolStripMenuItem.Name = "ClearTextToolStripMenuItem"
        Me.ClearTextToolStripMenuItem.Size = New System.Drawing.Size(161, 24)
        Me.ClearTextToolStripMenuItem.Text = "Clear text"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonRead)
        Me.GroupBox1.Controls.Add(Me.ButtonSave)
        Me.GroupBox1.Controls.Add(Me.ComboBoxFunction2)
        Me.GroupBox1.Controls.Add(Me.TextBoxSill)
        Me.GroupBox1.Controls.Add(Me.TextBoxNuget)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TextBoxRange)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.ButtonCreate)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(547, 30)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(416, 277)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Variogram function"
        '
        'ButtonRead
        '
        Me.ButtonRead.Location = New System.Drawing.Point(259, 39)
        Me.ButtonRead.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonRead.Name = "ButtonRead"
        Me.ButtonRead.Size = New System.Drawing.Size(100, 28)
        Me.ButtonRead.TabIndex = 60
        Me.ButtonRead.Text = "Read"
        Me.ButtonRead.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(151, 39)
        Me.ButtonSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(100, 28)
        Me.ButtonSave.TabIndex = 59
        Me.ButtonSave.Text = "Save"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'ComboBoxFunction2
        '
        Me.ComboBoxFunction2.FormattingEnabled = True
        Me.ComboBoxFunction2.Items.AddRange(New Object() {"Gaussian", "Linear", "Spherical", "Exponential"})
        Me.ComboBoxFunction2.Location = New System.Drawing.Point(113, 87)
        Me.ComboBoxFunction2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ComboBoxFunction2.Name = "ComboBoxFunction2"
        Me.ComboBoxFunction2.Size = New System.Drawing.Size(275, 24)
        Me.ComboBoxFunction2.TabIndex = 50
        '
        'TextBoxSill
        '
        Me.TextBoxSill.Location = New System.Drawing.Point(113, 178)
        Me.TextBoxSill.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBoxSill.Name = "TextBoxSill"
        Me.TextBoxSill.Size = New System.Drawing.Size(177, 22)
        Me.TextBoxSill.TabIndex = 51
        Me.TextBoxSill.Text = "0.25"
        '
        'TextBoxNuget
        '
        Me.TextBoxNuget.Location = New System.Drawing.Point(113, 138)
        Me.TextBoxNuget.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBoxNuget.Name = "TextBoxNuget"
        Me.TextBoxNuget.Size = New System.Drawing.Size(177, 22)
        Me.TextBoxNuget.TabIndex = 55
        Me.TextBoxNuget.Text = "0.045"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 91)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 17)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Function"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(39, 223)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 17)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "a"
        '
        'TextBoxRange
        '
        Me.TextBoxRange.Location = New System.Drawing.Point(113, 214)
        Me.TextBoxRange.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBoxRange.Name = "TextBoxRange"
        Me.TextBoxRange.Size = New System.Drawing.Size(177, 22)
        Me.TextBoxRange.TabIndex = 52
        Me.TextBoxRange.Text = "0.247"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(37, 142)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 17)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "C0"
        '
        'ButtonCreate
        '
        Me.ButtonCreate.Location = New System.Drawing.Point(43, 39)
        Me.ButtonCreate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonCreate.Name = "ButtonCreate"
        Me.ButtonCreate.Size = New System.Drawing.Size(100, 28)
        Me.ButtonCreate.TabIndex = 57
        Me.ButtonCreate.Text = "Create"
        Me.ButtonCreate.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(37, 187)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 17)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "C"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(45, 197)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(455, 267)
        Me.RichTextBox1.TabIndex = 62
        Me.RichTextBox1.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 117)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 17)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "Range factor"
        '
        'TextBoxRangefactor
        '
        Me.TextBoxRangefactor.Location = New System.Drawing.Point(149, 113)
        Me.TextBoxRangefactor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBoxRangefactor.Name = "TextBoxRangefactor"
        Me.TextBoxRangefactor.Size = New System.Drawing.Size(225, 22)
        Me.TextBoxRangefactor.TabIndex = 63
        Me.TextBoxRangefactor.Text = "1"
        '
        'ButtonFit
        '
        Me.ButtonFit.Location = New System.Drawing.Point(401, 153)
        Me.ButtonFit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonFit.Name = "ButtonFit"
        Me.ButtonFit.Size = New System.Drawing.Size(100, 28)
        Me.ButtonFit.TabIndex = 65
        Me.ButtonFit.Text = "Fit"
        Me.ButtonFit.UseVisualStyleBackColor = True
        '
        'FormCovariogram
        '
        Me.AcceptButton = Me.ButtonOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(1065, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonFit)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBoxRangefactor)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonOk)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ButtonReady)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxFunction1)
        Me.Controls.Add(Me.TextBox3)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormCovariogram"
        Me.Text = "Covariogram"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxFunction1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonReady As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyAllTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents ComboBoxFunction2 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxSill As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNuget As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRange As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ButtonCreate As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ButtonRead As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRangefactor As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFit As System.Windows.Forms.Button
End Class
