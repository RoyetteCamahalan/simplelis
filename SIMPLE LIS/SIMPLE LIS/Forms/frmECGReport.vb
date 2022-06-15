Imports System.Drawing.Imaging
Imports System.IO

Public Class frmECGReport

#Region "Variables"
    Dim erp As New ErrorProvider
    Public isSave As Boolean
    Public myFormStatus As enFormStatus
    Public myResult As enResult
    Public itemscode As String
    'Public frmPrintings As New frmPrinting
    Dim itemscodeold As String
    Public adminid As String  'supply value
    Public patientrequestno As String
    Dim labno As String
    Public labid As String
    Public labresultid As DataTable
    Public requestdetailno As String 'patient request detail number
    Dim templabresultdetailsid As String
    Dim dECGReport As DataTable
    Public status As Integer
    Public Islock As Boolean
    Dim dtHospitalInfo As New DataTable()
    Enum enFormStatus
        browsing = 0            'edit fields disabled
        add = 1
        edit = 2
        view = 3
    End Enum
    Enum enResult
        manageresult = 4 '
        releaseresult = 5
    End Enum

    Dim Admission As New clsAdmission
#End Region

#Region "validation"
    Private Sub ResetAllErrorProviders()
        'Wipe any visible error messages and hide any visible error provider icon  
        SetErrorProvider(Me.txtRhythm)
        SetErrorProvider(Me.txtAtrialRate)
        SetErrorProvider(Me.txtecgdiagnosis)
        SetErrorProvider(Me.txtPR)
        SetErrorProvider(Me.txtQRS)
        SetErrorProvider(Me.txtQTc)
        SetErrorProvider(Me.txtQRSAxis)
        SetErrorProvider(Me.txtVenticularRate)
        SetErrorProvider(Me.cmbCardiologist)
        SetErrorProvider(Me.dtDate)
    End Sub
#End Region

#Region "Events"
    Private Sub SetErrorProvider(ByVal ctl As Control, Optional ByVal strErrorMessage As String = "")
        'Activate or deactivate an error provider for a data entry field
        erp.SetError(ctl, strErrorMessage)
    End Sub

    Private Sub frmECGReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'EnableFields()
        Call LoadCardio()
        'If myFormStatus = enFormStatus.browsing Or myFormStatus = enFormStatus.edit Then
        Call LoadECGReport()
        'End If
    End Sub

    Private Sub txtRhythm_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtRhythm(Me.txtRhythm)
    End Sub

    Private Sub txtAtrialRate_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtAtrialRate(Me.txtAtrialRate)
    End Sub
    Private Sub txtVenticularRate_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtVenticularRate(Me.txtecgdiagnosis)
    End Sub
    Private Sub txtPR_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtPR(Me.txtPR)
    End Sub
    Private Sub txtQRS_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtQRS(Me.txtQRS)
    End Sub
    Private Sub txtQTc_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtQTc(Me.txtQTc)
    End Sub
    Private Sub txtQRSAxis_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtQRSAxis(Me.txtQRSAxis)
    End Sub
    Private Sub txtecgdiagnosis_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtecgdiagnosis(Me.txtVenticularRate)
    End Sub
    Private Sub cmbCardiologist_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidcmbCardiologist(Me.cmbCardiologist)
    End Sub
    Private Sub dtDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValiddtDate(Me.dtDate)
    End Sub
#End Region

