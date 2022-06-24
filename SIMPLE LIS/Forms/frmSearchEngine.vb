Public Class frmSearchEngine

#Region "Variables"
    Public myCurrentFormStatus As enFormStatus

    Public mDescription As String

    Public mModule As ModuleName
    Public mKey As String
    Public mvalue As String
    Public mRoomRate As String
    Public mDocFee As String
    Public mRVU As String
    Public mProcDescription As String
    Public mDiagnosisDesc As String
    Public mICD10Code As String
    Public mICD10Description As String
    Public mLastName As String
    Public mFirstName As String
    Public mAdmissionType As String
    Public isbilling As Boolean
    Dim misAvailable As Boolean = True
    Dim afteritemsload As Boolean = True
    Dim oldval As Boolean
    Dim vphilhealthno As String
    Public issave, istype As Boolean
    Public isAdmissionSearch As Boolean = False
    Private vdischargestatus As String
    Public vIsnewborn, afterload As Boolean
    Public AdmissionID As Long 'Add By IDRIZ
    Public caseratetype As Byte
    Dim dtCharges As New DataTable()
    Public dt As New DataTable
    Private dtitems As New DataTable

    Public mrow As DataGridViewRow 
    Enum enFormStatus
        browsing = 0
        add = 1
        edit = 2
        view = 3
    End Enum
    Enum ModuleName
        MergeResult
    End Enum

    Public IsActivePatient As Boolean = True
    Public IsExpired As Boolean
    Public IsNewBorn As Boolean

#End Region

