
Imports Microsoft.Win32
Imports SkyePDF.My

Namespace My

    Public Module App

        ' Declarations
        Friend PDFPath As String = String.Empty
        Friend AccentTextColor As Color = Color.White
        Friend InactiveTitleBarColor As Color = Color.FromArgb(255, 243, 243, 243)
        Friend Const AdjustScreenBoundsNormalWindow As Byte = 8
        Friend Const AdjustScreenBoundsDialogWindow As Byte = 10
        Friend FrmPDF As PDF
        Friend FrmLog As Skye.UI.Log.LogViewer

        ' Saved Settings
        Friend PDFMaximized As Boolean = False
        Friend PDFLocation As New Point(Integer.MinValue, Integer.MinValue)
        Friend PDFSize As New Size(-1, -1)

        ' Methods
        Friend Sub Initialize()
#If DEBUG Then
            Skye.Common.Log.Initialize(My.Application.Info.ProductName & "DEV")
            Skye.Common.RegistryHelper.BaseKey = "Software\\" + My.Application.Info.ProductName + "DEV"
#Else
            Skye.Common.Log.Initialize(My.Application.Info.ProductName)
            Skye.Common.RegistryHelper.BaseKey = "Software\\" + My.Application.Info.ProductName
#End If
            WriteToLog(My.Application.Info.ProductName + " Started...", False)
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JHaF5cWWdCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdlWXxfd3VURmlcU0ZzX0pWYEo=")
            If My.Application.CommandLineArgs.Count > 0 Then
                ProcessPassedParameters(My.Application.CommandLineArgs)
            End If
            GetSettings()
#If DEBUG Then
            GetDEBUGSettings()
#End If
            FrmPDF = New PDF
        End Sub
        Friend Sub Finalize()
            SaveSettings()
            WriteToLog("..." + My.Application.Info.ProductName + " Closed", False)
        End Sub
        Friend Sub ProcessPassedParameters(ByRef parameters As Collections.ObjectModel.ReadOnlyCollection(Of String))
            Try
                If String.IsNullOrEmpty(parameters(0)) Then
                    WriteToLog("Invalid CommandLine Parameter")
                Else
                    PDFPath = parameters(0)
                End If
                WriteToLog("Processing CommandLine")
            Catch
            End Try
        End Sub
        Friend Sub GetSettings()
            Try
                Dim starttime As TimeSpan = My.Computer.Clock.LocalTime.TimeOfDay
                App.PDFMaximized = Skye.Common.RegistryHelper.GetBool("PDFMaximized", False)
                App.PDFLocation.X = Skye.Common.RegistryHelper.GetInt("PDFLocationX", Integer.MinValue)
                App.PDFLocation.Y = Skye.Common.RegistryHelper.GetInt("PDFLocationY", Integer.MinValue)
                App.PDFSize.Width = Skye.Common.RegistryHelper.GetInt("PDFSizeX", -1)
                App.PDFSize.Height = Skye.Common.RegistryHelper.GetInt("PDFSizeY", -1)
                App.WriteToLog("Settings Loaded (" + Skye.Common.GenerateLogTime(starttime, My.Computer.Clock.LocalTime.TimeOfDay) + ")", False)
            Catch ex As Exception
                WriteToLog("Error Loading Settings" + vbCr + ex.Message, False)
            End Try
        End Sub
        <Diagnostics.ConditionalAttribute("DEBUG")> Private Sub GetDEBUGSettings()
            PDFPath = "C:\Users\YodeS\Dev\TESTDATA\XfinityMobile Statement 20251023.pdf"
        End Sub
        Friend Sub SaveSettings()
            Try
                Dim starttime As TimeSpan = My.Computer.Clock.LocalTime.TimeOfDay
                Skye.Common.RegistryHelper.SetBool("PDFMaximized", App.PDFMaximized)
                Skye.Common.RegistryHelper.SetInt("PDFLocationX", App.PDFLocation.X)
                Skye.Common.RegistryHelper.SetInt("PDFLocationY", App.PDFLocation.Y)
                Skye.Common.RegistryHelper.SetInt("PDFSizeX", App.PDFSize.Width)
                Skye.Common.RegistryHelper.SetInt("PDFSizeY", App.PDFSize.Height)
                App.WriteToLog("Settings Saved (" + Skye.Common.GenerateLogTime(starttime, My.Computer.Clock.LocalTime.TimeOfDay) + ")", False)
            Catch ex As Exception
                WriteToLog("Error Saving Settings" + vbCr + ex.Message, False)
            End Try
        End Sub
        Friend Sub WriteToLog(logtext As String, Optional showpdfpath As Boolean = True)
            Skye.Common.Log.Write(logtext & IIf(showpdfpath, " (" + IIf(String.IsNullOrEmpty(PDFPath), "PDF File Not Specified", PDFPath).ToString + ")", String.Empty).ToString)
        End Sub
        Friend Sub ShowLog()
            If FrmLog IsNot Nothing AndAlso Not FrmLog.IsDisposed Then FrmLog.Close()
            FrmLog = New Skye.UI.Log.LogViewer With {
                    .Text = My.Application.Info.ProductName + " Log",
                    .StartPosition = FormStartPosition.CenterScreen
                }
            FrmLog.Show()
        End Sub
        Friend Function GetAccentColor() As Color
            Dim c As Color
            Dim regkey As RegistryKey
            Dim regvalue As Integer
            regkey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\DWM")
            regvalue = CInt(regkey.GetValue("AccentColor"))
            If regvalue = Nothing Then
                c = SystemColors.Control
            Else
                c = Color.FromArgb(255, Skye.WinAPI.GetRValue(regvalue), Skye.WinAPI.GetGValue(regvalue), Skye.WinAPI.GetBValue(regvalue))
            End If
            regkey.Close()
            regkey.Dispose()
            GetAccentColor = c
        End Function

    End Module

End Namespace
