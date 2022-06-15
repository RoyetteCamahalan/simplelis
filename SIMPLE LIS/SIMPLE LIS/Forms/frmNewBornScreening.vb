Imports System.Drawing.Imaging
Imports System.IO
Public Class frmNewBornScreening

#Region "Variables"
    Dim erp As New ErrorProvider
    Public isSave As Boolean
    Public myFormStatus As enFormStatus
    Public myResult As enResult
    Public itemscode As String
    Dim itemscodeold As String
    Public requestdetailno As String 'supply value
    Dim templabresultdetailsid As String
    Public adminid As String  'supply value
    Dim patientrequestno As String
    Dim labno As String
    Public labid As String
    Dim dNBS As DataTable
    Public status As Integer
    Public Islock As Boolean
    Dim dtHospitalInfo As New DataTable()
    Public labresultid As DataTable
    'Friend WithEvents Label11 As System.Windows.Forms.Label
    'Friend WithEvents lblFecalysis As System.Windows.Forms.Label
    'Friend WithEvents Panel2 As System.Windows.Forms.Panel
    'Friend WithEvents Label10 As System.Windows.Forms.Label
    'Friend WithEvents Label6 As System.Windows.Forms.Label
    'Friend WithEvents Panel5 As System.Windows.Forms.Panel
    'Friend WithEvents mtxtDeliveryTime As System.Windows.Forms.MaskedTextBox
    'Friend WithEvents cmbDeliveryAmPm As System.Windows.Forms.ComboBox
    'Friend WithEvents dtpDelivery As System.Windows.Forms.DateTimePicker
    'Friend WithEvents txtPlace As System.Windows.Forms.TextBox
    'Friend WithEvents Label1 As System.Windows.Forms.Label
    'Friend WithEvents cmbCollectionAmPm As System.Windows.Forms.ComboBox
    'Friend WithEvents cmbresult As System.Windows.Forms.ComboBox
    'Friend WithEvents Label13 As System.Windows.Forms.Label
    'Friend WithEvents Label9 As System.Windows.Forms.Label
    'Friend WithEvents txtContactNo As System.Windows.Forms.TextBox
    'Friend WithEvents cmbPediatrician As System.Windows.Forms.ComboBox
    'Friend WithEvents Label7 As System.Windows.Forms.Label
    'Friend WithEvents mtxtCollectionTime As System.Windows.Forms.MaskedTextBox
    'Friend WithEvents lablTelNo As System.Windows.Forms.Label
    'Friend WithEvents lblAddress As System.Windows.Forms.Label
    'Friend WithEvents lblheader As System.Windows.Forms.Label
    'Friend WithEvents dtpDate As System.Windows.Forms.TextBox
    'Friend WithEvents Label8 As System.Windows.Forms.Label
    'Friend WithEvents pctrLogo As System.Windows.Forms.PictureBox
    'Friend WithEvents txtMothersName As System.Windows.Forms.TextBox
    'Friend WithEvents Panel6 As System.Windows.Forms.Panel
    'Friend WithEvents Label2 As System.Windows.Forms.Label
    'Friend WithEvents Label4 As System.Windows.Forms.Label
    'Friend WithEvents txtBabyName As System.Windows.Forms.TextBox
    'Friend WithEvents lblPatientname As System.Windows.Forms.Label
    'Friend WithEvents txtFilterPaper As System.Windows.Forms.TextBox
    'Friend WithEvents Label5 As System.Windows.Forms.Label
    'Friend WithEvents Label12 As System.Windows.Forms.Label
    'Friend WithEvents Panel3 As System.Windows.Forms.Panel
    'Friend WithEvents Panel4 As System.Windows.Forms.Panel
    'Friend WithEvents dtpCollectionDate As System.Windows.Forms.DateTimePicker
    'Friend WithEvents Label3 As System.Windows.Forms.Label

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
        SetErrorProvider(Me.txtBabyName)
        SetErrorProvider(Me.dtpDate)
        SetErrorProvider(Me.txtFilterPaper)
        SetErrorProvider(Me.cmbPediatrician)
        SetErrorProvider(Me.dtpDelivery)
        SetErrorProvider(Me.mtxtDeliveryTime)
        SetErrorProvider(Me.cmbDeliveryAmPm)
        SetErrorProvider(Me.txtPlace)
        SetErrorProvider(Me.dtpCollectionDate)
        SetErrorProvider(Me.mtxtCollectionTime)
        SetErrorProvider(Me.cmbCollectionAmPm)
        SetErrorProvider(Me.cmbresult)
    End Sub
