Imports System.Drawing.Drawing2D
'***********
'*    Author: Ronald Jumao-as
'*    Date Created: 06-05-12
'*
'**********

Imports System.Drawing.Imaging
Imports System.IO
Public Class frmRTFPrint
#Region "Variables"
    Dim dtHospitalInfo As New DataTable

    '    'Royette 2021-07-29
    Private afterload As Boolean
    Private isformedit As Boolean
    Private laboratoryid As Long
    Private labname As String
    Private requestdetailno As Long
    Private medtech As Long = 0
    Private patho As Long = 0
    Private dtPatientDetails As New DataTable
    Private dtNewBornResults As New DataTable
    Private isLock As Boolean
    Private baseForm As frmResultDesigner

    Public admissionid As Long
    Public itemcode As String
    Public laboratoryresultid As Long
    Public labexaminationno As Long

    'default grid height
    Private rowheight As Integer = 20

#End Region
#Region "Constructor"
    Public Sub New(baseForm As frmResultDesigner, ByVal isformedit As Boolean, ByVal laboratoryid As Long, ByVal labname As String, ByVal isLock As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.isformedit = isformedit
        Me.laboratoryid = laboratoryid
        Me.labname = labname
        Me.isLock = isLock
        Me.baseForm = baseForm
    End Sub

#End Region
#Region "Events"

    Private Sub frmMiscellaneous_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = getLabname()
        dtHospitalInfo = clsLaboratoryResult.getHospitalInfo()
        Me.lblHeader.Text = dtHospitalInfo.Rows(0).Item("Hospital").ToString()
        Me.lblAddress.Text = dtHospitalInfo.Rows(0).Item("Address3").ToString()
        Me.lablTelNo.Text = dtHospitalInfo.Rows(0).Item("Telephone").ToString()
        Try
            Dim tempphoto As Byte() = dtHospitalInfo.Rows(0).Item("hospitallogo")
            If IsDBNull(dtHospitalInfo.Rows(0).Item("hospitallogo")) Or tempphoto.Length = 0 Then
                pctrLogo.Image = Nothing
            Else
                pctrLogo.Image = Utility.convertImage(dtHospitalInfo.Rows(0).Item("hospitallogo")) 'image here
            End If
        Catch ex As Exception
        End Try
        If Me.laboratoryid = clsModel.LabFormats.ECGREPORT Then
            Me.lblpathodesignation.Text = "Cardiologist"
        ElseIf Me.laboratoryid = clsModel.LabFormats.NEWBORNSCREENING Then
            Me.panelnewborn.Visible = True
            Me.lblpathodesignation.Text = "Pediatrician"
            Me.dtNewBornResults = clsNewBornScreening.getNBSresults()
        End If
    End Sub
#End Region

#Region "Methods"
    Private Function getLabname() As String
        If Me.labname = "" Then
            Return "Laboratory"
        End If
        Return Me.labname
    End Function

    Public Sub loadRequestDetails(ByVal requestdetailno As Long)
        Me.requestdetailno = requestdetailno
        dtPatientDetails = clsLaboratoryResult.genericcls(14, requestdetailno)
        Me.admissionid = Utility.NullToZero(dtPatientDetails.Rows(0).Item("admissionid"))
        Me.laboratoryresultid = Utility.NullToZero(dtPatientDetails.Rows(0).Item("laboratoryresultid"))
        Me.labexaminationno = Utility.NullToZero(dtPatientDetails.Rows(0).Item("labexaminationno"))
        Me.itemcode = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("itemcode").ToString)
        If Me.labname = "" And Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("itemspecs")) <> "" Then
            Me.labname = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("itemspecs"))
        End If
        Me.txtRequestedby.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("requestedby").ToString)
        Me.txtPatientName.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("patient").ToString)
        Me.txtAge.Text = dtPatientDetails.Rows(0).Item("age").ToString
        Me.txtGender.Text = dtPatientDetails.Rows(0).Item("gender").ToString

        Me.lbltransdate.Text = Utility.NullToCurrentDate(dtPatientDetails.Rows(0).Item("daterequested")).ToString(modGlobal.defaultdateformat)
        Me.lbltranstime.Text = Utility.NullToCurrentDate(dtPatientDetails.Rows(0).Item("daterequested")).ToString(modGlobal.defaulttimeformat)
        Me.lbldateencoded.Text = Utility.NullToCurrentDate(dtPatientDetails.Rows(0).Item("resultdatesubmitted")).ToString(modGlobal.defaultdateformat)
        Me.lbltimeencoded.Text = Utility.NullToCurrentDate(dtPatientDetails.Rows(0).Item("resultdatesubmitted")).ToString(modGlobal.defaulttimeformat)
        Me.medtech = dtPatientDetails.Rows(0).Item("medicaltechnologist")
        Me.patho = dtPatientDetails.Rows(0).Item("pathologist")
        Me.txtmother.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("mothername").ToString)
        Me.txtcontactno.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("mobileno").ToString)
        Me.lblptno.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("ptno").ToString)
        Me.lblpatientaddress.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("homeaddress").ToString)
    End Sub
    
    Private Sub panel_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        Dim panel As Control = CType(sender, Control)
        Me.baseForm.onPanelDoubleClick(panel.Name.Replace("panel_", ""), panel.Location.X, panel.Location.Y, panel.Width, panel.Height)
    End Sub
    Private Sub label_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        Dim panel As Control = CType(sender, Control).Parent
        Me.baseForm.onPanelDoubleClick(panel.Name.Replace("panel_", ""), panel.Location.X, panel.Location.Y, panel.Width, panel.Height)
    End Sub
    Public Sub DisplayPrintPreview()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Text = ""
        Call clsadmissiondocuments.SaveLabResultImage(requestdetailno, Me.admissionid, GetFormImage(True), "RadLab_" & Me.labname & "_")
        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MiscPrintDocu.PrinterSettings = PrintDialog1.PrinterSettings
            MiscPrintDocu.Print()
        End If

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.Text = getLabname()
    End Sub
    Private Function GetFormImage(ByVal include_borders As Boolean) As Bitmap
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Me.Text = ""
        ' Make the bitmap.
        Dim wid As Integer = Me.Width
        Dim hgt As Integer = Me.Height
        Dim bm As New Bitmap(wid, hgt)
        ' Draw the form onto the bitmap.
        Me.DrawToBitmap(bm, New Rectangle(0, 0, wid, hgt))
        ' Make a smaller bitmap without borders.
        wid = Me.ClientSize.Width
        hgt = Me.ClientSize.Height
        Dim bm2 As New Bitmap(wid, hgt)
        ' Get the offset from the window's corner to its client
        ' area's corner.
        Dim pt As New Point(0, 0)
        pt = PointToScreen(pt)
        Dim dx As Integer = pt.X - Me.Left
        Dim dy As Integer = pt.Y - Me.Top
        ' Copy the part of the original bitmap that we want
        ' into the bitmap.
        Dim gr As Graphics = Graphics.FromImage(bm2)
        gr.DrawImage(bm, 0, 0, New Rectangle(dx, dy, wid, hgt), GraphicsUnit.Pixel)
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        'Me.Text = Labname
        Return bm
    End Function
#End Region


    Private Sub MiscPrintDocu_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles MiscPrintDocu.PrintPage
        e.Graphics.DrawImage(GetFormImage(False), New Point(15, 0))
    End Sub


    Public Sub lock()
        Dim dtdatenow As Date = Utility.GetServerDate()
        Me.lblprinttime.Text = dtdatenow.ToString(modGlobal.defaulttimeformat)
        Me.lblprintdate.Text = dtdatenow.ToString(modGlobal.defaultdateformat)
        Me.lblpatho.Visible = True
    End Sub

    Private Sub RichTextBox1_ContentsResized(sender As System.Object, e As System.Windows.Forms.ContentsResizedEventArgs) Handles RichTextBox1.ContentsResized
        RichTextBox1.Height = e.NewRectangle.Height + 12
    End Sub

    Private Sub frmRTFPrint_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown

        DisplayPrintPreview()
    End Sub
End Class