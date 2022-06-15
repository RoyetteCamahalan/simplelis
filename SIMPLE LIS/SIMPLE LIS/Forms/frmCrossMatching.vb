Imports System.Drawing.Imaging
Imports System.IO

Public Class frmCrossMatching

#Region "Variables"
    Dim erp As New ErrorProvider
    Public isSave As Boolean
    Public myFormStatus As enFormStatus
    Public myResult As enResult
    Public itemscode As String
    Dim labresultid As String
    Dim itemscodeold As String
    Public adminid As String 'supply value
    Dim patientrequestno As String
    Dim patientdetailrequestno As String
    Public requestdetailno As String  'supply patient request detail number
    Dim labno As String
    Dim labid As String
    Dim dECGReport As DataTable
    Dim ColumnDateExtracted As New CalendarColumn()
    Dim ColumnDateExpired As New CalendarColumn()
    'Public frmPrintings As New frmPrinting()
    Public status As Integer
    Public Islock As Boolean

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
        SetErrorProvider(Me.cmbpatientrh)
        SetErrorProvider(Me.cmbPhysician)
        SetErrorProvider(Me.cmbdonorsrh)
        SetErrorProvider(Me.cmbPathologist)
        SetErrorProvider(Me.cmbMedTech)
        SetErrorProvider(Me.txtLabNo)
        SetErrorProvider(Me.dtDate)

    End Sub
#End Region

#Region "Events"
    Private Sub SetErrorProvider(ByVal ctl As Control, Optional ByVal strErrorMessage As String = "")
        'Activate or deactivate an error provider for a data entry field
        erp.SetError(ctl, strErrorMessage)
    End Sub

    Private Sub frmCrossMatching_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'EnableFields()
        Call LoadPhysician()
        Call LoadPathologist()
        Call LoadMedtech()
        Call LoadXmatch()
        Call LoadXmatchBloods()
        If myFormStatus = enFormStatus.browsing Or myFormStatus = enFormStatus.edit Then
            Call LoadCrossmatching()
        End If
    End Sub

    Private Sub cmbpatientrh_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtPatientRh(Me.cmbpatientrh)
    End Sub

    Private Sub cmbPhysician_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidcmbPhysician(Me.cmbPhysician)
    End Sub
    Private Sub cmbdonorsrh_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtDonorRh(Me.cmbdonorsrh)
    End Sub
    Private Sub cmbPathologist_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidcmbPathologist(Me.cmbPathologist)
    End Sub
    Private Sub txtLabNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidtxtLabNo(Me.txtLabNo)
    End Sub
    Private Sub cmbMedTech_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValidcmbMedTech(Me.cmbMedTech)
    End Sub
    Private Sub dtDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        isFieldValiddtDate(Me.dtDate)
    End Sub
#End Region