#Region "New Methods"
    Private Function isFieldValidtxtRhythm(ByRef vtxtRhythm As Control) As Boolean
        Dim isValidtxtRhythm As Boolean
        If vtxtRhythm.Text = "" Then
            SetErrorProvider(Me.txtRhythm, "Field is required.")
            isValidtxtRhythm = False
        Else
            SetErrorProvider(vtxtRhythm)
            isValidtxtRhythm = True
        End If
        Return isValidtxtRhythm
    End Function

    Private Function isFieldValidtxtAtrialRate(ByRef vtxtAtrialRate As Control) As Boolean
        Dim isValidtxtAtrialRate As Boolean
        If vtxtAtrialRate.Text = "" Then
            SetErrorProvider(Me.txtAtrialRate, "Field is required.")
            isValidtxtAtrialRate = False
        Else
            SetErrorProvider(vtxtAtrialRate)
            isValidtxtAtrialRate = True
        End If
        Return isValidtxtAtrialRate
    End Function
    Private Function isFieldValidtxtVenticularRate(ByRef vtxtVenticularRate As Control) As Boolean
        Dim isValidtxtVenticularRate As Boolean
        If vtxtVenticularRate.Text = "" Then
            SetErrorProvider(Me.txtecgdiagnosis, "Field is required.")
            isValidtxtVenticularRate = False
        Else
            SetErrorProvider(vtxtVenticularRate)
            isValidtxtVenticularRate = True
        End If
        Return isValidtxtVenticularRate
    End Function
    Private Function isFieldValidtxtPR(ByRef vtxtPR As Control) As Boolean
        Dim isValidtxtPR As Boolean
        If vtxtPR.Text = "" Then
            SetErrorProvider(Me.txtPR, "Field is required.")
            isValidtxtPR = False
        Else
            SetErrorProvider(vtxtPR)
            isValidtxtPR = True
        End If
        Return isValidtxtPR
    End Function
    Private Function isFieldValidtxtQRS(ByRef vtxtQRS As Control) As Boolean
        Dim isValidtxtQRS As Boolean
        If vtxtQRS.Text = "" Then
            SetErrorProvider(Me.txtAtrialRate, "Field is required.")
            isValidtxtQRS = False
        Else
            SetErrorProvider(vtxtQRS)
            isValidtxtQRS = True
        End If
        Return isValidtxtQRS
    End Function
    Private Function isFieldValidtxtQTc(ByRef vtxtQTc As Control) As Boolean
        Dim isValidtxtQTc As Boolean
        If vtxtQTc.Text = "" Then
            SetErrorProvider(Me.txtQTc, "Field is required.")
            isValidtxtQTc = False
        Else
            SetErrorProvider(vtxtQTc)
            isValidtxtQTc = True
        End If
        Return isValidtxtQTc
    End Function
    Private Function isFieldValidtxtQRSAxis(ByRef vtxtQRSAxis As Control) As Boolean
        Dim isValidtxtQRSAxis As Boolean
        If vtxtQRSAxis.Text = "" Then
            SetErrorProvider(Me.txtQRSAxis, "Field is required.")
            isValidtxtQRSAxis = False
        Else
            SetErrorProvider(vtxtQRSAxis)
            isValidtxtQRSAxis = True
        End If
        Return isValidtxtQRSAxis
    End Function
    Private Function isFieldValidtxtecgdiagnosis(ByRef vtxtecgdiagnosis As Control) As Boolean
        Dim isValidtxtecgdiagnosis As Boolean
        If vtxtecgdiagnosis.Text = "" Then
            SetErrorProvider(Me.txtVenticularRate, "Field is required.")
            isValidtxtecgdiagnosis = False
        Else
            SetErrorProvider(vtxtecgdiagnosis)
            isValidtxtecgdiagnosis = True
        End If
        Return isValidtxtecgdiagnosis
    End Function
    Private Function isFieldValidcmbCardiologist(ByRef vcmbCardiologist As Control) As Boolean
        Dim isValidcmbCardiologist As Boolean
        If vcmbCardiologist.Text = "" Then
            SetErrorProvider(Me.cmbCardiologist, "Field is required.")
            isValidcmbCardiologist = False
        Else
            SetErrorProvider(vcmbCardiologist)
            isValidcmbCardiologist = True
        End If
        Return isValidcmbCardiologist
    End Function
    Private Function isFieldValiddtDate(ByRef vdtDate As Control) As Boolean
        Dim isValiddtDate As Boolean
        If vdtDate.Text = "" Then
            SetErrorProvider(Me.dtDate, "Field is required.")
            isValiddtDate = False
        Else
            SetErrorProvider(vdtDate)
            isValiddtDate = True
        End If
        Return isValiddtDate
    End Function
