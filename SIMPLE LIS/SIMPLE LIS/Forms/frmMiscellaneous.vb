Imports System.Drawing.Drawing2D
'***********
'*    Author: Ronald Jumao-as
'*    Date Created: 06-05-12
'*
'**********

Imports System.Drawing.Imaging
Imports System.IO
Public Class frmMiscellaneous
#Region "Variables"

    Public myFormStatus As enFormStatus
    Public myResult As enResult

    Public requestdetailno As Long
    Public status As Integer
    Public PatientNo As String
    Public Labname As String
    Public labid As Long
    Public itemcode As String
    Public Islock As Boolean

    Dim Labid_s As New DataTable
    Dim dtLoadMiscrecord As New DataTable
    Dim dtLabResultDetails As New DataTable
    Dim dtLabResultDetailupdate As New DataTable
    Dim dr As DataRow
    Dim drLabResultDetails As DataRow
    Dim dtHospitalInfo As New DataTable
    'Friend WithEvents lablTelNo As System.Windows.Forms.Label
    'Friend WithEvents lblHeader As System.Windows.Forms.Label
    'Friend WithEvents lblAddress As System.Windows.Forms.Label
    'Friend WithEvents pctrLogo As System.Windows.Forms.PictureBox
    'Friend WithEvents cbIggPositive As System.Windows.Forms.RadioButton
    'Friend WithEvents txtPathologist As System.Windows.Forms.ComboBox
    'Friend WithEvents lblPathologist As System.Windows.Forms.Label
    'Friend WithEvents cbIggNegative As System.Windows.Forms.RadioButton
    'Friend WithEvents gbIGG As System.Windows.Forms.GroupBox
    'Friend WithEvents gbIGM As System.Windows.Forms.GroupBox
    'Friend WithEvents cbIgmNegative As System.Windows.Forms.RadioButton
    'Friend WithEvents cbIgmPositive As System.Windows.Forms.RadioButton
    'Friend WithEvents cmbSpecimen As System.Windows.Forms.ComboBox
    'Friend WithEvents lblOthersmisc As System.Windows.Forms.Label
    'Friend WithEvents richtxtOthers As System.Windows.Forms.RichTextBox
    'Friend WithEvents lblResult As System.Windows.Forms.Label
    'Friend WithEvents lblSpecimen As System.Windows.Forms.Label
    'Friend WithEvents txtSpecimen As System.Windows.Forms.TextBox
    'Friend WithEvents lblLabExam As System.Windows.Forms.Label
    'Friend WithEvents txtLabExam As System.Windows.Forms.TextBox
    'Friend WithEvents cmbMedtech As System.Windows.Forms.ComboBox
    'Friend WithEvents lblMedtech As System.Windows.Forms.Label
    'Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    'Friend WithEvents lblDate As System.Windows.Forms.Label
    'Friend WithEvents txtLabno As System.Windows.Forms.TextBox
    'Friend WithEvents lblLabNo As System.Windows.Forms.Label
    'Friend WithEvents lblpatientid As System.Windows.Forms.Label
    'Friend WithEvents txtGender As System.Windows.Forms.TextBox
    'Friend WithEvents lblGender As System.Windows.Forms.Label
    'Friend WithEvents txtAge As System.Windows.Forms.TextBox
    'Friend WithEvents lblAge As System.Windows.Forms.Label
    'Friend WithEvents txtRoomno As System.Windows.Forms.TextBox
    'Friend WithEvents lblRoomno As System.Windows.Forms.Label
    'Friend WithEvents txtPatientname As System.Windows.Forms.TextBox
    'Friend WithEvents lblPatientname As System.Windows.Forms.Label
    'Friend WithEvents txtPatientid As System.Windows.Forms.TextBox
    'Friend WithEvents lblMisc As System.Windows.Forms.Label
    'Friend WithEvents dlgPrint As System.Windows.Forms.PrintDialog
    'Friend WithEvents lblIGM As System.Windows.Forms.Label
    'Friend WithEvents rbPositive As System.Windows.Forms.RadioButton
    'Friend WithEvents dlgPrintPreview As System.Windows.Forms.PrintPreviewDialog
    'Friend WithEvents MiscPrintDocu As System.Drawing.Printing.PrintDocument
    'Friend WithEvents txtRadiobuttonResult As System.Windows.Forms.TextBox
    'Friend WithEvents txtIGM As System.Windows.Forms.TextBox
    'Friend WithEvents txtIGG As System.Windows.Forms.TextBox
    'Friend WithEvents lblIGG As System.Windows.Forms.Label
    'Friend WithEvents rbNegative As System.Windows.Forms.RadioButton
    Dim Admission As New clsAdmission
#End Region
#Region "Constructor"
    Enum enFormStatus
        'for operations
        browsing = 0
        add = 1
        edit = 2
    End Enum

    Enum enResult
        'for sub query
        managerequest = 0
        ' releaseresult = 1
    End Enum

#End Region
#Region "Events"

    Private Sub frmMiscellaneous_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

        If Islock = True Then
            lock()
            LoadCombo()
            LoadMiscRecord()
            LoadVisibleItems()
            IGG()
            IGM()
        Else
            If myFormStatus = enFormStatus.add Then
                cmbLoadSpecimen()
            End If
            LoadCombo()
            LoadMiscRecord()
            LoadVisibleItems()
            IGG()
            IGM()
            'cmbLoadSpecimen()
        End If
    End Sub

    Private Sub cmbSpecimen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSpecimen.SelectedIndexChanged
        cmbLoadSpecimen()
    End Sub
    Private Sub cbIgmPositive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIgmPositive.CheckedChanged
        IGM()
    End Sub

    Private Sub cbIggPositive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIggPositive.CheckedChanged
        IGG()
    End Sub
#End Region

