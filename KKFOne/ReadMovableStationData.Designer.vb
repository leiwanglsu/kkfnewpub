<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadMovableStationData
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
        Me.TextBoxNLayers = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxFieldName = New System.Windows.Forms.TextBox()
        Me.ButtonReadData = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxNoData = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxNLayers
        '
        Me.TextBoxNLayers.Location = New System.Drawing.Point(192, 75)
        Me.TextBoxNLayers.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBoxNLayers.Name = "TextBoxNLayers"
        Me.TextBoxNLayers.Size = New System.Drawing.Size(225, 22)
        Me.TextBoxNLayers.TabIndex = 37
        Me.TextBoxNLayers.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 84)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 17)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Number of layers"
        '
        'TextBoxFieldName
        '
        Me.TextBoxFieldName.Location = New System.Drawing.Point(192, 130)
        Me.TextBoxFieldName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBoxFieldName.Name = "TextBoxFieldName"
        Me.TextBoxFieldName.Size = New System.Drawing.Size(225, 22)
        Me.TextBoxFieldName.TabIndex = 35
        Me.TextBoxFieldName.Text = "0"
        '
        'ButtonReadData
        '
        Me.ButtonReadData.Location = New System.Drawing.Point(464, 178)
        Me.ButtonReadData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonReadData.Name = "ButtonReadData"
        Me.ButtonReadData.Size = New System.Drawing.Size(100, 28)
        Me.ButtonReadData.TabIndex = 34
        Me.ButtonReadData.Text = "Read data"
        Me.ButtonReadData.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 130)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 17)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Data field name"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(154, 20)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 237)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(673, 25)
        Me.StatusStrip1.TabIndex = 38
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 185)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 17)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Minimum valid value"
        '
        'TextBoxNoData
        '
        Me.TextBoxNoData.Location = New System.Drawing.Point(192, 181)
        Me.TextBoxNoData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBoxNoData.Name = "TextBoxNoData"
        Me.TextBoxNoData.Size = New System.Drawing.Size(225, 22)
        Me.TextBoxNoData.TabIndex = 39
        Me.TextBoxNoData.Text = "-9999"
        '
        'ReadMovableStationData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 262)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBoxNoData)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TextBoxNLayers)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxFieldName)
        Me.Controls.Add(Me.ButtonReadData)
        Me.Controls.Add(Me.Label3)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ReadMovableStationData"
        Me.Text = "ReadMovableStationData"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxNLayers As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxFieldName As System.Windows.Forms.TextBox
    Friend WithEvents ButtonReadData As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoData As System.Windows.Forms.TextBox
End Class
