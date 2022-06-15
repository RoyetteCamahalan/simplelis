<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmECGReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmECGReport))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtecgdiagnosis = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbCardiologist = New System.Windows.Forms.ComboBox()
        Me.pdecgreport = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lablTelNo = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.pctrLogo = New System.Windows.Forms.PictureBox()
        Me.lblheader = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.txtGender = New System.Windows.Forms.TextBox()
        Me.txtQTc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRoom = New System.Windows.Forms.TextBox()
        Me.txtRhythm = New System.Windows.Forms.TextBox()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.txtPR = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtQRS = New System.Windows.Forms.TextBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.txtQRSAxis = New System.Windows.Forms.TextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblconsistency = New System.Windows.Forms.Label()
        Me.txtAtrialRate = New System.Windows.Forms.TextBox()
        Me.lblFecalysis = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtVenticularRate = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(45, 289)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(232, 15)
        Me.Label6.TabIndex = 144
        Me.Label6.Text = "ELECTROCARDIOGRAPHIC DIAGNOSIS:"
        '
        'txtecgdiagnosis
        '
        Me.txtecgdiagnosis.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtecgdiagnosis.Location = New System.Drawing.Point(46, 307)
        Me.txtecgdiagnosis.Multiline = True
        Me.txtecgdiagnosis.Name = "txtecgdiagnosis"
        Me.txtecgdiagnosis.Size = New System.Drawing.Size(758, 184)
        Me.txtecgdiagnosis.TabIndex = 150
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(658, 523)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 166
        Me.Label7.Text = "Cardiologist"
        '
        'cmbCardiologist
        '
        Me.cmbCardiologist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCardiologist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCardiologist.FormattingEnabled = True
        Me.cmbCardiologist.Location = New System.Drawing.Point(593, 496)
        Me.cmbCardiologist.Name = "cmbCardiologist"
        Me.cmbCardiologist.Size = New System.Drawing.Size(211, 24)
        Me.cmbCardiologist.TabIndex = 165
        '
        'pdecgreport
        '
        Me.pdecgreport.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.pdecgreport.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.pdecgreport.ClientSize = New System.Drawing.Size(400, 300)
        Me.pdecgreport.Enabled = True
        Me.pdecgreport.Icon = CType(resources.GetObject("pdecgreport.Icon"), System.Drawing.Icon)
        Me.pdecgreport.Name = "pdecgreport"
        Me.pdecgreport.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(555, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 15)
        Me.Label4.TabIndex = 215
        Me.Label4.Text = "QTc:"
        '
        'lablTelNo
        '
        Me.lablTelNo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lablTelNo.BackColor = System.Drawing.Color.Transparent
        Me.lablTelNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lablTelNo.ForeColor = System.Drawing.Color.Black
        Me.lablTelNo.Location = New System.Drawing.Point(273, 61)
        Me.lablTelNo.Name = "lablTelNo"
        Me.lablTelNo.Size = New System.Drawing.Size(290, 14)
        Me.lablTelNo.TabIndex = 242
        Me.lablTelNo.Text = "xxxx"
        Me.lablTelNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtName
        '
        Me.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtName.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.Black
        Me.txtName.Location = New System.Drawing.Point(25, 119)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(514, 25)
        Me.txtName.TabIndex = 229
        Me.txtName.Text = "JOHN DE GUZMAN"
        '
        'lblAge
        '
        Me.lblAge.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblAge.AutoSize = True
        Me.lblAge.BackColor = System.Drawing.Color.Transparent
        Me.lblAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAge.ForeColor = System.Drawing.Color.Black
        Me.lblAge.Location = New System.Drawing.Point(42, 166)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(31, 15)
        Me.lblAge.TabIndex = 231
        Me.lblAge.Text = "Age:"
        '
        'pctrLogo
        '
        Me.pctrLogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.pctrLogo.Location = New System.Drawing.Point(25, 18)
        Me.pctrLogo.Name = "pctrLogo"
        Me.pctrLogo.Size = New System.Drawing.Size(94, 88)
        Me.pctrLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctrLogo.TabIndex = 239
        Me.pctrLogo.TabStop = False
        '
        'lblheader
        '
        Me.lblheader.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblheader.BackColor = System.Drawing.Color.Transparent
        Me.lblheader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheader.ForeColor = System.Drawing.Color.Black
        Me.lblheader.Location = New System.Drawing.Point(271, 30)
        Me.lblheader.Name = "lblheader"
        Me.lblheader.Size = New System.Drawing.Size(293, 21)
        Me.lblheader.TabIndex = 240
        Me.lblheader.Text = "xxxx"
        Me.lblheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGender
        '
        Me.lblGender.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblGender.AutoSize = True
        Me.lblGender.BackColor = System.Drawing.Color.Transparent
        Me.lblGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.ForeColor = System.Drawing.Color.Black
        Me.lblGender.Location = New System.Drawing.Point(22, 149)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(51, 15)
        Me.lblGender.TabIndex = 233
        Me.lblGender.Text = "Gender:"
        '
        'txtGender
        '
        Me.txtGender.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtGender.BackColor = System.Drawing.Color.White
        Me.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGender.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGender.ForeColor = System.Drawing.Color.Black
        Me.txtGender.Location = New System.Drawing.Point(77, 149)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.ReadOnly = True
        Me.txtGender.Size = New System.Drawing.Size(52, 14)
        Me.txtGender.TabIndex = 234
        '
        'txtQTc
        '
        Me.txtQTc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQTc.Location = New System.Drawing.Point(601, 242)
        Me.txtQTc.Name = "txtQTc"
        Me.txtQTc.Size = New System.Drawing.Size(203, 24)
        Me.txtQTc.TabIndex = 225
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(527, 278)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 15)
        Me.Label5.TabIndex = 218
        Me.Label5.Text = "QRS Axis:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(178, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 235
        Me.Label1.Text = "Room:"
        '
        'txtRoom
        '
        Me.txtRoom.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtRoom.BackColor = System.Drawing.Color.White
        Me.txtRoom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoom.ForeColor = System.Drawing.Color.Black
        Me.txtRoom.Location = New System.Drawing.Point(223, 149)
        Me.txtRoom.Name = "txtRoom"
        Me.txtRoom.ReadOnly = True
        Me.txtRoom.Size = New System.Drawing.Size(52, 14)
        Me.txtRoom.TabIndex = 236
        '
        'txtRhythm
        '
        Me.txtRhythm.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRhythm.Location = New System.Drawing.Point(143, 187)
        Me.txtRhythm.Name = "txtRhythm"
        Me.txtRhythm.Size = New System.Drawing.Size(203, 24)
        Me.txtRhythm.TabIndex = 222
        '
        'dtDate
        '
        Me.dtDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtDate.Enabled = False
        Me.dtDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(685, 119)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(119, 21)
        Me.dtDate.TabIndex = 238
        '
        'txtPR
        '
        Me.txtPR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPR.Location = New System.Drawing.Point(600, 187)
        Me.txtPR.Name = "txtPR"
        Me.txtPR.Size = New System.Drawing.Size(203, 24)
        Me.txtPR.TabIndex = 226
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(563, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 15)
        Me.Label2.TabIndex = 221
        Me.Label2.Text = "PR:"
        '
        'txtQRS
        '
        Me.txtQRS.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQRS.Location = New System.Drawing.Point(600, 214)
        Me.txtQRS.Name = "txtQRS"
        Me.txtQRS.Size = New System.Drawing.Size(203, 24)
        Me.txtQRS.TabIndex = 228
        '
        'lblColor
        '
        Me.lblColor.BackColor = System.Drawing.Color.Transparent
        Me.lblColor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.ForeColor = System.Drawing.Color.Black
        Me.lblColor.Location = New System.Drawing.Point(59, 196)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(78, 15)
        Me.lblColor.TabIndex = 217
        Me.lblColor.Text = "Rhythm:"
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAge
        '
        Me.txtAge.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtAge.BackColor = System.Drawing.Color.White
        Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAge.ForeColor = System.Drawing.Color.Black
        Me.txtAge.Location = New System.Drawing.Point(77, 167)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ReadOnly = True
        Me.txtAge.Size = New System.Drawing.Size(39, 14)
        Me.txtAge.TabIndex = 232
        '
        'txtQRSAxis
        '
        Me.txtQRSAxis.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQRSAxis.Location = New System.Drawing.Point(601, 269)
        Me.txtQRSAxis.Name = "txtQRSAxis"
        Me.txtQRSAxis.Size = New System.Drawing.Size(203, 24)
        Me.txtQRSAxis.TabIndex = 227
        '
        'lblDate
        '
        Me.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(639, 122)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(36, 15)
        Me.lblDate.TabIndex = 237
        Me.lblDate.Text = "Date:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(554, 223)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 219
        Me.Label3.Text = "QRS:"
        '
        'lblconsistency
        '
        Me.lblconsistency.BackColor = System.Drawing.Color.Transparent
        Me.lblconsistency.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblconsistency.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconsistency.ForeColor = System.Drawing.Color.Black
        Me.lblconsistency.Location = New System.Drawing.Point(45, 223)
        Me.lblconsistency.Name = "lblconsistency"
        Me.lblconsistency.Size = New System.Drawing.Size(92, 15)
        Me.lblconsistency.TabIndex = 216
        Me.lblconsistency.Text = "Atrial Rate:"
        Me.lblconsistency.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAtrialRate
        '
        Me.txtAtrialRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAtrialRate.Location = New System.Drawing.Point(143, 214)
        Me.txtAtrialRate.Name = "txtAtrialRate"
        Me.txtAtrialRate.Size = New System.Drawing.Size(203, 24)
        Me.txtAtrialRate.TabIndex = 223
        '
        'lblFecalysis
        '
        Me.lblFecalysis.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblFecalysis.BackColor = System.Drawing.Color.Transparent
        Me.lblFecalysis.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecalysis.ForeColor = System.Drawing.Color.Black
        Me.lblFecalysis.Location = New System.Drawing.Point(329, 86)
        Me.lblFecalysis.Name = "lblFecalysis"
        Me.lblFecalysis.Size = New System.Drawing.Size(187, 24)
        Me.lblFecalysis.TabIndex = 214
        Me.lblFecalysis.Text = "ECG REPORT"
        Me.lblFecalysis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAddress
        '
        Me.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.ForeColor = System.Drawing.Color.Black
        Me.lblAddress.Location = New System.Drawing.Point(273, 48)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(290, 14)
        Me.lblAddress.TabIndex = 241
        Me.lblAddress.Text = "xxxx"
        Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVenticularRate
        '
        Me.txtVenticularRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVenticularRate.Location = New System.Drawing.Point(143, 242)
        Me.txtVenticularRate.Name = "txtVenticularRate"
        Me.txtVenticularRate.Size = New System.Drawing.Size(203, 24)
        Me.txtVenticularRate.TabIndex = 246
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(11, 255)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 15)
        Me.Label9.TabIndex = 245
        Me.Label9.Text = "Ventricular Rate:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmECGReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(837, 546)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtAtrialRate)
        Me.Controls.Add(Me.txtVenticularRate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lablTelNo)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblFecalysis)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.pctrLogo)
        Me.Controls.Add(Me.lblheader)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.txtGender)
        Me.Controls.Add(Me.txtQTc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRoom)
        Me.Controls.Add(Me.txtRhythm)
        Me.Controls.Add(Me.dtDate)
        Me.Controls.Add(Me.txtPR)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtQRS)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.txtQRSAxis)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblconsistency)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtecgdiagnosis)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbCardiologist)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmECGReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ECG Report"
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtecgdiagnosis As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbCardiologist As System.Windows.Forms.ComboBox
    Friend WithEvents pdecgreport As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lablTelNo As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents pctrLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblheader As System.Windows.Forms.Label
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents txtGender As System.Windows.Forms.TextBox
    Friend WithEvents txtQTc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRoom As System.Windows.Forms.TextBox
    Friend WithEvents txtRhythm As System.Windows.Forms.TextBox
    Friend WithEvents dtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPR As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQRS As System.Windows.Forms.TextBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents txtQRSAxis As System.Windows.Forms.TextBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblconsistency As System.Windows.Forms.Label
    Friend WithEvents txtAtrialRate As System.Windows.Forms.TextBox
    Friend WithEvents lblFecalysis As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtVenticularRate As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
