<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadFixedStationData
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxNoData = New System.Windows.Forms.TextBox()
        Me.ButtonReadData = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxFields = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxInput = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxNumTimes = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxTrendField = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxScale = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 178)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 17)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Minimum valid value"
        '
        'TextBoxNoData
        '
        Me.TextBoxNoData.Location = New System.Drawing.Point(174, 173)
        Me.TextBoxNoData.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxNoData.Name = "TextBoxNoData"
        Me.TextBoxNoData.Size = New System.Drawing.Size(225, 22)
        Me.TextBoxNoData.TabIndex = 33
        Me.TextBoxNoData.Text = "-9999"
        '
        'ButtonReadData
        '
        Me.ButtonReadData.Location = New System.Drawing.Point(299, 308)
        Me.ButtonReadData.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonReadData.Name = "ButtonReadData"
        Me.ButtonReadData.Size = New System.Drawing.Size(100, 28)
        Me.ButtonReadData.TabIndex = 32
        Me.ButtonReadData.Text = "Read data"
        Me.ButtonReadData.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 89)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 17)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "first data field"
        '
        'ComboBoxFields
        '
        Me.ComboBoxFields.FormattingEnabled = True
        Me.ComboBoxFields.Location = New System.Drawing.Point(174, 82)
        Me.ComboBoxFields.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxFields.Name = "ComboBoxFields"
        Me.ComboBoxFields.Size = New System.Drawing.Size(225, 24)
        Me.ComboBoxFields.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 44)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 17)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Input"
        '
        'ComboBoxInput
        '
        Me.ComboBoxInput.FormattingEnabled = True
        Me.ComboBoxInput.Location = New System.Drawing.Point(174, 37)
        Me.ComboBoxInput.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxInput.Name = "ComboBoxInput"
        Me.ComboBoxInput.Size = New System.Drawing.Size(225, 24)
        Me.ComboBoxInput.TabIndex = 27
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 356)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(451, 26)
        Me.StatusStrip1.TabIndex = 35
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(154, 20)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 133)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 17)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Number of times"
        '
        'TextBoxNumTimes
        '
        Me.TextBoxNumTimes.Location = New System.Drawing.Point(174, 133)
        Me.TextBoxNumTimes.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxNumTimes.Name = "TextBoxNumTimes"
        Me.TextBoxNumTimes.Size = New System.Drawing.Size(225, 22)
        Me.TextBoxNumTimes.TabIndex = 36
        Me.TextBoxNumTimes.Text = "0"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(19, 313)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(183, 21)
        Me.CheckBox1.TabIndex = 38
        Me.CheckBox1.Text = "Apply log transformation"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 221)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 17)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Trend field (optional)"
        '
        'ComboBoxTrendField
        '
        Me.ComboBoxTrendField.FormattingEnabled = True
        Me.ComboBoxTrendField.Location = New System.Drawing.Point(174, 214)
        Me.ComboBoxTrendField.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxTrendField.Name = "ComboBoxTrendField"
        Me.ComboBoxTrendField.Size = New System.Drawing.Size(225, 24)
        Me.ComboBoxTrendField.TabIndex = 39
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 269)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 17)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Scale factor"
        '
        'TextBoxScale
        '
        Me.TextBoxScale.Location = New System.Drawing.Point(174, 264)
        Me.TextBoxScale.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxScale.Name = "TextBoxScale"
        Me.TextBoxScale.Size = New System.Drawing.Size(225, 22)
        Me.TextBoxScale.TabIndex = 41
        Me.TextBoxScale.Text = "1"
        '
        'ReadFixedStationData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 382)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxScale)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBoxTrendField)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxNumTimes)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxNoData)
        Me.Controls.Add(Me.ButtonReadData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBoxFields)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBoxInput)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ReadFixedStationData"
        Me.Text = "ReadFixedStationData"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoData As System.Windows.Forms.TextBox
    Friend WithEvents ButtonReadData As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxFields As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxInput As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNumTimes As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBoxTrendField As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxScale As TextBox
End Class