#Region "Methods"

    Private Sub LoadMiscRecord()
        Dim lab_ids As Long


        dtLoadMiscrecord = clsLaboratoryResult.getRadiologyResultDetails(requestdetailno, myResult)

        Admission.AdmissionID = dtLoadMiscrecord.Rows(0).Item("admissionid").ToString
        Admission.patientname = dtLoadMiscrecord.Rows(0).Item("patient").ToString
        If IsDBNull(dtLoadMiscrecord.Rows(0).Item("hospitalno")) Or dtLoadMiscrecord.Rows(0).Item("hospitalno").ToString = "" Then
            Me.txtPatientname.Text = Utility.NullToEmptyString(dtLoadMiscrecord.Rows(0).Item("hospitalno").ToString)
        Else
            Me.txtPatientname.Text = Utility.formatHospitalNumber(dtLoadMiscrecord.Rows(0).Item("hospitalno").ToString)
        End If

        ' Me.txtPatientid.Text = Utility.NullToEmptyString(dtLoadMiscrecord.Rows(0).Item("patient").ToString)

        Me.txtPatientid.Text = Utility.NullToEmptyString(dtLoadMiscrecord.Rows(0).Item("patient").ToString)
        Me.txtAge.Text = dtLoadMiscrecord.Rows(0).Item("age").ToString
        Me.txtGender.Text = dtLoadMiscrecord.Rows(0).Item("gender").ToString
        Me.txtRoomno.Text = dtLoadMiscrecord.Rows(0).Item("roomno").ToString
        Me.txtLabno.Text = dtLoadMiscrecord.Rows(0).Item("labexaminationno").ToString

        Me.txtLabExam.Text = Labname

        If myFormStatus = enFormStatus.edit Or myFormStatus = enFormStatus.browsing Then
            Labid_s = clsLaboratoryResult.getLaboratoryID(requestdetailno, labid, 6)
            lab_ids = Labid_s.Rows(0)(0).ToString()

            dtLabResultDetails = clsLaboratoryResultDetails.getLaboratoryResultDetails(requestdetailno, lab_ids, labid, 1)
            dtLabResultDetails.PrimaryKey = New DataColumn() {dtLabResultDetails.Columns("description")}
            Me.txtPathologist.Text = dtLoadMiscrecord.Rows(0).Item("pathologist").ToString
            dr = dtLabResultDetails.Rows.Find("LAB EXAMINATION")
            If dr IsNot Nothing Then
                Me.txtLabExam.Text = dr.Item("result").ToString
            End If

            dr = dtLabResultDetails.Rows.Find("SPECIMEN")
            If dr IsNot Nothing Then
                Me.txtSpecimen.Text = dr.Item("result").ToString
            End If

            dr = dtLabResultDetails.Rows.Find("RESULTS")
            If dr IsNot Nothing Then
                Me.richtxtOthers.Text = dr.Item("result").ToString
            End If

            dr = dtLabResultDetails.Rows.Find("POS/NEG")
            If dr IsNot Nothing Then
                If dr.Item("result").ToString = "Positive" Then
                    Me.rbPositive.Checked = True
                ElseIf dr.Item("result").ToString = "Negative" Then
                    Me.rbNegative.Checked = True
                End If
            End If

            dr = dtLabResultDetails.Rows.Find("IgG")
            If dr IsNot Nothing Then
                If dr.Item("result").ToString = "+" Then
                    Me.cbIggPositive.Checked = True
                    Me.txtIGG.Text = "+"
                ElseIf dr.Item("result").ToString = "-" Then
                    Me.cbIggNegative.Checked = True
                    Me.txtIGG.Text = "-"
                End If
            End If

            dr = dtLabResultDetails.Rows.Find("IgM")
            If dr IsNot Nothing Then
                If dr.Item("result").ToString = "+" Then
                    Me.cbIgmPositive.Checked = True
                    Me.txtIGM.Text = "+"
                ElseIf dr.Item("result").ToString = "-" Then
                    Me.cbIgmNegative.Checked = True
                    Me.txtIGM.Text = "-"
                End If
            End If
        End If

    End Sub

    Private Sub LoadVisibleItems()
        If Labname = "TYPHIDOT-WARD-NM" Or Labname = "TYPHIDOT-WARD-MED" Or Labname = "TYPHIDOT-SPR-NM" Or _
                     Labname = "TYPHIDOT-SPR-MED" Or Labname = "TYPHIDOT-AIRCON-NM" Or Labname = "TYPHIDOT-AIRCON-MED" Or _
                      Labname = "TYPHIDOT ( PRI-NON MED)" Then
            Me.rbPositive.Visible = False
            Me.rbNegative.Visible = False
            Me.gbIGG.Visible = True
            Me.gbIGM.Visible = True
        Else
            Me.rbPositive.Visible = True
            Me.rbNegative.Visible = True
            Me.gbIGG.Visible = False
            Me.gbIGM.Visible = False
        End If
    End Sub

    Private Sub LoadCombo()
        Me.txtPathologist.DataSource = clsLaboratoryResult.getPathologist("777")
        Me.txtPathologist.DisplayMember = "radiologist"
        Me.txtPathologist.ValueMember = "employeeid"
        Me.txtPathologist.SelectedIndex = 0

        Me.cmbMedtech.DataSource = clsLaboratoryResult.getPathologist("666")
        Me.cmbMedtech.DisplayMember = "radiologist"
        Me.cmbMedtech.ValueMember = "employeeid"
        Me.cmbMedtech.SelectedIndex = 0

        Me.cmbSpecimen.Items.Add(New DictionaryEntry("BLOOD", "BLOOD"))
        Me.cmbSpecimen.Items.Add(New DictionaryEntry("STOOL", "STOOL"))
        Me.cmbSpecimen.Items.Add(New DictionaryEntry("OTHERS", "OTHERS"))

        Me.cmbSpecimen.DisplayMember = "Key"
        Me.cmbSpecimen.ValueMember = "Value"
        Me.cmbSpecimen.DataSource = Me.cmbSpecimen.Items
        Me.cmbSpecimen.SelectedIndex = 0

    End Sub


    Public Sub save()
        Dim myLaboratoryResult As New clsLaboratoryResult
        '******************** save labresult MISCELLANEOUS
        With myLaboratoryResult
            .laboratoryid = labid
            .itemcatcode = itemcode
            .admissionid = dtLoadMiscrecord.Rows(0).Item("admissionid").ToString()
            .patientrequestno = requestdetailno
            .labno = Utility.EmptyToZero(dtLoadMiscrecord.Rows(0).Item("labexaminationno").ToString)
            .specimen = Me.txtSpecimen.Text
            .datesubmitted = Utility.GetServerDate()
            .dateencoded = Utility.GetServerDate()
            .encodedby = modGlobal.userid
            .pathologist = Me.txtPathologist.SelectedValue
            .medtech = Me.cmbMedtech.SelectedValue
            .medicaltechnologist = Me.cmbMedtech.SelectedValue
            .releasedby = 1
            .datereleased = "01/01/1990"
            If myFormStatus = enFormStatus.add Then
                .Save(True)
            Else
                '.Oldlaboratoryid = Convert.ToInt32(labid.Rows(0)(0).ToString())
                '.Save(False)
            End If
        End With
    End Sub

    Public Sub saveDetails()
        Dim myLaboratoryResultDetails As New clsLaboratoryResultDetails
        Dim dtMisc As New DataTable
        Dim dtLabResultDetails As New DataTable
        Dim lab_idx As Long

        dtMisc = clsExamination.getLabdetails("8")
        If myFormStatus = enFormStatus.edit Or myFormStatus = enFormStatus.browsing Then
            Labid_s = clsLaboratoryResult.getLaboratoryID(requestdetailno, labid, 6)
            lab_idx = Labid_s.Rows(0)(0).ToString()
            dtLabResultDetailupdate = clsLaboratoryResultDetails.getLaboratoryResultDetails(requestdetailno, lab_idx, labid, 1)
        End If

        dtMisc.PrimaryKey = New DataColumn() {dtMisc.Columns("laboratorydetailsid")} ' Save
        dtLabResultDetailupdate.PrimaryKey = New DataColumn() {dtLabResultDetailupdate.Columns("laboratorydetailsid")} 'For Updating


        For ctr = 0 To dtMisc.Rows.Count - 1

            dr = dtMisc.Rows.Find(CDbl(dtMisc.Rows(ctr)(1).ToString()))
            If dr IsNot Nothing And dtMisc.Rows(ctr)(2).ToString() = "LAB EXAMINATION" Then
                myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                myLaboratoryResultDetails.result = Me.txtLabExam.Text
            ElseIf dr IsNot Nothing And dtMisc.Rows(ctr)(2).ToString() = "SPECIMEN" Then
                myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                myLaboratoryResultDetails.result = Me.txtSpecimen.Text
            ElseIf dr IsNot Nothing And dtMisc.Rows(ctr)(2).ToString() = "RESULTS" Then
                myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                myLaboratoryResultDetails.result = Me.richtxtOthers.Text

            ElseIf dr IsNot Nothing And dtMisc.Rows(ctr)(2).ToString() = "POS/NEG" Then
                myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                If Me.rbPositive.Checked = True Then
                    myLaboratoryResultDetails.result = "Positive"
                Else
                    myLaboratoryResultDetails.result = "Negative"
                End If

            ElseIf dr IsNot Nothing And dtMisc.Rows(ctr)(2).ToString() = "IgG" Then
                myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                If Me.cbIggPositive.Checked = True Then
                    myLaboratoryResultDetails.result = "+"
                ElseIf Me.cbIggNegative.Checked = True Then
                    myLaboratoryResultDetails.result = "-"
                End If

            ElseIf dr IsNot Nothing And dtMisc.Rows(ctr)(2).ToString() = "IgM" Then
                myLaboratoryResultDetails.laboratorydetailsid = dr.Item("laboratorydetailsid").ToString
                If Me.cbIgmPositive.Checked = True Then
                    myLaboratoryResultDetails.result = "+"
                ElseIf Me.cbIgmNegative.Checked = True Then
                    myLaboratoryResultDetails.result = "-"
                End If
            End If


            If myFormStatus = enFormStatus.add Then
                myLaboratoryResultDetails.Oldlaboratoryresultid = Nothing
                myLaboratoryResultDetails.Save(True)
            Else
                drLabResultDetails = dtLabResultDetailupdate.Rows.Find(CDbl(dtLabResultDetailupdate.Rows(ctr)(2).ToString()))
                If drLabResultDetails IsNot Nothing And dtLabResultDetailupdate.Rows(ctr)(3).ToString() = "LAB EXAMINATION" Then
                    myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetailupdate.Rows(ctr)(3).ToString() = "SPECIMEN" Then
                    myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetailupdate.Rows(ctr)(3).ToString() = "RESULTS" Then
                    myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetailupdate.Rows(ctr)(3).ToString() = "POS/NEG" Then
                    myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetailupdate.Rows(ctr)(3).ToString() = "IgG" Then
                    myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                ElseIf drLabResultDetails IsNot Nothing And dtLabResultDetailupdate.Rows(ctr)(3).ToString() = "IgM" Then
                    myLaboratoryResultDetails.Oldlaboratoryresultid = drLabResultDetails.Item("laboratoryresultdetailsid").ToString
                End If
                myLaboratoryResultDetails.laboratoryresultid = lab_idx
                myLaboratoryResultDetails.Save(False)
            End If
        Next
        lock()
    End Sub
    Public Sub UpdateRequestStatus()
        Dim Myrequest As New clsExaminationUpshots

        Myrequest.status = status
        Myrequest.patientreqdetailno = requestdetailno

        If myFormStatus = enFormStatus.add Or myFormStatus = enFormStatus.edit Or myFormStatus = enFormStatus.browsing Then
            Myrequest.save(False)
        Else
        End If
    End Sub

    Public Sub lock()
        Me.txtPathologist.Enabled = False
        Me.cmbMedtech.Enabled = False
        Me.txtSpecimen.Enabled = False
        Me.rbPositive.Enabled = False
        Me.rbNegative.Enabled = False
        Me.richtxtOthers.Enabled = False
        Me.gbIGG.Enabled = False
        Me.gbIGM.Enabled = False
        Me.txtSpecimen.Enabled = False
        Me.cmbSpecimen.Enabled = False

        Me.cmbSpecimen.Visible = False
    End Sub

    Private Sub IGG()
        If Me.cbIggPositive.Checked = True Then
            Me.txtIGG.Text = "+"
        ElseIf Me.cbIggNegative.Checked = True Then
            Me.txtIGG.Text = "-"
        End If
    End Sub
    Private Sub IGM()
        If Me.cbIgmPositive.Checked = True Then
            Me.txtIGM.Text = "+"
        ElseIf Me.cbIgmNegative.Checked = True Then
            Me.txtIGM.Text = "-"
        End If
    End Sub

    Private Sub cmbLoadSpecimen()

        If Me.cmbSpecimen.SelectedValue = "BLOOD" Then
            Me.txtSpecimen.Enabled = False
            Me.txtSpecimen.Text = "BLOOD"
        ElseIf Me.cmbSpecimen.SelectedValue = "STOOL" Then
            Me.txtSpecimen.Enabled = False
            Me.txtSpecimen.Text = "STOOL"
        Else
            Me.txtSpecimen.Text = ""
            If Islock = True Then
                Me.txtSpecimen.Enabled = False
            Else
                Me.txtSpecimen.Enabled = True
            End If

        End If
    End Sub

