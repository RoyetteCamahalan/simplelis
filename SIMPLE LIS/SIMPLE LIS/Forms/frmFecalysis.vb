Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Public Class frmFecalysis
#Region "Variables"

    Public myFormStatus As Integer
    Public myResult As Integer
    Public soperation As Integer
    Public requestdetailno As Long
    Public status As Integer
    Public PatientNo As String
    Public IsSelected As Boolean
    Public Islock As Boolean
    Dim dtResult As New DataTable
    Dim dtHospitalInfo As New DataTable()
    Dim dtLabResultDetails As New DataTable
    Dim LabID As New DataTable
    Public dtFecalysis As New DataTable

    '******************************Design Mode Variables************************
    Dim x As Integer
    Dim _mouseDown As Boolean = False

    Dim isdrag As Byte
    Dim dragging As Boolean
    Dim startX As Integer
    Dim startY As Integer
    Dim dtmedtech As New DataTable

    Public Const WM_NCLBUTTONDOWN = &HA1
    Public Const HTCAPTION = 2
    Public enabl As Boolean = True

    Dim LabdetailID As Long
    Dim normvalues As String
    Dim visiblecontrols As Byte
    Dim locationx As Long
    Dim locationy As Long
    Dim txtheight As Long
    Dim txtwidth As Long

    Dim colorid As Long
    Dim consistencyid As Long
    Dim pcellsid As Long
    Dim rbdid As Long
    Dim fglobulesid As Long
    Dim alumid As Long
    Dim hwormid As Long
    Dim ttrichuraid As Long
    Dim cystid As Long
    Dim trophoziteid As Long
    Dim othersid As Long
    Dim LocX As Double
    Dim LocY As Double

    Public isSave As Boolean
    Dim Admission As New clsAdmission
    Enum enFormStatus
        browsing = 0            'edit fields disabled
        add = 1
        edit = 2
    End Enum
#End Region

#Region "Methods"
#Region "Anchor"
    Private Sub AnchorFields()
        Me.lblHeader.Anchor = AnchorStyles.None
        Me.lblFecalysis.Anchor = AnchorStyles.None
        Me.txtPatientName.Anchor = AnchorStyles.None
        Me.txtHospitalNo.Anchor = AnchorStyles.None
        Me.txtAge.Anchor = AnchorStyles.None
        Me.txtGender.Anchor = AnchorStyles.None
        Me.txtRoomno.Anchor = AnchorStyles.None
        Me.txtLabno.Anchor = AnchorStyles.None
        Me.txtPathologist.Anchor = AnchorStyles.None
        Me.dtDate.Anchor = AnchorStyles.None

        Me.lblpatientid.Anchor = AnchorStyles.None
        'Me.lblPatientname.Anchor = AnchorStyles.None
        Me.lblAge.Anchor = AnchorStyles.None
        Me.lblGender.Anchor = AnchorStyles.None
        Me.lblRoomno.Anchor = AnchorStyles.None
        Me.lblLabNo.Anchor = AnchorStyles.None
        Me.lblPathologist.Anchor = AnchorStyles.None
        Me.lblDate.Anchor = AnchorStyles.None
        Me.LineBorder.Anchor = AnchorStyles.None
    End Sub
