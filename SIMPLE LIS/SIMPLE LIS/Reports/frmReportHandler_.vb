Imports System.Data
Imports System.Data.SqlClient
Imports SIMPLE_LIS.Utility
Imports System.Configuration
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
'Imports System.Web.Mail
Imports System.Collections
Imports System.Drawing.Printing
Imports System.Management
Public Class frmReportHandler

#Region "All Variables"
    Public varno As Long
    Public varstr, varlotno, varbyid, varfiltertype As String
    Public varoffice, vardestinationoffice As String
    Public varsupplierno As String
    Public employeeName As String
    Public varStart, varEnd, varCutoffdate As Date
    Public varitemcode As String
    Public varWithCost As Boolean
    Public printType As String
    Public ReportName As String
    Public Operation As Integer
    Public varno2 As Long
    Public fYear As String
    Public fMonth As String
    Public vstartdate, venddate As String
    Public isAutoPrint As Boolean
    Public isUsedByDashboard, isincrementorno As Boolean
    Public isshowtoggle As Boolean = True
    Public tempDataTable As New DataTable()
    Dim PageCount As Integer
    Dim CrExportOptions As ExportOptions
    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
    Dim resultrpt
    Dim savedCursor As Windows.Forms.Cursor
    Dim indicator As Boolean = False
    Dim othernearexpirydate As Long = 1
    Dim ishide, canresize, doneloading, isLoad As Boolean
    Public IsReportMain As Boolean = False
    '=========---JAYMAR---========
    Dim afterInit As Boolean
    Private phicno As String                '---JAYMAR
    Private phictagging As Boolean = True
    Dim ischecked As Boolean
    Dim idx As Integer
    Dim idxfilter As Integer
    Dim admissiondateFrom As Date
    Dim admissiondateTo As Date
    Dim tagdateto As Boolean
    Dim daydiff As Integer
    '=========---JAYMAR---========

    Sub New()
        InitializeComponent()
        loadZoom()
        'Dim dtrecords = clsHospitalInfo.getInfo(0, "")
        'Try
        '    If IsDBNull(dtrecords.Rows(0).Item("hospitallogo")) Then
        '        Me.pctrLogo.Image = Nothing
        '    Else
        '        Dim tempphoto As Byte() = dtrecords.Rows(0).Item("hospitallogo")
        '        If tempphoto.Length = 0 Then
        '            Me.pctrLogo.Image = Nothing
        '        Else
        '            Me.pctrLogo.Image = Utility.convertImage(dtrecords.Rows(0).Item("hospitallogo")) 'image here
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
        'Me.lblCompanyname.Text = dtrecords.Rows(0).Item("HospName").ToString()
        'Me.lblAddress.Text = dtrecords.Rows(0).Item("NoStreet").ToString() & " " _
        '    & dtrecords.Rows(0).Item("Barangay").ToString() & " " _
        '    & dtrecords.Rows(0).Item("MunCity").ToString() & " " _
        '    & dtrecords.Rows(0).Item("Province").ToString() & " " _
        '    & dtrecords.Rows(0).Item("region").ToString()
        'Me.lblTelno.Text = dtrecords.Rows(0).Item("Telephone").ToString()
        'Me.tsSystem.Text = modGlobal.msgboxTitle
        Me.KeyPreview = 1
    End Sub
#End Region

#Region "Form Events"
    Private Sub frmReportHandler_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        afterInit = False
        LoadPeriod(Me.cmbPeriod)
        toggle(, isshowtoggle) 
        LoadReport()
        isLoad = True
        afterInit = True
    End Sub
    Private Sub ts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPrint.Click, tsRefresh.Click, tsExportToPDF.Click, tsExportToExcel.Click, tsPrev.Click, tsNext.Click, tsEmail.Click, tsLastPage.Click, tsFirstPage.Click, crptDOHPage9.Click, crptDOHPage8.Click, crptDOHPage7.Click, crptDOHPage6.Click, crptDOHPage5.Click, crptDOHPage4.Click, crptDOHPage3.Click, crptDOHPage2.Click, crptDOHPage10.Click, crptDOHPage1.Click, tsClose.Click, btnSearch.Click, btnSearchForms.Click, tsZoom.SelectedIndexChanged, tsSearch.Click, tsModule.Click
        action(sender.name)
    End Sub
    Private Sub dgGenericList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgGenericList.CellClick
        LoadReport()
    End Sub
    Private Sub dgGenericList2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgGenericList2.CellClick
        LoadReport()
    End Sub 
    Private Sub frmReportHandler_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter And printType <> "Medical Certificate" Then
            LoadReport()
        ElseIf e.KeyCode = Keys.F3 And (printType = "e-Stock Card" Or printType = "Stock Receiving Entries History" Or printType = "Stock Transfer History" _
            Or printType = "Stock Adjustment History" Or printType = "Stock Extraction History" _
            Or printType = "Stock Return to Supplier History" Or printType = "Stock Invoice Return History" _
            Or printType = "Patient Charges History" Or printType = "Employee Charges History" _
            Or printType = "Expense Issuance History" Or printType = "Dead Stocks" _
            Or printType = "Reorder Stocks" Or printType = "Slow Moving Stocks" _
            Or printType = "Stock Expiry List" Or printType = "Stock Below Minimum Level List" _
            Or printType = "Inventory Status Report") Then
            Me.txtInventorySearch.Focus()
            txtInventorySearch.SelectionStart = 0
            txtInventorySearch.SelectionLength = txtSearch.Text.Length
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub cmbPeriod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPeriod.SelectedIndexChanged
        If printType = "Admission and Discharge Report" Or printType = "Daily Census" Then
            If afterInit And idxfilter <> Me.cmbPeriod.SelectedIndex Then
                idxfilter = cmbPeriod.SelectedIndex
                Call getPeriodDateRange(Me.cmbPeriod) ', vstartdate, venddate)
                Call LoadReport()
            End If
            Call EnableDateFilter()
            Exit Sub
        End If
        If isLoad Then
            ' If sender.name = "cmbPeriod" Then
            If printType <> "Patient Account Receivables Summary" And printType <> "Patient Account Receivables Details" Then
                If sender.name = "cmbPeriod" Then
                    getPeriodDateRange(Me.cmbPeriod, Me.Datefrom.Value, Me.Dateto.Value, Me.Datefrom, Me.Dateto, Me.Label18, Me.Label17)
                    If Me.cmbPeriod.SelectedIndex <> 5 Then
                        Me.Label30.Location = New Point(5, 36)
                        Me.cmbPeriod.Location = New Point(45, 32)
                    Else
                        Me.Label30.Location = New Point(6, 14)
                        Me.cmbPeriod.Location = New Point(59, 9)
                    End If
                End If
            End If


            ' Else
            'If ischecked Then1
            '    Columnformatter()
            '    loadDataUnto()
            'Else
            '    loadDataUnto()
            'End If
            'loadHeader()
            ' End If
        Else : getPeriodDateRange(Me.cmbPeriod, Me.Datefrom.Value, Me.Dateto.Value, Me.Datefrom, Me.Dateto, Me.Label18, Me.Label17)
        End If

    End Sub
    Private Sub TextBox1_DragLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.DragLeave
        If Me.TextBox1.Text = "" Then
            Me.TextBox1.Text = "Type here and Press Enter key"
            Me.TextBox1.Font = New Font("Segoe UI", 8, FontStyle.Italic)
            Me.TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Me.TextBox1.Text = "Type here and Press Enter key" Then
            Me.TextBox1.Clear()
            Me.TextBox1.Font = New Font("Segoe UI", 8, FontStyle.Regular)
            Me.TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.MouseEnter
        If Me.TextBox1.Text = "Type here and Press Enter key" Then
            Me.TextBox1.Clear()
            Me.TextBox1.Font = New Font("Segoe UI", 8, FontStyle.Regular)
            Me.TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.MouseLeave
        If Me.TextBox1.Text = "" Then
            Me.TextBox1.Text = "Type here and Press Enter key"
            Me.TextBox1.Font = New Font("Segoe UI", 8, FontStyle.Italic)
            Me.TextBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub chkincludeoverdueinvoiceonly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkshowDetails.CheckedChanged
        If isLoad = True Then
            If printType = "Purchase Tax Reports" Or printType = "Purchase Tax Reports { Invoice Summary }" Or printType = "Purchase Tax Reports { Invoice Details }" Then
                ischecked = Me.chkshowDetails.Checked
                LoadOffice(Me.tscombobranch)
                'Me.tsSupplier.SelectedValue = 2
                If printType = "Purchase Tax Reports" Or printType = "Purchase Tax Reports { Invoice Summary }" Or printType = "Purchase Tax Reports { Invoice Details }" And chkshowDetails.Checked = True Then
                    If Me.tsSupplier.SelectedValue = 2 Then
                        printType = "Purchase Tax Reports { Invoice Summary }"
                        LoadReport()
                    ElseIf Me.tsSupplier.SelectedValue = 3 Then
                        printType = "Purchase Tax Reports { Invoice Details }"
                        LoadReport()
                    Else
                        printType = "Purchase Tax Reports"
                        LoadReport()
                        useForTax(False)
                    End If
                ElseIf printType = "Purchase Tax Reports" Or printType = "Purchase Tax Reports { Invoice Summary }" Or printType = "Purchase Tax Reports { Invoice Details }" And chkshowDetails.Checked = False Then
                    printType = "Purchase Tax Reports"
                    LoadReport()
                End If
            End If


        End If
    End Sub

    Private Sub chkincludeoverdueinvoiceonly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkincludeoverdueinvoiceonly.Click

    End Sub

    Private Sub tsSupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSupplier.SelectedIndexChanged
        If printType = "Purchase Tax Reports" Or printType = "Purchase Tax Reports { Invoice Summary }" Or printType = "Purchase Tax Reports { Invoice Details }" Then
            If Me.tsSupplier.SelectedValue = 2 Then
                printType = "Purchase Tax Reports { Invoice Summary }"
                LoadReport()
            ElseIf Me.tsSupplier.SelectedValue = 3 Then
                printType = "Purchase Tax Reports { Invoice Details }"
                LoadReport()
            End If
        End If


    End Sub

    Private Sub dtFromFinancial_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Datefrom.ValueChanged
        If printType = "Admission and Discharge Report" Or printType = "Daily Census" Then
            If Me.Datefrom.Value > Me.Dateto.Value And Me.Datefrom.Focused = True And Dateto.Enabled = True Then
                admissiondateTo = Me.Dateto.Value
                Me.Datefrom.Value = admissiondateTo
                Call getPeriodDateRange(Me.cmbPeriod)
            ElseIf Me.Datefrom.Focused = True Then
                Call getPeriodDateRange(Me.cmbPeriod)
            End If
        End If
    End Sub
    Private Sub dtToFinancial_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dateto.ValueChanged
        If printType = "Admission and Discharge Report" Or printType = "Daily Census" Then
            If Me.Dateto.Value < Me.Datefrom.Value And Me.Dateto.Focused = True And Datefrom.Enabled = True Then
                admissiondateFrom = Me.Datefrom.Value
                Me.Dateto.Value = admissiondateFrom
                Call getPeriodDateRange(Me.cmbPeriod)
            ElseIf Me.Dateto.Focused = True Then
                Call getPeriodDateRange(Me.cmbPeriod)
            End If
        End If
    End Sub


#End Region

