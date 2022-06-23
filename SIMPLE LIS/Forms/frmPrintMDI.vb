Imports System.IO
Public Class frmPrintMDI
    Public requestdetailno As Long
    Public rtfLocation As String
    Private frm As New frmRTFPrint
    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub frmPrintMDI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        frm.requestdetailno = Me.requestdetailno
        Dim rtfcontainer As New RichTextBox
        frm.Controls.Add(rtfcontainer)
        rtfcontainer.BorderStyle = BorderStyle.None
        rtfcontainer.BackColor = Color.White
        rtfcontainer.ReadOnly = True
        rtfcontainer.Size = New Size(690, 100)
        rtfcontainer.Location = New Point(47, 177)
        AddHandler rtfcontainer.ContentsResized, AddressOf RichTextBox1_ContentsResized
        Dim theight As Integer = rtfcontainer.Height
        If File.Exists(rtfLocation) Then
            rtfcontainer.LoadFile(rtfLocation)
        End If
        frm.Height = frm.Height + rtfcontainer.Height - theight
        frm.MdiParent = Me
        frm.Show()
        '
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        frm.DisplayPrintPreview()
    End Sub
    Private Sub RichTextBox1_ContentsResized(sender As System.Object, e As System.Windows.Forms.ContentsResizedEventArgs)
        sender.Height = e.NewRectangle.Height + 12
    End Sub
End Class