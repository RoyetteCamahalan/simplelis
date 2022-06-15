Public Class frmMDIParent
    '   Inherits BaseForms.frmStandardEntry ' something
#Region "Variables"

    Dim myFormStatus As enFormStatus
    Public myResult As enResult
    'Public labtype As Long

    Dim lab As New DataTable
    Public IsSelected As Boolean
    Public Islock As Boolean
    Public dtFecalysis As New DataTable
    Public frmfecalysisi As New frmFecalysis()
    Public frmurinalysiss As New frmUrinalysis()
    Public frmHematologyis As New frmHematology()
    Public frmBloodChem As New frmBloodChemistry()
    Public frmECGReports As New frmECGReport()
    Public frmCrossmatchings As New frmCrossMatching()
    Public frmNewBornScreenings As New frmNewBornScreening()
    Public frmMisc As New frmMiscellaneous()
    Public frmReportHandlers As New frmReport
    Public frmRadiology As New frmRadiology()
    Public enbl As Boolean
    Public frm As String
    Public itemcode As String ' For itemcode
    Public IsEditOrRelease As Boolean
    Public requestdetailno As Long

    Public soperation As Integer 'updates
    Public controlProperties As Boolean 'Updates
    Public IsEdit As Boolean
    Public isCancel As Boolean

    Public status As Integer
    Public patientNO As String
    Dim msg As String
    Dim labid As Long

    Public adminid As Long
    Public tempadminid As String
    Public isSave As Boolean 
    Public isUseByDashboard As Boolean
#End Region
#Region "Constructor"
    Enum enFormStatus
        browsing = 0            'edit fields disabled
        add = 1
        edit = 2
    End Enum
    Enum enResult
        manageresult = 4 '0
        releaseresult = 5 '1
    End Enum
    Sub New(ByVal FormStatus As enFormStatus)
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call.
        myFormStatus = FormStatus
    End Sub