#End Region

#Region "Events"
    Private Sub SetErrorProvider(ByVal ctl As Control, Optional ByVal strErrorMessage As String = "")
        'Activate or deactivate an error provider for a data entry field
        erp.SetError(ctl, strErrorMessage)
    End Sub

    Private Sub frmNewBornScreening_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call LoadPedia()
        Call LoadNBSresults()
        Call formatdeliverydatetime()
        txtBabyName.ReadOnly = True
        If myFormStatus = enFormStatus.browsing Or myFormStatus = enFormStatus.edit Then
            Call LoadNBS()
        End If
        dtpDate.Text = CStr(Date.Now())
    End Sub

    Private Sub txtBabyName_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtBabyName(Me.txtBabyName)
    End Sub

    Private Sub dtpDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValiddtpDate(Me.dtpDate)
    End Sub
    Private Sub txtFilterPaper_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtFilterPaper(Me.txtFilterPaper)
    End Sub
    Private Sub cmbPediatrician_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidcmbPediatrician(Me.cmbPediatrician)
    End Sub
    Private Sub dtpDelivery_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValiddtpDelivery(Me.dtpDelivery)
    End Sub
    Private Sub mtxtDeliveryTime_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidmtxtDeliveryTime(Me.mtxtDeliveryTime)
    End Sub
    Private Sub cmbDeliveryAmPm_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidcmbDeliveryAmPm(Me.cmbDeliveryAmPm)
    End Sub
    Private Sub txtPlace_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtPlace(Me.txtPlace)
    End Sub
    Private Sub dtpCollectionDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValiddtpCollectionDate(Me.dtpCollectionDate)
    End Sub
    Private Sub mtxtCollectionTime_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidmtxtCollectionTime(Me.mtxtCollectionTime)
    End Sub
    Private Sub cmbCollectionAmPm_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidcmbCollectionAmPm(Me.cmbCollectionAmPm)
    End Sub

    Private Sub cmbresult_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isFieldValidtxtResult(Me.cmbresult)
    End Sub
#End Region