#End Region
    Public Sub loadFecalysisRecords()
        LabID = clsLaboratoryResult.getLaboratoryID(requestdetailno, "1", 6)
        dtHospitalInfo = clsLaboratoryResult.getHospitalInfo()
        Me.lblHeader.Text = dtHospitalInfo.Rows(0).Item("Hospital").ToString()
        Me.lblAddress.Text = dtHospitalInfo.Rows(0).Item("Address").ToString()
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
        If IsSelected = True Then
            ' LockFields(Islock)
            txtBoxProperties(True)
            Me.txtPathologist.DataSource = clsLaboratoryResult.getPathologist("777")
            Me.txtPathologist.DisplayMember = "radiologist"
            Me.txtPathologist.ValueMember = "employeeid"
            Me.txtPathologist.SelectedIndex = 0

            Me.cmbMedtech.DataSource = clsLaboratoryResult.getPathologist("666")
            Me.cmbMedtech.DisplayMember = "radiologist"
            Me.cmbMedtech.ValueMember = "employeeid"
            Me.cmbMedtech.SelectedIndex = 0
            dtResult = clsLaboratoryResult.getRadiologyResultDetails(requestdetailno, myResult)
            Admission.AdmissionID = dtResult.Rows(0).Item("admissionid").ToString
            Admission.patientname = dtResult.Rows(0).Item("patient").ToString
            Me.txtPatientName.Text = dtResult.Rows(0).Item("patient").ToString()
            If dtResult.Rows(0).Item("hospitalno").ToString = "" Then
                Me.txtHospitalNo.Text = Nothing
            Else
                Me.txtHospitalNo.Text = Utility.formatHospitalNumber(dtResult.Rows(0).Item("hospitalno").ToString)
            End If
            Me.txtAge.Text = dtResult.Rows(0).Item("age").ToString
            Me.txtGender.Text = dtResult.Rows(0).Item("gender").ToString
            Me.txtRoomno.Text = dtResult.Rows(0).Item("roomno").ToString
            Me.txtLabno.Text = dtResult.Rows(0).Item("labexaminationno").ToString
            If myFormStatus = enFormStatus.edit Or myFormStatus = enFormStatus.browsing Then
                If Islock = True Then
                    LockFields()
                    isEnabled()
                Else
                    isEnabledTop(False)
                End If
                dtmedtech = clsLaboratoryResult.getMedtech(requestdetailno)
                Me.cmbMedtech.Text = dtmedtech.Rows(0).Item("medtechnologist").ToString
                Me.txtPathologist.Text = dtResult.Rows(0).Item("pathologist").ToString
                dtLabResultDetails = clsLaboratoryResultDetails.getLaboratoryResultDetails(requestdetailno, LabID.Rows(0)(0).ToString(), 1, 1)
                dtLabResultDetails.PrimaryKey = New DataColumn() {dtLabResultDetails.Columns("description")}
                Dim dr As DataRow
                dr = dtLabResultDetails.Rows.Find("Color")
                If dr IsNot Nothing Then
                    Me.txtColor.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("Consistency")
                If dr IsNot Nothing Then
                    Me.txtConsist.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("Pus Cells")
                If dr IsNot Nothing Then
                    Me.txtPussCells.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("RBC")
                If dr IsNot Nothing Then
                    Me.txtRBC.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("Fat Globules")
                If dr IsNot Nothing Then
                    Me.txtFatGlob.Text = dr.Item("result").ToString
                End If


                dr = dtLabResultDetails.Rows.Find("Ascaris lumbricoides")
                If dr IsNot Nothing Then
                    Me.txtALumb.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("Hookworm")
                If dr IsNot Nothing Then
                    Me.txtHookworm.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("Trichuris trichiura")
                If dr IsNot Nothing Then
                    Me.txtTtrichu.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("Entamoeba histolyca Cyst")
                If dr IsNot Nothing Then
                    Me.txtEntahisCyst.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("OTHERS")
                If dr IsNot Nothing Then
                    Me.txtOthers.Text = dr.Item("result").ToString
                End If

                dr = dtLabResultDetails.Rows.Find("Trophozoite")
                If dr IsNot Nothing Then
                    Me.txtTropozite.Text = dr.Item("result").ToString
                End If
            End If
            LoadDesign()
            If myFormStatus = enFormStatus.browsing Then
                isEnabled()
            End If
        Else
            LoadDesign()
            isEnabledTop(False)
            Me.Label1.Visible = True
        End If
    End Sub

    Private Sub LoadDesign()
        dtFecalysis = clsExamination.getLabdetails("1")
        dtFecalysis.PrimaryKey = New DataColumn() {dtFecalysis.Columns("description")}
        Dim dr As DataRow
        dr = dtFecalysis.Rows.Find("Color")
        If dr IsNot Nothing Then
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                colorid = dr.Item("laboratorydetailsid").ToString
                pnlColorfecalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlColorfecalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlColorfecalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                colorid = dr.Item("laboratorydetailsid").ToString
                pnlColorfecalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtFecalysis.Rows.Find("Consistency")
        If dr IsNot Nothing Then
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                consistencyid = dr.Item("laboratorydetailsid")
                pnlCons.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlCons.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlCons.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                consistencyid = dr.Item("laboratorydetailsid").ToString
                pnlCons.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtFecalysis.Rows.Find("Pus Cells")
        If dr IsNot Nothing Then
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                pcellsid = dr.Item("laboratorydetailsid")
                pnlPcellsfecalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlPcellsfecalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlPcellsfecalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pcellsid = dr.Item("laboratorydetailsid").ToString
                pnlPcellsfecalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtFecalysis.Rows.Find("RBC")
        If dr IsNot Nothing Then
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                rbdid = dr.Item("laboratorydetailsid")
                pnlRBCfecalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlRBCfecalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlRBCfecalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                rbdid = dr.Item("laboratorydetailsid").ToString
                pnlRBCfecalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtFecalysis.Rows.Find("Fat Globules")
        If dr IsNot Nothing Then
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                fglobulesid = dr.Item("laboratorydetailsid")
                pnlFGlobfecalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlFGlobfecalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlFGlobfecalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                fglobulesid = dr.Item("laboratorydetailsid").ToString
                pnlFGlobfecalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtFecalysis.Rows.Find("Ascaris lumbricoides")
        If dr IsNot Nothing Then
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                alumid = dr.Item("laboratorydetailsid")
                pnlAsclum.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlAsclum.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlAsclum.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                alumid = dr.Item("laboratorydetailsid").ToString
                pnlAsclum.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtFecalysis.Rows.Find("Hookworm")
        If dr IsNot Nothing Then
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                hwormid = dr.Item("laboratorydetailsid")
                pnlHworm.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlHworm.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlHworm.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                hwormid = dr.Item("laboratorydetailsid").ToString
                pnlHworm.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtFecalysis.Rows.Find("Trichuris trichiura")
        If dr IsNot Nothing Then
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                ttrichuraid = dr.Item("laboratorydetailsid")
                pnlTrichura.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlTrichura.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlTrichura.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                ttrichuraid = dr.Item("laboratorydetailsid").ToString
                pnlTrichura.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtFecalysis.Rows.Find("Entamoeba histolyca Cyst")
        If dr IsNot Nothing Then
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                cystid = dr.Item("laboratorydetailsid")
                pnlCyst.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlCyst.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlCyst.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                cystid = dr.Item("laboratorydetailsid")
                pnlCyst.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If

        End If

        dr = dtFecalysis.Rows.Find("OTHERS")
        If dr IsNot Nothing Then
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                othersid = dr.Item("laboratorydetailsid")
                pnlOthersfecalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlOthersfecalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlOthersfecalysis.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                othersid = dr.Item("laboratorydetailsid")
                pnlOthersfecalysis.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If

        dr = dtFecalysis.Rows.Find("Trophozoite")
        If dr IsNot Nothing Then
            If Convert.ToBoolean(dr.Item("isDrag").ToString) = True Then
                trophoziteid = dr.Item("laboratorydetailsid")
                pnlTrophozite.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                pnlTrophozite.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            Else
                pnlTrophozite.Visible = Convert.ToBoolean(dr.Item("visible").ToString)
                trophoziteid = dr.Item("laboratorydetailsid")
                pnlTrophozite.Location = New Point(CDbl(dr.Item("x")), CDbl(dr.Item("y")))
            End If
        End If
    End Sub
    Public Sub txtBoxProperties(ByVal accessible As Boolean)
        For i = 0 To Controls.Count - 1
            If TypeOf Controls(i) Is Panel Then
                Controls(i).Enabled = accessible
            End If
        Next
    End Sub
    Private Sub paintForm(ByVal sender As Object, ByVal e As PaintEventArgs)
        Dim mGraphics As Graphics = e.Graphics
        Dim pen1 As Pen = New Pen(Color.FromArgb(252, 254, 255), 1)
        Dim Area1 As Rectangle = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1) '253, 254, 255
        Dim LGB As LinearGradientBrush = New LinearGradientBrush(Area1, Color.FromArgb(252, 254, 255), Color.FromArgb(227, 237, 253), LinearGradientMode.Vertical)
        mGraphics.FillRectangle(LGB, Area1)
        mGraphics.DrawRectangle(pen1, Area1)
    End Sub
    Public Sub saveFecalysis()
        Dim myLaboratoryResult As New clsLaboratoryResult
        '******************** save labresult
        With myLaboratoryResult
            .laboratoryid = 1
            .itemcatcode = Nothing
            If dtResult.Rows.Count = 0 Then
                .admissionid = 1
                .patientrequestno = 1
                .labno = "1"
            Else
                .admissionid = dtResult.Rows(0).Item("admissionid").ToString()
                .patientrequestno = requestdetailno
                .labno = Utility.EmptyToZero(dtResult.Rows(0).Item("labexaminationno").ToString)
            End If
            .specimen = Nothing
            .datesubmitted = Utility.GetServerDate()
            .dateencoded = Utility.GetServerDate()
            .encodedby = modGlobal.userid
            .pathologist = Me.txtPathologist.SelectedValue
            .medtech = 1
            .medicaltechnologist = Me.cmbMedtech.SelectedValue
            .releasedby = 1
            .datereleased = "01/01/1990"
            If myFormStatus = enFormStatus.add Then
                .soperation = soperation
                .Save(True)
                Call SaveLog("Laboratory", "New fecalysis result with request no.: " & .patientrequestno & "", modGlobal.userid)

            Else
                .Oldlaboratoryid = Convert.ToInt32(LabID.Rows(0)(0).ToString())
                .soperation = soperation
                .Save(False)
                Call SaveLog("Laboratory", "Update fecalysis result with request no.: " & .patientrequestno & "", modGlobal.userid)

            End If
        End With
        Dim frmProgress As New frmProgressIndicator()
        frmProgress.labtype = myLaboratoryResult.laboratoryid
        frmProgress.myFormStatus = myFormStatus
        frmProgress.myresult = myResult
        frmProgress.dtFecalysis = clsExamination.getLabdetails("1")
        frmProgress.txtcolor = Me.txtColor.Text
        frmProgress.txtConsist = Me.txtConsist.Text
        frmProgress.txtPussCells = Me.txtPussCells.Text
        frmProgress.txtRBC = Me.txtRBC.Text
        frmProgress.txtFatGlob = Me.txtFatGlob.Text
        frmProgress.txtALumb = Me.txtALumb.Text
        frmProgress.txtHookworm = Me.txtHookworm.Text
        frmProgress.txtTtrichu = Me.txtTtrichu.Text
        frmProgress.txtEntahisCyst = Me.txtEntahisCyst.Text
        frmProgress.txtOthers = Me.txtOthers.Text
        frmProgress.txtTropozite = Me.txtTropozite.Text
        If myFormStatus = enFormStatus.edit Or myFormStatus = enFormStatus.browsing Then
            frmProgress.dtLabResultDetails = clsLaboratoryResultDetails.getLaboratoryResultDetails(requestdetailno, LabID.Rows(0)(0).ToString(), 1, 1)
            frmProgress.LabID = clsLaboratoryResult.getLaboratoryID(requestdetailno, "1", 6)
        End If
        frmProgress.ShowDialog()
        isSave = True
        'Call DisplayPrintPDF()
    End Sub
    Public Sub DisplayPrintPDF()
        Dim filename As String = "RadLab_Fecalysis_" & requestdetailno & ".jpg"
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
    Public Sub UpdateRequestStatus()
        Dim Myrequest As New clsExaminationUpshots

        Myrequest.status = status
        Myrequest.patientreqdetailno = requestdetailno

        If myFormStatus = enFormStatus.add Or myFormStatus = enFormStatus.edit Then
            Myrequest.save(False)
        Else
            '.Oldlaboratoryid = Convert.ToInt32(LabID.Rows(0)(0).ToString())
            '.Save(False)
        End If
    End Sub

