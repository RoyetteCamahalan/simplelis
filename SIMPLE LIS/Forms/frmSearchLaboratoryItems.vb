Public Class frmSearchLaboratoryItems

    Private Sub frmLaboratoryItems_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        initForm()
    End Sub
#Region "Vars"

    Public issave As Boolean
    Private afterload As Boolean
    Public itemcodes As New List(Of String)
#End Region
#Region "Methods"
    Public Sub initForm()
        afterload = True
        Me.ActiveControl = txtSearch
    End Sub
    Private Sub addtoselecteditem(ByVal itemcode As String)
        If Not itemcodes.Contains(itemcode) Then
            itemcodes.Add(itemcode)
        End If
    End Sub
    Private Sub removeitem(ByVal itemcode As String)
        If itemcodes.Contains(itemcode) Then
            itemcodes.Remove(itemcode)
        End If
    End Sub
    Private Sub loadItems()
        afterload = False
        With Me.dgItems
            .Rows.Clear()
            Dim dt As DataTable = clsExamination.genericcls(7, 0, Me.txtSearch.Text)
            For Each row As DataRow In dt.Rows
                .Rows.Add(1)
                If itemcodes.Contains(row.Item("itemcode")) Then
                    .Rows(.Rows.Count - 1).Cells(colselect.Index).Value = True
                End If
                .Rows(.Rows.Count - 1).Cells(colitemcode.Index).Value = row.Item("itemcode")
                .Rows(.Rows.Count - 1).Cells(colitemdesc.Index).Value = row.Item("itemdescription")
                .Rows(.Rows.Count - 1).Cells(colcategory.Index).Value = row.Item("itemcatdescription")
            Next
        End With
        afterload = True
    End Sub
#End Region
    Private Sub txtSearch_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        If e.KeyCode = Keys.Enter And afterload Then
            Call loadItems()
        End If
    End Sub

    Private Sub dgItems_CurrentCellDirtyStateChanged(sender As System.Object, e As System.EventArgs) Handles dgItems.CurrentCellDirtyStateChanged
        If afterload Then
            Dim dgCheckBox As DataGridViewCheckBoxCell
            Try
                If dgItems.CurrentCellAddress.X = colselect.Index Then
                    dgCheckBox = dgItems.CurrentRow.Cells(colselect.Index)

                    If (dgItems.IsCurrentCellDirty) Then
                        dgItems.CommitEdit(DataGridViewDataErrorContexts.Commit)

                        If dgCheckBox.Value Then
                            Call addtoselecteditem(dgItems.CurrentRow.Cells(colitemcode.Index).Value)
                        Else
                            Call removeitem(dgItems.CurrentRow.Cells(colitemcode.Index).Value)
                        End If

                    End If
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click
        If Me.itemcodes.Count > 0 Then
            Me.issave = True
            Me.Close()
        End If
    End Sub

    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub
End Class