#Region "New Methods"
    Private Function isFieldValidtxtBabyName(ByRef vtxtBabyName As Control) As Boolean
        Dim isValidtxtBabyName As Boolean
        If vtxtBabyName.Text = "" Then
            SetErrorProvider(Me.txtBabyName, "Field is required.")
            isValidtxtBabyName = False
        Else
            SetErrorProvider(vtxtBabyName)
            isValidtxtBabyName = True
        End If
        Return isValidtxtBabyName
    End Function
    Private Function isFieldValiddtpDate(ByRef vdtpDate As Control) As Boolean
        Dim isValiddtpDate As Boolean
        If vdtpDate.Text = "" Then
            SetErrorProvider(Me.dtpDate, "Field is required.")
            isValiddtpDate = False
        Else
            SetErrorProvider(vdtpDate)
            isValiddtpDate = True
        End If
        Return isValiddtpDate
    End Function
    Private Function isFieldValidtxtFilterPaper(ByRef vtxtFilterPaper As Control) As Boolean
        Dim isValidtxtFilterPaper As Boolean
        If vtxtFilterPaper.Text = "" Then
            SetErrorProvider(Me.txtFilterPaper, "Field is required.")
            isValidtxtFilterPaper = False
        Else
            SetErrorProvider(vtxtFilterPaper)
            isValidtxtFilterPaper = True
        End If
        Return isValidtxtFilterPaper
    End Function
    Private Function isFieldValidcmbPediatrician(ByRef vcmbPediatrician As Control) As Boolean
        Dim isValidcmbPediatrician As Boolean
        If vcmbPediatrician.Text = "" Then
            SetErrorProvider(Me.cmbPediatrician, "Field is required.")
            isValidcmbPediatrician = False
        Else
            SetErrorProvider(vcmbPediatrician)
            isValidcmbPediatrician = True
        End If
        Return isValidcmbPediatrician
    End Function
    Private Function isFieldValiddtpDelivery(ByRef vdtpDelivery As Control) As Boolean
        Dim isValiddtpDelivery As Boolean
        If vdtpDelivery.Text = "" Then
            SetErrorProvider(Me.dtpDelivery, "Field is required.")
            isValiddtpDelivery = False
        Else
            SetErrorProvider(vdtpDelivery)
            isValiddtpDelivery = True
        End If
        Return isValiddtpDelivery
    End Function
    Private Function isFieldValidcmbDeliveryAmPm(ByRef vcmbDeliveryAmPm As Control) As Boolean
        Dim isValidcmbDeliveryAmPm As Boolean
        If vcmbDeliveryAmPm.Text = "" Then
            SetErrorProvider(Me.cmbDeliveryAmPm, "Field is required.")
            isValidcmbDeliveryAmPm = False
        Else
            SetErrorProvider(vcmbDeliveryAmPm)
            isValidcmbDeliveryAmPm = True
        End If
        Return isValidcmbDeliveryAmPm
    End Function
    Private Function isFieldValidmtxtDeliveryTime(ByRef vmtxtDeliveryTime As Control) As Boolean
        Dim isValidmtxtDeliveryTime As Boolean
        If vmtxtDeliveryTime.Text = "" Then
            SetErrorProvider(Me.mtxtDeliveryTime, "Field is required.")
            isValidmtxtDeliveryTime = False
        Else
            SetErrorProvider(vmtxtDeliveryTime)
            isValidmtxtDeliveryTime = True
        End If
        Return isValidmtxtDeliveryTime
    End Function
    Private Function isFieldValidtxtPlace(ByRef vtxtPlace As Control) As Boolean
        Dim isValidtxtPlace As Boolean
        If vtxtPlace.Text = "" Then
            SetErrorProvider(Me.txtPlace, "Field is required.")
            isValidtxtPlace = False
        Else
            SetErrorProvider(vtxtPlace)
            isValidtxtPlace = True
        End If
        Return isValidtxtPlace
    End Function
    Private Function isFieldValiddtpCollectionDate(ByRef vdtpCollectionDate As Control) As Boolean
        Dim isValiddtpCollectionDate As Boolean
        If vdtpCollectionDate.Text = "" Then
            SetErrorProvider(Me.dtpCollectionDate, "Field is required.")
            isValiddtpCollectionDate = False
        Else
            SetErrorProvider(vdtpCollectionDate)
            isValiddtpCollectionDate = True
        End If
        Return isValiddtpCollectionDate
    End Function
    Private Function isFieldValidmtxtCollectionTime(ByRef vdmtxtCollectionTime As Control) As Boolean
        Dim isValidmtxtCollectionTime As Boolean
        If vdmtxtCollectionTime.Text = "" Then
            SetErrorProvider(Me.mtxtCollectionTime, "Field is required.")
            isValidmtxtCollectionTime = False
        Else
            SetErrorProvider(vdmtxtCollectionTime)
            isValidmtxtCollectionTime = True
        End If
        Return isValidmtxtCollectionTime
    End Function
    Private Function isFieldValidcmbCollectionAmPm(ByRef vcmbCollectionAmPm As Control) As Boolean
        Dim isValidcmbCollectionAmPm As Boolean
        If vcmbCollectionAmPm.Text = "" Then
            SetErrorProvider(Me.cmbCollectionAmPm, "Field is required.")
            isValidcmbCollectionAmPm = False
        Else
            SetErrorProvider(vcmbCollectionAmPm)
            isValidcmbCollectionAmPm = True
        End If
        Return isValidcmbCollectionAmPm
    End Function
    Private Function isFieldValidtxtResult(ByRef vtxtResult As Control) As Boolean
        Dim isValidtxtResult As Boolean
        If vtxtResult.Text = "" Then
            SetErrorProvider(Me.cmbresult, "Field is required.")
            isValidtxtResult = False
        Else
            SetErrorProvider(vtxtResult)
            isValidtxtResult = True
        End If
        Return isValidtxtResult
    End Function
