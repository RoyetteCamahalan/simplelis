﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblpatientid = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblPatientname = New System.Windows.Forms.Label()
        Me.MiscPrintDocu = New System.Drawing.Printing.PrintDocument()
        Me.lablTelNo = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape10 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape9 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.lineage = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.txtPatientName = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.Label()
        Me.txtGender = New System.Windows.Forms.Label()
        Me.txtRequestedby = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.pctrLogo = New System.Windows.Forms.PictureBox()
        Me.panelnewborn = New System.Windows.Forms.Panel()
        Me.txtcontactno = New System.Windows.Forms.Label()
        Me.txtmother = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblpatientaddress = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblptno = New System.Windows.Forms.Label()
        Me.lblprintdate = New System.Windows.Forms.Label()
        Me.lblprinttime = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbldateencoded = New System.Windows.Forms.Label()
        Me.lbltimeencoded = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbltransdate = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbltranstime = New System.Windows.Forms.Label()
        Me.lblpatholicense = New System.Windows.Forms.Label()
        Me.lblpathodesignation = New System.Windows.Forms.Label()
        Me.panelpatho = New System.Windows.Forms.Panel()
        Me.txtResult = New System.Windows.Forms.RichTextBox()
        Me.lblpatho = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelnewborn.SuspendLayout()
        Me.panelpatho.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblpatientid
        '
        Me.lblpatientid.AutoSize = True
        Me.lblpatientid.BackColor = System.Drawing.Color.Transparent
        Me.lblpatientid.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblpatientid.ForeColor = System.Drawing.Color.Black
        Me.lblpatientid.Location = New System.Drawing.Point(259, 113)
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
        Me.lblGender.Location = New System.Drawing.Point(44, 114)
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
        Me.lblAge.Location = New System.Drawing.Point(159, 114)
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
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape10, Me.LineShape9, Me.LineShape2, Me.LineShape4, Me.LineShape3, Me.lineage, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(789, 396)
        Me.ShapeContainer1.TabIndex = 253
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape10
        '
        Me.LineShape10.Name = "LineShape10"
        Me.LineShape10.X1 = 660
        Me.LineShape10.X2 = 735
        Me.LineShape10.Y1 = 153
        Me.LineShape10.Y2 = 153
        '
        'LineShape9
        '
        Me.LineShape9.Name = "LineShape9"
        Me.LineShape9.X1 = 660
        Me.LineShape9.X2 = 735
        Me.LineShape9.Y1 = 132
        Me.LineShape9.Y2 = 132
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 110
        Me.LineShape2.X2 = 574
        Me.LineShape2.Y1 = 153
        Me.LineShape2.Y2 = 153
        '
        'LineShape4
        '
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 330
        Me.LineShape4.X2 = 574
        Me.LineShape4.Y1 = 132
        Me.LineShape4.Y2 = 132
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 79
        Me.LineShape3.X2 = 151
        Me.LineShape3.Y1 = 132
        Me.LineShape3.Y2 = 132
        '
        'lineage
        '
        Me.lineage.Name = "lineage"
        Me.lineage.X1 = 192
        Me.lineage.X2 = 254
        Me.lineage.Y1 = 132
        Me.lineage.Y2 = 132
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 89
        Me.LineShape1.X2 = 735
        Me.LineShape1.Y1 = 110
        Me.LineShape1.Y2 = 110
        '
        'txtPatientName
        '
        Me.txtPatientName.BackColor = System.Drawing.Color.Transparent
        Me.txtPatientName.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtPatientName.ForeColor = System.Drawing.Color.Black
        Me.txtPatientName.Location = New System.Drawing.Point(93, 92)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.Size = New System.Drawing.Size(511, 18)
        Me.txtPatientName.TabIndex = 257
        Me.txtPatientName.Text = "NAME"
        Me.txtPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAge
        '
        Me.txtAge.BackColor = System.Drawing.Color.Transparent
        Me.txtAge.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtAge.ForeColor = System.Drawing.Color.Black
        Me.txtAge.Location = New System.Drawing.Point(194, 114)
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
        Me.txtGender.Location = New System.Drawing.Point(79, 114)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.Size = New System.Drawing.Size(73, 18)
        Me.txtGender.TabIndex = 259
        Me.txtGender.Text = "Female"
        Me.txtGender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRequestedby
        '
        Me.txtRequestedby.BackColor = System.Drawing.Color.Transparent
        Me.txtRequestedby.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.txtRequestedby.ForeColor = System.Drawing.Color.Black
        Me.txtRequestedby.Location = New System.Drawing.Point(331, 113)
        Me.txtRequestedby.Name = "txtRequestedby"
        Me.txtRequestedby.Size = New System.Drawing.Size(231, 18)
        Me.txtRequestedby.TabIndex = 260
        Me.txtRequestedby.Text = "DR."
        Me.txtRequestedby.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'panelnewborn
        '
        Me.panelnewborn.Controls.Add(Me.txtcontactno)
        Me.panelnewborn.Controls.Add(Me.txtmother)
        Me.panelnewborn.Controls.Add(Me.Label2)
        Me.panelnewborn.Controls.Add(Me.ShapeContainer2)
        Me.panelnewborn.Location = New System.Drawing.Point(263, 113)
        Me.panelnewborn.Name = "panelnewborn"
        Me.panelnewborn.Size = New System.Drawing.Size(312, 26)
        Me.panelnewborn.TabIndex = 263
        Me.panelnewborn.Visible = False
        '
        'txtcontactno
        '
        Me.txtcontactno.BackColor = System.Drawing.Color.Transparent
        Me.txtcontactno.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.txtcontactno.ForeColor = System.Drawing.Color.Black
        Me.txtcontactno.Location = New System.Drawing.Point(337, 4)
        Me.txtcontactno.Name = "txtcontactno"
        Me.txtcontactno.Size = New System.Drawing.Size(131, 18)
        Me.txtcontactno.TabIndex = 262
        Me.txtcontactno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtcontactno.Visible = False
        '
        'txtmother
        '
        Me.txtmother.BackColor = System.Drawing.Color.Transparent
        Me.txtmother.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtmother.ForeColor = System.Drawing.Color.Black
        Me.txtmother.Location = New System.Drawing.Point(111, 2)
        Me.txtmother.Name = "txtmother"
        Me.txtmother.Size = New System.Drawing.Size(202, 18)
        Me.txtmother.TabIndex = 259
        Me.txtmother.Text = "NAME"
        Me.txtmother.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 18)
        Me.Label2.TabIndex = 258
        Me.Label2.Text = "Mother's Name:"
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape5})
        Me.ShapeContainer2.Size = New System.Drawing.Size(312, 26)
        Me.ShapeContainer2.TabIndex = 260
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape5
        '
        Me.LineShape5.Name = "LineShape5"
        Me.LineShape5.X1 = 107
        Me.LineShape5.X2 = 313
        Me.LineShape5.Y1 = 20
        Me.LineShape5.Y2 = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(44, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 18)
        Me.Label1.TabIndex = 264
        Me.Label1.Text = "Address:"
        '
        'lblpatientaddress
        '
        Me.lblpatientaddress.BackColor = System.Drawing.Color.Transparent
        Me.lblpatientaddress.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblpatientaddress.ForeColor = System.Drawing.Color.Black
        Me.lblpatientaddress.Location = New System.Drawing.Point(107, 135)
        Me.lblpatientaddress.Name = "lblpatientaddress"
        Me.lblpatientaddress.Size = New System.Drawing.Size(481, 18)
        Me.lblpatientaddress.TabIndex = 265
        Me.lblpatientaddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(611, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 14)
        Me.Label4.TabIndex = 266
        Me.Label4.Text = "Ptno:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(610, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 14)
        Me.Label5.TabIndex = 267
        Me.Label5.Text = "Print Date:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(610, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 14)
        Me.Label6.TabIndex = 268
        Me.Label6.Text = "Print Time:"
        '
        'lblptno
        '
        Me.lblptno.BackColor = System.Drawing.Color.Transparent
        Me.lblptno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblptno.ForeColor = System.Drawing.Color.Black
        Me.lblptno.Location = New System.Drawing.Point(645, 6)
        Me.lblptno.Name = "lblptno"
        Me.lblptno.Size = New System.Drawing.Size(89, 14)
        Me.lblptno.TabIndex = 269
        '
        'lblprintdate
        '
        Me.lblprintdate.BackColor = System.Drawing.Color.Transparent
        Me.lblprintdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprintdate.ForeColor = System.Drawing.Color.Black
        Me.lblprintdate.Location = New System.Drawing.Point(680, 24)
        Me.lblprintdate.Name = "lblprintdate"
        Me.lblprintdate.Size = New System.Drawing.Size(85, 14)
        Me.lblprintdate.TabIndex = 270
        '
        'lblprinttime
        '
        Me.lblprinttime.BackColor = System.Drawing.Color.Transparent
        Me.lblprinttime.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprinttime.ForeColor = System.Drawing.Color.Black
        Me.lblprinttime.Location = New System.Drawing.Point(681, 44)
        Me.lblprinttime.Name = "lblprinttime"
        Me.lblprinttime.Size = New System.Drawing.Size(85, 14)
        Me.lblprinttime.TabIndex = 271
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(575, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 17)
        Me.Label7.TabIndex = 273
        Me.Label7.Text = "Date Encoded:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(575, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 17)
        Me.Label8.TabIndex = 274
        Me.Label8.Text = "Time Encoded:"
        '
        'lbldateencoded
        '
        Me.lbldateencoded.BackColor = System.Drawing.Color.Transparent
        Me.lbldateencoded.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lbldateencoded.ForeColor = System.Drawing.Color.Black
        Me.lbldateencoded.Location = New System.Drawing.Point(660, 114)
        Me.lbldateencoded.Name = "lbldateencoded"
        Me.lbldateencoded.Size = New System.Drawing.Size(76, 18)
        Me.lbldateencoded.TabIndex = 275
        Me.lbldateencoded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbltimeencoded
        '
        Me.lbltimeencoded.BackColor = System.Drawing.Color.Transparent
        Me.lbltimeencoded.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.lbltimeencoded.ForeColor = System.Drawing.Color.Black
        Me.lbltimeencoded.Location = New System.Drawing.Point(663, 135)
        Me.lbltimeencoded.Name = "lbltimeencoded"
        Me.lbltimeencoded.Size = New System.Drawing.Size(73, 18)
        Me.lbltimeencoded.TabIndex = 276
        Me.lbltimeencoded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(610, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 14)
        Me.Label9.TabIndex = 277
        Me.Label9.Text = "Trans. Date:"
        '
        'lbltransdate
        '
        Me.lbltransdate.BackColor = System.Drawing.Color.Transparent
        Me.lbltransdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltransdate.ForeColor = System.Drawing.Color.Black
        Me.lbltransdate.Location = New System.Drawing.Point(682, 64)
        Me.lbltransdate.Name = "lbltransdate"
        Me.lbltransdate.Size = New System.Drawing.Size(83, 14)
        Me.lbltransdate.TabIndex = 278
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(610, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 14)
        Me.Label11.TabIndex = 279
        Me.Label11.Text = "Trans. Time:"
        '
        'lbltranstime
        '
        Me.lbltranstime.BackColor = System.Drawing.Color.Transparent
        Me.lbltranstime.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltranstime.ForeColor = System.Drawing.Color.Black
        Me.lbltranstime.Location = New System.Drawing.Point(682, 82)
        Me.lbltranstime.Name = "lbltranstime"
        Me.lbltranstime.Size = New System.Drawing.Size(83, 14)
        Me.lbltranstime.TabIndex = 280
        '
        'lblpatholicense
        '
        Me.lblpatholicense.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblpatholicense.BackColor = System.Drawing.Color.Transparent
        Me.lblpatholicense.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblpatholicense.ForeColor = System.Drawing.Color.Black
        Me.lblpatholicense.Location = New System.Drawing.Point(412, 355)
        Me.lblpatholicense.Name = "lblpatholicense"
        Me.lblpatholicense.Size = New System.Drawing.Size(319, 18)
        Me.lblpatholicense.TabIndex = 256
        Me.lblpatholicense.Text = "License No."
        Me.lblpatholicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblpathodesignation
        '
        Me.lblpathodesignation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblpathodesignation.BackColor = System.Drawing.Color.Transparent
        Me.lblpathodesignation.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.lblpathodesignation.ForeColor = System.Drawing.Color.Black
        Me.lblpathodesignation.Location = New System.Drawing.Point(409, 370)
        Me.lblpathodesignation.Name = "lblpathodesignation"
        Me.lblpathodesignation.Size = New System.Drawing.Size(326, 18)
        Me.lblpathodesignation.TabIndex = 255
        Me.lblpathodesignation.Text = "Clinical Pathologist"
        Me.lblpathodesignation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelpatho
        '
        Me.panelpatho.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelpatho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.panelpatho.Controls.Add(Me.txtResult)
        Me.panelpatho.Controls.Add(Me.lblpatho)
        Me.panelpatho.Location = New System.Drawing.Point(377, 305)
        Me.panelpatho.Name = "panelpatho"
        Me.panelpatho.Size = New System.Drawing.Size(360, 54)
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
        'lblpatho
        '
        Me.lblpatho.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblpatho.BackColor = System.Drawing.Color.Transparent
        Me.lblpatho.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblpatho.ForeColor = System.Drawing.Color.Black
        Me.lblpatho.Location = New System.Drawing.Point(25, 31)
        Me.lblpatho.Name = "lblpatho"
        Me.lblpatho.Size = New System.Drawing.Size(329, 19)
        Me.lblpatho.TabIndex = 273
        Me.lblpatho.Text = "Pathologist Name"
        Me.lblpatho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblpatho.Visible = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.EnableAutoDragDrop = True
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(47, 158)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(690, 141)
        Me.RichTextBox1.TabIndex = 281
        Me.RichTextBox1.Text = ""
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTextBoxColumn1.HeaderText = "Parameter"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridViewTextBoxColumn2.HeaderText = "Result"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 160
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle19
        Me.DataGridViewTextBoxColumn3.HeaderText = "Units"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle20
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
        'frmRTFPrint
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(789, 396)
        Me.ControlBox = False
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.panelpatho)
        Me.Controls.Add(Me.lblpatholicense)
        Me.Controls.Add(Me.lblpathodesignation)
        Me.Controls.Add(Me.panelnewborn)
        Me.Controls.Add(Me.lbltranstime)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lbltransdate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbltimeencoded)
        Me.Controls.Add(Me.lbldateencoded)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.pctrLogo)
        Me.Controls.Add(Me.lblprinttime)
        Me.Controls.Add(Me.lblprintdate)
        Me.Controls.Add(Me.lblptno)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblpatientaddress)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRequestedby)
        Me.Controls.Add(Me.txtGender)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.txtPatientName)
        Me.Controls.Add(Me.lablTelNo)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.lblpatientid)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.lblPatientname)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRTFPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TEST"
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelnewborn.ResumeLayout(False)
        Me.panelnewborn.PerformLayout()
        Me.panelpatho.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lineage As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents txtPatientName As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.Label
    Friend WithEvents txtGender As System.Windows.Forms.Label
    Friend WithEvents txtRequestedby As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents panelnewborn As System.Windows.Forms.Panel
    Friend WithEvents txtcontactno As System.Windows.Forms.Label
    Friend WithEvents txtmother As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape5 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblpatientaddress As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblptno As System.Windows.Forms.Label
    Friend WithEvents lblprintdate As System.Windows.Forms.Label
    Friend WithEvents lblprinttime As System.Windows.Forms.Label
    Friend WithEvents LineShape10 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape9 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbldateencoded As System.Windows.Forms.Label
    Friend WithEvents lbltimeencoded As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbltransdate As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbltranstime As System.Windows.Forms.Label
    Friend WithEvents lblpatholicense As System.Windows.Forms.Label
    Friend WithEvents lblpathodesignation As System.Windows.Forms.Label
    Friend WithEvents panelpatho As System.Windows.Forms.Panel
    Friend WithEvents lblpatho As System.Windows.Forms.Label
    Friend WithEvents txtResult As System.Windows.Forms.RichTextBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
End Class