#Region "LOCK"
    Private Sub isEnabledTop(ByVal accesssible As Boolean)
        'Me.txtPatientid.Enabled = accesssible
        'Me.txtPatientname.Enabled = accesssible
        'Me.txtAge.Enabled = accesssible
        'Me.txtGender.Enabled = accesssible
        'Me.txtRoomno.Enabled = accesssible
        '' Me.txtLabno.Enabled = accesssible
        'Me.dtDate.Enabled = accesssible

        'Me.lblpatientid.Enabled = accesssible
        'Me.lblPatientname.Enabled = accesssible
        'Me.lblAge.Enabled = accesssible
        'Me.lblGender.Enabled = accesssible
        'Me.lblRoomno.Enabled = accesssible
        '' Me.lblLabNo.Enabled = accesssible
        ''Me.lblPathologist.Enabled = accesssible
        'Me.lblDate.Enabled = accesssible
    End Sub
    Private Sub isEnabled()
        'Me.txtPatientid.Enabled = False
        'Me.txtPatientname.Enabled = False
        'Me.txtAge.Enabled = False
        'Me.txtGender.Enabled = False
        'Me.txtRoomno.Enabled = False
        'Me.txtLabno.Enabled = False
        Me.txtLabno.Enabled = False
        Me.dtDate.Enabled = False
        Me.lblLabNo.Enabled = False
        Me.lblPathologist.Enabled = False
        'Me.lblpatientid.Enabled = False
        'Me.lblPatientname.Enabled = False
        'Me.lblAge.Enabled = False
        'Me.lblGender.Enabled = False
        'Me.lblRoomno.Enabled = False
        Me.lblLabNo.Enabled = False
        Me.lblPathologist.Enabled = False
        'Me.lblDate.Enabled = False
        Me.lblMedtech.Enabled = False
        Me.cmbMedtech.Enabled = False
        Me.txtPathologist.Enabled = False
    End Sub

    Public Sub LockFields()
        For i = 0 To Controls.Count - 1
            If TypeOf Controls(i) Is Panel Then
                Controls(i).Enabled = False
            End If
        Next
    End Sub

