

Public Class GenericDA
    Public Shared Function ManageQuery(ByVal arrFieldName() As String, ByVal arrFieldValue() As Object, _
                              ByVal strStoredProcName As String, ByVal Operation As Byte, _
                              Optional ByVal ReturnType As Integer = 0) As Object
        Dim myQuery As New clsQuery
        Try
            Select Case Operation
                'generic fetch
                Case 0
                    Return myQuery.Fetch_Records(arrFieldName, arrFieldValue, _
                             strStoredProcName, Operation)

                    'generic insert into w/o PK/ update
                Case 1
                    myQuery.CreateOpenConnection()
                    myQuery.Par = arrFieldName
                    myQuery.parvalue = arrFieldValue
                    Call myQuery.ExecuteQueryDB(strStoredProcName)
                    myQuery.CloseDestroyConnection()
                Case 2
                    'generic insert into w PK
                    myQuery.CreateOpenConnection()
                    myQuery.Par = arrFieldName
                    myQuery.parvalue = arrFieldValue
                    Call myQuery.ExecuteQueryDB(strStoredProcName, , Operation)
                    Dim pk As String = myQuery.NewPK
                    myQuery.CloseDestroyConnection()
                    Return pk
            End Select
        Catch ex As Exception
            Return Nothing
        Finally
            'myQuery.CloseDestroyConnection()
            myQuery.Dispose()
            'myQuery = Nothing

        End Try

        'myQuery = Nothing
    End Function



End Class