#Region "Form Methods"
    Private Function LoadReportARs(reportname As String) As Boolean
        Dim isreportloaded As Boolean
        Dim da As SqlDataAdapter
         
        Dim gconn As New clsDBConnection
        gconn.CreateOpenConnection()

        Dim conn As New SqlConnection
        conn = gconn.GDBConn

        Dim dt As New DataTable
        Select Case reportname
            Case "AR PHIC"
                'Phil Health Account Receivables Details
                Me.grpFinancialReport.Visible = 1
                If isLoad = False Then
                    Call loaddatetype()
                    cmbDateType.SelectedValue = 1
                End If
                Me.cmbDateType.Visible = 1 

                varStart = FormatDateTime(Me.dtFromFinancial.Value, DateFormat.ShortDate) '& " " & Me.dtStartTimeFinancial.Text
                varEnd = FormatDateTime(Me.dtToFinancial.Value, DateFormat.ShortDate) '& " " & Me.dtEndTimeFinancial.Text

                If cmbDateType.SelectedValue = 1 Then
                    varstr = "1"
                Else
                    varstr = "0"
                End If

                Dim rpt As New crptARPHICDetails
                da = New SqlDataAdapter("Exec [spARPatientReports] 1,0,'','','" & varStart & "','" & varEnd & "'", conn)
                da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
                rpt.SetDataSource(dt)
                crptViewer.ReportSource = rpt
                Me.Text = "Accounts Receivable - PHIC"
                isreportloaded = True
                dt = Nothing
        End Select
        Me.tsModule.Text = Me.Text
        Me.crptViewer.ShowLastPage()
        PageCount = Me.crptViewer.GetCurrentPageNumber()
        Me.crptViewer.ShowFirstPage()
        If PageCount = 1 Then
            Me.tsNext.Enabled = False
            Me.tsLastPage.Enabled = False
        Else
            Me.tsNext.Enabled = True
            Me.tsLastPage.Enabled = True
        End If
        gconn.CloseDestroyConnection()
        Return isreportloaded
    End Function
    Private Sub LoadReport(Optional ByVal isAutoPrintDirectly As Boolean = False)
        isnotvisible()

        If LoadReportARs(printType) Then
            Exit Sub
        End If

        Dim da As SqlDataAdapter
         
        Dim gconn As New clsDBConnection
        gconn.CreateOpenConnection()

        Dim conn As New SqlConnection
        conn = gconn.GDBConn

        Dim dt As New DataTable
        If isUsedByDashboard Then
            Me.crptViewer.DisplayToolbar = False
        End If
        If printType = "EmployeeCreditPayrollDeductionsTrans" Then
            Me.Text = "Employee Credit Payroll Deduction Report"
        ElseIf printType = "EmployeeCreditPayrollDeductions" Then
            Me.Text = "Employee Credit Payroll Deduction Summary Report"
        ElseIf printType = "EmployeeSalaryDeductionBracket" Then
            Me.Text = "Employee Salary Deduction Bracket Report"
        Else
            Me.Text = printType
        End If

        If (printType = "e-Stock Card" Or printType = "Stock Receiving Entries History" Or printType = "Stock Transfer History" _
            Or printType = "Stock Adjustment History" Or printType = "Stock Extraction History" _
            Or printType = "Stock Return to Supplier History" Or printType = "Stock Invoice Return History" _
            Or printType = "Patient Charges History" Or printType = "Employee Charges History" _
            Or printType = "Expense Issuance History" Or printType = "Issuance History") And indicator = False Then
            If IsReportMain = False Then
                pnlItems.Text = fMain.dgGenericList.SelectedRows(0).Cells(1).Value
                varitemcode = fMain.dgGenericList.SelectedRows(0).Cells(0).Value
            End If

            grpInventoryHistory.Visible = True
            pnlInventoryHistory.Visible = True
            pnlInventoryHistory.BringToFront()
            grpInventorySearch.Enabled = False
            Call LoadOffice(cmbInventoryHitoryOffice)
            Call populatereports()
            indicator = True
            Me.dtpInventoryHistoryStartDate.Value = Me.dtpInventoryHistoryStartDate.Value.AddMonths(-1)
            Me.dtpInventoryHistoryStartDate.MaxDate = Me.dtpInventoryHistoryEndDate.Value
            Me.dtpInventoryHistoryEndDate.MinDate = Me.dtpInventoryHistoryStartDate.Value
        ElseIf printType = "Item Inventory Status By Office" And indicator = False Then
            grpInventoryHistory.Visible = True
            grpInventorySearch.Enabled = False
            Call LoadOffice(cmbInventoryHitoryOffice)
            Me.pnlItemInventoryStatusByOffice.Visible = True
            pnlItemInventoryStatusByOffice.BringToFront()
            indicator = True
            lblInventoryStartDate.Text = "As Of Date:"
            lblInventoryEndDate.Visible = False
            dtpInventoryHistoryEndDate.Visible = False
        ElseIf (printType = "Dead Stocks" Or printType = "Reorder Stocks" Or printType = "Slow Moving Stocks") _
        And indicator = False Then
            grpInventoryHistory.Visible = True
            Me.pnlInventoryBatch1.Visible = True
            pnlInventoryBatch1.BringToFront()
            Call LoadOffice(cmbInventoryHitoryOffice)
            indicator = True
            Me.dtpInventoryHistoryStartDate.Value = Me.dtpInventoryHistoryStartDate.Value.AddMonths(-1)
            Me.dtpInventoryHistoryStartDate.MaxDate = Me.dtpInventoryHistoryEndDate.Value
            Me.dtpInventoryHistoryEndDate.MinDate = Me.dtpInventoryHistoryStartDate.Value
        ElseIf printType = "Monthly Stock Inventory" And indicator = False Then
            grpInventoryHistory.Visible = True
            grpInventorySearch.Enabled = False
            Call LoadOffice(cmbInventoryHitoryOffice)
            indicator = True
            Me.dtpInventoryHistoryStartDate.Value = Me.dtpInventoryHistoryStartDate.Value.AddMonths(-1)
            Me.dtpInventoryHistoryStartDate.MaxDate = Me.dtpInventoryHistoryEndDate.Value
            Me.dtpInventoryHistoryEndDate.MinDate = Me.dtpInventoryHistoryStartDate.Value
        ElseIf (printType = "Stock Expiry List" Or printType = "Stock Below Minimum Level List") And indicator = False Then

            grpInventoryHistory.Visible = True
            Me.pnlInventoryBatch2.Visible = True
            pnlInventoryBatch2.BringToFront()
            Call LoadExpirySupplier()
            Call LoadOffice(cmbInventoryHitoryOffice)
            If printType = "Stock Expiry List" Then
                Call LoadExpiryNearDate()
            Else
                grpInventorySearch.Enabled = False
            End If

            indicator = True
            lblInventoryStartDate.Text = "As Of Date:"
            Me.dtpInventoryHistoryStartDate.Value = Me.dtpInventoryHistoryStartDate.Value
            lblInventoryEndDate.Visible = False
            dtpInventoryHistoryEndDate.Visible = False
        
        
        ElseIf (printType = "Summary of Items Issued as Expense" Or printType = "Summary of Items Received as Expense") _
            And indicator = False Then
            grpInventoryHistory.Visible = True
            grpInventorySearch.Enabled = False
            Call LoadOffice(cmbInventoryHitoryOffice)

            indicator = True
            Me.dtpInventoryHistoryStartDate.Value = Me.dtpInventoryHistoryStartDate.Value.AddMonths(-1)
            Me.dtpInventoryHistoryStartDate.MaxDate = Me.dtpInventoryHistoryEndDate.Value
            Me.dtpInventoryHistoryEndDate.MinDate = Me.dtpInventoryHistoryStartDate.Value
        ElseIf (printType = "e-Stock Card" Or printType = "Stock Receiving Entries History" Or printType = "Stock Transfer History" _
            Or printType = "Stock Adjustment History" Or printType = "Stock Extraction History" _
            Or printType = "Stock Return to Supplier History" Or printType = "Stock Invoice Return History" _
            Or printType = "Patient Charges History" Or printType = "Employee Charges History" _
            Or printType = "Expense Issuance History" Or printType = "Dead Stocks" _
            Or printType = "Reorder Stocks" Or printType = "Slow Moving Stocks" _
            Or printType = "Stock Expiry List" Or printType = "Stock Below Minimum Level List" _
            Or printType = "Inventory Status Report" Or printType = "Monthly Stock Inventory" _
            Or printType = "Issuance History" Or printType = "Summary of Items Issued as Expense" _
            Or printType = "Summary of Items Received as Expense" Or printType = "Item Inventory Status By Office") And indicator = True Then
            grpInventoryHistory.Visible = True

        End If



        If printType = "CROSSMATCHING" Then
            Me.grpLaboratory.Visible = True
            varStart = FormatDateTime(Me.dtFromlaboratory.Value, DateFormat.ShortDate) & " " & Me.dtStartlaboratory.Text
            varEnd = FormatDateTime(Me.dtToLaboratory.Value, DateFormat.ShortDate) & " " & Me.dtEndLaboratory.Text
            Dim rpt As New CrossmatchingDetailsRPT2
            da = New SqlDataAdapter("Exec spPrinting 0,10,0,'" & varStart & "','" & varEnd & "'  ", conn)
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
            Me.Text = "Crossmatching Report"
        ElseIf printType = "NEW BORN SCREENING" Then
            Me.grpLaboratory.Visible = True
            varStart = FormatDateTime(Me.dtFromlaboratory.Value, DateFormat.ShortDate) & " " & Me.dtStartlaboratory.Text
            varEnd = FormatDateTime(Me.dtToLaboratory.Value, DateFormat.ShortDate) & " " & Me.dtEndLaboratory.Text
            Dim rpt As New nbsDetailsRPT2
            da = New SqlDataAdapter("Exec spPrinting 0,11,0,'" & varStart & "','" & varEnd & "'  ", conn)
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
            Me.Text = "New Born Screening Report"
        ElseIf printType = "Fecalysis" Then
            Me.grpLaboratory.Visible = True
            varStart = FormatDateTime(Me.dtFromlaboratory.Value, DateFormat.ShortDate) & " " & Me.dtStartlaboratory.Text
            varEnd = FormatDateTime(Me.dtToLaboratory.Value, DateFormat.ShortDate) & " " & Me.dtEndLaboratory.Text
            Dim rpt As New FecalysisRPT
            da = New SqlDataAdapter("Exec spPrinting 0,3,0,'" & varStart & "','" & varEnd & "'  ", conn) ','" & varStart & "','" & varEnd & "' 
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
        ElseIf printType = "Urinalysis" Then
            Me.grpLaboratory.Visible = True
            varStart = FormatDateTime(Me.dtFromlaboratory.Value, DateFormat.ShortDate) & " " & Me.dtStartlaboratory.Text
            varEnd = FormatDateTime(Me.dtToLaboratory.Value, DateFormat.ShortDate) & " " & Me.dtEndLaboratory.Text
            Dim rpt As New UrinalysisRPT
            da = New SqlDataAdapter("Exec spPrinting 0,4,0,'" & varStart & "','" & varEnd & "'  ", conn) ','" & varStart & "','" & varEnd & "' 
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
        ElseIf printType = "Hematology" Then
            Me.grpLaboratory.Visible = True
            varStart = FormatDateTime(Me.dtFromlaboratory.Value, DateFormat.ShortDate) & " " & Me.dtStartlaboratory.Text
            varEnd = FormatDateTime(Me.dtToLaboratory.Value, DateFormat.ShortDate) & " " & Me.dtEndLaboratory.Text
            Dim rpt As New HematologyRPT
            da = New SqlDataAdapter("Exec spPrinting 0,5,0,'" & varStart & "','" & varEnd & "'  ", conn) ','" & varStart & "','" & varEnd & "' 
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
        ElseIf printType = "Blood Chemistry" Then
            Me.grpLaboratory.Visible = True
            varStart = FormatDateTime(Me.dtFromlaboratory.Value, DateFormat.ShortDate) & " " & Me.dtStartlaboratory.Text
            varEnd = FormatDateTime(Me.dtToLaboratory.Value, DateFormat.ShortDate) & " " & Me.dtEndLaboratory.Text
            Dim rpt As New BloodChemistryRPT
            da = New SqlDataAdapter("Exec spPrinting 0,6,0,'" & varStart & "','" & varEnd & "'  ", conn) ','" & varStart & "','" & varEnd & "' 
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
        ElseIf printType = "Radiology Department" Then
            Me.grpRadiology.Visible = True
            varStart = FormatDateTime(Me.dtfromradiology.Value, DateFormat.ShortDate) & " " & Me.dtStarttimeradiology.Text
            varEnd = FormatDateTime(Me.dtToRadiology.Value, DateFormat.ShortDate) & " " & Me.dtEndtimeRadiology.Text
            Dim rpt As New RadiologyRPT
            da = New SqlDataAdapter("Exec spPrinting 0,7,0,'" & varStart & "','" & varEnd & "'  ", conn) ','" & varStart & "','" & varEnd & "' 
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
        ElseIf printType = "Ultrasound Department" Then
            varStart = FormatDateTime(Me.dtfromradiology.Value, DateFormat.ShortDate) & " " & Me.dtStarttimeradiology.Text
            varEnd = FormatDateTime(Me.dtToRadiology.Value, DateFormat.ShortDate) & " " & Me.dtEndtimeRadiology.Text
            Me.grpRadiology.Visible = True
            Dim rpt As New UltraSoundRPT
            da = New SqlDataAdapter("Exec spPrinting 0,8,0,'" & varStart & "','" & varEnd & "'  ", conn) ','" & varStart & "','" & varEnd & "' 
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
        ElseIf printType = "Typhidot" Then
            Me.grpLaboratory.Visible = True
            varStart = FormatDateTime(Me.dtFromlaboratory.Value, DateFormat.ShortDate) & " " & Me.dtStartlaboratory.Text
            varEnd = FormatDateTime(Me.dtToLaboratory.Value, DateFormat.ShortDate) & " " & Me.dtEndLaboratory.Text
            Dim rpt As New crptTyphidotMisc
            da = New SqlDataAdapter("Exec spPrinting 0,13,'" & printType & "','" & varStart & "','" & varEnd & "'  ", conn) ','" & varStart & "','" & varEnd & "' 
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
        ElseIf printType = "H. Pylori" Or printType = "Pregnancy Test" Or printType = "Troponin" _
            Or printType = "ASO" Or printType = "Occult Blood" Or printType = "HBSAG" Or printType = "ANTI-HAV" Then
            Me.grpLaboratory.Visible = True
            varStart = FormatDateTime(Me.dtFromlaboratory.Value, DateFormat.ShortDate) & " " & Me.dtStartlaboratory.Text
            varEnd = FormatDateTime(Me.dtToLaboratory.Value, DateFormat.ShortDate) & " " & Me.dtEndLaboratory.Text
            Dim rpt As New crptMisc
            da = New SqlDataAdapter("Exec spPrinting 0,12,'" & printType & "','" & varStart & "','" & varEnd & "'  ", conn) ','" & varStart & "','" & varEnd & "' 
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
        ElseIf printType = "Remaining Films" Then
            Me.grpRadiology.Visible = True
            varStart = FormatDateTime(Me.dtfromradiology.Value, DateFormat.ShortDate) & " " & Me.dtStarttimeradiology.Text
            varEnd = FormatDateTime(Me.dtToRadiology.Value, DateFormat.ShortDate) & " " & Me.dtEndtimeRadiology.Text
            Dim rpt As New crptDepartmentOfDiagnosticImaging
            da = New SqlDataAdapter("Exec spPrinting 0,14,0,'" & varStart & "','" & varEnd & "'  ", conn) ','" & varStart & "','" & varEnd & "' 
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt

        ElseIf printType = "ECG REPORT MAIN" Then
            Dim rpt As New ECGRPT
            da = New SqlDataAdapter("Exec spPrinting 0,0,'" & varno & "','','','','','','','','','" & varstr & "'  ", conn)
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
            Me.Text = "ECG Report"
        ElseIf printType = "NEW BORN SCREENING MAIN" Then
            Dim rpt As New nbsRPT
            da = New SqlDataAdapter("Exec spPrinting 0,1,'" & varno & "','','','','','','','','','" & varstr & "' ", conn)
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
            Me.Text = "New Born Screening Report"
        ElseIf printType = "CROSSMATCHING MAIN" Then
            Dim rpt As New crptCrossmatching
            da = New SqlDataAdapter("Exec spPrinting 0,2,'" & varno & "','','','','','','','','','" & varstr & "' ", conn)
            da.SelectCommand.CommandTimeout = 1000 : da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
            resultrpt = rpt
            Me.Text = "Crossmatching"

        End If

        If printType = "CF1" Or printType = "CF2" Or printType = "CF21" Or printType = "CF22" Then
            Call SaveLog(printType, "Print: " & printType & " document admission " & varno & " .", modGlobal.userid)
        Else
            Call SaveLog(printType, "Print: " & printType & " document.", modGlobal.userid)
        End If
        'objDB.CloseDestroyConnection()
        'objDB = Nothing
        If isAutoPrint Then
            crptViewer.PrintReport()
            Me.Close()
        End If

        Me.tsModule.Text = Me.Text
        Me.crptViewer.ShowLastPage()
        PageCount = Me.crptViewer.GetCurrentPageNumber()
        Me.crptViewer.ShowFirstPage()
        If PageCount = 1 Then
            Me.tsNext.Enabled = False
            Me.tsLastPage.Enabled = False
        Else
            Me.tsNext.Enabled = True
            Me.tsLastPage.Enabled = True
        End If
        gconn.CloseDestroyConnection()
    End Sub

    Private Sub useForTax(ByVal sw As Boolean)
        Me.cmbInvoiceSummary.Visible = sw
        Me.cmbinvoicesummaryyear.Visible = sw
        Me.lblinvociesummaryyear.Visible = sw
        Me.lblInvoicesummarymonth.Visible = sw

        Me.Label30.Visible = Not Me.cmbInvoiceSummary.Visible
        Me.Label18.Visible = Not Me.cmbInvoiceSummary.Visible
        Me.Label17.Visible = Not Me.cmbInvoiceSummary.Visible
        Me.cmbPeriod.Visible = Not Me.cmbInvoiceSummary.Visible
        Me.Datefrom.Visible = Not Me.cmbInvoiceSummary.Visible
        Me.Dateto.Visible = Not Me.cmbInvoiceSummary.Visible
        Me.cmbPeriod.Visible = Not Me.cmbInvoiceSummary.Visible
    End Sub

    Private Sub LoadPeriod(ByRef cmbPeriod As ComboBox, Optional ByVal isCashtrans As Boolean = False)
        Me.dtpStartTimeCR.Value = "1/1/1900 12:00:00 AM"
        Me.dtpEndTimeCR.Value = "1/1/1900 11:59:59 PM"
        Me.dtAccountPayabaleTradeDate.Value = GetServerDate()
        If printType = "Suppliers Aged Payable" Or _
            printType = "Suppliers Cash Disbursement Journal" Or _
            printType = "Suppliers Cash Requirements/Account Payables" Or _
             printType = "Suppliers Check Register" Or _
             printType = "Suppliers Items Purchased From Vendors" Or _
             printType = "Suppliers Purchase Order Register" Or _
              printType = "Suppliers Purchase Order" Or _
               printType = "Purchase Tax Reports" Or _
                printType = "Supplier Ledgers/Transaction History" Or _
                 printType = "Suppliers List" Then
            LoadOffice(Me.tscombobranch)
            'cmbPeriod.
            With cmbPeriod
                .DataSource = Nothing
                .Items.Add(New DictionaryEntry("Today", 0))
                .Items.Add(New DictionaryEntry("This Week-to-Date", 1))
                If isCashtrans = False Then
                    .Items.Add(New DictionaryEntry("This Month-to-Date", 2))
                    .Items.Add(New DictionaryEntry("This Quarter-to-Date", 3))
                    .Items.Add(New DictionaryEntry("This Year-to-Date", 4))
                End If
                .Items.Add(New DictionaryEntry("Custom Date", 5))
                .DisplayMember = "Key"
                .ValueMember = "Value"
                .DataSource = .Items
                If isCashtrans = False Then
                    .SelectedIndex = 5
                Else
                    .SelectedIndex = 0
                End If
            End With


            Me.cmbDateType.Enabled = False
            Me.dtFromFinancial.Enabled = False
            Me.dtToFinancial.Enabled = False
            Me.dtStartTimeFinancial.Enabled = False
            Me.dtEndTimeFinancial.Enabled = False
        End If



        If printType = "Suppliers Aged Payable" Or _
            printType = "Suppliers Cash Requirements/Account Payables" Then
            Me.lblieforAgedPayable.Visible = True
            Me.cmbPeriod.Visible = False
            Me.Datefrom.Visible = False
            Me.Label18.Visible = False
            Me.Label30.Visible = False
            Me.Label17.Text = "As of"
            Me.Dateto.Location = New Point(59, 34)
            Me.Label17.Location = New Point(4, 37)
        ElseIf printType = "Suppliers Cash Disbursement Journal" Or _
             printType = "Suppliers Check Register" Or _
            printType = "Suppliers Items Purchased From Vendors" Or _
            printType = "Suppliers Purchase Order Register" Or _
             printType = "Suppliers Purchase Order" Or _
              printType = "Purchase Tax Reports" Or _
                printType = "Supplier Ledgers/Transaction History" Then
            Me.cmbPeriod.Visible = True
            Me.Datefrom.Visible = True
            Me.Label18.Visible = True
            Me.Label30.Visible = True

            Dim year As Integer = GetServerDate().Year()
            With Me.cmbInvoiceSummary
                For ctr = 0 To 12 - 1
                    Dim dt As Date = ctr + 1 & "/1/" & year
                    .Items.Add(New DictionaryEntry(dt.ToString("MMM"), ctr + 1))
                Next
                .Items.Add(New DictionaryEntry("Per Year...", 13))
                .DisplayMember = "Key"
                .ValueMember = "Value"
                .DataSource = .Items
                .SelectedValue = GetServerDate().Month
            End With

            With Me.cmbinvoicesummaryyear
                Dim inc As Integer = 0
                Dim ctrx As Integer = 1930
                For ctrx = 1930 To year
                    .Items.Add(New DictionaryEntry(year - inc, year - inc))
                    inc += 1
                Next
                .DisplayMember = "Key"
                .ValueMember = "Value"
                .DataSource = .Items
                .SelectedValue = year
            End With



        ElseIf printType = "Suppliers List" Then
            Me.TextBox1.Enabled = True


            Me.lblieforAgedPayable.Enabled = False
            Me.cmbPeriod.Enabled = False
            Me.Datefrom.Enabled = False
            Me.Label18.Enabled = False
            Me.Label30.Enabled = False
            Me.Label17.Enabled = False
            Me.Dateto.Enabled = False
            Me.tsSupplier.Enabled = False
            Me.tscombobranch.Enabled = False
            Me.chkincludeoverdueinvoiceonly.Enabled = False


            Me.cmbDateType.Enabled = False
            Me.dtFromFinancial.Enabled = False
            Me.dtToFinancial.Enabled = False
            Me.dtStartTimeFinancial.Enabled = False
            Me.dtEndTimeFinancial.Enabled = False
        Else
            Me.lblieforAgedPayable.Enabled = False
            Me.cmbPeriod.Enabled = False
            Me.Datefrom.Enabled = False
            Me.Label18.Enabled = False
            Me.Label30.Enabled = False
            Me.Label17.Enabled = False
            Me.Dateto.Enabled = False
            Me.TextBox1.Enabled = False
            Me.tsSupplier.Enabled = False
            Me.tscombobranch.Enabled = False
            Me.chkincludeoverdueinvoiceonly.Enabled = False


            Me.cmbDateType.Enabled = True
            Me.dtFromFinancial.Enabled = True
            Me.dtToFinancial.Enabled = True
            Me.dtStartTimeFinancial.Enabled = True
            Me.dtEndTimeFinancial.Enabled = True
        End If

        If printType = "Admission and Discharge Report" Or printType = "Daily Census" Then
            If afterInit = False Then
                Call datetype()
                Call loadrange()
            End If
        End If

    End Sub
    Private Sub getPeriodDateRange(ByVal cmbPeriod As ComboBox, _
                                         ByRef dateFrom As Date, _
                                         ByRef dateTo As Date, _
                                         Optional ByVal dtpTransFrom As Object = Nothing, _
                                         Optional ByVal dtpTransTo As Object = Nothing, _
                                         Optional ByVal label1 As Object = Nothing, _
                                         Optional ByVal label2 As Object = Nothing)
        Dim daydiff As Integer
        Dim quarter As Integer
        dateFrom = FormatDateTime(Utility.GetServerDate(), DateFormat.ShortDate) & " " & "12:00:00 AM"
        dateTo = FormatDateTime(Utility.GetServerDate(), DateFormat.ShortDate) & " " & "11:59:59 PM"
        SetVisibleDate(label1, label2, dtpTransFrom, dtpTransTo)
        Select Case cmbPeriod.SelectedValue
            Case 1 ' this week
                daydiff = -1 * dateTo.DayOfWeek
                dateFrom = dateTo.AddDays(daydiff)
            Case 2 'this month
                dateFrom = Month(dateTo) & "/1/" & Year(dateTo)
            Case 3 'this quarter to date
                If dateTo.Month = 12 Then
                    quarter = 10
                Else
                    'quarter = ((dateTo.Month \ 3) * 3) + 1
                    Select Case dateTo.Month
                        Case 1, 2, 3
                            quarter = 1
                        Case 4, 5, 6
                            quarter = 4
                        Case 7, 8, 9
                            quarter = 7
                        Case 10, 11, 12
                            quarter = 10
                    End Select
                End If
                dateFrom = quarter & "/1/" & Year(dateTo)
                dateTo = System.DateTime.Now
            Case 4
                dateFrom = "1/1/" & Year(dateTo)
            Case 5
                Dim aDay As DateTime = DateTime.Now
                With cmbPeriod
                    If .SelectedValue = 5 Then
                        SetVisibleDate(label1, label2, dtpTransFrom, dtpTransTo, True)
                        Dim aMonth As TimeSpan = New System.TimeSpan(30, 0, 0, 0)
                        Dim aDayBeforeAMonth As DateTime = aDay.Subtract(aMonth)
                        dtpTransFrom.Value = aDayBeforeAMonth
                    Else
                        SetVisibleDate(label1, label2, dtpTransFrom, dtpTransTo)
                    End If
                End With
                dateFrom = FormatDateTime(dtpTransFrom.Value, DateFormat.ShortDate) & " " & "12:00:00 AM"
                dateTo = FormatDateTime(dtpTransTo.Value, DateFormat.ShortDate) & " " & "11:59:59 PM"
        End Select
    End Sub
    Public Shared Sub SetVisibleDate(ByVal Label5 As Object, _
        ByVal Label4 As Object, _
        ByVal Datefrom As Object, _
        ByVal DateTo As Object, _
        Optional ByVal sw As Boolean = False)

        Label5.Visible = sw
        Label4.Visible = sw
        Datefrom.Visible = sw
        DateTo.Visible = sw
    End Sub
    Private Sub isnotvisible()
        Me.grpbxCashierReports.Visible = 0
        Me.grpDOH.Visible = 0
        Me.grpLaboratory.Visible = 0
        Me.grpMedicalRecords.Visible = 0
        Me.grpRadiology.Visible = 0
        Me.grpFinancialReport.Visible = 0
        Me.grpPharmacy.Visible = 0
        Me.grpInventoryHistory.Visible = 0
        Me.cmbInvoiceSummary.Visible = 0
        Me.grpAccountPayableTrade.Visible = 0
    End Sub

    Private Sub action(ByVal name As String)
        Select Case name
            Case "tsSearch"
                Me.crptViewer.SearchForText(Me.tsSearchtext.Text)
            Case "tsZoom"
                Select Case Me.tsZoom.ComboBox.SelectedValue
                    Case 3
                        Dim frm As New frmZoom()
                        frm.ShowDialog()
                        If frm.isOk Then
                            Me.crptViewer.Zoom(frm.MaskedTextBox1.Text)
                        End If
                    Case Else
                        Me.crptViewer.Zoom(Me.tsZoom.ComboBox.SelectedValue)
                End Select
            Case "btnSearch"
                loadPatientRecord(printType, True)
            Case "btnSearchForms"
                loadPatientRecordForms(printType, True)
            Case "crptDOHPage1", _
                "crptDOHPage2", _
                "crptDOHPage3", _
                "crptDOHPage4", _
                "crptDOHPage5", _
                "crptDOHPage6", _
                "crptDOHPage7", _
                "crptDOHPage8", _
                "crptDOHPage9", _
                "crptDOHPage10"
                printType = name
                LoadReport()
            Case "tsPrint"
                Select Case printType
                    Case "crptDOHPage1", _
                            "crptDOHPage2", _
                            "crptDOHPage3", _
                            "crptDOHPage4", _
                            "crptDOHPage5", _
                            "crptDOHPage6", _
                            "crptDOHPage7", _
                            "crptDOHPage8", _
                            "crptDOHPage9", _
                            "crptDOHPage10"
                        If MessageBox.Show("Do you want to print all remaining pages?", modGlobal.msgboxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Me.crptViewer.PrintReport()
                            Dim str As Integer = CInt(Replace(printType, "crptDOHPage", ""))
                            For ctr = CInt(str) To 10 - 1
                                Dim inc = ctr + 1
                                printType = CStr("crptDOHPage" & inc)
                                LoadReport()
                                Me.crptViewer.PrintReport()
                            Next
                        Else
                            Me.crptViewer.PrintReport()
                        End If
                    Case Else
                        If printType = "CH" Or printType = "CASH" Or _
                            printType = "Charge Invoice" Or printType = "Charge Invoice Pre Printed" Or _
                            printType = "Employee Charge Invoice" Or printType = "Employee Charge Invoice Pre Printed" Then
                            LoadReport(True)
                        Else
                            Me.crptViewer.PrintReport()
                        End If
                End Select
            Case "tsRefresh", "tsModule"
                LoadReport()
                If FormatDateTime(varStart, DateFormat.ShortDate) < FormatDateTime(Utility.GetServerDate(), DateFormat.ShortDate) Then
                    Dim cmd As New SqlCommand("exec spinventorydump " & varoffice)

                    Dim conn As New clsDBConnection
                    conn.CreateOpenConnection()
                    cmd.Connection = conn.GDBConn 
                    cmd.CommandTimeout = 1000
                    cmd.ExecuteNonQuery()

                    cmd.Dispose()
                End If
            Case "tsNext"
                Me.crptViewer.ShowNextPage()
                If PageCount = Me.crptViewer.GetCurrentPageNumber() Then
                    Me.tsNext.Enabled = False
                    Me.tsLastPage.Enabled = False
                Else
                    Me.tsNext.Enabled = True
                    Me.tsLastPage.Enabled = True
                End If
                Me.tsPrev.Enabled = True
                Me.tsFirstPage.Enabled = True
            Case "tsPrev"
                Me.crptViewer.ShowPreviousPage()
                If Me.crptViewer.GetCurrentPageNumber() = 1 Then
                    Me.tsPrev.Enabled = False
                    Me.tsFirstPage.Enabled = False
                Else
                    Me.tsPrev.Enabled = True
                    Me.tsFirstPage.Enabled = False
                End If
                Me.tsNext.Enabled = True
                Me.tsLastPage.Enabled = True
            Case "tsLastPage"
                Me.crptViewer.ShowLastPage()
                Me.tsLastPage.Enabled = False
                Me.tsNext.Enabled = False
                Me.tsPrev.Enabled = True
                Me.tsFirstPage.Enabled = True
            Case "tsFirstPage"
                Me.crptViewer.ShowFirstPage()
                Me.tsFirstPage.Enabled = False
                Me.tsNext.Enabled = True
                Me.tsPrev.Enabled = False
                Me.tsLastPage.Enabled = True
            Case "tsExportToExcel"
                export(resultrpt, ".xls", False, True)
            Case "tsExportToPDF"
                export(resultrpt, ".pdf", False)
            Case "tsEmail"
                export(resultrpt, ".pdf", True)
            Case "tsClose"
                Me.Close()
        End Select
    End Sub
    Private Sub export(ByVal report As Object, ByVal formattype As String, ByVal isEmail As Boolean, Optional ByVal isExcel As Boolean = False)
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.FileName = printType & " " & Utility.GetServerDate.ToString("MM-dd-yy")
        If formattype = ".pdf" And isEmail = False Then
            saveFileDialog1.Filter = "Portable Document Format (*.pdf)|*.pdf"
        ElseIf formattype = ".pdf" And isEmail Then
            saveFileDialog1.Filter = "Portable Document Format (*.pdf)|*.pdf|Excel Worksheets (*.xls)|*.xls"
        ElseIf formattype = ".xls" And isEmail = False Then
            saveFileDialog1.Filter = "Excel Worksheets (*.xls)|*.xls"
        End If
        saveFileDialog1.FilterIndex = 1
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            File.Delete(saveFileDialog1.FileName)
        Else
            Exit Sub
        End If
        If System.IO.File.Exists(saveFileDialog1.FileName) = False Then
            Try : CrDiskFileDestinationOptions.DiskFileName = saveFileDialog1.FileName 'formattype
                CrExportOptions = report.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    If isExcel Then
                        .ExportFormatType = ExportFormatType.Excel
                        .FormatOptions = ExportOptions.CreateExcelFormatOptions()
                    Else
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .FormatOptions = CrFormatTypeOptions
                    End If
                    .DestinationOptions = CrDiskFileDestinationOptions
                End With : report.Export()
                If Not isEmail Then
                    MsgBox("Export successfully done.", MsgBoxStyle.Information, modGlobal.msgboxTitle)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            If Not isEmail Then
                Try
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName)
                Catch ex As Exception

                End Try
            End If
        Else
            If Not isEmail Then
                Try
                    System.Diagnostics.Process.Start(saveFileDialog1.FileName)
                Catch ex As Exception

                End Try
            End If
        End If
        If isEmail Then
            Dim frm As New frmMailAccount(frmMailAccount.enFormStatus.add, saveFileDialog1.FileName, printType)
            frm.ShowDialog()
            frm = Nothing
        End If
    End Sub
    Private Sub loadQuarter(Optional ByVal isViewButton As Boolean = False)
        If Me.cmbMonthDOH.Items.Count = 0 Then
            Me.cmbMonthDOH.Items.Add(New DictionaryEntry("First Quarter", 1))
            Me.cmbMonthDOH.Items.Add(New DictionaryEntry("Second Quarter", 2))
            Me.cmbMonthDOH.Items.Add(New DictionaryEntry("Third Quarter", 3))
            Me.cmbMonthDOH.Items.Add(New DictionaryEntry("Fourth Quarter", 4))
            Me.cmbMonthDOH.Items.Add(New DictionaryEntry("Yearly", 5))
            Me.cmbMonthDOH.DisplayMember = "Key"
            Me.cmbMonthDOH.ValueMember = "Value"
            Me.cmbMonthDOH.DataSource = Me.cmbMonthDOH.Items
            Me.cmbMonthDOH.SelectedIndex = 0
        End If
        Me.cmbMonthDOH.Enabled = True
        Me.dtPyearDOH.Enabled = True
        Me.crptDOHPage1.Enabled = isViewButton
        Me.crptDOHPage2.Enabled = isViewButton
        Me.crptDOHPage3.Enabled = isViewButton
        Me.crptDOHPage4.Enabled = isViewButton
        Me.crptDOHPage5.Enabled = isViewButton
        Me.crptDOHPage6.Enabled = isViewButton
        Me.crptDOHPage7.Enabled = isViewButton
        Me.crptDOHPage8.Enabled = isViewButton
        Me.crptDOHPage9.Enabled = isViewButton
        Me.crptDOHPage10.Enabled = isViewButton
    End Sub
    'Private Sub loadICD10(Optional ByVal isEnabled As Boolean = False)
    '    If Me.cmICD10CodeDOH.Items.Count = 0 Then
    '        Dim dt As DataTable = clsDiagnosis.getDiagnosisClass()
    '        Me.cmICD10CodeDOH.DataSource = clsDiagnosis.getDiagnosisClass()
    '        Me.cmICD10CodeDOH.ValueMember = "diagnosisclasscode"
    '        Me.cmICD10CodeDOH.DisplayMember = "classification"
    '        Me.cmICD10CodeDOH.SelectedIndex = 0
    '    End If
    '    Me.dtpDateFromDOH.Enabled = True
    '    Me.dtpDateToDOH.Enabled = True
    '    Me.dtpStartTimeDOH.Enabled = True
    '    Me.dtpEndTimeDOH.Enabled = True
    '    Me.cmICD10CodeDOH.Enabled = isEnabled
    'End Sub
    'Public Sub LoadOffice(ByVal cmb As ComboBox)
    '       If Me.cmbOffice.Items.Count = 0 Then
    '   Dim dtOffices As New DataTable
    '   Dim ctr As Integer

    '           Me.tscombobranch.DataSource = Nothing
    '           Me.tscombobranch.Items.Add(New DictionaryEntry("[ALL]", 0))


    '           If isAdmin Then
    '               If printType = "e-Stock Card" Or printType = "Stock Receiving Entries History" _
    '                   Or printType = "Stock Transfer History" Or printType = "Stock Adjustment History" _
    '                   Or printType = "Stock Extraction History" Or printType = "Stock Return to Supplier History" _
    '                   Or printType = "Stock Invoice Return History" Or printType = "Patient Charges History" _
    '                   Or printType = "Employee Charges History" Or printType = "Expense Issuance History" Then
    '               Else
    '                   cmb.Items.Add(New DictionaryEntry("CASHIER and CSR", "CAR"))
    '               End If


    '               dtOffices = clsOffices.getOffices("", 1)
    '               ctr = 0
    '               Do While ctr < dtOffices.Rows.Count
    '                   cmb.Items.Add(New DictionaryEntry(dtOffices.Rows(ctr).Item("officedescription"), _
    '                                                              dtOffices.Rows(ctr).Item("officecode")))
    '   'tscombobranch.Items.Add(New DictionaryEntry(dtOffices.Rows(ctr).Item("officedescription"), _
    '   '                                           dtOffices.Rows(ctr).Item("officecode")))
    '                   ctr += 1
    '               Loop
    '           Else
    '               cmb.Items.Add(New DictionaryEntry(sourceOfficeDesc, sourceOfficeCode))
    '               If sourceOfficeCode = "106" Then
    '                   cmb.Items.Add(New DictionaryEntry("CASHIER and CSR", "CAR"))
    '                   cmb.Items.Add(New DictionaryEntry("CSR", "103"))
    '               End If
    '           End If
    '           cmb.DisplayMember = "Key"
    '           cmb.ValueMember = "Value"
    '           cmb.DataSource = cmb.Items
    '           cmb.SelectedValue = modGlobal.sourceOfficeCode


    '   'Me.tscombobranch.DisplayMember = "Key"
    '   'Me.tscombobranch.ValueMember = "Value"
    '   'Me.tscombobranch.DataSource = tscombobranch.Items
    '   'Me.tscombobranch.SelectedValue = modGlobal.sourceOfficeCode

    '   Dim dtSuppliers As DataTable
    '   Dim ctrx As Integer = 0
    '           tsSupplier.DataSource = Nothing
    '           If printType = "Purchase Tax Reports" Or printType = "Purchase Tax Reports { Invoice Summary }" Or printType = "Purchase Tax Reports { Invoice Details }" Then
    '               Me.chkincludeoverdueinvoiceonly.Visible = False
    '               Me.chkshowDetails.Visible = True
    '               With Me.tsSupplier
    '                   Me.chkshowDetails.Visible = True
    '                   .DataSource = Nothing
    '                   If Not ischecked Then
    '                       .Items.Add(New DictionaryEntry("", 1))
    '                       .DisplayMember = "Key"
    '                       .ValueMember = "Value"
    '                       .DataSource = .Items
    '                       Me.tsSupplier.Enabled = False
    '                   Else
    '                       Me.tsSupplier.Enabled = True
    '                       .Items.Add(New DictionaryEntry("Invoice Summary", 2))
    '                       .Items.Add(New DictionaryEntry("Invoice Details", 3))
    '                       .DisplayMember = "Key"
    '                       .ValueMember = "Value"
    '                       .DataSource = .Items
    '                       .SelectedIndex = 0
    '                   End If

    '               End With
    '               Me.Label32.Text = "Details"



    '           Else
    '               Me.tsSupplier.Items.Add(New DictionaryEntry("[ALL]", 0))
    '               dtSuppliers = clsInventoryReports.getAllSuppliers("1")

    '               Do While ctrx < dtSuppliers.Rows.Count
    '                   Me.tsSupplier.Items.Add(New DictionaryEntry(dtSuppliers.Rows(ctrx).Item("suppliername"), _
    '                                                              dtSuppliers.Rows(ctrx).Item("supplierno")))
    '                   ctrx += 1
    '               Loop

    '               With tsSupplier
    '                   .DisplayMember = "Key"
    '                   .ValueMember = "Value"
    '                   .DataSource = .Items
    '                   .SelectedValue = 0
    '               End With
    '           End If


    '       End If

    '   End Sub
    'Private Sub loadPatientRecord(ByVal swtch As String, Optional ByVal issearch As Boolean = False)
    '    Select Case swtch
    '        Case "Clinical Case Records", _
    '            "Patient's Index", _
    '            "Charges List", _
    '            "Clinical Abstract/Discharged Summary"
    '            Me.dgGenericList.Enabled = True
    '            Me.btnSearch.Enabled = True
    '            Me.txtSearch.Enabled = True
    '            If Me.dgGenericList.Rows.Count = 0 Or issearch Then
    '                With dgGenericList
    '                    .DataSource = clsPatient.getAdmissions(Me.txtSearch.Text)
    '                    .Columns(0).Visible = False
    '                    .Columns(0).HeaderText = "AdmissionID"
    '                    .Columns(1).Width = 35
    '                    .Columns(1).HeaderText = "PTNo"
    '                    .Columns(2).Visible = False
    '                    .Columns(2).HeaderText = "Hospital No"
    '                    .Columns(3).Width = 150
    '                    .Columns(3).HeaderText = "Patient"
    '                    .Columns(4).Width = 120
    '                    .Columns(4).HeaderText = "Admitted"
    '                    .Columns(5).Width = 120
    '                    .Columns(5).HeaderText = "Discharged"
    '                    .Columns(6).Visible = False
    '                    .Columns(7).Visible = False
    '                    .Columns(8).Visible = False
    '                End With
    '            End If
    '        Case "Birth Certificate", _
    '             "Medical Certificate"
    '            Me.dgGenericList.Visible = False
    '            Me.btnSearch.Enabled = True
    '            Me.txtSearch.Enabled = True
    '            Dim frm As New frmSearchEngine
    '            With frm
    '                If swtch = "Birth Certificate" Then
    '                    .mModuleName = "Birth Certificate"
    '                ElseIf swtch = "Medical Certificate" Then
    '                    .mModuleName = "Medical Certificate"
    '                    txtpurpose.Visible = True
    '                    dtToMedicalRecords.Enabled = True
    '                    Label10.Enabled = True
    '                    Label8.Enabled = True
    '                    Label8.Text = "Purpose"
    '                    Label10.Text = "Issued Date"
    '                End If
    '                .ShowDialog()
    '                If .issave Then
    '                    Me.txtSearch.Text = .mLastName
    '                    varno = .mKey
    '                Else
    '                    Me.txtSearch.Text = ""
    '                    varno = 0
    '                End If
    '                afterInit = True
    '                LoadReport()
    '            End With
    '            'Case "Birth Certificate"
    '            '    Me.dgGenericList.Enabled = True
    '            '    Me.btnSearch.Enabled = True
    '            '    Me.txtSearch.Enabled = True
    '            '    If Me.dgGenericList.Rows.Count = 0 Or issearch Then
    '            '        With Me.dgGenericList
    '            '            .DataSource = clsCertification.getAllNewBornBabies(Me.txtSearch.Text, 2)
    '            '            .Columns(0).Visible = False
    '            '            .Columns(1).Visible = False
    '            '            .Columns(2).Width = 60
    '            '            .Columns(2).HeaderText = "HospNo."
    '            '            .Columns(2).DefaultCellStyle.Format = "##-##-##"
    '            '            .Columns(3).Width = 200
    '            '            .Columns(3).HeaderText = "Patient Name"
    '            '            .Columns(4).Visible = False
    '            '            .Columns(5).Visible = False
    '            '            .Columns(6).Visible = False
    '            '            .Columns(7).Width = 100
    '            '            .Columns(7).HeaderText = "is Released"
    '            '        End With
    '            '    End If
    '        Case "Death Certificate"
    '            Me.dgGenericList.Enabled = True
    '            Me.btnSearch.Enabled = True
    '            Me.txtSearch.Enabled = True
    '            If Me.dgGenericList.Rows.Count = 0 Or issearch Then
    '                With Me.dgGenericList
    '                    .DataSource = clsCertification.getAllDeadPatients(Me.txtSearch.Text, 2)
    '                    .Columns(0).Visible = False
    '                    .Columns(1).Visible = False
    '                    .Columns(2).Width = 60
    '                    .Columns(2).HeaderText = "HospNo."
    '                    .Columns(2).DefaultCellStyle.Format = "##-##-##"
    '                    .Columns(3).Width = 200
    '                    .Columns(3).HeaderText = "Patient Name"
    '                    .Columns(4).Visible = False
    '                    .Columns(5).Visible = False
    '                    .Columns(6).Visible = False
    '                    .Columns(7).Width = 100
    '                    .Columns(7).HeaderText = "is Released"
    '                End With
    '            End If
    '        Case "Disease Index"
    '            Me.dgGenericList.Enabled = True
    '            Me.btnSearch.Enabled = True
    '            Me.txtSearch.Enabled = True
    '            If Me.dgGenericList.Rows.Count = 0 Or issearch Then
    '                With Me.dgGenericList
    '                    .DataSource = clsCertification.generic(17, Me.txtSearch.Text)
    '                    .Columns(0).Width = 60
    '                    .Columns(0).HeaderText = "ICD Code"
    '                    .Columns(1).Width = 300
    '                    .Columns(1).HeaderText = "Diagnosis"
    '                End With
    '            End If
    '        Case "Employees' Account Receivable Details"
    '            Me.btnSearch.Enabled = True
    '            Me.txtSearch.Enabled = True
    '            If isLoad = False Then
    '                If Me.dgGenericList.Rows.Count = 0 Or issearch Then
    '                    With Me.dgGenericList
    '                        .DataSource = clsEmpCreditPayrollDeduction.clsgeneric(11, Me.txtSearch.Text)
    '                        .Columns(0).Visible = False
    '                        .Columns(1).Width = 92
    '                        .Columns(1).HeaderText = "Employee No"
    '                        .Columns(2).Width = 300
    '                        .Columns(2).HeaderText = "Employee Name"
    '                    End With
    '                End If
    '            Else
    '                Dim frm As New frmItemsSearchEngine
    '                With frm
    '                    .modName = "Employees' Account Receivable Details"
    '                    .ShowDialog()
    '                    If .isSave = True Then
    '                        varno = .EmpID
    '                        Me.txtSearch.Text = .EmpName
    '                        Call LoadReport()
    '                    End If
    '                End With
    '            End If
    '    End Select
    'End Sub
    'Private Sub loadPatientRecordForms(ByVal swtch As String, Optional ByVal issearch As Boolean = False)
    '    Select Case swtch
    '        Case "Informed Consent For Admission"
    '            If Me.dgGenericList2.Rows.Count = 0 Or issearch Then
    '                Me.dgGenericList2.DataSource = clsPatient.getAdmissions(Me.txtSearchForms.Text)
    '                With dgGenericList2
    '                    .Columns(0).Visible = False
    '                    .Columns(0).HeaderText = "AdmissionID"
    '                    .Columns(1).Width = 35
    '                    .Columns(1).HeaderText = "PTNo"
    '                    .Columns(2).Visible = False
    '                    .Columns(2).HeaderText = "Hospital No"
    '                    .Columns(3).Width = 150
    '                    .Columns(3).HeaderText = "Patient"
    '                    .Columns(4).Width = 120
    '                    .Columns(4).HeaderText = "Admitted"
    '                    .Columns(5).Width = 120
    '                    .Columns(5).HeaderText = "Discharged"
    '                    .Columns(6).Visible = False
    '                    .Columns(7).Visible = False
    '                    .Columns(8).Visible = False
    '                End With
    '            End If
    '        Case "Clearance/Discharge Slip"
    '            If Me.dgGenericList2.Rows.Count = 0 Or issearch Then
    '                Me.dgGenericList2.DataSource = clsPatient.getAdmissions(Me.txtSearchForms.Text)
    '                With dgGenericList2
    '                    .Columns(0).Visible = False
    '                    .Columns(0).HeaderText = "AdmissionID"
    '                    .Columns(1).Width = 35
    '                    .Columns(1).HeaderText = "PTNo"
    '                    .Columns(2).Visible = False
    '                    .Columns(2).HeaderText = "Hospital No"
    '                    .Columns(3).Width = 150
    '                    .Columns(3).HeaderText = "Patient"
    '                    .Columns(4).Width = 120
    '                    .Columns(4).HeaderText = "Admitted"
    '                    .Columns(5).Width = 120
    '                    .Columns(5).HeaderText = "Discharged"
    '                    .Columns(6).Visible = False
    '                    .Columns(7).Visible = False
    '                    .Columns(8).Visible = False
    '                End With
    '            End If
    '    End Select
    'End Sub
    Private Sub loadmonthMedicalRecords(ByVal cmbMonth As ComboBox)
        If Me.cmbMonthMedicalRecords.Items.Count = 0 Then
            With cmbMonth
                .DataSource = Nothing
                .Items.Clear()
                .Items.Add(New DictionaryEntry("January", 1))
                .Items.Add(New DictionaryEntry("February", 2))
                .Items.Add(New DictionaryEntry("March", 3))
                .Items.Add(New DictionaryEntry("April", 4))
                .Items.Add(New DictionaryEntry("May", 5))
                .Items.Add(New DictionaryEntry("June", 6))
                .Items.Add(New DictionaryEntry("July", 7))
                .Items.Add(New DictionaryEntry("August", 8))
                .Items.Add(New DictionaryEntry("September", 9))
                .Items.Add(New DictionaryEntry("October", 10))
                .Items.Add(New DictionaryEntry("November", 11))
                .Items.Add(New DictionaryEntry("December", 12))
                .DisplayMember = "Key"
                .ValueMember = "Value"
                .DataSource = cmbMonth.Items
                .SelectedIndex = 0
            End With
        End If
    End Sub
    Private Sub LoadFilm()
        If Me.cmfilm.Items.Count = 0 Then
            Me.cmfilm.DataSource = clsLabRadiology.getItemCodeFilm()
            Me.cmfilm.DisplayMember = "ItemDescription"
            Me.cmfilm.ValueMember = "ItemCode"
        End If
    End Sub
    Private Sub loadZoom()
        Me.tsZoom.Items.Add(New DictionaryEntry("Page width", 1))
        Me.tsZoom.Items.Add(New DictionaryEntry("Whole Page", 2))
        Me.tsZoom.Items.Add(New DictionaryEntry("400 %", 400))
        Me.tsZoom.Items.Add(New DictionaryEntry("300 %", 300))
        Me.tsZoom.Items.Add(New DictionaryEntry("200 %", 200))
        Me.tsZoom.Items.Add(New DictionaryEntry("150 %", 150))
        Me.tsZoom.Items.Add(New DictionaryEntry("100 %", 100))
        Me.tsZoom.Items.Add(New DictionaryEntry("75 %", 75))
        Me.tsZoom.Items.Add(New DictionaryEntry("50 %", 50))
        Me.tsZoom.Items.Add(New DictionaryEntry("25 %", 25))
        Me.tsZoom.Items.Add(New DictionaryEntry("Customize...", 3))
        Me.tsZoom.ComboBox.DisplayMember = "Key"
        Me.tsZoom.ComboBox.ValueMember = "Value"
        Me.tsZoom.ComboBox.DataSource = Me.tsZoom.Items
        Me.tsZoom.ComboBox.SelectedValue = 100
    End Sub

