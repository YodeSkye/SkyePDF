
Imports System.IO
Imports SkyePDF.My

Public Class PDF

    'Declarations
    Private Header As String = String.Empty 'Keeps the form title from designer
    Private UserZoom As Integer = 100 '100% Zoom, Used to store the zoom factor while maximized.
    Private IsFocused As Boolean = True 'Indicates if the form is focused
    Private IsModded As Boolean = False 'Indicates whether the document is being modded
    Private InputStream As IO.FileStream
    Private LoadedDocument As Syncfusion.Pdf.Parsing.PdfLoadedDocument
    Private mMove As Boolean = False
    Private mOffset, mPosition As System.Drawing.Point

    'Form Events
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Try
            Select Case m.Msg
                Case Skye.WinAPI.WM_SIZE
                    Select Case m.WParam.ToInt32
                        Case 0 '0 = Restored
                            App.PDFMaximized = False
                            SetViewSize()
                        Case 2 '2 = Maximized
                            App.PDFMaximized = True
                            SetViewSize()
                    End Select
                Case Skye.WinAPI.WM_ACTIVATE
                    Select Case m.WParam.ToInt32
                        Case 0
                            IsFocused = False
                            SetInactiveColor()
                        Case 1, 2
                            IsFocused = True
                            SetAccentColor()
                    End Select
                Case Skye.WinAPI.WM_DWMCOLORIZATIONCOLORCHANGED
                    SetAccentColor()
            End Select
        Catch ex As Exception
            App.WriteToLog("Player WndProc Handler Error" + Chr(13) + ex.ToString)
        Finally
            MyBase.WndProc(m)
        End Try
    End Sub
    Private Sub PDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Header = Text
        LoadPDF(App.PDFPath)
#If DEBUG Then
        'If App.PDFMaximized Then WindowState = FormWindowState.Maximized
        'If App.PDFLocation.Y > Integer.MinValue Then Location = App.PDFLocation
        'If App.PDFSize.Height >= 0 Then Size = App.PDFSize
#Else
        If App.PDFMaximized Then WindowState = FormWindowState.Maximized
        If App.PDFLocation.Y > Integer.MinValue Then Location = App.PDFLocation
        If App.PDFSize.Height >= 0 Then Size = App.PDFSize
