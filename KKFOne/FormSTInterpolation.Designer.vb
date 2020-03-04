<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSTInterpolation
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
        Me.ButtonInterpolation = New System.Windows.Forms.Button()
        Me.TextBoxResult = New System.Windows.Forms.TextBox()
        Me.ButtonReadCoor = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxID = New System.Windows.Forms.TextBox()
        Me.ButtonLink = New System.Windows.Forms.Button()
        Me.ComboBoxInput = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxY = New System.Windows.Forms.TextBox()
        Me.TextBoxX = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyAllTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonInterpolation
        '
        Me.ButtonInterpolation.Location = New System.Drawing.Point(278, 269)
        Me.ButtonInterpolation.Name = "ButtonInterpolation"
        Me.ButtonInterpolation.Size = New System.Drawing.Size(75, 23)
        Me.ButtonInterpolation.TabIndex = 32
        Me.ButtonInterpolation.Text = "Interpolate"
        Me.ButtonInterpolation.UseVisualStyleBackColor = True
        '
        'TextBoxResult
        '
        Me.TextBoxResult.Location = New System.Drawing.Point(436, 35)
        Me.TextBoxResult.Multiline = True
        Me.TextBoxResult.Name = "TextBoxResult"
        Me.TextBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxResult.Size = New System.Drawing.Size(206, 257)
        Me.TextBoxResult.TabIndex = 31
        '
        'ButtonReadCoor
        '
        Me.ButtonReadCoor.Location = New System.Drawing.Point(334, 187)
        Me.ButtonReadCoor.Name = "ButtonReadCoor"
        Me.ButtonReadCoor.Size = New System.Drawing.Size(75, 23)
        Me.ButtonReadCoor.TabIndex = 30
        Me.ButtonReadCoor.Text = "Read Coord"
        Me.ButtonReadCoor.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Feature #"
        '
        'TextBoxID
        '
        Me.TextBoxID.Location = New System.Drawing.Point(126, 187)
        Me.TextBoxID.Name = "TextBoxID"
        Me.TextBoxID.Size = New System.Drawing.Size(170, 20)
        Me.TextBoxID.TabIndex = 28
        '
        'ButtonLink
        '
        Me.ButtonLink.Location = New System.Drawing.Point(34, 12)
        Me.ButtonLink.Name = "ButtonLink"
        Me.ButtonLink.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLink.TabIndex = 27
        Me.ButtonLink.Text = "Link Arcmap"
        Me.ButtonLink.UseVisualStyleBackColor = True
        '
        'ComboBoxInput
        '
        Me.ComboBoxInput.FormattingEnabled = True
        Me.ComboBoxInput.Location = New System.Drawing.Point(126, 135)
        Me.ComboBoxInput.Name = "ComboBoxInput"
        Me.ComboBoxInput.Size = New System.Drawing.Size(170, 21)
        Me.ComboBoxInput.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(279, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Y"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "X"
        '
        'TextBoxY
        '
        Me.TextBoxY.Location = New System.Drawing.Point(221, 93)
        Me.TextBoxY.Name = "TextBoxY"
        Me.TextBoxY.Size = New System.Drawing.Size(132, 20)
        Me.TextBoxY.TabIndex = 22
        '
        'TextBoxX
        '
        Me.TextBoxX.Location = New System.Drawing.Point(34, 93)
        Me.TextBoxX.Name = "TextBoxX"
        Me.TextBoxX.Size = New System.Drawing.Size(132, 20)
        Me.TextBoxX.TabIndex = 21
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyAllTextToolStripMenuItem, Me.ClearTextToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(140, 48)
        '
        'CopyAllTextToolStripMenuItem
        '
        Me.CopyAllTextToolStripMenuItem.Name = "CopyAllTextToolStripMenuItem"
        Me.CopyAllTextToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.CopyAllTextToolStripMenuItem.Text = "Copy all text"
        '
        'ClearTextToolStripMenuItem
        '
        Me.ClearTextToolStripMenuItem.Name = "ClearTextToolStripMenuItem"
        Me.ClearTextToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.ClearTextToolStripMenuItem.Text = "Clear text"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Location of points"
        '
        'FormSTInterpolation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 327)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxResult)
        Me.Controls.Add(Me.ButtonInterpolation)
        Me.Controls.Add(Me.ButtonReadCoor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxID)
        Me.Controls.Add(Me.ButtonLink)
        Me.Controls.Add(Me.ComboBoxInput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxY)
        Me.Controls.Add(Me.TextBoxX)
        Me.Name = "FormSTInterpolation"
        Me.Text = "FormSTInterpolation"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonInterpolation As System.Windows.Forms.Button
    Friend WithEvents TextBoxResult As System.Windows.Forms.TextBox
    Friend WithEvents ButtonReadCoor As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxID As System.Windows.Forms.TextBox
    Friend WithEvents ButtonLink As System.Windows.Forms.Button
    Friend WithEvents ComboBoxInput As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxY As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxX As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyAllTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
