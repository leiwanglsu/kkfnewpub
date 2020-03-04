<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKKFParameter
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxTransit = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxInitError = New System.Windows.Forms.TextBox()
        Me.TextBoxInitState = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonEM = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxTransit)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBoxInitError)
        Me.GroupBox1.Controls.Add(Me.TextBoxInitState)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(524, 235)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameters"
        '
        'TextBoxTransit
        '
        Me.TextBoxTransit.Location = New System.Drawing.Point(272, 138)
        Me.TextBoxTransit.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxTransit.Name = "TextBoxTransit"
        Me.TextBoxTransit.Size = New System.Drawing.Size(132, 22)
        Me.TextBoxTransit.TabIndex = 8
        Me.TextBoxTransit.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 142)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Transit slope"
        '
        'TextBoxInitError
        '
        Me.TextBoxInitError.Location = New System.Drawing.Point(272, 88)
        Me.TextBoxInitError.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxInitError.Name = "TextBoxInitError"
        Me.TextBoxInitError.Size = New System.Drawing.Size(132, 22)
        Me.TextBoxInitError.TabIndex = 6
        Me.TextBoxInitError.Text = "1"
        '
        'TextBoxInitState
        '
        Me.TextBoxInitState.Location = New System.Drawing.Point(272, 44)
        Me.TextBoxInitState.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxInitState.Name = "TextBoxInitState"
        Me.TextBoxInitState.Size = New System.Drawing.Size(132, 22)
        Me.TextBoxInitState.TabIndex = 5
        Me.TextBoxInitState.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(51, 92)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Initial noise term "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 53)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Initial state "
        '
        'ButtonEM
        '
        Me.ButtonEM.Location = New System.Drawing.Point(199, 299)
        Me.ButtonEM.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonEM.Name = "ButtonEM"
        Me.ButtonEM.Size = New System.Drawing.Size(143, 36)
        Me.ButtonEM.TabIndex = 31
        Me.ButtonEM.Text = "OK"
        Me.ButtonEM.UseVisualStyleBackColor = True
        '
        'FormKKFParameter
        '
        Me.AcceptButton = Me.ButtonEM
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 364)
        Me.Controls.Add(Me.ButtonEM)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormKKFParameter"
        Me.Text = "FormKKFParameter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxInitError As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxInitState As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonEM As System.Windows.Forms.Button
    Friend WithEvents TextBoxTransit As TextBox
    Friend WithEvents Label1 As Label
End Class
