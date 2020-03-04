<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LinkArcMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FixedStationDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovableStationDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpatialComponentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CovariogramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModelSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KKFAlgorithmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InitializeModelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EMAlgorithmToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalibrateAutomaticallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveModelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadModelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimeSeriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpatialTemporalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyAllTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ButtonIterate = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBoxOutput = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataToolStripMenuItem, Me.SpatialComponentToolStripMenuItem, Me.KKFAlgorithmToolStripMenuItem, Me.ResultsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(749, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LinkArcMapToolStripMenuItem, Me.FixedStationDataToolStripMenuItem, Me.MovableStationDataToolStripMenuItem})
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.DataToolStripMenuItem.Text = "Data"
        '
        'LinkArcMapToolStripMenuItem
        '
        Me.LinkArcMapToolStripMenuItem.Name = "LinkArcMapToolStripMenuItem"
        Me.LinkArcMapToolStripMenuItem.Size = New System.Drawing.Size(233, 26)
        Me.LinkArcMapToolStripMenuItem.Text = "Link ArcMap"
        '
        'FixedStationDataToolStripMenuItem
        '
        Me.FixedStationDataToolStripMenuItem.Name = "FixedStationDataToolStripMenuItem"
        Me.FixedStationDataToolStripMenuItem.Size = New System.Drawing.Size(233, 26)
        Me.FixedStationDataToolStripMenuItem.Text = "Fixed station data"
        '
        'MovableStationDataToolStripMenuItem
        '
        Me.MovableStationDataToolStripMenuItem.Name = "MovableStationDataToolStripMenuItem"
        Me.MovableStationDataToolStripMenuItem.Size = New System.Drawing.Size(233, 26)
        Me.MovableStationDataToolStripMenuItem.Text = "Movable station data"
        '
        'SpatialComponentToolStripMenuItem
        '
        Me.SpatialComponentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.CovariogramToolStripMenuItem, Me.ModelSetupToolStripMenuItem})
        Me.SpatialComponentToolStripMenuItem.Name = "SpatialComponentToolStripMenuItem"
        Me.SpatialComponentToolStripMenuItem.Size = New System.Drawing.Size(71, 24)
        Me.SpatialComponentToolStripMenuItem.Text = "Kriging"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(240, 26)
        Me.ToolStripMenuItem1.Text = "Normative sites"
        '
        'CovariogramToolStripMenuItem
        '
        Me.CovariogramToolStripMenuItem.Name = "CovariogramToolStripMenuItem"
        Me.CovariogramToolStripMenuItem.Size = New System.Drawing.Size(240, 26)
        Me.CovariogramToolStripMenuItem.Text = "Variogram"
        '
        'ModelSetupToolStripMenuItem
        '
        Me.ModelSetupToolStripMenuItem.Name = "ModelSetupToolStripMenuItem"
        Me.ModelSetupToolStripMenuItem.Size = New System.Drawing.Size(240, 26)
        Me.ModelSetupToolStripMenuItem.Text = "Extract Principal Fields"
        '
        'KKFAlgorithmToolStripMenuItem
        '
        Me.KKFAlgorithmToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InitializeModelToolStripMenuItem, Me.EMAlgorithmToolStripMenuItem, Me.CalibrateAutomaticallyToolStripMenuItem, Me.SaveModelToolStripMenuItem, Me.LoadModelToolStripMenuItem})
        Me.KKFAlgorithmToolStripMenuItem.Name = "KKFAlgorithmToolStripMenuItem"
        Me.KKFAlgorithmToolStripMenuItem.Size = New System.Drawing.Size(117, 24)
        Me.KKFAlgorithmToolStripMenuItem.Text = "KKF algorithm"
        '
        'InitializeModelToolStripMenuItem
        '
        Me.InitializeModelToolStripMenuItem.Name = "InitializeModelToolStripMenuItem"
        Me.InitializeModelToolStripMenuItem.Size = New System.Drawing.Size(248, 26)
        Me.InitializeModelToolStripMenuItem.Text = "Initialize"
        '
        'EMAlgorithmToolStripMenuItem
        '
        Me.EMAlgorithmToolStripMenuItem.Name = "EMAlgorithmToolStripMenuItem"
        Me.EMAlgorithmToolStripMenuItem.Size = New System.Drawing.Size(248, 26)
        Me.EMAlgorithmToolStripMenuItem.Text = "Calibrate Manually"
        '
        'CalibrateAutomaticallyToolStripMenuItem
        '
        Me.CalibrateAutomaticallyToolStripMenuItem.Name = "CalibrateAutomaticallyToolStripMenuItem"
        Me.CalibrateAutomaticallyToolStripMenuItem.Size = New System.Drawing.Size(248, 26)
        Me.CalibrateAutomaticallyToolStripMenuItem.Text = "Calibrate Automatically"
        '
        'SaveModelToolStripMenuItem
        '
        Me.SaveModelToolStripMenuItem.Name = "SaveModelToolStripMenuItem"
        Me.SaveModelToolStripMenuItem.Size = New System.Drawing.Size(248, 26)
        Me.SaveModelToolStripMenuItem.Text = "Save Model"
        '
        'LoadModelToolStripMenuItem
        '
        Me.LoadModelToolStripMenuItem.Name = "LoadModelToolStripMenuItem"
        Me.LoadModelToolStripMenuItem.Size = New System.Drawing.Size(248, 26)
        Me.LoadModelToolStripMenuItem.Text = "Load Model"
        '
        'ResultsToolStripMenuItem
        '
        Me.ResultsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TimeSeriesToolStripMenuItem, Me.SpatialTemporalToolStripMenuItem})
        Me.ResultsToolStripMenuItem.Name = "ResultsToolStripMenuItem"
        Me.ResultsToolStripMenuItem.Size = New System.Drawing.Size(90, 24)
        Me.ResultsToolStripMenuItem.Text = "Prediction"
        '
        'TimeSeriesToolStripMenuItem
        '
        Me.TimeSeriesToolStripMenuItem.Name = "TimeSeriesToolStripMenuItem"
        Me.TimeSeriesToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.TimeSeriesToolStripMenuItem.Text = "Time series"
        '
        'SpatialTemporalToolStripMenuItem
        '
        Me.SpatialTemporalToolStripMenuItem.Name = "SpatialTemporalToolStripMenuItem"
        Me.SpatialTemporalToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.SpatialTemporalToolStripMenuItem.Text = "Spatial temporal"
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
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(13, 32)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(706, 108)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'ButtonIterate
        '
        Me.ButtonIterate.Location = New System.Drawing.Point(274, 147)
        Me.ButtonIterate.Name = "ButtonIterate"
        Me.ButtonIterate.Size = New System.Drawing.Size(75, 23)
        Me.ButtonIterate.TabIndex = 3
        Me.ButtonIterate.Text = "Iterate"
        Me.ButtonIterate.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(159, 147)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "H"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBoxOutput
        '
        Me.TextBoxOutput.Location = New System.Drawing.Point(13, 201)
        Me.TextBoxOutput.Multiline = True
        Me.TextBoxOutput.Name = "TextBoxOutput"
        Me.TextBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxOutput.Size = New System.Drawing.Size(706, 327)
        Me.TextBoxOutput.TabIndex = 5
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 552)
        Me.Controls.Add(Me.TextBoxOutput)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonIterate)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormMain"
        Me.Text = "KKFOne"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SpatialComponentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KKFAlgorithmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResultsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CovariogramToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EMAlgorithmToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimeSeriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpatialTemporalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyAllTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FixedStationDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MovableStationDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents LinkArcMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InitializeModelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModelSetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalibrateAutomaticallyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ButtonIterate As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBoxOutput As TextBox
    Friend WithEvents SaveModelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadModelToolStripMenuItem As ToolStripMenuItem
End Class
