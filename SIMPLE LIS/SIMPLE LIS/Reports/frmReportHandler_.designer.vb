<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportHandler
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportHandler))
        Me.crptViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsSystem = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblTelno = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtPyearDOH = New System.Windows.Forms.DateTimePicker()
        Me.cmbMonthDOH = New System.Windows.Forms.ComboBox()
        Me.lblQuarter = New System.Windows.Forms.Label()
        Me.grpbxCashierReports = New System.Windows.Forms.GroupBox()
        Me.dtpEndTimeCR = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartTimeCR = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateToCR = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateFromCR = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grpDOH = New System.Windows.Forms.GroupBox()
        Me.crptDOHPage10 = New System.Windows.Forms.Button()
        Me.crptDOHPage9 = New System.Windows.Forms.Button()
        Me.crptDOHPage8 = New System.Windows.Forms.Button()
        Me.crptDOHPage7 = New System.Windows.Forms.Button()
        Me.crptDOHPage6 = New System.Windows.Forms.Button()
        Me.crptDOHPage5 = New System.Windows.Forms.Button()
        Me.crptDOHPage4 = New System.Windows.Forms.Button()
        Me.crptDOHPage3 = New System.Windows.Forms.Button()
        Me.crptDOHPage2 = New System.Windows.Forms.Button()
        Me.crptDOHPage1 = New System.Windows.Forms.Button()
        Me.cmICD10CodeDOH = New System.Windows.Forms.ComboBox()
        Me.lblICD10Code = New System.Windows.Forms.Label()
        Me.dtpEndTimeDOH = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartTimeDOH = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateToDOH = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateFromDOH = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tsModule = New System.Windows.Forms.Button()
        Me.grpLaboratory = New System.Windows.Forms.GroupBox()
        Me.dtEndLaboratory = New System.Windows.Forms.DateTimePicker()
        Me.dtStartlaboratory = New System.Windows.Forms.DateTimePicker()
        Me.dtToLaboratory = New System.Windows.Forms.DateTimePicker()
        Me.dtFromlaboratory = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grpMedicalRecords = New System.Windows.Forms.GroupBox()
        Me.txtpurpose = New System.Windows.Forms.TextBox()
        Me.dtEndTimeMedicalRecords = New System.Windows.Forms.DateTimePicker()
        Me.dtStartTimeMedicalRecords = New System.Windows.Forms.DateTimePicker()
        Me.dtToMedicalRecords = New System.Windows.Forms.DateTimePicker()
        Me.dtFromMedicalRecords = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgGenericList = New System.Windows.Forms.DataGridView()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.dtpYearMedicalRecords = New System.Windows.Forms.DateTimePicker()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmbMonthMedicalRecords = New System.Windows.Forms.ComboBox()
        Me.cmbfilterby = New System.Windows.Forms.ComboBox()
        Me.grpRadiology = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmfilm = New System.Windows.Forms.ComboBox()
        Me.cmbOffice = New System.Windows.Forms.ComboBox()
        Me.dtEndtimeRadiology = New System.Windows.Forms.DateTimePicker()
        Me.dtStarttimeradiology = New System.Windows.Forms.DateTimePicker()
        Me.dtToRadiology = New System.Windows.Forms.DateTimePicker()
        Me.dtfromradiology = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpForms = New System.Windows.Forms.GroupBox()
        Me.btnSearchForms = New System.Windows.Forms.Button()
        Me.dgGenericList2 = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSearchForms = New System.Windows.Forms.TextBox()
        Me.lblCompanyname = New System.Windows.Forms.LinkLabel()
        Me.pctrLogo = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsExportToPDF = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEmail = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsSearchtext = New System.Windows.Forms.ToolStripTextBox()
        Me.tsSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsFirstPage = New System.Windows.Forms.ToolStripButton()
        Me.tsPrev = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsNext = New System.Windows.Forms.ToolStripButton()
        Me.tsLastPage = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsZoom = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.grpFinancialReport = New System.Windows.Forms.GroupBox()
        Me.grpAccountPayableTrade = New System.Windows.Forms.GroupBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.dtAccountPayabaleTradeDate = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblieforAgedPayable = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkincludeoverdueinvoiceonly = New System.Windows.Forms.CheckBox()
        Me.chkshowDetails = New System.Windows.Forms.CheckBox()
        Me.tscombobranch = New System.Windows.Forms.ComboBox()
        Me.tsSupplier = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbinvoicesummaryyear = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblInvoicesummarymonth = New System.Windows.Forms.Label()
        Me.Dateto = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbPeriod = New System.Windows.Forms.ComboBox()
        Me.cmbInvoiceSummary = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblinvociesummaryyear = New System.Windows.Forms.Label()
        Me.Datefrom = New System.Windows.Forms.DateTimePicker()
        Me.cmbDateType = New System.Windows.Forms.ComboBox()
        Me.dtEndTimeFinancial = New System.Windows.Forms.DateTimePicker()
        Me.dtStartTimeFinancial = New System.Windows.Forms.DateTimePicker()
        Me.dtToFinancial = New System.Windows.Forms.DateTimePicker()
        Me.dtFromFinancial = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.grpPharmacy = New System.Windows.Forms.GroupBox()
        Me.lblEmployeePharma = New System.Windows.Forms.Label()
        Me.cmbPharmaEmployee = New System.Windows.Forms.ComboBox()
        Me.cmbPharmaOffice = New System.Windows.Forms.ComboBox()
        Me.lblOfficePharma = New System.Windows.Forms.Label()
        Me.dtEndTimePharmacy = New System.Windows.Forms.DateTimePicker()
        Me.dtStartTimePharmacy = New System.Windows.Forms.DateTimePicker()
        Me.dtToPharmacy = New System.Windows.Forms.DateTimePicker()
        Me.dtFromPharmacy = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.grpInventoryHistory = New System.Windows.Forms.GroupBox()
        Me.grpInventorySearch = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.pcSearch = New System.Windows.Forms.PictureBox()
        Me.txtInventorySearch = New System.Windows.Forms.TextBox()
        Me.pnlInventoryBatch1 = New System.Windows.Forms.Panel()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.pnlInventoryBatch1Sub = New System.Windows.Forms.Panel()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cbExcludeReceivedStocks = New System.Windows.Forms.CheckBox()
        Me.numDays = New System.Windows.Forms.NumericUpDown()
        Me.cbExcludeItemswithZeroQty = New System.Windows.Forms.CheckBox()
        Me.cbIncludeStockTransOut = New System.Windows.Forms.CheckBox()
        Me.pnlInventoryHistory = New System.Windows.Forms.Panel()
        Me.pnlInventoryHistorySub = New System.Windows.Forms.Panel()
        Me.chklotno = New System.Windows.Forms.CheckBox()
        Me.cmblotno = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.pnlItems = New System.Windows.Forms.Label()
        Me.picSearch = New System.Windows.Forms.PictureBox()
        Me.cmbInventoryHistoryReport = New System.Windows.Forms.ComboBox()
        Me.pnlInventory = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblInventoryStartDate = New System.Windows.Forms.Label()
        Me.cmbInventoryHitoryOffice = New System.Windows.Forms.ComboBox()
        Me.lblInventoryEndDate = New System.Windows.Forms.Label()
        Me.dtpInventoryHistoryEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpInventoryHistoryStartDate = New System.Windows.Forms.DateTimePicker()
        Me.pnlInventoryBatch2 = New System.Windows.Forms.Panel()
        Me.pnlInventoryBatch2Sub = New System.Windows.Forms.Panel()
        Me.lblMonths = New System.Windows.Forms.Label()
        Me.txtNearExpiryDate = New System.Windows.Forms.TextBox()
        Me.cbNearExpiryDate = New System.Windows.Forms.CheckBox()
        Me.cmbNearExpiryDate = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        Me.cbIncludeNegativeQuantity = New System.Windows.Forms.CheckBox()
        Me.cbIncludeZeroQty = New System.Windows.Forms.CheckBox()
        Me.cbOrderByExpiry = New System.Windows.Forms.CheckBox()
        Me.cbShowLotNo = New System.Windows.Forms.CheckBox()
        Me.pnlInventoryStatus = New System.Windows.Forms.Panel()
        Me.cbStatusCategory = New System.Windows.Forms.CheckBox()
        Me.cbStatusSupplier = New System.Windows.Forms.CheckBox()
        Me.cmbStatusCategory = New System.Windows.Forms.ComboBox()
        Me.cmbStatusSupplier = New System.Windows.Forms.ComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.pnlItemInventoryStatusByOffice = New System.Windows.Forms.Panel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.pnlItems2 = New System.Windows.Forms.Label()
        Me.pbItemSearch = New System.Windows.Forms.PictureBox()
        Me.pctrshow = New System.Windows.Forms.PictureBox()
        Me.pctrHide = New System.Windows.Forms.PictureBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsAutoHide = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpbxCashierReports.SuspendLayout()
        Me.grpDOH.SuspendLayout()
        Me.grpLaboratory.SuspendLayout()
        Me.grpMedicalRecords.SuspendLayout()
        CType(Me.dgGenericList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRadiology.SuspendLayout()
        Me.grpForms.SuspendLayout()
        CType(Me.dgGenericList2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.grpFinancialReport.SuspendLayout()
        Me.grpAccountPayableTrade.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.grpPharmacy.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInventoryHistory.SuspendLayout()
        Me.grpInventorySearch.SuspendLayout()
        CType(Me.pcSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInventoryBatch1.SuspendLayout()
        Me.pnlInventoryBatch1Sub.SuspendLayout()
        CType(Me.numDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInventoryHistory.SuspendLayout()
        Me.pnlInventoryHistorySub.SuspendLayout()
        CType(Me.picSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInventory.SuspendLayout()
        Me.pnlInventoryBatch2.SuspendLayout()
        Me.pnlInventoryBatch2Sub.SuspendLayout()
        Me.pnlInventoryStatus.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlItemInventoryStatusByOffice.SuspendLayout()
        CType(Me.pbItemSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctrshow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctrHide, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'crptViewer
        '
        Me.crptViewer.ActiveViewIndex = -1
        Me.crptViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crptViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.crptViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crptViewer.DisplayBackgroundEdge = False
        Me.crptViewer.DisplayToolbar = False
        Me.crptViewer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crptViewer.Location = New System.Drawing.Point(0, 45)
        Me.crptViewer.Name = "crptViewer"
        Me.crptViewer.SelectionFormula = ""
        Me.crptViewer.Size = New System.Drawing.Size(1020, 574)
        Me.crptViewer.TabIndex = 0
        Me.crptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crptViewer.ViewTimeSelectionFormula = ""
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.Color.Khaki
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSystem})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 597)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(220, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsSystem
        '
        Me.tsSystem.Font = New System.Drawing.Font("Mistral", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsSystem.Name = "tsSystem"
        Me.tsSystem.Size = New System.Drawing.Size(16, 17)
        Me.tsSystem.Text = "..."
        Me.tsSystem.Visible = False
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblAddress.Location = New System.Drawing.Point(76, 27)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(25, 15)
        Me.lblAddress.TabIndex = 6
        Me.lblAddress.Text = "$$$"
        '
        'lblTelno
        '
        Me.lblTelno.AutoSize = True
        Me.lblTelno.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTelno.Location = New System.Drawing.Point(76, 46)
        Me.lblTelno.Name = "lblTelno"
        Me.lblTelno.Size = New System.Drawing.Size(25, 13)
        Me.lblTelno.TabIndex = 7
        Me.lblTelno.Text = "$$$"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.ColumnHeadersHeight = 44
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.DataGridView1.Location = New System.Drawing.Point(4, 1)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(214, 609)
        Me.DataGridView1.TabIndex = 9
        '
        'Column1
        '
        Me.Column1.HeaderText = "Tools"
        Me.Column1.Name = "Column1"
        '
        'dtPyearDOH
        '
        Me.dtPyearDOH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtPyearDOH.CustomFormat = "yyyy"
        Me.dtPyearDOH.Enabled = False
        Me.dtPyearDOH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPyearDOH.Location = New System.Drawing.Point(110, 114)
        Me.dtPyearDOH.Name = "dtPyearDOH"
        Me.dtPyearDOH.ShowUpDown = True
        Me.dtPyearDOH.Size = New System.Drawing.Size(90, 21)
        Me.dtPyearDOH.TabIndex = 88
        Me.dtPyearDOH.Value = New Date(2012, 8, 14, 16, 12, 49, 0)
        '
        'cmbMonthDOH
        '
        Me.cmbMonthDOH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbMonthDOH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonthDOH.Enabled = False
        Me.cmbMonthDOH.FormattingEnabled = True
        Me.cmbMonthDOH.Location = New System.Drawing.Point(5, 113)
        Me.cmbMonthDOH.Name = "cmbMonthDOH"
        Me.cmbMonthDOH.Size = New System.Drawing.Size(104, 21)
        Me.cmbMonthDOH.TabIndex = 87
        '
        'lblQuarter
        '
        Me.lblQuarter.AutoSize = True
        Me.lblQuarter.BackColor = System.Drawing.Color.Transparent
        Me.lblQuarter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuarter.ForeColor = System.Drawing.Color.Black
        Me.lblQuarter.Location = New System.Drawing.Point(8, 98)
        Me.lblQuarter.Name = "lblQuarter"
        Me.lblQuarter.Size = New System.Drawing.Size(51, 15)
        Me.lblQuarter.TabIndex = 86
        Me.lblQuarter.Text = "Quarter:"
        Me.lblQuarter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpbxCashierReports
        '
        Me.grpbxCashierReports.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpbxCashierReports.BackColor = System.Drawing.Color.White
        Me.grpbxCashierReports.Controls.Add(Me.dtpEndTimeCR)
        Me.grpbxCashierReports.Controls.Add(Me.dtpStartTimeCR)
        Me.grpbxCashierReports.Controls.Add(Me.dtpDateToCR)
        Me.grpbxCashierReports.Controls.Add(Me.dtpDateFromCR)
        Me.grpbxCashierReports.Controls.Add(Me.lblEndDate)
        Me.grpbxCashierReports.Controls.Add(Me.lblStartDate)
        Me.grpbxCashierReports.Location = New System.Drawing.Point(6, 46)
        Me.grpbxCashierReports.Name = "grpbxCashierReports"
        Me.grpbxCashierReports.Size = New System.Drawing.Size(208, 174)
        Me.grpbxCashierReports.TabIndex = 89
        Me.grpbxCashierReports.TabStop = False
        Me.grpbxCashierReports.Text = "Cashier"
        Me.grpbxCashierReports.Visible = False
        '
        'dtpEndTimeCR
        '
        Me.dtpEndTimeCR.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndTimeCR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpEndTimeCR.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpEndTimeCR.Location = New System.Drawing.Point(109, 65)
        Me.dtpEndTimeCR.Name = "dtpEndTimeCR"
        Me.dtpEndTimeCR.ShowUpDown = True
        Me.dtpEndTimeCR.Size = New System.Drawing.Size(91, 21)
        Me.dtpEndTimeCR.TabIndex = 94
        '
        'dtpStartTimeCR
        '
        Me.dtpStartTimeCR.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartTimeCR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpStartTimeCR.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpStartTimeCR.Location = New System.Drawing.Point(110, 27)
        Me.dtpStartTimeCR.Name = "dtpStartTimeCR"
        Me.dtpStartTimeCR.ShowUpDown = True
        Me.dtpStartTimeCR.Size = New System.Drawing.Size(90, 21)
        Me.dtpStartTimeCR.TabIndex = 93
        '
        'dtpDateToCR
        '
        Me.dtpDateToCR.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateToCR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpDateToCR.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateToCR.Location = New System.Drawing.Point(9, 65)
        Me.dtpDateToCR.Name = "dtpDateToCR"
        Me.dtpDateToCR.Size = New System.Drawing.Size(99, 21)
        Me.dtpDateToCR.TabIndex = 90
        '
        'dtpDateFromCR
        '
        Me.dtpDateFromCR.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFromCR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpDateFromCR.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFromCR.Location = New System.Drawing.Point(10, 27)
        Me.dtpDateFromCR.Name = "dtpDateFromCR"
        Me.dtpDateFromCR.Size = New System.Drawing.Size(99, 21)
        Me.dtpDateFromCR.TabIndex = 89
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEndDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndDate.ForeColor = System.Drawing.Color.Black
        Me.lblEndDate.Location = New System.Drawing.Point(8, 53)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(57, 13)
        Me.lblEndDate.TabIndex = 92
        Me.lblEndDate.Text = "End Date:"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
        Me.lblStartDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDate.ForeColor = System.Drawing.Color.Black
        Me.lblStartDate.Location = New System.Drawing.Point(8, 15)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(61, 13)
        Me.lblStartDate.TabIndex = 91
        Me.lblStartDate.Text = "Start Date:"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 597)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(218, 2)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'grpDOH
        '
        Me.grpDOH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpDOH.BackColor = System.Drawing.Color.White
        Me.grpDOH.Controls.Add(Me.crptDOHPage10)
        Me.grpDOH.Controls.Add(Me.crptDOHPage9)
        Me.grpDOH.Controls.Add(Me.crptDOHPage8)
        Me.grpDOH.Controls.Add(Me.crptDOHPage7)
        Me.grpDOH.Controls.Add(Me.crptDOHPage6)
        Me.grpDOH.Controls.Add(Me.crptDOHPage5)
        Me.grpDOH.Controls.Add(Me.crptDOHPage4)
        Me.grpDOH.Controls.Add(Me.crptDOHPage3)
        Me.grpDOH.Controls.Add(Me.crptDOHPage2)
        Me.grpDOH.Controls.Add(Me.crptDOHPage1)
        Me.grpDOH.Controls.Add(Me.cmICD10CodeDOH)
        Me.grpDOH.Controls.Add(Me.lblICD10Code)
        Me.grpDOH.Controls.Add(Me.dtpEndTimeDOH)
        Me.grpDOH.Controls.Add(Me.dtpStartTimeDOH)
        Me.grpDOH.Controls.Add(Me.dtpDateToDOH)
        Me.grpDOH.Controls.Add(Me.dtpDateFromDOH)
        Me.grpDOH.Controls.Add(Me.Label1)
        Me.grpDOH.Controls.Add(Me.Label2)
        Me.grpDOH.Controls.Add(Me.lblQuarter)
        Me.grpDOH.Controls.Add(Me.dtPyearDOH)
        Me.grpDOH.Controls.Add(Me.cmbMonthDOH)
        Me.grpDOH.Location = New System.Drawing.Point(7, 47)
        Me.grpDOH.Name = "grpDOH"
        Me.grpDOH.Size = New System.Drawing.Size(210, 344)
        Me.grpDOH.TabIndex = 95
        Me.grpDOH.TabStop = False
        Me.grpDOH.Text = "DOH"
        Me.grpDOH.Visible = False
        '
        'crptDOHPage10
        '
        Me.crptDOHPage10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.crptDOHPage10.Enabled = False
        Me.crptDOHPage10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.crptDOHPage10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crptDOHPage10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.crptDOHPage10.Location = New System.Drawing.Point(56, 188)
        Me.crptDOHPage10.Name = "crptDOHPage10"
        Me.crptDOHPage10.Size = New System.Drawing.Size(55, 23)
        Me.crptDOHPage10.TabIndex = 106
        Me.crptDOHPage10.Text = "Page 10"
        Me.crptDOHPage10.UseVisualStyleBackColor = True
        '
        'crptDOHPage9
        '
        Me.crptDOHPage9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.crptDOHPage9.Enabled = False
        Me.crptDOHPage9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.crptDOHPage9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crptDOHPage9.Location = New System.Drawing.Point(5, 188)
        Me.crptDOHPage9.Name = "crptDOHPage9"
        Me.crptDOHPage9.Size = New System.Drawing.Size(50, 23)
        Me.crptDOHPage9.TabIndex = 105
        Me.crptDOHPage9.Text = "Page 9"
        Me.crptDOHPage9.UseVisualStyleBackColor = True
        '
        'crptDOHPage8
        '
        Me.crptDOHPage8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.crptDOHPage8.Enabled = False
        Me.crptDOHPage8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.crptDOHPage8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crptDOHPage8.Location = New System.Drawing.Point(158, 164)
        Me.crptDOHPage8.Name = "crptDOHPage8"
        Me.crptDOHPage8.Size = New System.Drawing.Size(50, 23)
        Me.crptDOHPage8.TabIndex = 104
        Me.crptDOHPage8.Text = "Page 8"
        Me.crptDOHPage8.UseVisualStyleBackColor = True
        '
        'crptDOHPage7
        '
        Me.crptDOHPage7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.crptDOHPage7.Enabled = False
        Me.crptDOHPage7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.crptDOHPage7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crptDOHPage7.Location = New System.Drawing.Point(107, 164)
        Me.crptDOHPage7.Name = "crptDOHPage7"
        Me.crptDOHPage7.Size = New System.Drawing.Size(50, 23)
        Me.crptDOHPage7.TabIndex = 103
        Me.crptDOHPage7.Text = "Page 7"
        Me.crptDOHPage7.UseVisualStyleBackColor = True
        '
        'crptDOHPage6
        '
        Me.crptDOHPage6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.crptDOHPage6.Enabled = False
        Me.crptDOHPage6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.crptDOHPage6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crptDOHPage6.Location = New System.Drawing.Point(56, 164)
        Me.crptDOHPage6.Name = "crptDOHPage6"
        Me.crptDOHPage6.Size = New System.Drawing.Size(50, 23)
        Me.crptDOHPage6.TabIndex = 102
        Me.crptDOHPage6.Text = "Page 6"
        Me.crptDOHPage6.UseVisualStyleBackColor = True
        '
        'crptDOHPage5
        '
        Me.crptDOHPage5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.crptDOHPage5.Enabled = False
        Me.crptDOHPage5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.crptDOHPage5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crptDOHPage5.Location = New System.Drawing.Point(5, 164)
        Me.crptDOHPage5.Name = "crptDOHPage5"
        Me.crptDOHPage5.Size = New System.Drawing.Size(50, 23)
        Me.crptDOHPage5.TabIndex = 101
        Me.crptDOHPage5.Text = "Page 5"
        Me.crptDOHPage5.UseVisualStyleBackColor = True
        '
        'crptDOHPage4
        '
        Me.crptDOHPage4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.crptDOHPage4.Enabled = False
        Me.crptDOHPage4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.crptDOHPage4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crptDOHPage4.Location = New System.Drawing.Point(158, 140)
        Me.crptDOHPage4.Name = "crptDOHPage4"
        Me.crptDOHPage4.Size = New System.Drawing.Size(50, 23)
        Me.crptDOHPage4.TabIndex = 100
        Me.crptDOHPage4.Text = "Page 4"
        Me.crptDOHPage4.UseVisualStyleBackColor = True
        '
        'crptDOHPage3
        '
        Me.crptDOHPage3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.crptDOHPage3.Enabled = False
        Me.crptDOHPage3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.crptDOHPage3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crptDOHPage3.Location = New System.Drawing.Point(107, 140)
        Me.crptDOHPage3.Name = "crptDOHPage3"
        Me.crptDOHPage3.Size = New System.Drawing.Size(50, 23)
        Me.crptDOHPage3.TabIndex = 99
        Me.crptDOHPage3.Text = "Page 3"
        Me.crptDOHPage3.UseVisualStyleBackColor = True
        '
        'crptDOHPage2
        '
        Me.crptDOHPage2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.crptDOHPage2.Enabled = False
        Me.crptDOHPage2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.crptDOHPage2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crptDOHPage2.Location = New System.Drawing.Point(56, 140)
        Me.crptDOHPage2.Name = "crptDOHPage2"
        Me.crptDOHPage2.Size = New System.Drawing.Size(50, 23)
        Me.crptDOHPage2.TabIndex = 98
        Me.crptDOHPage2.Text = "Page 2"
        Me.crptDOHPage2.UseVisualStyleBackColor = True
        '
        'crptDOHPage1
        '
        Me.crptDOHPage1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.crptDOHPage1.Enabled = False
        Me.crptDOHPage1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.crptDOHPage1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crptDOHPage1.Location = New System.Drawing.Point(5, 140)
        Me.crptDOHPage1.Name = "crptDOHPage1"
        Me.crptDOHPage1.Size = New System.Drawing.Size(50, 23)
        Me.crptDOHPage1.TabIndex = 97
        Me.crptDOHPage1.Text = "Page 1"
        Me.crptDOHPage1.UseVisualStyleBackColor = True
        '
        'cmICD10CodeDOH
        '
        Me.cmICD10CodeDOH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmICD10CodeDOH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmICD10CodeDOH.Enabled = False
        Me.cmICD10CodeDOH.FormattingEnabled = True
        Me.cmICD10CodeDOH.Location = New System.Drawing.Point(9, 253)
        Me.cmICD10CodeDOH.Name = "cmICD10CodeDOH"
        Me.cmICD10CodeDOH.Size = New System.Drawing.Size(189, 21)
        Me.cmICD10CodeDOH.TabIndex = 95
        '
        'lblICD10Code
        '
        Me.lblICD10Code.AutoSize = True
        Me.lblICD10Code.BackColor = System.Drawing.Color.Transparent
        Me.lblICD10Code.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblICD10Code.ForeColor = System.Drawing.Color.Black
        Me.lblICD10Code.Location = New System.Drawing.Point(8, 239)
        Me.lblICD10Code.Name = "lblICD10Code"
        Me.lblICD10Code.Size = New System.Drawing.Size(74, 15)
        Me.lblICD10Code.TabIndex = 96
        Me.lblICD10Code.Text = "ICD10-Code:"
        Me.lblICD10Code.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpEndTimeDOH
        '
        Me.dtpEndTimeDOH.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndTimeDOH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpEndTimeDOH.Enabled = False
        Me.dtpEndTimeDOH.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpEndTimeDOH.Location = New System.Drawing.Point(109, 65)
        Me.dtpEndTimeDOH.Name = "dtpEndTimeDOH"
        Me.dtpEndTimeDOH.ShowUpDown = True
        Me.dtpEndTimeDOH.Size = New System.Drawing.Size(91, 21)
        Me.dtpEndTimeDOH.TabIndex = 94
        '
        'dtpStartTimeDOH
        '
        Me.dtpStartTimeDOH.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartTimeDOH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpStartTimeDOH.Enabled = False
        Me.dtpStartTimeDOH.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpStartTimeDOH.Location = New System.Drawing.Point(110, 27)
        Me.dtpStartTimeDOH.Name = "dtpStartTimeDOH"
        Me.dtpStartTimeDOH.ShowUpDown = True
        Me.dtpStartTimeDOH.Size = New System.Drawing.Size(90, 21)
        Me.dtpStartTimeDOH.TabIndex = 93
        '
        'dtpDateToDOH
        '
        Me.dtpDateToDOH.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateToDOH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpDateToDOH.Enabled = False
        Me.dtpDateToDOH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateToDOH.Location = New System.Drawing.Point(9, 65)
        Me.dtpDateToDOH.Name = "dtpDateToDOH"
        Me.dtpDateToDOH.Size = New System.Drawing.Size(99, 21)
        Me.dtpDateToDOH.TabIndex = 90
        '
        'dtpDateFromDOH
        '
        Me.dtpDateFromDOH.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFromDOH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpDateFromDOH.Enabled = False
        Me.dtpDateFromDOH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFromDOH.Location = New System.Drawing.Point(10, 27)
        Me.dtpDateFromDOH.Name = "dtpDateFromDOH"
        Me.dtpDateFromDOH.Size = New System.Drawing.Size(99, 21)
        Me.dtpDateFromDOH.TabIndex = 89
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "End Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Start Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tsModule
        '
        Me.tsModule.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tsModule.BackColor = System.Drawing.Color.Khaki
        Me.tsModule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tsModule.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tsModule.FlatAppearance.BorderSize = 0
        Me.tsModule.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.tsModule.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsModule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsModule.Location = New System.Drawing.Point(85, 50)
        Me.tsModule.Name = "tsModule"
        Me.tsModule.Size = New System.Drawing.Size(930, 20)
        Me.tsModule.TabIndex = 96
        Me.tsModule.Text = "$$$$"
        Me.tsModule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tsModule.UseVisualStyleBackColor = False
        '
        'grpLaboratory
        '
        Me.grpLaboratory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpLaboratory.BackColor = System.Drawing.Color.White
        Me.grpLaboratory.Controls.Add(Me.dtEndLaboratory)
        Me.grpLaboratory.Controls.Add(Me.dtStartlaboratory)
        Me.grpLaboratory.Controls.Add(Me.dtToLaboratory)
        Me.grpLaboratory.Controls.Add(Me.dtFromlaboratory)
        Me.grpLaboratory.Controls.Add(Me.Label4)
        Me.grpLaboratory.Controls.Add(Me.Label5)
        Me.grpLaboratory.Location = New System.Drawing.Point(6, 47)
        Me.grpLaboratory.Name = "grpLaboratory"
        Me.grpLaboratory.Size = New System.Drawing.Size(210, 268)
        Me.grpLaboratory.TabIndex = 97
        Me.grpLaboratory.TabStop = False
        Me.grpLaboratory.Text = "Laboratory"
        Me.grpLaboratory.Visible = False
        '
        'dtEndLaboratory
        '
        Me.dtEndLaboratory.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEndLaboratory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtEndLaboratory.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtEndLaboratory.Location = New System.Drawing.Point(109, 65)
        Me.dtEndLaboratory.Name = "dtEndLaboratory"
        Me.dtEndLaboratory.ShowUpDown = True
        Me.dtEndLaboratory.Size = New System.Drawing.Size(91, 21)
        Me.dtEndLaboratory.TabIndex = 94
        '
        'dtStartlaboratory
        '
        Me.dtStartlaboratory.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStartlaboratory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtStartlaboratory.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtStartlaboratory.Location = New System.Drawing.Point(110, 27)
        Me.dtStartlaboratory.Name = "dtStartlaboratory"
        Me.dtStartlaboratory.ShowUpDown = True
        Me.dtStartlaboratory.Size = New System.Drawing.Size(90, 21)
        Me.dtStartlaboratory.TabIndex = 93
        '
        'dtToLaboratory
        '
        Me.dtToLaboratory.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToLaboratory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtToLaboratory.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToLaboratory.Location = New System.Drawing.Point(9, 65)
        Me.dtToLaboratory.Name = "dtToLaboratory"
        Me.dtToLaboratory.Size = New System.Drawing.Size(99, 21)
        Me.dtToLaboratory.TabIndex = 90
        '
        'dtFromlaboratory
        '
        Me.dtFromlaboratory.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromlaboratory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtFromlaboratory.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFromlaboratory.Location = New System.Drawing.Point(10, 27)
        Me.dtFromlaboratory.Name = "dtFromlaboratory"
        Me.dtFromlaboratory.Size = New System.Drawing.Size(99, 21)
        Me.dtFromlaboratory.TabIndex = 89
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "End Date:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "Start Date:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpMedicalRecords
        '
        Me.grpMedicalRecords.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpMedicalRecords.BackColor = System.Drawing.Color.White
        Me.grpMedicalRecords.Controls.Add(Me.txtpurpose)
        Me.grpMedicalRecords.Controls.Add(Me.dtEndTimeMedicalRecords)
        Me.grpMedicalRecords.Controls.Add(Me.dtStartTimeMedicalRecords)
        Me.grpMedicalRecords.Controls.Add(Me.dtToMedicalRecords)
        Me.grpMedicalRecords.Controls.Add(Me.dtFromMedicalRecords)
        Me.grpMedicalRecords.Controls.Add(Me.Label10)
        Me.grpMedicalRecords.Controls.Add(Me.Label12)
        Me.grpMedicalRecords.Controls.Add(Me.btnSearch)
        Me.grpMedicalRecords.Controls.Add(Me.Label8)
        Me.grpMedicalRecords.Controls.Add(Me.dgGenericList)
        Me.grpMedicalRecords.Controls.Add(Me.lblSearch)
        Me.grpMedicalRecords.Controls.Add(Me.dtpYearMedicalRecords)
        Me.grpMedicalRecords.Controls.Add(Me.txtSearch)
        Me.grpMedicalRecords.Controls.Add(Me.cmbMonthMedicalRecords)
        Me.grpMedicalRecords.Controls.Add(Me.cmbfilterby)
        Me.grpMedicalRecords.Location = New System.Drawing.Point(6, 48)
        Me.grpMedicalRecords.Name = "grpMedicalRecords"
        Me.grpMedicalRecords.Size = New System.Drawing.Size(210, 542)
        Me.grpMedicalRecords.TabIndex = 98
        Me.grpMedicalRecords.TabStop = False
        Me.grpMedicalRecords.Text = "Medical Records"
        Me.grpMedicalRecords.Visible = False
        '
        'txtpurpose
        '
        Me.txtpurpose.Location = New System.Drawing.Point(6, 31)
        Me.txtpurpose.Multiline = True
        Me.txtpurpose.Name = "txtpurpose"
        Me.txtpurpose.Size = New System.Drawing.Size(196, 62)
        Me.txtpurpose.TabIndex = 228
        Me.txtpurpose.Text = "This certification is issued upon the request of NAME"
        Me.txtpurpose.Visible = False
        '
        'dtEndTimeMedicalRecords
        '
        Me.dtEndTimeMedicalRecords.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEndTimeMedicalRecords.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtEndTimeMedicalRecords.Enabled = False
        Me.dtEndTimeMedicalRecords.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtEndTimeMedicalRecords.Location = New System.Drawing.Point(108, 107)
        Me.dtEndTimeMedicalRecords.Name = "dtEndTimeMedicalRecords"
        Me.dtEndTimeMedicalRecords.ShowUpDown = True
        Me.dtEndTimeMedicalRecords.Size = New System.Drawing.Size(91, 21)
        Me.dtEndTimeMedicalRecords.TabIndex = 226
        '
        'dtStartTimeMedicalRecords
        '
        Me.dtStartTimeMedicalRecords.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStartTimeMedicalRecords.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtStartTimeMedicalRecords.Enabled = False
        Me.dtStartTimeMedicalRecords.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtStartTimeMedicalRecords.Location = New System.Drawing.Point(109, 69)
        Me.dtStartTimeMedicalRecords.Name = "dtStartTimeMedicalRecords"
        Me.dtStartTimeMedicalRecords.ShowUpDown = True
        Me.dtStartTimeMedicalRecords.Size = New System.Drawing.Size(90, 21)
        Me.dtStartTimeMedicalRecords.TabIndex = 225
        '
        'dtToMedicalRecords
        '
        Me.dtToMedicalRecords.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToMedicalRecords.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtToMedicalRecords.Enabled = False
        Me.dtToMedicalRecords.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToMedicalRecords.Location = New System.Drawing.Point(8, 107)
        Me.dtToMedicalRecords.Name = "dtToMedicalRecords"
        Me.dtToMedicalRecords.Size = New System.Drawing.Size(99, 21)
        Me.dtToMedicalRecords.TabIndex = 222
        '
        'dtFromMedicalRecords
        '
        Me.dtFromMedicalRecords.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromMedicalRecords.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtFromMedicalRecords.Enabled = False
        Me.dtFromMedicalRecords.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFromMedicalRecords.Location = New System.Drawing.Point(9, 69)
        Me.dtFromMedicalRecords.Name = "dtFromMedicalRecords"
        Me.dtFromMedicalRecords.Size = New System.Drawing.Size(99, 21)
        Me.dtFromMedicalRecords.TabIndex = 221
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Enabled = False
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(7, 95)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 224
        Me.Label10.Text = "End Date:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Enabled = False
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(3, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 223
        Me.Label12.Text = "Start Date:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSearch
        '
        Me.btnSearch.Enabled = False
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(176, 150)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(28, 24)
        Me.btnSearch.TabIndex = 220
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "Month:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgGenericList
        '
        Me.dgGenericList.AllowUserToAddRows = False
        Me.dgGenericList.AllowUserToDeleteRows = False
        Me.dgGenericList.AllowUserToResizeColumns = False
        Me.dgGenericList.AllowUserToResizeRows = False
        Me.dgGenericList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgGenericList.BackgroundColor = System.Drawing.Color.White
        Me.dgGenericList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgGenericList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgGenericList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgGenericList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgGenericList.Enabled = False
        Me.dgGenericList.EnableHeadersVisualStyles = False
        Me.dgGenericList.Location = New System.Drawing.Point(6, 176)
        Me.dgGenericList.MultiSelect = False
        Me.dgGenericList.Name = "dgGenericList"
        Me.dgGenericList.ReadOnly = True
        Me.dgGenericList.RowHeadersVisible = False
        Me.dgGenericList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgGenericList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgGenericList.Size = New System.Drawing.Size(198, 354)
        Me.dgGenericList.TabIndex = 219
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearch.ForeColor = System.Drawing.Color.Black
        Me.lblSearch.Location = New System.Drawing.Point(6, 135)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(46, 15)
        Me.lblSearch.TabIndex = 217
        Me.lblSearch.Text = "Search"
        Me.lblSearch.Visible = False
        '
        'dtpYearMedicalRecords
        '
        Me.dtpYearMedicalRecords.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpYearMedicalRecords.CustomFormat = "yyyy"
        Me.dtpYearMedicalRecords.Enabled = False
        Me.dtpYearMedicalRecords.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpYearMedicalRecords.Location = New System.Drawing.Point(131, 32)
        Me.dtpYearMedicalRecords.Name = "dtpYearMedicalRecords"
        Me.dtpYearMedicalRecords.ShowUpDown = True
        Me.dtpYearMedicalRecords.Size = New System.Drawing.Size(71, 21)
        Me.dtpYearMedicalRecords.TabIndex = 88
        Me.dtpYearMedicalRecords.Value = New Date(2012, 8, 14, 16, 12, 49, 0)
        '
        'txtSearch
        '
        Me.txtSearch.Enabled = False
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(5, 151)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(171, 22)
        Me.txtSearch.TabIndex = 218
        '
        'cmbMonthMedicalRecords
        '
        Me.cmbMonthMedicalRecords.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbMonthMedicalRecords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonthMedicalRecords.Enabled = False
        Me.cmbMonthMedicalRecords.FormattingEnabled = True
        Me.cmbMonthMedicalRecords.Location = New System.Drawing.Point(6, 31)
        Me.cmbMonthMedicalRecords.Name = "cmbMonthMedicalRecords"
        Me.cmbMonthMedicalRecords.Size = New System.Drawing.Size(119, 21)
        Me.cmbMonthMedicalRecords.TabIndex = 87
        '
        'cmbfilterby
        '
        Me.cmbfilterby.Enabled = False
        Me.cmbfilterby.FormattingEnabled = True
        Me.cmbfilterby.Location = New System.Drawing.Point(10, 69)
        Me.cmbfilterby.Name = "cmbfilterby"
        Me.cmbfilterby.Size = New System.Drawing.Size(190, 21)
        Me.cmbfilterby.TabIndex = 227
        Me.cmbfilterby.Visible = False
        '
        'grpRadiology
        '
        Me.grpRadiology.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpRadiology.BackColor = System.Drawing.Color.White
        Me.grpRadiology.Controls.Add(Me.Label9)
        Me.grpRadiology.Controls.Add(Me.Label7)
        Me.grpRadiology.Controls.Add(Me.cmfilm)
        Me.grpRadiology.Controls.Add(Me.cmbOffice)
        Me.grpRadiology.Controls.Add(Me.dtEndtimeRadiology)
        Me.grpRadiology.Controls.Add(Me.dtStarttimeradiology)
        Me.grpRadiology.Controls.Add(Me.dtToRadiology)
        Me.grpRadiology.Controls.Add(Me.dtfromradiology)
        Me.grpRadiology.Controls.Add(Me.Label3)
        Me.grpRadiology.Controls.Add(Me.Label6)
        Me.grpRadiology.Location = New System.Drawing.Point(5, 47)
        Me.grpRadiology.Name = "grpRadiology"
        Me.grpRadiology.Size = New System.Drawing.Size(210, 251)
        Me.grpRadiology.TabIndex = 99
        Me.grpRadiology.TabStop = False
        Me.grpRadiology.Text = "Radiology/Ultrasound"
        Me.grpRadiology.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 222
        Me.Label9.Text = "Film:"
        Me.Label9.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 221
        Me.Label7.Text = "Office:"
        Me.Label7.Visible = False
        '
        'cmfilm
        '
        Me.cmfilm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmfilm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmfilm.Enabled = False
        Me.cmfilm.FormattingEnabled = True
        Me.cmfilm.Location = New System.Drawing.Point(11, 151)
        Me.cmfilm.Name = "cmfilm"
        Me.cmfilm.Size = New System.Drawing.Size(193, 21)
        Me.cmfilm.TabIndex = 96
        '
        'cmbOffice
        '
        Me.cmbOffice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbOffice.Enabled = False
        Me.cmbOffice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOffice.FormattingEnabled = True
        Me.cmbOffice.Location = New System.Drawing.Point(11, 110)
        Me.cmbOffice.Name = "cmbOffice"
        Me.cmbOffice.Size = New System.Drawing.Size(193, 23)
        Me.cmbOffice.TabIndex = 95
        '
        'dtEndtimeRadiology
        '
        Me.dtEndtimeRadiology.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEndtimeRadiology.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtEndtimeRadiology.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtEndtimeRadiology.Location = New System.Drawing.Point(109, 65)
        Me.dtEndtimeRadiology.Name = "dtEndtimeRadiology"
        Me.dtEndtimeRadiology.ShowUpDown = True
        Me.dtEndtimeRadiology.Size = New System.Drawing.Size(91, 21)
        Me.dtEndtimeRadiology.TabIndex = 94
        '
        'dtStarttimeradiology
        '
        Me.dtStarttimeradiology.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStarttimeradiology.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtStarttimeradiology.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtStarttimeradiology.Location = New System.Drawing.Point(110, 27)
        Me.dtStarttimeradiology.Name = "dtStarttimeradiology"
        Me.dtStarttimeradiology.ShowUpDown = True
        Me.dtStarttimeradiology.Size = New System.Drawing.Size(90, 21)
        Me.dtStarttimeradiology.TabIndex = 93
        '
        'dtToRadiology
        '
        Me.dtToRadiology.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToRadiology.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtToRadiology.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToRadiology.Location = New System.Drawing.Point(9, 65)
        Me.dtToRadiology.Name = "dtToRadiology"
        Me.dtToRadiology.Size = New System.Drawing.Size(99, 21)
        Me.dtToRadiology.TabIndex = 90
        '
        'dtfromradiology
        '
        Me.dtfromradiology.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfromradiology.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtfromradiology.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfromradiology.Location = New System.Drawing.Point(10, 27)
        Me.dtfromradiology.Name = "dtfromradiology"
        Me.dtfromradiology.Size = New System.Drawing.Size(99, 21)
        Me.dtfromradiology.TabIndex = 89
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "End Date:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Start Date:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpForms
        '
        Me.grpForms.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpForms.BackColor = System.Drawing.Color.White
        Me.grpForms.Controls.Add(Me.btnSearchForms)
        Me.grpForms.Controls.Add(Me.dgGenericList2)
        Me.grpForms.Controls.Add(Me.Label11)
        Me.grpForms.Controls.Add(Me.txtSearchForms)
        Me.grpForms.Location = New System.Drawing.Point(7, 47)
        Me.grpForms.Name = "grpForms"
        Me.grpForms.Size = New System.Drawing.Size(210, 547)
        Me.grpForms.TabIndex = 100
        Me.grpForms.TabStop = False
        Me.grpForms.Text = "Forms"
        Me.grpForms.Visible = False
        '
        'btnSearchForms
        '
        Me.btnSearchForms.Image = CType(resources.GetObject("btnSearchForms.Image"), System.Drawing.Image)
        Me.btnSearchForms.Location = New System.Drawing.Point(176, 31)
        Me.btnSearchForms.Name = "btnSearchForms"
        Me.btnSearchForms.Size = New System.Drawing.Size(28, 24)
        Me.btnSearchForms.TabIndex = 220
        Me.btnSearchForms.UseVisualStyleBackColor = True
        '
        'dgGenericList2
        '
        Me.dgGenericList2.AllowUserToAddRows = False
        Me.dgGenericList2.AllowUserToDeleteRows = False
        Me.dgGenericList2.AllowUserToResizeColumns = False
        Me.dgGenericList2.AllowUserToResizeRows = False
        Me.dgGenericList2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgGenericList2.BackgroundColor = System.Drawing.Color.White
        Me.dgGenericList2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgGenericList2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgGenericList2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgGenericList2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgGenericList2.EnableHeadersVisualStyles = False
        Me.dgGenericList2.Location = New System.Drawing.Point(6, 57)
        Me.dgGenericList2.MultiSelect = False
        Me.dgGenericList2.Name = "dgGenericList2"
        Me.dgGenericList2.ReadOnly = True
        Me.dgGenericList2.RowHeadersVisible = False
        Me.dgGenericList2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgGenericList2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgGenericList2.Size = New System.Drawing.Size(198, 467)
        Me.dgGenericList2.TabIndex = 219
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(6, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 15)
        Me.Label11.TabIndex = 217
        Me.Label11.Text = "Search"
        Me.Label11.Visible = False
        '
        'txtSearchForms
        '
        Me.txtSearchForms.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchForms.Location = New System.Drawing.Point(5, 32)
        Me.txtSearchForms.Name = "txtSearchForms"
        Me.txtSearchForms.Size = New System.Drawing.Size(171, 22)
        Me.txtSearchForms.TabIndex = 218
        '
        'lblCompanyname
        '
        Me.lblCompanyname.AutoSize = True
        Me.lblCompanyname.DisabledLinkColor = System.Drawing.Color.Transparent
        Me.lblCompanyname.Enabled = False
        Me.lblCompanyname.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyname.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblCompanyname.LinkColor = System.Drawing.Color.Transparent
        Me.lblCompanyname.Location = New System.Drawing.Point(76, 2)
        Me.lblCompanyname.Name = "lblCompanyname"
        Me.lblCompanyname.Size = New System.Drawing.Size(108, 25)
        Me.lblCompanyname.TabIndex = 101
        Me.lblCompanyname.TabStop = True
        Me.lblCompanyname.Text = "LinkLabel1"
        '
        'pctrLogo
        '
        Me.pctrLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pctrLogo.Location = New System.Drawing.Point(6, 4)
        Me.pctrLogo.Name = "pctrLogo"
        Me.pctrLogo.Size = New System.Drawing.Size(67, 67)
        Me.pctrLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctrLogo.TabIndex = 4
        Me.pctrLogo.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsExportToPDF, Me.ToolStripSeparator3, Me.tsEmail, Me.ToolStripSeparator6, Me.tsExportToExcel, Me.ToolStripSeparator2, Me.tsPrint, Me.ToolStripSeparator1, Me.tsRefresh, Me.ToolStripSeparator4, Me.tsSearchtext, Me.tsSearch, Me.ToolStripSeparator9, Me.tsFirstPage, Me.tsPrev, Me.ToolStripSeparator5, Me.tsNext, Me.tsLastPage, Me.ToolStripSeparator7, Me.tsZoom, Me.ToolStripLabel1, Me.ToolStripSeparator8, Me.tsClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(1, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1068, 44)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsExportToPDF
        '
        Me.tsExportToPDF.ForeColor = System.Drawing.Color.Red
        Me.tsExportToPDF.Image = CType(resources.GetObject("tsExportToPDF.Image"), System.Drawing.Image)
        Me.tsExportToPDF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsExportToPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsExportToPDF.Name = "tsExportToPDF"
        Me.tsExportToPDF.Size = New System.Drawing.Size(77, 41)
        Me.tsExportToPDF.Text = "> PDF"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 44)
        '
        'tsEmail
        '
        Me.tsEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tsEmail.Image = CType(resources.GetObject("tsEmail.Image"), System.Drawing.Image)
        Me.tsEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEmail.Name = "tsEmail"
        Me.tsEmail.Size = New System.Drawing.Size(62, 41)
        Me.tsEmail.Text = "Email"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 44)
        '
        'tsExportToExcel
        '
        Me.tsExportToExcel.ForeColor = System.Drawing.Color.DarkGreen
        Me.tsExportToExcel.Image = CType(resources.GetObject("tsExportToExcel.Image"), System.Drawing.Image)
        Me.tsExportToExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsExportToExcel.Name = "tsExportToExcel"
        Me.tsExportToExcel.Size = New System.Drawing.Size(84, 41)
        Me.tsExportToExcel.Text = "> Excel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 44)
        '
        'tsPrint
        '
        Me.tsPrint.Image = CType(resources.GetObject("tsPrint.Image"), System.Drawing.Image)
        Me.tsPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPrint.Name = "tsPrint"
        Me.tsPrint.Size = New System.Drawing.Size(68, 41)
        Me.tsPrint.Text = "Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 44)
        '
        'tsRefresh
        '
        Me.tsRefresh.ForeColor = System.Drawing.Color.Blue
        Me.tsRefresh.Image = CType(resources.GetObject("tsRefresh.Image"), System.Drawing.Image)
        Me.tsRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRefresh.Name = "tsRefresh"
        Me.tsRefresh.Size = New System.Drawing.Size(76, 41)
        Me.tsRefresh.Text = "Refresh"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 44)
        '
        'tsSearchtext
        '
        Me.tsSearchtext.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsSearchtext.Name = "tsSearchtext"
        Me.tsSearchtext.Size = New System.Drawing.Size(100, 44)
        '
        'tsSearch
        '
        Me.tsSearch.Image = CType(resources.GetObject("tsSearch.Image"), System.Drawing.Image)
        Me.tsSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(65, 41)
        Me.tsSearch.Text = "Find"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 44)
        '
        'tsFirstPage
        '
        Me.tsFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsFirstPage.Enabled = False
        Me.tsFirstPage.Image = CType(resources.GetObject("tsFirstPage.Image"), System.Drawing.Image)
        Me.tsFirstPage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFirstPage.Name = "tsFirstPage"
        Me.tsFirstPage.Size = New System.Drawing.Size(43, 41)
        Me.tsFirstPage.Text = "|<<<"
        '
        'tsPrev
        '
        Me.tsPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsPrev.Enabled = False
        Me.tsPrev.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsPrev.Image = CType(resources.GetObject("tsPrev.Image"), System.Drawing.Image)
        Me.tsPrev.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPrev.Name = "tsPrev"
        Me.tsPrev.Size = New System.Drawing.Size(35, 41)
        Me.tsPrev.Text = "<<<"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 44)
        '
        'tsNext
        '
        Me.tsNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsNext.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsNext.Image = CType(resources.GetObject("tsNext.Image"), System.Drawing.Image)
        Me.tsNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNext.Name = "tsNext"
        Me.tsNext.Size = New System.Drawing.Size(35, 41)
        Me.tsNext.Text = ">>>"
        '
        'tsLastPage
        '
        Me.tsLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsLastPage.Image = CType(resources.GetObject("tsLastPage.Image"), System.Drawing.Image)
        Me.tsLastPage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLastPage.Name = "tsLastPage"
        Me.tsLastPage.Size = New System.Drawing.Size(43, 41)
        Me.tsLastPage.Text = ">>>|"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 44)
        '
        'tsZoom
        '
        Me.tsZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tsZoom.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tsZoom.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsZoom.Name = "tsZoom"
        Me.tsZoom.Size = New System.Drawing.Size(80, 44)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(38, 41)
        Me.ToolStripLabel1.Text = "Zoom"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 44)
        '
        'tsClose
        '
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(63, 41)
        Me.tsClose.Text = "Close"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'grpFinancialReport
        '
        Me.grpFinancialReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpFinancialReport.BackColor = System.Drawing.Color.White
        Me.grpFinancialReport.Controls.Add(Me.grpAccountPayableTrade)
        Me.grpFinancialReport.Controls.Add(Me.PictureBox2)
        Me.grpFinancialReport.Controls.Add(Me.GroupBox3)
        Me.grpFinancialReport.Controls.Add(Me.PictureBox3)
        Me.grpFinancialReport.Controls.Add(Me.GroupBox5)
        Me.grpFinancialReport.Controls.Add(Me.PictureBox1)
        Me.grpFinancialReport.Controls.Add(Me.GroupBox2)
        Me.grpFinancialReport.Controls.Add(Me.cmbDateType)
        Me.grpFinancialReport.Controls.Add(Me.dtEndTimeFinancial)
        Me.grpFinancialReport.Controls.Add(Me.dtStartTimeFinancial)
        Me.grpFinancialReport.Controls.Add(Me.dtToFinancial)
        Me.grpFinancialReport.Controls.Add(Me.dtFromFinancial)
        Me.grpFinancialReport.Controls.Add(Me.Label13)
        Me.grpFinancialReport.Controls.Add(Me.Label14)
        Me.grpFinancialReport.Controls.Add(Me.cmbMonth)
        Me.grpFinancialReport.Controls.Add(Me.cmbYear)
        Me.grpFinancialReport.Location = New System.Drawing.Point(6, 49)
        Me.grpFinancialReport.Name = "grpFinancialReport"
        Me.grpFinancialReport.Size = New System.Drawing.Size(210, 536)
        Me.grpFinancialReport.TabIndex = 102
        Me.grpFinancialReport.TabStop = False
        Me.grpFinancialReport.Text = "Financial Status"
        Me.grpFinancialReport.Visible = False
        '
        'grpAccountPayableTrade
        '
        Me.grpAccountPayableTrade.Controls.Add(Me.Label35)
        Me.grpAccountPayableTrade.Controls.Add(Me.dtAccountPayabaleTradeDate)
        Me.grpAccountPayableTrade.Location = New System.Drawing.Point(1, 12)
        Me.grpAccountPayableTrade.Name = "grpAccountPayableTrade"
        Me.grpAccountPayableTrade.Size = New System.Drawing.Size(208, 446)
        Me.grpAccountPayableTrade.TabIndex = 359
        Me.grpAccountPayableTrade.TabStop = False
        Me.grpAccountPayableTrade.Visible = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(11, 58)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(38, 13)
        Me.Label35.TabIndex = 1
        Me.Label35.Text = "As Of:"
        '
        'dtAccountPayabaleTradeDate
        '
        Me.dtAccountPayabaleTradeDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtAccountPayabaleTradeDate.Location = New System.Drawing.Point(54, 55)
        Me.dtAccountPayabaleTradeDate.Name = "dtAccountPayabaleTradeDate"
        Me.dtAccountPayabaleTradeDate.Size = New System.Drawing.Size(142, 21)
        Me.dtAccountPayabaleTradeDate.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Khaki
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(4, 407)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(204, 39)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 358
        Me.PictureBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Khaki
        Me.GroupBox3.Controls.Add(Me.lblieforAgedPayable)
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 349)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(204, 58)
        Me.GroupBox3.TabIndex = 357
        Me.GroupBox3.TabStop = False
        '
        'lblieforAgedPayable
        '
        Me.lblieforAgedPayable.AutoSize = True
        Me.lblieforAgedPayable.BackColor = System.Drawing.Color.Khaki
        Me.lblieforAgedPayable.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblieforAgedPayable.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lblieforAgedPayable.Location = New System.Drawing.Point(59, 43)
        Me.lblieforAgedPayable.Name = "lblieforAgedPayable"
        Me.lblieforAgedPayable.Size = New System.Drawing.Size(122, 12)
        Me.lblieforAgedPayable.TabIndex = 13
        Me.lblieforAgedPayable.Text = "i.e.,,Invoice No.,Branch,Supplier"
        Me.lblieforAgedPayable.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Gray
        Me.TextBox1.Location = New System.Drawing.Point(59, 21)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(141, 22)
        Me.TextBox1.TabIndex = 11
        Me.TextBox1.Text = "Type here and Press Enter key"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Khaki
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(3, 24)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(41, 13)
        Me.Label34.TabIndex = 12
        Me.Label34.Text = "Search"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Khaki
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(4, 300)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(204, 39)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 136
        Me.PictureBox3.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Khaki
        Me.GroupBox5.Controls.Add(Me.chkincludeoverdueinvoiceonly)
        Me.GroupBox5.Controls.Add(Me.chkshowDetails)
        Me.GroupBox5.Controls.Add(Me.tscombobranch)
        Me.GroupBox5.Controls.Add(Me.tsSupplier)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Controls.Add(Me.Label33)
        Me.GroupBox5.Location = New System.Drawing.Point(4, 219)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(204, 83)
        Me.GroupBox5.TabIndex = 135
        Me.GroupBox5.TabStop = False
        '
        'chkincludeoverdueinvoiceonly
        '
        Me.chkincludeoverdueinvoiceonly.AutoSize = True
        Me.chkincludeoverdueinvoiceonly.Checked = True
        Me.chkincludeoverdueinvoiceonly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkincludeoverdueinvoiceonly.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkincludeoverdueinvoiceonly.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkincludeoverdueinvoiceonly.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkincludeoverdueinvoiceonly.ForeColor = System.Drawing.Color.MediumBlue
        Me.chkincludeoverdueinvoiceonly.Location = New System.Drawing.Point(59, 61)
        Me.chkincludeoverdueinvoiceonly.Name = "chkincludeoverdueinvoiceonly"
        Me.chkincludeoverdueinvoiceonly.Size = New System.Drawing.Size(135, 17)
        Me.chkincludeoverdueinvoiceonly.TabIndex = 16
        Me.chkincludeoverdueinvoiceonly.Text = "Include overdue invoice only"
        Me.chkincludeoverdueinvoiceonly.UseVisualStyleBackColor = True
        Me.chkincludeoverdueinvoiceonly.Visible = False
        '
        'chkshowDetails
        '
        Me.chkshowDetails.AutoSize = True
        Me.chkshowDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkshowDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkshowDetails.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkshowDetails.ForeColor = System.Drawing.Color.RoyalBlue
        Me.chkshowDetails.Location = New System.Drawing.Point(60, 60)
        Me.chkshowDetails.Name = "chkshowDetails"
        Me.chkshowDetails.Size = New System.Drawing.Size(70, 16)
        Me.chkshowDetails.TabIndex = 15
        Me.chkshowDetails.Text = "Show Details"
        Me.chkshowDetails.UseVisualStyleBackColor = True
        Me.chkshowDetails.Visible = False
        '
        'tscombobranch
        '
        Me.tscombobranch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tscombobranch.DropDownWidth = 230
        Me.tscombobranch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.tscombobranch.FormattingEnabled = True
        Me.tscombobranch.Location = New System.Drawing.Point(59, 14)
        Me.tscombobranch.Name = "tscombobranch"
        Me.tscombobranch.Size = New System.Drawing.Size(141, 21)
        Me.tscombobranch.TabIndex = 10
        '
        'tsSupplier
        '
        Me.tsSupplier.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tsSupplier.DropDownWidth = 230
        Me.tsSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.tsSupplier.FormattingEnabled = True
        Me.tsSupplier.Location = New System.Drawing.Point(59, 37)
        Me.tsSupplier.Name = "tsSupplier"
        Me.tsSupplier.Size = New System.Drawing.Size(141, 21)
        Me.tsSupplier.TabIndex = 9
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Khaki
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(2, 40)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(50, 13)
        Me.Label32.TabIndex = 13
        Me.Label32.Text = "Supplier"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Khaki
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(4, 17)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(38, 13)
        Me.Label33.TabIndex = 14
        Me.Label33.Text = "Office"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Khaki
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 183)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(204, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 134
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Khaki
        Me.GroupBox2.Controls.Add(Me.cmbinvoicesummaryyear)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.lblInvoicesummarymonth)
        Me.GroupBox2.Controls.Add(Me.Dateto)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.cmbPeriod)
        Me.GroupBox2.Controls.Add(Me.cmbInvoiceSummary)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.lblinvociesummaryyear)
        Me.GroupBox2.Controls.Add(Me.Datefrom)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 105)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(204, 81)
        Me.GroupBox2.TabIndex = 133
        Me.GroupBox2.TabStop = False
        '
        'cmbinvoicesummaryyear
        '
        Me.cmbinvoicesummaryyear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbinvoicesummaryyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbinvoicesummaryyear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbinvoicesummaryyear.FormattingEnabled = True
        Me.cmbinvoicesummaryyear.Location = New System.Drawing.Point(60, 55)
        Me.cmbinvoicesummaryyear.Name = "cmbinvoicesummaryyear"
        Me.cmbinvoicesummaryyear.Size = New System.Drawing.Size(140, 21)
        Me.cmbinvoicesummaryyear.TabIndex = 311
        Me.cmbinvoicesummaryyear.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Khaki
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(0, 35)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 13)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "Date From"
        '
        'lblInvoicesummarymonth
        '
        Me.lblInvoicesummarymonth.AutoSize = True
        Me.lblInvoicesummarymonth.BackColor = System.Drawing.Color.Khaki
        Me.lblInvoicesummarymonth.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoicesummarymonth.Location = New System.Drawing.Point(3, 41)
        Me.lblInvoicesummarymonth.Name = "lblInvoicesummarymonth"
        Me.lblInvoicesummarymonth.Size = New System.Drawing.Size(42, 13)
        Me.lblInvoicesummarymonth.TabIndex = 309
        Me.lblInvoicesummarymonth.Text = "Month"
        Me.lblInvoicesummarymonth.Visible = False
        '
        'Dateto
        '
        Me.Dateto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Dateto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dateto.Location = New System.Drawing.Point(59, 59)
        Me.Dateto.Name = "Dateto"
        Me.Dateto.Size = New System.Drawing.Size(140, 21)
        Me.Dateto.TabIndex = 306
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(4, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 307
        Me.Label17.Text = "Date To"
        '
        'cmbPeriod
        '
        Me.cmbPeriod.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbPeriod.FormattingEnabled = True
        Me.cmbPeriod.Location = New System.Drawing.Point(59, 9)
        Me.cmbPeriod.Name = "cmbPeriod"
        Me.cmbPeriod.Size = New System.Drawing.Size(140, 21)
        Me.cmbPeriod.TabIndex = 20
        '
        'cmbInvoiceSummary
        '
        Me.cmbInvoiceSummary.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbInvoiceSummary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInvoiceSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbInvoiceSummary.FormattingEnabled = True
        Me.cmbInvoiceSummary.Location = New System.Drawing.Point(60, 32)
        Me.cmbInvoiceSummary.Name = "cmbInvoiceSummary"
        Me.cmbInvoiceSummary.Size = New System.Drawing.Size(140, 21)
        Me.cmbInvoiceSummary.TabIndex = 308
        Me.cmbInvoiceSummary.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Khaki
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(4, 12)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(40, 13)
        Me.Label30.TabIndex = 21
        Me.Label30.Text = "Period"
        '
        'lblinvociesummaryyear
        '
        Me.lblinvociesummaryyear.AutoSize = True
        Me.lblinvociesummaryyear.BackColor = System.Drawing.Color.Khaki
        Me.lblinvociesummaryyear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinvociesummaryyear.Location = New System.Drawing.Point(6, 60)
        Me.lblinvociesummaryyear.Name = "lblinvociesummaryyear"
        Me.lblinvociesummaryyear.Size = New System.Drawing.Size(28, 13)
        Me.lblinvociesummaryyear.TabIndex = 310
        Me.lblinvociesummaryyear.Text = "Year"
        Me.lblinvociesummaryyear.Visible = False
        '
        'Datefrom
        '
        Me.Datefrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Datefrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Datefrom.Location = New System.Drawing.Point(59, 32)
        Me.Datefrom.Name = "Datefrom"
        Me.Datefrom.Size = New System.Drawing.Size(140, 21)
        Me.Datefrom.TabIndex = 16
        '
        'cmbDateType
        '
        Me.cmbDateType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDateType.FormattingEnabled = True
        Me.cmbDateType.Location = New System.Drawing.Point(8, 14)
        Me.cmbDateType.Name = "cmbDateType"
        Me.cmbDateType.Size = New System.Drawing.Size(196, 21)
        Me.cmbDateType.TabIndex = 108
        Me.cmbDateType.Visible = False
        '
        'dtEndTimeFinancial
        '
        Me.dtEndTimeFinancial.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEndTimeFinancial.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtEndTimeFinancial.Enabled = False
        Me.dtEndTimeFinancial.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtEndTimeFinancial.Location = New System.Drawing.Point(109, 84)
        Me.dtEndTimeFinancial.Name = "dtEndTimeFinancial"
        Me.dtEndTimeFinancial.ShowUpDown = True
        Me.dtEndTimeFinancial.Size = New System.Drawing.Size(91, 21)
        Me.dtEndTimeFinancial.TabIndex = 94
        '
        'dtStartTimeFinancial
        '
        Me.dtStartTimeFinancial.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStartTimeFinancial.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtStartTimeFinancial.Enabled = False
        Me.dtStartTimeFinancial.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtStartTimeFinancial.Location = New System.Drawing.Point(110, 46)
        Me.dtStartTimeFinancial.Name = "dtStartTimeFinancial"
        Me.dtStartTimeFinancial.ShowUpDown = True
        Me.dtStartTimeFinancial.Size = New System.Drawing.Size(90, 21)
        Me.dtStartTimeFinancial.TabIndex = 93
        '
        'dtToFinancial
        '
        Me.dtToFinancial.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToFinancial.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtToFinancial.Enabled = False
        Me.dtToFinancial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToFinancial.Location = New System.Drawing.Point(9, 84)
        Me.dtToFinancial.Name = "dtToFinancial"
        Me.dtToFinancial.Size = New System.Drawing.Size(99, 21)
        Me.dtToFinancial.TabIndex = 90
        '
        'dtFromFinancial
        '
        Me.dtFromFinancial.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromFinancial.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtFromFinancial.Enabled = False
        Me.dtFromFinancial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFromFinancial.Location = New System.Drawing.Point(10, 46)
        Me.dtFromFinancial.Name = "dtFromFinancial"
        Me.dtFromFinancial.Size = New System.Drawing.Size(99, 21)
        Me.dtFromFinancial.TabIndex = 89
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(8, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 92
        Me.Label13.Text = "End Date:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(8, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 91
        Me.Label14.Text = "Start Date:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbMonth
        '
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(7, 47)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(194, 21)
        Me.cmbMonth.TabIndex = 316
        Me.cmbMonth.Visible = False
        '
        'cmbYear
        '
        Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(7, 82)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(194, 21)
        Me.cmbYear.TabIndex = 317
        Me.cmbYear.Visible = False
        '
        'grpPharmacy
        '
        Me.grpPharmacy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpPharmacy.BackColor = System.Drawing.Color.White
        Me.grpPharmacy.Controls.Add(Me.lblEmployeePharma)
        Me.grpPharmacy.Controls.Add(Me.cmbPharmaEmployee)
        Me.grpPharmacy.Controls.Add(Me.cmbPharmaOffice)
        Me.grpPharmacy.Controls.Add(Me.lblOfficePharma)
        Me.grpPharmacy.Controls.Add(Me.dtEndTimePharmacy)
        Me.grpPharmacy.Controls.Add(Me.dtStartTimePharmacy)
        Me.grpPharmacy.Controls.Add(Me.dtToPharmacy)
        Me.grpPharmacy.Controls.Add(Me.dtFromPharmacy)
        Me.grpPharmacy.Controls.Add(Me.Label15)
        Me.grpPharmacy.Controls.Add(Me.Label16)
        Me.grpPharmacy.Location = New System.Drawing.Point(4, 51)
        Me.grpPharmacy.Name = "grpPharmacy"
        Me.grpPharmacy.Size = New System.Drawing.Size(210, 156)
        Me.grpPharmacy.TabIndex = 103
        Me.grpPharmacy.TabStop = False
        Me.grpPharmacy.Text = "Pharmacy"
        Me.grpPharmacy.Visible = False
        '
        'lblEmployeePharma
        '
        Me.lblEmployeePharma.AutoSize = True
        Me.lblEmployeePharma.BackColor = System.Drawing.Color.White
        Me.lblEmployeePharma.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeePharma.Location = New System.Drawing.Point(12, 125)
        Me.lblEmployeePharma.Name = "lblEmployeePharma"
        Me.lblEmployeePharma.Size = New System.Drawing.Size(32, 13)
        Me.lblEmployeePharma.TabIndex = 109
        Me.lblEmployeePharma.Text = "Emp:"
        '
        'cmbPharmaEmployee
        '
        Me.cmbPharmaEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbPharmaEmployee.FormattingEnabled = True
        Me.cmbPharmaEmployee.Location = New System.Drawing.Point(46, 121)
        Me.cmbPharmaEmployee.Name = "cmbPharmaEmployee"
        Me.cmbPharmaEmployee.Size = New System.Drawing.Size(155, 21)
        Me.cmbPharmaEmployee.TabIndex = 108
        '
        'cmbPharmaOffice
        '
        Me.cmbPharmaOffice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbPharmaOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPharmaOffice.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbPharmaOffice.FormattingEnabled = True
        Me.cmbPharmaOffice.Location = New System.Drawing.Point(46, 92)
        Me.cmbPharmaOffice.Name = "cmbPharmaOffice"
        Me.cmbPharmaOffice.Size = New System.Drawing.Size(156, 21)
        Me.cmbPharmaOffice.TabIndex = 95
        '
        'lblOfficePharma
        '
        Me.lblOfficePharma.AutoSize = True
        Me.lblOfficePharma.BackColor = System.Drawing.Color.White
        Me.lblOfficePharma.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOfficePharma.Location = New System.Drawing.Point(4, 95)
        Me.lblOfficePharma.Name = "lblOfficePharma"
        Me.lblOfficePharma.Size = New System.Drawing.Size(41, 13)
        Me.lblOfficePharma.TabIndex = 96
        Me.lblOfficePharma.Text = "Office:"
        '
        'dtEndTimePharmacy
        '
        Me.dtEndTimePharmacy.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEndTimePharmacy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtEndTimePharmacy.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtEndTimePharmacy.Location = New System.Drawing.Point(109, 65)
        Me.dtEndTimePharmacy.Name = "dtEndTimePharmacy"
        Me.dtEndTimePharmacy.ShowUpDown = True
        Me.dtEndTimePharmacy.Size = New System.Drawing.Size(91, 21)
        Me.dtEndTimePharmacy.TabIndex = 94
        '
        'dtStartTimePharmacy
        '
        Me.dtStartTimePharmacy.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStartTimePharmacy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtStartTimePharmacy.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtStartTimePharmacy.Location = New System.Drawing.Point(110, 27)
        Me.dtStartTimePharmacy.Name = "dtStartTimePharmacy"
        Me.dtStartTimePharmacy.ShowUpDown = True
        Me.dtStartTimePharmacy.Size = New System.Drawing.Size(90, 21)
        Me.dtStartTimePharmacy.TabIndex = 93
        '
        'dtToPharmacy
        '
        Me.dtToPharmacy.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtToPharmacy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtToPharmacy.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtToPharmacy.Location = New System.Drawing.Point(9, 65)
        Me.dtToPharmacy.Name = "dtToPharmacy"
        Me.dtToPharmacy.Size = New System.Drawing.Size(99, 21)
        Me.dtToPharmacy.TabIndex = 90
        '
        'dtFromPharmacy
        '
        Me.dtFromPharmacy.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFromPharmacy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtFromPharmacy.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFromPharmacy.Location = New System.Drawing.Point(10, 27)
        Me.dtFromPharmacy.Name = "dtFromPharmacy"
        Me.dtFromPharmacy.Size = New System.Drawing.Size(99, 21)
        Me.dtFromPharmacy.TabIndex = 89
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(8, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 13)
        Me.Label15.TabIndex = 92
        Me.Label15.Text = "End Date:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(8, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 13)
        Me.Label16.TabIndex = 91
        Me.Label16.Text = "Start Date:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox8
        '
        Me.PictureBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox8.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(6, 44)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(1227, 25)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 303
        Me.PictureBox8.TabStop = False
        '
        'grpInventoryHistory
        '
        Me.grpInventoryHistory.BackColor = System.Drawing.Color.White
        Me.grpInventoryHistory.Controls.Add(Me.grpInventorySearch)
        Me.grpInventoryHistory.Controls.Add(Me.pnlInventoryBatch1)
        Me.grpInventoryHistory.Controls.Add(Me.pnlInventoryHistory)
        Me.grpInventoryHistory.Controls.Add(Me.pnlInventory)
        Me.grpInventoryHistory.Location = New System.Drawing.Point(6, 65)
        Me.grpInventoryHistory.Name = "grpInventoryHistory"
        Me.grpInventoryHistory.Size = New System.Drawing.Size(209, 431)
        Me.grpInventoryHistory.TabIndex = 304
        Me.grpInventoryHistory.TabStop = False
        Me.grpInventoryHistory.Text = "Inventory"
        '
        'grpInventorySearch
        '
        Me.grpInventorySearch.Controls.Add(Me.Label24)
        Me.grpInventorySearch.Controls.Add(Me.Label25)
        Me.grpInventorySearch.Controls.Add(Me.pcSearch)
        Me.grpInventorySearch.Controls.Add(Me.txtInventorySearch)
        Me.grpInventorySearch.Location = New System.Drawing.Point(5, 16)
        Me.grpInventorySearch.Name = "grpInventorySearch"
        Me.grpInventorySearch.Size = New System.Drawing.Size(200, 70)
        Me.grpInventorySearch.TabIndex = 307
        Me.grpInventorySearch.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(2, 11)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(63, 13)
        Me.Label24.TabIndex = 214
        Me.Label24.Text = "Search [F3]"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 49)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(195, 12)
        Me.Label25.TabIndex = 213
        Me.Label25.Text = "i.e. Item Code, Description, Generic, Category"
        '
        'pcSearch
        '
        Me.pcSearch.BackColor = System.Drawing.SystemColors.Control
        Me.pcSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pcSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pcSearch.Image = CType(resources.GetObject("pcSearch.Image"), System.Drawing.Image)
        Me.pcSearch.Location = New System.Drawing.Point(172, 8)
        Me.pcSearch.Name = "pcSearch"
        Me.pcSearch.Size = New System.Drawing.Size(23, 19)
        Me.pcSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pcSearch.TabIndex = 215
        Me.pcSearch.TabStop = False
        Me.pcSearch.Visible = False
        '
        'txtInventorySearch
        '
        Me.txtInventorySearch.Location = New System.Drawing.Point(3, 28)
        Me.txtInventorySearch.Name = "txtInventorySearch"
        Me.txtInventorySearch.Size = New System.Drawing.Size(193, 21)
        Me.txtInventorySearch.TabIndex = 212
        '
        'pnlInventoryBatch1
        '
        Me.pnlInventoryBatch1.Controls.Add(Me.Label26)
        Me.pnlInventoryBatch1.Controls.Add(Me.pnlInventoryBatch1Sub)
        Me.pnlInventoryBatch1.Controls.Add(Me.cbIncludeStockTransOut)
        Me.pnlInventoryBatch1.Location = New System.Drawing.Point(3, 182)
        Me.pnlInventoryBatch1.Name = "pnlInventoryBatch1"
        Me.pnlInventoryBatch1.Size = New System.Drawing.Size(206, 219)
        Me.pnlInventoryBatch1.TabIndex = 305
        Me.pnlInventoryBatch1.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(21, 19)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(60, 13)
        Me.Label26.TabIndex = 216
        Me.Label26.Text = "Units Sold"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlInventoryBatch1Sub
        '
        Me.pnlInventoryBatch1Sub.Controls.Add(Me.Label28)
        Me.pnlInventoryBatch1Sub.Controls.Add(Me.Label27)
        Me.pnlInventoryBatch1Sub.Controls.Add(Me.cbExcludeReceivedStocks)
        Me.pnlInventoryBatch1Sub.Controls.Add(Me.numDays)
        Me.pnlInventoryBatch1Sub.Controls.Add(Me.cbExcludeItemswithZeroQty)
        Me.pnlInventoryBatch1Sub.Location = New System.Drawing.Point(0, 36)
        Me.pnlInventoryBatch1Sub.Name = "pnlInventoryBatch1Sub"
        Me.pnlInventoryBatch1Sub.Size = New System.Drawing.Size(206, 75)
        Me.pnlInventoryBatch1Sub.TabIndex = 213
        Me.pnlInventoryBatch1Sub.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(23, 20)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(54, 13)
        Me.Label28.TabIndex = 217
        Me.Label28.Text = "Quantity."
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(64, 56)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(143, 13)
        Me.Label27.TabIndex = 110
        Me.Label27.Text = "days ago from current date."
        '
        'cbExcludeReceivedStocks
        '
        Me.cbExcludeReceivedStocks.AutoSize = True
        Me.cbExcludeReceivedStocks.Location = New System.Drawing.Point(5, 36)
        Me.cbExcludeReceivedStocks.Name = "cbExcludeReceivedStocks"
        Me.cbExcludeReceivedStocks.Size = New System.Drawing.Size(175, 17)
        Me.cbExcludeReceivedStocks.TabIndex = 107
        Me.cbExcludeReceivedStocks.Text = "Exclude Received Stocks within"
        Me.cbExcludeReceivedStocks.UseVisualStyleBackColor = True
        '
        'numDays
        '
        Me.numDays.Enabled = False
        Me.numDays.Location = New System.Drawing.Point(26, 53)
        Me.numDays.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numDays.Name = "numDays"
        Me.numDays.Size = New System.Drawing.Size(38, 21)
        Me.numDays.TabIndex = 109
        '
        'cbExcludeItemswithZeroQty
        '
        Me.cbExcludeItemswithZeroQty.AutoSize = True
        Me.cbExcludeItemswithZeroQty.Location = New System.Drawing.Point(5, 4)
        Me.cbExcludeItemswithZeroQty.Name = "cbExcludeItemswithZeroQty"
        Me.cbExcludeItemswithZeroQty.Size = New System.Drawing.Size(183, 17)
        Me.cbExcludeItemswithZeroQty.TabIndex = 106
        Me.cbExcludeItemswithZeroQty.Text = "Exclude Items with Zero Reorder"
        Me.cbExcludeItemswithZeroQty.UseVisualStyleBackColor = True
        '
        'cbIncludeStockTransOut
        '
        Me.cbIncludeStockTransOut.AutoSize = True
        Me.cbIncludeStockTransOut.Location = New System.Drawing.Point(5, 4)
        Me.cbIncludeStockTransOut.Name = "cbIncludeStockTransOut"
        Me.cbIncludeStockTransOut.Size = New System.Drawing.Size(177, 17)
        Me.cbIncludeStockTransOut.TabIndex = 215
        Me.cbIncludeStockTransOut.Text = "Include Stock Transfer (Out) as"
        Me.cbIncludeStockTransOut.UseVisualStyleBackColor = True
        '
        'pnlInventoryHistory
        '
        Me.pnlInventoryHistory.Controls.Add(Me.pnlInventoryHistorySub)
        Me.pnlInventoryHistory.Controls.Add(Me.Label20)
        Me.pnlInventoryHistory.Controls.Add(Me.Label21)
        Me.pnlInventoryHistory.Controls.Add(Me.pnlItems)
        Me.pnlInventoryHistory.Controls.Add(Me.picSearch)
        Me.pnlInventoryHistory.Controls.Add(Me.cmbInventoryHistoryReport)
        Me.pnlInventoryHistory.Location = New System.Drawing.Point(3, 182)
        Me.pnlInventoryHistory.Name = "pnlInventoryHistory"
        Me.pnlInventoryHistory.Size = New System.Drawing.Size(206, 219)
        Me.pnlInventoryHistory.TabIndex = 211
        Me.pnlInventoryHistory.Visible = False
        '
        'pnlInventoryHistorySub
        '
        Me.pnlInventoryHistorySub.Controls.Add(Me.chklotno)
        Me.pnlInventoryHistorySub.Controls.Add(Me.cmblotno)
        Me.pnlInventoryHistorySub.Controls.Add(Me.Label23)
        Me.pnlInventoryHistorySub.Controls.Add(Me.Label22)
        Me.pnlInventoryHistorySub.Location = New System.Drawing.Point(0, 169)
        Me.pnlInventoryHistorySub.Name = "pnlInventoryHistorySub"
        Me.pnlInventoryHistorySub.Size = New System.Drawing.Size(206, 38)
        Me.pnlInventoryHistorySub.TabIndex = 212
        Me.pnlInventoryHistorySub.Visible = False
        '
        'chklotno
        '
        Me.chklotno.AutoSize = True
        Me.chklotno.Location = New System.Drawing.Point(4, 11)
        Me.chklotno.Name = "chklotno"
        Me.chklotno.Size = New System.Drawing.Size(15, 14)
        Me.chklotno.TabIndex = 106
        Me.chklotno.UseVisualStyleBackColor = True
        '
        'cmblotno
        '
        Me.cmblotno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmblotno.Enabled = False
        Me.cmblotno.FormattingEnabled = True
        Me.cmblotno.Location = New System.Drawing.Point(99, 7)
        Me.cmblotno.Name = "cmblotno"
        Me.cmblotno.Size = New System.Drawing.Size(105, 21)
        Me.cmblotno.TabIndex = 107
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(20, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(35, 13)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "Serial"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(20, 7)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 13)
        Me.Label22.TabIndex = 110
        Me.Label22.Text = "Show Lot No./"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(1, 3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 13)
        Me.Label20.TabIndex = 108
        Me.Label20.Text = "Report:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(1, 47)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(120, 13)
        Me.Label21.TabIndex = 109
        Me.Label21.Text = "Itemcode/Description:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlItems
        '
        Me.pnlItems.BackColor = System.Drawing.Color.White
        Me.pnlItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlItems.Location = New System.Drawing.Point(1, 65)
        Me.pnlItems.Name = "pnlItems"
        Me.pnlItems.Size = New System.Drawing.Size(197, 104)
        Me.pnlItems.TabIndex = 210
        '
        'picSearch
        '
        Me.picSearch.BackColor = System.Drawing.SystemColors.Control
        Me.picSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picSearch.Image = CType(resources.GetObject("picSearch.Image"), System.Drawing.Image)
        Me.picSearch.Location = New System.Drawing.Point(174, 45)
        Me.picSearch.Name = "picSearch"
        Me.picSearch.Size = New System.Drawing.Size(23, 19)
        Me.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picSearch.TabIndex = 209
        Me.picSearch.TabStop = False
        '
        'cmbInventoryHistoryReport
        '
        Me.cmbInventoryHistoryReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbInventoryHistoryReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInventoryHistoryReport.FormattingEnabled = True
        Me.cmbInventoryHistoryReport.Location = New System.Drawing.Point(4, 19)
        Me.cmbInventoryHistoryReport.Name = "cmbInventoryHistoryReport"
        Me.cmbInventoryHistoryReport.Size = New System.Drawing.Size(196, 21)
        Me.cmbInventoryHistoryReport.TabIndex = 107
        '
        'pnlInventory
        '
        Me.pnlInventory.BackColor = System.Drawing.Color.White
        Me.pnlInventory.Controls.Add(Me.Label19)
        Me.pnlInventory.Controls.Add(Me.lblInventoryStartDate)
        Me.pnlInventory.Controls.Add(Me.cmbInventoryHitoryOffice)
        Me.pnlInventory.Controls.Add(Me.lblInventoryEndDate)
        Me.pnlInventory.Controls.Add(Me.dtpInventoryHistoryEndDate)
        Me.pnlInventory.Controls.Add(Me.dtpInventoryHistoryStartDate)
        Me.pnlInventory.Location = New System.Drawing.Point(2, 89)
        Me.pnlInventory.Name = "pnlInventory"
        Me.pnlInventory.Size = New System.Drawing.Size(207, 90)
        Me.pnlInventory.TabIndex = 112
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(4, 49)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 13)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "Office:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblInventoryStartDate
        '
        Me.lblInventoryStartDate.AutoSize = True
        Me.lblInventoryStartDate.BackColor = System.Drawing.Color.Transparent
        Me.lblInventoryStartDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventoryStartDate.ForeColor = System.Drawing.Color.Black
        Me.lblInventoryStartDate.Location = New System.Drawing.Point(3, 8)
        Me.lblInventoryStartDate.Name = "lblInventoryStartDate"
        Me.lblInventoryStartDate.Size = New System.Drawing.Size(61, 13)
        Me.lblInventoryStartDate.TabIndex = 91
        Me.lblInventoryStartDate.Text = "Start Date:"
        Me.lblInventoryStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbInventoryHitoryOffice
        '
        Me.cmbInventoryHitoryOffice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbInventoryHitoryOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInventoryHitoryOffice.FormattingEnabled = True
        Me.cmbInventoryHitoryOffice.Location = New System.Drawing.Point(6, 65)
        Me.cmbInventoryHitoryOffice.Name = "cmbInventoryHitoryOffice"
        Me.cmbInventoryHitoryOffice.Size = New System.Drawing.Size(196, 21)
        Me.cmbInventoryHitoryOffice.TabIndex = 105
        '
        'lblInventoryEndDate
        '
        Me.lblInventoryEndDate.AutoSize = True
        Me.lblInventoryEndDate.BackColor = System.Drawing.Color.Transparent
        Me.lblInventoryEndDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventoryEndDate.ForeColor = System.Drawing.Color.Black
        Me.lblInventoryEndDate.Location = New System.Drawing.Point(103, 8)
        Me.lblInventoryEndDate.Name = "lblInventoryEndDate"
        Me.lblInventoryEndDate.Size = New System.Drawing.Size(57, 13)
        Me.lblInventoryEndDate.TabIndex = 92
        Me.lblInventoryEndDate.Text = "End Date:"
        Me.lblInventoryEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpInventoryHistoryEndDate
        '
        Me.dtpInventoryHistoryEndDate.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInventoryHistoryEndDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpInventoryHistoryEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInventoryHistoryEndDate.Location = New System.Drawing.Point(106, 21)
        Me.dtpInventoryHistoryEndDate.Name = "dtpInventoryHistoryEndDate"
        Me.dtpInventoryHistoryEndDate.Size = New System.Drawing.Size(99, 21)
        Me.dtpInventoryHistoryEndDate.TabIndex = 90
        '
        'dtpInventoryHistoryStartDate
        '
        Me.dtpInventoryHistoryStartDate.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInventoryHistoryStartDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtpInventoryHistoryStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInventoryHistoryStartDate.Location = New System.Drawing.Point(5, 21)
        Me.dtpInventoryHistoryStartDate.Name = "dtpInventoryHistoryStartDate"
        Me.dtpInventoryHistoryStartDate.Size = New System.Drawing.Size(99, 21)
        Me.dtpInventoryHistoryStartDate.TabIndex = 89
        '
        'pnlInventoryBatch2
        '
        Me.pnlInventoryBatch2.BackColor = System.Drawing.Color.White
        Me.pnlInventoryBatch2.Controls.Add(Me.pnlInventoryBatch2Sub)
        Me.pnlInventoryBatch2.Controls.Add(Me.Label29)
        Me.pnlInventoryBatch2.Controls.Add(Me.cmbSupplier)
        Me.pnlInventoryBatch2.Location = New System.Drawing.Point(9, 247)
        Me.pnlInventoryBatch2.Name = "pnlInventoryBatch2"
        Me.pnlInventoryBatch2.Size = New System.Drawing.Size(206, 219)
        Me.pnlInventoryBatch2.TabIndex = 306
        Me.pnlInventoryBatch2.Visible = False
        '
        'pnlInventoryBatch2Sub
        '
        Me.pnlInventoryBatch2Sub.Controls.Add(Me.lblMonths)
        Me.pnlInventoryBatch2Sub.Controls.Add(Me.txtNearExpiryDate)
        Me.pnlInventoryBatch2Sub.Controls.Add(Me.cbNearExpiryDate)
        Me.pnlInventoryBatch2Sub.Controls.Add(Me.cmbNearExpiryDate)
        Me.pnlInventoryBatch2Sub.Location = New System.Drawing.Point(0, 49)
        Me.pnlInventoryBatch2Sub.Name = "pnlInventoryBatch2Sub"
        Me.pnlInventoryBatch2Sub.Size = New System.Drawing.Size(206, 75)
        Me.pnlInventoryBatch2Sub.TabIndex = 213
        '
        'lblMonths
        '
        Me.lblMonths.AutoSize = True
        Me.lblMonths.Location = New System.Drawing.Point(134, 31)
        Me.lblMonths.Name = "lblMonths"
        Me.lblMonths.Size = New System.Drawing.Size(46, 13)
        Me.lblMonths.TabIndex = 216
        Me.lblMonths.Text = "Month/s"
        Me.lblMonths.Visible = False
        '
        'txtNearExpiryDate
        '
        Me.txtNearExpiryDate.Location = New System.Drawing.Point(101, 27)
        Me.txtNearExpiryDate.Name = "txtNearExpiryDate"
        Me.txtNearExpiryDate.Size = New System.Drawing.Size(31, 21)
        Me.txtNearExpiryDate.TabIndex = 215
        Me.txtNearExpiryDate.Text = "1"
        Me.txtNearExpiryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtNearExpiryDate.Visible = False
        '
        'cbNearExpiryDate
        '
        Me.cbNearExpiryDate.AutoSize = True
        Me.cbNearExpiryDate.Location = New System.Drawing.Point(6, 7)
        Me.cbNearExpiryDate.Name = "cbNearExpiryDate"
        Me.cbNearExpiryDate.Size = New System.Drawing.Size(108, 17)
        Me.cbNearExpiryDate.TabIndex = 214
        Me.cbNearExpiryDate.Text = "Near Expiry Date"
        Me.cbNearExpiryDate.UseVisualStyleBackColor = True
        '
        'cmbNearExpiryDate
        '
        Me.cmbNearExpiryDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbNearExpiryDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNearExpiryDate.FormattingEnabled = True
        Me.cmbNearExpiryDate.Location = New System.Drawing.Point(22, 26)
        Me.cmbNearExpiryDate.Name = "cmbNearExpiryDate"
        Me.cmbNearExpiryDate.Size = New System.Drawing.Size(73, 21)
        Me.cmbNearExpiryDate.TabIndex = 213
        Me.cmbNearExpiryDate.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(3, 7)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 13)
        Me.Label29.TabIndex = 108
        Me.Label29.Text = "Supplier:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSupplier
        '
        Me.cmbSupplier.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Location = New System.Drawing.Point(5, 23)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(196, 21)
        Me.cmbSupplier.TabIndex = 107
        '
        'cbIncludeNegativeQuantity
        '
        Me.cbIncludeNegativeQuantity.AutoSize = True
        Me.cbIncludeNegativeQuantity.Location = New System.Drawing.Point(6, 145)
        Me.cbIncludeNegativeQuantity.Name = "cbIncludeNegativeQuantity"
        Me.cbIncludeNegativeQuantity.Size = New System.Drawing.Size(128, 17)
        Me.cbIncludeNegativeQuantity.TabIndex = 20
        Me.cbIncludeNegativeQuantity.Text = "Include Negative Qty"
        Me.cbIncludeNegativeQuantity.UseVisualStyleBackColor = True
        '
        'cbIncludeZeroQty
        '
        Me.cbIncludeZeroQty.AutoSize = True
        Me.cbIncludeZeroQty.Location = New System.Drawing.Point(6, 128)
        Me.cbIncludeZeroQty.Name = "cbIncludeZeroQty"
        Me.cbIncludeZeroQty.Size = New System.Drawing.Size(107, 17)
        Me.cbIncludeZeroQty.TabIndex = 19
        Me.cbIncludeZeroQty.Text = "Include Zero Qty"
        Me.cbIncludeZeroQty.UseVisualStyleBackColor = True
        '
        'cbOrderByExpiry
        '
        Me.cbOrderByExpiry.AutoSize = True
        Me.cbOrderByExpiry.Enabled = False
        Me.cbOrderByExpiry.Location = New System.Drawing.Point(6, 111)
        Me.cbOrderByExpiry.Name = "cbOrderByExpiry"
        Me.cbOrderByExpiry.Size = New System.Drawing.Size(128, 17)
        Me.cbOrderByExpiry.TabIndex = 18
        Me.cbOrderByExpiry.Text = "Order By Expiry Date"
        Me.cbOrderByExpiry.UseVisualStyleBackColor = True
        '
        'cbShowLotNo
        '
        Me.cbShowLotNo.AutoSize = True
        Me.cbShowLotNo.Location = New System.Drawing.Point(6, 94)
        Me.cbShowLotNo.Name = "cbShowLotNo"
        Me.cbShowLotNo.Size = New System.Drawing.Size(113, 17)
        Me.cbShowLotNo.TabIndex = 17
        Me.cbShowLotNo.Text = "Show LotNo/Serial"
        Me.cbShowLotNo.UseVisualStyleBackColor = True
        '
        'pnlInventoryStatus
        '
        Me.pnlInventoryStatus.BackColor = System.Drawing.Color.White
        Me.pnlInventoryStatus.Controls.Add(Me.cbStatusCategory)
        Me.pnlInventoryStatus.Controls.Add(Me.cbStatusSupplier)
        Me.pnlInventoryStatus.Controls.Add(Me.cmbStatusCategory)
        Me.pnlInventoryStatus.Controls.Add(Me.cbIncludeNegativeQuantity)
        Me.pnlInventoryStatus.Controls.Add(Me.cbIncludeZeroQty)
        Me.pnlInventoryStatus.Controls.Add(Me.cmbStatusSupplier)
        Me.pnlInventoryStatus.Controls.Add(Me.cbOrderByExpiry)
        Me.pnlInventoryStatus.Controls.Add(Me.cbShowLotNo)
        Me.pnlInventoryStatus.Location = New System.Drawing.Point(9, 247)
        Me.pnlInventoryStatus.Name = "pnlInventoryStatus"
        Me.pnlInventoryStatus.Size = New System.Drawing.Size(206, 219)
        Me.pnlInventoryStatus.TabIndex = 308
        Me.pnlInventoryStatus.Visible = False
        '
        'cbStatusCategory
        '
        Me.cbStatusCategory.AutoSize = True
        Me.cbStatusCategory.Location = New System.Drawing.Point(6, 48)
        Me.cbStatusCategory.Name = "cbStatusCategory"
        Me.cbStatusCategory.Size = New System.Drawing.Size(71, 17)
        Me.cbStatusCategory.TabIndex = 112
        Me.cbStatusCategory.Text = "Category"
        Me.cbStatusCategory.UseVisualStyleBackColor = True
        '
        'cbStatusSupplier
        '
        Me.cbStatusSupplier.AutoSize = True
        Me.cbStatusSupplier.Location = New System.Drawing.Point(6, 4)
        Me.cbStatusSupplier.Name = "cbStatusSupplier"
        Me.cbStatusSupplier.Size = New System.Drawing.Size(64, 17)
        Me.cbStatusSupplier.TabIndex = 111
        Me.cbStatusSupplier.Text = "Supplier"
        Me.cbStatusSupplier.UseVisualStyleBackColor = True
        '
        'cmbStatusCategory
        '
        Me.cmbStatusCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbStatusCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatusCategory.Enabled = False
        Me.cmbStatusCategory.FormattingEnabled = True
        Me.cmbStatusCategory.Location = New System.Drawing.Point(5, 66)
        Me.cmbStatusCategory.Name = "cmbStatusCategory"
        Me.cmbStatusCategory.Size = New System.Drawing.Size(196, 21)
        Me.cmbStatusCategory.TabIndex = 109
        '
        'cmbStatusSupplier
        '
        Me.cmbStatusSupplier.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbStatusSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatusSupplier.Enabled = False
        Me.cmbStatusSupplier.FormattingEnabled = True
        Me.cmbStatusSupplier.Location = New System.Drawing.Point(5, 23)
        Me.cmbStatusSupplier.Name = "cmbStatusSupplier"
        Me.cmbStatusSupplier.Size = New System.Drawing.Size(196, 21)
        Me.cmbStatusSupplier.TabIndex = 107
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpMedicalRecords)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpPharmacy)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpFinancialReport)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlItemInventoryStatusByOffice)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpInventoryHistory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pctrshow)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pctrHide)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlInventoryBatch2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlInventoryStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpForms)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpDOH)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpRadiology)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpbxCashierReports)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpLaboratory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tsModule)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.crptViewer)
        Me.SplitContainer1.Size = New System.Drawing.Size(1233, 622)
        Me.SplitContainer1.SplitterDistance = 222
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 309
        '
        'pnlItemInventoryStatusByOffice
        '
        Me.pnlItemInventoryStatusByOffice.Controls.Add(Me.Label31)
        Me.pnlItemInventoryStatusByOffice.Controls.Add(Me.pnlItems2)
        Me.pnlItemInventoryStatusByOffice.Controls.Add(Me.pbItemSearch)
        Me.pnlItemInventoryStatusByOffice.Location = New System.Drawing.Point(7, 203)
        Me.pnlItemInventoryStatusByOffice.Name = "pnlItemInventoryStatusByOffice"
        Me.pnlItemInventoryStatusByOffice.Size = New System.Drawing.Size(206, 263)
        Me.pnlItemInventoryStatusByOffice.TabIndex = 212
        Me.pnlItemInventoryStatusByOffice.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(3, 5)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(120, 13)
        Me.Label31.TabIndex = 109
        Me.Label31.Text = "Itemcode/Description:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlItems2
        '
        Me.pnlItems2.BackColor = System.Drawing.Color.White
        Me.pnlItems2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlItems2.Location = New System.Drawing.Point(3, 23)
        Me.pnlItems2.Name = "pnlItems2"
        Me.pnlItems2.Size = New System.Drawing.Size(197, 104)
        Me.pnlItems2.TabIndex = 210
        '
        'pbItemSearch
        '
        Me.pbItemSearch.BackColor = System.Drawing.SystemColors.Control
        Me.pbItemSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbItemSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbItemSearch.Image = CType(resources.GetObject("pbItemSearch.Image"), System.Drawing.Image)
        Me.pbItemSearch.Location = New System.Drawing.Point(176, 3)
        Me.pbItemSearch.Name = "pbItemSearch"
        Me.pbItemSearch.Size = New System.Drawing.Size(23, 19)
        Me.pbItemSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbItemSearch.TabIndex = 209
        Me.pbItemSearch.TabStop = False
        '
        'pctrshow
        '
        Me.pctrshow.Image = CType(resources.GetObject("pctrshow.Image"), System.Drawing.Image)
        Me.pctrshow.Location = New System.Drawing.Point(202, 2)
        Me.pctrshow.Name = "pctrshow"
        Me.pctrshow.Size = New System.Drawing.Size(16, 14)
        Me.pctrshow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctrshow.TabIndex = 310
        Me.pctrshow.TabStop = False
        '
        'pctrHide
        '
        Me.pctrHide.Image = CType(resources.GetObject("pctrHide.Image"), System.Drawing.Image)
        Me.pctrHide.Location = New System.Drawing.Point(202, 2)
        Me.pctrHide.Name = "pctrHide"
        Me.pctrHide.Size = New System.Drawing.Size(16, 14)
        Me.pctrHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctrHide.TabIndex = 311
        Me.pctrHide.TabStop = False
        Me.pctrHide.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAutoHide})
        Me.ToolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip2.Size = New System.Drawing.Size(30, 630)
        Me.ToolStrip2.TabIndex = 97
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsAutoHide
        '
        Me.tsAutoHide.AutoSize = False
        Me.tsAutoHide.Image = CType(resources.GetObject("tsAutoHide.Image"), System.Drawing.Image)
        Me.tsAutoHide.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tsAutoHide.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsAutoHide.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAutoHide.Name = "tsAutoHide"
        Me.tsAutoHide.Size = New System.Drawing.Size(23, 182)
        Me.tsAutoHide.Text = "Tools"
        Me.tsAutoHide.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90
        Me.tsAutoHide.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "..."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 951
        '
        'frmReportHandler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1236, 625)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.pctrLogo)
        Me.Controls.Add(Me.lblTelno)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.lblCompanyname)
        Me.Controls.Add(Me.lblAddress)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmReportHandler"
        Me.Text = "frmReportHandler"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpbxCashierReports.ResumeLayout(False)
        Me.grpbxCashierReports.PerformLayout()
        Me.grpDOH.ResumeLayout(False)
        Me.grpDOH.PerformLayout()
        Me.grpLaboratory.ResumeLayout(False)
        Me.grpLaboratory.PerformLayout()
        Me.grpMedicalRecords.ResumeLayout(False)
        Me.grpMedicalRecords.PerformLayout()
        CType(Me.dgGenericList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRadiology.ResumeLayout(False)
        Me.grpRadiology.PerformLayout()
        Me.grpForms.ResumeLayout(False)
        Me.grpForms.PerformLayout()
        CType(Me.dgGenericList2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctrLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpFinancialReport.ResumeLayout(False)
        Me.grpFinancialReport.PerformLayout()
        Me.grpAccountPayableTrade.ResumeLayout(False)
        Me.grpAccountPayableTrade.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpPharmacy.ResumeLayout(False)
        Me.grpPharmacy.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInventoryHistory.ResumeLayout(False)
        Me.grpInventorySearch.ResumeLayout(False)
        Me.grpInventorySearch.PerformLayout()
        CType(Me.pcSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInventoryBatch1.ResumeLayout(False)
        Me.pnlInventoryBatch1.PerformLayout()
        Me.pnlInventoryBatch1Sub.ResumeLayout(False)
        Me.pnlInventoryBatch1Sub.PerformLayout()
        CType(Me.numDays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInventoryHistory.ResumeLayout(False)
        Me.pnlInventoryHistory.PerformLayout()
        Me.pnlInventoryHistorySub.ResumeLayout(False)
        Me.pnlInventoryHistorySub.PerformLayout()
        CType(Me.picSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInventory.ResumeLayout(False)
        Me.pnlInventory.PerformLayout()
        Me.pnlInventoryBatch2.ResumeLayout(False)
        Me.pnlInventoryBatch2.PerformLayout()
        Me.pnlInventoryBatch2Sub.ResumeLayout(False)
        Me.pnlInventoryBatch2Sub.PerformLayout()
        Me.pnlInventoryStatus.ResumeLayout(False)
        Me.pnlInventoryStatus.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlItemInventoryStatusByOffice.ResumeLayout(False)
        Me.pnlItemInventoryStatusByOffice.PerformLayout()
        CType(Me.pbItemSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctrshow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctrHide, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents crptViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pctrLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblTelno As System.Windows.Forms.Label
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsExportToPDF As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPrev As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsEmail As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dtPyearDOH As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbMonthDOH As System.Windows.Forms.ComboBox
    Friend WithEvents lblQuarter As System.Windows.Forms.Label
    Friend WithEvents grpbxCashierReports As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndTimeCR As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartTimeCR As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateToCR As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateFromCR As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents tsFirstPage As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsLastPage As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grpDOH As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndTimeDOH As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartTimeDOH As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateToDOH As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateFromDOH As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmICD10CodeDOH As System.Windows.Forms.ComboBox
    Friend WithEvents lblICD10Code As System.Windows.Forms.Label
    Friend WithEvents crptDOHPage1 As System.Windows.Forms.Button
    Friend WithEvents crptDOHPage10 As System.Windows.Forms.Button
    Friend WithEvents crptDOHPage9 As System.Windows.Forms.Button
    Friend WithEvents crptDOHPage8 As System.Windows.Forms.Button
    Friend WithEvents crptDOHPage7 As System.Windows.Forms.Button
    Friend WithEvents crptDOHPage6 As System.Windows.Forms.Button
    Friend WithEvents crptDOHPage5 As System.Windows.Forms.Button
    Friend WithEvents crptDOHPage4 As System.Windows.Forms.Button
    Friend WithEvents crptDOHPage3 As System.Windows.Forms.Button
    Friend WithEvents crptDOHPage2 As System.Windows.Forms.Button
    Friend WithEvents tsModule As System.Windows.Forms.Button
    Friend WithEvents grpLaboratory As System.Windows.Forms.GroupBox
    Friend WithEvents dtEndLaboratory As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStartlaboratory As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtToLaboratory As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFromlaboratory As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpMedicalRecords As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpYearMedicalRecords As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbMonthMedicalRecords As System.Windows.Forms.ComboBox
    Friend WithEvents dgGenericList As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grpRadiology As System.Windows.Forms.GroupBox
    Friend WithEvents dtEndtimeRadiology As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStarttimeradiology As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtToRadiology As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtfromradiology As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbOffice As System.Windows.Forms.ComboBox
    Friend WithEvents cmfilm As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grpForms As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearchForms As System.Windows.Forms.Button
    Friend WithEvents dgGenericList2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSearchForms As System.Windows.Forms.TextBox
    Friend WithEvents lblCompanyname As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsZoom As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsSystem As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents grpFinancialReport As System.Windows.Forms.GroupBox
    Friend WithEvents dtEndTimeFinancial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStartTimeFinancial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtToFinancial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFromFinancial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents grpPharmacy As System.Windows.Forms.GroupBox
    Friend WithEvents dtEndTimePharmacy As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStartTimePharmacy As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtToPharmacy As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFromPharmacy As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtEndTimeMedicalRecords As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtStartTimeMedicalRecords As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtToMedicalRecords As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFromMedicalRecords As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tsSearchtext As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents grpInventoryHistory As System.Windows.Forms.GroupBox
    Friend WithEvents dtpInventoryHistoryEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInventoryHistoryStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblInventoryEndDate As System.Windows.Forms.Label
    Friend WithEvents lblInventoryStartDate As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbInventoryHistoryReport As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbInventoryHitoryOffice As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmblotno As System.Windows.Forms.ComboBox
    Friend WithEvents chklotno As System.Windows.Forms.CheckBox
    Friend WithEvents pnlItems As System.Windows.Forms.Label
    Friend WithEvents picSearch As System.Windows.Forms.PictureBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents pnlInventoryHistory As System.Windows.Forms.Panel
    Friend WithEvents pnlInventory As System.Windows.Forms.Panel
    Friend WithEvents pnlInventoryHistorySub As System.Windows.Forms.Panel
    Friend WithEvents pnlInventoryBatch1 As System.Windows.Forms.Panel
    Friend WithEvents pnlInventoryBatch1Sub As System.Windows.Forms.Panel
    Friend WithEvents cbExcludeItemswithZeroQty As System.Windows.Forms.CheckBox
    Friend WithEvents cbIncludeStockTransOut As System.Windows.Forms.CheckBox
    Friend WithEvents txtInventorySearch As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cbExcludeReceivedStocks As System.Windows.Forms.CheckBox
    Friend WithEvents numDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents grpInventorySearch As System.Windows.Forms.GroupBox
    Friend WithEvents pnlInventoryBatch2 As System.Windows.Forms.Panel
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents pnlInventoryBatch2Sub As System.Windows.Forms.Panel
    Friend WithEvents cmbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents lblMonths As System.Windows.Forms.Label
    Friend WithEvents txtNearExpiryDate As System.Windows.Forms.TextBox
    Friend WithEvents cbNearExpiryDate As System.Windows.Forms.CheckBox
    Friend WithEvents cmbNearExpiryDate As System.Windows.Forms.ComboBox
    Friend WithEvents cbIncludeNegativeQuantity As System.Windows.Forms.CheckBox
    Friend WithEvents cbIncludeZeroQty As System.Windows.Forms.CheckBox
    Friend WithEvents cbOrderByExpiry As System.Windows.Forms.CheckBox
    Friend WithEvents cbShowLotNo As System.Windows.Forms.CheckBox
    Friend WithEvents pnlInventoryStatus As System.Windows.Forms.Panel
    Friend WithEvents cmbStatusCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cmbStatusSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents cbStatusCategory As System.Windows.Forms.CheckBox
    Friend WithEvents cbStatusSupplier As System.Windows.Forms.CheckBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents pctrHide As System.Windows.Forms.PictureBox
    Friend WithEvents pctrshow As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsAutoHide As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmbDateType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbfilterby As System.Windows.Forms.ComboBox
    Friend WithEvents pnlItemInventoryStatusByOffice As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents pnlItems2 As System.Windows.Forms.Label
    Friend WithEvents pbItemSearch As System.Windows.Forms.PictureBox
    Friend WithEvents pcSearch As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblieforAgedPayable As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkincludeoverdueinvoiceonly As System.Windows.Forms.CheckBox
    Friend WithEvents chkshowDetails As System.Windows.Forms.CheckBox
    Friend WithEvents tscombobranch As System.Windows.Forms.ComboBox
    Friend WithEvents tsSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Dateto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Datefrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbInvoiceSummary As System.Windows.Forms.ComboBox
    Friend WithEvents lblInvoicesummarymonth As System.Windows.Forms.Label
    Friend WithEvents lblinvociesummaryyear As System.Windows.Forms.Label
    Friend WithEvents cmbinvoicesummaryyear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents grpAccountPayableTrade As System.Windows.Forms.GroupBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents dtAccountPayabaleTradeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbPharmaOffice As System.Windows.Forms.ComboBox
    Friend WithEvents lblOfficePharma As System.Windows.Forms.Label
    Friend WithEvents lblEmployeePharma As System.Windows.Forms.Label
    Friend WithEvents cmbPharmaEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents txtpurpose As System.Windows.Forms.TextBox
End Class