#End Region


#Region "Inventory Dorms ~ Events & Methods here"


    Private Sub picSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picSearch.Click
        Dim ItemsSE As New frmItemsSearchEngine
        Dim strSearch As String
        Try
            ItemsSE.modName = "ReportViewItemHistory"
            ItemsSE.ShowDialog()

            If ItemsSE.isSave = True Then
                strSearch = ItemsSE.retailitemdescription
                varitemcode = ItemsSE.retailitemcode
                pnlItems.Text = ItemsSE.retailitemdescription

                If pnlItems.Text.Length = 0 Then
                    ItemsSE.strSearch = ""
                ElseIf pnlItems.Text.Length > 5 Then
                    ItemsSE.strSearch = strSearch.Substring(0, 5)
                Else
                    ItemsSE.strSearch = pnlItems.Text
                End If
            End If
        Catch
            strSearch = ""
            ItemsSE.itemcode = ""
        End Try

        If ItemsSE.isSave = True Then
            varitemcode = ItemsSE.retailitemcode
            pnlItems.Text = ItemsSE.retailitemdescription
            Call loadlotno()
        End If
    End Sub
    Private Sub pbItemSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbItemSearch.Click
        Dim ItemsSE As New frmItemsSearchEngine
        Dim strSearch As String
        Try
            ItemsSE.modName = "ReportViewItemHistory"
            ItemsSE.ShowDialog()

            If ItemsSE.isSave = True Then
                strSearch = ItemsSE.retailitemdescription
                varitemcode = ItemsSE.retailitemcode
                pnlItems2.Text = ItemsSE.retailitemdescription

                If pnlItems2.Text.Length = 0 Then
                    ItemsSE.strSearch = ""
                ElseIf pnlItems2.Text.Length > 5 Then
                    ItemsSE.strSearch = strSearch.Substring(0, 5)
                Else
                    ItemsSE.strSearch = pnlItems2.Text
                End If
            End If
        Catch
            strSearch = ""
            ItemsSE.itemcode = ""
        End Try

        If ItemsSE.isSave = True Then
            varitemcode = ItemsSE.retailitemcode
            pnlItems2.Text = ItemsSE.retailitemdescription
            Call loadlotno()
        End If
    End Sub
    Private Sub loadlotno()
        Dim dtlotno As DataTable
        Dim ctr As Integer = 0
        Try
            cmblotno.DataSource = Nothing
            Me.cmblotno.Items.Add(New DictionaryEntry("[ALL]", 0))
            dtlotno = clsReports.LoadLotNO(0, varitemcode, Me.cmbInventoryHitoryOffice.SelectedValue)

            Do While ctr < dtlotno.Rows.Count
                Me.cmblotno.Items.Add(New DictionaryEntry(dtlotno.Rows(ctr).Item("lotno"), _
                                                           dtlotno.Rows(ctr).Item("lotno")))
                ctr += 1
            Loop

            With cmblotno
                .DisplayMember = "Key"
                .ValueMember = "Value"
                .DataSource = .Items

                .SelectedValue = 0
            End With

        Catch
        End Try
    End Sub
    Private Sub populatereports()
        Dim tempprintType As String
        tempprintType = printType
        With Me.cmbInventoryHistoryReport
            .Items.Add(New DictionaryEntry("Inventory Stock Card", "e-Stock Card"))
            .Items.Add(New DictionaryEntry("Stock Receiving Entries History", "Stock Receiving Entries History"))
            .Items.Add(New DictionaryEntry("Stock Transfer History", "Stock Transfer History"))
            .Items.Add(New DictionaryEntry("Stock Adjustment History", "Stock Adjustment History"))
            .Items.Add(New DictionaryEntry("Stock Extraction History", "Stock Extraction History"))
            .Items.Add(New DictionaryEntry("Stock Return to Supplier History", "Stock Return to Supplier History"))
            .Items.Add(New DictionaryEntry("Stock Invoice Return History", "Stock Invoice Return History"))
            .Items.Add(New DictionaryEntry("Patient Charges History", "Patient Charges History"))
            .Items.Add(New DictionaryEntry("Employee Charges History", "Employee Charges History"))
            .Items.Add(New DictionaryEntry("Expense Issuance History", "Expense Issuance History"))
            .Items.Add(New DictionaryEntry("Issuance History", "Issuance History"))

            .DisplayMember = "Key"
            .ValueMember = "Value"
            .DataSource = .Items
            .SelectedValue = tempprintType
        End With
    End Sub
    Private Sub LoadExpiryNearDate()
        With cmbNearExpiryDate
            .DataSource = Nothing

            .Items.Add(New DictionaryEntry("3 Months", 3))
            .Items.Add(New DictionaryEntry("6 Months", 6))
            .Items.Add(New DictionaryEntry("Other", 0))

            .DisplayMember = "Key"
            .ValueMember = "Value"
            .DataSource = .Items
            .SelectedValue = 3
        End With
    End Sub
    'Private Sub LoadSupplier()
    '    Dim dtSuppliers As DataTable
    '    Dim ctr As Integer = 0

    '    'cmbStatusSupplier.DataSource = Nothing
    '    'Me.cmbStatusSupplier.Items.Add(New DictionaryEntry("[ALL]", 0))
    '    dtSuppliers = clsInventoryReports.getAllSuppliers("0")

    '    'Do While ctr < dtSuppliers.Rows.Count
    '    '    Me.cmbStatusSupplier.Items.Add(New DictionaryEntry(dtSuppliers.Rows(ctr).Item("suppliername"), _
    '    '                                               dtSuppliers.Rows(ctr).Item("supplierno")))
    '    '    ctr += 1
    '    'Loop
    '    'With cmbStatusSupplier
    '    '    .DisplayMember = "Key"
    '    '    .ValueMember = "Value"
    '    '    .DataSource = .Items
    '    '    .SelectedValue = 0
    '    'End With
    '    'With cmbSupplier
    '    '    .DisplayMember = "suppliername"
    '    '    .ValueMember = "supplierno"
    '    '    .DataSource = dtSuppliers
    '    '    .SelectedValue = 0
    '    'End With
    '    With cmbStatusSupplier
    '        .DisplayMember = "suppliername"
    '        .ValueMember = "supplierno"
    '        .DataSource = dtSuppliers
    '        .SelectedValue = 0
    '    End With
    'End Sub
    'Private Sub LoadExpirySupplier()
    '    Dim dtSuppliers As DataTable
    '    Dim ctr As Integer = 0

    '    cmbSupplier.DataSource = Nothing
    '    'Me.cmbSupplier.Items.Add(New DictionaryEntry("[ALL]", 0))
    '    dtSuppliers = clsInventoryReports.getAllSuppliers("0")

    '    'Do While ctr < dtSuppliers.Rows.Count
    '    '    Me.cmbSupplier.Items.Add(New DictionaryEntry(dtSuppliers.Rows(ctr).Item("suppliername"), _
    '    '                                               dtSuppliers.Rows(ctr).Item("supplierno")))
    '    '    ctr += 1
    '    'Loop
    '    'With cmbSupplier
    '    '    .DisplayMember = "Key"
    '    '    .ValueMember = "Value"
    '    '    .DataSource = .Items
    '    '    .SelectedValue = 0
    '    'End With

    '    With cmbSupplier
    '        .DisplayMember = "suppliername"
    '        .ValueMember = "supplierno"
    '        .DataSource = dtSuppliers
    '        .SelectedValue = 0
    '    End With
    'End Sub
    'Private Sub LoadCategory()

    '    Dim dtCat As DataTable
    '    Dim ctr As Integer = 0

    '    'cmbStatusCategory.DataSource = Nothing
    '    'Me.cmbStatusCategory.Items.Add(New DictionaryEntry("[ALL]", 0))
    '    dtCat = clsInventoryReports.getAllCategory("")

    '    'Do While ctr < dtCat.Rows.Count
    '    '    Me.cmbStatusCategory.Items.Add(New DictionaryEntry(dtCat.Rows(ctr).Item("itemcatdescription"), _
    '    '                                               dtCat.Rows(ctr).Item("itemcatcode")))
    '    '    ctr += 1
    '    'Loop
    '    'With cmbStatusCategory
    '    '    .DisplayMember = "Key"
    '    '    .ValueMember = "Value"
    '    '    .DataSource = .Items
    '    '    .SelectedValue = 0
    '    'End With
    '    With cmbStatusCategory
    '        .DisplayMember = "itemcatdescription"
    '        .ValueMember = "itemcatcode"
    '        .DataSource = dtCat
    '        .SelectedValue = 0
    '    End With
    'End Sub
    'Private Sub chklotno_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklotno.CheckedChanged
    '    Dim dtretLotNo As DataTable = clsReports.getlotno(Me.pnlItems.Text)
    '    If Me.pnlItems.Text <> "" Then
    '        If chklotno.Checked = True Then
    '            loadlotno()
    '            cmblotno.Enabled = True
    '            'varitemcode = Me.cmblotno.SelectedValue
    '            varlotno = Me.cmblotno.Text
    '        Else
    '            cmblotno.Enabled = False
    '            varitemcode = dtretLotNo.Rows(0).Item("itemcode")
    '        End If
    '    End If
    'End Sub

    'Private Sub cmbInventoryHistoryReport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInventoryHistoryReport.SelectedIndexChanged
    '    If cmbInventoryHistoryReport.SelectedValue = "e-Stock Card" Then
    '        pnlInventoryHistorySub.Visible = True
    '    Else
    '        pnlInventoryHistorySub.Visible = False
    '    End If
    '    Me.printType = cmbInventoryHistoryReport.SelectedValue
    'End Sub

    'Private Sub dtpInventoryHistoryStartDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInventoryHistoryStartDate.ValueChanged

    '    Me.dtpInventoryHistoryEndDate.MinDate = Me.dtpInventoryHistoryStartDate.Value
    'End Sub

    'Private Sub dtpInventoryHistoryEndDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInventoryHistoryEndDate.ValueChanged
    '    Me.dtpInventoryHistoryStartDate.MaxDate = Me.dtpInventoryHistoryEndDate.Value
    'End Sub

    Private Sub cbExcludeReceivedStocks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbExcludeReceivedStocks.CheckedChanged
        If cbExcludeReceivedStocks.Checked = True Then
            numDays.Enabled = True
        Else
            numDays.Value = 0
            numDays.Enabled = False
        End If
    End Sub

    Private Sub cbNearExpiryDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNearExpiryDate.CheckedChanged
        If printType = "Stock Expiry List" Then
            If cbNearExpiryDate.CheckState = CheckState.Checked Then
                cmbNearExpiryDate.Visible = True
                Call LoadExpiryNearDate()
            Else
                cmbNearExpiryDate.Visible = False
                txtNearExpiryDate.Visible = False
                lblMonths.Visible = False
                cmbNearExpiryDate.SelectedValue = -1
            End If
        End If
    End Sub

    Private Sub cmbNearExpiryDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNearExpiryDate.SelectedIndexChanged
        If printType = "Stock Expiry List" Then
            If cmbNearExpiryDate.SelectedValue = 0 Then
                If cbNearExpiryDate.CheckState = CheckState.Checked Then
                    txtNearExpiryDate.Visible = True
                    lblMonths.Visible = True
                    txtNearExpiryDate.Text = "1"
                    othernearexpirydate = CLng(txtNearExpiryDate.Text) * 30
                Else
                    txtNearExpiryDate.Visible = False
                    lblMonths.Visible = False
                    othernearexpirydate = cmbNearExpiryDate.SelectedValue
                End If
            Else
                txtNearExpiryDate.Visible = False
                lblMonths.Visible = False
                othernearexpirydate = cmbNearExpiryDate.SelectedValue
            End If
        End If
    End Sub

    Private Sub txtNearExpiryDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNearExpiryDate.TextChanged
        If txtNearExpiryDate.Text = "0" Then
            txtNearExpiryDate.Text = "1"
        End If
    End Sub

    Private Sub txtNearExpiryDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNearExpiryDate.KeyPress
        Dim allowedChars As String = "0123456789"
        If e.KeyChar <> ControlChars.Back Then
            If allowedChars.IndexOf(e.KeyChar) = -1 Then
                ' Invalid Character
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cbStatusSupplier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbStatusSupplier.CheckedChanged
        If printType = "Inventory Status Report" Then
            If cbStatusSupplier.CheckState = CheckState.Checked Then
                cmbStatusSupplier.Enabled = True
                cbStatusCategory.CheckState = CheckState.Unchecked
                cmbStatusCategory.Enabled = False
                cmbStatusCategory.SelectedValue = 0
                'cmbStatusSupplier.SelectedValue = 0
            Else
                cmbStatusSupplier.Enabled = False
            End If
        End If

    End Sub

    Private Sub cbStatusCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbStatusCategory.CheckedChanged
        If printType = "Inventory Status Report" Then
            If cbStatusCategory.CheckState = CheckState.Checked Then
                cmbStatusCategory.Enabled = True
                cbStatusSupplier.CheckState = CheckState.Unchecked
                cmbStatusSupplier.Enabled = False
                cmbStatusSupplier.SelectedValue = 0
                'cmbStatusCategory.SelectedValue = 0
            Else
                cmbStatusCategory.Enabled = False
            End If
        End If
    End Sub

    Private Sub cbShowLotNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShowLotNo.CheckedChanged
        If cbShowLotNo.Checked = False Then
            cbOrderByExpiry.Checked = False
            cbOrderByExpiry.Enabled = False
        Else
            cbOrderByExpiry.Enabled = True
        End If
    End Sub

