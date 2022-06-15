Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Configuration
Imports System.Management.Instrumentation
Imports System.Management
Imports SIMPLE_LIS.Utility
Imports System.Drawing.Imaging 
Public Class frmRadiology
    
#Region "Variables"
    Dim ImageStorage As String
    Public myFormStatus As enFormStatus
    Public myResult As enResult
    Dim dtResult As New DataTable
    Dim dtResultImages As New DataTable
    Dim dtResultemptyImages As New DataTable
    Dim dtChargeResult As New DataTable
    Dim dtChargeResultDetails As New DataTable
    Dim dtLabRadioLogyDefault As New DataTable
    Dim dtOfficeCode As New DataTable
    'Dim myExamType As enExamType 'Flag to identify examination type
    Dim getTransNo As DataTable
    Public patientNo As String  '--- change data type
    Public requestNo As Integer
    Public soperation As Integer
    Public labID As Integer  'new Update
    Public requestdetailno As Integer
    Public registrydetailno As Integer
    Public IsEdit As Boolean
    Public itemDescription As String
    Dim indicator As Integer
    Dim img As Image
    Public isSave As Boolean
    Enum enFormStatus
        browsing = 0            'edit fields disabled
        add = 1
        edit = 2
    End Enum
    Enum enResult
        manageresult = 0
        releaseresult = 1
    End Enum
    Dim Admission As New clsAdmission
