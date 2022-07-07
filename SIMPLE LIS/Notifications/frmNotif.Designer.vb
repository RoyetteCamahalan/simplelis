<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotif
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.panelheader = New System.Windows.Forms.Panel()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btnsettings = New System.Windows.Forms.Button()
        Me.panelheader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.CadetBlue
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(355, 58)
        Me.Panel1.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 6000
        '
        'panelheader
        '
        Me.panelheader.BackColor = System.Drawing.Color.White
        Me.panelheader.Controls.Add(Me.btnclose)
        Me.panelheader.Controls.Add(Me.btnsettings)
        Me.panelheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelheader.Location = New System.Drawing.Point(1, 1)
        Me.panelheader.Name = "panelheader"
        Me.panelheader.Size = New System.Drawing.Size(355, 26)
        Me.panelheader.TabIndex = 0
        '
        'btnclose
        '
        Me.btnclose.FlatAppearance.BorderSize = 0
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Image = Global.SIMPLE_LIS.My.Resources.Resources.delete_16x16
        Me.btnclose.Location = New System.Drawing.Point(328, 1)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(28, 23)
        Me.btnclose.TabIndex = 9
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btnsettings
        '
        Me.btnsettings.FlatAppearance.BorderSize = 0
        Me.btnsettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsettings.Image = Global.SIMPLE_LIS.My.Resources.Resources.ic_gear_16
        Me.btnsettings.Location = New System.Drawing.Point(298, 2)
        Me.btnsettings.Name = "btnsettings"
        Me.btnsettings.Size = New System.Drawing.Size(28, 23)
        Me.btnsettings.TabIndex = 8
        Me.btnsettings.UseVisualStyleBackColor = True
        '
        'frmNotif
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CadetBlue
        Me.ClientSize = New System.Drawing.Size(357, 86)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panelheader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmNotif"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.panelheader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents panelheader As System.Windows.Forms.Panel
    Friend WithEvents btnsettings As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
End Class
