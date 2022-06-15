Imports System.Drawing.Drawing2D
'***********
'*    Author: Ronald Jumao-as
'*    Date Created: 06-05-12
'*
'**********

Imports System.Drawing.Imaging
Imports System.IO
Public Class frmtemplatewithconversion
    '#Region "Variables"


    Private requestdetailno As Long
    Private laboratoryid As Long
    Private labname As String
    Private itemcode As String
    Private Islock As Boolean

    Dim dtHospitalInfo As New DataTable

    '    'Royette 2021-07-29
    Private rowheight As Integer = 22
    Private afterload As Boolean = True
    Private admissionid As Long
    Private labexaminationno As String
    Private laboratoryresultid As Long
    Private medtech As Long = 0
    Private patho As Long = 0
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
        afterload = False
        Dim dtLabResultDetails As DataTable = clsLaboratoryResultDetails.getLaboratoryResultDetails(Me.requestdetailno, "", Me.laboratoryid, 2)
        For Each row As DataRow In dtLabResultDetails.Rows
            If row.Item("visible") Then
                Call AddRow(row.Item("laboratorydetailsid"),
                       row.Item("laboratoryresultdetailsid"),
                       row.Item("description"),
                       row.Item("normalvalues"),
                       row.Item("unit"),
                        row.Item("normalvaluessi"),
                       row.Item("unitsi"),
                       CDbl(row.Item("siconversion")),
                       Utility.NullToEmptyString(row.Item("result")))
            End If
        Next
        afterload = True
    End Sub
    Private Sub AddRow(ByVal laboratorydetailsid As Long,
                       ByVal laboratoryresultdetailsid As String,
                       ByVal description As String,
                       ByVal normalvalues As String,
                       ByVal unit As String,
                       ByVal normalvaluessi As String,
                       ByVal unitsi As String,
                       ByVal siconversion As Double,
                       ByVal result As String)
        Me.dgvResult.Rows.Add(1)
        Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(collabdetailid.Index).Value = laboratorydetailsid
        Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colparameter.Index).Value = description
        Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colref.Index).Value = normalvalues
        Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colunits.Index).Value = unit
        Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(collabresultdetailid.Index).Value = laboratoryresultdetailsid
        Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colrefsi.Index).Value = normalvaluessi
        Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colunitsi.Index).Value = unitsi
        Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colsiconversion.Index).Value = siconversion
        If unit = "" And normalvalues = "" Then
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colresult.Index).ReadOnly = True
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colresult.Index).Value = ""
        Else
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colresult.Index).Value = result
            computeConversion(Me.dgvResult.Rows.Count - 1, colresultsi.Index, result)
        End If
        If unitsi = "" And normalvaluessi = "" Then
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colresultsi.Index).ReadOnly = True
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colresultsi.Index).Value = ""
        ElseIf unit = "" And normalvalues = "" Then
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colresultsi.Index).Value = result
            If unit <> "" Or normalvalues <> "" Then
                computeConversion(Me.dgvResult.Rows.Count - 1, colresult.Index, result)
            End If
        End If
        Call adjustForm()
    End Sub
    Private Sub computeConversion(ByVal rowIndex As Integer, ByVal resultIndex As Integer, ByVal result As String)
        Try
            Me.dgvResult.Rows(rowIndex).Cells(resultIndex).Value = CDbl(result / Me.dgvResult.Rows(rowIndex).Cells(colsiconversion.Index).Value).ToString("N2")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub adjustForm()
        If Me.dgvResult.Rows.Count > 15 Then
            Exit Sub
        End If
        Me.dgvResult.Height = Me.dgvResult.Height + rowheight
        Me.panelresult.Height = Me.panelresult.Height + rowheight
        Me.panelmain.Height = Me.panelmain.Height + rowheight
        Me.Height = Me.Height + rowheight
    End Sub
    Private Sub reduceForm()
        If Me.dgvResult.Rows.Count > 15 Or Me.dgvResult.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.dgvResult.Height = Me.dgvResult.Height - rowheight
        Me.panelresult.Height = Me.panelresult.Height - rowheight
        Me.panelmain.Height = Me.panelmain.Height - rowheight
        Me.Height = Me.Height - rowheight
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


    Public Sub save()
        Me.dgvResult.EndEdit()
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
                Dim myLaboratoryResultDetails As New clsLaboratoryResultDetails
                myLaboratoryResultDetails.laboratoryresultid = Me.laboratoryresultid
                For Each row As DataGridViewRow In Me.dgvResult.Rows
                    myLaboratoryResultDetails.laboratorydetailsid = row.Cells(collabdetailid.Index).Value
                    myLaboratoryResultDetails.Oldlaboratoryresultid = row.Cells(collabresultdetailid.Index).Value
                    If row.Cells(colref.Index).Value <> "" Or row.Cells(colunits.Index).Value <> "" Then
                        myLaboratoryResultDetails.result = row.Cells(colresult.Index).Value
                    ElseIf row.Cells(colrefsi.Index).Value <> "" Or row.Cells(colunitsi.Index).Value <> "" Then
                        myLaboratoryResultDetails.result = row.Cells(colresultsi.Index).Value
                    Else
                        myLaboratoryResultDetails.result = ""
                    End If
                    If myLaboratoryResultDetails.Oldlaboratoryresultid = 0 Then
                        myLaboratoryResultDetails.Save(True)
                    Else
                        myLaboratoryResultDetails.Save(False)
                    End If
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
        'Dim hasunits As Boolean = False
        For i As Integer = Me.dgvResult.Rows.Count - 1 To 0 Step -1
            If Utility.NullToEmptyString(Me.dgvResult.Rows(i).Cells(colresult.Index).Value) = "" And Utility.NullToEmptyString(Me.dgvResult.Rows(i).Cells(colresultsi.Index).Value) = "" Then
                Me.dgvResult.Rows.RemoveAt(i)
                Call reduceForm()
            Else
                Me.dgvResult.Rows(i).Cells(colunits.Index).Value = Me.dgvResult.Rows(i).Cells(colresult.Index).Value & " " & Me.dgvResult.Rows(i).Cells(colunits.Index).Value
                Me.dgvResult.Rows(i).Cells(colunitsi.Index).Value = Me.dgvResult.Rows(i).Cells(colresultsi.Index).Value & " " & Me.dgvResult.Rows(i).Cells(colunitsi.Index).Value
                '    If Utility.NullToEmptyString(Me.dgvResult.Rows(i).Cells(colunits.Index).Value) <> "" Then
                '        hasunits = True
                '    End If
            End If
        Next
        Me.panelmanageparams.Visible = False
        Me.dgvResult.Columns(colresult.Index).DefaultCellStyle.BackColor = Color.White
        Me.dgvResult.Columns(colunitsi.Index).Width = Me.dgvResult.Columns(colunitsi.Index).Width + Me.dgvResult.Columns(colresultsi.Index).Width
        Me.dgvResult.Columns(colresult.Index).Visible = False
        Me.dgvResult.Columns(colresultsi.Index).Visible = False
        Me.dgvResult.Columns(colunitsi.Index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvResult.Columns(colunits.Index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.dgvResult.Columns(colunitsi.Index).DefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Bold)
        Me.dgvResult.Columns(colunits.Index).DefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Bold)
        'If Not hasunits Then
        '    Me.dgvResult.Columns(colunits.Index).Visible = False
        'End If
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
#End Region

