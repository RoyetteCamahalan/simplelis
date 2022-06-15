Imports System.Drawing.Drawing2D
'***********
'*    Author: Ronald Jumao-as
'*    Date Created: 06-05-12
'*
'**********

Imports System.Drawing.Imaging
Imports System.IO
Public Class frmCrossMatchingNew
    '#Region "Variables"


    Private requestdetailno As Long
    Private laboratoryid As Long
    Private labname As String
    Private itemcode As String
    Private Islock As Boolean

    Dim dtHospitalInfo As New DataTable

    '    'Royette 2021-07-29
    Private rowheight As Integer = 22
    Private afterload As Boolean
    Private admissionid As Long
    Private labexaminationno As String
    Private laboratoryresultid As Long
    Private crossmatchingresultid As Long
    Private medtech As Long = 0
    Private patho As Long = 0

    Public issave As Boolean
    Dim erp As New ErrorProvider
    '#End Region
#Region "Constructor"
    Public Sub New(ByVal requestdetailno As Long, ByVal laboratoryid As Long, ByVal labname As String, ByVal Islock As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.requestdetailno = requestdetailno
        Me.laboratoryid = laboratoryid
        Me.labname = labname
        Me.Islock = Islock
    End Sub
#End Region
#Region "Events"

    Private Sub frmMiscellaneous_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = getLabname()
        dtHospitalInfo = clsLaboratoryResult.getHospitalInfo()
        Me.lblHeader.Text = dtHospitalInfo.Rows(0).Item("Hospital").ToString()
        Me.lblAddress.Text = dtHospitalInfo.Rows(0).Item("Address2").ToString()
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

        Call LoadXmatchBloods()
        Call LoadXmatch()
        Call LoadRecord()
        Call LoadCombo()
        If Islock Then
            lock()
        End If
    End Sub
#End Region

#Region "Methods"
    Private Function getLabname() As String
        Return Me.labname
    End Function
    Public Sub LoadRecord()
        Dim dtRecord As DataTable = clsLaboratoryResult.genericcls(14, requestdetailno)
        Me.admissionid = Utility.NullToZero(dtRecord.Rows(0).Item("admissionid"))
        Me.labexaminationno = Utility.NullToEmptyString(dtRecord.Rows(0).Item("labexaminationno").ToString)
        Me.itemcode = Utility.NullToEmptyString(dtRecord.Rows(0).Item("itemcode").ToString)
        Me.txtRequestedby.Text = Utility.NullToEmptyString(dtRecord.Rows(0).Item("requestedby").ToString)
        Me.txtPatientName.Text = Utility.NullToEmptyString(dtRecord.Rows(0).Item("patient").ToString)
        Me.txtAge.Text = dtRecord.Rows(0).Item("age").ToString
        Me.txtGender.Text = dtRecord.Rows(0).Item("gender").ToString

        Me.lblMisc.Text = getLabname()
        Me.dtDate.Value = Utility.NullToCurrentDate(dtRecord.Rows(0).Item("resultdatesubmitted"))
        Me.txtdate.Text = Me.dtDate.Value.ToString("yyyy/MM/dd")
        Me.medtech = dtRecord.Rows(0).Item("medicaltechnologist")
        Me.patho = dtRecord.Rows(0).Item("pathologist")
        Me.laboratoryresultid = dtRecord.Rows(0).Item("laboratoryresultid")

        If Me.laboratoryresultid > 0 Then
            Dim dtxmatching As DataTable = clsCrossmatching.getlabresultxmtching(Me.laboratoryresultid)
            Me.crossmatchingresultid = dtxmatching.Rows(0).Item("laboratoryresultcrossmatchingid")
            cmbpatientrh.Text = dtxmatching.Rows(0).Item("patientrh")
            Me.txtpatientblood.Text = cmbpatientrh.Text
            cmbdonorsrh.Text = dtxmatching.Rows(0).Item("donorrh")
            Me.txtdonorblood.Text = cmbdonorsrh.Text
        End If
        Dim dtLabResultDetails As DataTable = clsCrossmatching.getlabresultxmtchingdetail(Me.laboratoryresultid)
        For ctr As Integer = 0 To dtLabResultDetails.Rows.Count - 1
            dgvCrossM.Rows.Add()
            Me.dgvCrossM.Rows(ctr).Cells(0).Value = dtLabResultDetails.Rows(ctr)(2).ToString
            Me.dgvCrossM.Rows(ctr).Cells(1).Value = dtLabResultDetails.Rows(ctr)(3).ToString
            Me.dgvCrossM.Rows(ctr).Cells(2).Value = dtLabResultDetails.Rows(ctr)(4).ToString
            Me.dgvCrossM.Rows(ctr).Cells(3).Value = dtLabResultDetails.Rows(ctr)(5).ToString
            Me.dgvCrossM.Rows(ctr).Cells(4).Value = CDate(dtLabResultDetails.Rows(ctr)(6).ToString)
            Me.dgvCrossM.Rows(ctr).Cells(5).Value = CDate(dtLabResultDetails.Rows(ctr)(7).ToString)
            Me.dgvCrossM.Rows(ctr).Cells(6).Value = dtLabResultDetails.Rows(ctr)(8).ToString
        Next
    End Sub

    Private Sub LoadCombo()

        afterload = False
        Me.cmbPathologist.DataSource = clsLaboratoryResult.getPathologist("777")
        Me.cmbPathologist.DisplayMember = "radiologist"
        Me.cmbPathologist.ValueMember = "employeeid"
        Me.cmbPathologist.SelectedIndex = -1
        afterload = True
        If patho > 0 Then
            Me.cmbPathologist.SelectedValue = patho
        ElseIf Me.cmbPathologist.Items.Count > 0 Then
            Me.cmbPathologist.SelectedIndex = 0
        End If

        afterload = False
        Me.cmbMedtech.DataSource = clsLaboratoryResult.getPathologist("666")
        Me.cmbMedtech.DisplayMember = "radiologist"
        Me.cmbMedtech.ValueMember = "employeeid"
        Me.cmbMedtech.SelectedIndex = -1
        afterload = True
        If medtech > 0 Then
            Me.cmbMedtech.SelectedValue = medtech
        ElseIf Me.cmbMedtech.Items.Count > 0 Then
            Me.cmbMedtech.SelectedIndex = 0
        End If

    End Sub
    Private Function isallfieldvalid() As Boolean
        Dim isvalid As Boolean = True
        If Me.cmbpatientrh.Text = "" Then
            isvalid = False
            erp.SetError(Me.cmbpatientrh, "This field is required!")
        End If
        erp.SetError(Me.cmbpatientrh, "")
        If Me.cmbdonorsrh.Text = "" Then
            isvalid = False
            erp.SetError(Me.cmbdonorsrh, "This field is required!")
        End If
        erp.SetError(Me.cmbdonorsrh, "")
        Return isvalid
    End Function

    Public Sub save()
        Me.dgvCrossM.EndEdit()
        If Not isallfieldvalid() Then
            Exit Sub
        End If
        Dim myLaboratoryResult As New clsLaboratoryResult
        With myLaboratoryResult
            .Oldlaboratoryid = Me.laboratoryresultid
            .laboratoryid = Me.laboratoryid
            .itemcode = itemcode
            .admissionid = Me.admissionid
            .patientrequestno = requestdetailno
            .labno = Me.labexaminationno
            .specimen = ""
            .datesubmitted = Utility.GetServerDate()
            .dateencoded = Utility.GetServerDate()
            .encodedby = modGlobal.userid
            .pathologist = Me.cmbPathologist.SelectedValue
            .medtech = Me.cmbMedtech.SelectedValue
            .medicaltechnologist = Me.cmbMedtech.SelectedValue
            .releasedby = 1
            .datereleased = "01/01/1990"
            If Me.laboratoryresultid = 0 Then
                Me.laboratoryresultid = .Save(True)
            Else
                .Save(False)
            End If
            If Me.laboratoryresultid > 0 Then
                Dim myXmatching As New clsCrossmatching
                myXmatching.labresultid = Me.laboratoryresultid
                myXmatching.patientrh = Me.cmbpatientrh.Text
                myXmatching.donorrh = Me.cmbdonorsrh.Text
                myXmatching.labno = Me.labexaminationno

                If Me.crossmatchingresultid = 0 Then
                    myXmatching.saveLRXmatching(True)
                Else
                    myXmatching.saveLRXmatching(False)
                End If
                Me.issave = True
                myXmatching.deleteXmatchingdetails(Me.laboratoryresultid)
                For ctr As Integer = 0 To dgvCrossM.Rows.Count - 2
                    myXmatching.bloodsource = dgvCrossM.Item(0, ctr).Value
                    myXmatching.serialno = dgvCrossM.Item(1, ctr).Value
                    myXmatching.bloodcomponent = dgvCrossM.Item(2, ctr).Value
                    myXmatching.volume = dgvCrossM.Item(3, ctr).Value
                    myXmatching.dateextracted = Utility.NullToCurrentDate((dgvCrossM.Item(4, ctr).Value))
                    myXmatching.dateexpired = Utility.NullToCurrentDate((dgvCrossM.Item(5, ctr).Value))
                    myXmatching.remarks = dgvCrossM.Item(6, ctr).Value
                    myXmatching.saveLRXmatchingResultDetail(True)
                Next
            End If
        End With
        lock()
    End Sub
    Public Sub lock()
        Me.dtDate.Visible = False
        Me.txtdate.Visible = True
        Me.cmbPathologist.Visible = False
        Me.cmbMedtech.Visible = False
        Me.lblpatho.Visible = True
        Me.lblmedtech.Visible = True
        Me.cmbpatientrh.Visible = False
        Me.txtpatientblood.Visible = True
        Me.cmbdonorsrh.Visible = False
        Me.txtdonorblood.Visible = True
        Me.dgvCrossM.ReadOnly = True
        Me.dgvCrossM.AllowUserToAddRows = False
        Me.dgvCrossM.RowHeadersVisible = False
        Me.dgvCrossM.RowsDefaultCellStyle.SelectionBackColor = Color.White
        Me.dgvCrossM.RowsDefaultCellStyle.SelectionForeColor = Color.Black
        'For i As Integer = Me.dgvResult.Rows.Count - 1 To 0 Step -1
        '    If Utility.NullToEmptyString(Me.dgvResult.Rows(i).Cells(colresult.Index).Value) = "" Then
        '        Me.dgvResult.Rows.RemoveAt(i)
        '        Call reduceForm()
        '    Else
        '        Me.dgvResult.Rows(i).Cells(colunits.Index).Value = Me.dgvResult.Rows(i).Cells(colresult.Index).Value & " " & Me.dgvResult.Rows(i).Cells(colunits.Index).Value
        '    End If
        'Next
        'Me.panelmanageparams.Visible = False
        'Me.dgvResult.Columns(colunits.Index).Width = CInt(Me.dgvResult.Columns(colunits.Index).Width + (Me.dgvResult.Columns(colresult.Index).Width / 2))
        'Me.dgvResult.Columns(colresult.Index).Visible = False
        'Me.dgvResult.Columns(colunits.Index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Me.dgvResult.Columns(colunits.Index).DefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Bold)
        'Me.dgvResult.Columns(colunits.Index).HeaderText = "Result"
    End Sub

    Private Sub getEmployeeInfo(ByVal employeeid As String, ByVal ispatho As Boolean)
        Dim dt As DataTable = clsRadiology.genericcls(8, employeeid)
        If dt.Rows.Count = 0 Then
            Exit Sub
        End If
        If ispatho Then 'Patho
            Me.lblpatho.Text = Me.cmbPathologist.Text
            Me.lblpatholicense.Text = "License No. " & dt.Rows(0).Item("prcno")
            If Utility.NullToEmptyString(dt.Rows(0).Item("designation")) = "" Then
                Me.lblpathodesignation.Text = "Clinical Pathologist"
            Else
                Me.lblpathodesignation.Text = dt.Rows(0).Item("designation")
            End If
        Else 'Medtech
            Me.lblmedtech.Text = Me.cmbMedtech.Text
            Me.lblmedtechlicense.Text = "License No. " & dt.Rows(0).Item("prcno")
            If Utility.NullToEmptyString(dt.Rows(0).Item("designation")) = "" Then
                Me.lblmedtechdesignation.Text = "Medical Technologist"
            Else
                Me.lblmedtechdesignation.Text = dt.Rows(0).Item("designation")
            End If
        End If
    End Sub
    Public Sub LoadXmatchBloods()

        cmbpatientrh.Items.Clear()
        cmbpatientrh.Items.Add("Unknown")
        cmbpatientrh.Items.Add("A Positive")
        cmbpatientrh.Items.Add("A Negative")
        cmbpatientrh.Items.Add("A Unknown")
        cmbpatientrh.Items.Add("B Positive")
        cmbpatientrh.Items.Add("B Negative")
        cmbpatientrh.Items.Add("B Unknown")
        cmbpatientrh.Items.Add("AB Positive")
        cmbpatientrh.Items.Add("AB Negative")
        cmbpatientrh.Items.Add("AB Unknown")
        cmbpatientrh.Items.Add("O Positive")
        cmbpatientrh.Items.Add("O Negative")
        cmbpatientrh.Items.Add("O Unknown")
        cmbpatientrh.SelectedIndex = 0

        cmbdonorsrh.Items.Clear()
        cmbdonorsrh.Items.Add("Unknown")
        cmbdonorsrh.Items.Add("A Positive")
        cmbdonorsrh.Items.Add("A Negative")
        cmbdonorsrh.Items.Add("A Unknown")
        cmbdonorsrh.Items.Add("B Positive")
        cmbdonorsrh.Items.Add("B Negative")
        cmbdonorsrh.Items.Add("B Unknown")
        cmbdonorsrh.Items.Add("AB Positive")
        cmbdonorsrh.Items.Add("AB Negative")
        cmbdonorsrh.Items.Add("AB Unknown")
        cmbdonorsrh.Items.Add("O Positive")
        cmbdonorsrh.Items.Add("O Negative")
        cmbdonorsrh.Items.Add("O Unknown")
        cmbdonorsrh.SelectedIndex = 0
    End Sub
    Public Sub LoadXmatch()
        Dim ColumnDateExtracted As New CalendarColumn()
        Dim ColumnDateExpired As New CalendarColumn()
        ColumnDateExtracted.Name = "Date Extracted"
        ColumnDateExpired.Name = "Date Expired"
        With Me.dgvCrossM
            .DefaultCellStyle.Font = New Font("Calibri", 10)
            .RowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns.Add(0, "Blood Source")
            .Columns(0).Width = 110
            .Columns(0).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)
            .Columns.Add(1, "Serial No.")
            .Columns(1).Width = 110
            .Columns(1).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)
            .Columns.Add(2, "Blood Component")
            .Columns(2).Width = 110
            .Columns(2).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)

            .Columns.Add(3, "Volume")
            .Columns(3).Width = 100
            .Columns(3).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)

            .Columns.Add(ColumnDateExtracted)
            .Columns(4).Width = 100
            .Columns(4).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)
            .Columns.Add(ColumnDateExpired)
            .Columns(5).Width = 130
            .Columns(5).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)
            .Columns.Add(5, "Remarks")
            .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns(6).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)
        End With

    End Sub
#End Region

#Region "Printing"
    'Call in Printing
    Public Sub DisplayPrintPreview()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Text = ""
        Call clsadmissiondocuments.SaveLabResultImage(requestdetailno, Me.admissionid, GetFormImage(True), "RadLab_CrossMatching_")
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

    Private Sub cmbMedtech_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbMedtech.SelectedValueChanged
        If afterload AndAlso cmbMedtech.SelectedIndex >= 0 Then
            Call getEmployeeInfo(cmbMedtech.SelectedValue, False)
        End If
    End Sub

    Private Sub txtPathologist_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cmbPathologist.SelectedValueChanged
        If afterload AndAlso cmbPathologist.SelectedIndex >= 0 Then
            Call getEmployeeInfo(cmbPathologist.SelectedValue, True)
        End If
    End Sub

    Private Sub MiscPrintDocu_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles MiscPrintDocu.PrintPage
        e.Graphics.DrawImage(GetFormImage(False), New Point(15, 0))
    End Sub
End Class