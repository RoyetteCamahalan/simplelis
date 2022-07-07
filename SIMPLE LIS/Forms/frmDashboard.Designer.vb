<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboard))
        Me.tsmain = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblpreviousdate = New System.Windows.Forms.ToolStripLabel()
        Me.tsfilteryby = New System.Windows.Forms.ToolStripComboBox()
        Me.tslblfilterby = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtsearch = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.dgMain = New System.Windows.Forms.DataGridView()
        Me.lblmodulename = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tsview = New System.Windows.Forms.ToolStripButton()
        Me.tsnew = New System.Windows.Forms.ToolStripButton()
        Me.tsedit = New System.Windows.Forms.ToolStripButton()
        Me.tsoptions = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsExaminationSchema = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDiagnosticTestMapping = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDiagnosticTests = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnsearch = New System.Windows.Forms.ToolStripButton()
        Me.tsmain.SuspendLayout()
        CType(Me.dgMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsmain
        '
        Me.tsmain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.tsview, Me.ToolStripSeparator1, Me.tsnew, Me.ToolStripSeparator2, Me.tsedit, Me.ToolStripSeparator3, Me.tsoptions, Me.tsClose, Me.lblpreviousdate, Me.tsfilteryby, Me.tslblfilterby, Me.ToolStripSeparator4, Me.tsbtnsearch, Me.txtsearch, Me.ToolStripLabel1})
        Me.tsmain.Location = New System.Drawing.Point(0, 0)
        Me.tsmain.Name = "tsmain"
        Me.tsmain.Padding = New System.Windows.Forms.Padding(0, 5, 1, 5)
        Me.tsmain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsmain.Size = New System.Drawing.Size(922, 33)
        Me.tsmain.TabIndex = 43
        Me.tsmain.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'lblpreviousdate
        '
        Me.lblpreviousdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblpreviousdate.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblpreviousdate.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lblpreviousdate.Name = "lblpreviousdate"
        Me.lblpreviousdate.Size = New System.Drawing.Size(0, 20)
        '
        'tsfilteryby
        '
        Me.tsfilteryby.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsfilteryby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tsfilteryby.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tsfilteryby.Name = "tsfilteryby"
        Me.tsfilteryby.Size = New System.Drawing.Size(150, 23)
        '
        'tslblfilterby
        '
        Me.tslblfilterby.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tslblfilterby.Name = "tslblfilterby"
        Me.tslblfilterby.Size = New System.Drawing.Size(52, 20)
        Me.tslblfilterby.Text = "Filter By:"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'txtsearch
        '
        Me.txtsearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(160, 23)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(45, 20)
        Me.ToolStripLabel1.Text = "Search:"
        '
        'dgMain
        '
        Me.dgMain.AllowUserToAddRows = False
        Me.dgMain.AllowUserToDeleteRows = False
        Me.dgMain.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMain.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CadetBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMain.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMain.Location = New System.Drawing.Point(0, 33)
        Me.dgMain.Name = "dgMain"
        Me.dgMain.ReadOnly = True
        Me.dgMain.RowHeadersVisible = False
        Me.dgMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMain.Size = New System.Drawing.Size(922, 335)
        Me.dgMain.TabIndex = 44
        '
        'lblmodulename
        '
        Me.lblmodulename.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblmodulename.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmodulename.ForeColor = System.Drawing.Color.CadetBlue
        Me.lblmodulename.Location = New System.Drawing.Point(299, 6)
        Me.lblmodulename.Name = "lblmodulename"
        Me.lblmodulename.Size = New System.Drawing.Size(308, 20)
        Me.lblmodulename.TabIndex = 45
        Me.lblmodulename.Text = "Label1"
        Me.lblmodulename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn2.HeaderText = "coloptionvalues"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "coloptionvalues"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "laboratorydetailsid"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "colfieldtype"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "coluuid"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "collocationx"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "collocationy"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "coldefaultvalue"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "collaboratoryresultdetailid"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "collabeltext"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "colwidth"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "colheight"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.SIMPLE_LIS.My.Resources.Resources.view_maintoolstrip
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(66, 20)
        Me.ToolStripButton1.Text = "Viewqq"
        '
        'tsview
        '
        Me.tsview.Image = Global.SIMPLE_LIS.My.Resources.Resources.view_maintoolstrip
        Me.tsview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsview.Name = "tsview"
        Me.tsview.Size = New System.Drawing.Size(52, 20)
        Me.tsview.Text = "View"
        '
        'tsnew
        '
        Me.tsnew.Image = Global.SIMPLE_LIS.My.Resources.Resources.application_add
        Me.tsnew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsnew.Name = "tsnew"
        Me.tsnew.Size = New System.Drawing.Size(51, 20)
        Me.tsnew.Text = "New"
        '
        'tsedit
        '
        Me.tsedit.Image = Global.SIMPLE_LIS.My.Resources.Resources.application_edit
        Me.tsedit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsedit.Name = "tsedit"
        Me.tsedit.Size = New System.Drawing.Size(47, 20)
        Me.tsedit.Text = "Edit"
        '
        'tsoptions
        '
        Me.tsoptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsExaminationSchema, Me.tsDiagnosticTestMapping, Me.tsDiagnosticTests})
        Me.tsoptions.Image = Global.SIMPLE_LIS.My.Resources.Resources.ic_gear_16
        Me.tsoptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsoptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsoptions.Name = "tsoptions"
        Me.tsoptions.Size = New System.Drawing.Size(105, 20)
        Me.tsoptions.Text = "Components"
        '
        'tsExaminationSchema
        '
        Me.tsExaminationSchema.Name = "tsExaminationSchema"
        Me.tsExaminationSchema.Size = New System.Drawing.Size(204, 22)
        Me.tsExaminationSchema.Text = "Examination Schema"
        '
        'tsDiagnosticTestMapping
        '
        Me.tsDiagnosticTestMapping.Name = "tsDiagnosticTestMapping"
        Me.tsDiagnosticTestMapping.Size = New System.Drawing.Size(204, 22)
        Me.tsDiagnosticTestMapping.Text = "Diagnostic Test Mapping"
        '
        'tsDiagnosticTests
        '
        Me.tsDiagnosticTests.Name = "tsDiagnosticTests"
        Me.tsDiagnosticTests.Size = New System.Drawing.Size(204, 22)
        Me.tsDiagnosticTests.Text = "Diagnostic Tests"
        '
        'tsClose
        '
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(56, 20)
        Me.tsClose.Text = "Close"
        '
        'tsbtnsearch
        '
        Me.tsbtnsearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnsearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnsearch.Image = Global.SIMPLE_LIS.My.Resources.Resources.search_glyph
        Me.tsbtnsearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnsearch.Name = "tsbtnsearch"
        Me.tsbtnsearch.Size = New System.Drawing.Size(23, 20)
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 368)
        Me.Controls.Add(Me.lblmodulename)
        Me.Controls.Add(Me.dgMain)
        Me.Controls.Add(Me.tsmain)
        Me.Name = "frmDashboard"
        Me.Text = "LIS Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsmain.ResumeLayout(False)
        Me.tsmain.PerformLayout()
        CType(Me.dgMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tsmain As System.Windows.Forms.ToolStrip
    Public WithEvents tsnew As System.Windows.Forms.ToolStripButton
    Public WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents tsoptions As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsExaminationSchema As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsDiagnosticTestMapping As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents tsview As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsedit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsfilteryby As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tslblfilterby As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblpreviousdate As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dgMain As System.Windows.Forms.DataGridView
    Friend WithEvents txtsearch As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbtnsearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDiagnosticTests As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblmodulename As System.Windows.Forms.Label
    Public WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