#End Region
    Private Sub ValidateFields()
        Me.pnlColorfecalysis.Enabled = False
        Me.pnlCons.Enabled = False
        Me.pnlPcellsfecalysis.Enabled = False
        Me.pnlRBCfecalysis.Enabled = False
        Me.pnlFGlobfecalysis.Enabled = False
        Me.pnlAsclum.Enabled = False
        Me.pnlHworm.Enabled = False
        Me.pnlTrichura.Enabled = False
        Me.pnlCyst.Enabled = False
        Me.pnlOthersfecalysis.Enabled = False
        Me.pnlTrophozite.Enabled = False
    End Sub
    Public Sub SaveFecalysisDesign()
        Dim myFecalysis As New clsExamination
        myFecalysis.laboratorydetailsid = LabdetailID
        myFecalysis.visible = visiblecontrols
        myFecalysis.x = LocX
        myFecalysis.y = LocY
        myFecalysis.isDrag = isdrag
        myFecalysis.save(True)
    End Sub
    Public Sub Fecalysis()
        If Me.pnlColorfecalysis.Visible = True Then
            LabdetailID = colorid
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlColorfecalysis.Location.X
            LocY = Me.pnlColorfecalysis.Location.Y
            SaveFecalysisDesign()
        Else
            LabdetailID = colorid
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlColorfecalysis.Location.X
            LocY = Me.pnlColorfecalysis.Location.Y
            SaveFecalysisDesign()

        End If

        If Me.pnlCons.Visible = True Then
            LabdetailID = consistencyid
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlCons.Location.X
            LocY = Me.pnlCons.Location.Y
            SaveFecalysisDesign()
        Else
            LabdetailID = consistencyid
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlCons.Location.X
            LocY = Me.pnlCons.Location.Y
            SaveFecalysisDesign()
        End If

        If Me.pnlPcellsfecalysis.Visible = True Then
            LabdetailID = pcellsid
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlPcellsfecalysis.Location.X
            LocY = Me.pnlPcellsfecalysis.Location.Y
            SaveFecalysisDesign()
        Else
            LabdetailID = pcellsid
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlPcellsfecalysis.Location.X
            LocY = Me.pnlPcellsfecalysis.Location.Y
            SaveFecalysisDesign()
        End If

        If Me.pnlRBCfecalysis.Visible = True Then
            LabdetailID = rbdid
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlRBCfecalysis.Location.X
            LocY = Me.pnlRBCfecalysis.Location.Y
            SaveFecalysisDesign()
        Else
            LabdetailID = rbdid
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlRBCfecalysis.Location.X
            LocY = Me.pnlRBCfecalysis.Location.Y
            SaveFecalysisDesign()
        End If

        If Me.pnlFGlobfecalysis.Visible = True Then
            LabdetailID = fglobulesid
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlFGlobfecalysis.Location.X
            LocY = Me.pnlFGlobfecalysis.Location.Y
            SaveFecalysisDesign()
        Else
            LabdetailID = fglobulesid
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlFGlobfecalysis.Location.X
            LocY = Me.pnlFGlobfecalysis.Location.Y
            SaveFecalysisDesign()
        End If

        If Me.pnlAsclum.Visible = True Then
            LabdetailID = alumid
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlAsclum.Location.X
            LocY = Me.pnlAsclum.Location.Y
            SaveFecalysisDesign()
        Else
            LabdetailID = alumid
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlAsclum.Location.X
            LocY = Me.pnlAsclum.Location.Y
            SaveFecalysisDesign()
        End If

        If Me.pnlHworm.Visible = True Then
            LabdetailID = hwormid
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlHworm.Location.X
            LocY = Me.pnlHworm.Location.Y
            SaveFecalysisDesign()
        Else
            LabdetailID = hwormid
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlHworm.Location.X
            LocY = Me.pnlHworm.Location.Y
            SaveFecalysisDesign()
        End If

        If Me.pnlTrichura.Visible = True Then
            LabdetailID = ttrichuraid
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlTrichura.Location.X
            LocY = Me.pnlTrichura.Location.Y
            SaveFecalysisDesign()
        Else
            LabdetailID = ttrichuraid
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlTrichura.Location.X
            LocY = Me.pnlTrichura.Location.Y
            SaveFecalysisDesign()
        End If

        If Me.pnlCyst.Visible = True Then
            LabdetailID = cystid
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlCyst.Location.X
            LocY = Me.pnlCyst.Location.Y
            SaveFecalysisDesign()
        Else
            LabdetailID = cystid
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlCyst.Location.X
            LocY = Me.pnlCyst.Location.Y
            SaveFecalysisDesign()
        End If

        If Me.pnlTrophozite.Visible = True Then
            LabdetailID = trophoziteid
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlTrophozite.Location.X
            LocY = Me.pnlTrophozite.Location.Y
            SaveFecalysisDesign()
        Else
            LabdetailID = trophoziteid
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlTrophozite.Location.X
            LocY = Me.pnlTrophozite.Location.Y
            SaveFecalysisDesign()
        End If

        If Me.pnlOthersfecalysis.Visible = True Then
            LabdetailID = othersid
            visiblecontrols = 1
            isdrag = 1
            LocX = Me.pnlOthersfecalysis.Location.X
            LocY = Me.pnlOthersfecalysis.Location.Y
            SaveFecalysisDesign()
        Else
            LabdetailID = othersid
            visiblecontrols = 0
            isdrag = 0
            LocX = Me.pnlOthersfecalysis.Location.X
            LocY = Me.pnlOthersfecalysis.Location.Y
            SaveFecalysisDesign()
        End If
        ValidateFields()
        Call SaveLog("Laboratory", "Modify fecalysis design schema", modGlobal.userid)
    End Sub

    Private Sub panel_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlColorfecalysis.MouseDown, _
        pnlCons.MouseDown, _
        pnlPcellsfecalysis.MouseDown, _
        pnlRBCfecalysis.MouseDown, _
        pnlFGlobfecalysis.MouseDown, _
        pnlAsclum.MouseDown, _
        pnlHworm.MouseDown, _
        pnlTrichura.MouseDown, _
        pnlCyst.MouseDown, _
        pnlTrophozite.MouseDown, _
        pnlOthersfecalysis.MouseDown
        If IsSelected = False Then
            dragging = True
        Else
            sender.Cursor = DefaultCursor
        End If
        startX = e.X
        startY = e.Y
    End Sub
    Private Sub panel_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlColorfecalysis.MouseMove, _
        pnlCons.MouseMove, _
        pnlPcellsfecalysis.MouseMove, _
        pnlRBCfecalysis.MouseMove, _
        pnlFGlobfecalysis.MouseMove, _
        pnlAsclum.MouseMove, _
        pnlHworm.MouseMove, _
        pnlTrichura.MouseMove, _
        pnlCyst.MouseMove, _
        pnlTrophozite.MouseMove, _
        pnlOthersfecalysis.MouseMove
        If dragging = True Then
            Dim newX As Integer = sender.Location.X + e.X - startX
            Dim newY As Integer = sender.Location.Y + e.Y - startY
            If newX < 0 And newY < 187 Then
                sender.Location = New Point(0, 187)
            ElseIf newX < 0 And newY > 446 Then
                sender.Location = New Point(0, 446)
            ElseIf newX > 578 And newY < 187 Then
                sender.Location = New Point(578, 187)
            ElseIf newX > 578 And newY > 446 Then
                sender.Location = New Point(578, 446)
            ElseIf newX < 0 Then
                sender.Location = New Point(0, sender.Location.Y + e.Y - startY)
            ElseIf newX > 578 Then
                sender.Location = New Point(578, sender.Location.Y + e.Y - startY)
            ElseIf newY < 187 Then
                sender.Location = New Point(sender.Location.X + e.X - startX, 187)
            ElseIf newY > 446 Then
                sender.Location = New Point(sender.Location.X + e.X - startX, 446)
            Else
                sender.Location = New Point(sender.Location.X + e.X - startX, sender.Location.Y + e.Y - startY)
            End If
            Label1.Text = sender.Location.X & " , " & sender.Location.Y & " px"
            Me.Refresh()
        End If
    End Sub
    Private Sub panel_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlColorfecalysis.MouseUp, _
        pnlCons.MouseUp, _
        pnlPcellsfecalysis.MouseUp, _
        pnlRBCfecalysis.MouseUp, _
        pnlFGlobfecalysis.MouseUp, _
        pnlAsclum.MouseUp, _
        pnlHworm.MouseUp, _
        pnlTrichura.MouseUp, _
        pnlCyst.MouseUp, _
        pnlTrophozite.MouseUp, _
        pnlOthersfecalysis.MouseUp
        dragging = False
    End Sub
