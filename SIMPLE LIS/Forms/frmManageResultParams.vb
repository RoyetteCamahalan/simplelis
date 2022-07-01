Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Public Class frmManageResultParams
#Region "Variables"

    Public myFormStatus As enFormStatus
    Public Labname As String
    Public labid As Long
    Public itemcode As String
    Public itemname As String

    'Royette 2021-07-29
    Private rowheight As Integer = 26
    Private afterload As Boolean
    Public issave As Boolean
    Public hasSIvalue As Boolean
#End Region
#Region "Constructor"
    Enum enFormStatus
        'for operations
        browsing = 0
        add = 1
        edit = 2
    End Enum

#End Region
#Region "Events"
    Private Sub frmManageResultParams_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call RefreshDesign()
        Call LoadRecord()
    End Sub

    Private Sub dgvResult_SelectionChanged(sender As System.Object, e As System.EventArgs) Handles dgvResult.SelectionChanged
        Try
            If afterload Then
                Call setButtonStatus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tsClose_Click(sender As System.Object, e As System.EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub tsSave_Click(sender As System.Object, e As System.EventArgs) Handles tsSave.Click
        Me.dgvResult.EndEdit()
        If isValid() Then
            save()
        End If
    End Sub

    Private Sub btnup_Click(sender As System.Object, e As System.EventArgs) Handles btnup.Click
        Dim row As DataGridViewRow = Me.dgvResult.CurrentRow
        Dim idx As Integer = Me.dgvResult.CurrentRow.Index
        Me.dgvResult.Rows.RemoveAt(idx)
        Me.dgvResult.Rows.Insert(idx - 1, row)
        Me.dgvResult.CurrentCell = Me.dgvResult.Rows(idx - 1).Cells(Me.dgvResult.CurrentCell.ColumnIndex)
        setButtonStatus()
    End Sub

    Private Sub btndown_Click(sender As System.Object, e As System.EventArgs) Handles btndown.Click
        Dim row As DataGridViewRow = Me.dgvResult.CurrentRow
        Dim idx As Integer = Me.dgvResult.CurrentRow.Index
        Me.dgvResult.Rows.RemoveAt(idx)
        Me.dgvResult.Rows.Insert(idx + 1, row)
        Me.dgvResult.CurrentCell = Me.dgvResult.Rows(idx + 1).Cells(Me.dgvResult.CurrentCell.ColumnIndex)
        setButtonStatus()
    End Sub
#End Region

#Region "Methods"
    Private Sub RefreshDesign()
        If Not hasSIvalue Then
            Me.lblconventional.Visible = False
            Me.lblSI.Visible = False
            Me.lblconversion.Visible = False
            Me.lblrefval1.Visible = False
            Me.lblunit1.Visible = False
            Me.lbltest.Width = 446
            Me.lblrefval2.Height = Me.lbltest.Height
            Me.lblunit2.Height = Me.lbltest.Height
            Me.dgvResult.Columns(colconversion.Index).Visible = False
            Me.dgvResult.Columns(colsiref.Index).Visible = False
            Me.dgvResult.Columns(colsiunit.Index).Visible = False
            Me.dgvResult.Columns(colparameter.Index).Width = 445
        End If
    End Sub

    Private Sub LoadRecord()
        Dim dt As DataTable = clsExamination.getLabdetails(Me.labid)
        afterload = False
        For Each row As DataRow In dt.Rows
            dgvResult.Rows.Add(1)

            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colchk.Index).Value = row.Item("visible")
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(collabdetailid.Index).Value = row.Item("laboratorydetailsid")
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colparameter.Index).Value = row.Item("description")
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colref.Index).Value = row.Item("normalvalues")
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colunits.Index).Value = row.Item("unit")
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colsiref.Index).Value = row.Item("normalvaluessi")
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colsiunit.Index).Value = row.Item("unitsi")
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(colconversion.Index).Value = CDbl(row.Item("siconversion"))
            Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(coltexthighlight.Index).Value = row.Item("texthighlight")
        Next
        afterload = True
    End Sub

    Private Function isValid() As Boolean
        Dim valid As Boolean = True
        For Each row As DataGridViewRow In Me.dgvResult.Rows
            If row.Cells(colparameter.Index).Value = "" Then
                row.Cells(colparameter.Index).ErrorText = "Invalid Value"
                valid = False
            Else
                row.Cells(colparameter.Index).ErrorText = ""
            End If
            Try
                Dim tryint As Decimal
                If Not Decimal.TryParse(row.Cells(colconversion.Index).Value, tryint) Then
                    If dgvResult.Columns(colconversion.Index).Visible = True Then
                        row.Cells(colconversion.Index).ErrorText = "Invalid Value"
                        valid = False
                    Else
                        row.Cells(colconversion.Index).Value = "1"
                    End If
                Else
                    row.Cells(colconversion.Index).ErrorText = ""
                End If
            Catch ex As Exception
                row.Cells(colparameter.Index).ErrorText = "Invalid Value, use 0 if not applicable"
            End Try
        Next
        Return valid
    End Function
    Public Sub save()
        Dim x As New clsExamination
        x.laboratoryid = Me.labid
        For Each row As DataGridViewRow In Me.dgvResult.Rows
            x.laboratorydetailsid = row.Cells(collabdetailid.Index).Value
            x.labdetailsdescription = row.Cells(colparameter.Index).Value
            x.visible = row.Cells(colchk.Index).Value
            x.normalvalues = Utility.NullToEmptyString(row.Cells(colref.Index).Value)
            x.unit = Utility.NullToEmptyString(row.Cells(colunits.Index).Value)
            x.orderno = row.Index
            x.normalvaluessi = Utility.NullToEmptyString(row.Cells(colsiref.Index).Value)
            x.unitsi = Utility.NullToEmptyString(row.Cells(colsiunit.Index).Value)
            x.siconversion = Utility.NullToZero(row.Cells(colconversion.Index).Value)
            x.texthighlight = Utility.NullToEmptyString(row.Cells(coltexthighlight.Index).Value)
            If x.laboratorydetailsid = 0 Then
                x.saveDetails(True)
            Else
                x.saveDetails(False)
            End If
        Next
        Me.issave = True
        MsgBox("Laboratory Details has been saved!", MsgBoxStyle.Information, modGlobal.msgboxTitle)
        Me.Close()
    End Sub
    Private Sub setButtonStatus()
        If Me.dgvResult.CurrentCell.RowIndex = 0 Then
            Me.btnup.Enabled = False
            Me.btndown.Enabled = True
        ElseIf Me.dgvResult.CurrentCell.RowIndex = Me.dgvResult.Rows.Count - 1 Then
            Me.btnup.Enabled = True
            Me.btndown.Enabled = False
        Else
            Me.btnup.Enabled = True
            Me.btndown.Enabled = True
        End If
    End Sub
#End Region

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Me.dgvResult.Rows.Add(1)
        Me.dgvResult.Rows(Me.dgvResult.Rows.Count - 1).Cells(collabdetailid.Index).Value = 0
        Me.dgvResult.FirstDisplayedScrollingRowIndex = Me.dgvResult.RowCount - 1
        Me.dgvResult.Rows(Me.dgvResult.RowCount - 1).Cells(colparameter.Index).Selected = True
        Me.dgvResult.Select()
    End Sub

    Private Sub lblseeavailablecolors_Click(sender As System.Object, e As System.EventArgs) Handles lblseeavailablecolors.Click
        Dim f As New frmAvailableColors
        f.ShowDialog()
    End Sub
End Class