#Region "New Methods"
    Private Function isFieldValidtxtPatientRh(ByRef vtxtPatientRh As Control) As Boolean
        Dim isValidtxtPatientRh As Boolean
        If vtxtPatientRh.Text = "" Then
            SetErrorProvider(Me.cmbpatientrh, "Field is required.")
            isValidtxtPatientRh = False
        Else
            SetErrorProvider(vtxtPatientRh)
            isValidtxtPatientRh = True
        End If
        Return isValidtxtPatientRh
    End Function

    Private Function isFieldValidcmbPhysician(ByRef vcmbPhysician As Control) As Boolean
        Dim isValidcmbPhysician As Boolean
        If vcmbPhysician.Text = "" Then
            SetErrorProvider(Me.cmbPhysician, "Field is required.")
            isValidcmbPhysician = False
        Else
            SetErrorProvider(vcmbPhysician)
            isValidcmbPhysician = True
        End If
        Return isValidcmbPhysician
    End Function
    Private Function isFieldValidtxtDonorRh(ByRef vtxtDonorRh As Control) As Boolean
        Dim isValidtxtDonorRh As Boolean
        If vtxtDonorRh.Text = "" Then
            SetErrorProvider(Me.cmbdonorsrh, "Field is required.")
            isValidtxtDonorRh = False
        Else
            SetErrorProvider(vtxtDonorRh)
            isValidtxtDonorRh = True
        End If
        Return isValidtxtDonorRh
    End Function
    Private Function isFieldValidcmbPathologist(ByRef vcmbPathologist As Control) As Boolean
        Dim isValidcmbPathologist As Boolean
        If vcmbPathologist.Text = "" Then
            SetErrorProvider(Me.cmbPathologist, "Field is required.")
            isValidcmbPathologist = False
        Else
            SetErrorProvider(vcmbPathologist)
            isValidcmbPathologist = True
        End If
        Return isValidcmbPathologist
    End Function
    Private Function isFieldValidcmbMedTech(ByRef vcmbMedTech As Control) As Boolean
        Dim isValidcmbMedTech As Boolean
        If vcmbMedTech.Text = "" Then
            SetErrorProvider(Me.cmbMedTech, "Field is required.")
            isValidcmbMedTech = False
        Else
            SetErrorProvider(vcmbMedTech)
            isValidcmbMedTech = True
        End If
        Return isValidcmbMedTech
    End Function
    Private Function isFieldValidtxtLabNo(ByRef vtxtLabNo As Control) As Boolean
        Dim isValidtxtLabNo As Boolean
        If vtxtLabNo.Text = "" Then
            SetErrorProvider(Me.txtLabNo, "Field is required.")
            isValidtxtLabNo = False
        Else
            SetErrorProvider(vtxtLabNo)
            isValidtxtLabNo = True
        End If
        Return isValidtxtLabNo
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

            Me.cmbpatientrh.Enabled = False
            Me.cmbPhysician.Enabled = False
            Me.cmbdonorsrh.Enabled = False
            Me.cmbPathologist.Enabled = False
            Me.cmbMedTech.Enabled = False
            Me.dtDate.Enabled = False
            Me.txtLabNo.Enabled = False
            Me.dgvCrossM.Enabled = False
        End If
    End Sub
    Public Sub SaveRecord()
        Dim myXmatching As New clsCrossmatching
        Dim dtgetlabid As New DataTable
        'Dim frmMDIParents As New frmMDIParent
        dtgetlabid = clsCrossmatching.getlabresultid("5", patientdetailrequestno)
        labresultid = dtgetlabid.Rows(0).Item("laboratoryresultid")
        myXmatching.labresultid = labresultid
        myXmatching.patientrh = Me.cmbpatientrh.Text
        myXmatching.donorrh = Me.cmbdonorsrh.Text
        myXmatching.labno = Me.txtLabNo.Text

        If myFormStatus = enFormStatus.add Then
            myXmatching.saveLRXmatching(True)
        Else
            myXmatching.saveLRXmatching(False)
        End If

    End Sub
    Public Sub SaveRecordResult()
        Dim myXMatching As New clsCrossmatching
        Dim dtgetlabid As New DataTable

        myXMatching.adminno = adminid
        myXMatching.patientdetailno = patientdetailrequestno
        myXMatching.labno = labno
        myXMatching.edate = Me.dtDate.Value
        myXMatching.empno = Me.cmbPhysician.SelectedValue
        myXMatching.medtech = Me.cmbMedTech.SelectedValue
        myXMatching.pathologist = Me.cmbPathologist.SelectedValue
        myXMatching.labresultid = labresultid

        If myFormStatus = enFormStatus.add Then
            myXMatching.saveLRXmatchingResult(True)
        Else
            dtgetlabid = clsCrossmatching.getlabresultid("5", patientdetailrequestno)
            labresultid = dtgetlabid.Rows(0).Item("laboratoryresultid")
            myXMatching.labresultid = labresultid
            myXMatching.saveLRXmatchingResult(False)
        End If
    End Sub
    Public Sub SaveRecordResultDetails()
        Dim frmMDIParents As New frmMDIParent(frmMDIParent.enFormStatus.add)
        Dim myXMatching As New clsCrossmatching

        If myFormStatus = enFormStatus.edit Then
            myXMatching.deleteXmatchingdetails(labresultid)
        End If
        For ctr As Integer = 0 To dgvCrossM.Rows.Count - 2
            If ctr < dgvCrossM.Rows.Count Then
                myXMatching.bloodsource = dgvCrossM.Item(0, ctr).Value
                myXMatching.serialno = dgvCrossM.Item(1, ctr).Value
                myXMatching.bloodcomponent = dgvCrossM.Item(2, ctr).Value
                myXMatching.volume = dgvCrossM.Item(3, ctr).Value
                myXMatching.dateextracted = CDate(dgvCrossM.Item(4, ctr).Value)
                myXMatching.dateexpired = CDate(dgvCrossM.Item(5, ctr).Value)
                myXMatching.remarks = dgvCrossM.Item(6, ctr).Value
            End If

            myXMatching.saveLRXmatchingResultDetail(True)

        Next
        myFormStatus = enFormStatus.browsing
    End Sub
   

