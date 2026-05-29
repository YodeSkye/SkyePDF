<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        LblAbout = New Skye.UI.Label()
        LblVersion = New Skye.UI.Label()
        SuspendLayout()
        ' 
        ' LblAbout
        ' 
        LblAbout.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblAbout.Location = New Point(12, 39)
        LblAbout.Name = "LblAbout"
        LblAbout.Size = New Size(360, 32)
        LblAbout.TabIndex = 0
        LblAbout.Text = "About"
        LblAbout.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' LblVersion
        ' 
        LblVersion.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblVersion.Location = New Point(12, 128)
        LblVersion.Name = "LblVersion"
        LblVersion.Size = New Size(360, 24)
        LblVersion.TabIndex = 1
        LblVersion.Text = "Version"
        LblVersion.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' About
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(384, 161)
        Controls.Add(LblVersion)
        Controls.Add(LblAbout)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "About"
        StartPosition = FormStartPosition.CenterParent
        ResumeLayout(False)
    End Sub

    Friend WithEvents LblAbout As Skye.UI.Label
    Friend WithEvents LblVersion As Skye.UI.Label
End Class
