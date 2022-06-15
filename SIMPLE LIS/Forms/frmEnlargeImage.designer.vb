<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnlargeImage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pctreenlarge = New System.Windows.Forms.PictureBox()
        CType(Me.pctreenlarge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pctreenlarge
        '
        Me.pctreenlarge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctreenlarge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pctreenlarge.Location = New System.Drawing.Point(0, 0)
        Me.pctreenlarge.Name = "pctreenlarge"
        Me.pctreenlarge.Size = New System.Drawing.Size(1057, 607)
        Me.pctreenlarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctreenlarge.TabIndex = 0
        Me.pctreenlarge.TabStop = False
        '
        'frmEnlargeImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 607)
        Me.Controls.Add(Me.pctreenlarge)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmEnlargeImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmEnlargeImage"
        CType(Me.pctreenlarge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents pctreenlarge As System.Windows.Forms.PictureBox
End Class
