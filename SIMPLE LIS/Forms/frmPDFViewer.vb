Imports System.IO
Imports PdfSharp
Public Class frmPDFViewer

#Region "Vars"
    Private filelocation As String
    Private canPrint As Boolean
    Private directPrint As Boolean

    Private tempFileName As String

    Public Sub New(ByVal filelocation As String, ByVal canPrint As Boolean, ByVal directPrint As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.filelocation = filelocation
        Me.canPrint = canPrint
        Me.directPrint = directPrint
    End Sub
#End Region
    Private Sub frmResultDesigner_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        
    End Sub
    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub frmPDFViewer_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        Dim PDFDoc As New Pdf.PdfDocument
        Try
            'If Not canPrint Then
            '    tempFileName = "templates\temp\" & Utility.GetRandomString() & ".pdf"
            '    While File.Exists(tempFileName)
            '        tempFileName = "templates\temp\" & Utility.GetRandomString() & ".pdf"
            '    End While
            '    Dim PDFNewDoc As New PdfSharp.Pdf.PdfDocument()
            '    PDFDoc = Pdf.IO.PdfReader.Open(filelocation, Pdf.IO.PdfDocumentOpenMode.Import)
            '    PDFNewDoc.SecuritySettings.PermitPrint = False
            '    PDFNewDoc.SecuritySettings.PermitFullQualityPrint = False

            '    For Pg As Integer = 0 To PDFDoc.Pages.Count - 1
            '        PDFNewDoc.AddPage(PDFDoc.Pages(Pg))
            '    Next

            '    PDFNewDoc.Save(tempFileName)
            '    PDFNewDoc = Nothing
            '    'AxAcroPDF1.LoadFile("D:\Royette\SSTS\Simple EMR\simplelis\SIMPLE LIS\bin\Debug\templates\temp\qYp0hGEmcY.pdf")
            '    AxAcroPDF1.LoadFile(filelocation)
            '    AxAcroPDF1.src = filelocation
            'Else
            '    AxAcroPDF1.LoadFile(filelocation)
            '    AxAcroPDF1.src = filelocation
            'End If
            Me.tsPrint.Visible = canPrint
            Dim fi As New FileInfo(filelocation)
            AxAcroPDF1.LoadFile(fi.FullName)
            AxAcroPDF1.src = fi.FullName
            AxAcroPDF1.setZoom(90)
            AxAcroPDF1.setShowToolbar(False)
            AxAcroPDF1.Show()
            'If directPrint Then
            '    AxAcroPDF1.printWithDialog()
            'End If
        Catch ex As Exception

        Finally
            If Not PDFDoc Is Nothing Then
                PDFDoc = Nothing
            End If
        End Try
    End Sub

    Private Sub frmPDFViewer_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If tempFileName <> "" Then
            Try
                If File.Exists(tempFileName) Then
                    File.Delete(tempFileName)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub tsPrint_Click(sender As System.Object, e As System.EventArgs) Handles tsPrint.Click
        AxAcroPDF1.printWithDialog()
    End Sub
End Class