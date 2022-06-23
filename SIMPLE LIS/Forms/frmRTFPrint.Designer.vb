<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRTFPrint
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
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblPatientname = New System.Windows.Forms.Label()
        Me.MiscPrintDocu = New System.Drawing.Printing.PrintDocument()
        Me.lablTelNo = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.txtPatientName = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.pctrLogo = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbltestdate = New System.Windows.Forms.Label()
        Me.lblprintdate = New System.Windows.Forms.Label()
        Me.lblradiolicense = New System.Windows.Forms.Label()
        Me.lblradiodesignation = New System.Windows.Forms.Label()
        Me.panelpatho = New System.Windows.Forms.Panel()
        Me.txtResult = New System.Windows.Forms.RichTextBox()
        Me.lblradiologist = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblptno = New System.Windows.Forms.Label()
        Me.lblpatientaddress = New System.Windows.Forms.Label()
        Me.lblexamination = New System.Windows.Forms.Label()
        Me.lblbirthdate = New System.Windows.Forms.Label()
        Me.lblagesex = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelpatho.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.BackColor = System.Drawing.Color.Transparent
        Me.lblGender.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblGender.ForeColor = System.Drawing.Color.Black
        Me.lblGender.Location = New System.Drawing.Point(44, 133)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(77, 18)
        Me.lblGender.TabIndex = 212
        Me.lblGender.Text = "Patient No:"
        '
        'lblPatientname
        '
        Me.lblPatientname.AutoSize = True
        Me.lblPatientname.BackColor = System.Drawing.Color.Transparent
        Me.lblPatientname.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblPatientname.ForeColor = System.Drawing.Color.Black
        Me.lblPatientname.Location = New System.Drawing.Point(44, 93)
        Me.lblPatientname.Name = "lblPatientname"
        Me.lblPatientname.Size = New System.Drawing.Size(49, 18)
        Me.lblPatientname.TabIndex = 206
        Me.lblPatientname.Text = "Name:"
        '
        'MiscPrintDocu
        '
        '
        'lablTelNo
        '
        Me.lablTelNo.BackColor = System.Drawing.Color.Transparent
        Me.lablTelNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lablTelNo.ForeColor = System.Drawing.Color.Black
        Me.lablTelNo.Location = New System.Drawing.Point(222, 48)
        Me.lablTelNo.Name = "lablTelNo"
        Me.lablTelNo.Size = New System.Drawing.Size(392, 37)
        Me.lablTelNo.TabIndex = 248
        Me.lablTelNo.Text = "xxxx"
        Me.lablTelNo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblAddress
        '
        Me.lblAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblAddress.ForeColor = System.Drawing.Color.Black
        Me.lblAddress.Location = New System.Drawing.Point(219, 30)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(395, 18)
        Me.lblAddress.TabIndex = 247
        Me.lblAddress.Text = "Address"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Black
        Me.lblHeader.Location = New System.Drawing.Point(222, 9)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(392, 21)
        Me.lblHeader.TabIndex = 246
        Me.lblHeader.Text = "LUTHERAN HOSPITAL INCORPORATED"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPatientName
        '
        Me.txtPatientName.BackColor = System.Drawing.Color.Transparent
        Me.txtPatientName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtPatientName.ForeColor = System.Drawing.Color.Black
        Me.txtPatientName.Location = New System.Drawing.Point(93, 93)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.Size = New System.Drawing.Size(454, 18)
        Me.txtPatientName.TabIndex = 257
        Me.txtPatientName.Text = "NAME"
        Me.txtPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.MiscPrintDocu
        Me.PrintDialog1.UseEXDialog = True
        '
        'pctrLogo
        '
        Me.pctrLogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.pctrLogo.Location = New System.Drawing.Point(123, 7)
        Me.pctrLogo.Name = "pctrLogo"
        Me.pctrLogo.Size = New System.Drawing.Size(98, 86)
        Me.pctrLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctrLogo.TabIndex = 245
        Me.pctrLogo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(44, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 18)
        Me.Label1.TabIndex = 264
        Me.Label1.Text = "Address:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(549, 135)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 17)
        Me.Label7.TabIndex = 273
        Me.Label7.Text = "Test Date:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(549, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 17)
        Me.Label8.TabIndex = 274
        Me.Label8.Text = "Print Date:"
        '
        'lbltestdate
        '
        Me.lbltestdate.BackColor = System.Drawing.Color.Transparent
        Me.lbltestdate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lbltestdate.ForeColor = System.Drawing.Color.Black
        Me.lbltestdate.Location = New System.Drawing.Point(613, 134)
        Me.lbltestdate.Name = "lbltestdate"
        Me.lbltestdate.Size = New System.Drawing.Size(118, 18)
        Me.lbltestdate.TabIndex = 275
        Me.lbltestdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblprintdate
        '
        Me.lblprintdate.BackColor = System.Drawing.Color.Transparent
        Me.lblprintdate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lblprintdate.ForeColor = System.Drawing.Color.Black
        Me.lblprintdate.Location = New System.Drawing.Point(622, 155)
        Me.lblprintdate.Name = "lblprintdate"
        Me.lblprintdate.Size = New System.Drawing.Size(115, 18)
        Me.lblprintdate.TabIndex = 276
        Me.lblprintdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblradiolicense
        '
        Me.lblradiolicense.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblradiolicense.BackColor = System.Drawing.Color.Transparent
        Me.lblradiolicense.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblradiolicense.ForeColor = System.Drawing.Color.Black
        Me.lblradiolicense.Location = New System.Drawing.Point(412, 358)
        Me.lblradiolicense.Name = "lblradiolicense"
        Me.lblradiolicense.Size = New System.Drawing.Size(319, 18)
        Me.lblradiolicense.TabIndex = 256
        Me.lblradiolicense.Text = "License No."
        Me.lblradiolicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblradiodesignation
        '
        Me.lblradiodesignation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblradiodesignation.BackColor = System.Drawing.Color.Transparent
        Me.lblradiodesignation.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblradiodesignation.ForeColor = System.Drawing.Color.Black
        Me.lblradiodesignation.Location = New System.Drawing.Point(409, 373)
        Me.lblradiodesignation.Name = "lblradiodesignation"
        Me.lblradiodesignation.Size = New System.Drawing.Size(326, 18)
        Me.lblradiodesignation.TabIndex = 255
        Me.lblradiodesignation.Text = "Clinical Pathologist"
        Me.lblradiodesignation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelpatho
        '
        Me.panelpatho.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelpatho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.panelpatho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelpatho.Controls.Add(Me.txtResult)
        Me.panelpatho.Controls.Add(Me.lblradiologist)
        Me.panelpatho.Location = New System.Drawing.Point(377, 304)
        Me.panelpatho.Name = "panelpatho"
        Me.panelpatho.Size = New System.Drawing.Size(360, 58)
        Me.panelpatho.TabIndex = 274
        '
        'txtResult
        '
        Me.txtResult.EnableAutoDragDrop = True
        Me.txtResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResult.Location = New System.Drawing.Point(-330, -117)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(690, 111)
        Me.txtResult.TabIndex = 281
        Me.txtResult.Text = ""
        '
        'lblradiologist
        '
        Me.lblradiologist.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblradiologist.BackColor = System.Drawing.Color.Transparent
        Me.lblradiologist.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblradiologist.ForeColor = System.Drawing.Color.Black
        Me.lblradiologist.Location = New System.Drawing.Point(25, 33)
        Me.lblradiologist.Name = "lblradiologist"
        Me.lblradiologist.Size = New System.Drawing.Size(327, 19)
        Me.lblradiologist.TabIndex = 273
        Me.lblradiologist.Text = "Radiologist Name"
        Me.lblradiologist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(549, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 282
        Me.Label2.Text = "DOB:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(549, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 283
        Me.Label3.Text = "Age/Sex:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(44, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 18)
        Me.Label4.TabIndex = 284
        Me.Label4.Text = "Examination:"
        '
        'lblptno
        '
        Me.lblptno.BackColor = System.Drawing.Color.Transparent
        Me.lblptno.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblptno.ForeColor = System.Drawing.Color.Black
        Me.lblptno.Location = New System.Drawing.Point(120, 134)
        Me.lblptno.Name = "lblptno"
        Me.lblptno.Size = New System.Drawing.Size(301, 18)
        Me.lblptno.TabIndex = 285
        Me.lblptno.Text = "ptno"
        Me.lblptno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblpatientaddress
        '
        Me.lblpatientaddress.BackColor = System.Drawing.Color.Transparent
        Me.lblpatientaddress.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblpatientaddress.ForeColor = System.Drawing.Color.Black
        Me.lblpatientaddress.Location = New System.Drawing.Point(107, 113)
        Me.lblpatientaddress.Name = "lblpatientaddress"
        Me.lblpatientaddress.Size = New System.Drawing.Size(440, 18)
        Me.lblpatientaddress.TabIndex = 265
        Me.lblpatientaddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblexamination
        '
        Me.lblexamination.BackColor = System.Drawing.Color.Transparent
        Me.lblexamination.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblexamination.ForeColor = System.Drawing.Color.Black
        Me.lblexamination.Location = New System.Drawing.Point(132, 155)
        Me.lblexamination.Name = "lblexamination"
        Me.lblexamination.Size = New System.Drawing.Size(415, 18)
        Me.lblexamination.TabIndex = 286
        Me.lblexamination.Text = "Exam"
        Me.lblexamination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblbirthdate
        '
        Me.lblbirthdate.BackColor = System.Drawing.Color.Transparent
        Me.lblbirthdate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lblbirthdate.ForeColor = System.Drawing.Color.Black
        Me.lblbirthdate.Location = New System.Drawing.Point(589, 114)
        Me.lblbirthdate.Name = "lblbirthdate"
        Me.lblbirthdate.Size = New System.Drawing.Size(118, 18)
        Me.lblbirthdate.TabIndex = 287
        Me.lblbirthdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblagesex
        '
        Me.lblagesex.BackColor = System.Drawing.Color.Transparent
        Me.lblagesex.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lblagesex.ForeColor = System.Drawing.Color.Black
        Me.lblagesex.Location = New System.Drawing.Point(608, 94)
        Me.lblagesex.Name = "lblagesex"
        Me.lblagesex.Size = New System.Drawing.Size(141, 18)
        Me.lblagesex.TabIndex = 288
        Me.lblagesex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewTextBoxColumn1.HeaderText = "Parameter"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridViewTextBoxColumn2.HeaderText = "Result"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 160
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle23
        Me.DataGridViewTextBoxColumn3.HeaderText = "Units"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle24
        Me.DataGridViewTextBoxColumn4.HeaderText = "Reference  Range"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 190
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "collabdetailid"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "collabresultdetailid"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(272, 210)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(386, 20)
        Me.TextBox1.TabIndex = 289
        Me.TextBox1.Text = "gffdgdfgdfgh  sd dl;syhm ldfty"
        '
        'frmRTFPrint
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(789, 396)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblagesex)
        Me.Controls.Add(Me.lblbirthdate)
        Me.Controls.Add(Me.lblexamination)
        Me.Controls.Add(Me.lblptno)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.panelpatho)
        Me.Controls.Add(Me.lblradiolicense)
        Me.Controls.Add(Me.lblradiodesignation)
        Me.Controls.Add(Me.lblprintdate)
        Me.Controls.Add(Me.lbltestdate)
        Me.Controls.Add(Me.pctrLogo)
        Me.Controls.Add(Me.lblpatientaddress)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPatientName)
        Me.Controls.Add(Me.lablTelNo)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.lblPatientname)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRTFPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TEST"
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelpatho.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents lblPatientname As System.Windows.Forms.Label
    Friend WithEvents MiscPrintDocu As System.Drawing.Printing.PrintDocument
    Friend WithEvents pctrLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lablTelNo As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents txtPatientName As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbltestdate As System.Windows.Forms.Label
    Friend WithEvents lblprintdate As System.Windows.Forms.Label
    Friend WithEvents lblradiolicense As System.Windows.Forms.Label
    Friend WithEvents lblradiodesignation As System.Windows.Forms.Label
    Friend WithEvents panelpatho As System.Windows.Forms.Panel
    Friend WithEvents lblradiologist As System.Windows.Forms.Label
    Friend WithEvents txtResult As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblptno As System.Windows.Forms.Label
    Friend WithEvents lblpatientaddress As System.Windows.Forms.Label
    Friend WithEvents lblexamination As System.Windows.Forms.Label
    Friend WithEvents lblbirthdate As System.Windows.Forms.Label
    Friend WithEvents lblagesex As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