#End Region
#Region "Methods"
    Private Sub TreeviewControls()
        If IsSelected = False Then
            For i = 0 To lab.Rows.Count - 1
                If frm = lab.Rows(i)(1).ToString() Then
                    dtFecalysis = clsExamination.getLabdetails(i + 1)
                    For i1 = 0 To dtFecalysis.Rows.Count - 1
                        Me.tvControlsMain.Nodes.Add(dtFecalysis.Rows(i1)(2).ToString())
                        Me.tvControlsMain.Nodes(i1).Name = dtFecalysis.Rows(i1)(2).ToString()
                        Me.tvControlsMain.Nodes(i1).SelectedImageIndex = 0
                        If Convert.ToBoolean(dtFecalysis.Rows(i1)(7).ToString) = True Then
                            Me.tvControlsMain.Nodes(i1).BackColor = Color.Yellow
                        End If
                    Next
                End If
            Next
        Else
            Me.tvControlsMain.Visible = False
        End If
    End Sub
    Private Sub save()
        If IsSelected = False Then '************ Design Mode her
            If MsgBox("Are you sure you want to save this examination template?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, modGlobal.msgboxTitle) = MsgBoxResult.Yes Then
                lab = clsExamination.getLabtypes()
                If frm = lab.Rows(0)(1).ToString() Then
                    frmfecalysisi.Fecalysis()
                    tsSave.Visible = False
                    tsPrint.Visible = False

                    Me.tvControlsMain.Enabled = False
                    Me.tsPrint.Enabled = True
                    frmurinalysiss.LockFields()
                    MsgBox("Template successfully saved.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                ElseIf frm = lab.Rows(1)(1).ToString() Then
                    frmurinalysiss.Urinalysis()
                    tsSave.Visible = False
                    tsPrint.Visible = False
                    Me.tvControlsMain.Enabled = False
                    frmurinalysiss.LockFields()
                    MsgBox("Template successfully saved.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                ElseIf frm = lab.Rows(2)(1).ToString() Then
                    frmHematologyis.Hematology()
                    tsSave.Visible = False
                    tsPrint.Visible = False
                    Me.tvControlsMain.Enabled = False
                    tsSave.Enabled = False
                    frmHematologyis.LockFields()
                    MsgBox("Template successfully saved.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                ElseIf frm = lab.Rows(3)(1).ToString() Then
                    frmBloodChem.BloodChem()
                    tsSave.Visible = False
                    tsPrint.Visible = False
                    Me.tsPrint.Enabled = True
                    Me.tvControlsMain.Enabled = False
                    frmBloodChem.LockFields()
                    MsgBox("Template successfully saved.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                End If
                'tsPrintPDF.Visible = tsPrint.Visible
            End If
        Else
            If Me.tsSave.Text = "Release" Then
                msg = "Are you sure you want to release this examination?"
            ElseIf Me.tsSave.Text = "Update" Then
                msg = "Are you sure you want to update this examination result?"
            ElseIf Me.tsSave.Text = "Save" Then
                msg = "Are you sure you want to save this examination result?"
            End If

            ' **************** data Entry her
            'For Canceling a Examination Result
            If tsSave.Text = "Cancel" Then
                If MsgBox("Are you sure you want to cancel this examination result?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, modGlobal.msgboxTitle) = MsgBoxResult.Yes Then

                    If labid = 1 Then
                        Call frmfecalysisi.UpdateRequestStatus()
                        MsgBox("Examination has been canceled", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                        Me.Close()
                        'Urinalysis
                    ElseIf labid = 2 Then
                        Call frmurinalysiss.UpdateRequestStatus()
                        MsgBox("Examination has been canceled", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                        Me.Close()

                        'Hematology
                    ElseIf labid = 3 Then
                        Call frmHematologyis.UpdateRequestStatus()
                        MsgBox("Examination has been canceled", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                        Me.Close()

                        'Blood Chem 
                    ElseIf labid = 4 Then

                        Call frmBloodChem.UpdateRequestStatus()
                        MsgBox("Examination has been canceled", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                        Me.Close()
                    ElseIf labid = 8 Then
                        Call frmMisc.UpdateRequestStatus()
                        MsgBox("Examination has been canceled", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                        Me.Close()
                    Else
                        Exit Sub
                    End If
                End If
            Else
                'Saving Entry
                If MsgBox(msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, modGlobal.msgboxTitle) = MsgBoxResult.Yes Then
                    'fecalysis
                    If labid = 1 Then

                        Call frmfecalysisi.saveFecalysis()
                        If status = 4 Or status = 5 Then
                            Call frmfecalysisi.UpdateRequestStatus()
                        End If
                        Call frmfecalysisi.txtBoxProperties(False)
                        tsSave.Visible = False
                        frmHematologyis.LockFields()
                        isSave = frmfecalysisi.isSave
                        MessageBox.Show("Successfully saved.", modGlobal.msgboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'Urinalysis
                    ElseIf labid = 2 Then

                        Call frmurinalysiss.saveUrinalysis()
                        If status = 4 Or status = 5 Then
                            Call frmurinalysiss.UpdateRequestStatus()
                        End If
                        Call frmurinalysiss.txtBoxProperties(False)
                        tsSave.Visible = False
                        frmurinalysiss.LockFields()
                        isSave = frmurinalysiss.isSave
                        MessageBox.Show("Successfully saved.", modGlobal.msgboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Hematology
                    ElseIf labid = 3 Then
                        Call frmHematologyis.saveHematology()
                        If status = 4 Or status = 5 Then
                            Call frmHematologyis.UpdateRequestStatus()
                        End If
                        Call frmHematologyis.txtBoxProperties(False)
                        tsSave.Visible = False
                        frmHematologyis.LockFields()
                        isSave = frmHematologyis.isSave
                        MessageBox.Show("Successfully saved.", modGlobal.msgboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Blood Chem 
                    ElseIf labid = 4 Then
                        If status = 4 Or status = 5 Then
                            Call frmBloodChem.UpdateRequestStatus()
                        End If
                        Call frmBloodChem.SaveBloodChemistry()
                        Call frmBloodChem.txtBoxProperties(False)
                        tsSave.Visible = False
                        frmHematologyis.LockFields()
                        isSave = frmBloodChem.isSave
                        MessageBox.Show("Successfully saved.", modGlobal.msgboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf labid = 7 Then
                        If status = 4 Or status = 5 Then
                            If myFormStatus = enFormStatus.add Then
                                frmECGReports.myFormStatus = frmECGReport.enFormStatus.add
                            ElseIf myFormStatus = enFormStatus.edit Then
                                frmECGReports.myFormStatus = frmECGReport.enFormStatus.edit
                            End If
                            Call frmECGReports.UpdateRequestStatus()
                        End If
                        If myFormStatus = enFormStatus.add Then
                            frmECGReports.myFormStatus = frmECGReport.enFormStatus.add
                            Call frmECGReports.SaveRecordResult()
                            Call frmECGReports.SaveRecord()
                            myFormStatus = enFormStatus.browsing
                        Else
                            frmECGReports.myFormStatus = frmECGReport.enFormStatus.edit
                            Call frmECGReports.UpdateRecord()
                            Call frmECGReports.SaveRecordResult()
                            myFormStatus = enFormStatus.browsing
                        End If
                        If myFormStatus = enFormStatus.browsing Then
                            myEnableFields()
                            frmECGReports.EnableFields()
                            frmECGReports.isSave = True
                            MsgBox("Record successfully saved.", vbInformation, modGlobal.msgboxTitle)
                            tsPrint.Visible = True
                        End If
                    ElseIf labid = 5 Then
                        If status = 4 Or status = 5 Then
                            If myFormStatus = enFormStatus.add Then
                                frmCrossmatchings.myFormStatus = frmECGReport.enFormStatus.add
                            ElseIf myFormStatus = enFormStatus.edit Then
                                frmCrossmatchings.myFormStatus = frmECGReport.enFormStatus.edit
                            End If
                            Call frmCrossmatchings.UpdateRequestStatus()
                        End If
                        If myFormStatus = enFormStatus.add Then
                            frmCrossmatchings.myFormStatus = frmECGReport.enFormStatus.add

                            frmCrossmatchings.SaveRecordResult()
                            frmCrossmatchings.SaveRecord()
                            frmCrossmatchings.SaveRecordResultDetails()
                            myFormStatus = enFormStatus.browsing
                        Else
                            frmCrossmatchings.myFormStatus = frmCrossMatching.enFormStatus.edit
                            frmCrossmatchings.SaveRecordResult()
                            frmCrossmatchings.SaveRecord()
                            frmCrossmatchings.SaveRecordResultDetails()
                            myFormStatus = enFormStatus.browsing
                        End If
                        If myFormStatus = enFormStatus.browsing Then
                            myEnableFields()
                            frmCrossmatchings.EnableFields()
                            frmCrossmatchings.isSave = True
                            MsgBox("Record successfully saved.", vbInformation, modGlobal.msgboxTitle)
                            tsPrint.Visible = True
                        End If
                    ElseIf labid = 6 Then
                        If status = 4 Or status = 5 Then
                            If myFormStatus = enFormStatus.add Then
                                frmNewBornScreenings.myFormStatus = frmECGReport.enFormStatus.add
                            ElseIf myFormStatus = enFormStatus.edit Then
                                frmNewBornScreenings.myFormStatus = frmECGReport.enFormStatus.edit
                            End If
                            Call frmNewBornScreenings.UpdateRequestStatus()
                        End If
                        If myFormStatus = enFormStatus.add Then
                            frmNewBornScreenings.myFormStatus = frmNewBornScreening.enFormStatus.add

                            frmNewBornScreenings.SaveRecordResult()
                            frmNewBornScreenings.SaveRecord()
                            myFormStatus = enFormStatus.browsing
                        Else
                            frmNewBornScreenings.myFormStatus = frmECGReport.enFormStatus.edit
                            frmNewBornScreenings.UpdateRecord()
                            frmNewBornScreenings.SaveRecordResult()
                            myFormStatus = enFormStatus.browsing
                        End If
                        If myFormStatus = enFormStatus.browsing Then
                            myEnableFields()
                            frmNewBornScreenings.EnableFields()
                            frmNewBornScreenings.isSave = True
                            MsgBox("Record successfully saved.", vbInformation, modGlobal.msgboxTitle)
                            tsPrint.Visible = True
                        Else

                        End If
                    ElseIf labid = 8 Then
                        Call frmMisc.save()
                        Call frmMisc.saveDetails()
                        If status = 4 Or status = 5 Then
                            Call frmMisc.UpdateRequestStatus()
                        End If
                        tsSave.Enabled = False
                        MsgBox("Record successfully saved.", vbInformation, modGlobal.msgboxTitle)
                        tsPrint.Visible = True
                    End If
                    'tsPrintPDF.Visible = tsPrint.Visible
                    If status = 5 Then
                        Me.tsPrint.Visible = True
                    Else
                        Me.tsPrint.Visible = False
                    End If
                End If
            End If
        End If
    End Sub
    Public Sub print()
        If labid = 1 Or frm = lab.Rows(0).Item("description") Then
            frmfecalysisi.DisplayPrintPreview()

        ElseIf labid = 2 Or frm = lab.Rows(1).Item("description") Then
            frmurinalysiss.DisplayPrintPreview()

        ElseIf labid = 3 Or frm = lab.Rows(2).Item("description") Then
            frmHematologyis.DisplayPrintPreview()

        ElseIf labid = 4 Or frm = lab.Rows(3).Item("description") Then
            frmBloodChem.DisplayPrintPreview()

        ElseIf labid = 7 Then 'JND update 6/15/2012
            frmECGReports.adminid = adminid
            frmECGReports.DisplayPrintPreview()


        ElseIf labid = 5 Then 'JND update 6/15/2012

            frmCrossmatchings.adminid = adminid
            frmCrossmatchings.DisplayPrintPreview()

        ElseIf labid = 6 Then 'JND update 6/15/2012
            frmNewBornScreenings.adminid = adminid
            frmNewBornScreenings.DisplayPrintPreview()
        ElseIf labid = 8 Then
            frmMisc.DisplayPrintPreview()
        End If
    End Sub
    Public Sub PrintPDF()
        If labid = 1 Or frm = lab.Rows(0).Item("description") Then
            frmfecalysisi.DisplayPrintPDF()

        ElseIf labid = 2 Or frm = lab.Rows(1).Item("description") Then
            frmurinalysiss.DisplayPrintPDF()

        ElseIf labid = 3 Or frm = lab.Rows(2).Item("description") Then
            frmHematologyis.DisplayPrintPDF()

        ElseIf labid = 4 Or frm = lab.Rows(3).Item("description") Then
            frmBloodChem.DisplayPrintPDF()

        ElseIf labid = 7 Then 'JND update 6/15/2012
            frmReportHandlers.printType = "ECG REPORT MAIN"
            frmReportHandlers.varno = adminid
            frmReportHandlers.ShowDialog()

        ElseIf labid = 5 Then 'JND update 6/15/2012
            frmReportHandlers.printType = "NEW BORN SCREENING MAIN"
            frmReportHandlers.varno = adminid
            frmReportHandlers.ShowDialog()

        ElseIf labid = 6 Then 'JND update 6/15/2012
            frmReportHandlers.printType = "CROSSMATCHING MAIN"
            frmReportHandlers.varno = adminid
            frmReportHandlers.ShowDialog()

        ElseIf labid = 8 Then
            frmMisc.DisplayPrintPreview()
        End If
    End Sub
#End Region
#Region "Events"
    Private Sub frmMDIParent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim frms As New Form()
        Dim dtlabitems As New DataTable
        Me.KeyPreview = True
        'Check if itemdesc is match
        dtlabitems = clsExamination.getLabItems()
        For i = 0 To dtlabitems.Rows.Count - 1
            If frm = dtlabitems.Rows(i).Item("itemdescription") Then
                labid = dtlabitems.Rows(i).Item("laboratoryid")
                itemcode = dtlabitems.Rows(i).Item("itemcode")
                Exit For
            Else

            End If
        Next

        If IsSelected = True Then '<<---- New Updated
            If labid = 0 Then
                MsgBox("Laboratory item Request has not been encoded yet", MsgBoxStyle.Information + MsgBoxStyle.Information, modGlobal.msgboxTitle)
                Me.Close()
                Exit Sub
            End If
        End If
        lab = clsExamination.getLabtypes()
        'Fecalysis
        If IsSelected = False Then '************ Design Mode her
            If frm = lab.Rows(0).Item("description") Then
                frmfecalysisi.MdiParent = Me
                frmfecalysisi.enabl = enbl
                TreeviewControls()
                frmfecalysisi.myFormStatus = myFormStatus
                frmfecalysisi.IsSelected = IsSelected
                frmfecalysisi.Islock = Islock
                frmfecalysisi.myResult = myResult
                frmfecalysisi.requestdetailno = requestdetailno
                frmfecalysisi.status = status
                frmfecalysisi.PatientNo = patientNO
                frmfecalysisi.Show()

                'Urinalysis
            ElseIf frm = lab.Rows(1).Item("description") Then
                frmurinalysiss.MdiParent = Me
                frmurinalysiss.enabl = enbl
                frmurinalysiss.IsSelected = IsSelected
                frmurinalysiss.myFormStatus = myFormStatus
                frmurinalysiss.Islock = Islock
                frmurinalysiss.myResult = myResult
                frmurinalysiss.requestdetailno = requestdetailno
                frmurinalysiss.status = status
                frmurinalysiss.PatientNo = patientNO
                TreeviewControls()
                frmurinalysiss.Show()

                'Hematology
            ElseIf frm = lab.Rows(2).Item("description") Then
                frmHematologyis.MdiParent = Me
                frmHematologyis.enbl = enbl
                frmHematologyis.IsSelected = IsSelected
                frmHematologyis.Islock = Islock
                frmHematologyis.myFormStatus = myFormStatus
                frmHematologyis.myResult = myResult
                frmHematologyis.requestdetailno = requestdetailno
                frmHematologyis.status = status
                frmHematologyis.PatientNo = patientNO
                TreeviewControls()
                frmHematologyis.Show()

                'Blood Chem
            ElseIf frm = lab.Rows(3).Item("description") Then
                frmBloodChem.MdiParent = Me
                frmBloodChem.enbl = enbl
                frmBloodChem.IsSelected = IsSelected
                frmBloodChem.Islock = Islock
                frmBloodChem.myFormStatus = myFormStatus
                frmBloodChem.myResult = myResult
                frmBloodChem.requestdetailno = requestdetailno
                frmBloodChem.status = status
                frmBloodChem.PatientNo = patientNO
                TreeviewControls()
                frmBloodChem.Show()
            End If

            '**************for entry here*******************
        Else
            Me.tsPrint.Visible = False
            'If isUseByDashboard Then
            '    Me.tsPrint.Visible = False
            'Else
            '    If myFormStatus = enFormStatus.add Then



            '    End If
            'End If
            'tsPrintPDF.Visible = tsPrint.Visible
            If labid = 1 Then
                frmfecalysisi.MdiParent = Me
                frmfecalysisi.soperation = soperation
                frmfecalysisi.enabl = enbl
                TreeviewControls()
                frmfecalysisi.myFormStatus = myFormStatus
                frmfecalysisi.IsSelected = IsSelected
                frmfecalysisi.Islock = Islock
                frmfecalysisi.myResult = myResult
                frmfecalysisi.requestdetailno = requestdetailno
                frmfecalysisi.status = status

                frmfecalysisi.PatientNo = patientNO
                frmfecalysisi.Show()

                'Urinalysis
            ElseIf labid = 2 Then
                frmurinalysiss.MdiParent = Me
                frmurinalysiss.soperation = soperation
                frmurinalysiss.enabl = enbl
                frmurinalysiss.IsSelected = IsSelected
                frmurinalysiss.myFormStatus = myFormStatus
                frmurinalysiss.Islock = Islock
                If Me.tsSave.Text = "Cancel" Then
                    frmurinalysiss.isCancel = True
                End If
                frmurinalysiss.myResult = myResult
                frmurinalysiss.requestdetailno = requestdetailno
                frmurinalysiss.status = status
                frmurinalysiss.PatientNo = patientNO
                TreeviewControls()
                frmurinalysiss.Show()

                'Hematology
            ElseIf labid = 3 Then
                frmHematologyis.MdiParent = Me
                frmHematologyis.soperation = soperation
                frmHematologyis.enbl = enbl
                frmHematologyis.IsSelected = IsSelected
                frmHematologyis.Islock = Islock
                If Me.tsSave.Text = "Cancel" Then
                    frmHematologyis.isCancel = True
                End If
                frmHematologyis.myFormStatus = myFormStatus
                frmHematologyis.myResult = myResult
                frmHematologyis.requestdetailno = requestdetailno
                frmHematologyis.status = status
                frmHematologyis.PatientNo = patientNO
                TreeviewControls()
                frmHematologyis.Show()
                'Blood Chem
            ElseIf labid = 4 Then
                frmBloodChem.MdiParent = Me
                frmBloodChem.soperation = soperation
                frmBloodChem.enbl = enbl
                frmBloodChem.IsSelected = IsSelected
                frmBloodChem.Islock = Islock
                frmBloodChem.myFormStatus = myFormStatus
                frmBloodChem.myResult = myResult
                If Me.tsSave.Text = "Cancel" Then
                    frmBloodChem.isCancel = True
                End If
                frmBloodChem.requestdetailno = requestdetailno
                frmBloodChem.status = status
                frmBloodChem.PatientNo = patientNO
                TreeviewControls()
                frmBloodChem.Show()
                'ECG Report
            ElseIf labid = 7 Then 'JND update 6/15/2012
                If myFormStatus = enFormStatus.add Or myFormStatus = enFormStatus.edit Then
                    frmECGReports.myResult = frmECGReport.enResult.manageresult
                Else
                    frmECGReports.myResult = frmECGReport.enResult.releaseresult
                End If
                frmECGReports.adminid = adminid
                frmECGReports.requestdetailno = requestdetailno
                frmECGReports.status = status
                frmECGReports.Islock = Islock
                frmECGReports.myFormStatus = myFormStatus
                Me.tvControlsMain.Visible = False
                frmECGReports.MdiParent = Me
                frmECGReports.Show()
            ElseIf labid = 5 Then 'JND update 6/15/2012
                If myFormStatus = enFormStatus.add Then
                    frmCrossmatchings.myResult = frmCrossMatching.enResult.manageresult
                Else
                    frmCrossmatchings.myResult = frmCrossMatching.enResult.releaseresult
                End If
                frmCrossmatchings.adminid = adminid
                frmCrossmatchings.requestdetailno = requestdetailno
                frmCrossmatchings.status = status
                frmCrossmatchings.Islock = Islock
                Me.tvControlsMain.Visible = False
                frmCrossmatchings.MdiParent = Me
                frmCrossmatchings.Show()
            ElseIf labid = 6 Then 'JND update 6/15/2012
                If myFormStatus = enFormStatus.add Then
                    frmNewBornScreenings.myResult = frmNewBornScreening.enResult.manageresult
                Else
                    frmNewBornScreenings.myResult = frmNewBornScreening.enResult.releaseresult
                End If
                frmNewBornScreenings.adminid = adminid
                frmNewBornScreenings.requestdetailno = requestdetailno
                frmNewBornScreenings.status = status
                frmNewBornScreenings.Islock = Islock
                frmNewBornScreenings.MdiParent = Me
                Me.tvControlsMain.Visible = False
                frmNewBornScreenings.Show()

            ElseIf labid = 8 Then

                'If myFormStatus = enFormStatus.add Then

                'End If
                frmMisc.MdiParent = Me
                'frmBloodChem.enbl = enbl
                ' frmBloodChem.IsSelected = IsSelected

                frmMisc.Islock = Islock
                frmMisc.myFormStatus = myFormStatus
                frmMisc.myResult = myResult
                frmMisc.requestdetailno = requestdetailno
                frmMisc.status = status 'Use to update status
                frmMisc.PatientNo = patientNO
                frmMisc.Labname = frm
                frmMisc.labid = labid
                frmMisc.itemcode = itemcode
                TreeviewControls()
                frmMisc.Show()
            ElseIf labid = 9 Or labid = 10 Then
                If myFormStatus = enFormStatus.add Then
                    frmRadiology.myResult = frmRadiology.enResult.manageresult
                Else
                    frmRadiology.myResult = frmRadiology.enResult.releaseresult
                End If
                frmRadiology.itemDescription = frm
                frmRadiology.soperation = soperation
                frmRadiology.controlProperties(controlProperties)
                frmRadiology.myFormStatus = myFormStatus
                frmRadiology.labID = labid
                frmRadiology.requestdetailno = requestdetailno
                frmRadiology.IsEdit = IsEdit
                frmRadiology.tsSave1.Text = Me.tsSave.Text
                'frmRadiology.status = status
                'frmRadiology.Islock = Islock
                If Me.tsSave.Visible = False Then
                    isCancel = True
                End If
                Me.ToolStrip1.Visible = False
                TreeviewControls()
                frmRadiology.MdiParent = Me
                frmRadiology.Show()
            Else
                Me.Hide()
                Me.Close()
            End If
            If status = 0 Then
                Me.tsPrint.Visible = True
            End If
        End If
    End Sub
    Private Sub frmMDIParent_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)


        If labid = 1 Then
            Me.Dispose()
            Me.Close()
            frmfecalysisi.Close()
        ElseIf labid = 2 Then
            Me.Close()
            Me.Dispose()
            frmurinalysiss.Close()
        ElseIf labid = 3 Then
            Me.Close()
            Me.Dispose()
            frmHematologyis.Close()
        ElseIf labid = 4 Then
            Me.Close()
            Me.Dispose()
            frmBloodChem.Close()
        ElseIf labid = 8 Then
            Me.Close()
            Me.Dispose()
            frmMisc.Close()

        ElseIf labid > 8 Then
            isSave = frmRadiology.isSave

        End If
    End Sub
    Public Sub tsclick(ByVal Panl As Panel, ByVal node As TreeNode)
        If Panl.Visible = False Then
            Panl.Visible = True
            node.BackColor = Color.Yellow
        Else
            node.BackColor = Color.Empty
            Panl.Visible = False
        End If
    End Sub
#Region "Toolstrip Buttons"
    Public Sub tsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSave.Click
        save()
        isSave = True
    End Sub
#Region "Enable Fields"
    Public Sub myEnableFields()
        'Me.tsCancel.Visible = False
        Me.tsPrint.Visible = False


        If myFormStatus = enFormStatus.add Then
            tsPrint.Visible = False
            ' Me.tsCancel.Visible = False
        ElseIf myFormStatus = enFormStatus.browsing Then
            ' Me.tsCancel.Visible = False
            Me.tsPrint.Visible = False
            Me.tsSave.Visible = False
        End If
        'tsPrintPDF.Visible = tsPrint.Visible
    End Sub
#End Region
    Public Sub tsClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsClose.Click  
        Me.Close()
    End Sub
    Public Sub tsPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPrint.Click
        print()
    End Sub
    Private Sub tsPrintPDF_Click(sender As System.Object, e As System.EventArgs)
        PrintPDF()
    End Sub
#End Region
#Region "Node Mouseclick"
    Private Sub tvControlsMain_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvControlsMain.NodeMouseClick

        'Fecalysis
        If frm = lab.Rows(0)(1).ToString() Then
            dtFecalysis = clsExamination.getLabdetails("1")

            If e.Node.Name = dtFecalysis.Rows(0)(2).ToString() Then
                tsclick(Me.frmfecalysisi.pnlColorfecalysis, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(1)(2).ToString() Then
                tsclick(Me.frmfecalysisi.pnlCons, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(2)(2).ToString() Then
                tsclick(Me.frmfecalysisi.pnlPcellsfecalysis, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(3)(2).ToString() Then
                tsclick(Me.frmfecalysisi.pnlRBCfecalysis, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(4)(2).ToString() Then
                tsclick(Me.frmfecalysisi.pnlFGlobfecalysis, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(5)(2).ToString() Then
                tsclick(Me.frmfecalysisi.pnlAsclum, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(6)(2).ToString() Then
                tsclick(Me.frmfecalysisi.pnlHworm, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(7)(2).ToString() Then
                tsclick(Me.frmfecalysisi.pnlTrichura, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(8)(2).ToString() Then
                tsclick(Me.frmfecalysisi.pnlCyst, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(9)(2).ToString() Then
                tsclick(Me.frmfecalysisi.pnlOthersfecalysis, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(10)(2).ToString() Then
                tsclick(Me.frmfecalysisi.pnlTrophozite, e.Node)

            End If

            'Urinalysis
        ElseIf frm = lab.Rows(1)(1).ToString() Then

            dtFecalysis = clsExamination.getLabdetails("2")

            If e.Node.Name = dtFecalysis.Rows(0)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlColor, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(1)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlAppearance, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(2)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlReactions, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(3)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlSpecGravity, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(4)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlAlbumin, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(5)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlSugar, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(6)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlKetone, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(7)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlChemOthers, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(8)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlPusCells, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(9)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlRBC, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(10)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlEpithCells, e.Node)

                '**
            ElseIf e.Node.Name = dtFecalysis.Rows(11)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlMucThread, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(12)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlAmorUrates, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(13)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlUricAcid, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(14)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlCalciumOxalate, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(15)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlTriplePhospate, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(16)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlCoarse, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(17)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlFine, e.Node)
                'Bacteria_Others
            ElseIf e.Node.Name = dtFecalysis.Rows(18)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlBacteriaOthers, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(19)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlYeast, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(20)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlCastOthers, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(21)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlPhysicalExam, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(22)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlChemExam, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(23)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlMicroExam, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(24)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlCastsUrinalysis, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(25)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlCrystals, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(26)(2).ToString() Then
                tsclick(Me.frmurinalysiss.pnlBacteria, e.Node)
            End If

        ElseIf frm = lab.Rows(2)(1).ToString() Then

            dtFecalysis = clsExamination.getLabdetails("3")

            'Panel Hemoglobin Property
            If e.Node.Name = dtFecalysis.Rows(0)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlHemoglobin, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(1)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlHematocrit, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(2)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlLeucocyteCount, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(3)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlSegmentedNeutophilis, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(4)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlStabs, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(5)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlLymphocytes, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(6)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlMonocytes, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(7)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlEosinophilis, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(8)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlBasophilis, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(9)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlBloodtype, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(10)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlPlateletCount, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(11)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlBleedingtime, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(12)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlClottingTime, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(13)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlESR, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(14)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlMalarialPara, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(15)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlRedCellCount, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(16)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlOthers, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(17)(2).ToString Then
                tsclick(Me.frmHematologyis.pnlDifferentialCount, e.Node)
            End If

        ElseIf frm = lab.Rows(3)(1).ToString() Then

            dtFecalysis = clsExamination.getLabdetails("4")

            ' For ctr = 0 To dtFecalysis.Rows.Count - 1
            If e.Node.Name = dtFecalysis.Rows(0)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlFBS, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(1)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlRBS, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(2)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlPPBS, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(3)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlSUA, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(4)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlCreatinine, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(5)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlALTSGPT, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(6)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlCholesterol, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(7)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlTriglyceride, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(8)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlHDL, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(9)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlElectrolytes, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(10)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlLDL, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(11)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlHBAlc, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(12)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlAmylase, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(13)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlTotallProtein, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(14)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlAlbuminBloodChem, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(15)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlGlobulin, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(16)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlLipase, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(17)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlAST, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(18)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlAP, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(19)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlBUN, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(20)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlSodium, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(21)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlPotassium, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(22)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlCalcium, e.Node)

            ElseIf e.Node.Name = dtFecalysis.Rows(23)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlBilirubin, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(24)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlDirectbilirubin, e.Node)
            ElseIf e.Node.Name = dtFecalysis.Rows(25)(2).ToString Then
                tsclick(Me.frmBloodChem.pnlIndirectBilrubin, e.Node)
            End If
            'Next


        End If
    End Sub
#End Region
    Private Sub frmMDIParent_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control = True And e.KeyCode = Keys.S Then
            If labid = 9 Or labid = 10 Then
                If isCancel = False Then
                    frmRadiology.saveNow()
                    isSave = True
                End If
            Else
                If Me.tsSave.Visible = True Then
                    save()
                    isSave = True
                End If
            End If
        ElseIf e.Control = True And e.KeyCode = Keys.P And myFormStatus <> enFormStatus.add And tsPrint.Visible = True Then
            If labid <> 9 Or labid <> 10 Then
                print()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
#End Region


    
End Class
