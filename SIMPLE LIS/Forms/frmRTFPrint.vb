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
    Public requestdetailno As Long
    Private dtPatientDetails As New DataTable

    Public admissionid As Long

#End Region
#Region "Events"

    Private Sub frmMiscellaneous_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Call loadRequestDetails(Me.requestdetailno)
    End Sub
#End Region

#Region "Methods"
    Public Sub loadRequestDetails(ByVal requestdetailno As Long)
        Me.requestdetailno = requestdetailno
        dtPatientDetails = clsRadiology.getRadiologyResultDetails(requestdetailno, 9)
        Me.admissionid = Utility.NullToZero(dtPatientDetails.Rows(0).Item("admissionid"))
        Me.lblexamination.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("itemspecs"))
        Me.txtPatientName.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("patient").ToString)

        Me.lblprintdate.Text = Utility.NullToCurrentDate(dtPatientDetails.Rows(0).Item("printdate")).ToString(modGlobal.defaulttimeformat)
        Me.lbltestdate.Text = Utility.NullToCurrentDate(dtPatientDetails.Rows(0).Item("dateencoded")).ToString(modGlobal.defaultdateformat)
        Me.lblptno.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("ptno").ToString)
        Me.lblpatientaddress.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("homeaddress").ToString)

        Me.lblradiologist.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("radiologistname").ToString)
        Me.lblradiolicense.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("radiologistlicense").ToString)
        Me.lblradiodesignation.Text = Utility.NullToEmptyString(dtPatientDetails.Rows(0).Item("radiologistdesignation").ToString)
        Try
            Dim tempphoto As Byte() = dtPatientDetails.Rows(0).Item("radiologistsign")
            If IsDBNull(dtPatientDetails.Rows(0).Item("radiologistsign")) Or tempphoto.Length = 0 Then
                panelpatho.BackgroundImage = Nothing
            Else
                panelpatho.BackgroundImage = Utility.convertImage(dtPatientDetails.Rows(0).Item("radiologistsign")) 'image here
            End If
            Catch ex As Exception
            End Try
    End Sub

    Public Sub DisplayPrintPreview()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Text = ""
        Call clsadmissiondocuments.SaveLabResultImage(requestdetailno, Me.admissionid, GetFormImage(True), "RadLab_" & Me.lblexamination.Text & "_")
        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MiscPrintDocu.PrinterSettings = PrintDialog1.PrinterSettings
            MiscPrintDocu.Print()
        End If

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
    End Sub
    Private Function GetFormImage(ByVal include_borders As Boolean) As Bitmap
        ' Dim wid As Integer = Me.Width
        ' Dim hgt As Integer = Me.Height
        ' Dim bm As New Bitmap(wid, hgt)
        ' ' Draw the form onto the bitmap.
        ' Me.DrawToBitmap(bm, New Rectangle(0, 0, wid, hgt))
        ' ' Make a smaller bitmap without borders.
        ' 'wid = Me.ClientSize.Width
        ' 'hgt = Me.ClientSize.Height
        ' 'Dim bm2 As New Bitmap(wid, hgt)
        ' '' Get the offset from the window's corner to its client
        ' '' area's corner.
        ' 'Dim pt As New Point(0, 0)
        ' 'pt = PointToScreen(pt)
        ' 'Dim dx As Integer = pt.X - Me.Left
        ' 'Dim dy As Integer = pt.Y - Me.Top
        ' '' Copy the part of the original bitmap that we want
        ' '' into the bitmap.
        ' 'Dim gr As Graphics = Graphics.FromImage(bm2)
        ' 'gr.DrawImage(bm, 0, 0, New Rectangle(dx, dy, wid, hgt), GraphicsUnit.Pixel)

        ' Dim rtf = DirectCast(Me.Controls.Find("rtfcontainer", True).First(), RichTextBox)
        ' rtf.draw()

        ''Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        ' 'Me.Text = Labname
        ' Return bm

        Dim myGraphics = Me.CreateGraphics()
        Dim s = Me.ClientSize
        Dim memoryImage = New Bitmap(s.Width, s.Height, myGraphics)
        Dim memoryGraphics = Graphics.FromImage(memoryImage)
        memoryGraphics.CopyFromScreen(Me.Location.X, Me.Location.Y, 0, 0, s)
        Return memoryImage
    End Function
#End Region


    Private Sub MiscPrintDocu_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles MiscPrintDocu.PrintPage
        e.Graphics.DrawImage(GetFormImage(False), New Point(0, 0))
    End Sub


    Private Sub frmRTFPrint_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown

    End Sub

End Class