#End Region

#Region "Methods"

    Public Sub EnableFields()

        If myFormStatus = enFormStatus.browsing Then

            Me.txtRhythm.Enabled = False
            Me.txtAtrialRate.Enabled = False
            Me.txtecgdiagnosis.Enabled = False
            Me.txtPR.Enabled = False
            Me.txtQRS.Enabled = False
            Me.txtQTc.Enabled = False
            Me.txtQRSAxis.Enabled = False
            Me.txtVenticularRate.Enabled = False
            Me.cmbCardiologist.Enabled = False
            Me.dtDate.Enabled = False

        End If
    End Sub
    Public Sub DisplayPrintPreview()
        Call DisplayPrintPDF()
        Dim fReportHander As New frmReport
        fReportHander.printType = "ECG REPORT MAIN"
        fReportHander.varno = adminid
        fReportHander.varstr = requestdetailno
        fReportHander.ShowDialog()

    End Sub
    Public Sub DisplayPrintPDF()
        Dim filename As String = "RadLab_ECG_" & requestdetailno & ".jpg"
        Dim destfolder As String = "\documents\" & Admission.AdmissionID
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

        dtadmissiondocuments.Rows.Add(Admission.AdmissionID,
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
        Return bm
    End Function
    Public Sub SaveRecord()
        Dim myECGReport As New clsECGReport
        Dim frmMDIParents As New frmMDIParent(frmMDIParent.enFormStatus.add)
        Me.dECGReport = clsECGReport.getECGReportdetail("7")
        For ctr As Integer = 0 To dECGReport.Rows.Count - 1
            myECGReport.labresultid = requestdetailno

            If ctr = 0 Then
                myECGReport.labdetailid = dECGReport.Rows(ctr)(1).ToString
                myECGReport.result = Me.txtRhythm.Text
            ElseIf ctr = 1 Then
                myECGReport.labdetailid = dECGReport.Rows(ctr)(1).ToString
                myECGReport.result = Me.txtAtrialRate.Text
            ElseIf ctr = 2 Then
                myECGReport.labdetailid = dECGReport.Rows(ctr)(1).ToString
                myECGReport.result = Me.txtVenticularRate.Text
            ElseIf ctr = 3 Then
                myECGReport.labdetailid = dECGReport.Rows(ctr)(1).ToString
                myECGReport.result = Me.txtPR.Text
            ElseIf ctr = 4 Then
                myECGReport.labdetailid = dECGReport.Rows(ctr)(1).ToString
                myECGReport.result = Me.txtQRS.Text
            ElseIf ctr = 5 Then
                myECGReport.labdetailid = dECGReport.Rows(ctr)(1).ToString
                myECGReport.result = Me.txtQTc.Text
            ElseIf ctr = 6 Then
                myECGReport.labdetailid = dECGReport.Rows(ctr)(1).ToString
                myECGReport.result = Me.txtQRSAxis.Text
            ElseIf ctr = 7 Then
                myECGReport.labdetailid = dECGReport.Rows(ctr)(1).ToString
                myECGReport.result = Me.txtecgdiagnosis.Text
            End If
            If myFormStatus = enFormStatus.add Then
                myECGReport.saveECGReport(True)
            Else
                myECGReport.saveECGReport(False)
            End If
        Next
        myFormStatus = enFormStatus.browsing

    End Sub

    Public Sub UpdateRequestStatus()
        Dim Myrequest As New clsExaminationUpshots

        Myrequest.status = status
        Myrequest.patientreqdetailno = requestdetailno

        If myFormStatus = enFormStatus.add Or myFormStatus = enFormStatus.edit Then
            Myrequest.save(False)
        Else
            'Myrequest.Oldlaboratoryid = Convert.ToInt32(labid.Rows(0)(0).ToString())
            Myrequest.save(False)
        End If
    End Sub
    Public Sub UpdateRecord()
        Dim myECGReport As New clsECGReport

        Me.dECGReport = clsECGReport.getECGReportresultDetails(labid)
        For ctr As Integer = 0 To dECGReport.Rows.Count - 1
            If ctr = 0 Then
                templabresultdetailsid = dECGReport.Rows(ctr)(0).ToString
                myECGReport.labdetailid = dECGReport.Rows(ctr)(2).ToString
                myECGReport.result = txtRhythm.Text
            ElseIf ctr = 1 Then
                templabresultdetailsid = dECGReport.Rows(ctr)(0).ToString
                myECGReport.labdetailid = dECGReport.Rows(ctr)(2).ToString
                myECGReport.result = txtAtrialRate.Text
            ElseIf ctr = 2 Then
                templabresultdetailsid = dECGReport.Rows(ctr)(0).ToString
                myECGReport.labdetailid = dECGReport.Rows(ctr)(2).ToString
                myECGReport.result = txtVenticularRate.Text
            ElseIf ctr = 3 Then
                templabresultdetailsid = dECGReport.Rows(ctr)(0).ToString
                myECGReport.labdetailid = dECGReport.Rows(ctr)(2).ToString
                myECGReport.result = txtPR.Text
            ElseIf ctr = 4 Then
                templabresultdetailsid = dECGReport.Rows(ctr)(0).ToString
                myECGReport.labdetailid = dECGReport.Rows(ctr)(2).ToString
                myECGReport.result = txtQRS.Text
            ElseIf ctr = 5 Then
                templabresultdetailsid = dECGReport.Rows(ctr)(0).ToString
                myECGReport.labdetailid = dECGReport.Rows(ctr)(2).ToString
                myECGReport.result = txtQTc.Text
            ElseIf ctr = 6 Then
                templabresultdetailsid = dECGReport.Rows(ctr)(0).ToString
                myECGReport.labdetailid = dECGReport.Rows(ctr)(2).ToString
                myECGReport.result = txtQRSAxis.Text
            ElseIf ctr = 7 Then
                templabresultdetailsid = dECGReport.Rows(ctr)(0).ToString
                myECGReport.labdetailid = dECGReport.Rows(ctr)(2).ToString
                myECGReport.result = txtecgdiagnosis.Text
            End If
            myECGReport.labresultid = labid
            myECGReport.labresultdetailid = templabresultdetailsid
            myECGReport.updatelabresultdetails()
        Next

    End Sub
    Public Sub SaveRecordResult()
        Dim frmMDIParents As New frmMDIParent(frmMDIParent.enFormStatus.add)
        Dim myECGReport As New clsECGReport
        Dim dtCGReport As New DataTable

        myECGReport.adminno = adminid
        myECGReport.patientdetailno = patientrequestno
        myECGReport.labno = labno
        myECGReport.edate = Me.dtDate.Value
        myECGReport.empno = Me.cmbCardiologist.SelectedValue



        If myFormStatus = enFormStatus.add Then
            myECGReport.saveECGReportResult(True)
            'If labresultid.Rows.Count <> 0 Then
            '    frmMDIParents.labresultid = labresultid.Rows(0).Item("laboratoryresultid").ToString
            'Else
            '    frmMDIParents.labresultid = 1
            'End If
        Else
            myECGReport.labresultid = labid
            myECGReport.saveECGReportResult(False)
            myFormStatus = enFormStatus.browsing
            'frmMDIParents.labresultid = labid
        End If
        labresultid = clsECGReport.getlabresultid()
        frmMDIParents.tempadminid = adminid
    End Sub

    Public Sub LoadCardio()
        Me.cmbCardiologist.DataSource = clsECGReport.getCardio()
        Me.cmbCardiologist.DisplayMember = "cname"
        Me.cmbCardiologist.ValueMember = "employeeid"
    End Sub
    Public Sub LoadECGReport()
        Dim dtCGReport As New DataTable
        'Dim frmMDIParents As New frmMDIParent(frmMDIParent.enFormStatus.edit)
        If myFormStatus = enFormStatus.add Then
            dtCGReport = clsECGReport.getECGReportresult(requestdetailno, enResult.manageresult)
        Else
            dtCGReport = clsECGReport.getids(adminid, requestdetailno)
            'If myFormStatus = enFormStatus.edit Then 
            'Else
            '    Call EnableFields()
            'End If
        End If
        Admission.AdmissionID = dtCGReport.Rows(0).Item("admissionid").ToString
        Admission.patientname = dtCGReport.Rows(0).Item("patient").ToString
        Me.txtName.Text = dtCGReport.Rows(0).Item("patient")
        Me.txtAge.Text = dtCGReport.Rows(0).Item("age")
        Me.txtGender.Text = dtCGReport.Rows(0).Item("gender")
        Me.txtRoom.Text = dtCGReport.Rows(0).Item("roomno")
        patientrequestno = requestdetailno ' dtCGReport.Rows(0).Item("patientrequestdetailno")
        dtHospitalInfo = clsLaboratoryResult.getHospitalInfo()
        Me.lblheader.Text = dtHospitalInfo.Rows(0).Item("Hospital").ToString()
        Me.lblAddress.Text = dtHospitalInfo.Rows(0).Item("Address").ToString()
        Me.lablTelNo.Text = dtHospitalInfo.Rows(0).Item("Telephone").ToString()
        Try
            ' Image.FromFile(dtHospitalInfo.Rows(0).Item("hospitallogo").ToString())
            Dim tempphoto As Byte() = dtHospitalInfo.Rows(0).Item("hospitallogo")
            If IsDBNull(dtHospitalInfo.Rows(0).Item("hospitallogo")) Or tempphoto.Length = 0 Then
                pctrLogo.Image = Nothing
            Else
                pctrLogo.Image = Utility.convertImage(dtHospitalInfo.Rows(0).Item("hospitallogo")) 'image here
            End If
        Catch ex As Exception
        End Try
        If Not myFormStatus = enFormStatus.add Then
            If Islock = True Then
                LockFields()
            End If
            labid = dtCGReport.Rows(0).Item("laboratoryresultid")
            Me.dtDate.Value = dtCGReport.Rows(0).Item("dateencoded")
            Me.cmbCardiologist.SelectedValue = dtCGReport.Rows(0).Item("employeeno")
            dtCGReport = clsECGReport.getECGReportresultDetails(labid)
            txtRhythm.Text = dtCGReport.Rows(0).Item("result")
            txtAtrialRate.Text = dtCGReport.Rows(1).Item("result")
            txtVenticularRate.Text = dtCGReport.Rows(2).Item("result")
            txtPR.Text = dtCGReport.Rows(3).Item("result")
            txtQRS.Text = dtCGReport.Rows(4).Item("result")
            txtQTc.Text = dtCGReport.Rows(5).Item("result")
            txtQRSAxis.Text = dtCGReport.Rows(6).Item("result")
            txtecgdiagnosis.Text = dtCGReport.Rows(7).Item("result")
        End If
        labno = "7"
        If Islock = True Then
            LockFields()
        End If
    End Sub
    Public Sub LockFields()
        For i = 0 To Controls.Count - 1
            If TypeOf Controls(i) Is Panel Then
                Controls(i).Enabled = False
            End If
        Next
        txtecgdiagnosis.Enabled = False
        txtVenticularRate.Enabled = False
        txtQRS.Enabled = False
        txtQTc.Enabled = False
        cmbCardiologist.Enabled = False
        txtAtrialRate.Enabled = False
        txtRhythm.Enabled = False
        txtPR.Enabled = False
        txtQRSAxis.Enabled = False
    End Sub
#End Region

     
End Class