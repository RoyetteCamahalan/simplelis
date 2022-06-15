Public Class frmLaboratory
    Private laboratoryid As Long

    Public myformstatus As formstatus

    Public issave As Boolean
    Enum formstatus
        add = 0
        edit = 1
        view = 2
    End Enum

    Private erp As New ErrorProvider
    Public Sub New(ByVal myformstatus As formstatus, Optional ByVal laboratoryid As Long = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.myformstatus = myformstatus
        Me.laboratoryid = laboratoryid
    End Sub
    Private Sub frmAddField_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Me.myformstatus <> formstatus.add Then
            Call LoadRecord()
        End If
    End Sub
    Private Sub LoadRecord()
        Dim dtRecord As DataTable = clsExamination.genericcls(8, Me.laboratoryid)
        If dtRecord.Rows.Count = 0 Then
            Exit Sub
        End If
        With dtRecord.Rows(0)
            Me.txtlabname.Text = Utility.NullToEmptyString(.Item("description"))
            Me.txtresulttitle.Text = Utility.NullToEmptyString(.Item("title"))
            Me.chkisactive.Checked = Utility.NullToBoolean(.Item("isactive"))
        End With
    End Sub

    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click
        If MsgBox("Do you want to save this laboratory?", MsgBoxStyle.YesNo, "") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If Me.txtlabname.Text = "" Then
            erp.SetError(Me.txtlabname, "This field is required")
            Exit Sub
        End If
        erp.SetError(Me.txtlabname, "")

        clsExamination.saveLaboratory(Me.laboratoryid, Me.txtlabname.Text, Me.txtresulttitle.Text, Me.chkisactive.Checked)
        Me.issave = True
        Me.Close()
    End Sub

    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub
End Class