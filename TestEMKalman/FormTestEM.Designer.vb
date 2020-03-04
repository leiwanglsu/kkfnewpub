<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTestEM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTestEM))
        Me.TextBoxOutput = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonIterate = New System.Windows.Forms.Button()
        Me.ButtonInitialize = New System.Windows.Forms.Button()
        Me.TextBoxObservation = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBoxOutput
        '
        Me.TextBoxOutput.Location = New System.Drawing.Point(350, 42)
        Me.TextBoxOutput.Multiline = True
        Me.TextBoxOutput.Name = "TextBoxOutput"
        Me.TextBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxOutput.Size = New System.Drawing.Size(293, 415)
        Me.TextBoxOutput.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(790, 45)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 22)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = "2500"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(790, 98)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 22)
        Me.TextBox4.TabIndex = 3
        Me.TextBox4.Text = "1.1"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(790, 151)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 22)
        Me.TextBox5.TabIndex = 4
        Me.TextBox5.Text = "100"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(695, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "u"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(695, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "phi"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(695, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "e"
        '
        'ButtonIterate
        '
        Me.ButtonIterate.Location = New System.Drawing.Point(790, 302)
        Me.ButtonIterate.Name = "ButtonIterate"
        Me.ButtonIterate.Size = New System.Drawing.Size(75, 23)
        Me.ButtonIterate.TabIndex = 8
        Me.ButtonIterate.Text = "Iterate"
        Me.ButtonIterate.UseVisualStyleBackColor = True
        '
        'ButtonInitialize
        '
        Me.ButtonInitialize.Location = New System.Drawing.Point(790, 252)
        Me.ButtonInitialize.Name = "ButtonInitialize"
        Me.ButtonInitialize.Size = New System.Drawing.Size(75, 23)
        Me.ButtonInitialize.TabIndex = 9
        Me.ButtonInitialize.Text = "Initialize"
        Me.ButtonInitialize.UseVisualStyleBackColor = True
        '
        'TextBoxObservation
        '
        Me.TextBoxObservation.Location = New System.Drawing.Point(27, 42)
        Me.TextBoxObservation.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxObservation.Multiline = True
        Me.TextBoxObservation.Name = "TextBoxObservation"
        Me.TextBoxObservation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxObservation.Size = New System.Drawing.Size(292, 415)
        Me.TextBoxObservation.TabIndex = 23
        Me.TextBoxObservation.Text = resources.GetString("TextBoxObservation.Text")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(695, 210)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 17)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "NoData"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(790, 207)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 24
        Me.TextBox1.Text = "-9999"
        '
        'FormTestEM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 508)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBoxObservation)
        Me.Controls.Add(Me.ButtonInitialize)
        Me.Controls.Add(Me.ButtonIterate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBoxOutput)
        Me.Name = "FormTestEM"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxOutput As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonIterate As Button
    Friend WithEvents ButtonInitialize As Button
    Friend WithEvents TextBoxObservation As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
End Class