#End Region

#Region "Auto Hide ~ Toggle by Idris"
    Private Sub toggle(Optional ByVal sw As Boolean = True, Optional ByVal isshowtoggle As Boolean = True)
        If isshowtoggle Then
            If sw Then
                canresize = True
                Me.pctrshow.Visible = True
                Me.pctrHide.Visible = False
                ishide = False
                Me.ToolStrip2.Visible = False
                SplitContainer1.SplitterDistance = 222
                SplitContainer1.Panel1.AutoScroll = True
            Else
                canresize = False
                Me.pctrshow.Visible = False
                Me.pctrHide.Visible = True
                ishide = True
                Me.ToolStrip2.Visible = True
                Me.ToolStrip2.BringToFront()
                SplitContainer1.SplitterDistance = 25
                SplitContainer1.Panel1.AutoScroll = False
            End If
        Else
            Me.ToolStrip2.Visible = True
            Me.ToolStrip2.BringToFront()
            Me.tsAutoHide.Enabled = False
            SplitContainer1.SplitterDistance = 25
            SplitContainer1.Panel1.AutoScroll = False
        End If

        doneloading = True
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        If doneloading Then
            If isshowtoggle = False Then
                SplitContainer1.SplitterDistance = 25
                Exit Sub
            End If
            If canresize Then
                If SplitContainer1.Panel1.Width >= 222 Then
                    SplitContainer1.SplitterDistance = 222
                End If
            Else
                SplitContainer1.SplitterDistance = 25
            End If
        End If

    End Sub
    Private Sub frmReportHandler_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        If SplitContainer1.Panel1.Width >= 222 Then
            SplitContainer1.SplitterDistance = 222
        End If
    End Sub
    Private Sub pctrshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctrshow.Click
        toggle(False)
    End Sub
    Private Sub pctrHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctrHide.Click
        toggle()
    End Sub
    Private Sub tsAutoHide_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAutoHide.MouseHover
        canresize = True
        SplitContainer1.SplitterDistance = 222
    End Sub
    Private Sub SplitContainer1_Panel1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitContainer1.Panel1.MouseLeave
        If ishide Then
            toggle(False)
        Else
            toggle()
        End If
    End Sub
    Private Sub pctrshow_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctrshow.MouseHover
        Dim tt As New ToolTip()
        tt.SetToolTip(pctrshow, "Auto Hide")
    End Sub
    Private Sub pctrHide_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctrHide.MouseHover
        Dim tt As New ToolTip()
        tt.SetToolTip(pctrHide, "Auto Hide")
    End Sub
    Private Sub tsAutoHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAutoHide.Click
        toggle()
    End Sub
