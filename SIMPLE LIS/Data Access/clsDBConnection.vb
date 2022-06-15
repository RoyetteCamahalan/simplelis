Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports SIMPLE_LIS.Utility
Imports System.Security.Cryptography
Imports System.IO
Public Class clsDBConnection

#Region "Variables"
    Dim DBCon As New SqlConnection
#End Region

#Region "Properties"
    Public ReadOnly Property GDBConn() As SqlConnection
        Get
            Return DBCon
        End Get
    End Property
#End Region

#Region "Methods"

    Public Sub CreateOpenConnection()
        Try

            DBCon.ConnectionString = modGlobal.gconnectionstring
            DBCon.Open()
        Catch ex As Exception
        End Try
    End Sub



    Public Sub CloseDestroyConnection()
        If Not DBCon.State = ConnectionState.Closed Then
            DBCon.Close()
        End If

        Try
            DBCon = Nothing
        Catch ex As Exception

        End Try

    End Sub

#End Region
End Class
