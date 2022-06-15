<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddField
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddField))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFieldType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtfieldname = New System.Windows.Forms.TextBox()
        Me.txtvalue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLabelText = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbDefaultValue = New System.Windows.Forms.ComboBox()
        Me.txtX = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtY = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtheight = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtwidth = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panelfieldtype = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.paneltextreg = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.paneltextrtf = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtfieldlabelrtf = New System.Windows.Forms.RichTextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panelfieldtype.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.paneltextreg.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.paneltextrtf.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSave, Me.tsClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(470, 38)
        Me.ToolStrip1.TabIndex = 44
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSave
        '
        Me.tsSave.Image = CType(resources.GetObject("tsSave.Image"), System.Drawing.Image)
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(35, 35)
        Me.tsSave.Text = "Save"
        Me.tsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsClose
        '
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(40, 35)
        Me.tsClose.Text = "Close"
        Me.tsClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 234
        Me.Label2.Text = "Field Type:"
        '
        'cmbFieldType
        '
        Me.cmbFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFieldType.Font = New System.Drawing.Font("Cambria", 9.25!)
        Me.cmbFieldType.FormattingEnabled = True
        Me.cmbFieldType.Location = New System.Drawing.Point(113, 10)
        Me.cmbFieldType.Name = "cmbFieldType"
        Me.cmbFieldType.Size = New System.Drawing.Size(310, 22)
        Me.cmbFieldType.TabIndex = 235
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 236
        Me.Label1.Text = "Field Name:"
        '
        'txtfieldname
        '
        Me.txtfieldname.Font = New System.Drawing.Font("Cambria", 9.25!)
        Me.txtfieldname.Location = New System.Drawing.Point(113, 11)
        Me.txtfieldname.Name = "txtfieldname"
        Me.txtfieldname.Size = New System.Drawing.Size(310, 22)
        Me.txtfieldname.TabIndex = 237
        '
        'txtvalue
        '
        Me.txtvalue.Font = New System.Drawing.Font("Cambria", 9.25!)
        Me.txtvalue.Location = New System.Drawing.Point(113, 29)
        Me.txtvalue.Multiline = True
        Me.txtvalue.Name = "txtvalue"
        Me.txtvalue.Size = New System.Drawing.Size(310, 65)
        Me.txtvalue.TabIndex = 239
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 238
        Me.Label3.Text = "Value Options:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Label4.Location = New System.Drawing.Point(111, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(312, 25)
        Me.Label4.TabIndex = 240
        Me.Label4.Text = "Enter valid options for dropdown fields. Separate each value with semi-colon "";"""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 15)
        Me.Label5.TabIndex = 241
        Me.Label5.Text = "Default Value:"
        '
        'txtLabelText
        '
        Me.txtLabelText.Font = New System.Drawing.Font("Cambria", 9.25!)
        Me.txtLabelText.Location = New System.Drawing.Point(113, 9)
        Me.txtLabelText.Name = "txtLabelText"
        Me.txtLabelText.Size = New System.Drawing.Size(310, 22)
        Me.txtLabelText.TabIndex = 244
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(26, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 15)
        Me.Label6.TabIndex = 243
        Me.Label6.Text = "Text:"
        '
        'cmbDefaultValue
        '
        Me.cmbDefaultValue.Font = New System.Drawing.Font("Cambria", 9.25!)
        Me.cmbDefaultValue.FormattingEnabled = True
        Me.cmbDefaultValue.Location = New System.Drawing.Point(113, 10)
        Me.cmbDefaultValue.MaxLength = 2000
        Me.cmbDefaultValue.Name = "cmbDefaultValue"
        Me.cmbDefaultValue.Size = New System.Drawing.Size(310, 22)
        Me.cmbDefaultValue.TabIndex = 245
        '
        'txtX
        '
        Me.txtX.Font = New System.Drawing.Font("Cambria", 9.25!)
        Me.txtX.Location = New System.Drawing.Point(113, 9)
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(132, 22)
        Me.txtX.TabIndex = 247
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(26, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 15)
        Me.Label7.TabIndex = 246
        Me.Label7.Text = "Location X:"
        '
        'txtY
        '
        Me.txtY.Font = New System.Drawing.Font("Cambria", 9.25!)
        Me.txtY.Location = New System.Drawing.Point(298, 9)
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(125, 22)
        Me.txtY.TabIndex = 248
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(280, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 15)
        Me.Label8.TabIndex = 249
        Me.Label8.Text = "Y:"
        '
        'txtheight
        '
        Me.txtheight.Font = New System.Drawing.Font("Cambria", 9.25!)
        Me.txtheight.Location = New System.Drawing.Point(298, 8)
        Me.txtheight.Name = "txtheight"
        Me.txtheight.Size = New System.Drawing.Size(125, 22)
        Me.txtheight.TabIndex = 251
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Cambria", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(249, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 15)
        Me.Label9.TabIndex = 250
        Me.Label9.Text = "Height:"
        '
        'txtwidth
        '
        Me.txtwidth.Font = New System.Drawing.Font("Cambria", 9.25!)
        Me.txtwidth.Location = New System.Drawing.Point(113, 8)
        Me.txtwidth.Name = "txtwidth"
        Me.txtwidth.Size = New System.Drawing.Size(132, 22)
        Me.txtwidth.TabIndex = 253
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Cambria", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(26, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 15)
        Me.Label10.TabIndex = 252
        Me.Label10.Text = "Width:"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.paneltextrtf)
        Me.Panel1.Controls.Add(Me.paneltextreg)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.panelfieldtype)
        Me.Panel1.Location = New System.Drawing.Point(12, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(448, 430)
        Me.Panel1.TabIndex = 254
        '
        'panelfieldtype
        '
        Me.panelfieldtype.Controls.Add(Me.Label2)
        Me.panelfieldtype.Controls.Add(Me.cmbFieldType)
        Me.panelfieldtype.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelfieldtype.Location = New System.Drawing.Point(0, 0)
        Me.panelfieldtype.Name = "panelfieldtype"
        Me.panelfieldtype.Size = New System.Drawing.Size(448, 39)
        Me.panelfieldtype.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtfieldname)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 39)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(448, 39)
        Me.Panel2.TabIndex = 1
        '
        'paneltextreg
        '
        Me.paneltextreg.Controls.Add(Me.txtLabelText)
        Me.paneltextreg.Controls.Add(Me.Label6)
        Me.paneltextreg.Dock = System.Windows.Forms.DockStyle.Top
        Me.paneltextreg.Location = New System.Drawing.Point(0, 78)
        Me.paneltextreg.Name = "paneltextreg"
        Me.paneltextreg.Size = New System.Drawing.Size(448, 39)
        Me.paneltextreg.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.txtvalue)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 203)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(448, 109)
        Me.Panel4.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.cmbDefaultValue)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 312)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(448, 39)
        Me.Panel5.TabIndex = 4
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.txtY)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.txtX)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 351)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(448, 39)
        Me.Panel6.TabIndex = 5
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.txtwidth)
        Me.Panel7.Controls.Add(Me.Label9)
        Me.Panel7.Controls.Add(Me.Label10)
        Me.Panel7.Controls.Add(Me.txtheight)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 390)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(448, 39)
        Me.Panel7.TabIndex = 6
        '
        'paneltextrtf
        '
        Me.paneltextrtf.Controls.Add(Me.txtfieldlabelrtf)
        Me.paneltextrtf.Controls.Add(Me.Label11)
        Me.paneltextrtf.Dock = System.Windows.Forms.DockStyle.Top
        Me.paneltextrtf.Location = New System.Drawing.Point(0, 117)
        Me.paneltextrtf.Name = "paneltextrtf"
        Me.paneltextrtf.Size = New System.Drawing.Size(448, 86)
        Me.paneltextrtf.TabIndex = 7
        Me.paneltextrtf.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Cambria", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(26, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 15)
        Me.Label11.TabIndex = 244
        Me.Label11.Text = "Text:"
        '
        'txtfieldlabelrtf
        '
        Me.txtfieldlabelrtf.Location = New System.Drawing.Point(113, 3)
        Me.txtfieldlabelrtf.Name = "txtfieldlabelrtf"
        Me.txtfieldlabelrtf.Size = New System.Drawing.Size(310, 77)
        Me.txtfieldlabelrtf.TabIndex = 245
        Me.txtfieldlabelrtf.Text = ""
        '
        'frmAddField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 483)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAddField"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Field"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.panelfieldtype.ResumeLayout(False)
        Me.panelfieldtype.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.paneltextreg.ResumeLayout(False)
        Me.paneltextreg.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.paneltextrtf.ResumeLayout(False)
        Me.paneltextrtf.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents tsSave As System.Windows.Forms.ToolStripButton
    Public WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbFieldType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtfieldname As System.Windows.Forms.TextBox
    Friend WithEvents txtvalue As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLabelText As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbDefaultValue As System.Windows.Forms.ComboBox
    Friend WithEvents txtX As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtY As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtheight As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtwidth As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents paneltextrtf As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents paneltextreg As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents panelfieldtype As System.Windows.Forms.Panel
    Friend WithEvents txtfieldlabelrtf As System.Windows.Forms.RichTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