#End Region

#Region "Finance ~ Ronald"
#Region "Methods"
    Public Sub LoadOfficePharmacy(ByVal cmb As ComboBox, Optional ByVal vdesc As String = "Office")
        If cmb.Items.Count = 0 Then
            Dim dtOffices As New DataTable
            Dim ctr As Integer

            Select Case vdesc
                Case "Office"
                    cmb.DataSource = Nothing
                    cmb.Items.Add(New DictionaryEntry("[ALL]", 0))
                    dtOffices = clsOffices.getOffices("", 1)
                    ctr = 0
                    Do While ctr < dtOffices.Rows.Count
                        cmb.Items.Add(New DictionaryEntry(dtOffices.Rows(ctr).Item("officedescription"), _
                                                                   dtOffices.Rows(ctr).Item("officecode")))

                        ctr += 1
                    Loop

                    cmb.DisplayMember = "Key"
                    cmb.ValueMember = "Value"
                    cmb.DataSource = cmb.Items
                    cmb.SelectedValue = modGlobal.sourceOfficeCode

                Case "Employee"

                    cmb.DataSource = Nothing
                    cmb.Items.Add(New DictionaryEntry("[ALL]", 0))
                    dtOffices = clsEmployees.getEmployees(0, "", "", 0)
                    ctr = 0
                    Do While ctr < dtOffices.Rows.Count
                        cmb.Items.Add(New DictionaryEntry(dtOffices.Rows(ctr).Item("Last Name") & " " & dtOffices.Rows(ctr).Item("First Name") & ", " & dtOffices.Rows(ctr).Item("Middle Name"), _
                                                          dtOffices.Rows(ctr).Item("employeeid")))

                        ctr += 1
                    Loop

                    cmb.DisplayMember = "Key"
                    cmb.ValueMember = "Value"
                    cmb.DataSource = cmb.Items
                    'cmb.SelectedValue = modGlobal.sourceOfficeCode

            End Select

        End If
    End Sub

    Private Sub loaddatetype()
        If printType = "Patient Account Receivable Details (HMO Patient Claims)" Or _
            printType = "Patient Account Receivable Details (PhilHealth Claims)" Then
            With cmbDateType
                .DataSource = Nothing
                .Items.Clear()
                .Items.Add(New DictionaryEntry("As Of", 1))
                .Items.Add(New DictionaryEntry("Custom Date", 2))
                .Items.Add(New DictionaryEntry("Monthly", 3))
                .DisplayMember = "Key"
                .ValueMember = "Value"
                .DataSource = cmbDateType.Items
                .SelectedIndex = 0
                Call LoadMonth() : Call LoadYear()
            End With
        ElseIf printType = "Daily Charge Invoice List" Or _
        printType = "Daily Charge Invoice Summary" Then
            With cmbDateType
                .DataSource = Nothing
                .Items.Clear()
                .Items.Add(New DictionaryEntry("Monthly", 1))
                .Items.Add(New DictionaryEntry("Custom Date", 2))
                .DisplayMember = "Key"
                .ValueMember = "Value"
                .DataSource = cmbDateType.Items
                .SelectedIndex = 0
                Call LoadMonth() : Call LoadYear()
            End With
        Else
            With cmbDateType
                .DataSource = Nothing
                .Items.Clear()
                .Items.Add(New DictionaryEntry("As Of", 1))
                .Items.Add(New DictionaryEntry("Custom Date", 2))
                .DisplayMember = "Key"
                .ValueMember = "Value"
                .DataSource = cmbDateType.Items
                .SelectedIndex = 0
            End With
        End If

    End Sub

    Private Sub loadadmissiontype()
        With cmbPeriod
            .DataSource = Nothing
            .Items.Clear()
            .Items.Add(New DictionaryEntry("VIEW ALL", 0))
            .Items.Add(New DictionaryEntry("IPD", 1))
            .Items.Add(New DictionaryEntry("OPD", 2))
            .Items.Add(New DictionaryEntry("ER-OPD", 3))
            .DisplayMember = "Key"
            .ValueMember = "Value"
            .DataSource = cmbPeriod.Items
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub LoadMonth()
        cmbMonth.DataSource = Nothing
        cmbMonth.Items.Clear()
        Me.cmbMonth.Items.Add(New DictionaryEntry("January", 1))
        Me.cmbMonth.Items.Add(New DictionaryEntry("February", 2))
        Me.cmbMonth.Items.Add(New DictionaryEntry("March", 3))
        Me.cmbMonth.Items.Add(New DictionaryEntry("April", 4))
        Me.cmbMonth.Items.Add(New DictionaryEntry("May", 5))
        Me.cmbMonth.Items.Add(New DictionaryEntry("June", 6))
        Me.cmbMonth.Items.Add(New DictionaryEntry("July", 7))
        Me.cmbMonth.Items.Add(New DictionaryEntry("August", 8))
        Me.cmbMonth.Items.Add(New DictionaryEntry("September", 9))
        Me.cmbMonth.Items.Add(New DictionaryEntry("October", 10))
        Me.cmbMonth.Items.Add(New DictionaryEntry("November", 11))
        Me.cmbMonth.Items.Add(New DictionaryEntry("December", 12))

        Me.cmbMonth.DisplayMember = "Key"
        Me.cmbMonth.ValueMember = "Value"
        Me.cmbMonth.DataSource = Me.cmbMonth.Items
        Me.cmbMonth.SelectedIndex = 0
    End Sub

    Private Sub LoadYear()
        Dim i As Integer
        Dim x As Integer = 0
        cmbYear.DataSource = Nothing
        cmbYear.Items.Clear()

        For i = 2000 To Year(Now)
            Me.cmbYear.Items.Add(New DictionaryEntry(i, i))
            x += 1
        Next i

        Me.cmbYear.DisplayMember = "Key"
        Me.cmbYear.ValueMember = "Value"
        Me.cmbYear.DataSource = Me.cmbYear.Items
        Me.cmbYear.SelectedIndex = x - 1
    End Sub

