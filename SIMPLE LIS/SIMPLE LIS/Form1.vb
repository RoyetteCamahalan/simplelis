Imports System.Data.SqlClient

Public Class frmMain
    Dim requestdetailno As Long
    Dim admissionid As Long
    Dim testname As String
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        requestdetailno = Me.txtRequestDetailNo.Text
        testname = Me.cmbTestName.Text
        Dim dt As DataTable = clsExaminationUpshots.getPatientRequestStatus(requestdetailno)
        ' if status is 3
        If dt.Rows(0)(0) = 3 Then
            Dim frmMDI As New frmMDIParent(frmMDIParent.enFormStatus.add)
            frmMDI.myResult = frmMDIParent.enResult.manageresult
            frmMDI.IsSelected = True
            frmMDI.soperation = 0 'Update
            frmMDI.controlProperties = True
            frmMDI.requestdetailno = requestdetailno
            frmMDI.adminid = admissionid

            frmMDI.frm = testname 'dgGenericList.SelectedRows(0).Cells(8).Value ' pass the description ex.TBC THORACIC BONY CAGE-PHIC/PRIVATE

            If dt.Rows(0)(0) = 3 Then
                frmMDI.status = 4
            Else
                frmMDI.status = 5
            End If
            frmMDI.ShowDialog()
        End If
    End Sub



    Private Sub btnView_Click(sender As System.Object, e As System.EventArgs) Handles btnView.Click
        requestdetailno = Me.txtRequestDetailNo.Text
        testname = Me.cmbTestName.Text
        Dim dt As DataTable = clsExaminationUpshots.getPatientRequestStatus(requestdetailno)
        'view rendered request
        If dt.Rows(0)(0) = 4 Then
            Dim frmMDI As New frmMDIParent(frmMDIParent.enFormStatus.browsing)
            frmMDI.myResult = frmMDIParent.enResult.releaseresult
            frmMDI.IsSelected = True
            frmMDI.Islock = True
            frmMDI.adminid = admissionid
            frmMDI.requestdetailno = requestdetailno
            frmMDI.frm = testname
            frmMDI.IsEdit = True
            frmMDI.tsSave.Text = "Release"
            frmMDI.controlProperties = False
            If dt.Rows(0)(0) = 4 Then
                frmMDI.status = 5
                frmMDI.soperation = 1 'Update

                'frmMDI.disabledFields = False
            End If
            frmMDI.ShowDialog()
            frmMDI = Nothing
            'Viewing the released examinations or cancelled examinations
        ElseIf dt.Rows(0)(0) = 5 Or dt.Rows(0)(0) = 6 Then
            Dim frmMDI As New frmMDIParent(frmMDIParent.enFormStatus.browsing)
            frmMDI.myResult = frmMDIParent.enResult.releaseresult
            frmMDI.soperation = 1
            frmMDI.IsSelected = True
            frmMDI.IsEdit = False
            frmMDI.Islock = True
            frmMDI.controlProperties = False
            frmMDI.requestdetailno = requestdetailno
            frmMDI.adminid = admissionid
            frmMDI.frm = testname
            frmMDI.tsSave.Visible = False
            frmMDI.ShowDialog()
            frmMDI = Nothing
        ElseIf dt.Rows(0)(0) = 3 Then
            MsgBox("Request doesn't have result yet", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click

        Dim dtGetStatus As New DataTable
        requestdetailno = Me.txtRequestDetailNo.Text
        testname = Me.cmbTestName.Text
        dtGetStatus = clsExaminationUpshots.getPatientRequestStatus(requestdetailno)
        If dtGetStatus.Rows(0)(0) = 4 Then
            Dim frmMDI As New frmMDIParent(frmMDIParent.enFormStatus.edit)
            frmMDI.myResult = frmMDIParent.enResult.releaseresult
            frmMDI.IsSelected = True
            frmMDI.requestdetailno = requestdetailno
            frmMDI.adminid = admissionid
            frmMDI.Islock = False
            frmMDI.soperation = 0 'Update
            frmMDI.controlProperties = True
            frmMDI.tsSave.Text = "Update"
            frmMDI.frm = testname
            If testname = "ECG" Then
                Dim frmECGReports As New frmECGReport

                'frmMDI.enbl = False
                frmMDI.tvControlsMain.Visible = False
                frmMDI.frm = "ECG"
                'frmMDIParent.myFormStatus = frmMDIParent.enFormStatus.edit
                frmECGReport.myResult = frmECGReport.enResult.releaseresult
            ElseIf testname = "CROSSMATCHING" Then

                frmMDI.tvControlsMain.Visible = False
                frmMDI.frm = "CROSSMATCHING"
                'frmMDIParent.myFormStatus = frmMDIParent.enFormStatus.edit
                frmCrossMatching.myResult = frmCrossMatching.enResult.releaseresult
            ElseIf testname = "NEWBORNSCREENING" Then

                frmMDI.tvControlsMain.Visible = False
                frmMDI.frm = "NEWBORNSCREENING"
                'frmMDIParent.myFormStatus = frmMDIParent.enFormStatus.edit
                frmNewBornScreening.myResult = frmNewBornScreening.enResult.releaseresult
            End If
            frmMDI.ShowDialog()
        End If
    End Sub

    Private Sub LoadDiagnosticItems()
        Dim conn As New clsDBConnection
        conn.CreateOpenConnection()
        Dim itemcatcode As String = "222"
        If Not Me.RadioButton1.Checked Then
            itemcatcode = "333"
        End If
        Dim strSQL As String = "select * from items where itemcatcode in ('" & itemcatcode & "')    and isactive=1 order by itemdescription"
        Dim command As New SqlCommand(strSQL, conn.GDBConn)
        command.CommandType = CommandType.Text
        Dim dt As New DataTable
        Dim da As SqlDataAdapter = New SqlDataAdapter(command)
        da.SelectCommand.CommandTimeout = 0
        da.Fill(dt)

        Me.cmbTestName.DataSource = dt
        Me.cmbTestName.ValueMember = "ItemCode"
        Me.cmbTestName.DisplayMember = "ItemDescription"
        'Me.cmbTestName.SelectedIndex = 0
    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadDiagnosticItems() 
        requestdetailno = Me.txtRequestDetailNo.Text
        testname = Me.cmbTestName.Text
    End Sub

    
    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        LoadDiagnosticItems()
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        LoadDiagnosticItems()
    End Sub
End Class
