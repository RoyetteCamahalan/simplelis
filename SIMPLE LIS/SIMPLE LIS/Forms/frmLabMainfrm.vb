Public Class frmLabMainfrm

    Dim myFormStatus As enFormStatus
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
    Private Sub frmLabMainfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dgvExamTypes.DataSource = clsExamination.getLabtypes()
    End Sub
    Private Sub dgvExamTypes_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvExamTypes.DataError
        If TypeOf (e.Exception) Is ConstraintException Then
            Dim view As DataGridView = DirectCast(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex).ErrorText = "an error"
            e.ThrowException = False
        End If
    End Sub
    Private Sub btnSchema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSchema.Click
        manageOrSchema(False)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        manageOrSchema(True)
    End Sub
    Private Sub manageOrSchema(ByVal IsSchema As Boolean)
        For ctr = 0 To Me.dgvExamTypes.Rows.Count - 1
            If Me.dgvExamTypes.Rows(ctr).Cells(0).Value = True Then
                Dim frm As New frmMDIParent(frmMDIParent.enFormStatus.add)
                frm.enbl = True
                frm.frm = Me.dgvExamTypes.Rows(ctr).Cells(2).Value
                frm.IsSelected = IsSchema
                frm.requestdetailno = 1
                frm.patientNO = "23456"
                frm.myResult = frmMDIParent.enResult.manageresult
                frm.ShowDialog()
                Me.dgvExamTypes.Rows(ctr).Cells(0).Value = CheckState.Unchecked
            End If
        Next
    End Sub
    Private Sub Result(ByVal IsResult As Boolean)
        For ctr = 0 To Me.dgvExamTypes.Rows.Count - 1
            If Me.dgvExamTypes.Rows(ctr).Cells(0).Value = True Then
                Dim frm As New frmMDIParent(frmMDIParent.enFormStatus.edit)
                frm.enbl = True
                frm.frm = Me.dgvExamTypes.Rows(ctr).Cells(2).Value
                frm.IsSelected = IsResult
                frm.requestdetailno = 1
                frm.patientNO = "23456"
                frm.myResult = frmMDIParent.enResult.releaseresult
                frm.ShowDialog()
                Me.dgvExamTypes.Rows(ctr).Cells(0).Value = CheckState.Unchecked
            End If
        Next
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub dgvExamTypes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExamTypes.CellContentClick
        Dim isSlected As Integer = Me.dgvExamTypes.CurrentRow.Index
        For i = 0 To Me.dgvExamTypes.Rows.Count - 1
            If i <> isSlected Then
                Me.dgvExamTypes.Rows(i).Cells(0).Value = CheckState.Unchecked
            End If
        Next
    End Sub
    Private Sub dgvExamTypes_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvExamTypes.CurrentCellDirtyStateChanged
        If Me.dgvExamTypes.IsCurrentCellDirty Then
            Me.dgvExamTypes.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Result(True)
    End Sub
    Private Sub dgvExamTypes_RowPostPaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvExamTypes.RowPostPaint
        Dim myBitmap As New Bitmap(ImageList1.Images(0))
        Dim myIcon As Icon = Icon.FromHandle(myBitmap.GetHicon())
        Dim graphics As Graphics = e.Graphics
        Dim iconHeight As Integer = 16
        Dim iconWidth As Integer = 16
        Dim xPosition As Integer = e.RowBounds.X + (dgvExamTypes.RowHeadersWidth / 14)
        Dim yPosition As Integer = e.RowBounds.Y + ((dgvExamTypes.Rows(e.RowIndex).Height - iconHeight) \ 3)
        Dim rectangle As New Rectangle(xPosition, yPosition, iconWidth, iconHeight)
        graphics.DrawIcon(myIcon, rectangle)
    End Sub
End Class