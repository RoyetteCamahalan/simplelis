<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrossMatchingNew
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblMisc = New System.Windows.Forms.Label()
        Me.cmbMedtech = New System.Windows.Forms.ComboBox()
        Me.cmbPathologist = New System.Windows.Forms.ComboBox()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblpatientid = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblPatientname = New System.Windows.Forms.Label()
        Me.MiscPrintDocu = New System.Drawing.Printing.PrintDocument()
        Me.lablTelNo = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelmain = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblpatho = New System.Windows.Forms.TextBox()
        Me.lblmedtech = New System.Windows.Forms.TextBox()
        Me.lblpatholicense = New System.Windows.Forms.Label()
        Me.lblpathodesignation = New System.Windows.Forms.Label()
        Me.lblmedtechlicense = New System.Windows.Forms.Label()
        Me.lblmedtechdesignation = New System.Windows.Forms.Label()
        Me.panelresult = New System.Windows.Forms.Panel()
        Me.txtdonorblood = New System.Windows.Forms.TextBox()
        Me.txtpatientblood = New System.Windows.Forms.TextBox()
        Me.dgvCrossM = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbpatientrh = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbdonorsrh = New System.Windows.Forms.ComboBox()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape7 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.txtPatientName = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.Label()
        Me.txtGender = New System.Windows.Forms.Label()
        Me.txtRequestedby = New System.Windows.Forms.Label()
        Me.txtdate = New System.Windows.Forms.TextBox()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pctrLogo = New System.Windows.Forms.PictureBox()
        Me.panelmain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panelresult.SuspendLayout()
        CType(Me.dgvCrossM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMisc
        '
        Me.lblMisc.BackColor = System.Drawing.Color.Transparent
        Me.lblMisc.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMisc.ForeColor = System.Drawing.Color.Black
        Me.lblMisc.Location = New System.Drawing.Point(276, 91)
        Me.lblMisc.Name = "lblMisc"
        Me.lblMisc.Size = New System.Drawing.Size(286, 26)
        Me.lblMisc.TabIndex = 127
        Me.lblMisc.Text = "HEMATOLOGY"
        Me.lblMisc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbMedtech
        '
        Me.cmbMedtech.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbMedtech.BackColor = System.Drawing.Color.White
        Me.cmbMedtech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedtech.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbMedtech.FormattingEnabled = True
        Me.cmbMedtech.Location = New System.Drawing.Point(61, 24)
        Me.cmbMedtech.Name = "cmbMedtech"
        Me.cmbMedtech.Size = New System.Drawing.Size(326, 26)
        Me.cmbMedtech.TabIndex = 222
        '
        'cmbPathologist
        '
        Me.cmbPathologist.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbPathologist.BackColor = System.Drawing.Color.White
        Me.cmbPathologist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPathologist.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.cmbPathologist.FormattingEnabled = True
        Me.cmbPathologist.Location = New System.Drawing.Point(431, 24)
        Me.cmbPathologist.Name = "cmbPathologist"
        Me.cmbPathologist.Size = New System.Drawing.Size(320, 26)
        Me.cmbPathologist.TabIndex = 220
        '
        'dtDate
        '
        Me.dtDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtDate.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtDate.Location = New System.Drawing.Point(700, 110)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(151, 26)
        Me.dtDate.TabIndex = 218
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.White
        Me.lblDate.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(660, 119)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(41, 18)
        Me.lblDate.TabIndex = 217
        Me.lblDate.Text = "Date:"
        '
        'lblpatientid
        '
        Me.lblpatientid.AutoSize = True
        Me.lblpatientid.BackColor = System.Drawing.Color.Transparent
        Me.lblpatientid.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblpatientid.ForeColor = System.Drawing.Color.Black
        Me.lblpatientid.Location = New System.Drawing.Point(438, 141)
        Me.lblpatientid.Name = "lblpatientid"
        Me.lblpatientid.Size = New System.Drawing.Size(75, 18)
        Me.lblpatientid.TabIndex = 214
        Me.lblpatientid.Text = "Req. Phys: "
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.BackColor = System.Drawing.Color.Transparent
        Me.lblGender.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblGender.ForeColor = System.Drawing.Color.Black
        Me.lblGender.Location = New System.Drawing.Point(191, 141)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(34, 18)
        Me.lblGender.TabIndex = 212
        Me.lblGender.Text = "Sex:"
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.BackColor = System.Drawing.Color.Transparent
        Me.lblAge.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblAge.ForeColor = System.Drawing.Color.Black
        Me.lblAge.Location = New System.Drawing.Point(40, 141)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(36, 18)
        Me.lblAge.TabIndex = 210
        Me.lblAge.Text = "Age:"
        '
        'lblPatientname
        '
        Me.lblPatientname.AutoSize = True
        Me.lblPatientname.BackColor = System.Drawing.Color.Transparent
        Me.lblPatientname.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblPatientname.ForeColor = System.Drawing.Color.Black
        Me.lblPatientname.Location = New System.Drawing.Point(40, 119)
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
        Me.lablTelNo.Location = New System.Drawing.Point(272, 63)
        Me.lablTelNo.Name = "lablTelNo"
        Me.lablTelNo.Size = New System.Drawing.Size(290, 14)
        Me.lablTelNo.TabIndex = 248
        Me.lablTelNo.Text = "xxxx"
        Me.lablTelNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lablTelNo.Visible = False
        '
        'lblAddress
        '
        Me.lblAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblAddress.ForeColor = System.Drawing.Color.Black
        Me.lblAddress.Location = New System.Drawing.Point(272, 46)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(290, 18)
        Me.lblAddress.TabIndex = 247
        Me.lblAddress.Text = "Address"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblHeader.Location = New System.Drawing.Point(270, 9)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(293, 21)
        Me.lblHeader.TabIndex = 246
        Me.lblHeader.Text = "LUTHERAN HOSPITAL INCORPORATED"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(273, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(290, 20)
        Me.Label1.TabIndex = 249
        Me.Label1.Text = " CLINICAL LABORATORY"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelmain
        '
        Me.panelmain.Controls.Add(Me.Panel2)
        Me.panelmain.Controls.Add(Me.panelresult)
        Me.panelmain.Location = New System.Drawing.Point(37, 170)
        Me.panelmain.Name = "panelmain"
        Me.panelmain.Size = New System.Drawing.Size(821, 348)
        Me.panelmain.TabIndex = 250
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblpatho)
        Me.Panel2.Controls.Add(Me.lblmedtech)
        Me.Panel2.Controls.Add(Me.cmbMedtech)
        Me.Panel2.Controls.Add(Me.cmbPathologist)
        Me.Panel2.Controls.Add(Me.lblpatholicense)
        Me.Panel2.Controls.Add(Me.lblpathodesignation)
        Me.Panel2.Controls.Add(Me.lblmedtechlicense)
        Me.Panel2.Controls.Add(Me.lblmedtechdesignation)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 261)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(821, 84)
        Me.Panel2.TabIndex = 253
        '
        'lblpatho
        '
        Me.lblpatho.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblpatho.BackColor = System.Drawing.Color.White
        Me.lblpatho.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblpatho.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblpatho.Location = New System.Drawing.Point(431, 29)
        Me.lblpatho.Name = "lblpatho"
        Me.lblpatho.ReadOnly = True
        Me.lblpatho.Size = New System.Drawing.Size(320, 19)
        Me.lblpatho.TabIndex = 258
        Me.lblpatho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lblpatho.Visible = False
        '
        'lblmedtech
        '
        Me.lblmedtech.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblmedtech.BackColor = System.Drawing.Color.White
        Me.lblmedtech.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblmedtech.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblmedtech.Location = New System.Drawing.Point(61, 29)
        Me.lblmedtech.Name = "lblmedtech"
        Me.lblmedtech.ReadOnly = True
        Me.lblmedtech.Size = New System.Drawing.Size(326, 19)
        Me.lblmedtech.TabIndex = 257
        Me.lblmedtech.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.lblmedtech.Visible = False
        '
        'lblpatholicense
        '
        Me.lblpatholicense.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblpatholicense.BackColor = System.Drawing.Color.Transparent
        Me.lblpatholicense.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblpatholicense.ForeColor = System.Drawing.Color.Black
        Me.lblpatholicense.Location = New System.Drawing.Point(425, 48)
        Me.lblpatholicense.Name = "lblpatholicense"
        Me.lblpatholicense.Size = New System.Drawing.Size(329, 18)
        Me.lblpatholicense.TabIndex = 256
        Me.lblpatholicense.Text = "License No."
        Me.lblpatholicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblpathodesignation
        '
        Me.lblpathodesignation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblpathodesignation.BackColor = System.Drawing.Color.Transparent
        Me.lblpathodesignation.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblpathodesignation.ForeColor = System.Drawing.Color.Black
        Me.lblpathodesignation.Location = New System.Drawing.Point(428, 63)
        Me.lblpathodesignation.Name = "lblpathodesignation"
        Me.lblpathodesignation.Size = New System.Drawing.Size(326, 18)
        Me.lblpathodesignation.TabIndex = 255
        Me.lblpathodesignation.Text = "Clinical Pathologist"
        Me.lblpathodesignation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblmedtechlicense
        '
        Me.lblmedtechlicense.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblmedtechlicense.BackColor = System.Drawing.Color.Transparent
        Me.lblmedtechlicense.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblmedtechlicense.ForeColor = System.Drawing.Color.Black
        Me.lblmedtechlicense.Location = New System.Drawing.Point(58, 48)
        Me.lblmedtechlicense.Name = "lblmedtechlicense"
        Me.lblmedtechlicense.Size = New System.Drawing.Size(329, 18)
        Me.lblmedtechlicense.TabIndex = 253
        Me.lblmedtechlicense.Text = "License No."
        Me.lblmedtechlicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblmedtechdesignation
        '
        Me.lblmedtechdesignation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblmedtechdesignation.BackColor = System.Drawing.Color.Transparent
        Me.lblmedtechdesignation.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblmedtechdesignation.ForeColor = System.Drawing.Color.Black
        Me.lblmedtechdesignation.Location = New System.Drawing.Point(61, 63)
        Me.lblmedtechdesignation.Name = "lblmedtechdesignation"
        Me.lblmedtechdesignation.Size = New System.Drawing.Size(326, 18)
        Me.lblmedtechdesignation.TabIndex = 252
        Me.lblmedtechdesignation.Text = "Medical Technologist"
        Me.lblmedtechdesignation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelresult
        '
        Me.panelresult.Controls.Add(Me.txtdonorblood)
        Me.panelresult.Controls.Add(Me.txtpatientblood)
        Me.panelresult.Controls.Add(Me.dgvCrossM)
        Me.panelresult.Controls.Add(Me.Label2)
        Me.panelresult.Controls.Add(Me.cmbpatientrh)
        Me.panelresult.Controls.Add(Me.Label4)
        Me.panelresult.Controls.Add(Me.cmbdonorsrh)
        Me.panelresult.Controls.Add(Me.ShapeContainer2)
        Me.panelresult.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelresult.Location = New System.Drawing.Point(0, 0)
        Me.panelresult.Name = "panelresult"
        Me.panelresult.Size = New System.Drawing.Size(821, 261)
        Me.panelresult.TabIndex = 252
        '
        'txtdonorblood
        '
        Me.txtdonorblood.BackColor = System.Drawing.Color.White
        Me.txtdonorblood.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtdonorblood.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.txtdonorblood.Location = New System.Drawing.Point(633, 13)
        Me.txtdonorblood.Name = "txtdonorblood"
        Me.txtdonorblood.ReadOnly = True
        Me.txtdonorblood.Size = New System.Drawing.Size(180, 19)
        Me.txtdonorblood.TabIndex = 263
        Me.txtdonorblood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtdonorblood.Visible = False
        '
        'txtpatientblood
        '
        Me.txtpatientblood.BackColor = System.Drawing.Color.White
        Me.txtpatientblood.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtpatientblood.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.txtpatientblood.Location = New System.Drawing.Point(145, 13)
        Me.txtpatientblood.Name = "txtpatientblood"
        Me.txtpatientblood.ReadOnly = True
        Me.txtpatientblood.Size = New System.Drawing.Size(180, 19)
        Me.txtpatientblood.TabIndex = 262
        Me.txtpatientblood.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtpatientblood.Visible = False
        '
        'dgvCrossM
        '
        Me.dgvCrossM.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCrossM.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCrossM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCrossM.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCrossM.Location = New System.Drawing.Point(6, 44)
        Me.dgvCrossM.Name = "dgvCrossM"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCrossM.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCrossM.Size = New System.Drawing.Size(808, 211)
        Me.dgvCrossM.TabIndex = 210
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 14)
        Me.Label2.TabIndex = 209
        Me.Label2.Text = "Patient's Blood Type/RH :"
        '
        'cmbpatientrh
        '
        Me.cmbpatientrh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbpatientrh.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbpatientrh.FormattingEnabled = True
        Me.cmbpatientrh.Location = New System.Drawing.Point(146, 10)
        Me.cmbpatientrh.Name = "cmbpatientrh"
        Me.cmbpatientrh.Size = New System.Drawing.Size(177, 22)
        Me.cmbpatientrh.TabIndex = 208
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(499, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 14)
        Me.Label4.TabIndex = 207
        Me.Label4.Text = "Donor's Blood Type/RH :"
        '
        'cmbdonorsrh
        '
        Me.cmbdonorsrh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbdonorsrh.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbdonorsrh.FormattingEnabled = True
        Me.cmbdonorsrh.Location = New System.Drawing.Point(635, 10)
        Me.cmbdonorsrh.Name = "cmbdonorsrh"
        Me.cmbdonorsrh.Size = New System.Drawing.Size(177, 22)
        Me.cmbdonorsrh.TabIndex = 206
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape6, Me.LineShape5})
        Me.ShapeContainer2.Size = New System.Drawing.Size(821, 261)
        Me.ShapeContainer2.TabIndex = 211
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape6
        '
        Me.LineShape6.Name = "LineShape6"
        Me.LineShape6.X1 = 633
        Me.LineShape6.X2 = 812
        Me.LineShape6.Y1 = 32
        Me.LineShape6.Y2 = 32
        '
        'LineShape5
        '
        Me.LineShape5.Name = "LineShape5"
        Me.LineShape5.X1 = 145
        Me.LineShape5.X2 = 324
        Me.LineShape5.Y1 = 32
        Me.LineShape5.Y2 = 32
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape7, Me.LineShape4, Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(894, 530)
        Me.ShapeContainer1.TabIndex = 253
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape7
        '
        Me.LineShape7.Name = "LineShape7"
        Me.LineShape7.X1 = 699
        Me.LineShape7.X2 = 849
        Me.LineShape7.Y1 = 136
        Me.LineShape7.Y2 = 136
        '
        'LineShape4
        '
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 510
        Me.LineShape4.X2 = 847
        Me.LineShape4.Y1 = 160
        Me.LineShape4.Y2 = 160
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 231
        Me.LineShape3.X2 = 298
        Me.LineShape3.Y1 = 160
        Me.LineShape3.Y2 = 160
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 89
        Me.LineShape2.X2 = 151
        Me.LineShape2.Y1 = 160
        Me.LineShape2.Y2 = 160
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 89
        Me.LineShape1.X2 = 524
        Me.LineShape1.Y1 = 136
        Me.LineShape1.Y2 = 136
        '
        'txtPatientName
        '
        Me.txtPatientName.BackColor = System.Drawing.Color.Transparent
        Me.txtPatientName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtPatientName.ForeColor = System.Drawing.Color.Black
        Me.txtPatientName.Location = New System.Drawing.Point(93, 118)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.Size = New System.Drawing.Size(432, 18)
        Me.txtPatientName.TabIndex = 257
        Me.txtPatientName.Text = "NAME"
        Me.txtPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAge
        '
        Me.txtAge.BackColor = System.Drawing.Color.Transparent
        Me.txtAge.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtAge.ForeColor = System.Drawing.Color.Black
        Me.txtAge.Location = New System.Drawing.Point(89, 141)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(63, 18)
        Me.txtAge.TabIndex = 258
        Me.txtAge.Text = "Age"
        Me.txtAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtGender
        '
        Me.txtGender.BackColor = System.Drawing.Color.Transparent
        Me.txtGender.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtGender.ForeColor = System.Drawing.Color.Black
        Me.txtGender.Location = New System.Drawing.Point(231, 141)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.Size = New System.Drawing.Size(67, 18)
        Me.txtGender.TabIndex = 259
        Me.txtGender.Text = "Female"
        Me.txtGender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRequestedby
        '
        Me.txtRequestedby.BackColor = System.Drawing.Color.Transparent
        Me.txtRequestedby.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.txtRequestedby.ForeColor = System.Drawing.Color.Black
        Me.txtRequestedby.Location = New System.Drawing.Point(510, 141)
        Me.txtRequestedby.Name = "txtRequestedby"
        Me.txtRequestedby.Size = New System.Drawing.Size(334, 18)
        Me.txtRequestedby.TabIndex = 260
        Me.txtRequestedby.Text = "DR."
        Me.txtRequestedby.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtdate
        '
        Me.txtdate.BackColor = System.Drawing.Color.White
        Me.txtdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtdate.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.txtdate.Location = New System.Drawing.Point(700, 115)
        Me.txtdate.Name = "txtdate"
        Me.txtdate.ReadOnly = True
        Me.txtdate.Size = New System.Drawing.Size(151, 19)
        Me.txtdate.TabIndex = 261
        Me.txtdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtdate.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.MiscPrintDocu
        Me.PrintDialog1.UseEXDialog = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.HeaderText = "Parameter"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn2.HeaderText = "Result"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 160
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn3.HeaderText = "Units"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle7
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
        'pctrLogo
        '
        Me.pctrLogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.pctrLogo.Location = New System.Drawing.Point(190, 7)
        Me.pctrLogo.Name = "pctrLogo"
        Me.pctrLogo.Size = New System.Drawing.Size(86, 86)
        Me.pctrLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctrLogo.TabIndex = 245
        Me.pctrLogo.TabStop = False
        '
        'frmCrossMatchingNew
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(894, 530)
        Me.ControlBox = False
        Me.Controls.Add(Me.pctrLogo)
        Me.Controls.Add(Me.txtdate)
        Me.Controls.Add(Me.txtRequestedby)
        Me.Controls.Add(Me.txtGender)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.txtPatientName)
        Me.Controls.Add(Me.panelmain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lablTelNo)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.dtDate)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblpatientid)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblPatientname)
        Me.Controls.Add(Me.lblMisc)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCrossMatchingNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TEST"
        Me.panelmain.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.panelresult.ResumeLayout(False)
        Me.panelresult.PerformLayout()
        CType(Me.dgvCrossM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMisc As System.Windows.Forms.Label
    Friend WithEvents cmbMedtech As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPathologist As System.Windows.Forms.ComboBox
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblpatientid As System.Windows.Forms.Label
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents panelmain As System.Windows.Forms.Panel
    Friend WithEvents panelresult As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblpatholicense As System.Windows.Forms.Label
    Friend WithEvents lblpathodesignation As System.Windows.Forms.Label
    Friend WithEvents lblmedtechlicense As System.Windows.Forms.Label
    Friend WithEvents lblmedtechdesignation As System.Windows.Forms.Label
    Friend WithEvents lblpatho As System.Windows.Forms.TextBox
    Friend WithEvents lblmedtech As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents txtPatientName As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.Label
    Friend WithEvents txtGender As System.Windows.Forms.Label
    Friend WithEvents txtRequestedby As System.Windows.Forms.Label
    Friend WithEvents LineShape7 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents txtdate As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbdonorsrh As System.Windows.Forms.ComboBox
    Friend WithEvents cmbpatientrh As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvCrossM As System.Windows.Forms.DataGridView
    Friend WithEvents txtdonorblood As System.Windows.Forms.TextBox
    Friend WithEvents txtpatientblood As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape5 As Microsoft.VisualBasic.PowerPacks.LineShape
End Class