#End If
    End Sub
    Private Sub PDF_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.W Then
            Close()
        End If
    End Sub
    Private Sub PDF_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown, MenuPDF.MouseDown
        Dim cSender As Control
        If e.Button = MouseButtons.Left AndAlso Me.WindowState = FormWindowState.Normal Then
            mMove = True
            cSender = CType(sender, Control)
            If cSender Is Me Then
                mOffset = New Point(-e.X - SystemInformation.FrameBorderSize.Width - 4, -e.Y - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            Else
                mOffset = New Point(-e.X - cSender.Left - SystemInformation.FrameBorderSize.Width - 4, -e.Y - cSender.Top - SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight - 4)
            End If
        End If
    End Sub
    Private Sub PDF_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove, MenuPDF.MouseMove
        If mMove Then
            mPosition = MousePosition
            mPosition.Offset(mOffset.X, mOffset.Y)
            Location = mPosition
        End If
    End Sub
    Private Sub PDF_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp, MenuPDF.MouseUp
        mMove = False
    End Sub
    Private Sub PDF_Move(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Move
        If Visible AndAlso Me.WindowState = FormWindowState.Normal AndAlso Not mMove Then
            App.PDFLocation = Location
        End If
    End Sub
    Private Sub PDF_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Visible AndAlso WindowState = FormWindowState.Normal Then
            App.PDFSize = Me.Size
        End If
    End Sub
    Private Sub PDF_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        App.Finalize()
    End Sub

    'Control Events
    Private Sub PDFViewer_DocumentLoaded(sender As Object, args As EventArgs) Handles PDFViewer.DocumentLoaded
        If Not IsModded Then
            App.PDFPath = PDFViewer.DocumentInformation.FilePath + PDFViewer.DocumentInformation.FileName
            Text = Header + " - " + App.PDFPath
            App.WriteToLog("PDF File Opened")
        End If
        IsModded = False
    End Sub
    Private Sub PDFViewer_DocumentUnloaded(sender As Object, e As Syncfusion.Windows.Forms.PdfViewer.DocumentUnloadedEventArgs) Handles PDFViewer.DocumentUnloaded
        If Not IsModded Then
            App.PDFPath = String.Empty
            If LoadedDocument IsNot Nothing Then LoadedDocument.Close()
            If InputStream IsNot Nothing Then InputStream.Close()
        End If
        Text = Header
    End Sub
    Private Sub PDFViewer_DragEnter(sender As Object, e As DragEventArgs) Handles PDFViewer.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub PDFViewer_DragDrop(sender As Object, e As DragEventArgs) Handles PDFViewer.DragDrop
        If e.Effect = DragDropEffects.Copy Then
            Dim filedrop As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop, True), String())
            LoadPDF(filedrop(0))
        End If
    End Sub
    Private Sub MenuPDF_DoubleClick(sender As Object, e As EventArgs) Handles MenuPDF.DoubleClick
        ToggleMaximized()
    End Sub
    Private Sub MIFile_DropDownClosed(sender As Object, e As EventArgs) Handles MIFile.DropDownClosed
        If Not MIFile.Selected Then MIFile.ForeColor = App.AccentTextColor
    End Sub
    Private Sub MIFile_MouseEnter(sender As Object, e As EventArgs) Handles MIFile.MouseEnter
        MIFile.ForeColor = Color.Black
    End Sub
    Private Sub MIFile_MouseLeave(sender As Object, e As EventArgs) Handles MIFile.MouseLeave
        If Not MIFile.DropDown.Visible Then MIFile.ForeColor = App.AccentTextColor
    End Sub
    Private Sub CMIOpen_Click(sender As Object, e As EventArgs) Handles CMIOpen.Click
        SelectPDF()
    End Sub
    Private Sub CMIClose_Click(sender As Object, e As EventArgs) Handles CMIClose.Click
        UnloadPDF()
    End Sub
    Private Sub CMIExit_Click(sender As Object, e As EventArgs) Handles CMIExit.Click
        Close()
    End Sub
    Private Sub MIView_DropDownOpening(sender As Object, e As EventArgs) Handles MIView.DropDownOpening
        If String.IsNullOrEmpty(App.PDFPath) Then
            CMIRotate0.Enabled = False
            CMIRotate90.Enabled = False
            CMIRotate180.Enabled = False
            CMIRotate270.Enabled = False
        Else
            CMIRotate0.Enabled = True
            CMIRotate90.Enabled = True
            CMIRotate180.Enabled = True
            CMIRotate270.Enabled = True
        End If
    End Sub
    Private Sub MIView_DropDownClosed(sender As Object, e As EventArgs) Handles MIView.DropDownClosed
        If Not MIView.Selected Then MIView.ForeColor = App.AccentTextColor
    End Sub
    Private Sub MIView_MouseEnter(sender As Object, e As EventArgs) Handles MIView.MouseEnter
        MIView.ForeColor = Color.Black
    End Sub
    Private Sub MIView_MouseLeave(sender As Object, e As EventArgs) Handles MIView.MouseLeave
        If Not MIView.DropDown.Visible Then MIView.ForeColor = App.AccentTextColor
    End Sub
    Private Sub CMIRotate0_Click(sender As Object, e As EventArgs) Handles CMIRotate0.Click
        RotatePDF(Syncfusion.Pdf.PdfPageRotateAngle.RotateAngle0)
    End Sub
    Private Sub CMIRotate90_Click(sender As Object, e As EventArgs) Handles CMIRotate90.Click
        RotatePDF(Syncfusion.Pdf.PdfPageRotateAngle.RotateAngle90)
    End Sub
    Private Sub CMIRotate180_Click(sender As Object, e As EventArgs) Handles CMIRotate180.Click
        RotatePDF(Syncfusion.Pdf.PdfPageRotateAngle.RotateAngle180)
    End Sub
    Private Sub CMIRotate270_Click(sender As Object, e As EventArgs) Handles CMIRotate270.Click
        RotatePDF(Syncfusion.Pdf.PdfPageRotateAngle.RotateAngle270)
    End Sub
    Private Sub MIAbout_DropDownClosed(sender As Object, e As EventArgs) Handles MIAbout.DropDownClosed
        If Not MIAbout.Selected Then MIAbout.ForeColor = App.AccentTextColor
    End Sub
    Private Sub MIAbout_MouseEnter(sender As Object, e As EventArgs) Handles MIAbout.MouseEnter
        MIAbout.ForeColor = Color.Black
    End Sub
    Private Sub MIAbout_MouseLeave(sender As Object, e As EventArgs) Handles MIAbout.MouseLeave
        If Not MIAbout.DropDown.Visible Then MIAbout.ForeColor = App.AccentTextColor
    End Sub
    Private Sub CMILog_Click(sender As Object, e As EventArgs) Handles CMILog.Click
        App.ShowLog()
    End Sub
    Private Sub CMIAbout_Click(sender As Object, e As EventArgs) Handles CMIAbout.Click
        About.ShowDialog()
    End Sub

    'Procedures
    Private Sub LoadPDF(path As String)
        If Not String.IsNullOrEmpty(path) Then
            PDFViewer.Load(path)
        End If
    End Sub
    Private Sub UnloadPDF()
        PDFViewer.Unload()
    End Sub
    Private Sub SelectPDF()
        Dim ofd As New OpenFileDialog With {
            .Title = "Select a Pdf file.",
            .Filter = "Pdf files *.Pdf|*.pdf",
            .Multiselect = False}
        Dim result As DialogResult = ofd.ShowDialog(Me)
        If result = DialogResult.OK AndAlso ofd.FileNames.Length > 0 Then
            LoadPDF(ofd.FileName)
        End If
        ofd.Dispose()
    End Sub
    Private Sub SetViewSize()
        Select Case WindowState
            Case FormWindowState.Normal
                If UserZoom = 0 Then
                    PDFViewer.ZoomTo(100)
                Else
                    PDFViewer.ZoomTo(UserZoom)
                End If
            Case FormWindowState.Maximized
                UserZoom = PDFViewer.ZoomPercentage
                PDFViewer.ZoomTo(200)
        End Select
    End Sub
    Private Sub RotatePDF(r As Syncfusion.Pdf.PdfPageRotateAngle)
        IsModded = True
        InputStream = New FileStream(PDFPath, FileMode.Open, FileAccess.Read)
        LoadedDocument = New Syncfusion.Pdf.Parsing.PdfLoadedDocument(InputStream)
        Dim loadedPage As Syncfusion.Pdf.PdfLoadedPage = DirectCast(LoadedDocument.Pages(PDFViewer.CurrentPageIndex - 1), Syncfusion.Pdf.PdfLoadedPage)
        loadedPage.Rotation = r
        PDFViewer.Load(LoadedDocument)
    End Sub
    Private Sub ToggleMaximized()
        Select Case WindowState
            Case FormWindowState.Normal, FormWindowState.Minimized
                WindowState = FormWindowState.Maximized
            Case FormWindowState.Maximized
                WindowState = FormWindowState.Normal
        End Select
    End Sub
    Private Sub SetAccentColor(Optional AsTheme As Boolean = False)
        Static c As Color
        c = App.GetAccentColor()
        If IsFocused Then
            MenuPDF.BackColor = c
        End If
        Debug.Print("Accent Color Set")
    End Sub
    Private Sub SetInactiveColor()
        MenuPDF.BackColor = App.InactiveTitleBarColor
    End Sub

End Class
