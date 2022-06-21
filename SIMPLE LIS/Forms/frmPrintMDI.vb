Imports System.IO
Public Class frmPrintMDI
    Public requestdetailno As Long
    Public rtfLocation As String
    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub frmPrintMDI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim frm As New frmRTFPrint
        Dim theight As Integer = frm.RichTextBox1.Height
        If File.Exists(rtfLocation) Then
            frm.RichTextBox1.LoadFile(rtfLocation)
        End If
        frm.Height = frm.Height + frm.RichTextBox1.Height - theight
        frm.lock()
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class