#End Region

#Region "Methods"
    Public Sub DisplayPrintPreview()
       
        Call DisplayPrintPDF()
        Dim fReportHander As New frmReport
        fReportHander.printType = "NEW BORN SCREENING MAIN"
        fReportHander.varno = adminid
        fReportHander.varstr = requestdetailno
        fReportHander.ShowDialog()

    End Sub
    Public Sub DisplayPrintPDF()
        Dim filename As String = "RadLab_NewBornScreening_" & requestdetailno & ".jpg"
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
    Public Sub EnableFields()

        If myFormStatus = enFormStatus.browsing Then

            Me.txtBabyName.Enabled = False
            Me.dtpDate.Enabled = False
            Me.txtFilterPaper.Enabled = False
            Me.cmbPediatrician.Enabled = False
            Me.dtpDelivery.Enabled = False
            Me.mtxtDeliveryTime.Enabled = False
            Me.cmbDeliveryAmPm.Enabled = False
            Me.txtPlace.Enabled = False
            Me.dtpCollectionDate.Enabled = False
            Me.mtxtCollectionTime.Enabled = False
            Me.cmbCollectionAmPm.Enabled = False
            Me.cmbresult.Enabled = False
        End If
    End Sub
    Public Sub SaveRecord()
        Dim myNBS As New clsNewBornScreening
        Dim frmMDIParents As New frmMDIParent(frmMDIParent.enFormStatus.add)
        Me.dNBS = clsNewBornScreening.getNBSDetail("6")
        For ctr As Integer = 0 To dNBS.Rows.Count - 1
            'myNBS.labresultid = "1"
            myNBS.labresultid = requestdetailno

            If ctr = 0 Then
                myNBS.labdetailid = dNBS.Rows(ctr)(1).ToString
                myNBS.result = CDate(Me.dtpDate.Text)
            ElseIf ctr = 1 Then
                myNBS.labdetailid = dNBS.Rows(ctr)(1).ToString
                myNBS.result = Me.txtPlace.Text
            ElseIf ctr = 2 Then
                myNBS.labdetailid = dNBS.Rows(ctr)(1).ToString
                myNBS.result = Me.dtpDelivery.Value
            ElseIf ctr = 3 Then
                myNBS.labdetailid = dNBS.Rows(ctr)(1).ToString
                myNBS.result = Me.mtxtDeliveryTime.Text
            ElseIf ctr = 4 Then
                myNBS.labdetailid = dNBS.Rows(ctr)(1).ToString
                myNBS.result = Me.dtpCollectionDate.Value
            ElseIf ctr = 5 Then
                myNBS.labdetailid = dNBS.Rows(ctr)(1).ToString
                myNBS.result = Me.mtxtCollectionTime.Text
            ElseIf ctr = 6 Then
                myNBS.labdetailid = dNBS.Rows(ctr)(1).ToString
                myNBS.result = Me.txtFilterPaper.Text
            ElseIf ctr = 7 Then
                myNBS.labdetailid = dNBS.Rows(ctr)(1).ToString
                myNBS.result = Me.cmbresult.Text
            ElseIf ctr = 8 Then
                myNBS.labdetailid = dNBS.Rows(ctr)(1).ToString
                myNBS.result = Me.cmbDeliveryAmPm.Text
            ElseIf ctr = 9 Then
                myNBS.labdetailid = dNBS.Rows(ctr)(1).ToString
                myNBS.result = Me.cmbCollectionAmPm.Text
            End If
            If myFormStatus = enFormStatus.add Then
                myNBS.saveNBS(True)
            Else
                'myECGReport.RoomId = roomid
                myNBS.saveNBS(False)
            End If
        Next
        myFormStatus = enFormStatus.browsing
    End Sub
    Public Sub SaveRecordResult()
        Dim frmMDIParents As New frmMDIParent(frmMDIParent.enFormStatus.add)
        Dim myNBS As New clsNewBornScreening
        Dim dtCGReport As New DataTable

        myNBS.adminno = adminid
        myNBS.patientdetailno = patientrequestno
        myNBS.labno = labno
        myNBS.edate = CDate(Me.dtpDate.Text)
        myNBS.empno = Me.cmbPediatrician.SelectedValue

        If myFormStatus = enFormStatus.add Then
            myNBS.saveNBSResult(True)
        Else
            myNBS.labresultid = labid
            myNBS.saveNBSResult(False)
            myFormStatus = enFormStatus.browsing
        End If
        labresultid = clsECGReport.getlabresultid()
        frmMDIParents.tempadminid = adminid
    End Sub

    Public Sub LoadPedia()
        Me.cmbPediatrician.DataSource = clsNewBornScreening.getPediatrician()
        Me.cmbPediatrician.DisplayMember = "cname"
        Me.cmbPediatrician.ValueMember = "employeeid"
    End Sub
    Public Sub LoadNBSresults()
        Me.cmbresult.DataSource = clsNewBornScreening.getNBSresults()
        Me.cmbresult.DisplayMember = "results"
        Me.cmbresult.ValueMember = "newbornscreeningresultid"
    End Sub
    Public Sub LoadNBS()
        Dim dtNBS As New DataTable
        If myFormStatus = enFormStatus.add Or myResult = enResult.manageresult Then
            dtNBS = clsNewBornScreening.getNBS(requestdetailno, enResult.manageresult)
            ' adminid = dtNBS.Rows(0).Item("admissionid")
        Else
            '  adminid = 1
            dtNBS = clsECGReport.getids(adminid, requestdetailno)
        End If
        dtHospitalInfo = clsLaboratoryResult.getHospitalInfo()

        Admission.AdmissionID = dtNBS.Rows(0).Item("admissionid").ToString
        Admission.patientname = dtNBS.Rows(0).Item("patient").ToString
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
        Me.txtBabyName.Text = dtNBS.Rows(0).Item("patient")
        Me.txtMothersName.Text = dtNBS.Rows(0).Item("mothername")
        Me.txtContactNo.Text = dtNBS.Rows(0).Item("mobileno")

        patientrequestno = dtNBS.Rows(0).Item("patientrequestdetailno")
        If myResult = enResult.releaseresult Then
            If Islock = True Then
                LockFields()
            End If
            cmbPediatrician.SelectedValue = dtNBS.Rows(0).Item("employeeno")
            labid = dtNBS.Rows(0).Item("laboratoryresultid")
            dtNBS = clsECGReport.getECGReportresultDetails(labid)
            dtpDate.Text = CDate(dtNBS.Rows(0).Item("result"))
            txtPlace.Text = dtNBS.Rows(1).Item("result")
            dtpDelivery.Value = CDate(dtNBS.Rows(2).Item("result"))
            mtxtDeliveryTime.Text = dtNBS.Rows(3).Item("result")
            dtpCollectionDate.Value = CDate(dtNBS.Rows(4).Item("result"))
            mtxtCollectionTime.Text = dtNBS.Rows(5).Item("result")
            txtFilterPaper.Text = dtNBS.Rows(6).Item("result")
            cmbresult.Text = dtNBS.Rows(7).Item("result")
            cmbDeliveryAmPm.Text = dtNBS.Rows(8).Item("result")
            cmbCollectionAmPm.Text = dtNBS.Rows(9).Item("result")
        End If
        labno = "6"
        If Islock = True Then
            LockFields()
        End If
    End Sub
    Public Sub UpdateRecord()
        Dim myNBS As New clsECGReport

        Me.dNBS = clsECGReport.getECGReportresultDetails(labid)
        For ctr As Integer = 0 To dNBS.Rows.Count - 1
            If ctr = 0 Then
                templabresultdetailsid = dNBS.Rows(ctr)(0).ToString
                myNBS.labdetailid = dNBS.Rows(ctr)(2).ToString
                myNBS.result = CDate(Me.dtpDate.Text)
            ElseIf ctr = 1 Then
                templabresultdetailsid = dNBS.Rows(ctr)(0).ToString
                myNBS.labdetailid = dNBS.Rows(ctr)(2).ToString
                myNBS.result = txtPlace.Text
            ElseIf ctr = 2 Then
                templabresultdetailsid = dNBS.Rows(ctr)(0).ToString
                myNBS.labdetailid = dNBS.Rows(ctr)(2).ToString
                myNBS.result = dtpDelivery.Value
            ElseIf ctr = 3 Then
                templabresultdetailsid = dNBS.Rows(ctr)(0).ToString
                myNBS.labdetailid = dNBS.Rows(ctr)(2).ToString
                myNBS.result = mtxtDeliveryTime.Text
            ElseIf ctr = 4 Then
                templabresultdetailsid = dNBS.Rows(ctr)(0).ToString
                myNBS.labdetailid = dNBS.Rows(ctr)(2).ToString
                myNBS.result = dtpCollectionDate.Value
            ElseIf ctr = 5 Then
                templabresultdetailsid = dNBS.Rows(ctr)(0).ToString
                myNBS.labdetailid = dNBS.Rows(ctr)(2).ToString
                myNBS.result = mtxtCollectionTime.Text
            ElseIf ctr = 6 Then
                templabresultdetailsid = dNBS.Rows(ctr)(0).ToString
                myNBS.labdetailid = dNBS.Rows(ctr)(2).ToString
                myNBS.result = txtFilterPaper.Text
            ElseIf ctr = 7 Then
                templabresultdetailsid = dNBS.Rows(ctr)(0).ToString
                myNBS.labdetailid = dNBS.Rows(ctr)(2).ToString
                myNBS.result = cmbresult.Text
            ElseIf ctr = 8 Then
                templabresultdetailsid = dNBS.Rows(ctr)(0).ToString
                myNBS.labdetailid = dNBS.Rows(ctr)(2).ToString
                myNBS.result = cmbDeliveryAmPm.Text
            ElseIf ctr = 9 Then
                templabresultdetailsid = dNBS.Rows(ctr)(0).ToString
                myNBS.labdetailid = dNBS.Rows(ctr)(2).ToString
                myNBS.result = cmbCollectionAmPm.Text

            End If
            myNBS.labresultid = labid
            myNBS.labresultdetailid = templabresultdetailsid
            myNBS.updatelabresultdetails()
        Next
    End Sub

    Public Sub UpdateRequestStatus()
        Dim Myrequest As New clsExaminationUpshots

        Myrequest.status = status
        Myrequest.patientreqdetailno = requestdetailno

        If myFormStatus = enFormStatus.add Or myFormStatus = enFormStatus.edit Then
            Myrequest.save(False)
        Else
            Myrequest.save(False)
        End If
    End Sub
    Public Sub LockFields()
        'For i = 0 To Controls.Count - 1
        '    If TypeOf Controls(i) Is Panel Then
        '        Controls(i).Enabled = False
        '    End If
        'Next
        txtFilterPaper.Enabled = False
        cmbPediatrician.Enabled = False
        dtpCollectionDate.Enabled = False
        cmbresult.Enabled = False
        dtpDelivery.Enabled = False
        mtxtCollectionTime.Enabled = False
        mtxtDeliveryTime.Enabled = False
        cmbCollectionAmPm.Enabled = False
        cmbDeliveryAmPm.Enabled = False
        txtPlace.Enabled = False
    End Sub
#End Region

#Region "Format Combobox"
    Public Sub formatdeliverydatetime()
        cmbDeliveryAmPm.Items.Clear()
        cmbDeliveryAmPm.Items.Add("AM")
        cmbDeliveryAmPm.Items.Add("PM")
        cmbDeliveryAmPm.SelectedIndex = 0

        cmbCollectionAmPm.Items.Clear()
        cmbCollectionAmPm.Items.Add("AM")
        cmbCollectionAmPm.Items.Add("PM")
        cmbCollectionAmPm.SelectedIndex = 0
    End Sub
#End Region

  
End Class