#End Region
#Region "Events"
    Private Sub cmbDateType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDateType.SelectedIndexChanged
        If printType = "Employees' Outstanding Balance" Then

            If cmbDateType.SelectedValue = 1 Then
                dtToFinancial.Visible = False
                dtEndTimeFinancial.Visible = False
                dtFromFinancial.Value = Now
                dtStartTimeFinancial.Visible = False
                Label13.Visible = False
                Label14.Visible = False
                cmbDateType.Enabled = False
                dtToFinancial.Value = DateTime.Today
                dtEndTimeFinancial.Value = DateTime.Today

            Else
                dtToFinancial.Visible = True
                dtEndTimeFinancial.Visible = True
                dtFromFinancial.Enabled = True
                dtStartTimeFinancial.Visible = True
                Label13.Visible = True
                Label14.Text = "Start Date:"
                dtToFinancial.Enabled = True
                dtEndTimeFinancial.Enabled = True
                Label14.Visible = True
                cmbDateType.Enabled = True
            End If
        ElseIf printType = "Patient Account Receivables Summary" Or printType = "Patient Account Receivables Details" Or _
               printType = "Account Receivables Summary" Then

            If cmbDateType.SelectedValue = 1 Then
                dtToFinancial.Visible = False
                dtEndTimeFinancial.Visible = False
                dtFromFinancial.Value = Now
                dtStartTimeFinancial.Visible = False
                Label13.Visible = False
                Label14.Visible = False
                cmbDateType.Enabled = True
                dtToFinancial.Value = DateTime.Today
                dtEndTimeFinancial.Value = FormatDateTime(DateTime.Today, DateFormat.ShortDate) & " " & "11:59:59 PM"

                '-------New Added
                cmbPeriod.Enabled = True
                Label30.Text = "Admission Type:"

                cmbPeriod.Size = New Size(102, 21)
                cmbPeriod.Location = New Point(97, 9)
                Label30.Location = New Point(4, 12)
            Else

                dtFromFinancial.Value = DateTime.Today
                dtStartTimeFinancial.Value = DateTime.Today
                dtToFinancial.Value = DateTime.Today
                dtEndTimeFinancial.Value = FormatDateTime(DateTime.Today, DateFormat.ShortDate) & " " & "11:59:59 PM"

                dtToFinancial.Visible = True
                dtEndTimeFinancial.Visible = True
                dtFromFinancial.Enabled = True




                dtStartTimeFinancial.Visible = True
                Label13.Visible = True
                Label14.Text = "Start Date:"
                dtToFinancial.Enabled = True
                dtEndTimeFinancial.Enabled = True
                Label14.Visible = True
                cmbDateType.Enabled = True

                '-------New Added
                cmbPeriod.Enabled = True
                Label30.Text = "Admission Type:"

                cmbPeriod.Size = New Size(102, 21)
                cmbPeriod.Location = New Point(97, 9)
                Label30.Location = New Point(4, 12)
            End If
        ElseIf printType = "HMO Account Receivables Details" Or printType = "Religious Group Account Receivables Details" Or _
         printType = "HMO Account Receivables Summary" Or printType = "Religious Group Account Receivables Summary" Or _
          printType = "PhilHealth Account Receivables Details" Or printType = "PhilHealth Account Receivables Summary" Then

            If cmbDateType.SelectedValue = 1 Then
                dtToFinancial.Visible = False
                dtEndTimeFinancial.Visible = False
                dtFromFinancial.Value = Now
                dtStartTimeFinancial.Visible = False
                Label13.Visible = False
                Label14.Visible = False
                cmbDateType.Enabled = True
                dtToFinancial.Value = DateTime.Today
                dtEndTimeFinancial.Value = FormatDateTime(DateTime.Today, DateFormat.ShortDate) & " " & "11:59:59 PM"
            Else
                dtFromFinancial.Value = DateTime.Today
                dtStartTimeFinancial.Value = DateTime.Today
                dtToFinancial.Value = DateTime.Today
                dtEndTimeFinancial.Value = FormatDateTime(DateTime.Today, DateFormat.ShortDate) & " " & "11:59:59 PM"

                dtToFinancial.Visible = True
                dtEndTimeFinancial.Visible = True
                dtFromFinancial.Enabled = True




                dtStartTimeFinancial.Visible = True
                Label13.Visible = True
                Label14.Text = "Start Date:"
                dtToFinancial.Enabled = True
                dtEndTimeFinancial.Enabled = True
                Label14.Visible = True
                cmbDateType.Enabled = True
            End If

        ElseIf printType = "Patient Account Receivable Details (HMO Patient Claims)" _
            Or printType = "Patient Account Receivable Details (PhilHealth Claims)" Then

            If cmbDateType.SelectedValue = 1 Then 'AS OF
                dtToFinancial.Visible = False
                dtEndTimeFinancial.Visible = False
                dtFromFinancial.Value = Now
                dtStartTimeFinancial.Visible = False
                Label13.Visible = False
                Label14.Visible = False
                cmbDateType.Enabled = True
                dtToFinancial.Value = DateTime.Today
                dtEndTimeFinancial.Value = FormatDateTime(DateTime.Today, DateFormat.ShortDate) & " " & "11:59:59 PM"
                cmbMonth.Visible = False
                cmbYear.Visible = False
                dtFromFinancial.Visible = True
            ElseIf cmbDateType.SelectedValue = 3 Then 'MONTHLY
                Label14.Visible = True
                Label13.Visible = True
                Label14.Text = "Month:"
                Label13.Text = "Year:"
                cmbMonth.Visible = True
                cmbYear.Visible = True

                dtToFinancial.Visible = False
                dtEndTimeFinancial.Visible = False
                dtFromFinancial.Visible = False
                dtStartTimeFinancial.Visible = False
                cmbDateType.Enabled = True
                'dtToFinancial.Value = DateTime.Today
                'dtEndTimeFinancial.Value = FormatDateTime(DateTime.Today, DateFormat.ShortDate) & " " & "11:59:59 PM"


            Else 'DATE DRANGE
                dtFromFinancial.Value = DateTime.Today
                dtStartTimeFinancial.Value = DateTime.Today
                dtToFinancial.Value = DateTime.Today
                dtEndTimeFinancial.Value = FormatDateTime(DateTime.Today, DateFormat.ShortDate) & " " & "11:59:59 PM"
                dtFromFinancial.Visible = True
                dtToFinancial.Visible = True
                dtEndTimeFinancial.Visible = True
                dtFromFinancial.Enabled = True

                dtStartTimeFinancial.Visible = True
                Label13.Visible = True
                Label14.Text = "Start Date:"
                Label13.Text = "End Date:"
                dtToFinancial.Enabled = True
                dtEndTimeFinancial.Enabled = True
                Label14.Visible = True
                cmbDateType.Enabled = True
                cmbMonth.Visible = False
                cmbYear.Visible = False
            End If
        ElseIf printType = "Daily Charge Invoice List" _
       Or printType = "Daily Charge Invoice Summary" Then

            If cmbDateType.SelectedValue = 1 Then 'MONTHLY
                Label14.Visible = True
                Label13.Visible = True
                Label14.Text = "Month:"
                Label13.Text = "Year:"
                cmbMonth.Visible = True
                cmbYear.Visible = True

                dtToFinancial.Visible = False
                dtEndTimeFinancial.Visible = False
                dtFromFinancial.Visible = False
                dtStartTimeFinancial.Visible = False
                cmbDateType.Enabled = True

            Else 'DATE DRANGE
                dtFromFinancial.Value = DateTime.Today
                dtStartTimeFinancial.Value = DateTime.Today
                dtToFinancial.Value = DateTime.Today
                dtEndTimeFinancial.Value = FormatDateTime(DateTime.Today, DateFormat.ShortDate) & " " & "11:59:59 PM"
                dtFromFinancial.Visible = True
                dtToFinancial.Visible = True
                dtEndTimeFinancial.Visible = True
                dtFromFinancial.Enabled = True

                dtStartTimeFinancial.Visible = True
                Label13.Visible = True
                Label14.Text = "Start Date:"
                Label13.Text = "End Date:"
                dtToFinancial.Enabled = True
                dtEndTimeFinancial.Enabled = True
                Label14.Visible = True
                cmbDateType.Enabled = True
                cmbMonth.Visible = False
                cmbYear.Visible = False

            End If



        ElseIf printType = "Admission and Discharge Report" Or printType = "Daily Census" Then
            If afterInit And idx <> Me.cmbDateType.SelectedIndex Then
                idx = cmbDateType.SelectedIndex
                'Call getPeriodDateRange(Me.cmbDateType) ', vstartdate, venddate)
                Call EnableDateFilter()
                Call LoadReport()
            End If
        End If
    End Sub
