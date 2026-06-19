<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PDF
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Dim MessageBoxSettings1 As Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings = New Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings()
        Dim PdfViewerPrinterSettings1 As Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings = New Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PDF))
        Dim TextSearchSettings1 As Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings = New Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings()
        PDFViewer = New Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl()
        MenuPDF = New MenuStrip()
        MIFile = New ToolStripMenuItem()
        CMIOpen = New ToolStripMenuItem()
        CMIClose = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        CMIExit = New ToolStripMenuItem()
        MIView = New ToolStripMenuItem()
        CMIRotate0 = New ToolStripMenuItem()
        CMIRotate90 = New ToolStripMenuItem()
        CMIRotate180 = New ToolStripMenuItem()
        CMIRotate270 = New ToolStripMenuItem()
        MIAbout = New ToolStripMenuItem()
        CMILog = New ToolStripMenuItem()
        CMIAbout = New ToolStripMenuItem()
        MenuPDF.SuspendLayout()
        SuspendLayout()
        ' 
        ' PDFViewer
        ' 
        PDFViewer.AllowDrop = True
        PDFViewer.CursorMode = Syncfusion.Windows.Forms.PdfViewer.PdfViewerCursorMode.SelectTool
        PDFViewer.Dock = DockStyle.Fill
        PDFViewer.EnableContextMenu = True
        PDFViewer.EnableNotificationBar = True
        PDFViewer.HorizontalScrollOffset = 0
        PDFViewer.IsBookmarkEnabled = False
        PDFViewer.IsTextSearchEnabled = True
        PDFViewer.IsTextSelectionEnabled = True
        PDFViewer.Location = New Point(0, 29)
        MessageBoxSettings1.EnableNotification = True
        PDFViewer.MessageBoxSettings = MessageBoxSettings1
        PDFViewer.MinimumZoomPercentage = 50
        PDFViewer.Name = "PDFViewer"
        PDFViewer.PageBorderThickness = 1
        PdfViewerPrinterSettings1.Copies = 1
        PdfViewerPrinterSettings1.PageOrientation = Syncfusion.Windows.PdfViewer.PdfViewerPrintOrientation.Auto
        PdfViewerPrinterSettings1.PageSize = Syncfusion.Windows.PdfViewer.PdfViewerPrintSize.ActualSize
        PdfViewerPrinterSettings1.PrintLocation = CType(resources.GetObject("PdfViewerPrinterSettings1.PrintLocation"), PointF)
        PdfViewerPrinterSettings1.ShowPrintStatusDialog = True
        PDFViewer.PrinterSettings = PdfViewerPrinterSettings1
        PDFViewer.ReferencePath = Nothing
        PDFViewer.ScrollDisplacementValue = 0
        PDFViewer.ShowHorizontalScrollBar = True
        PDFViewer.ShowToolBar = True
        PDFViewer.ShowVerticalScrollBar = True
        PDFViewer.Size = New Size(984, 732)
        PDFViewer.SpaceBetweenPages = 8
        PDFViewer.TabIndex = 0
        TextSearchSettings1.CurrentInstanceColor = Color.FromArgb(CByte(127), CByte(255), CByte(171), CByte(64))
        TextSearchSettings1.HighlightAllInstance = True
        TextSearchSettings1.OtherInstanceColor = Color.FromArgb(CByte(127), CByte(254), CByte(255), CByte(0))
        PDFViewer.TextSearchSettings = TextSearchSettings1
        PDFViewer.ThemeName = "Default"
        PDFViewer.VerticalScrollOffset = 0
        PDFViewer.VisualStyle = Syncfusion.Windows.Forms.PdfViewer.VisualStyle.Default
        PDFViewer.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.Default
        ' 
        ' MenuPDF
        ' 
        MenuPDF.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MenuPDF.Items.AddRange(New ToolStripItem() {MIFile, MIView, MIAbout})
        MenuPDF.Location = New Point(0, 0)
        MenuPDF.Name = "MenuPDF"
        MenuPDF.Size = New Size(984, 29)
        MenuPDF.TabIndex = 1
        ' 
        ' MIFile
        ' 
        MIFile.DropDownItems.AddRange(New ToolStripItem() {CMIOpen, CMIClose, ToolStripSeparator1, CMIExit})
        MIFile.ForeColor = Color.White
        MIFile.Image = My.Resources.Resources.ImageFile16
        MIFile.Name = "MIFile"
        MIFile.Size = New Size(62, 25)
        MIFile.Text = "File"
        ' 
        ' CMIOpen
        ' 
        CMIOpen.Image = My.Resources.Resources.ImageOpen16
        CMIOpen.Name = "CMIOpen"
        CMIOpen.Size = New Size(118, 26)
        CMIOpen.Text = "Open"
        ' 
        ' CMIClose
        ' 
        CMIClose.Image = My.Resources.Resources.ImageExit16
        CMIClose.Name = "CMIClose"
        CMIClose.Size = New Size(118, 26)
        CMIClose.Text = "Close"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(115, 6)
        ' 
        ' CMIExit
        ' 
        CMIExit.Image = My.Resources.Resources.ImageExit16
        CMIExit.Name = "CMIExit"
        CMIExit.Size = New Size(118, 26)
        CMIExit.Text = "Exit"
        ' 
        ' MIView
        ' 
        MIView.DropDownItems.AddRange(New ToolStripItem() {CMIRotate0, CMIRotate90, CMIRotate180, CMIRotate270})
        MIView.ForeColor = Color.White
        MIView.Image = My.Resources.Resources.ImageView16
        MIView.Name = "MIView"
        MIView.Size = New Size(72, 25)
        MIView.Text = "View"
        ' 
        ' CMIRotate0
        ' 
        CMIRotate0.Image = My.Resources.Resources.ImageRotate016
        CMIRotate0.Name = "CMIRotate0"
        CMIRotate0.Size = New Size(164, 26)
        CMIRotate0.Text = "No Rotation"
        ' 
        ' CMIRotate90
        ' 
        CMIRotate90.Image = My.Resources.Resources.ImageRotate9016
        CMIRotate90.Name = "CMIRotate90"
        CMIRotate90.Size = New Size(164, 26)
        CMIRotate90.Text = "Rotate 90°"
        ' 
        ' CMIRotate180
        ' 
        CMIRotate180.Image = My.Resources.Resources.ImageRotate18016
        CMIRotate180.Name = "CMIRotate180"
        CMIRotate180.Size = New Size(164, 26)
        CMIRotate180.Text = "Rotate 180°"
        ' 
        ' CMIRotate270
        ' 
        CMIRotate270.Image = My.Resources.Resources.ImageRotate27016
        CMIRotate270.Name = "CMIRotate270"
        CMIRotate270.Size = New Size(164, 26)
        CMIRotate270.Text = "Rotate 270°"
        ' 
        ' MIAbout
        ' 
        MIAbout.DropDownItems.AddRange(New ToolStripItem() {CMILog, CMIAbout})
        MIAbout.ForeColor = Color.White
        MIAbout.Image = My.Resources.Resources.ImageAbout16
        MIAbout.Name = "MIAbout"
        MIAbout.Size = New Size(80, 25)
        MIAbout.Text = "About"
        ' 
        ' CMILog
        ' 
        CMILog.Image = My.Resources.Resources.ImageLog16
        CMILog.Name = "CMILog"
        CMILog.Size = New Size(122, 26)
        CMILog.Text = "Log"
        ' 
        ' CMIAbout
        ' 
        CMIAbout.Image = My.Resources.Resources.ImageAbout16
        CMIAbout.Name = "CMIAbout"
        CMIAbout.Size = New Size(122, 26)
        CMIAbout.Text = "About"
        ' 
        ' PDF
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(984, 761)
        Controls.Add(PDFViewer)
        Controls.Add(MenuPDF)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        MainMenuStrip = MenuPDF
        Name = "PDF"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Skye's PDF Viewer"
        MenuPDF.ResumeLayout(False)
        MenuPDF.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PDFViewer As Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl
    Friend WithEvents MenuPDF As MenuStrip
    Friend WithEvents MIFile As ToolStripMenuItem
    Friend WithEvents MIAbout As ToolStripMenuItem
    Friend WithEvents CMIOpen As ToolStripMenuItem
    Friend WithEvents CMIClose As ToolStripMenuItem
    Friend WithEvents CMILog As ToolStripMenuItem
    Friend WithEvents CMIAbout As ToolStripMenuItem
    Friend WithEvents CMIExit As ToolStripMenuItem
    Friend WithEvents MIView As ToolStripMenuItem
    Friend WithEvents CMIRotate0 As ToolStripMenuItem
    Friend WithEvents CMIRotate90 As ToolStripMenuItem
    Friend WithEvents CMIRotate180 As ToolStripMenuItem
    Friend WithEvents CMIRotate270 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator

End Class
