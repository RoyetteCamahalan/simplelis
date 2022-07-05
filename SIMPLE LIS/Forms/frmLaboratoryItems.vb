Public Class frmLaboratoryItems

    Private Sub frmLaboratoryItems_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        initForm()
    End Sub
#Region "Vars"

    Public issave As Boolean
    Private afterload As Boolean
#End Region
#Region "Methods"
    Public Sub initForm()
        Call loadDiagnostics()
    End Sub
    Private Sub loadDiagnostics()
        afterload = False
        With cmbDiagnostics
            .DataSource = clsExamination.getLabtypes()
            .DisplayMember = "Description"
            .ValueMember = "Code"
            .SelectedIndex = -1
            afterload = True
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub
    Private Sub loadItems()
        With Me.dgItems
            .Rows.Clear()
            Dim dt As DataTable = clsExamination.genericcls(6, Me.cmbDiagnostics.SelectedValue, Me.txtSearch.Text)
            For Each row As DataRow In dt.Rows
                .Rows.Add(1)
                .Rows(.Rows.Count - 1).Cells(collabno.Index).Value = row.Item("laboratoryno")
                .Rows(.Rows.Count - 1).Cells(colitemcode.Index).Value = row.Item("itemcode")
                .Rows(.Rows.Count - 1).Cells(colitemdesc.Index).Value = row.Item("itemdescription")
                .Rows(.Rows.Count - 1).Cells(colcategory.Index).Value = row.Item("itemcatdescription")
            Next
            Me.lblrecordcount.Text = dgItems.Rows.Count
        End With
    End Sub
#End Region

    Private Sub cmbDiagnostics_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDiagnostics.SelectedIndexChanged
        If afterload Then
            Call loadItems()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearch.TextChanged
        If afterload Then
            Call loadItems()
        End If
    End Sub

    Private Sub dgItems_CellPainting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgItems.CellPainting
        Try
            If e.ColumnIndex = colremove.Index AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                Dim bmpFind As Bitmap = modGlobal.delete_icon  'ImageList1.Images(1)
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 7, e.CellBounds.Top + 3)
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearch_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        If e.KeyCode = Keys.Enter And afterload Then
            Call loadItems()
        End If
    End Sub

    Private Sub btnadditemcategory_Click(sender As System.Object, e As System.EventArgs) Handles btnadditemcategory.Click
        Dim f As New frmSearchLaboratoryItems
        f.ShowDialog()
        If f.issave Then
            For Each itemcode As String In f.itemcodes
                clsExamination.addlabitem(Me.cmbDiagnostics.SelectedValue, itemcode)
            Next
            Call loadItems()
        End If
    End Sub

    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub dgItems_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgItems.CellContentClick
        Try
            If e.ColumnIndex = colremove.Index AndAlso e.RowIndex >= 0 Then
                clsExamination.removelabitem(Me.cmbDiagnostics.SelectedValue, Me.dgItems.Rows(e.RowIndex).Cells(colitemcode.Index).Value)
                dgItems.Rows.RemoveAt(e.RowIndex)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class