#End Region



#End Region
#Region "Methods & Events ~ JAYMAR"
#Region "Philhealth Form"
    Private Sub pcSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pcSearch.Click
        Dim fphicmember As New frmSearchEngine
        With fphicmember
            .mModuleName = printType
            .ShowDialog()
            If .issave Then
                phicno = .mKey
                Me.varno = phicno
                Me.txtInventorySearch.Text = .mLastName
            End If
            phictagging = False
            Call LoadReport()
        End With
    End Sub
#End Region
#Region "admission"
    Private Sub design()
        Me.grpFinancialReport.Text = printType
        Me.grpFinancialReport.Visible = 1
        Me.cmbDateType.Visible = 1

        Me.Dateto.Visible = 1
        Me.Datefrom.Visible = 1
        Me.GroupBox2.Visible = 1
        Me.GroupBox2.Location = New Point(10, 46)
        Me.cmbPeriod.Visible = 1

        Me.Label13.Visible = 0
        Me.Label14.Visible = 0

        Me.GroupBox3.Visible = 0
        Me.GroupBox5.Visible = 0
        Me.PictureBox2.Visible = 0
        Me.PictureBox1.Visible = 0
        Me.PictureBox3.Visible = 0
        Me.dtEndTimeFinancial.Visible = 0
        Me.dtStartTimeFinancial.Visible = 0
    End Sub
    Private Sub getPeriodDateRange(ByVal cmbPeriod As ComboBox) ', _
        Dim quarter As Integer
        Dim week As Integer
        If cmbPeriod.SelectedIndex = 0 Or cmbPeriod.SelectedIndex = 5 Then
            If afterInit Then
                admissiondateTo = FormatDateTime(Datefrom.Value, DateFormat.ShortDate)
                admissiondateFrom = FormatDateTime(Dateto.Value, DateFormat.ShortDate)
            Else
                admissiondateTo = FormatDateTime(Utility.GetServerDate(), DateFormat.ShortDate)
                admissiondateFrom = FormatDateTime(Utility.GetServerDate(), DateFormat.ShortDate)
            End If

        Else
            admissiondateTo = Me.Datefrom.Value
        End If
        Select Case cmbPeriod.SelectedValue
            Case 0
                admissiondateFrom = admissiondateTo
            Case 1 ' this week
                daydiff = -1 * admissiondateTo.DayOfWeek
                admissiondateTo = admissiondateTo.AddDays(daydiff)
                week = -admissiondateTo.DayOfWeek + 6
                admissiondateFrom = admissiondateTo.AddDays(week)
            Case 2 'this month
                admissiondateTo = Month(admissiondateTo) & "/1/" & Year(admissiondateTo)
                admissiondateFrom = admissiondateTo.AddMonths(1).AddDays(-1)
            Case 3 'this quarter to date

                'If admissiondateTo.Month = 12 Then
                '    quarter = 10
                'Else
                '    quarter = ((admissiondateTo.Month \ 3) * 3) + 1
                'End If
                'admissiondateTo = quarter & "/1/" & Year(admissiondateTo)
                quarter = CType((admissiondateTo.Month - 1) / 3 + 1, Integer)
                admissiondateTo = New DateTime(admissiondateTo.Year, 3 * quarter - 2, 1)
                admissiondateFrom = New DateTime(admissiondateTo.Year, admissiondateTo.Month + 2, 1).AddMonths(1).AddDays(-1)
            Case 4
                admissiondateTo = "1/1/" & Year(admissiondateTo)
                admissiondateFrom = New DateTime((admissiondateTo.Year + 1), 1, 1)
                admissiondateFrom = admissiondateFrom.AddDays(-1)

            Case 5
                If afterInit = False Then
                    admissiondateTo = DateAdd(DateInterval.Month, -1, admissiondateFrom)
                End If
        End Select
        Me.Datefrom.Value = admissiondateTo
        Me.Dateto.Value = admissiondateFrom
        'Call displaylist()
    End Sub
    Public Function GetFirstOfLastWeek(ByVal inputdate As DateTime) As DateTime
        Dim daysSinceMonday As Integer
        daysSinceMonday = inputdate.DayOfWeek - DayOfWeek.Monday
        If daysSinceMonday < 0 Then
            daysSinceMonday += 7
        End If
        Return Today.AddDays(-daysSinceMonday)
    End Function
    Private Sub EnableDateFilter()
        Me.GroupBox2.Enabled = True
        Me.Dateto.Visible = 1
        Me.Datefrom.Visible = 1
        Me.Label18.Visible = 1
        Me.Label17.Visible = 1
        If printType = "Admission and Discharge Report" Then
            Me.cmbPeriod.Enabled = 1
            If cmbPeriod.SelectedIndex < 5 Then
                Me.Datefrom.Enabled = 1
                Me.Dateto.Enabled = 0
            ElseIf cmbPeriod.SelectedIndex = 5 Then
                Me.Dateto.Enabled = 1
                Me.Datefrom.Enabled = 1
            Else
                Me.Datefrom.Enabled = 0
            End If
        ElseIf printType = "Daily Census" Then
            Me.cmbPeriod.Enabled = 0
            Me.Datefrom.Enabled = 1
            Me.Dateto.Enabled = 0
        End If
    End Sub
    Private Sub datetype()
        With cmbDateType
            .DataSource = Nothing
            .Items.Add(New DictionaryEntry("Inpatients", 0))
            .Items.Add(New DictionaryEntry("Outpatients", 1))
            .Items.Add(New DictionaryEntry("Emergency", 2))
            .DisplayMember = "Key"
            .ValueMember = "Value"
            .DataSource = .Items
            .SelectedIndex = 0
            idx = .SelectedIndex
        End With
    End Sub
    Private Sub loadrange()
        With cmbPeriod
            .DataSource = Nothing
            .Items.Add(New DictionaryEntry("Daily", 0))
            .Items.Add(New DictionaryEntry("Weekly", 1))
            .Items.Add(New DictionaryEntry("Monthly", 2))
            .Items.Add(New DictionaryEntry("Quarterly", 3))
            .Items.Add(New DictionaryEntry("Yearly", 4))
            .Items.Add(New DictionaryEntry("Custom Date", 5))
            .DisplayMember = "Key"
            .ValueMember = "Value"
            .DataSource = .Items
            .SelectedIndex = 0
            idxfilter = .SelectedIndex
        End With
    End Sub
#End Region
#End Region

    Public Sub CleanOutViewer()
        Try
            If Not Me.crptViewer.ReportSource() Is Nothing Then
                CType(Me.crptViewer.ReportSource(), CrystalDecisions.CrystalReports.Engine.ReportDocument).Close()
                CType(Me.crptViewer.ReportSource(), CrystalDecisions.CrystalReports.Engine.ReportDocument).Dispose()
                Me.crptViewer.ReportSource() = Nothing
                GC.Collect()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmReportHandler_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        CleanOutViewer()
    End Sub




End Class


