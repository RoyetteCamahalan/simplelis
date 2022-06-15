<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMiscellaneous
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMiscellaneous))
        Me.lblMisc = New System.Windows.Forms.Label()
        Me.cmbMedtech = New System.Windows.Forms.ComboBox()
        Me.lblMedtech = New System.Windows.Forms.Label()
        Me.txtPathologist = New System.Windows.Forms.ComboBox()
        Me.lblPathologist = New System.Windows.Forms.Label()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtLabno = New System.Windows.Forms.TextBox()
        Me.lblLabNo = New System.Windows.Forms.Label()
        Me.lblpatientid = New System.Windows.Forms.Label()
        Me.txtGender = New System.Windows.Forms.TextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.txtRoomno = New System.Windows.Forms.TextBox()
        Me.lblRoomno = New System.Windows.Forms.Label()
        Me.txtPatientname = New System.Windows.Forms.TextBox()
        Me.lblPatientname = New System.Windows.Forms.Label()
        Me.txtPatientid = New System.Windows.Forms.TextBox()
        Me.lblLabExam = New System.Windows.Forms.Label()
        Me.txtLabExam = New System.Windows.Forms.TextBox()
        Me.LineBorder = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.lblSpecimen = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.rbNegative = New System.Windows.Forms.RadioButton()
        Me.rbPositive = New System.Windows.Forms.RadioButton()
        Me.richtxtOthers = New System.Windows.Forms.RichTextBox()
        Me.lblOthersmisc = New System.Windows.Forms.Label()
        Me.dlgPrint = New System.Windows.Forms.PrintDialog()
        Me.dlgPrintPreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.MiscPrintDocu = New System.Drawing.Printing.PrintDocument()
        Me.txtSpecimen = New System.Windows.Forms.TextBox()
        Me.txtRadiobuttonResult = New System.Windows.Forms.TextBox()
        Me.lblIGG = New System.Windows.Forms.Label()
        Me.txtIGG = New System.Windows.Forms.TextBox()
        Me.txtIGM = New System.Windows.Forms.TextBox()
        Me.lblIGM = New System.Windows.Forms.Label()
        Me.cmbSpecimen = New System.Windows.Forms.ComboBox()
        Me.gbIGM = New System.Windows.Forms.GroupBox()
        Me.cbIgmNegative = New System.Windows.Forms.RadioButton()
        Me.cbIgmPositive = New System.Windows.Forms.RadioButton()
        Me.gbIGG = New System.Windows.Forms.GroupBox()
        Me.cbIggNegative = New System.Windows.Forms.RadioButton()
        Me.cbIggPositive = New System.Windows.Forms.RadioButton()
        Me.lablTelNo = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.pctrLogo = New System.Windows.Forms.PictureBox()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.gbIGM.SuspendLayout()
        Me.gbIGG.SuspendLayout()
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMisc
        '
        Me.lblMisc.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMisc.AutoSize = True
        Me.lblMisc.BackColor = System.Drawing.SystemColors.Control
        Me.lblMisc.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMisc.ForeColor = System.Drawing.Color.Black
        Me.lblMisc.Location = New System.Drawing.Point(378, 64)
        Me.lblMisc.Name = "lblMisc"
        Me.lblMisc.Size = New System.Drawing.Size(125, 17)
        Me.lblMisc.TabIndex = 127
        Me.lblMisc.Text = "MISCELLANEOUS"
        '
        'cmbMedtech
        '
        Me.cmbMedtech.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbMedtech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedtech.FormattingEnabled = True
        Me.cmbMedtech.Location = New System.Drawing.Point(689, 139)
        Me.cmbMedtech.Name = "cmbMedtech"
        Me.cmbMedtech.Size = New System.Drawing.Size(146, 21)
        Me.cmbMedtech.TabIndex = 222
        '
        'lblMedtech
        '
        Me.lblMedtech.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblMedtech.AutoSize = True
        Me.lblMedtech.BackColor = System.Drawing.SystemColors.Control
        Me.lblMedtech.ForeColor = System.Drawing.Color.Black
        Me.lblMedtech.Location = New System.Drawing.Point(625, 147)
        Me.lblMedtech.Name = "lblMedtech"
        Me.lblMedtech.Size = New System.Drawing.Size(59, 13)
        Me.lblMedtech.TabIndex = 221
        Me.lblMedtech.Text = "Med Tech:"
        '
        'txtPathologist
        '
        Me.txtPathologist.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtPathologist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtPathologist.FormattingEnabled = True
        Me.txtPathologist.Location = New System.Drawing.Point(436, 139)
        Me.txtPathologist.Name = "txtPathologist"
        Me.txtPathologist.Size = New System.Drawing.Size(170, 21)
        Me.txtPathologist.TabIndex = 220
        '
        'lblPathologist
        '
        Me.lblPathologist.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPathologist.AutoSize = True
        Me.lblPathologist.BackColor = System.Drawing.SystemColors.Control
        Me.lblPathologist.ForeColor = System.Drawing.Color.Black
        Me.lblPathologist.Location = New System.Drawing.Point(373, 147)
        Me.lblPathologist.Name = "lblPathologist"
        Me.lblPathologist.Size = New System.Drawing.Size(62, 13)
        Me.lblPathologist.TabIndex = 219
        Me.lblPathologist.Text = "Pathologist:"
        '
        'dtDate
        '
        Me.dtDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtDate.Enabled = False
        Me.dtDate.Location = New System.Drawing.Point(176, 140)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(191, 20)
        Me.dtDate.TabIndex = 218
        '
        'lblDate
        '
        Me.lblDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(145, 147)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(33, 13)
        Me.lblDate.TabIndex = 217
        Me.lblDate.Text = "Date:"
        '
        'txtLabno
        '
        Me.txtLabno.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtLabno.Enabled = False
        Me.txtLabno.Location = New System.Drawing.Point(60, 140)
        Me.txtLabno.Name = "txtLabno"
        Me.txtLabno.Size = New System.Drawing.Size(81, 20)
        Me.txtLabno.TabIndex = 216
        '
        'lblLabNo
        '
        Me.lblLabNo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLabNo.AutoSize = True
        Me.lblLabNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblLabNo.ForeColor = System.Drawing.Color.Black
        Me.lblLabNo.Location = New System.Drawing.Point(16, 147)
        Me.lblLabNo.Name = "lblLabNo"
        Me.lblLabNo.Size = New System.Drawing.Size(45, 13)
        Me.lblLabNo.TabIndex = 215
        Me.lblLabNo.Text = "Lab No:"
        '
        'lblpatientid
        '
        Me.lblpatientid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblpatientid.AutoSize = True
        Me.lblpatientid.BackColor = System.Drawing.SystemColors.Control
        Me.lblpatientid.ForeColor = System.Drawing.Color.Black
        Me.lblpatientid.Location = New System.Drawing.Point(12, 106)
        Me.lblpatientid.Name = "lblpatientid"
        Me.lblpatientid.Size = New System.Drawing.Size(65, 13)
        Me.lblpatientid.TabIndex = 214
        Me.lblpatientid.Text = "Hospital No:"
        '
        'txtGender
        '
        Me.txtGender.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtGender.Enabled = False
        Me.txtGender.Location = New System.Drawing.Point(551, 99)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.Size = New System.Drawing.Size(62, 20)
        Me.txtGender.TabIndex = 213
        '
        'lblGender
        '
        Me.lblGender.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblGender.AutoSize = True
        Me.lblGender.BackColor = System.Drawing.SystemColors.Control
        Me.lblGender.ForeColor = System.Drawing.Color.Black
        Me.lblGender.Location = New System.Drawing.Point(507, 106)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(45, 13)
        Me.lblGender.TabIndex = 212
        Me.lblGender.Text = "Gender:"
        '
        'txtAge
        '
        Me.txtAge.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtAge.Enabled = False
        Me.txtAge.Location = New System.Drawing.Point(646, 99)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(57, 20)
        Me.txtAge.TabIndex = 211
        '
        'lblAge
        '
        Me.lblAge.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAge.AutoSize = True
        Me.lblAge.BackColor = System.Drawing.SystemColors.Control
        Me.lblAge.ForeColor = System.Drawing.Color.Black
        Me.lblAge.Location = New System.Drawing.Point(616, 106)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(29, 13)
        Me.lblAge.TabIndex = 210
        Me.lblAge.Text = "Age:"
        '
        'txtRoomno
        '
        Me.txtRoomno.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtRoomno.Enabled = False
        Me.txtRoomno.Location = New System.Drawing.Point(759, 99)
        Me.txtRoomno.Name = "txtRoomno"
        Me.txtRoomno.Size = New System.Drawing.Size(44, 20)
        Me.txtRoomno.TabIndex = 209
        '
        'lblRoomno
        '
        Me.lblRoomno.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblRoomno.AutoSize = True
        Me.lblRoomno.BackColor = System.Drawing.SystemColors.Control
        Me.lblRoomno.ForeColor = System.Drawing.Color.Black
        Me.lblRoomno.Location = New System.Drawing.Point(705, 106)
        Me.lblRoomno.Name = "lblRoomno"
        Me.lblRoomno.Size = New System.Drawing.Size(55, 13)
        Me.lblRoomno.TabIndex = 208
        Me.lblRoomno.Text = "Room No:"
        '
        'txtPatientname
        '
        Me.txtPatientname.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtPatientname.Enabled = False
        Me.txtPatientname.Location = New System.Drawing.Point(79, 99)
        Me.txtPatientname.Name = "txtPatientname"
        Me.txtPatientname.Size = New System.Drawing.Size(80, 20)
        Me.txtPatientname.TabIndex = 207
        '
        'lblPatientname
        '
        Me.lblPatientname.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPatientname.AutoSize = True
        Me.lblPatientname.BackColor = System.Drawing.SystemColors.Control
        Me.lblPatientname.ForeColor = System.Drawing.Color.Black
        Me.lblPatientname.Location = New System.Drawing.Point(182, 106)
        Me.lblPatientname.Name = "lblPatientname"
        Me.lblPatientname.Size = New System.Drawing.Size(74, 13)
        Me.lblPatientname.TabIndex = 206
        Me.lblPatientname.Text = "Patient Name:"
        '
        'txtPatientid
        '
        Me.txtPatientid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtPatientid.Enabled = False
        Me.txtPatientid.Location = New System.Drawing.Point(257, 99)
        Me.txtPatientid.Name = "txtPatientid"
        Me.txtPatientid.Size = New System.Drawing.Size(246, 20)
        Me.txtPatientid.TabIndex = 205
        '
        'lblLabExam
        '
        Me.lblLabExam.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblLabExam.AutoSize = True
        Me.lblLabExam.BackColor = System.Drawing.Color.Transparent
        Me.lblLabExam.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLabExam.Location = New System.Drawing.Point(133, 196)
        Me.lblLabExam.Name = "lblLabExam"
        Me.lblLabExam.Size = New System.Drawing.Size(117, 15)
        Me.lblLabExam.TabIndex = 224
        Me.lblLabExam.Text = "LAB EXAMINATION:"
        '
        'txtLabExam
        '
        Me.txtLabExam.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtLabExam.BackColor = System.Drawing.Color.Bisque
        Me.txtLabExam.Enabled = False
        Me.txtLabExam.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtLabExam.Location = New System.Drawing.Point(270, 193)
        Me.txtLabExam.Name = "txtLabExam"
        Me.txtLabExam.ReadOnly = True
        Me.txtLabExam.Size = New System.Drawing.Size(498, 23)
        Me.txtLabExam.TabIndex = 223
        '
        'LineBorder
        '
        Me.LineBorder.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineBorder.Name = "LineBorder"
        Me.LineBorder.X1 = 40
        Me.LineBorder.X2 = 797
        Me.LineBorder.Y1 = 178
        Me.LineBorder.Y2 = 178
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineBorder})
        Me.ShapeContainer1.Size = New System.Drawing.Size(856, 487)
        Me.ShapeContainer1.TabIndex = 225
        Me.ShapeContainer1.TabStop = False
        '
        'lblSpecimen
        '
        Me.lblSpecimen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblSpecimen.AutoSize = True
        Me.lblSpecimen.BackColor = System.Drawing.Color.Transparent
        Me.lblSpecimen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSpecimen.Location = New System.Drawing.Point(183, 238)
        Me.lblSpecimen.Name = "lblSpecimen"
        Me.lblSpecimen.Size = New System.Drawing.Size(67, 15)
        Me.lblSpecimen.TabIndex = 227
        Me.lblSpecimen.Text = "SPECIMEN:"
        '
        'lblResult
        '
        Me.lblResult.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblResult.AutoSize = True
        Me.lblResult.BackColor = System.Drawing.Color.Transparent
        Me.lblResult.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblResult.Location = New System.Drawing.Point(183, 285)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(59, 15)
        Me.lblResult.TabIndex = 228
        Me.lblResult.Text = "RESULTS:"
        '
        'rbNegative
        '
        Me.rbNegative.AutoSize = True
        Me.rbNegative.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rbNegative.Location = New System.Drawing.Point(414, 293)
        Me.rbNegative.Name = "rbNegative"
        Me.rbNegative.Size = New System.Drawing.Size(162, 19)
        Me.rbNegative.TabIndex = 3
        Me.rbNegative.Text = "Negative - Non Reactive"
        Me.rbNegative.UseVisualStyleBackColor = True
        '
        'rbPositive
        '
        Me.rbPositive.AutoSize = True
        Me.rbPositive.Checked = True
        Me.rbPositive.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rbPositive.Location = New System.Drawing.Point(276, 292)
        Me.rbPositive.Name = "rbPositive"
        Me.rbPositive.Size = New System.Drawing.Size(129, 19)
        Me.rbPositive.TabIndex = 2
        Me.rbPositive.TabStop = True
        Me.rbPositive.Text = "Positive / Reactive"
        Me.rbPositive.UseVisualStyleBackColor = True
        '
        'richtxtOthers
        '
        Me.richtxtOthers.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.richtxtOthers.Location = New System.Drawing.Point(267, 340)
        Me.richtxtOthers.Name = "richtxtOthers"
        Me.richtxtOthers.Size = New System.Drawing.Size(356, 107)
        Me.richtxtOthers.TabIndex = 230
        Me.richtxtOthers.Text = ""
        '
        'lblOthersmisc
        '
        Me.lblOthersmisc.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblOthersmisc.AutoSize = True
        Me.lblOthersmisc.BackColor = System.Drawing.Color.Transparent
        Me.lblOthersmisc.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblOthersmisc.Location = New System.Drawing.Point(184, 342)
        Me.lblOthersmisc.Name = "lblOthersmisc"
        Me.lblOthersmisc.Size = New System.Drawing.Size(66, 15)
        Me.lblOthersmisc.TabIndex = 231
        Me.lblOthersmisc.Text = "REMARKS:"
        '
        'dlgPrint
        '
        Me.dlgPrint.UseEXDialog = True
        '
        'dlgPrintPreview
        '
        Me.dlgPrintPreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.ClientSize = New System.Drawing.Size(400, 300)
        Me.dlgPrintPreview.Document = Me.MiscPrintDocu
        Me.dlgPrintPreview.Enabled = True
        Me.dlgPrintPreview.Icon = CType(resources.GetObject("dlgPrintPreview.Icon"), System.Drawing.Icon)
        Me.dlgPrintPreview.Name = "dlgPrintPreview"
        Me.dlgPrintPreview.Visible = False
        '
        'MiscPrintDocu
        '
        '
        'txtSpecimen
        '
        Me.txtSpecimen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtSpecimen.BackColor = System.Drawing.Color.White
        Me.txtSpecimen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSpecimen.Location = New System.Drawing.Point(270, 235)
        Me.txtSpecimen.Name = "txtSpecimen"
        Me.txtSpecimen.Size = New System.Drawing.Size(310, 23)
        Me.txtSpecimen.TabIndex = 226
        '
        'txtRadiobuttonResult
        '
        Me.txtRadiobuttonResult.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtRadiobuttonResult.BackColor = System.Drawing.Color.White
        Me.txtRadiobuttonResult.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRadiobuttonResult.Location = New System.Drawing.Point(267, 283)
        Me.txtRadiobuttonResult.Name = "txtRadiobuttonResult"
        Me.txtRadiobuttonResult.Size = New System.Drawing.Size(216, 23)
        Me.txtRadiobuttonResult.TabIndex = 232
        Me.txtRadiobuttonResult.Visible = False
        '
        'lblIGG
        '
        Me.lblIGG.AutoSize = True
        Me.lblIGG.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIGG.Location = New System.Drawing.Point(339, 301)
        Me.lblIGG.Name = "lblIGG"
        Me.lblIGG.Size = New System.Drawing.Size(32, 15)
        Me.lblIGG.TabIndex = 235
        Me.lblIGG.Text = "IGG:"
        Me.lblIGG.Visible = False
        '
        'txtIGG
        '
        Me.txtIGG.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtIGG.Location = New System.Drawing.Point(370, 299)
        Me.txtIGG.Name = "txtIGG"
        Me.txtIGG.Size = New System.Drawing.Size(31, 23)
        Me.txtIGG.TabIndex = 236
        Me.txtIGG.Visible = False
        '
        'txtIGM
        '
        Me.txtIGM.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtIGM.Location = New System.Drawing.Point(300, 298)
        Me.txtIGM.Name = "txtIGM"
        Me.txtIGM.Size = New System.Drawing.Size(31, 23)
        Me.txtIGM.TabIndex = 238
        Me.txtIGM.Visible = False
        '
        'lblIGM
        '
        Me.lblIGM.AutoSize = True
        Me.lblIGM.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIGM.Location = New System.Drawing.Point(267, 301)
        Me.lblIGM.Name = "lblIGM"
        Me.lblIGM.Size = New System.Drawing.Size(34, 15)
        Me.lblIGM.TabIndex = 237
        Me.lblIGM.Text = "IGM:"
        Me.lblIGM.Visible = False
        '
        'cmbSpecimen
        '
        Me.cmbSpecimen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbSpecimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSpecimen.FormattingEnabled = True
        Me.cmbSpecimen.Location = New System.Drawing.Point(586, 236)
        Me.cmbSpecimen.Name = "cmbSpecimen"
        Me.cmbSpecimen.Size = New System.Drawing.Size(182, 21)
        Me.cmbSpecimen.TabIndex = 239
        '
        'gbIGM
        '
        Me.gbIGM.Controls.Add(Me.cbIgmNegative)
        Me.gbIGM.Controls.Add(Me.cbIgmPositive)
        Me.gbIGM.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.gbIGM.Location = New System.Drawing.Point(270, 277)
        Me.gbIGM.Name = "gbIGM"
        Me.gbIGM.Size = New System.Drawing.Size(105, 57)
        Me.gbIGM.TabIndex = 242
        Me.gbIGM.TabStop = False
        Me.gbIGM.Text = "IGM"
        '
        'cbIgmNegative
        '
        Me.cbIgmNegative.AutoSize = True
        Me.cbIgmNegative.Location = New System.Drawing.Point(65, 25)
        Me.cbIgmNegative.Name = "cbIgmNegative"
        Me.cbIgmNegative.Size = New System.Drawing.Size(30, 19)
        Me.cbIgmNegative.TabIndex = 246
        Me.cbIgmNegative.Text = "-"
        Me.cbIgmNegative.UseVisualStyleBackColor = True
        '
        'cbIgmPositive
        '
        Me.cbIgmPositive.AutoSize = True
        Me.cbIgmPositive.Checked = True
        Me.cbIgmPositive.Location = New System.Drawing.Point(18, 25)
        Me.cbIgmPositive.Name = "cbIgmPositive"
        Me.cbIgmPositive.Size = New System.Drawing.Size(33, 19)
        Me.cbIgmPositive.TabIndex = 245
        Me.cbIgmPositive.TabStop = True
        Me.cbIgmPositive.Text = "+"
        Me.cbIgmPositive.UseVisualStyleBackColor = True
        '
        'gbIGG
        '
        Me.gbIGG.Controls.Add(Me.cbIggNegative)
        Me.gbIGG.Controls.Add(Me.cbIggPositive)
        Me.gbIGG.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.gbIGG.Location = New System.Drawing.Point(402, 277)
        Me.gbIGG.Name = "gbIGG"
        Me.gbIGG.Size = New System.Drawing.Size(113, 57)
        Me.gbIGG.TabIndex = 243
        Me.gbIGG.TabStop = False
        Me.gbIGG.Text = "IGG"
        '
        'cbIggNegative
        '
        Me.cbIggNegative.AutoSize = True
        Me.cbIggNegative.Location = New System.Drawing.Point(71, 26)
        Me.cbIggNegative.Name = "cbIggNegative"
        Me.cbIggNegative.Size = New System.Drawing.Size(30, 19)
        Me.cbIggNegative.TabIndex = 245
        Me.cbIggNegative.Text = "-"
        Me.cbIggNegative.UseVisualStyleBackColor = True
        '
        'cbIggPositive
        '
        Me.cbIggPositive.AutoSize = True
        Me.cbIggPositive.Checked = True
        Me.cbIggPositive.Location = New System.Drawing.Point(20, 25)
        Me.cbIggPositive.Name = "cbIggPositive"
        Me.cbIggPositive.Size = New System.Drawing.Size(33, 19)
        Me.cbIggPositive.TabIndex = 244
        Me.cbIggPositive.TabStop = True
        Me.cbIggPositive.Text = "+"
        Me.cbIggPositive.UseVisualStyleBackColor = True
        '
        'lablTelNo
        '
        Me.lablTelNo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lablTelNo.BackColor = System.Drawing.SystemColors.Control
        Me.lablTelNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lablTelNo.ForeColor = System.Drawing.Color.Black
        Me.lablTelNo.Location = New System.Drawing.Point(299, 47)
        Me.lablTelNo.Name = "lablTelNo"
        Me.lablTelNo.Size = New System.Drawing.Size(290, 14)
        Me.lablTelNo.TabIndex = 248
        Me.lablTelNo.Text = "xxxx"
        Me.lablTelNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAddress
        '
        Me.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAddress.BackColor = System.Drawing.SystemColors.Control
        Me.lblAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.ForeColor = System.Drawing.Color.Black
        Me.lblAddress.Location = New System.Drawing.Point(299, 30)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(290, 14)
        Me.lblAddress.TabIndex = 247
        Me.lblAddress.Text = "xxxx"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pctrLogo
        '
        Me.pctrLogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.pctrLogo.Location = New System.Drawing.Point(15, 7)
        Me.pctrLogo.Name = "pctrLogo"
        Me.pctrLogo.Size = New System.Drawing.Size(86, 74)
        Me.pctrLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctrLogo.TabIndex = 245
        Me.pctrLogo.TabStop = False
        '
        'lblHeader
        '
        Me.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblHeader.BackColor = System.Drawing.SystemColors.Control
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Black
        Me.lblHeader.Location = New System.Drawing.Point(297, 9)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(293, 21)
        Me.lblHeader.TabIndex = 246
        Me.lblHeader.Text = "xxxx"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMiscellaneous
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 487)
        Me.ControlBox = False
        Me.Controls.Add(Me.lablTelNo)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.pctrLogo)
        Me.Controls.Add(Me.txtPathologist)
        Me.Controls.Add(Me.lblPathologist)
        Me.Controls.Add(Me.gbIGG)
        Me.Controls.Add(Me.gbIGM)
        Me.Controls.Add(Me.cmbSpecimen)
        Me.Controls.Add(Me.lblOthersmisc)
        Me.Controls.Add(Me.richtxtOthers)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.lblSpecimen)
        Me.Controls.Add(Me.txtSpecimen)
        Me.Controls.Add(Me.lblLabExam)
        Me.Controls.Add(Me.txtLabExam)
        Me.Controls.Add(Me.cmbMedtech)
        Me.Controls.Add(Me.lblMedtech)
        Me.Controls.Add(Me.dtDate)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.txtLabno)
        Me.Controls.Add(Me.lblLabNo)
        Me.Controls.Add(Me.lblpatientid)
        Me.Controls.Add(Me.txtGender)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.txtRoomno)
        Me.Controls.Add(Me.lblRoomno)
        Me.Controls.Add(Me.txtPatientname)
        Me.Controls.Add(Me.lblPatientname)
        Me.Controls.Add(Me.txtPatientid)
        Me.Controls.Add(Me.lblMisc)
        Me.Controls.Add(Me.txtRadiobuttonResult)
        Me.Controls.Add(Me.txtIGM)
        Me.Controls.Add(Me.lblIGM)
        Me.Controls.Add(Me.txtIGG)
        Me.Controls.Add(Me.lblIGG)
        Me.Controls.Add(Me.rbNegative)
        Me.Controls.Add(Me.rbPositive)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMiscellaneous"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Miscellaneous"
        Me.gbIGM.ResumeLayout(False)
        Me.gbIGM.PerformLayout()
        Me.gbIGG.ResumeLayout(False)
        Me.gbIGG.PerformLayout()
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMisc As System.Windows.Forms.Label
    Friend WithEvents cmbMedtech As System.Windows.Forms.ComboBox
    Friend WithEvents lblMedtech As System.Windows.Forms.Label
    Friend WithEvents txtPathologist As System.Windows.Forms.ComboBox
    Friend WithEvents lblPathologist As System.Windows.Forms.Label
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents txtLabno As System.Windows.Forms.TextBox
    Friend WithEvents lblLabNo As System.Windows.Forms.Label
    Friend WithEvents lblpatientid As System.Windows.Forms.Label
    Friend WithEvents txtGender As System.Windows.Forms.TextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents txtRoomno As System.Windows.Forms.TextBox
    Friend WithEvents lblRoomno As System.Windows.Forms.Label
    Friend WithEvents txtPatientname As System.Windows.Forms.TextBox
    Friend WithEvents lblPatientname As System.Windows.Forms.Label
    Friend WithEvents txtPatientid As System.Windows.Forms.TextBox
    Friend WithEvents lblLabExam As System.Windows.Forms.Label
    Friend WithEvents txtLabExam As System.Windows.Forms.TextBox
    Friend WithEvents LineBorder As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents lblSpecimen As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents rbNegative As System.Windows.Forms.RadioButton
    Friend WithEvents rbPositive As System.Windows.Forms.RadioButton
    Friend WithEvents richtxtOthers As System.Windows.Forms.RichTextBox
    Friend WithEvents lblOthersmisc As System.Windows.Forms.Label
    Friend WithEvents dlgPrint As System.Windows.Forms.PrintDialog
    Friend WithEvents dlgPrintPreview As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents MiscPrintDocu As System.Drawing.Printing.PrintDocument
    Friend WithEvents txtSpecimen As System.Windows.Forms.TextBox
    Friend WithEvents txtRadiobuttonResult As System.Windows.Forms.TextBox
    Friend WithEvents lblIGG As System.Windows.Forms.Label
    Friend WithEvents txtIGG As System.Windows.Forms.TextBox
    Friend WithEvents txtIGM As System.Windows.Forms.TextBox
    Friend WithEvents lblIGM As System.Windows.Forms.Label
    Friend WithEvents cmbSpecimen As System.Windows.Forms.ComboBox
    Friend WithEvents gbIGM As System.Windows.Forms.GroupBox
    Friend WithEvents gbIGG As System.Windows.Forms.GroupBox
    Friend WithEvents cbIggNegative As System.Windows.Forms.RadioButton
    Friend WithEvents cbIggPositive As System.Windows.Forms.RadioButton
    Friend WithEvents cbIgmPositive As System.Windows.Forms.RadioButton
    Friend WithEvents cbIgmNegative As System.Windows.Forms.RadioButton
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
End Class
