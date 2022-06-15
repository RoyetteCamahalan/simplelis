Public Class frmEnlargeImage
    Private Sub pctreenlarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctreenlarge.Click
        Me.Close()
    End Sub
    Private Sub frmEnlargeImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Opacity = 0.99
        Dim iCount As Integer
        For iCount = 90 To 10 Step -10
            Me.Opacity = iCount / 100
            Me.Refresh()
            Threading.Thread.Sleep(50)
        Next
        Me.Opacity = 100
    End Sub
End Class