Public Class frmCustomDialog
    Public issave As Boolean
    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        issave = True
        Me.Close()
    End Sub
End Class