#End Region

#Region "Events"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadFecalysisRecords()
    End Sub
    Private Sub ChangeTextboxForeColor(ByVal txtName As TextBox, ByVal SelectedColor As System.Drawing.Color)
        With txtName
            .BackColor = .BackColor
            .ForeColor = SelectedColor
        End With
    End Sub
#End Region

#Region "Printing"

    'Call in Printing
    Public Sub DisplayPrintPreview()
        DisplayPrintPDF()
        dlgPrintPreview.Document.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", 850, 579) 'Updates
        dlgPrintPreview.PrintPreviewControl.Zoom = 1.0
        dlgPrintPreview.Document.DefaultPageSettings.Margins = New Printing.Margins(150, 150, 200, 200)

        dlgPrintPreview.WindowState = FormWindowState.Maximized
        dlgPrintPreview.ShowDialog()

    End Sub


    'Print Document Event
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles FecalysisPrintDocu.PrintPage
        Dim sf As New StringFormat
        sf.LineAlignment = StringAlignment.Center
        sf.Alignment = StringAlignment.Center
        Dim txtfnt As New Font("Times New Roman", 10)
        Dim txtfntheader As New Font("Times New Roman", 11, FontStyle.Bold)
        Dim txtfnt1 As New Font("Times New Roman", 6.75)
        Dim txtlabs As New Font("Times New Roman", 8)
        Dim flblLabNo As New Font("Times New Roman", 11, FontStyle.Underline) 'Updates begin here *********IDRIZ
        dtFecalysis = clsExamination.getLabdetails("1")

        e.Graphics.DrawLine(Pens.Black, LineBorder.X1, LineBorder.Y1, _
                               LineBorder.X2, LineBorder.Y2)

        Dim sngCenterPage1 As Single
        sngCenterPage1 = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(Me.lblFecalysis.Text, Me.lblFecalysis.Font).Width / 2) 'Updates begin here *********IDRIZ
        e.Graphics.DrawString(Me.lblFecalysis.Text, Me.lblFecalysis.Font, Brushes.Black, sngCenterPage1, 80)

        Dim sngCenterPage2 As Single
        sngCenterPage2 = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(Me.lblHeader.Text, Me.lblHeader.Font).Width / 2) 'Updates begin here *********IDRIZ
        e.Graphics.DrawString(Me.lblHeader.Text, lblHeader.Font, Brushes.Black, sngCenterPage2, 6)


        Dim sngCenterPage3 As Single
        sngCenterPage3 = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(Me.lblAddress.Text, Me.lblAddress.Font).Width / 2)
        e.Graphics.DrawString(Me.lblAddress.Text, lblAddress.Font, Brushes.Black, sngCenterPage3, 20) 'Updates begin here *********IDRIZ

        Dim sngCenterPage4 As Single
        sngCenterPage4 = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(Me.lablTelNo.Text, Me.lablTelNo.Font).Width / 2)
        e.Graphics.DrawString(Me.lablTelNo.Text, lablTelNo.Font, Brushes.Black, sngCenterPage4, 35) ' updates


        e.Graphics.DrawImage(Me.pctrLogo.Image, Me.pctrLogo.Location.X, Me.pctrLogo.Location.Y, 94, 88) 'Updates

        e.Graphics.DrawString(Me.lblpatientid.Text, Font, Brushes.Black, lblpatientid.Location.X, lblpatientid.Location.Y)
        e.Graphics.DrawString(Me.txtPatientName.Text, flblLabNo, Brushes.Black, txtPatientName.Location.X, txtPatientName.Location.Y)

        'e.Graphics.DrawString(Me.lblPatientname.Text, Font, Brushes.Black, lblPatientname.Location.X, lblPatientname.Location.Y)
        e.Graphics.DrawString(Me.txtHospitalNo.Text, flblLabNo, Brushes.Black, txtHospitalNo.Location.X, txtHospitalNo.Location.Y)

        e.Graphics.DrawString(Me.lblAge.Text, Font, Brushes.Black, lblAge.Location.X, lblAge.Location.Y)
        e.Graphics.DrawString(Me.txtAge.Text, flblLabNo, Brushes.Black, txtAge.Location.X, txtAge.Location.Y)

        e.Graphics.DrawString(Me.lblGender.Text, Font, Brushes.Black, lblGender.Location.X, lblGender.Location.Y)
        e.Graphics.DrawString(Me.txtGender.Text, flblLabNo, Brushes.Black, txtGender.Location.X, txtGender.Location.Y)

        e.Graphics.DrawString(Me.lblLabNo.Text, Font, Brushes.Black, lblLabNo.Location.X, lblLabNo.Location.Y)
        e.Graphics.DrawString(Me.txtLabno.Text, flblLabNo, Brushes.Black, txtLabno.Location.X, txtLabno.Location.Y)

        e.Graphics.DrawString(Me.lblRoomno.Text, Font, Brushes.Black, lblRoomno.Location.X, lblRoomno.Location.Y)
        e.Graphics.DrawString(Me.txtRoomno.Text, flblLabNo, Brushes.Black, txtRoomno.Location.X, txtRoomno.Location.Y)

        e.Graphics.DrawString(Me.lblPathologist.Text, Font, Brushes.Black, lblPathologist.Location.X, lblPathologist.Location.Y)
        e.Graphics.DrawString(Me.txtPathologist.Text, flblLabNo, Brushes.Black, txtPathologist.Location.X, txtPathologist.Location.Y)

        e.Graphics.DrawString(Me.lblDate.Text, Font, Brushes.Black, lblDate.Location.X, lblDate.Location.Y)
        e.Graphics.DrawString(Me.dtDate.Text, flblLabNo, Brushes.Black, dtDate.Location.X, dtDate.Location.Y)

        e.Graphics.DrawString(Me.lblMedtech.Text, Font, Brushes.Black, lblMedtech.Location.X, lblMedtech.Location.Y)
        e.Graphics.DrawString(Me.cmbMedtech.Text, flblLabNo, Brushes.Black, cmbMedtech.Location.X, cmbMedtech.Location.Y)

        If Convert.ToBoolean(dtFecalysis.Rows(0)(7).ToString) = True Then

            e.Graphics.DrawString(Me.lblColor.Text, txtfnt1, Brushes.Black, pnlColorfecalysis.Location.X + lblColor.Location.X, pnlColorfecalysis.Location.Y + lblColor.Location.Y)
            e.Graphics.DrawString(Me.txtColor.Text, txtColor.Font, Brushes.Black, pnlColorfecalysis.Location.X + txtColor.Location.X, pnlColorfecalysis.Location.Y + txtColor.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineColor.X1 + Me.pnlColorfecalysis.Location.X, lineColor.Y1 + Me.pnlColorfecalysis.Location.Y, _
                                lineColor.X2 + Me.pnlColorfecalysis.Location.X, lineColor.Y2 + Me.pnlColorfecalysis.Location.Y)
        End If

        If Convert.ToBoolean(dtFecalysis.Rows(1)(7).ToString) = True Then

            e.Graphics.DrawString(Me.lblconsistency.Text, txtfnt1, Brushes.Black, lblconsistency.Location.X + pnlCons.Location.X, lblconsistency.Location.Y + pnlCons.Location.Y)
            e.Graphics.DrawString(Me.txtConsist.Text, txtConsist.Font, Brushes.Black, txtConsist.Location.X + pnlCons.Location.X, txtConsist.Location.Y + pnlCons.Location.Y)
            e.Graphics.DrawLine(Pens.Black, LineConsistency.X1 + Me.pnlCons.Location.X, LineConsistency.Y1 + Me.pnlCons.Location.Y, _
                                LineConsistency.X2 + Me.pnlCons.Location.X, LineConsistency.Y2 + Me.pnlCons.Location.Y)
        End If

        If Convert.ToBoolean(dtFecalysis.Rows(2)(7).ToString) = True Then
            e.Graphics.DrawString(Me.lblPussCells.Text, txtfnt1, Brushes.Black, lblPussCells.Location.X + pnlPcellsfecalysis.Location.X, lblPussCells.Location.Y + pnlPcellsfecalysis.Location.Y)
            e.Graphics.DrawString(Me.txtPussCells.Text, txtPussCells.Font, Brushes.Black, txtPussCells.Location.X + pnlPcellsfecalysis.Location.X, txtPussCells.Location.Y + pnlPcellsfecalysis.Location.Y)
            e.Graphics.DrawLine(Pens.Black, linePussCells.X1 + Me.pnlPcellsfecalysis.Location.X, linePussCells.Y1 + Me.pnlPcellsfecalysis.Location.Y, _
                                linePussCells.X2 + Me.pnlPcellsfecalysis.Location.X, linePussCells.Y2 + Me.pnlPcellsfecalysis.Location.Y)
        End If

        If Convert.ToBoolean(dtFecalysis.Rows(3)(7).ToString) = True Then
            e.Graphics.DrawString(Me.lblRBC.Text, txtfnt1, Brushes.Black, lblRBC.Location.X + pnlRBCfecalysis.Location.X, lblRBC.Location.Y + pnlRBCfecalysis.Location.Y)
            e.Graphics.DrawString(Me.txtRBC.Text, txtRBC.Font, Brushes.Black, txtRBC.Location.X + pnlRBCfecalysis.Location.X, txtRBC.Location.Y + pnlRBCfecalysis.Location.Y)
            e.Graphics.DrawLine(Pens.Black, lineRBC.X1 + Me.pnlRBCfecalysis.Location.X, lineRBC.Y1 + Me.pnlRBCfecalysis.Location.Y, _
                                lineRBC.X2 + Me.pnlRBCfecalysis.Location.X, lineRBC.Y2 + Me.pnlRBCfecalysis.Location.Y)
        End If

        If Convert.ToBoolean(dtFecalysis.Rows(4)(7).ToString) = True Then
            e.Graphics.DrawString(Me.lblFatg.Text, txtfnt1, Brushes.Black, lblFatg.Location.X + pnlFGlobfecalysis.Location.X, lblFatg.Location.Y + pnlFGlobfecalysis.Location.Y)
            e.Graphics.DrawString(Me.txtFatGlob.Text, txtFatGlob.Font, Brushes.Black, txtFatGlob.Location.X + pnlFGlobfecalysis.Location.X, txtFatGlob.Location.Y + pnlFGlobfecalysis.Location.Y)
            e.Graphics.DrawLine(Pens.Black, LineFatG.X1 + Me.pnlFGlobfecalysis.Location.X, LineFatG.Y1 + Me.pnlFGlobfecalysis.Location.Y, _
                                LineFatG.X2 + Me.pnlFGlobfecalysis.Location.X, LineFatG.Y2 + Me.pnlFGlobfecalysis.Location.Y)
        End If

        If Convert.ToBoolean(dtFecalysis.Rows(5)(7).ToString) = True Then
            e.Graphics.DrawString(Me.lblAscaris.Text, txtfnt1, Brushes.Black, lblAscaris.Location.X + pnlAsclum.Location.X, lblAscaris.Location.Y + pnlAsclum.Location.Y)
            e.Graphics.DrawString(Me.txtALumb.Text, txtALumb.Font, Brushes.Black, txtALumb.Location.X + pnlAsclum.Location.X, txtALumb.Location.Y + pnlAsclum.Location.Y)
            e.Graphics.DrawLine(Pens.Black, LineAscaris.X1 + Me.pnlAsclum.Location.X, LineAscaris.Y1 + Me.pnlAsclum.Location.Y, _
                                LineAscaris.X2 + Me.pnlAsclum.Location.X, LineAscaris.Y2 + Me.pnlAsclum.Location.Y)
        End If

        If Convert.ToBoolean(dtFecalysis.Rows(6)(7).ToString) = True Then
            e.Graphics.DrawString(Me.lblHookworm.Text, txtfnt1, Brushes.Black, lblHookworm.Location.X + pnlHworm.Location.X, lblHookworm.Location.Y + pnlHworm.Location.Y)
            e.Graphics.DrawString(Me.txtHookworm.Text, txtHookworm.Font, Brushes.Black, txtHookworm.Location.X + pnlHworm.Location.X, txtHookworm.Location.Y + pnlHworm.Location.Y)
            e.Graphics.DrawLine(Pens.Black, LineHookworm.X1 + Me.pnlHworm.Location.X, LineHookworm.Y1 + Me.pnlHworm.Location.Y, _
                                LineHookworm.X2 + Me.pnlHworm.Location.X, LineHookworm.Y2 + Me.pnlHworm.Location.Y)
        End If

        If Convert.ToBoolean(dtFecalysis.Rows(7)(7).ToString) = True Then
            e.Graphics.DrawString(Me.lblTrichuris.Text, txtfnt1, Brushes.Black, lblTrichuris.Location.X + pnlTrichura.Location.X, lblTrichuris.Location.Y + pnlTrichura.Location.Y)
            e.Graphics.DrawString(Me.txtTtrichu.Text, txtTtrichu.Font, Brushes.Black, txtTtrichu.Location.X + pnlTrichura.Location.X, txtTtrichu.Location.Y + pnlTrichura.Location.Y)
            e.Graphics.DrawLine(Pens.Black, LineTrichuris.X1 + Me.pnlTrichura.Location.X, LineTrichuris.Y1 + Me.pnlTrichura.Location.Y, _
                                LineTrichuris.X2 + Me.pnlTrichura.Location.X, LineTrichuris.Y2 + Me.pnlTrichura.Location.Y)
        End If

        If Convert.ToBoolean(dtFecalysis.Rows(8)(7).ToString) = True Then
            e.Graphics.DrawString(Me.lblEHC.Text, txtfnt1, Brushes.Black, lblEHC.Location.X + pnlCyst.Location.X, lblEHC.Location.Y + pnlCyst.Location.Y)
            e.Graphics.DrawString(Me.txtEntahisCyst.Text, txtEntahisCyst.Font, Brushes.Black, txtEntahisCyst.Location.X + pnlCyst.Location.X, txtEntahisCyst.Location.Y + pnlCyst.Location.Y)
            e.Graphics.DrawLine(Pens.Black, LineEHC.X1 + Me.pnlCyst.Location.X, LineEHC.Y1 + Me.pnlCyst.Location.Y, _
                                LineEHC.X2 + Me.pnlCyst.Location.X, LineEHC.Y2 + Me.pnlCyst.Location.Y)
        End If

        If Convert.ToBoolean(dtFecalysis.Rows(9)(7).ToString) = True Then
            e.Graphics.DrawString(Me.lblOthers.Text, txtfnt1, Brushes.Black, lblOthers.Location.X + pnlOthersfecalysis.Location.X, lblOthers.Location.Y + pnlOthersfecalysis.Location.Y)
            e.Graphics.DrawString(Me.txtOthers.Text, txtOthers.Font, Brushes.Black, txtOthers.Location.X + pnlOthersfecalysis.Location.X, txtOthers.Location.Y + pnlOthersfecalysis.Location.Y)
            e.Graphics.DrawLine(Pens.Black, LineOthers.X1 + Me.pnlOthersfecalysis.Location.X, LineOthers.Y1 + Me.pnlOthersfecalysis.Location.Y, _
                                LineOthers.X2 + Me.pnlOthersfecalysis.Location.X, LineOthers.Y2 + Me.pnlOthersfecalysis.Location.Y)
        End If

        If Convert.ToBoolean(dtFecalysis.Rows(10)(7).ToString) = True Then
            e.Graphics.DrawString(Me.lblTrophozite.Text, txtfnt1, Brushes.Black, lblTrophozite.Location.X + pnlTrophozite.Location.X, lblTrophozite.Location.Y + pnlTrophozite.Location.Y)
            e.Graphics.DrawString(Me.txtTropozite.Text, txtTropozite.Font, Brushes.Black, txtTropozite.Location.X + pnlTrophozite.Location.X, txtTropozite.Location.Y + pnlTrophozite.Location.Y)
            e.Graphics.DrawLine(Pens.Black, LineTrophozite.X1 + Me.pnlTrophozite.Location.X, LineTrophozite.Y1 + Me.pnlTrophozite.Location.Y, _
                            LineTrophozite.X2 + Me.pnlTrophozite.Location.X, LineTrophozite.Y2 + Me.pnlTrophozite.Location.Y)
        End If
    End Sub


#End Region
     
End Class