#Region "Load Methods"
    Public Sub LoadPhysician()
        Me.cmbPhysician.DataSource = clsCrossmatching.getPhysician()
        Me.cmbPhysician.DisplayMember = "cname"
        Me.cmbPhysician.ValueMember = "employeeid"
    End Sub
    Public Sub LoadPathologist()
        Me.cmbPathologist.DataSource = clsCrossmatching.getPathologist()
        Me.cmbPathologist.DisplayMember = "cname"
        Me.cmbPathologist.ValueMember = "employeeid"
    End Sub
    Public Sub LoadMedtech()
        Me.cmbMedTech.DataSource = clsCrossmatching.getMedtech()
        Me.cmbMedTech.DisplayMember = "cname"
        Me.cmbMedTech.ValueMember = "employeeid"
    End Sub
    Public Sub LoadXmatch()

        ColumnDateExtracted.Name = "Date Extracted"
        ColumnDateExpired.Name = "Date Expired"
        With Me.dgvCrossM
            .DefaultCellStyle.Font = New Font("Calibri", 10)
            .RowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

            .Columns.Add(0, "Blood Source")
            .Columns(0).Width = 110
            .Columns(0).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)
            .Columns.Add(1, "Serial No.")
            .Columns(1).Width = 110
            .Columns(1).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)
            .Columns.Add(2, "Blood Component")
            .Columns(2).Width = 120
            .Columns(2).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)

            .Columns.Add(3, "Volume")
            .Columns(3).Width = 100
            .Columns(3).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)

            .Columns.Add(ColumnDateExtracted)
            .Columns(4).Width = 100
            .Columns(4).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)
            .Columns.Add(ColumnDateExpired)
            .Columns(5).Width = 120
            .Columns(5).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)
            .Columns.Add(5, "Remarks")
            .Columns(6).Width = 100
            .Columns(6).DefaultCellStyle.SelectionBackColor = Color.FromArgb(73, 163, 75)
        End With
        
    End Sub
    Public Sub LoadCrossmatching()
        Dim dtxmatching As New DataTable
        If myFormStatus = enFormStatus.add Or myResult = enResult.manageresult Then
            dtxmatching = clsCrossmatching.getECGReportresult(requestdetailno, enResult.manageresult)
        Else
            dtxmatching = clsECGReport.getids(adminid, requestdetailno)
        End If
        Me.txtName.Text = dtxmatching.Rows(0).Item("patient")

        If dtxmatching.Rows(0).Item("age").ToString = "" Then
            Me.txtAge.Text = ""
        Else
            Me.txtAge.Text = dtxmatching.Rows(0).Item("age")
        End If
        Me.txtGender.Text = dtxmatching.Rows(0).Item("gender")
        Me.txtRoom.Text = dtxmatching.Rows(0).Item("roomno")

        adminid = dtxmatching.Rows(0).Item("admissionid")
        Me.txtLabNo.Text = dtxmatching.Rows(0).Item("labno")
        patientdetailrequestno = dtxmatching.Rows(0).Item("patientrequestdetailno")
        Admission.AdmissionID = dtxmatching.Rows(0).Item("admissionid").ToString
        Admission.patientname = dtxmatching.Rows(0).Item("patient").ToString

        Dim dtHospitalInfo As DataTable = clsLaboratoryResult.getHospitalInfo()

        Me.lblHeader.Text = dtHospitalInfo.Rows(0).Item("Hospital").ToString()
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
        If myResult = enResult.releaseresult Then
            If Islock = True Then
                LockFields()
            End If
            Me.cmbPhysician.SelectedValue = dtxmatching.Rows(0).Item("employeeno")
            Me.cmbPathologist.SelectedValue = dtxmatching.Rows(0).Item("pathologist")
            Me.cmbMedTech.SelectedValue = dtxmatching.Rows(0).Item("medtech")
            labid = dtxmatching.Rows(0).Item("laboratoryresultid")
            Me.dtDate.Value = dtxmatching.Rows(0).Item("dateencoded")
            dtxmatching = clsCrossmatching.getlabresultxmtching(labid)
            cmbpatientrh.Text = dtxmatching.Rows(0).Item("patientrh")
            cmbdonorsrh.Text = dtxmatching.Rows(0).Item("donorrh")
            txtLabNo.Text = dtxmatching.Rows(0).Item("labno")

            Me.dECGReport = clsCrossmatching.getlabresultxmtchingdetail(labid)
            For ctr As Integer = 0 To dECGReport.Rows.Count - 1
                dgvCrossM.Rows.Add()
                Me.dgvCrossM.Rows(ctr).Cells(0).Value = dECGReport.Rows(ctr)(2).ToString
                Me.dgvCrossM.Rows(ctr).Cells(1).Value = dECGReport.Rows(ctr)(3).ToString
                Me.dgvCrossM.Rows(ctr).Cells(2).Value = dECGReport.Rows(ctr)(4).ToString
                Me.dgvCrossM.Rows(ctr).Cells(3).Value = dECGReport.Rows(ctr)(5).ToString
                Me.dgvCrossM.Rows(ctr).Cells(4).Value = CDate(dECGReport.Rows(ctr)(6).ToString)
                Me.dgvCrossM.Rows(ctr).Cells(5).Value = CDate(dECGReport.Rows(ctr)(7).ToString)
                Me.dgvCrossM.Rows(ctr).Cells(6).Value = dECGReport.Rows(ctr)(8).ToString
            Next
        End If

        labno = "5"

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
        For i = 0 To Controls.Count - 1
            If TypeOf Controls(i) Is Panel Then
                Controls(i).Enabled = False
            End If
        Next
        cmbMedTech.Enabled = False
        cmbPathologist.Enabled = False
        dgvCrossM.Enabled = False
    End Sub
