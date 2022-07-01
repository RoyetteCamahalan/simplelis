Public Class frmAvailableColors

    Private Sub frmAvailableColors_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For Each d As String In [Enum].GetNames(GetType(KnownColor))
            Me.DataGridView1.Rows.Add(1)
            Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(1).Value = d
            Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(0).Style.BackColor = System.Drawing.Color.FromName(d)
            Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Cells(0).Style.SelectionBackColor = System.Drawing.Color.FromName(d)
        Next
    End Sub

    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub
End Class