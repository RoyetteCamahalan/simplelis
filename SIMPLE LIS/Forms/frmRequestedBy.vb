Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Xml
Public Class frmRequestedBy

#Region "Variables"
    Public isLoginValid As Boolean
    Public RequestedByID As Long
    Public isSubModal As Boolean
    Private erp As New ErrorProvider
    Private tooltip As New ToolTip
    Public purpose As enPurpose
    Private canverify As Boolean
    Private officecode As String
    Enum enPurpose
        na
        editResult
    End Enum
#End Region
    Public Sub New(purpose As enPurpose, Optional officecode As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.purpose = purpose
        Me.officecode = officecode
    End Sub
    Private Sub frmSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitFormDefault()
    End Sub
    Private Sub ProceedLogin()
        Dim dtRecord As DataTable = clsUsers.GetUser(0, Me.txtUser.Text, clsJCypher.StringCipher.Encrypt(Me.txtPass.Text, cypherpassphrase), 0)
        If dtRecord.Rows.Count <> 0 Then
            If purpose = enPurpose.editResult Then
                Dim dt As DataTable = clsUsers.GetUser(1, "", "", dtRecord.Rows(0).Item("employeeid"))
                Me.LoadUserModules(dtRecord.Rows(0).Item("employeeid"), AccountModule.modExaminationUpshots)
                If Me.canverify And dt.Rows(0).Item("officecode") = Me.officecode Then
                    Me.RequestedByID = dtRecord.Rows(0).Item("employeeid")
                    Me.isLoginValid = True
                    Me.Close()
                Else
                    MsgBox("You don't have enough permission to perform this action.")
                End If
            Else
                Me.RequestedByID = dtRecord.Rows(0).Item("employeeid")
                Me.isLoginValid = True
                Me.Close()
            End If
        Else
            MsgBox("Invalid username/password. Please try again.")
            Me.isSubModal = True
        End If
    End Sub
    Private Sub btnSignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignIn.Click
        Me.Cursor = Cursors.WaitCursor
        Call ProceedLogin()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub txtUser_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtPass.Focus()
            Me.txtPass.SelectAll()
        End If
    End Sub

    Private Sub txtPass_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPass.MouseClick
        txtPass.SelectAll()
    End Sub
    Private Sub txtPass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSignIn_Click(sender, e)
        End If
    End Sub

    Private Sub InitFormDefault()
        Me.CenterToScreen()
        If Me.purpose = enPurpose.editResult Then
            Me.gbOverride.Text = "Override"
            Me.btnSignIn.Text = "Override"
        End If
    End Sub
    Private Sub LoadUserModules(userid As Long, accMod As String)
        Dim dpk(1) As DataColumn
        Dim dtModule = clsUsers.GetUser(2, "", "", userid)
        dpk(0) = dtModule.Columns("modcode")
        dtModule.PrimaryKey = dpk
        If dtModule.Rows.Count > 0 Then
            Dim row As DataRow = dtModule.Rows.Find(accMod)
            If Not (row Is Nothing) Then
                Me.canverify = row("canverify")
            Else
                Me.canverify = False
            End If
        End If
    End Sub
End Class