#End Region

#Region "Printing"
    'Call in Printing
    Public Sub DisplayPrintPreview()
        Call DisplayPrintPDF()
        dlgPrintPreview.Document.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", 850, 450)
        dlgPrintPreview.PrintPreviewControl.Zoom = 1.0
        dlgPrintPreview.Document.DefaultPageSettings.Margins = New Printing.Margins(150, 150, 200, 200)

        dlgPrintPreview.WindowState = FormWindowState.Maximized
        dlgPrintPreview.ShowDialog()
    End Sub
    Public Sub DisplayPrintPDF()
        Dim filename As String = "RadLab_Misc_" & requestdetailno & ".jpg"
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
    Private Sub MiscPrintDocu_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles MiscPrintDocu.PrintPage

    End Sub
#End Region



    'Private Sub InitializeComponent()
    '    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMiscellaneous))
    '    Me.lablTelNo = New System.Windows.Forms.Label()
    '    Me.lblHeader = New System.Windows.Forms.Label()
    '    Me.lblAddress = New System.Windows.Forms.Label()
    '    Me.pctrLogo = New System.Windows.Forms.PictureBox()
    '    Me.cbIggPositive = New System.Windows.Forms.RadioButton()
    '    Me.txtPathologist = New System.Windows.Forms.ComboBox()
    '    Me.lblPathologist = New System.Windows.Forms.Label()
    '    Me.cbIggNegative = New System.Windows.Forms.RadioButton()
    '    Me.gbIGG = New System.Windows.Forms.GroupBox()
    '    Me.gbIGM = New System.Windows.Forms.GroupBox()
    '    Me.cbIgmNegative = New System.Windows.Forms.RadioButton()
    '    Me.cbIgmPositive = New System.Windows.Forms.RadioButton()
    '    Me.cmbSpecimen = New System.Windows.Forms.ComboBox()
    '    Me.lblOthersmisc = New System.Windows.Forms.Label()
    '    Me.richtxtOthers = New System.Windows.Forms.RichTextBox()
    '    Me.lblResult = New System.Windows.Forms.Label()
    '    Me.lblSpecimen = New System.Windows.Forms.Label()
    '    Me.txtSpecimen = New System.Windows.Forms.TextBox()
    '    Me.lblLabExam = New System.Windows.Forms.Label()
    '    Me.txtLabExam = New System.Windows.Forms.TextBox()
    '    Me.cmbMedtech = New System.Windows.Forms.ComboBox()
    '    Me.lblMedtech = New System.Windows.Forms.Label()
    '    Me.dtDate = New System.Windows.Forms.DateTimePicker()
    '    Me.lblDate = New System.Windows.Forms.Label()
    '    Me.txtLabno = New System.Windows.Forms.TextBox()
    '    Me.lblLabNo = New System.Windows.Forms.Label()
    '    Me.lblpatientid = New System.Windows.Forms.Label()
    '    Me.txtGender = New System.Windows.Forms.TextBox()
    '    Me.lblGender = New System.Windows.Forms.Label()
    '    Me.txtAge = New System.Windows.Forms.TextBox()
    '    Me.lblAge = New System.Windows.Forms.Label()
    '    Me.txtRoomno = New System.Windows.Forms.TextBox()
    '    Me.lblRoomno = New System.Windows.Forms.Label()
    '    Me.txtPatientname = New System.Windows.Forms.TextBox()
    '    Me.lblPatientname = New System.Windows.Forms.Label()
    '    Me.txtPatientid = New System.Windows.Forms.TextBox()
    '    Me.lblMisc = New System.Windows.Forms.Label()
    '    Me.dlgPrint = New System.Windows.Forms.PrintDialog()
    '    Me.lblIGM = New System.Windows.Forms.Label()
    '    Me.rbPositive = New System.Windows.Forms.RadioButton()
    '    Me.dlgPrintPreview = New System.Windows.Forms.PrintPreviewDialog()
    '    Me.MiscPrintDocu = New System.Drawing.Printing.PrintDocument()
    '    Me.txtRadiobuttonResult = New System.Windows.Forms.TextBox()
    '    Me.txtIGM = New System.Windows.Forms.TextBox()
    '    Me.txtIGG = New System.Windows.Forms.TextBox()
    '    Me.lblIGG = New System.Windows.Forms.Label()
    '    Me.rbNegative = New System.Windows.Forms.RadioButton()
    '    CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    '    Me.gbIGG.SuspendLayout()
    '    Me.gbIGM.SuspendLayout()
    '    Me.SuspendLayout()
    '    '
    '    'lablTelNo
    '    '
    '    Me.lablTelNo.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lablTelNo.BackColor = System.Drawing.SystemColors.Control
    '    Me.lablTelNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.lablTelNo.ForeColor = System.Drawing.Color.Black
    '    Me.lablTelNo.Location = New System.Drawing.Point(300, 94)
    '    Me.lablTelNo.Name = "lablTelNo"
    '    Me.lablTelNo.Size = New System.Drawing.Size(290, 14)
    '    Me.lablTelNo.TabIndex = 288
    '    Me.lablTelNo.Text = "xxxx"
    '    Me.lablTelNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '    '
    '    'lblHeader
    '    '
    '    Me.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblHeader.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.lblHeader.ForeColor = System.Drawing.Color.Black
    '    Me.lblHeader.Location = New System.Drawing.Point(298, 56)
    '    Me.lblHeader.Name = "lblHeader"
    '    Me.lblHeader.Size = New System.Drawing.Size(293, 21)
    '    Me.lblHeader.TabIndex = 286
    '    Me.lblHeader.Text = "xxxx"
    '    Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '    '
    '    'lblAddress
    '    '
    '    Me.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblAddress.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.lblAddress.ForeColor = System.Drawing.Color.Black
    '    Me.lblAddress.Location = New System.Drawing.Point(300, 77)
    '    Me.lblAddress.Name = "lblAddress"
    '    Me.lblAddress.Size = New System.Drawing.Size(290, 14)
    '    Me.lblAddress.TabIndex = 287
    '    Me.lblAddress.Text = "xxxx"
    '    Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '    '
    '    'pctrLogo
    '    '
    '    Me.pctrLogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(75, Byte), Integer))
    '    Me.pctrLogo.Location = New System.Drawing.Point(12, 54)
    '    Me.pctrLogo.Name = "pctrLogo"
    '    Me.pctrLogo.Size = New System.Drawing.Size(86, 74)
    '    Me.pctrLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    '    Me.pctrLogo.TabIndex = 285
    '    Me.pctrLogo.TabStop = False
    '    '
    '    'cbIggPositive
    '    '
    '    Me.cbIggPositive.AutoSize = True
    '    Me.cbIggPositive.Checked = True
    '    Me.cbIggPositive.Location = New System.Drawing.Point(20, 25)
    '    Me.cbIggPositive.Name = "cbIggPositive"
    '    Me.cbIggPositive.Size = New System.Drawing.Size(33, 19)
    '    Me.cbIggPositive.TabIndex = 244
    '    Me.cbIggPositive.TabStop = True
    '    Me.cbIggPositive.Text = "+"
    '    Me.cbIggPositive.UseVisualStyleBackColor = True
    '    '
    '    'txtPathologist
    '    '
    '    Me.txtPathologist.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.txtPathologist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    '    Me.txtPathologist.FormattingEnabled = True
    '    Me.txtPathologist.Location = New System.Drawing.Point(437, 186)
    '    Me.txtPathologist.Name = "txtPathologist"
    '    Me.txtPathologist.Size = New System.Drawing.Size(170, 21)
    '    Me.txtPathologist.TabIndex = 267
    '    '
    '    'lblPathologist
    '    '
    '    Me.lblPathologist.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblPathologist.AutoSize = True
    '    Me.lblPathologist.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblPathologist.ForeColor = System.Drawing.Color.Black
    '    Me.lblPathologist.Location = New System.Drawing.Point(374, 194)
    '    Me.lblPathologist.Name = "lblPathologist"
    '    Me.lblPathologist.Size = New System.Drawing.Size(62, 13)
    '    Me.lblPathologist.TabIndex = 266
    '    Me.lblPathologist.Text = "Pathologist:"
    '    '
    '    'cbIggNegative
    '    '
    '    Me.cbIggNegative.AutoSize = True
    '    Me.cbIggNegative.Location = New System.Drawing.Point(71, 26)
    '    Me.cbIggNegative.Name = "cbIggNegative"
    '    Me.cbIggNegative.Size = New System.Drawing.Size(30, 19)
    '    Me.cbIggNegative.TabIndex = 245
    '    Me.cbIggNegative.Text = "-"
    '    Me.cbIggNegative.UseVisualStyleBackColor = True
    '    '
    '    'gbIGG
    '    '
    '    Me.gbIGG.Controls.Add(Me.cbIggNegative)
    '    Me.gbIGG.Controls.Add(Me.cbIggPositive)
    '    Me.gbIGG.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
    '    Me.gbIGG.Location = New System.Drawing.Point(399, 324)
    '    Me.gbIGG.Name = "gbIGG"
    '    Me.gbIGG.Size = New System.Drawing.Size(113, 57)
    '    Me.gbIGG.TabIndex = 284
    '    Me.gbIGG.TabStop = False
    '    Me.gbIGG.Text = "IGG"
    '    '
    '    'gbIGM
    '    '
    '    Me.gbIGM.Controls.Add(Me.cbIgmNegative)
    '    Me.gbIGM.Controls.Add(Me.cbIgmPositive)
    '    Me.gbIGM.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
    '    Me.gbIGM.Location = New System.Drawing.Point(267, 324)
    '    Me.gbIGM.Name = "gbIGM"
    '    Me.gbIGM.Size = New System.Drawing.Size(105, 57)
    '    Me.gbIGM.TabIndex = 283
    '    Me.gbIGM.TabStop = False
    '    Me.gbIGM.Text = "IGM"
    '    '
    '    'cbIgmNegative
    '    '
    '    Me.cbIgmNegative.AutoSize = True
    '    Me.cbIgmNegative.Location = New System.Drawing.Point(65, 25)
    '    Me.cbIgmNegative.Name = "cbIgmNegative"
    '    Me.cbIgmNegative.Size = New System.Drawing.Size(30, 19)
    '    Me.cbIgmNegative.TabIndex = 246
    '    Me.cbIgmNegative.Text = "-"
    '    Me.cbIgmNegative.UseVisualStyleBackColor = True
    '    '
    '    'cbIgmPositive
    '    '
    '    Me.cbIgmPositive.AutoSize = True
    '    Me.cbIgmPositive.Checked = True
    '    Me.cbIgmPositive.Location = New System.Drawing.Point(18, 25)
    '    Me.cbIgmPositive.Name = "cbIgmPositive"
    '    Me.cbIgmPositive.Size = New System.Drawing.Size(33, 19)
    '    Me.cbIgmPositive.TabIndex = 245
    '    Me.cbIgmPositive.TabStop = True
    '    Me.cbIgmPositive.Text = "+"
    '    Me.cbIgmPositive.UseVisualStyleBackColor = True
    '    '
    '    'cmbSpecimen
    '    '
    '    Me.cmbSpecimen.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.cmbSpecimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    '    Me.cmbSpecimen.FormattingEnabled = True
    '    Me.cmbSpecimen.Location = New System.Drawing.Point(587, 283)
    '    Me.cmbSpecimen.Name = "cmbSpecimen"
    '    Me.cmbSpecimen.Size = New System.Drawing.Size(182, 21)
    '    Me.cmbSpecimen.TabIndex = 282
    '    '
    '    'lblOthersmisc
    '    '
    '    Me.lblOthersmisc.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblOthersmisc.AutoSize = True
    '    Me.lblOthersmisc.BackColor = System.Drawing.Color.Transparent
    '    Me.lblOthersmisc.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
    '    Me.lblOthersmisc.Location = New System.Drawing.Point(185, 389)
    '    Me.lblOthersmisc.Name = "lblOthersmisc"
    '    Me.lblOthersmisc.Size = New System.Drawing.Size(66, 15)
    '    Me.lblOthersmisc.TabIndex = 276
    '    Me.lblOthersmisc.Text = "REMARKS:"
    '    '
    '    'richtxtOthers
    '    '
    '    Me.richtxtOthers.Font = New System.Drawing.Font("Segoe UI", 9.0!)
    '    Me.richtxtOthers.Location = New System.Drawing.Point(264, 387)
    '    Me.richtxtOthers.Name = "richtxtOthers"
    '    Me.richtxtOthers.Size = New System.Drawing.Size(356, 107)
    '    Me.richtxtOthers.TabIndex = 275
    '    Me.richtxtOthers.Text = ""
    '    '
    '    'lblResult
    '    '
    '    Me.lblResult.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblResult.AutoSize = True
    '    Me.lblResult.BackColor = System.Drawing.Color.Transparent
    '    Me.lblResult.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
    '    Me.lblResult.Location = New System.Drawing.Point(184, 332)
    '    Me.lblResult.Name = "lblResult"
    '    Me.lblResult.Size = New System.Drawing.Size(59, 15)
    '    Me.lblResult.TabIndex = 274
    '    Me.lblResult.Text = "RESULTS:"
    '    '
    '    'lblSpecimen
    '    '
    '    Me.lblSpecimen.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblSpecimen.AutoSize = True
    '    Me.lblSpecimen.BackColor = System.Drawing.Color.Transparent
    '    Me.lblSpecimen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
    '    Me.lblSpecimen.Location = New System.Drawing.Point(184, 285)
    '    Me.lblSpecimen.Name = "lblSpecimen"
    '    Me.lblSpecimen.Size = New System.Drawing.Size(67, 15)
    '    Me.lblSpecimen.TabIndex = 273
    '    Me.lblSpecimen.Text = "SPECIMEN:"
    '    '
    '    'txtSpecimen
    '    '
    '    Me.txtSpecimen.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.txtSpecimen.BackColor = System.Drawing.Color.White
    '    Me.txtSpecimen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
    '    Me.txtSpecimen.Location = New System.Drawing.Point(271, 282)
    '    Me.txtSpecimen.Name = "txtSpecimen"
    '    Me.txtSpecimen.Size = New System.Drawing.Size(310, 23)
    '    Me.txtSpecimen.TabIndex = 272
    '    '
    '    'lblLabExam
    '    '
    '    Me.lblLabExam.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblLabExam.AutoSize = True
    '    Me.lblLabExam.BackColor = System.Drawing.Color.Transparent
    '    Me.lblLabExam.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
    '    Me.lblLabExam.Location = New System.Drawing.Point(134, 243)
    '    Me.lblLabExam.Name = "lblLabExam"
    '    Me.lblLabExam.Size = New System.Drawing.Size(117, 15)
    '    Me.lblLabExam.TabIndex = 271
    '    Me.lblLabExam.Text = "LAB EXAMINATION:"
    '    '
    '    'txtLabExam
    '    '
    '    Me.txtLabExam.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.txtLabExam.BackColor = System.Drawing.Color.Bisque
    '    Me.txtLabExam.Enabled = False
    '    Me.txtLabExam.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
    '    Me.txtLabExam.Location = New System.Drawing.Point(271, 240)
    '    Me.txtLabExam.Name = "txtLabExam"
    '    Me.txtLabExam.ReadOnly = True
    '    Me.txtLabExam.Size = New System.Drawing.Size(498, 23)
    '    Me.txtLabExam.TabIndex = 270
    '    '
    '    'cmbMedtech
    '    '
    '    Me.cmbMedtech.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.cmbMedtech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    '    Me.cmbMedtech.FormattingEnabled = True
    '    Me.cmbMedtech.Location = New System.Drawing.Point(690, 186)
    '    Me.cmbMedtech.Name = "cmbMedtech"
    '    Me.cmbMedtech.Size = New System.Drawing.Size(146, 21)
    '    Me.cmbMedtech.TabIndex = 269
    '    '
    '    'lblMedtech
    '    '
    '    Me.lblMedtech.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblMedtech.AutoSize = True
    '    Me.lblMedtech.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblMedtech.ForeColor = System.Drawing.Color.Black
    '    Me.lblMedtech.Location = New System.Drawing.Point(626, 194)
    '    Me.lblMedtech.Name = "lblMedtech"
    '    Me.lblMedtech.Size = New System.Drawing.Size(59, 13)
    '    Me.lblMedtech.TabIndex = 268
    '    Me.lblMedtech.Text = "Med Tech:"
    '    '
    '    'dtDate
    '    '
    '    Me.dtDate.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.dtDate.Enabled = False
    '    Me.dtDate.Location = New System.Drawing.Point(177, 187)
    '    Me.dtDate.Name = "dtDate"
    '    Me.dtDate.Size = New System.Drawing.Size(191, 20)
    '    Me.dtDate.TabIndex = 265
    '    '
    '    'lblDate
    '    '
    '    Me.lblDate.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblDate.AutoSize = True
    '    Me.lblDate.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblDate.ForeColor = System.Drawing.Color.Black
    '    Me.lblDate.Location = New System.Drawing.Point(146, 194)
    '    Me.lblDate.Name = "lblDate"
    '    Me.lblDate.Size = New System.Drawing.Size(33, 13)
    '    Me.lblDate.TabIndex = 264
    '    Me.lblDate.Text = "Date:"
    '    '
    '    'txtLabno
    '    '
    '    Me.txtLabno.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.txtLabno.Enabled = False
    '    Me.txtLabno.Location = New System.Drawing.Point(61, 187)
    '    Me.txtLabno.Name = "txtLabno"
    '    Me.txtLabno.Size = New System.Drawing.Size(81, 20)
    '    Me.txtLabno.TabIndex = 263
    '    '
    '    'lblLabNo
    '    '
    '    Me.lblLabNo.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblLabNo.AutoSize = True
    '    Me.lblLabNo.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblLabNo.ForeColor = System.Drawing.Color.Black
    '    Me.lblLabNo.Location = New System.Drawing.Point(17, 194)
    '    Me.lblLabNo.Name = "lblLabNo"
    '    Me.lblLabNo.Size = New System.Drawing.Size(45, 13)
    '    Me.lblLabNo.TabIndex = 262
    '    Me.lblLabNo.Text = "Lab No:"
    '    '
    '    'lblpatientid
    '    '
    '    Me.lblpatientid.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblpatientid.AutoSize = True
    '    Me.lblpatientid.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblpatientid.ForeColor = System.Drawing.Color.Black
    '    Me.lblpatientid.Location = New System.Drawing.Point(13, 153)
    '    Me.lblpatientid.Name = "lblpatientid"
    '    Me.lblpatientid.Size = New System.Drawing.Size(65, 13)
    '    Me.lblpatientid.TabIndex = 261
    '    Me.lblpatientid.Text = "Hospital No:"
    '    '
    '    'txtGender
    '    '
    '    Me.txtGender.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.txtGender.Enabled = False
    '    Me.txtGender.Location = New System.Drawing.Point(552, 146)
    '    Me.txtGender.Name = "txtGender"
    '    Me.txtGender.Size = New System.Drawing.Size(62, 20)
    '    Me.txtGender.TabIndex = 260
    '    '
    '    'lblGender
    '    '
    '    Me.lblGender.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblGender.AutoSize = True
    '    Me.lblGender.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblGender.ForeColor = System.Drawing.Color.Black
    '    Me.lblGender.Location = New System.Drawing.Point(508, 153)
    '    Me.lblGender.Name = "lblGender"
    '    Me.lblGender.Size = New System.Drawing.Size(45, 13)
    '    Me.lblGender.TabIndex = 259
    '    Me.lblGender.Text = "Gender:"
    '    '
    '    'txtAge
    '    '
    '    Me.txtAge.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.txtAge.Enabled = False
    '    Me.txtAge.Location = New System.Drawing.Point(647, 146)
    '    Me.txtAge.Name = "txtAge"
    '    Me.txtAge.Size = New System.Drawing.Size(57, 20)
    '    Me.txtAge.TabIndex = 258
    '    '
    '    'lblAge
    '    '
    '    Me.lblAge.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblAge.AutoSize = True
    '    Me.lblAge.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblAge.ForeColor = System.Drawing.Color.Black
    '    Me.lblAge.Location = New System.Drawing.Point(617, 153)
    '    Me.lblAge.Name = "lblAge"
    '    Me.lblAge.Size = New System.Drawing.Size(29, 13)
    '    Me.lblAge.TabIndex = 257
    '    Me.lblAge.Text = "Age:"
    '    '
    '    'txtRoomno
    '    '
    '    Me.txtRoomno.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.txtRoomno.Enabled = False
    '    Me.txtRoomno.Location = New System.Drawing.Point(760, 146)
    '    Me.txtRoomno.Name = "txtRoomno"
    '    Me.txtRoomno.Size = New System.Drawing.Size(44, 20)
    '    Me.txtRoomno.TabIndex = 256
    '    '
    '    'lblRoomno
    '    '
    '    Me.lblRoomno.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblRoomno.AutoSize = True
    '    Me.lblRoomno.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblRoomno.ForeColor = System.Drawing.Color.Black
    '    Me.lblRoomno.Location = New System.Drawing.Point(706, 153)
    '    Me.lblRoomno.Name = "lblRoomno"
    '    Me.lblRoomno.Size = New System.Drawing.Size(55, 13)
    '    Me.lblRoomno.TabIndex = 255
    '    Me.lblRoomno.Text = "Room No:"
    '    '
    '    'txtPatientname
    '    '
    '    Me.txtPatientname.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.txtPatientname.Enabled = False
    '    Me.txtPatientname.Location = New System.Drawing.Point(80, 146)
    '    Me.txtPatientname.Name = "txtPatientname"
    '    Me.txtPatientname.Size = New System.Drawing.Size(80, 20)
    '    Me.txtPatientname.TabIndex = 254
    '    '
    '    'lblPatientname
    '    '
    '    Me.lblPatientname.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblPatientname.AutoSize = True
    '    Me.lblPatientname.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblPatientname.ForeColor = System.Drawing.Color.Black
    '    Me.lblPatientname.Location = New System.Drawing.Point(183, 153)
    '    Me.lblPatientname.Name = "lblPatientname"
    '    Me.lblPatientname.Size = New System.Drawing.Size(74, 13)
    '    Me.lblPatientname.TabIndex = 253
    '    Me.lblPatientname.Text = "Patient Name:"
    '    '
    '    'txtPatientid
    '    '
    '    Me.txtPatientid.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.txtPatientid.Enabled = False
    '    Me.txtPatientid.Location = New System.Drawing.Point(258, 146)
    '    Me.txtPatientid.Name = "txtPatientid"
    '    Me.txtPatientid.Size = New System.Drawing.Size(246, 20)
    '    Me.txtPatientid.TabIndex = 252
    '    '
    '    'lblMisc
    '    '
    '    Me.lblMisc.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.lblMisc.AutoSize = True
    '    Me.lblMisc.BackColor = System.Drawing.SystemColors.Control
    '    Me.lblMisc.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
    '    Me.lblMisc.ForeColor = System.Drawing.Color.Black
    '    Me.lblMisc.Location = New System.Drawing.Point(379, 111)
    '    Me.lblMisc.Name = "lblMisc"
    '    Me.lblMisc.Size = New System.Drawing.Size(125, 17)
    '    Me.lblMisc.TabIndex = 251
    '    Me.lblMisc.Text = "MISCELLANEOUS"
    '    '
    '    'dlgPrint
    '    '
    '    Me.dlgPrint.UseEXDialog = True
    '    '
    '    'lblIGM
    '    '
    '    Me.lblIGM.AutoSize = True
    '    Me.lblIGM.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
    '    Me.lblIGM.Location = New System.Drawing.Point(264, 348)
    '    Me.lblIGM.Name = "lblIGM"
    '    Me.lblIGM.Size = New System.Drawing.Size(34, 15)
    '    Me.lblIGM.TabIndex = 280
    '    Me.lblIGM.Text = "IGM:"
    '    Me.lblIGM.Visible = False
    '    '
    '    'rbPositive
    '    '
    '    Me.rbPositive.AutoSize = True
    '    Me.rbPositive.Checked = True
    '    Me.rbPositive.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
    '    Me.rbPositive.Location = New System.Drawing.Point(273, 339)
    '    Me.rbPositive.Name = "rbPositive"
    '    Me.rbPositive.Size = New System.Drawing.Size(129, 19)
    '    Me.rbPositive.TabIndex = 249
    '    Me.rbPositive.TabStop = True
    '    Me.rbPositive.Text = "Positive / Reactive"
    '    Me.rbPositive.UseVisualStyleBackColor = True
    '    '
    '    'dlgPrintPreview
    '    '
    '    Me.dlgPrintPreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
    '    Me.dlgPrintPreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
    '    Me.dlgPrintPreview.ClientSize = New System.Drawing.Size(400, 300)
    '    Me.dlgPrintPreview.Document = Me.MiscPrintDocu
    '    Me.dlgPrintPreview.Enabled = True
    '    Me.dlgPrintPreview.Icon = CType(resources.GetObject("dlgPrintPreview.Icon"), System.Drawing.Icon)
    '    Me.dlgPrintPreview.Name = "dlgPrintPreview"
    '    Me.dlgPrintPreview.Visible = False
    '    '
    '    'txtRadiobuttonResult
    '    '
    '    Me.txtRadiobuttonResult.Anchor = System.Windows.Forms.AnchorStyles.None
    '    Me.txtRadiobuttonResult.BackColor = System.Drawing.Color.White
    '    Me.txtRadiobuttonResult.Font = New System.Drawing.Font("Segoe UI", 9.0!)
    '    Me.txtRadiobuttonResult.Location = New System.Drawing.Point(268, 330)
    '    Me.txtRadiobuttonResult.Name = "txtRadiobuttonResult"
    '    Me.txtRadiobuttonResult.Size = New System.Drawing.Size(216, 23)
    '    Me.txtRadiobuttonResult.TabIndex = 277
    '    Me.txtRadiobuttonResult.Visible = False
    '    '
    '    'txtIGM
    '    '
    '    Me.txtIGM.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
    '    Me.txtIGM.Location = New System.Drawing.Point(297, 345)
    '    Me.txtIGM.Name = "txtIGM"
    '    Me.txtIGM.Size = New System.Drawing.Size(31, 23)
    '    Me.txtIGM.TabIndex = 281
    '    Me.txtIGM.Visible = False
    '    '
    '    'txtIGG
    '    '
    '    Me.txtIGG.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
    '    Me.txtIGG.Location = New System.Drawing.Point(367, 346)
    '    Me.txtIGG.Name = "txtIGG"
    '    Me.txtIGG.Size = New System.Drawing.Size(31, 23)
    '    Me.txtIGG.TabIndex = 279
    '    Me.txtIGG.Visible = False
    '    '
    '    'lblIGG
    '    '
    '    Me.lblIGG.AutoSize = True
    '    Me.lblIGG.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
    '    Me.lblIGG.Location = New System.Drawing.Point(336, 348)
    '    Me.lblIGG.Name = "lblIGG"
    '    Me.lblIGG.Size = New System.Drawing.Size(32, 15)
    '    Me.lblIGG.TabIndex = 278
    '    Me.lblIGG.Text = "IGG:"
    '    Me.lblIGG.Visible = False
    '    '
    '    'rbNegative
    '    '
    '    Me.rbNegative.AutoSize = True
    '    Me.rbNegative.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
    '    Me.rbNegative.Location = New System.Drawing.Point(411, 340)
    '    Me.rbNegative.Name = "rbNegative"
    '    Me.rbNegative.Size = New System.Drawing.Size(162, 19)
    '    Me.rbNegative.TabIndex = 250
    '    Me.rbNegative.Text = "Negative - Non Reactive"
    '    Me.rbNegative.UseVisualStyleBackColor = True
    '    '
    '    'frmMiscellaneous
    '    '
    '    Me.ClientSize = New System.Drawing.Size(848, 549)
    '    Me.Controls.Add(Me.lablTelNo)
    '    Me.Controls.Add(Me.lblHeader)
    '    Me.Controls.Add(Me.lblAddress)
    '    Me.Controls.Add(Me.pctrLogo)
    '    Me.Controls.Add(Me.txtPathologist)
    '    Me.Controls.Add(Me.lblPathologist)
    '    Me.Controls.Add(Me.gbIGG)
    '    Me.Controls.Add(Me.gbIGM)
    '    Me.Controls.Add(Me.cmbSpecimen)
    '    Me.Controls.Add(Me.lblOthersmisc)
    '    Me.Controls.Add(Me.richtxtOthers)
    '    Me.Controls.Add(Me.lblResult)
    '    Me.Controls.Add(Me.lblSpecimen)
    '    Me.Controls.Add(Me.txtSpecimen)
    '    Me.Controls.Add(Me.lblLabExam)
    '    Me.Controls.Add(Me.txtLabExam)
    '    Me.Controls.Add(Me.cmbMedtech)
    '    Me.Controls.Add(Me.lblMedtech)
    '    Me.Controls.Add(Me.dtDate)
    '    Me.Controls.Add(Me.lblDate)
    '    Me.Controls.Add(Me.txtLabno)
    '    Me.Controls.Add(Me.lblLabNo)
    '    Me.Controls.Add(Me.lblpatientid)
    '    Me.Controls.Add(Me.txtGender)
    '    Me.Controls.Add(Me.lblGender)
    '    Me.Controls.Add(Me.txtAge)
    '    Me.Controls.Add(Me.lblAge)
    '    Me.Controls.Add(Me.txtRoomno)
    '    Me.Controls.Add(Me.lblRoomno)
    '    Me.Controls.Add(Me.txtPatientname)
    '    Me.Controls.Add(Me.lblPatientname)
    '    Me.Controls.Add(Me.txtPatientid)
    '    Me.Controls.Add(Me.lblMisc)
    '    Me.Controls.Add(Me.lblIGM)
    '    Me.Controls.Add(Me.rbPositive)
    '    Me.Controls.Add(Me.txtRadiobuttonResult)
    '    Me.Controls.Add(Me.txtIGM)
    '    Me.Controls.Add(Me.txtIGG)
    '    Me.Controls.Add(Me.lblIGG)
    '    Me.Controls.Add(Me.rbNegative)
    '    Me.Name = "frmMiscellaneous"
    '    CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).EndInit()
    '    Me.gbIGG.ResumeLayout(False)
    '    Me.gbIGG.PerformLayout()
    '    Me.gbIGM.ResumeLayout(False)
    '    Me.gbIGM.PerformLayout()
    '    Me.ResumeLayout(False)
    '    Me.PerformLayout()

    'End Sub
End Class