#Region "Printing"
    'Call in Printing
    Public Sub DisplayPrintPreview()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Text = ""
        Call DisplayPrintPDF()
        'dlgPrintPreview.Document.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", 850, 450)
        'dlgPrintPreview.PrintPreviewControl.Zoom = 1.0
        'dlgPrintPreview.Document.DefaultPageSettings.Margins = New Printing.Margins(150, 150, 200, 200)

        'dlgPrintPreview.WindowState = FormWindowState.Maximized
        'dlgPrintPreview.ShowDialog()
        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MiscPrintDocu.PrinterSettings = PrintDialog1.PrinterSettings
            MiscPrintDocu.Print()
        End If

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.Text = getLabname()
    End Sub
    Public Sub DisplayPrintPDF()
        Dim filename As String = "RadLab_Misc_" & requestdetailno & ".jpg"
        Dim destfolder As String = "\documents\" & Me.admissionid
        Dim destfile As String = destfolder & "\" & filename


        If Not Directory.Exists(gDocumentLocationEMR & destfolder) Then
            Directory.CreateDirectory(gDocumentLocationEMR & destfolder)
        End If
        If File.Exists(gDocumentLocationEMR & destfile) Then
            Exit Sub
        End If
        GetFormImage(True).Save(gDocumentLocationEMR & destfile, ImageFormat.Jpeg)


        Dim odocuments As New clsadmissiondocuments
        Dim dtadmissiondocuments As DataTable = createDataTable()

        dtadmissiondocuments.Rows.Add(Me.admissionid,
                                                      requestdetailno,
                                                      destfile,
                                                      Path.GetFileName(destfile),
                                                      "",
                                                      "RadLab",
                                                      userid,
                                                      Utility.GetServerDate,
                                                      1,
                                                      False
                                                      )

        If dtadmissiondocuments.Rows.Count > 0 Then
            Call odocuments.saveAdmissionDocuments(dtadmissiondocuments)
            dtadmissiondocuments.Rows.Clear()
        End If
    End Sub
    Private Function createDataTable() As DataTable
        Dim dt As New DataTable
        With dt.Columns
            .Add(New DataColumn("[admissionid]", GetType(Integer)))
            .Add(New DataColumn("[documentcode]", GetType(String)))
            .Add(New DataColumn("[documentlocation]", GetType(String)))
            .Add(New DataColumn("[documentname]", GetType(String)))
            .Add(New DataColumn("[documenturl]", GetType(String)))
            .Add(New DataColumn("[documenttype]", GetType(String)))
            .Add(New DataColumn("createdbyid", GetType(Integer)))
            .Add(New DataColumn("datecreated", GetType(Date)))
            .Add(New DataColumn("[uploadsequence]", GetType(Integer)))
            .Add(New DataColumn("[isuploaded]", GetType(Boolean)))
        End With
        Return dt
    End Function
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

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        Dim f As New frmManageResultParams
        f.labid = Me.laboratoryid
        f.Labname = Me.labname
        f.hasSIvalue = True
        f.ShowDialog()
        If f.issave Then
            afterload = False
            Dim dt As DataTable = clsExamination.getLabdetails(Me.laboratoryid)
            dt.Columns.Add("result")
            dt.Columns.Add("laboratoryresultdetailsid")
            For i As Integer = 0 To dt.Rows.Count - 1
                For j As Integer = 0 To Me.dgvResult.Rows.Count - 1
                    If dt.Rows(i).Item("laboratorydetailsid") = Me.dgvResult.Rows(j).Cells(collabdetailid.Index).Value Then
                        If Utility.NullToEmptyString(Me.dgvResult.Rows(j).Cells(colresult.Index).Value) <> "" Then
                            dt.Rows(i).Item("result") = Utility.NullToEmptyString(Me.dgvResult.Rows(j).Cells(colresult.Index).Value)
                        Else
                            dt.Rows(i).Item("result") = Utility.NullToEmptyString(Me.dgvResult.Rows(j).Cells(colresultsi.Index).Value)
                        End If
                        dt.Rows(i).Item("laboratoryresultdetailsid") = Utility.NullToZero(Me.dgvResult.Rows(j).Cells(collabresultdetailid.Index).Value)
                        Me.dgvResult.Rows.RemoveAt(j)
                        reduceForm()
                        Exit For
                    End If
                Next
            Next
            For j As Integer = Me.dgvResult.Rows.Count - 1 To 0 Step -1
                Me.dgvResult.Rows.RemoveAt(j)
                reduceForm()
            Next
            For Each row As DataRow In dt.Rows
                If row.Item("visible") Then
                    Call AddRow(row.Item("laboratorydetailsid"),
                       Utility.NullToZero(row.Item("laboratoryresultdetailsid")),
                       row.Item("description"),
                       row.Item("normalvalues"),
                       row.Item("unit"),
                        row.Item("normalvaluessi"),
                       row.Item("unitsi"),
                       CDbl(row.Item("siconversion")),
                       Utility.NullToEmptyString(row.Item("result")))
                End If
            Next
            afterload = True
        End If
    End Sub

    Private Sub MiscPrintDocu_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles MiscPrintDocu.PrintPage
        e.Graphics.DrawImage(GetFormImage(False), New Point(15, 0))
    End Sub

    Private Sub dgvResult_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResult.CellValueChanged
        Try
            If afterload AndAlso e.RowIndex >= 0 AndAlso (e.ColumnIndex = colresult.Index Or e.ColumnIndex = colresultsi.Index) Then
                afterload = False
                If e.ColumnIndex = colresult.Index AndAlso Me.dgvResult.Rows(e.RowIndex).Cells(colrefsi.Index).Value <> "" AndAlso Me.dgvResult.Rows(e.RowIndex).Cells(colunitsi.Index).Value <> "" Then
                    Me.dgvResult.Rows(e.RowIndex).Cells(colresultsi.Index).Value = CDbl(Me.dgvResult.Rows(e.RowIndex).Cells(colresult.Index).Value * Me.dgvResult.Rows(e.RowIndex).Cells(colsiconversion.Index).Value).ToString("N2")
                ElseIf e.ColumnIndex = colresultsi.Index AndAlso Me.dgvResult.Rows(e.RowIndex).Cells(colref.Index).Value <> "" AndAlso Me.dgvResult.Rows(e.RowIndex).Cells(colunits.Index).Value <> "" Then
                    Me.dgvResult.Rows(e.RowIndex).Cells(colresult.Index).Value = CDbl(Me.dgvResult.Rows(e.RowIndex).Cells(colresultsi.Index).Value / Me.dgvResult.Rows(e.RowIndex).Cells(colsiconversion.Index).Value).ToString("N2")
                End If
                afterload = True
            End If
        Catch ex As Exception
            afterload = True
        End Try
    End Sub
End Class