#End Region
    Public Sub DisplayPrintPreview()
        Call DisplayPrintPDF()
        Dim fReportHander As New frmReport
        fReportHander.printType = "CROSSMATCHING MAIN"
        fReportHander.varno = adminid 
        fReportHander.varstr = requestdetailno
        fReportHander.ShowDialog()
    End Sub
    Public Sub DisplayPrintPDF()
        Dim filename As String = "RadLab_CrossMatching_" & requestdetailno & ".jpg"
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
#Region "Format Blood List"
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
#End Region
#End Region

     
End Class
Public Class CalendarColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
            Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
            Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "M/d/yyyy hh:mm tt"


    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
    ByVal initialFormattedValue As Object, _
    ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        Try

            ' Set the value of the editing control to the current cell value.
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
            dataGridViewCellStyle)

            Dim ctl As CalendarEditingControl = _
            CType(DataGridView.EditingControl, CalendarEditingControl)
            ctl.Value = CDate(Me.Value)

        Catch ex As Exception

        End Try
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(String)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return ""
        End Get
    End Property
End Class


Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.CustomFormat = "M/d/yyyy hh:mm tt"

        Me.Format = DateTimePickerFormat.Custom

    End Sub

    Public Property EditingControlFormattedValue() As Object _
    Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Value.ToShortDateString
        End Get

        Set(ByVal value As Object)
            If TypeOf value Is String Then
                Me.Value = DateTime.Parse(CStr(value))
            End If
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
    As DataGridViewDataErrorContexts) As Object _
    Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Value.ToString("M/d/yyyy hh:mm tt")

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
    DataGridViewCellStyle) _
    Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer _
    Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
    ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
    Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
            Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
    Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done.

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
    As Boolean Implements _
    IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
    Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
    Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
    Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)

    End Sub

End Class