#End Region
#Region "Events"
    Private Sub btnAddToList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToList.Click
        If Me.cmbItemCodeFilm.Text <> "" Then
            If Utility.IsAlpha(txtFilm.Text) = False And Utility.NullToEmptyString(txtFilm.Text) <> "" Then
                Me.DGVFilm.Rows.Add(1)
                Me.DGVFilm.Rows(DGVFilm.Rows.Count - 1).Cells(0).Value = Me.cmbItemCodeFilm.SelectedValue
                Me.DGVFilm.Rows(DGVFilm.Rows.Count - 1).Cells(1).Value = Me.cmbItemCodeFilm.Text
                Me.DGVFilm.Rows(DGVFilm.Rows.Count - 1).Cells(2).Value = Me.txtFilm.Text
            Else
                MsgBox("Numbers only.")
            End If
        Else
            MsgBox("Please Select Film First")
        End If
    End Sub
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If myFormStatus = enFormStatus.edit Then
            If Me.DGVFilm.Rows.Count > 0 And Me.DGVFilm.SelectedRows.Count > 0 Then
                'Dim myCharges As New clsCharges
                'dtOfficeCode = clsCharges.getInventoryOfficeCode(10, Me.DGVFilm.SelectedRows(0).Cells(0).Value)
                If MessageBox.Show("Are you sure you want to remove this film?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim okDelete As Boolean = False
                    okDelete = clsRadiology.removeChargeDetails(Me.DGVFilm.SelectedRows(0).Cells(4).Value)
                    If okDelete Then
                        ' moveDeletedImage(Me.DGVFilm.SelectedRows(0).Cells(5).Value, Me.DGVFilm.SelectedRows(0).Cells(3).Value, 0)
                        Me.DGVFilm.Rows.Remove(Me.DGVFilm.CurrentRow)
                        MsgBox("Successfully Deleted")
                        ' myCharges.callInventoryDump(dtOfficeCode.Rows(0).Item("officecode").ToString(), Utility.GetServerDate())
                    End If
                End If
            End If
        Else
            If Me.DGVFilm.Rows.Count > 0 Then
                ' moveDeletedImage(Me.DGVFilm.SelectedRows(0).Cells(5).Value, Me.DGVFilm.SelectedRows(0).Cells(3).Value, 0)
                Me.DGVFilm.Rows.Remove(Me.DGVFilm.CurrentRow)
            End If
        End If
       
    End Sub
    Private Sub DGVFilm_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGVFilm.CurrentCellDirtyStateChanged
        If Me.DGVFilm.IsCurrentCellDirty Then
            Me.DGVFilm.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Sub DGVFilm_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVFilm.CellContentClick
        Dim selectedRow As Integer = Me.DGVFilm.CurrentRow.Index
        For ctr = 0 To Me.DGVFilm.Rows.Count - 1
            If ctr <> selectedRow Then
                Me.DGVFilm.Rows(ctr).Cells(3).Value = CheckState.Unchecked
            End If
        Next
    End Sub

    Private Sub btnCleartxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCleartxt.Click
        Me.txtResult.Clear()
    End Sub
    Private Sub frmRadiology_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadRecord()
        Me.tsSave.Image = modGlobal.save_icon
        Me.tsClose.Image = modGlobal.close_icon
        Me.KeyPreview = True
    End Sub
    
    Private Sub CenterImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CenterImageToolStripMenuItem.Click
        resizeImg(PictureBoxSizeMode.CenterImage)
    End Sub
    Private Sub NormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormalToolStripMenuItem.Click
        resizeImg(PictureBoxSizeMode.Normal)
    End Sub
    Private Sub StretchImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StretchImageToolStripMenuItem.Click
        resizeImg(PictureBoxSizeMode.StretchImage)
    End Sub
    Private Sub AutoSizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSizeToolStripMenuItem.Click
        resizeImg(PictureBoxSizeMode.AutoSize)
    End Sub
    Private Sub ZoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomToolStripMenuItem.Click
        resizeImg(PictureBoxSizeMode.Zoom)
    End Sub
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvImageAddress.CurrentCellDirtyStateChanged
        If dgvImageAddress.IsCurrentCellDirty Then
            Me.dgvImageAddress.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvImageAddress.CellClick
        If myFormStatus = enFormStatus.add Then
            If Me.dgvImageAddress.Rows.Count > 0 Then
                Call readImageName(Me.dgvImageAddress.SelectedRows(0).Cells(1).Value)
            End If
        Else
            Dim selected As Integer = Me.dgvImageAddress.CurrentRow.Index
            For i = 0 To Me.dgvImageAddress.Rows.Count - 1
                If i <> selected Then
                    Me.dgvImageAddress.Rows(i).Cells(0).Value = CheckState.Unchecked
                End If
            Next
            If Me.dgvImageAddress.SelectedRows(0).Cells(5).Value = "" Then
                Call readImageName(Me.dgvImageAddress.SelectedRows(0).Cells(1).Value)
            Else
                Call readImageName(Me.dgvImageAddress.SelectedRows(0).Cells(5).Value)
            End If
        End If
    End Sub
    '#Region "Constructor"
    '    Sub New(ByVal FormStatus As enFormStatus, ByVal ExamType As enExamType)

    '        ' This call is required by the Windows Form Designer.
    '        InitializeComponent()

    '        ' Add any initialization after the InitializeComponent() call.
    '        myFormStatus = FormStatus
    '        myExamType = ExamType

    '        ' Form text display
    '        If myExamType = enExamType.EX_BLOODTYPE Then
    '            Me.Text = "Blood Type Laboratory Examination"
    '            Me.lblExamType.Text = "Blood Type:"
    '        Else
    '            Me.Text = "CBS/RBS Laboratory Examination"
    '            Me.lblExamType.Text = "CBS/RBS:"
    '        End If

    '        Call LoadTechnologists()
    '        Call LoadRadServices()
    '    End Sub
    '#End Region
#Region "ToolStrip Events"
    Private Sub tsSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsSave1.Click
        saveNow()
    End Sub
    Private Sub tsCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsCancel1.Click
        Me.Close()
    End Sub
    Private Sub tsClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsClose1.Click

        ParentForm.Close()

        Me.Close()
    End Sub
    'Protected Overrides Sub tsCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If MsgBox("You are going to " + tsCheck.Text.ToLower + " this selected Laboratory Result. Do you want to proceed?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Releasing Confirmation") = MsgBoxResult.Yes Then
    '        Call SaveAsReleased()
    '        myFormStatus = enFormStatus.browsing
    '        Call EnableFields(False)
    '        MsgBox("Laboratory Result successfully " + tsCheck.Text.ToLower + "d!", MsgBoxStyle.OkOnly, "Successful")
    '    End If
    'End Sub

    'Protected Overrides Sub tsPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'Try
    '    '    Dim fReport As New frmReportHandler 
    '    '    fReport.varno = requestdetailno
    '    '    fReport.printType = "Radiology"
    '    '    fReport.ShowDialog()
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    'End Try
    'End Sub
#End Region
    '#Region "Methods"
    '    Public Sub EnableFields(ByVal sw As Boolean)
    '        If myFormStatus = enFormStatus.browsing Then
    '            tsSave.Visible = Not sw
    '            tsCancel.Visible = Not sw
    '            tsCheck.Visible = Not sw
    '            Call EnableTextBox(Not sw)
    '        ElseIf myFormStatus = enFormStatus.add Then
    '            tsSave.Visible = sw
    '            tsCancel.Visible = Not sw
    '            tsCheck.Visible = Not sw
    '        ElseIf myFormStatus = enFormStatus.edit Then
    '            tsSave.Visible = sw
    '            tsSave.Text = "Update"
    '            tsCheck.Visible = sw
    '            tsCheck.Text = "Release"
    '            tsCancel.Visible = Not sw
    '        End If
    '    End Sub

    '    Public Sub EnableTextBox(ByVal accessible As Boolean)
    '        Me.txtBloodType.ReadOnly = Not accessible
    '        Me.txtSpecimen.ReadOnly = Not accessible
    '        Me.cmbMedTech.Enabled = accessible
    '        Me.cmbPathologist.Enabled = accessible
    '    End Sub

    '    Public Sub InitForm()
    '        Call LoadRecords()
    '        Call EnableFields(True)
    '    End Sub

    '    Public Sub LoadReferenceData(ByVal PatientNo As Integer, _
    '                                 ByVal RequestNo As Integer, _
    '                                 ByVal RequestDetailNo As Integer, _
    '                                 ByVal RegistryDetailNo As Integer)
    '        Me.patientNo = PatientNo
    '        Me.requestNo = RequestNo
    '        Me.requestdetailno = RequestDetailNo
    '        Me.registrydetailno = RegistryDetailNo
    '    End Sub

    '    Public Sub LoadRecords()
    '        Dim patInfo As New DataTable

    '        patInfo = clsLaboratoryExamination.getPatientInformation(patientNo)

    '        With patInfo
    '            Me.txtPatientNo.Text = .Rows(0).Item("patientno")
    '            Me.txtPatientName.Text = .Rows(0).Item("lastname") + ", " + .Rows(0).Item("firstname") + " " + .Rows(0).Item("middlename").ToString.First
    '            Me.txtAge.Text = .Rows(0).Item("age")
    '            Me.txtGender.Text = .Rows(0).Item("gender").ToString.First
    '        End With

    '        Me.txtRequestNo.Text = requestNo

    '        If myFormStatus = enFormStatus.add Then
    '        Else
    '            Dim examInfo As New DataTable

    '            examInfo = clsLaboratoryExamination.ShowLabResults(requestdetailno, "MISC")

    '            With examInfo
    '                'Check if the laboratory result is already released.
    '                If .Rows(0).Item("isreleased") = True Then
    '                    myFormStatus = enFormStatus.browsing
    '                    Call EnableFields(True)
    '                End If

    '                Me.txtExaminationNo.Text = .Rows(0).Item("labexaminationno")
    '                Me.cmbMedTech.SelectedValue = .Rows(0).Item("medtech")
    '                Me.cmbPathologist.SelectedValue = .Rows(0).Item("pathologist")
    '                If myExamType = enExamType.EX_BLOODTYPE Then
    '                    Me.txtBloodType.Text = .Rows(0).Item("bloodtype")
    '                Else
    '                    Me.txtBloodType.Text = .Rows(0).Item("cbsrbs")
    '                End If
    '                Me.txtSpecimen.Text = .Rows(0).Item("specimen")
    '            End With
    '        End If
    '    End Sub

    '    Public Sub LoadTechnologists()
    '        Me.cmbMedTech.DataSource = cls.getTechnologist(666)
    '        Me.cmbMedTech.DisplayMember = "technologist"
    '        Me.cmbMedTech.ValueMember = "employeeid"


    '    End Sub
    '    Public Sub LoadRadServices()
    '        Me.cmbMedTech.DataSource = clsLaboratoryExamination.getTechnologist(666)
    '        Me.cmbMedTech.DisplayMember = "technologist"
    '        Me.cmbMedTech.ValueMember = "employeeid"


    '    End Sub
    '    Public Sub SaveRecord()
    '        Dim otherExams As New clsLaboratoryExamination

    '        If myFormStatus = enFormStatus.add Then
    '            otherExams.registrydetailno = registrydetailno
    '            otherExams.patientrequestdetailno = requestdetailno
    '            otherExams.requestno = requestNo
    '            otherExams.encodedbyid = modGlobal.userid
    '            otherExams.dateencoded = Utility.GetServerDate()
    '            otherExams.submissiondate = Utility.GetServerDate()
    '            otherExams.medicaltechnologist = Me.cmbMedTech.SelectedValue
    '            otherExams.pathologist = Me.cmbPathologist.SelectedValue
    '            otherExams.specimen = Me.txtSpecimen.Text
    '            otherExams.labexaminationno = otherExams.Save(True)

    '            Me.txtExaminationNo.Text = otherExams.labexaminationno

    '            If myExamType = enExamType.EX_BLOODTYPE Then
    '                'Save BloodType Examination Entry
    '                otherExams.bloodtype = Me.txtBloodType.Text
    '                otherExams.SaveExamination(True, clsLaboratoryExamination.ExaminationType.EX_BLOODTYPE)
    '            Else
    '                'Save CBS/RBS Examination Entry
    '                otherExams.cbsrbs = Me.txtBloodType.Text
    '                otherExams.SaveExamination(True, clsLaboratoryExamination.ExaminationType.EX_CBSRBS)
    '            End If
    '        ElseIf myFormStatus = enFormStatus.edit Then
    '            'Update BloodType And CBS/RBS Examination Entry
    '            otherExams.medicaltechnologist = Me.cmbMedTech.SelectedValue
    '            otherExams.pathologist = Me.cmbPathologist.SelectedValue
    '            otherExams.labexaminationno = Me.txtExaminationNo.Text
    '            otherExams.specimen = Me.txtSpecimen.Text
    '            otherExams.patientrequestdetailno = requestdetailno
    '            otherExams.Save(False)
    '            If myExamType = enExamType.EX_BLOODTYPE Then
    '                otherExams.bloodtype = Me.txtBloodType.Text
    '                otherExams.SaveExamination(False, clsLaboratoryExamination.ExaminationType.EX_BLOODTYPE)
    '            Else
    '                otherExams.cbsrbs = Me.txtBloodType.Text
    '                otherExams.SaveExamination(False, clsLaboratoryExamination.ExaminationType.EX_CBSRBS)
    '            End If
    '        End If
    '    End Sub


    '#End Region

    '#Region "Form Events"
    '    Private Sub frmBloodExamination_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '        Call InitForm()
    '    End Sub
    '#End Region
    Private Sub txtStatus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    
    
    Private Sub Picture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Picture.Click
        If Me.dgvImageAddress.Rows.Count > 0 And Me.Picture.Image IsNot img Then
            'Dim pctre As New frmEnlargeImage()
            'pctre.pctreenlarge.Image = Me.Picture.Image
            'pctre.Text = Me.dgvImageAddress.SelectedRows(0).Cells(3).Value
            'pctre.ShowDialog()
            'Me.Picture.Image = img
            'Me.Picture.SizeMode = PictureBoxSizeMode.CenterImage
            Try
                System.Diagnostics.Process.Start(Me.dgvImageAddress.SelectedRows(0).Cells(1).Value)
            Catch ex As Exception
                System.Diagnostics.Process.Start(Me.dgvImageAddress.SelectedRows(0).Cells(5).Value)
            End Try
        End If
    End Sub


    Private Sub ToolStripButtonbrowswimage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonbrowswimage.Click
        Dim dlg As New OpenFileDialog()
        dlg.Filter = "Image Files|*.jpg;*.bmp;*.png;*.jpeg"
        Dim dlgRes As DialogResult = dlg.ShowDialog()
        If dlgRes <> DialogResult.Cancel Then

            Dim ok As Boolean = False
            Dim f As String = dlg.SafeFileName
            For i = 0 To Me.dgvImageAddress.Rows.Count - 1
                If Me.dgvImageAddress.Rows(i).Cells(1).Value = dlg.FileName Then
                    ok = True
                    i = Me.dgvImageAddress.Rows.Count - 1
                Else
                    ok = False
                End If
            Next
            '**********************
            If ok = False Then
                Me.dgvImageAddress.Rows.Add(1)
                Me.dgvImageAddress.Rows(Me.dgvImageAddress.Rows.Count - 1).Cells(1).Value = dlg.FileName
                Me.dgvImageAddress.Rows(Me.dgvImageAddress.Rows.Count - 1).Cells(3).Value = dlg.SafeFileName
                Try
                    Dim imageData As Byte() = ReadFile(dlg.FileName)
                    Dim newImage As Image
                    Using ms As New MemoryStream(imageData, 0, imageData.Length)
                        ms.Write(imageData, 0, imageData.Length)
                        newImage = Image.FromStream(ms, True)
                    End Using
                    Me.dgvImageAddress.Rows(Me.dgvImageAddress.Rows.Count - 1).Cells(2).Value = newImage
                    Me.Picture.Image = newImage
                    Me.dgvImageAddress.Rows(Me.dgvImageAddress.Rows.Count - 1).Selected = True
                    Me.dgvImageAddress.CurrentCell = Me.dgvImageAddress(0, Me.dgvImageAddress.Rows.Count - 1)
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                End Try
            Else
                MessageBox.Show("This image is selected already", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ok = False
        End If
    End Sub
    Private Sub ToolStripButtonMovethisimage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonMovethisimage.Click
        Dim ok As Boolean
        For i = 0 To Me.dgvImageAddress.Rows.Count - 1
            If Me.dgvImageAddress.Rows(i).Cells(0).Value = True Or Me.dgvImageAddress.Rows(i).Cells(0).Value = CheckState.Checked Then
                ok = True
                Exit For
            End If
        Next
        If ok Then
            If MessageBox.Show("Source image will be deleted.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim ctrindicator As Integer = 0
                If myFormStatus = enFormStatus.add Then
                    For i = 0 To Me.dgvImageAddress.Rows.Count - 1
                        If Me.dgvImageAddress.Rows(i).Cells(0).Value = True And Me.dgvImageAddress.Rows.Count > 0 Then
                            moveImage(Me.dgvImageAddress.Rows(i).Cells(1).Value, Me.dgvImageAddress.Rows(i).Cells(3).Value, i)
                            Me.dgvImageAddress.Rows(i).Cells(0).Value = CheckState.Unchecked
                            ctrindicator += 1
                        End If
                    Next
                    If Me.dgvImageAddress.Rows.Count > 0 And ctrindicator > 0 Then
                        MsgBox("Finished transferring")
                    End If
                Else
                    For i = 0 To Me.dgvImageAddress.Rows.Count - 1
                        If Me.dgvImageAddress.Rows(i).Cells(0).Value = True And Me.dgvImageAddress.Rows.Count > 0 Then
                            If Me.dgvImageAddress.Rows(i).Cells(5).Value = "" Then
                                moveImage(Me.dgvImageAddress.Rows(i).Cells(1).Value, Me.dgvImageAddress.Rows(i).Cells(3).Value, i)
                                ctrindicator += 1
                            Else
                                moveImage(Me.dgvImageAddress.Rows(i).Cells(5).Value, Me.dgvImageAddress.Rows(i).Cells(3).Value, i)

                                ctrindicator += 1
                            End If
                        End If
                    Next
                    If Me.dgvImageAddress.Rows.Count > 0 And ctrindicator > 0 Then
                        MsgBox("Finished transferring")
                    End If
                End If

            End If

        Else
            MsgBox("No image/s to be transferred")
        End If
    End Sub
    Private Sub ToolStripButtonremovethisimage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonremovethisimage.Click
        Dim hasCheck As Boolean = False
        For i = 0 To Me.dgvImageAddress.Rows.Count - 1
            If Me.dgvImageAddress.Rows(i).Cells(0).Value = True Or Me.dgvImageAddress.Rows(i).Cells(0).Value = CheckState.Checked Then
                hasCheck = True
            End If
        Next
        If hasCheck Then
            If MessageBox.Show("Are you sure you want to remove this image?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim ok As Boolean = False
                Dim rowIndicator = Me.dgvImageAddress.Rows.Count - 1
                For ctr = 0 To rowIndicator
                    If Me.dgvImageAddress(0, ctr).Value = True Then
                        If Me.dgvImageAddress.Rows(ctr).Cells(7).Value <> "" Then
                            Dim okToDelete As Boolean = clsRadiology.removeImages(Me.dgvImageAddress.Rows(ctr).Cells(7).Value)
                            If okToDelete Then
                                moveDeletedImage(Me.dgvImageAddress.Rows(ctr).Cells(5).Value, Me.dgvImageAddress.Rows(ctr).Cells(3).Value, 0)
                            End If
                        Else
                            If Me.dgvImageAddress.Rows(ctr).Cells(5).Value <> "" Then
                                moveDeletedImage(Me.dgvImageAddress.Rows(ctr).Cells(5).Value, Me.dgvImageAddress.Rows(ctr).Cells(3).Value, 0)
                            End If
                            Me.dgvImageAddress.Rows.RemoveAt(ctr)
                            Me.Picture.Image = img
                            Exit For
                        End If

                        Me.dgvImageAddress.Rows.RemoveAt(ctr)
                        ctr += 1
                        Me.Picture.Image = Nothing
                        ok = True
                    End If
                Next
                If ok Then
                    MsgBox("Image/s successfully remove")
                End If
            End If
        Else
            MsgBox("Please select an image to remove")
        End If
    End Sub
    Private Sub ToolStripButtonchangepicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonchangepicture.Click
        If Me.dgvImageAddress.Rows.Count > 0 Then
            If Me.dgvImageAddress.Rows(Me.dgvImageAddress.CurrentRow.Index).Cells(0).Value = True Then
                If MessageBox.Show("If you want to change this picture it will automatically replace the original picture", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim dlg As New OpenFileDialog()
                    dlg.Filter = "Image Files|*.jpg;*.gif;*.bmp;*.png;*.jpeg;*.MVL"
                    Dim dlgRes As DialogResult = dlg.ShowDialog()
                    If dlgRes <> DialogResult.Cancel Then
                        Dim ok As Boolean = False
                        Dim f As String = dlg.SafeFileName
                        For i = 0 To Me.dgvImageAddress.Rows.Count - 1
                            If Me.dgvImageAddress.Rows(i).Cells(1).Value = dlg.FileName Then
                                ok = True
                                i = Me.dgvImageAddress.Rows.Count - 1
                            Else
                                ok = False
                            End If
                        Next
                        '**********************
                        If ok = False Then
                            moveDeletedImage(Me.dgvImageAddress.SelectedRows(0).Cells(5).Value, Me.dgvImageAddress.SelectedRows(0).Cells(3).Value, 0)
                            Me.dgvImageAddress.SelectedRows(0).Cells(1).Value = dlg.FileName
                            Me.dgvImageAddress.SelectedRows(0).Cells(3).Value = dlg.SafeFileName
                            moveImage(dlg.FileName, dlg.SafeFileName, Me.dgvImageAddress.CurrentRow.Index)
                            Try
                                Dim imageData As Byte() = ReadFile(ImageStorage & "\UltrasoundImages\Templates\" + dlg.SafeFileName)
                                Dim newImage As Image
                                Using ms As New MemoryStream(imageData, 0, imageData.Length)
                                    ms.Write(imageData, 0, imageData.Length)
                                    newImage = Image.FromStream(ms, True)
                                End Using
                                Me.dgvImageAddress.SelectedRows(0).Cells(2).Value = newImage
                                Me.Picture.Image = newImage
                                Me.dgvImageAddress.Rows(Me.dgvImageAddress.CurrentRow.Index).Selected = True
                                Me.dgvImageAddress.CurrentCell = Me.dgvImageAddress(0, Me.dgvImageAddress.CurrentRow.Index)
                            Catch ex As Exception
                                MessageBox.Show(ex.ToString())
                            End Try
                        Else
                            MessageBox.Show("This image is selected already", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                        ok = False
                    End If
                Else
                End If
            End If
        Else
            MsgBox("No image to be change")
        End If

    End Sub

#End Region
#Region "Constructor"
    'Sub New(ByVal FormStatus As enFormStatus)
    '    ' This call is required by the Windows Form Designer.
    '    InitializeComponent()
    '    ' Add any initialization after the InitializeComponent() call.
    '    myFormStatus = FormStatus
    'End Sub
#End Region
#Region "Methods"
    Public Sub saveNow()
        If MsgBox("Are you sure you want to " + tsSave1.Text.ToLower + " this laboratory result?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, modGlobal.msgboxTitle) = MsgBoxResult.Yes Then
            If Me.cmbRadiologist.Text <> "" Then
                isSave = True
                Call SaveRecord()
                Call checkAllImageMoveToServer()
                MsgBox("Laboratory result successfully " + tsSave1.Text.ToLower() + "d.", MsgBoxStyle.OkOnly, modGlobal.msgboxTitle)
                IsEdit = False
                myFormStatus = enFormStatus.browsing
                Call EnableFields(False)
            Else
                MsgBox("Please select radiologist", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, modGlobal.msgboxTitle)
            End If

        End If
    End Sub
    Public Sub controlProperties(ByVal accessible As Boolean)
        For i = 0 To Controls.Count - 1
            If TypeOf Controls(i) Is ToolStrip = False Then
                If myFormStatus = enFormStatus.browsing Then
                    tsClose1.Visible = True
                    If TypeOf Controls(i) Is TabControl = False Then
                        Controls(i).Enabled = accessible
                    End If
                    Me.txtResult.Enabled = accessible
                    Me.ToolStrip2.Enabled = accessible
                    Me.dgvImageAddress.Enabled = accessible
                    Me.Picture.Enabled = accessible
                    Me.DGVFilm.Enabled = accessible
                    Me.btnAddToList.Enabled = accessible
                    Me.btnRemove.Enabled = accessible
                    Me.txtFilm.Enabled = accessible
                    Me.cmbItemCodeFilm.Enabled = accessible
                Else
                    Controls(i).Enabled = accessible
                End If
            End If
        Next
    End Sub
    Public Sub checkAllImageMoveToServer()
        For i = 0 To Me.dgvImageAddress.Rows.Count - 1
            If Me.dgvImageAddress.Rows(i).Cells(5).Value = "" Then
                moveImage(Me.dgvImageAddress.Rows(i).Cells(1).Value, Me.dgvImageAddress.Rows(i).Cells(3).Value, i)
            End If
        Next
    End Sub
    Public Sub moveImage(ByVal sourcePath As String, ByVal imageName As String, ByVal rowcount As Integer)
        If Directory.Exists(ImageStorage & "\UltrasoundImages\Templates") = False Then
            Directory.CreateDirectory(ImageStorage & "\UltrasoundImages")
            Directory.CreateDirectory(ImageStorage & "\UltrasoundImages\Templates")
            Dim managementClass As New ManagementClass("Win32_Share")
            Dim inParams As ManagementBaseObject = managementClass.GetMethodParameters("Create")
            inParams.Item("Description") = "My Files Share"
            inParams.Item("Name") = "My Files Share"
            inParams.Item("Path") = ImageStorage & "\UltrasoundImages"
            inParams.Item("Type") = 0
            Dim diMyDir As New DirectoryInfo(ImageStorage & "\UltrasoundImages")
            diMyDir.Attributes = FileAttributes.Hidden
            Dim diMyDir1 As New DirectoryInfo(ImageStorage & "\UltrasoundImages\Templates")
            diMyDir1.Attributes = FileAttributes.Hidden
        End If
        If System.IO.File.Exists(sourcePath) = True Then

            If myFormStatus = enFormStatus.add Then

                If System.IO.File.Exists(ImageStorage & "\UltrasoundImages\Templates\" + imageName) = False Then
                    System.IO.File.Copy(sourcePath, ImageStorage & "\UltrasoundImages\Templates\" + imageName)
                    Me.dgvImageAddress.Rows(rowcount).Cells(5).Value = ImageStorage & "\UltrasoundImages\Templates\" + imageName
                Else
                    System.IO.File.Copy(sourcePath, ImageStorage & "\UltrasoundImages\Templates\" + "(img" & requestdetailno & ")" & imageName)
                    Me.dgvImageAddress.Rows(rowcount).Cells(5).Value = sourcePath
                End If

            Else
                If Me.dgvImageAddress.Rows(rowcount).Cells(7).Value <> "" Then
                    Dim oldImageName As String = ""
                    For ctr = 0 To dtResultImages.Rows.Count - 1
                        If dtResultImages.Rows(ctr)(0).ToString() = Me.dgvImageAddress.Rows(rowcount).Cells(7).Value Then
                            oldImageName = dtResultImages.Rows(ctr)(2).ToString()
                            Exit For
                        End If
                    Next

                    If checkIfImageExist(Me.dgvImageAddress.Rows(rowcount).Cells(3).Value) = True And oldImageName = Me.dgvImageAddress.Rows(rowcount).Cells(3).Value Then
                        System.IO.File.Copy(sourcePath, ImageStorage & "\UltrasoundImages\Templates\" + imageName)
                        Me.dgvImageAddress.Rows(rowcount).Cells(5).Value = ImageStorage & "\UltrasoundImages\Templates\" + imageName
                    ElseIf checkIfImageExist(Me.dgvImageAddress.Rows(rowcount).Cells(3).Value) = True And oldImageName <> Me.dgvImageAddress.Rows(rowcount).Cells(3).Value Then
                        System.IO.File.Copy(sourcePath, ImageStorage & "\UltrasoundImages\Templates\" + "(img" & requestdetailno & ")" & imageName)
                        Me.dgvImageAddress.Rows(rowcount).Cells(5).Value = sourcePath
                    ElseIf checkIfImageExist(Me.dgvImageAddress.Rows(rowcount).Cells(3).Value) = False And oldImageName = Me.dgvImageAddress.Rows(rowcount).Cells(3).Value Then
                        System.IO.File.Copy(sourcePath, ImageStorage & "\UltrasoundImages\Templates\" + "(img" & requestdetailno & ")" & imageName)
                        Me.dgvImageAddress.Rows(rowcount).Cells(5).Value = sourcePath
                    ElseIf checkIfImageExist(Me.dgvImageAddress.Rows(rowcount).Cells(3).Value) = False And oldImageName <> Me.dgvImageAddress.Rows(rowcount).Cells(3).Value Then
                        System.IO.File.Copy(sourcePath, ImageStorage & "\UltrasoundImages\Templates\" + imageName)
                        Me.dgvImageAddress.Rows(rowcount).Cells(5).Value = ImageStorage & "\UltrasoundImages\Templates\" + imageName
                    End If

                Else
                    If System.IO.File.Exists(ImageStorage & "\UltrasoundImages\Templates\" + imageName) = False Then
                        System.IO.File.Copy(sourcePath, ImageStorage & "\UltrasoundImages\Templates\" + imageName)
                        Me.dgvImageAddress.Rows(rowcount).Cells(5).Value = ImageStorage & "\UltrasoundImages\Templates\" + imageName
                    Else
                        System.IO.File.Copy(sourcePath, ImageStorage & "\UltrasoundImages\Templates\" + "(img" & requestdetailno & ")" & imageName)
                        Me.dgvImageAddress.Rows(rowcount).Cells(5).Value = sourcePath
                    End If
                End If
            End If



        End If
    End Sub
    Public Function checkIfImageExist(ByVal imageName As String)
        Dim isExist As Boolean = False
        If Directory.Exists(ImageStorage & "\UltrasoundImages\Templates") = False Then
            isExist = False
        Else
            If System.IO.File.Exists(ImageStorage & "\UltrasoundImages\Templates\" + imageName) = False Then
                isExist = False
            Else
                isExist = True
            End If
        End If
        Return isExist
    End Function
    Public Sub moveDeletedImage(ByVal sourcePath As String, ByVal imageName As String, ByVal rowcount As Integer)
        If Directory.Exists(ImageStorage & "\UltrasoundImages\Deleted") = False Then
            Directory.CreateDirectory(ImageStorage & "\UltrasoundImages\Deleted")
            Dim diMyDir As New DirectoryInfo(ImageStorage & "\UltrasoundImages\Deleted")
            diMyDir.Attributes = FileAttributes.Hidden
        End If
        If System.IO.File.Exists(sourcePath) = True Then
            If System.IO.File.Exists(ImageStorage & "\UltrasoundImages\Deleted\" + imageName) = False Then
                System.IO.File.Copy(sourcePath, ImageStorage & "\UltrasoundImages\Deleted\" + imageName)
            Else
                System.IO.File.Copy(sourcePath, ImageStorage & "\UltrasoundImages\Deleted\" + imageName & "(Copy)")
            End If
        Else
        End If
    End Sub
    Public Sub EnableFields(ByVal sw As Boolean)
        If myFormStatus = enFormStatus.browsing Then
            If IsEdit = True Then
                Me.tsSave1.Text = "Release"
                tsSave1.Visible = True
            Else
                tsSave1.Visible = sw
            End If
            tsCancel1.Visible = sw
        ElseIf myFormStatus = enFormStatus.add Then
            tsSave1.Visible = sw
            tsCancel1.Visible = Not sw
        ElseIf myFormStatus = enFormStatus.edit Then
            tsSave1.Visible = sw
            If soperation = 2 Then
                Me.tsSave1.Text = "Void/Cancel"
            Else
                Me.tsSave1.Text = "Update"
            End If
        End If
        Call EnableTextBox(sw)
    End Sub
    Private Sub resizeImg(ByVal sender As String)
        If Me.Picture.Image IsNot img Then
            Me.Picture.SizeMode = sender
        End If
    End Sub
    Private Function ReadFile(ByVal sPath As String) As Byte()
        Dim data As Byte() = Nothing
        Dim fInfo As New FileInfo(sPath)
        Dim numBytes As Long = fInfo.Length
        Dim fStream As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fStream)
        data = br.ReadBytes(CInt(numBytes))
        Return data
    End Function
    Public Sub EnableTextBox(ByVal accessible As Boolean)
        If soperation = 2 Then
            accessible = False
        End If
        Me.txtResult.Enabled = accessible
        Me.txtRemarks.Enabled = accessible
        Me.cmbRadiologist.Enabled = accessible
        Me.txtFilm.Enabled = accessible
        Me.cmbItemCodeFilm.Enabled = accessible
        Me.txtSpoil.Enabled = accessible
        tsSave.Enabled = accessible
        Me.Picture.Enabled = accessible
        Me.ToolStrip2.Enabled = accessible
        Me.dgvImageAddress.Enabled = accessible
        Me.btnAddToList.Enabled = accessible
        Me.btnRemove.Enabled = accessible
        Me.DGVFilm.Enabled = accessible
        Me.cmbItemCodeFilm.Enabled = accessible
        Me.txtFilm.Enabled = accessible
        Me.btnCleartxt.Enabled = accessible
    End Sub
    Private Sub LoadRecord()
        Try
            ImageStorage = ConfigurationSettings.AppSettings("Image Storage")
            Me.DGVFilm.Columns(0).Visible = False
            Me.DGVFilm.Columns(4).Visible = False
            If myFormStatus = enFormStatus.browsing Then
                Me.tsPrint1.Visible = True
            Else
                Me.tsPrint1.Visible = False
            End If
            Me.tsCancel1.Visible = False
            Call LoadRadiologist()
            Call LoadFilms()
            If labID = 10 Then
                Me.Text = "Radiology"
            Else
                Me.Text = "Ultrasound"
            End If
            dtResult = clsRadiology.getRadiologyResultDetails(requestdetailno, myResult)
            If dtResult.Rows.Count > 0 Then
                If dtResult.Rows(0).Item("gender").ToString = "M" Then
                    Me.txtGender.Text = "Male"
                Else
                    Me.txtGender.Text = "Female"
                End If
                Admission.AdmissionID = dtResult.Rows(0).Item("admissionid").ToString
                Admission.patientname = dtResult.Rows(0).Item("patient").ToString

                Me.txtPatientName.Text = dtResult.Rows(0).Item("patient").ToString
                If dtResult.Rows(0).Item("age").ToString = "1" Or dtResult.Rows(0).Item("age").ToString = "0" Then
                    Me.txtAge.Text = dtResult.Rows(0).Item("age").ToString & "  yr. old"
                Else
                    Me.txtAge.Text = dtResult.Rows(0).Item("age").ToString & "  yrs. old"
                End If
                If myResult = enResult.manageresult Then
                    Me.txtRequestNo.Text = dtResult.Rows(0).Item("patientrequestno").ToString
                Else
                    Me.txtRequestNo.Text = dtResult.Rows(0).Item("patientrequestno").ToString
                End If
                Me.txtStatus.Text = dtResult.Rows(0).Item("requisitionstatus").ToString
                If dtResult.Rows(0).Item("documentno").ToString = "" Then
                    Me.txtCaseNo.Text = Nothing
                Else
                    Me.txtCaseNo.Text = formatHospitalNumber(dtResult.Rows(0).Item("documentno").ToString)
                End If
                ' Me.txtCaseNo.Text = dtResult.Rows(0).Item("documentno").ToString
                Me.txtFilm.Text = dtResult.Rows(0).Item("filmcount").ToString
                Me.txtExamination.Text = dtResult.Rows(0).Item("itemspecs").ToString
                Me.txtResult.Text = dtResult.Rows(0).Item("resultdescription").ToString
                Me.txtRemarks.Text = dtResult.Rows(0).Item("remarks").ToString
                Me.lblFilm.Text = dtResult.Rows(0).Item("film").ToString
                ' Me.cmbItemCodeFilm.SelectedValue = dtResult.Rows(0).Item("itemcodefilm")
                'Me.lblFilm.Text = dtResult.Rows(0).Item("itemcodefilm")
                Me.txtLabExamNo.Text = dtResult.Rows(0).Item("labexaminationno").ToString
                Me.txtRequestedBy.Text = dtResult.Rows(0).Item("requestedby").ToString
                If dtResult.Rows(0).Item("Designation").ToString() <> "" Then
                    Me.lblDesignation.Text = dtResult.Rows(0).Item("Designation").ToString()
                Else
                    Me.lblDesignation.Text = "Radiologist"
                End If
                Me.txtSpoil.Text = dtResult.Rows(0).Item("filmspoil").ToString()
            End If
            If myFormStatus = enFormStatus.edit Or myFormStatus = enFormStatus.browsing Then
                Dim t As String = dtResult.Rows(0).Item("admissionid").ToString()

                Me.cmbRadiologist.SelectedValue = dtResult.Rows(0).Item("radiologistid")
                dtResultImages = clsRadiology.getRadiologyResultDetailsImages(requestdetailno, 4)
                dtResultemptyImages = clsRadiology.getRadiologyResultDetailsImages(requestdetailno, 7)
                dtChargeResultDetails = clsCharges.getResultCharges(8, "", requestdetailno)
                dtChargeResult = clsCharges.getResultCharges(7, dtChargeResultDetails.Rows(0).Item("chargeid").ToString(), requestdetailno) 'dtChargeResultDetails.Rows(0).Item("chargeid").ToString()
                If dtResultImages.Rows.Count > 0 Then
                    Me.dgvImageAddress.Columns(1).Visible = False
                    For i = 0 To dtResultImages.Rows.Count - 1
                        Me.dgvImageAddress.Rows.Add(1)
                        Try
                            Dim imageData As Byte() = ReadFile(ImageStorage & "\UltrasoundImages\Templates\" + dtResultImages.Rows(i)(2).ToString())
                            Dim newImage As Image
                            Using ms As New MemoryStream(imageData, 0, imageData.Length)
                                ms.Write(imageData, 0, imageData.Length)
                                newImage = Image.FromStream(ms, True)
                            End Using
                            Me.dgvImageAddress.Rows(i).Cells(2).Value = newImage
                        Catch ex As Exception
                            MessageBox.Show(ex.ToString())
                        End Try
                        Me.dgvImageAddress.Rows(i).Cells(3).Value = dtResultImages.Rows(i)(2).ToString()
                        Me.dgvImageAddress.Rows(i).Cells(4).Value = dtResultImages.Rows(i)(3).ToString()
                        Me.dgvImageAddress.Rows(i).Cells(5).Value = ImageStorage & "\UltrasoundImages\Templates\" + dtResultImages.Rows(i)(2).ToString()
                        Me.dgvImageAddress.Rows(i).Cells(7).Value = dtResultImages.Rows(i)(0).ToString()
                        Me.dgvImageAddress.Rows(i).Cells(8).Value = dtResultImages.Rows(i)(1).ToString()
                    Next
                End If
                For ctr = 0 To dtChargeResultDetails.Rows.Count - 1
                    If dtChargeResultDetails.Rows(ctr).Item("remarks").ToString() <> "X-RAY/Ultrasound DEFAULT Details" Then
                        Me.DGVFilm.Rows.Add(1)
                        Me.DGVFilm.Rows(ctr).Cells(4).Value = dtChargeResultDetails.Rows(ctr).Item("chargedetailsid").ToString()
                        Me.DGVFilm.Rows(ctr).Cells(0).Value = dtChargeResultDetails.Rows(ctr).Item("itemcode").ToString()
                        Dim FilName As DataTable = clsCharges.getItemCodeFilmName(dtChargeResultDetails.Rows(ctr).Item("itemcode").ToString())
                        Me.DGVFilm.Rows(ctr).Cells(1).Value = FilName.Rows(0).Item("itemdescription").ToString()
                        Me.DGVFilm.Rows(ctr).Cells(2).Value = dtChargeResultDetails.Rows(ctr).Item("quantity").ToString()
                        ' Me.DGVFilm.Rows(ctr).Cells(3).Value = dtChargeResultDetails.Rows(ctr).Item("unitcost").ToString()
                        If dtChargeResultDetails.Rows(ctr).Item("remarks").ToString() = "Film Used" Then
                            Me.DGVFilm.Rows(ctr).Cells(3).Value = CheckState.Checked
                        Else
                            Me.DGVFilm.Rows(ctr).Cells(3).Value = CheckState.Unchecked
                        End If
                    End If
                Next
            Else  'Updates here 6/13/2012 4:27 PM
                dtLabRadioLogyDefault = clsLabRadiology.getLabRadiologyResult(itemDescription)
                If dtLabRadioLogyDefault.Rows.Count > 0 Then
                    Me.txtResult.Text = dtLabRadioLogyDefault.Rows(0).Item("normalresultdesc") '.ToString()
                    Me.cmbItemCodeFilm.SelectedValue = dtLabRadioLogyDefault.Rows(0).Item("itemcodefilm") '.ToString()
                    Me.txtFilm.Text = dtLabRadioLogyDefault.Rows(0).Item("qtyfilm").ToString()
                    Me.DGVFilm.Rows.Add(1)
                    Me.DGVFilm.Rows(DGVFilm.Rows.Count - 1).Cells(0).Value = dtLabRadioLogyDefault.Rows(0).Item("itemcodefilm") '.ToString()
                    Me.DGVFilm.Rows(DGVFilm.Rows.Count - 1).Cells(1).Value = dtLabRadioLogyDefault.Rows(0).Item("id")
                    Me.DGVFilm.Rows(DGVFilm.Rows.Count - 1).Cells(2).Value = Me.txtFilm.Text
                    Me.DGVFilm.Rows(DGVFilm.Rows.Count - 1).Cells(3).Value = CheckState.Checked
                End If
            End If
            EnableFields(myFormStatus)
        Catch ex As Exception
        End Try
        indicator += 1
        img = Me.Picture.Image
    End Sub
    Private Sub readImageName(ByVal dgv As String)
        Try
            Dim imageData As Byte() = ReadFile(dgv)
            Dim newImage As Image
            Using ms As New MemoryStream(imageData, 0, imageData.Length)
                ms.Write(imageData, 0, imageData.Length)
                newImage = Image.FromStream(ms, True)
            End Using
            Me.Picture.Image = newImage
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub LoadRadiologist()
        Try
            Me.cmbRadiologist.DataSource = clsRadiology.getRadiologist(999)
            Me.cmbRadiologist.DisplayMember = "radiologist"
            Me.cmbRadiologist.ValueMember = "employeeid"
            Me.cmbRadiologist.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadFilms()
        Me.cmbItemCodeFilm.DataSource = clsLabRadiology.getItemCodeFilm()
        Me.cmbItemCodeFilm.DisplayMember = "ItemDescription"
        Me.cmbItemCodeFilm.ValueMember = "ItemCode"
    End Sub
    Private Sub paintForm(ByVal sender As Object, ByVal e As PaintEventArgs) Handles TabPage2.Paint, TabPage1.Paint
        Dim mGraphics As Graphics = e.Graphics
        Dim pen1 As Pen = New Pen(Color.FromArgb(252, 254, 255), 1)
        Dim Area1 As Rectangle = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1) '253, 254, 255
        Dim LGB As LinearGradientBrush = New LinearGradientBrush(Area1, Color.FromArgb(252, 254, 255), Color.FromArgb(227, 237, 253), LinearGradientMode.Vertical)
        mGraphics.FillRectangle(LGB, Area1)
        mGraphics.DrawRectangle(pen1, Area1)
    End Sub
    Private Sub SaveRecord()
        Dim myRadiology As New clsRadiology
        Dim myLaboratoryResult As New clsLaboratoryResult
        Dim myCharges As New clsCharges
        Dim myAdmissionChargeNo As Long
        '******************** save labresult
        With myLaboratoryResult

            .laboratoryid = labID  'Update 10 before
            .itemcatcode = Convert.ToString(Me.cmbItemCodeFilm.SelectedValue)
            If dtResult.Rows.Count = 0 Then
                .admissionid = 1
                .patientrequestno = 1
                .labno = "1"
            Else
                .admissionid = dtResult.Rows(0).Item("admissionid").ToString()
                .patientrequestno = requestdetailno ' dtResult.Rows(0).Item("patientrequestdetailno").ToString
                .labno = EmptyToZero(dtResult.Rows(0).Item("labexaminationno").ToString)
            End If
            .specimen = Me.txtExamination.Text
            .datesubmitted = GetServerDate()
            .dateencoded = GetServerDate()
            .encodedby = userid
            '.pathologist = 1
            .medtech = 1
            .medicaltechnologist = 1
            .releasedby = 1
            .datereleased = GetServerDate() '"01/01/1990"
            .pathologist = Me.cmbRadiologist.SelectedValue
            If myFormStatus = enFormStatus.add Then
                .Save(True)
                Call SaveLog("Radiology", "New laboratory result:" & .patientrequestno, userid)
            Else
                Dim LabID As DataTable = clsRadiology.getRadiologyResultDetails(requestdetailno, 5)
                .Oldlaboratoryid = Convert.ToInt32(LabID.Rows(0)(0).ToString())
                .Save(False)
                Call SaveLog("Radiology", "Update laboratory result:" & .patientrequestno, userid)
            End If
        End With


        '************************ save radiology
        myRadiology.labexaminationno = myLaboratoryResult.labno
        myRadiology.resultdescription = Me.txtResult.Text
        If myLaboratoryResult.patientrequestno = 0 Then
            myRadiology.patientrequestdetailno = 1 ' Temporary
        Else
            myRadiology.patientrequestdetailno = myLaboratoryResult.patientrequestno
        End If
        myRadiology.admissionid = myLaboratoryResult.admissionid
        For ctr = 0 To Me.DGVFilm.Rows.Count - 1
            If Me.DGVFilm.Rows(ctr).Cells(3).Value = CheckState.Checked Or Me.DGVFilm.Rows(ctr).Cells(3).Value = True Then
                If dtResult.Rows.Count = 0 Then
                    myRadiology.itemcode = "0"
                Else
                    myRadiology.itemcode = Me.DGVFilm.Rows(ctr).Cells(0).Value 'Me.cmbItemCodeFilm.SelectedValue 'dtResult.Rows(0).Item("itemcode").ToString
                End If
                myRadiology.filmcount = Me.DGVFilm.Rows(ctr).Cells(2).Value
                myRadiology.ItemCodeFilm = Me.DGVFilm.Rows(ctr).Cells(0).Value 'Me.cmbItemCodeFilm.SelectedValue
            Else
                myRadiology.filmspoil = Convert.ToInt32(Me.DGVFilm.Rows(ctr).Cells(2).Value) + Convert.ToInt32(myRadiology.filmspoil)
            End If
        Next
        myRadiology.remarks = Me.txtRemarks.Text
        If myFormStatus = enFormStatus.add Then
            myRadiology.Oldlabradiologyid = Nothing
            myRadiology.soperation = soperation
            myRadiology.Save(True)
        Else
            If dtResultImages.Rows.Count > 0 Then
                myRadiology.Oldlabradiologyid = dtResultImages.Rows(0).Item("labradiologyid").ToString()
            Else
                myRadiology.Oldlabradiologyid = dtResultemptyImages.Rows(0).Item("labradiologyid").ToString()
            End If
            myRadiology.soperation = soperation
            myRadiology.Save(False)

        End If
        '******************* save charges
        With myCharges
            myCharges.transtype = "XR"
            Dim officecode As DataTable = clsCharges.getOfficeCode(modGlobal.userid)
            myCharges.officecode = officecode.Rows(0).Item("officecode").ToString()
            getTransNo = clsCharges.getTransNo(myCharges.officecode, myCharges.transtype) 'datatTable get transNO
            myCharges.transno = getTransNo.Rows(0).Item("documentno").ToString()
            myCharges.preparedbyid = userid
            myCharges.dateprepared = GetServerDate()
            myCharges.dateapproved = GetServerDate() '"1/1/1900 0:00:00 PM"
            myCharges.remarks = "X-RAY/Ultrasound"

            myCharges.patientno = dtResult.Rows(0).Item("patientid").ToString() ' get patient id
            myCharges.patientname = dtResult.Rows(0).Item("patient").ToString
            myCharges.registryno = myLaboratoryResult.admissionid ' or admission id
            If myFormStatus = enFormStatus.add Then
                myAdmissionChargeNo = myCharges.Save(True)
            Else
                If dtChargeResult.Rows.Count > 0 Then
                    If IsDBNull(dtChargeResult.Rows(0).Item("chargeid")) Then
                        myAdmissionChargeNo = myCharges.Save(True)
                    Else
                        If dtChargeResult.Rows(0).Item("chargeid").ToString() = "" Then
                            myAdmissionChargeNo = myCharges.Save(True)
                        Else
                            myCharges.admissionchargeno = Convert.ToInt32(dtChargeResult.Rows(0).Item("chargeid").ToString())
                            myAdmissionChargeNo = myCharges.SaveUpdate(False)
                        End If
                    End If
                Else
                    myAdmissionChargeNo = myCharges.Save(True)
                End If
            End If
        End With

        '******************** save charge details
        If Me.DGVFilm.Rows.Count = 0 Then
            myCharges.DeleteAllChargeDetailsForXray(requestdetailno)
            myCharges.itemcode = "0" 'myLaboratoryResult.itemcatcode
            myCharges.lotno = "0"
            myCharges.expirydate = GetServerDate() '"1/1/1900 0:00:00 PM"
            myCharges.quantity = 0
            'myCharges.unitcost = Me.DGVFilm.Rows(ctr).Cells(3).Value
            'If Me.DGVFilm.Rows(ctr).Cells(3).Value = CheckState.Checked Or Me.DGVFilm.Rows(ctr).Cells(3).Value = True Then

            'Else
            myCharges.remarks = "X-RAY/Ultrasound DEFAULT Details"
            'End If
            myCharges.refadmissionchargeno = requestdetailno
            If myFormStatus = enFormStatus.add Then
                myCharges.admissionchargeno = myAdmissionChargeNo
            Else
                myCharges.admissionchargeno = myCharges.admissionchargeno 'myAdmissionChargeNo
            End If

            myCharges.SaveDetails(True)
        Else
            myCharges.DeleteAllChargeDetailsForXray(requestdetailno)
            For ctr = 0 To Me.DGVFilm.Rows.Count - 1
                myCharges.itemcode = Me.DGVFilm.Rows(ctr).Cells(0).Value 'myLaboratoryResult.itemcatcode
                myCharges.lotno = Me.DGVFilm.Rows(ctr).Cells(0).Value
                myCharges.expirydate = GetServerDate() '"1/1/1900 0:00:00 PM"
                myCharges.quantity = Me.DGVFilm.Rows(ctr).Cells(2).Value
                If Me.DGVFilm.Rows(ctr).Cells(3).Value = CheckState.Checked Or Me.DGVFilm.Rows(ctr).Cells(3).Value = True Then
                    myCharges.remarks = "Film Used"
                Else
                    myCharges.remarks = "Spoils"
                End If
                myCharges.refadmissionchargeno = requestdetailno
                If myFormStatus = enFormStatus.add Then
                    myCharges.admissionchargeno = myAdmissionChargeNo
                    myCharges.SaveDetails(True)
                Else
                    myCharges.admissionchargeno = myCharges.admissionchargeno
                    If Me.DGVFilm.Rows(ctr).Cells(4).Value <> "" Then
                        myCharges.search = Convert.ToInt32(Me.DGVFilm.Rows(ctr).Cells(4).Value) 'dtChargeResultDetails.Rows(ctr).Item("chargedetailsid").ToString())
                        myCharges.SaveUpdateDetails(False)
                    Else
                        myCharges.SaveDetails(True)
                    End If
                End If
            Next
        End If
        '******************** save images
        For i = 0 To Me.dgvImageAddress.Rows.Count - 1

            If myFormStatus = enFormStatus.add Then
                If checkIfImageExist(Me.dgvImageAddress.Rows(i).Cells(3).Value) = False Then
                    myRadiology.image = Me.dgvImageAddress.Rows(i).Cells(3).Value
                Else
                    myRadiology.image = "(img" & requestdetailno & ")" & Me.dgvImageAddress.Rows(i).Cells(3).Value
                End If

                myRadiology.description = Me.dgvImageAddress.Rows(i).Cells(4).Value
                myRadiology.saveImage(True)
            Else
                myRadiology.Oldimageid = Me.dgvImageAddress.Rows(i).Cells(7).Value
                myRadiology.labradiologyid = Me.dgvImageAddress.Rows(i).Cells(8).Value




                myRadiology.description = Me.dgvImageAddress.Rows(i).Cells(4).Value
                If Me.dgvImageAddress.Rows(i).Cells(7).Value <> "" Then

                    Dim oldImageName As String = ""
                    For ctr = 0 To dtResultImages.Rows.Count - 1
                        If dtResultImages.Rows(ctr)(0).ToString() = Me.dgvImageAddress.Rows(i).Cells(7).Value Then
                            oldImageName = dtResultImages.Rows(ctr)(2).ToString()
                            Exit For
                        End If
                    Next

                    If checkIfImageExist(Me.dgvImageAddress.Rows(i).Cells(3).Value) = True And oldImageName = Me.dgvImageAddress.Rows(i).Cells(3).Value Then
                        myRadiology.image = Me.dgvImageAddress.Rows(i).Cells(3).Value
                    ElseIf checkIfImageExist(Me.dgvImageAddress.Rows(i).Cells(3).Value) = True And oldImageName <> Me.dgvImageAddress.Rows(i).Cells(3).Value Then
                        myRadiology.image = "(img" & requestdetailno & ")" & Me.dgvImageAddress.Rows(i).Cells(3).Value
                    ElseIf checkIfImageExist(Me.dgvImageAddress.Rows(i).Cells(3).Value) = False And oldImageName = Me.dgvImageAddress.Rows(i).Cells(3).Value Then
                        myRadiology.image = "(img" & requestdetailno & ")" & Me.dgvImageAddress.Rows(i).Cells(3).Value
                    ElseIf checkIfImageExist(Me.dgvImageAddress.Rows(i).Cells(3).Value) = False And oldImageName <> Me.dgvImageAddress.Rows(i).Cells(3).Value Then
                        myRadiology.image = Me.dgvImageAddress.Rows(i).Cells(3).Value
                    End If


                    myRadiology.saveImage(False)
                    oldImageName = ""
                Else


                    If checkIfImageExist(Me.dgvImageAddress.Rows(i).Cells(3).Value) = False Then
                        myRadiology.image = Me.dgvImageAddress.Rows(i).Cells(3).Value
                    Else
                        myRadiology.image = "(img" & requestdetailno & ")" & Me.dgvImageAddress.Rows(i).Cells(3).Value
                    End If


                    myRadiology.labradiologyid = myRadiology.Oldlabradiologyid
                    myRadiology.saveImage(True)
                End If
            End If
        Next
        isSave = True
        myRadiology = Nothing
        myLaboratoryResult = Nothing
    End Sub
    Private Sub validateNumber(ByVal sender As Control, ByVal e As EventArgs) Handles txtFilm.TextChanged
        If indicator > 0 Then
            sender.Text = IsNumeric(sender.Text)
        End If
    End Sub
#End Region


    
    Private Sub tsPrint1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPrint1.Click
        Call DisplayPrintPDF()
        Dim dtrec = clsDashboard.getDashboard(2, requestdetailno)
        Dim str = Utility.getSPR(dtrec.Rows(0).Item("itemdescription").ToString(), dtResult.Rows(0).Item("itemspecs").ToString())
        Dim frm As New frmReport
        frm.printType = "PrescriptionRad"
        frm.varstr = requestdetailno
        Dim dtRecord = clsDashboard.getMyPatients(1, dtResult.Rows(0).Item("admissionid").ToString())

        'frm.varoffice = Utility.formatHospitalNumber(dtRecord.Rows(0).Item("Hospital No").ToString())

        'frm.vardestinationoffice = str
        frm.ShowDialog()
        frm = Nothing
    End Sub

    Public Sub DisplayPrintPDF()
        Dim filename As String = "RadLab_Radiology_" & requestdetailno & ".jpg"
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
End Class