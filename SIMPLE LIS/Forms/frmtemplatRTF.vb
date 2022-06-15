Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Configuration
Imports System.Management.Instrumentation
Imports System.Management
Imports SIMPLE_LIS.Utility
Imports System.Drawing.Imaging
Public Class frmtemplateRTF

    Public Sub New(ByVal requestdetailno As Long, ByVal laboratoryid As Long, ByVal labname As String, ByVal Islock As Boolean, ByVal status As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.requestdetailno = requestdetailno
        Me.laboratoryid = laboratoryid
        Me.labname = labname
        Me.Islock = Islock
        Me.requestStatus = status
    End Sub
#Region "Variables"
    Private requestdetailno As Long
    Private laboratoryid As Long
    Private labname As String
    Private itemcode As String
    Private Islock As Boolean

    Private admissionid As Long
    Private labradiologyid As Long
    Private laboratoryresultid As Long
    Private chargeid As Long
    Private patientid As Long
    Private patientname As String
    Private patientbirthdate As Date = Date.Now
    Private ptno As String
    Private patientaddress As String
    Private radiologistdesignation As String
    Private requestStatus As Integer


    Private tempfilename As String
    Private tempsafefilaname As String

    Private ImageStorage As String
    Private DocumentLocation As String
    Private rtfLocation As String

    Dim dtHospitalInfo As New DataTable

    Dim getTransNo As DataTable
    Dim img As Image
    Public isSave As Boolean
#End Region
#Region "Events"
    Private Sub btnAddToList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToList.Click
        If Me.cmbItemCodeFilm.Text <> "" Then
            Dim isexist As Boolean
            For Each row As DataGridViewRow In DGVFilm.Rows
                If Me.cmbItemCodeFilm.SelectedValue = row.Cells(colitemcode.Index).Value Then
                    isexist = True
                End If
            Next
            If isexist Then
                MsgBox("Item already exist in the list", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Else
                Me.DGVFilm.Rows.Add(1)
                Me.DGVFilm.Rows(DGVFilm.Rows.Count - 1).Cells(colitemcode.Index).Value = Me.cmbItemCodeFilm.SelectedValue
                Me.DGVFilm.Rows(DGVFilm.Rows.Count - 1).Cells(colfilmname.Index).Value = Me.cmbItemCodeFilm.Text
                Me.DGVFilm.Rows(DGVFilm.Rows.Count - 1).Cells(colnooffilms.Index).Value = 1
            End If
        Else
            MsgBox("Please Select Film First")
        End If
    End Sub
    Private Sub DGVFilm_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGVFilm.CurrentCellDirtyStateChanged
        If Me.DGVFilm.IsCurrentCellDirty Then
            Me.DGVFilm.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Sub DGVFilm_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVFilm.CellContentClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex = colremove.Index Then
                If Me.DGVFilm.SelectedRows(0).Cells(colchargedetailsid.Index).Value > 0 Then
                    If MessageBox.Show("Are you sure you want to remove this film?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim okDelete As Boolean = False
                        okDelete = clsRadiology.removeChargeDetails(Me.DGVFilm.SelectedRows(0).Cells(colchargedetailsid.Index).Value)
                        If okDelete Then
                            ' moveDeletedImage(Me.DGVFilm.SelectedRows(0).Cells(5).Value, Me.DGVFilm.SelectedRows(0).Cells(3).Value, 0)
                            Me.DGVFilm.Rows.Remove(Me.DGVFilm.CurrentRow)
                            MsgBox("Successfully Deleted")
                            ' myCharges.callInventoryDump(dtOfficeCode.Rows(0).Item("officecode").ToString(), Utility.GetServerDate())
                        End If
                    End If
                Else
                    Me.DGVFilm.Rows.Remove(Me.DGVFilm.CurrentRow)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmRadiology_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtHospitalInfo = clsLaboratoryResult.getHospitalInfo()
        Call LoadCombo()
        Call LoadRecord()
        If Islock Then
            lock()
        End If
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
        Call readImageName(Me.dgvImageAddress.SelectedRows(0).Cells(collocation.Index).Value)
    End Sub


    Private Sub Picture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Picture.Click
        If Me.dgvImageAddress.Rows.Count > 0 And Me.Picture.Image IsNot img Then
            Try
                System.Diagnostics.Process.Start(Me.dgvImageAddress.SelectedRows(0).Cells(collocation.Index).Value)
            Catch ex As Exception
            End Try
        End If
    End Sub


    Private Sub ToolStripButtonbrowswimage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonbrowswimage.Click
        If BrowseFile() Then
            Dim ok As Boolean = False
            For i = 0 To Me.dgvImageAddress.Rows.Count - 1
                If Me.dgvImageAddress.Rows(i).Cells(collocation.Index).Value = tempfilename Then
                    ok = True
                    i = Me.dgvImageAddress.Rows.Count - 1
                Else
                    ok = False
                End If
            Next
            '**********************
            If ok = False Then
                Me.dgvImageAddress.Rows.Add(1)
                Me.dgvImageAddress.Rows(Me.dgvImageAddress.Rows.Count - 1).Cells(collocation.Index).Value = tempfilename
                Me.dgvImageAddress.Rows(Me.dgvImageAddress.Rows.Count - 1).Cells(colimagename.Index).Value = tempsafefilaname
                Me.dgvImageAddress.Rows(Me.dgvImageAddress.Rows.Count - 1).Cells(colimageid.Index).Value = 0
                Try
                    Dim imageData As Byte() = ReadFile(tempfilename)
                    Dim newImage As Image
                    Using ms As New MemoryStream(imageData, 0, imageData.Length)
                        ms.Write(imageData, 0, imageData.Length)
                        newImage = Image.FromStream(ms, True)
                    End Using
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
    Private Sub ToolStripButtonremovethisimage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonremovethisimage.Click
        Try
            If Me.dgvImageAddress.SelectedRows(0).Index >= 0 Then
                If MessageBox.Show("Are you sure you want to remove this image?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    If Me.dgvImageAddress.SelectedRows(0).Cells(colimageid.Index).Value > 0 Then
                        Dim okToDelete As Boolean = clsRadiology.removeImages(Me.dgvImageAddress.SelectedRows(0).Cells(colimageid.Index).Value)
                        If okToDelete Then
                            moveImage(Me.dgvImageAddress.SelectedRows(0).Cells(collocation.Index).Value, Me.dgvImageAddress.SelectedRows(0).Cells(colimagename.Index).Value, True)
                        End If
                    Else
                        Me.dgvImageAddress.Rows.RemoveAt(Me.dgvImageAddress.SelectedRows(0).Index)
                        Me.Picture.Image = img
                    End If
                End If
            Else
                MsgBox("Please select an image to remove")
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region
#Region "Methods"
    Private Function BrowseFile() As Boolean
        Dim dlg As New OpenFileDialog()
        dlg.Filter = "Image Files|*.jpg;*.bmp;*.png;*.jpeg"
        Dim dlgRes As DialogResult = dlg.ShowDialog()
        If dlgRes = DialogResult.OK Then
            Me.tempfilename = dlg.FileName
            Me.tempsafefilaname = dlg.SafeFileName
            Return True
        End If
        Return False
    End Function
    Public Sub saveNow(ByRef action As String)
        'If MsgBox("Are you sure you want to " & action & " this laboratory result?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, modGlobal.msgboxTitle) = MsgBoxResult.Yes Then
        If Me.cmbRadTech.Text = "" Then
            SetErrorProvider(cmbRadTech, "Select employee.")
            Exit Sub
        End If
        If Me.cmbradiologist.Text = "" Then
            SetErrorProvider(cmbRadTech, "Select doctor.")
            Exit Sub
        End If

        isSave = True
        Call SaveRecord()
        If Me.requestStatus = clsModel.RequestStatus.released Then
            Call Me.generatePDF(False)
        End If
        'MsgBox("Laboratory result successfully " + action + "d.", MsgBoxStyle.OkOnly, modGlobal.msgboxTitle)
        Islock = True

        'End If
    End Sub
    Public Sub lock()
        Me.DGVFilm.ReadOnly = True
        Me.DGVFilm.Columns(colremove.Index).Visible = False
        Me.paneladdfilm.Visible = False
        Me.ToolStripButtonbrowswimage.Visible = False
        Me.ToolStripSeparator1.Visible = False
        Me.ToolStripButtonremovethisimage.Visible = False
        Me.ToolStripSeparator2.Visible = False
        Me.dgvImageAddress.ReadOnly = True
        Me.txtResult.ReadOnly = True
        Me.dtDate.Enabled = False
        Me.cmbRadTech.Enabled = False
        Me.cmbradiologist.Enabled = False
    End Sub
    Public Function moveImage(ByVal sourcePath As String, ByVal imageName As String, ByVal isdelete As Boolean) As String
        Dim targetlocation As String = ImageStorage & "\Templates"
        If isdelete Then
            targetlocation = ImageStorage & "\Deleted"
            If Directory.Exists(targetlocation) = False Then
                Directory.CreateDirectory(targetlocation)
                Dim diMyDir As New DirectoryInfo(targetlocation)
                diMyDir.Attributes = FileAttributes.Hidden
            End If
            imageName = Me.requestdetailno & "_" & imageName
        End If
        If System.IO.File.Exists(sourcePath) Then
            Dim i As Integer = 1
            While System.IO.File.Exists(targetlocation & "\" & imageName)
                imageName = imageName & "_" + i
            End While
            System.IO.File.Copy(sourcePath, targetlocation & "\" & imageName)
        Else
            imageName = ""
        End If
        Return imageName
    End Function
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
    Private Sub LoadRecord()
        Try
            Call LoadFilms()
            If Me.laboratoryid = 10 Then
                Me.Text = "RADIOLOGY"
            Else
                Me.Text = "ULTRASOUND"
            End If
            Dim dtResult As DataTable = clsRadiology.getRadiologyResultDetails(requestdetailno, 9)
            If dtResult.Rows(0).Item("gender").ToString = "M" Then
                Me.txtGender.Text = "Male"
            Else
                Me.txtGender.Text = "Female"
            End If
            Me.admissionid = dtResult.Rows(0).Item("admissionid").ToString
            DocumentLocation = Utility.readSetting(appSettings.DocumentLocationEMR)
            If DocumentLocation <> "" Then
                ImageStorage = DocumentLocation & "\"
            End If
            rtfLocation = String.Format("{0}{1}\results\{2}.rtf", ImageStorage, Me.admissionid, Me.requestdetailno)
            ImageStorage = String.Format("{0}{1}\results\", ImageStorage, Me.admissionid)
            Me.txtPatientname.Text = dtResult.Rows(0).Item("patient").ToString
            Me.txtAge.Text = dtResult.Rows(0).Item("age").ToString
            Me.lblexamination.Text = dtResult.Rows(0).Item("itemspecs").ToString
            Me.cmbRadTech.SelectedValue = dtResult.Rows(0).Item("radtechid")
            Me.cmbradiologist.SelectedValue = dtResult.Rows(0).Item("radiologistid")
            Me.laboratoryresultid = dtResult.Rows(0).Item("laboratoryresultid")
            Me.labradiologyid = dtResult.Rows(0).Item("labradiologyid")
            Me.patientid = dtResult.Rows(0).Item("patientid")
            Me.patientname = dtResult.Rows(0).Item("patient")
            Me.patientbirthdate = Utility.NullToDefaultDateFormat(dtResult.Rows(0).Item("birthdate"))
            Me.ptno = Utility.NullToEmptyString(dtResult.Rows(0).Item("ptno"))
            Me.patientaddress = Utility.NullToEmptyString(dtResult.Rows(0).Item("homeaddress"))
            Me.radiologistdesignation = Utility.NullToEmptyString(dtResult.Rows(0).Item("radiologistdesignation"))

            Dim dtResultImages As DataTable = clsRadiology.getRadiologyResultDetailsImages(requestdetailno, 4)
            For i = 0 To dtResultImages.Rows.Count - 1
                Me.dgvImageAddress.Rows.Add(1)
                Me.dgvImageAddress.Rows(i).Cells(colimageid.Index).Value = dtResultImages.Rows(i)("imageid")
                Me.dgvImageAddress.Rows(i).Cells(colimagename.Index).Value = dtResultImages.Rows(i)("image")
                Me.dgvImageAddress.Rows(i).Cells(colimagedesc.Index).Value = dtResultImages.Rows(i)("description")
                Me.dgvImageAddress.Rows(i).Cells(collocation.Index).Value = ImageStorage & "\Templates\" + dtResultImages.Rows(i)("image").ToString()
            Next

            Dim dtChargeResultDetails As DataTable = clsCharges.getResultCharges(8, "", requestdetailno)
            For ctr = 0 To dtChargeResultDetails.Rows.Count - 1
                Me.DGVFilm.Rows.Add(1)
                Me.DGVFilm.Rows(ctr).Cells(colchargedetailsid.Index).Value = dtChargeResultDetails.Rows(ctr).Item("chargedetailsid")
                Me.DGVFilm.Rows(ctr).Cells(colitemcode.Index).Value = dtChargeResultDetails.Rows(ctr).Item("itemcode").ToString()
                Me.DGVFilm.Rows(ctr).Cells(colfilmname.Index).Value = dtChargeResultDetails.Rows(ctr).Item("itemdescription").ToString()
                Me.DGVFilm.Rows(ctr).Cells(colnooffilms.Index).Value = dtChargeResultDetails.Rows(ctr).Item("quantity")
                Me.chargeid = dtChargeResultDetails.Rows(ctr).Item("chargeid")
            Next

            If File.Exists(rtfLocation) Then
                txtResult.LoadFile(rtfLocation)
            End If
        Catch ex As Exception
        End Try
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
            Me.Picture.SizeMode = PictureBoxSizeMode.StretchImage
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub LoadCombo()
        Try
            Me.cmbradiologist.DataSource = clsRadiology.getRadiologist(clsModel.EmployeeTypes.radiologist)
            Me.cmbradiologist.DisplayMember = "radiologist"
            Me.cmbradiologist.ValueMember = "employeeid"
            Me.cmbradiologist.SelectedIndex = 0

            Me.cmbRadTech.DataSource = clsRadiology.getRadiologist(clsModel.EmployeeTypes.radtech)
            Me.cmbRadTech.DisplayMember = "radiologist"
            Me.cmbRadTech.ValueMember = "employeeid"
            Me.cmbRadTech.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadFilms()
        Me.cmbItemCodeFilm.DataSource = clsLabRadiology.getItemCodeFilm()
        Me.cmbItemCodeFilm.DisplayMember = "ItemDescription"
        Me.cmbItemCodeFilm.ValueMember = "ItemCode"
    End Sub

    Private Sub SaveRecord()
        '******************** save labresult
        Dim myLaboratoryResult As New clsLaboratoryResult
        With myLaboratoryResult

            .laboratoryid = Me.laboratoryid
            .admissionid = Me.admissionid
            .patientrequestno = Me.requestdetailno
            .specimen = Me.lblexamination.Text
            .datesubmitted = GetServerDate()
            .dateencoded = dtDate.Value
            .encodedby = userid
            .medtech = cmbRadTech.SelectedValue
            .medicaltechnologist = .medtech
            .releasedby = 1
            .datereleased = GetServerDate() '"01/01/1990"
            .pathologist = Me.cmbradiologist.SelectedValue
            If Me.laboratoryresultid = 0 Then
                .Save(True)
                Call SaveLog("Radiology", "New Radiology result:" & .patientrequestno, userid)
            Else
                .Oldlaboratoryid = Me.laboratoryresultid
                .Save(False)
                Call SaveLog("Radiology", "Update Radiology result:" & .patientrequestno, userid)
            End If
        End With

        Dim myRadiology As New clsRadiology
        Dim myCharges As New clsCharges

        '************************ save radiology
        myRadiology.labexaminationno = myLaboratoryResult.labno
        myRadiology.resultdescription = "" 'Me.txtResult.Text
        myRadiology.patientrequestdetailno = Me.requestdetailno
        myRadiology.admissionid = Me.admissionid
        myRadiology.remarks = ""
        If Me.labradiologyid = 0 Then
            myRadiology.Oldlabradiologyid = 0
            myRadiology.soperation = 0
            myRadiology.Save(True)
        Else
            myRadiology.Oldlabradiologyid = Me.labradiologyid
            myRadiology.soperation = 0
            myRadiology.Save(False)
        End If
        If Directory.Exists(ImageStorage) = False Then
            Directory.CreateDirectory(ImageStorage)
        End If
        Me.txtResult.SaveFile(rtfLocation)

        If Me.DGVFilm.Rows.Count > 0 Then
            '******************* save charges
            myCharges.transtype = "XR"
            Dim officecode As DataTable = clsCharges.getOfficeCode(modGlobal.userid)
            myCharges.officecode = officecode.Rows(0).Item("officecode").ToString()
            getTransNo = clsCharges.getTransNo(myCharges.officecode, myCharges.transtype) 'datatTable get transNO
            myCharges.transno = getTransNo.Rows(0).Item("documentno").ToString()
            myCharges.preparedbyid = userid
            myCharges.dateprepared = GetServerDate()
            myCharges.dateapproved = GetServerDate() '"1/1/1900 0:00:00 PM"
            myCharges.remarks = "X-RAY/Ultrasound"

            myCharges.patientno = Me.patientid
            myCharges.patientname = Me.patientname
            myCharges.registryno = myLaboratoryResult.admissionid ' or admission id
            If Me.chargeid = 0 Then
                Me.chargeid = myCharges.Save(True)
            Else
                myCharges.SaveUpdate(False)
            End If

            '******************** save charge details
            myCharges.DeleteAllChargeDetailsForXray(requestdetailno)
            For ctr = 0 To Me.DGVFilm.Rows.Count - 1
                myCharges.itemcode = Me.DGVFilm.Rows(ctr).Cells(colitemcode.Index).Value 'myLaboratoryResult.itemcatcode
                myCharges.lotno = Me.DGVFilm.Rows(ctr).Cells(colitemcode.Index).Value
                myCharges.expirydate = GetServerDate() '"1/1/1900 0:00:00 PM"
                myCharges.quantity = Me.DGVFilm.Rows(ctr).Cells(colnooffilms.Index).Value
                'If Me.DGVFilm.Rows(ctr).Cells(3).Value = CheckState.Checked Or Me.DGVFilm.Rows(ctr).Cells(3).Value = True Then
                myCharges.remarks = "Film Used"
                'Else
                'myCharges.remarks = "Spoils"
                'End If
                myCharges.refadmissionchargeno = requestdetailno
                myCharges.search = Me.DGVFilm.Rows(ctr).Cells(colchargedetailsid.Index).Value
                myCharges.admissionchargeno = Me.chargeid
                If myCharges.search = 0 Then
                    myCharges.SaveDetails(True)
                Else
                    myCharges.SaveUpdateDetails(False)
                End If
            Next
        End If

        '******************** save images
        If Me.dgvImageAddress.Rows.Count > 0 AndAlso Directory.Exists(ImageStorage & "\Templates") = False Then
            Directory.CreateDirectory(ImageStorage)
            Directory.CreateDirectory(ImageStorage & "\Templates")
            Dim managementClass As New ManagementClass("Win32_Share")
            Dim inParams As ManagementBaseObject = managementClass.GetMethodParameters("Create")
            inParams.Item("Description") = "My Files Share"
            inParams.Item("Name") = "My Files Share"
            inParams.Item("Path") = ImageStorage
            inParams.Item("Type") = 0
            Dim diMyDir As New DirectoryInfo(ImageStorage)
            diMyDir.Attributes = FileAttributes.Hidden
            Dim diMyDir1 As New DirectoryInfo(ImageStorage & "\Templates")
            diMyDir1.Attributes = FileAttributes.Hidden
        End If
        For Each row As DataGridViewRow In Me.dgvImageAddress.Rows
            If row.Cells(colimageid.Index).Value = 0 Then
                myRadiology.image = moveImage(row.Cells(collocation.Index).Value, row.Cells(colimagename.Index).Value, False)
            Else
                myRadiology.image = row.Cells(colimagename.Index).Value
            End If
            If myRadiology.image = "" Then
                MsgBox("Unable to save file " & row.Cells(colimagename.Index).Value)
            Else
                myRadiology.imageid = row.Cells(colimageid.Index).Value
                myRadiology.description = row.Cells(colimagedesc.Index).Value
                myRadiology.saveImage(myRadiology.imageid = 0)
            End If
        Next
        isSave = True
        myRadiology = Nothing
        myLaboratoryResult = Nothing
    End Sub
#End Region
#Region "Printing"
    Public Sub DisplayPrintPreview()
        Dim dt As DataTable = clsadmissiondocuments.getDocument(6, Me.requestdetailno, Me.admissionid)
        If (dt.Rows.Count > 0) Then
            If File.Exists(DocumentLocation & "\" & dt.Rows(0).Item("documentlocation")) Then
                Process.Start(DocumentLocation & "\" & dt.Rows(0).Item("documentlocation"))
                Exit Sub
            End If
        End If
        Call generatePDF()
    End Sub
    Public Sub generatePDF(Optional openAfterExport As Boolean = True)
        Dim wordApplication As New Microsoft.Office.Interop.Word.Application
        Dim wordDocument As Microsoft.Office.Interop.Word.Document = Nothing
        Dim tempfilename = Application.StartupPath() & "\templates\temp\" & Utility.GetRandomString() & ".docx"
        Dim mastertemplate As String = "templates\headertemplatedoc_generic.docx"
        If File.Exists("templates\headertemplatedoc_" & cmbradiologist.SelectedValue & ".docx") Then
            mastertemplate = "templates\headertemplatedoc_" & cmbradiologist.SelectedValue & ".docx"
        End If
        Try
            File.Copy(mastertemplate, tempfilename, True)
            wordDocument = wordApplication.Documents.Open(tempfilename)
            wordDocument.Activate()
            For Each r As Microsoft.Office.Interop.Word.Range In wordDocument.StoryRanges
                With r.Find
                    .Text = "{patientname}"
                    .Replacement.Text = txtPatientname.Text
                    .Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
                    .Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
                End With
                With r.Find
                    .Text = "{age_sex}"
                    .Replacement.Text = txtAge.Text & "/" & txtGender.Text
                    .Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
                    .Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
                End With
                With r.Find
                    .Text = "{date}"
                    .Replacement.Text = dtDate.Value.ToString("MM/dd/yyyy hh:mm tt")
                    .Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
                    .Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
                End With
                With r.Find
                    .Text = "{print_date}"
                    .Replacement.Text = Utility.GetServerDate().ToString("MM/dd/yyyy hh:mm tt")
                    .Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
                    .Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
                End With
                With r.Find
                    .Text = "{examination}"
                    .Replacement.Text = Me.lblexamination.Text
                    .Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
                    .Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
                End With
                With r.Find
                    .Text = "{patientno}"
                    .Replacement.Text = Me.ptno
                    .Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
                    .Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
                End With
                With r.Find
                    .Text = "{birthdate}"
                    .Replacement.Text = Me.patientbirthdate.ToShortDateString
                    .Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
                    .Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
                End With
                With r.Find
                    .Text = "{patientaddress}"
                    .Replacement.Text = Me.patientaddress
                    .Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
                    .Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
                End With
                With r.Find
                    .Text = "{doctorsname}"
                    .Replacement.Text = Me.cmbradiologist.Text
                    .Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
                    .Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
                End With
                With r.Find
                    .Text = "{doctorsdesignation}"
                    .Replacement.Text = Me.radiologistdesignation
                    .Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
                    .Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
                End With
            Next
            Dim finfo As New FileInfo(rtfLocation)
            wordDocument.Range.InsertFile(finfo.FullName, Type.Missing, False, False, False)
            wordDocument.Save()

            Dim outputFilename = String.Format("\{0}\{1}.pdf", admissionid, Me.lblexamination.Text)
            Dim fi As New FileInfo(DocumentLocation)


            If Not wordDocument Is Nothing Then
                wordDocument.ExportAsFixedFormat(fi.FullName & outputFilename, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF, openAfterExport, Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForOnScreen, Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument, 0, 0, Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentContent, True, True, Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks, True, True, False)
                Call clsadmissiondocuments.SaveAdmissionDocument(requestdetailno, Me.admissionid, outputFilename)
            End If
        Catch ex As Exception
            'TODO: handle exception
        Finally
            If Not wordDocument Is Nothing Then
                wordDocument.Close(False)
                wordDocument = Nothing
            End If

            If Not wordApplication Is Nothing Then
                wordApplication.Quit()
                wordApplication = Nothing
            End If
        End Try
        Try
            File.Delete(tempfilename)
        Catch ex As Exception

        End Try
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

    Private Sub MiscPrintDocu_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles MiscPrintDocu.PrintPage
        e.Graphics.DrawImage(GetFormImage(False), New Point(15, 0))
    End Sub
#End Region

    Private Sub DGVFilm_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DGVFilm.CellPainting
        If e.ColumnIndex = colremove.Index AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            Dim bmpFind As Bitmap = My.Resources.delete_16x16
            Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
            e.Graphics.DrawIcon(ico, e.CellBounds.Left + 8, e.CellBounds.Top + 3)
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        txtResult.LoadFile("C:\Users\Admin\Downloads\testrtf.rtf")
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs)
        If txtResult.Text.Contains("{birthdate}") Then
            MsgBox(txtResult.Text.IndexOf("{birthdate}"))
        End If
    End Sub

    Private Sub Button1_Click_2(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        DisplayPrintPreview()
    End Sub
End Class