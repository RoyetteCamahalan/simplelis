Public Class CustomGrid
    Inherits DataGridView

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Enter Then
            Return False
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class
