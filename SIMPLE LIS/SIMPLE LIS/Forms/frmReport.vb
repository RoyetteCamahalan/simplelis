Imports System.Data.SqlClient
Imports System.Configuration

Public Class frmReport
    Public myReportName As enReportName
    Public printType As String
    Public varno As Long
    Public varstr As String
    Enum enReportName
        ecgreport = 0 '
        crossmatching = 1
        newbornscreening = 2
    End Enum
    Private Sub frmReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.crptViewer.RefreshReport()

    End Sub

    Public Sub printreport(ByVal rnum As String)
        Dim da As SqlDataAdapter

        Dim objDB As New clsDBConnection
        Dim ConnectionString As String = ConfigurationSettings.AppSettings("MyConnectionString")
        Dim conn As New SqlConnection(ConnectionString)
        Dim dt As New DataTable

        If myReportName = enReportName.ecgreport Then
            Dim rpt As New ECGRPT
            Me.Text = "ECG Report"
            da = New SqlDataAdapter("Exec spPrinting 0,0,'" & rnum & "'  ", conn)
            da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
        ElseIf myReportName = enReportName.newbornscreening Then
            Dim rpt As New nbsRPT
            Me.Text = "New Born Screening"
            da = New SqlDataAdapter("Exec spPrinting 0,1,'" & rnum & "' ", conn)
            da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
        ElseIf myReportName = enReportName.crossmatching Then
            Me.Text = "Crossmatching"
            Dim rpt As New CrossmatchingRPT
            da = New SqlDataAdapter("Exec spPrinting 0,2,'" & rnum & "' ", conn)
            da.Fill(dt)
            rpt.SetDataSource(dt)
            crptViewer.ReportSource = rpt
        End If

    End Sub
End Class