#Region "Form Events"
    Private Sub btnIgnoreCreateNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIgnoreCreateNew.Click
        IgnoreCreateNew()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        issave = False
        Me.Close()
        Dispose()
    End Sub
    Private Sub btnSelRecClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelRec.Click
        SelectedRecord()
    End Sub
    Private Sub dgGeneric_doubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.btnSelRec.PerformClick()
    End Sub
    Private Sub dgGeneric_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) 'Handles dgobygne.CellValidating
        Dim CurrentCellValue As Object = e.FormattedValue
        Dim CurrentCellValueMinusCurrenctyFormatting As String = Replace(CurrentCellValue.ToString, "$", "")

        Dim DoubleForConvert As Double
        If Double.TryParse(CurrentCellValueMinusCurrenctyFormatting, DoubleForConvert) = True Then
            dgGeneric.CurrentCell.Value = DoubleForConvert
        Else
            dgGeneric.CurrentCell.Value = 0
            e.Cancel = True
            Exit Sub
        End If

    End Sub
    Private Sub DataErrorTerminator(ByVal sender As Control, ByVal e As DataGridViewDataErrorEventArgs) Handles dgGeneric.DataError
        If TypeOf (e.Exception) Is ConstraintException Then
            Dim view As DataGridView = DirectCast(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
            e.ThrowException = False
        End If
    End Sub
    Public Sub DisplayList(Optional isFirstLoad As Boolean = False)

        Select Case mModule
            Case ModuleName.MergeResult
                Me.dgGeneric.DataSource = clsLaboratoryResult.genericcls(16, Me.mKey)
        End Select

        Me.lblRecordCount.Text = Me.dgGeneric.Rows.Count & " rows"

        Call FormatGrid()

        If Me.dgGeneric.RowCount > 0 Then
            Me.dgGeneric.Rows(0).Selected = True
        End If

    End Sub
    Private Sub dgGeneric_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        
    End Sub
    Private Sub frmSearchEngine_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter And dgGeneric.Focused Then
            SelectedRecord()
        ElseIf e.KeyCode = Keys.F3 Then
            Me.txtSearch.Select()
        ElseIf e.Control = True And e.KeyCode = Keys.N And btnIgnoreCreateNew.TabIndex = 2 Then
            IgnoreCreateNew()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
            issave = False
            'Dispose()
        End If
    End Sub
    Private Sub frmSearchEngine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        FilterBy()
        Call LoadImage()
        If mModule = ModuleName.MergeResult Then
            Me.btnIgnoreCreateNew.Visible = False
        End If

        Call DisplayList(True)
        'Application.DoEvents()
        Me.Show()
        Me.txtSearch.Focus()
    End Sub

    Public Sub FormatGrid()
        With dgGeneric
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DefaultCellStyle.Font = New Font("Tahoma", 9.0!)
            .RowsDefaultCellStyle.BackColor = Color.WhiteSmoke ' themecolor4 'Color.FromArgb(80,123,139) ' Color.WhiteSmoke ' Color.OldLace 'Color.Gainsboro
            .RowsDefaultCellStyle.SelectionBackColor = themecolor3
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White 'Color.FromArgb(142,171,182) ' Color.White
            .AlternatingRowsDefaultCellStyle.SelectionBackColor = themecolor3
            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.False
            .ReadOnly = True
            .EnableHeadersVisualStyles = True


            If Me.mModule = ModuleName.MergeResult Then
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Test Description"
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(2).HeaderText = "Test Specification"
                .Columns(3).Width = 100
                .Columns(3).HeaderText = "Date Released"
            End If
        End With
    End Sub
    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        If e.KeyCode = Keys.Enter Then
            afterload = True
            Call DisplayList()
        End If
    End Sub
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        'istype = True
        'If mModuleName <> "Patient" Then
        '    If mModuleName <> "BirthCertificate" Then
        '        If mModuleName <> "DeathCertificate" Then
        '            Call DisplayList(mModuleName)
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub picSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        istype = True
        afterload = True
        'If mModuleName <> "Patient" Then
        '    If mModuleName <> "BirthCertificate" Then
        '        If mModuleName <> "DeathCertificate" Then
        '            Call DisplayList(mModuleName)
        '        End If
        '    End If
        'End If
        Call DisplayList()
    End Sub
    Private Sub tsClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsClose.Click
        issave = False
        Close()
    End Sub
    Private Sub enabledFields(ByVal sw As Boolean)
        Me.tsClose.Enabled = sw
        Me.btnIgnoreCreateNew.Enabled = sw
        Me.btnSelRec.Enabled = sw
        Me.txtSearch.Enabled = sw
        'Me.picSearch.Enabled = sw
        Me.prgrefresh.Visible = Not sw
        Me.lblLoading.Visible = Not sw

    End Sub
    Private Sub cmbFilterby_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbFilterby.SelectedIndexChanged
        Select Case mModule
            'Outgoing Payment (Payee)
        End Select
    End Sub

#End Region

#Region "Methods"
    Private Sub LoadImage()
        Me.tsClose.Image = modGlobal.close_icon
        Me.btnSelRec.Image = modGlobal.continue_icon
        Me.btnIgnoreCreateNew.Image = modGlobal.load_item_icon
    End Sub
    Private Sub FilterBy()
        Me.cmbFilterby.Visible = False
        Me.lblFilterby.Visible = False
        'With Me.cmbFilterby


        'End With
    End Sub
    Private Function ComputeTotalAmount() As Double
        Dim i As Integer
        Dim payable As Double
        Do While i < dtCharges.Rows.Count
            If IsDBNull(dtCharges.Rows(i)("Excess")) = False Then
                payable = payable + Utility.EmptyToZero(dtCharges.Rows(i)("Excess"))
            End If
            i += 1
        Loop
        Return payable
    End Function
    Private Sub IgnoreCreateNew()
        
    End Sub
    Private Sub SelectedRecord()
        Try
            mKey = Me.dgGeneric.SelectedRows(0).Cells(0).Value
            Select Case mModule
                Case ModuleName.MergeResult
                    mKey = Me.dgGeneric.SelectedRows(0).Cells("patientrequestdetailno").Value
            End Select
            If mKey = "0" Then
                MsgBox("No record selected. Please select from the list or search again.", vbInformation, modGlobal.msgboxTitle)
            Else
                issave = True
                Me.Close()
            End If
        Catch
            MsgBox("No record selected. Please select from the list or search again.", vbInformation, modGlobal.msgboxTitle)
        End Try

    End Sub
    Private Function verifyitemselection(ByVal itemcode As String) As Integer
        'check if lotno exists from database
        Dim ctr As Integer
        Dim exist As Boolean = False
        With dgGeneric
            Do While ctr < dgGeneric.RowCount
                If UCase(.Item(2, ctr).Value) Like "*" & UCase(itemcode) & "*" Or UCase(.Item(1, ctr).Value) = UCase(itemcode) Then
                    exist = True
                    Exit Do
                End If
                ctr = ctr + 1
            Loop
        End With

        Return exist
    End Function
#End Region


    Private Sub DataErrorTerminator(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgGeneric.DataError

    End Sub
End Class

