Imports System.Data
Imports System.Data.SqlClient
Imports System

Public Class clsQuery
    Inherits clsDBConnection

#Region "Constructor"
    Public Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Variables"
    Private c_sqlComm As New SqlCommand
    Private f_rdr As SqlDataReader
    Private c_sqlDA As SqlDataAdapter
    Private c_tran As SqlTransaction
#End Region

#Region "Global variable"
    Public Par As String() = New String() {}
    Public parvalue As Object() = New Object() {}
    Public NewPK As String
#End Region

#Region "Methods"

    Public Sub Dispose()
        Try
            c_sqlComm.Dispose()
            c_tran.Dispose()
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Fetch Data and Store Data"

    Public Function Fetch_Records(ByVal parFieldName() As String, ByVal parFieldValue() As Object, _
                              ByVal strStoredProcName As String, Optional ByVal ReturnType As Integer = 0) As Object

        Dim sqlDA As New SqlDataAdapter
        Dim dtResult As New DataTable
        Dim dbcon As New clsDBConnection
        Call dbcon.CreateOpenConnection()
        Dim command As New SqlCommand(strStoredProcName, dbcon.GDBConn)
        command.CommandType = CommandType.StoredProcedure

        If parFieldName.Length > 0 Then
            For ctr As Integer = 0 To parFieldValue.Length - 1
                With command
                    .Parameters.AddWithValue(parFieldName(ctr), parFieldValue(ctr))
                End With
            Next
        End If

        sqlDA = New SqlDataAdapter(command)
        sqlDA.SelectCommand.CommandTimeout = 1000
        sqlDA.Fill(dtResult)
        dbcon.CloseDestroyConnection()
        Return dtResult

        'Dim f_ok As Boolean = True
        'Dim cls_Query As New clsQuery
        'Dim f_dt As New DataTable

        'cls_Query.Par = arrFieldName
        'cls_Query.parvalue = arrFieldValue

        'Try
        'cls_Query.CreateOpenConnection()
        'f_dt = cls_Query.ExecuteQueryDB(strStoredProcName, , ReturnType)
        'Return f_dt

        ''If ReturnType = 0 Then
        ''If Not (CStr(arrFieldValue(0)) = "1" And strStoredProcName = strStoredProcName) Then
        ''If f_ok = cls_Query.ExecuteQueryDB(strStoredProcName, , ReturnType) Then
        ''    'f_dt = cls_Query.GetData()
        ''    Return f_dt
        ''End If
        ''ElseIf ReturnType = 1 Then
        ''    If f_ok = cls_Query.ExecuteQueryDB(strStoredProcName, , ReturnType) Then
        ''        f_rdr = cls_Query.getDataRdr
        ''        Return f_rdr
        ''    End If
        ''End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    'If ReturnType = 0 Then
        '    cls_Query.CloseDestroyConnection()
        '    cls_Query.Dispose()
        '    'End If
        'End Try
    End Function

    Public Function ExecuteQueryDB(ByRef p_ProcedQuery As String, _
                Optional ByRef p_CommandType As CommandType = CommandType.StoredProcedure, _
                Optional ByVal ReturnType As Integer = 0) As DataTable
        Dim f_ok As Boolean = True
        'Dim c_sqlCon As New clsDBConnection
        Dim mark As Integer = 0
        Dim dt As New DataTable

        Try
            'c_sqlCon.CreateOpenConnection()
            c_sqlComm.Connection = Me.GDBConn
            c_sqlComm.CommandText = p_ProcedQuery
            c_sqlComm.CommandType = p_CommandType
            c_sqlComm.CommandTimeout = 120
            'c_tran = Me.GDBConn.BeginTransaction
            'c_sqlComm.Transaction = c_tran
            If Par.Length > 0 Then
                c_sqlComm.Parameters.Clear()
                For ctr As Integer = 0 To parvalue.Length - 1
                    With c_sqlComm
                        If Par(ctr) = "NewPK" Then
                            .Parameters.Add("NewPK", SqlDbType.VarChar, 15).Direction = ParameterDirection.Output
                            mark = parvalue(ctr)
                        Else
                            .Parameters.AddWithValue(Par(ctr), parvalue(ctr))
                        End If
                    End With
                Next
            End If
            If ReturnType = 0 Then
                'c_sqlComm.ExecuteNonQuery()
                c_sqlDA = New SqlDataAdapter(c_sqlComm)
                c_sqlDA.Fill(dt)
                'If mark = 1 Then
                '    NewPK = Utility.NullToEmptyString(c_sqlComm.Parameters("NewPK").Value)
                'End If
                'c_sqlComm = Nothing
                'c_tran.Commit()
            Else
                c_sqlComm.ExecuteNonQuery()
                If mark = 1 Then
                    NewPK = Utility.NullToEmptyString(c_sqlComm.Parameters("NewPK").Value)
                End If
                '    'f_rdr = c_sqlComm.ExecuteReader(CommandBehavior.CloseConnection)
                '    c_sqlDA = New SqlDataAdapter(c_sqlComm)
                '    c_sqlDA.Fill(dt)
            End If
        Catch ex As Exception
            'f_ok = False
            Return Nothing
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Gets the Data From the Database. 
    ''' Must Execute the ExecuteQueryDB method First before using this method.
    ''' </summary>
    ''' <returns>Return True if no error occured, return false if error occured</returns>
    ''' <remarks></remarks>
    Public Function GetData() As DataTable
        Dim dt As New DataTable
        Try
            c_sqlDA = New SqlDataAdapter(c_sqlComm)
            c_sqlDA.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            c_sqlDA.Dispose()
        End Try
        Return dt
    End Function
    Public Function getDataRdr() As SqlDataReader
        Return f_rdr
    End Function

#End Region

End Class
