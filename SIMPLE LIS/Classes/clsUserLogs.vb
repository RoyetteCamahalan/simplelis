Public Class clsUserLogs
#Region "Variables"
    Dim flogid As Integer
    Dim freferenceno As String
    Dim fmodule As String
    Dim fusername As String
    Dim faction As String
    Dim flogdate As Date

    Dim operation As Integer
#End Region

#Region "Properties"
    Public Property logid() As Integer
        Get
            Return flogid
        End Get
        Set(ByVal value As Integer)
            flogid = value
        End Set
    End Property

    Public Property referenceno() As String
        Get
            Return freferenceno
        End Get
        Set(ByVal value As String)
            freferenceno = value
        End Set
    End Property

    Public Property usermodule() As String
        Get
            Return fmodule
        End Get
        Set(ByVal value As String)
            fmodule = value
        End Set
    End Property

    Public Property username() As String
        Get
            Return fusername
        End Get
        Set(ByVal value As String)
            fusername = value
        End Set
    End Property

    Public Property action() As String
        Get
            Return faction
        End Get
        Set(ByVal value As String)
            faction = value
        End Set
    End Property

    Public Property logdate() As Date
        Get
            Return flogdate
        End Get
        Set(ByVal value As Date)
            flogdate = value
        End Set
    End Property
#End Region

#Region "Methods"
    Public Shared Function getUserlogs(ByVal strSearch As String, _
                                         ByVal dateFrom As Date, _
                                         ByVal dateTo As Date, _
                                       Optional ByVal suboperation As Integer = 0) As DataTable
        Dim strPar() As String = {"operation", "search", "datefrom", "dateto", "suboperation"}
        Dim strVal() As String = {0, strSearch, dateFrom, dateTo, suboperation}

        Return GenericDA.ManageQuery(strPar, strVal, "spUserLog", 0)
    End Function
    Public Shared Function logsFinder(ByVal search As String, ByVal dateFrom As DateTime, ByVal dateTo As DateTime, Optional ByVal soperation As Integer = 0) As DataTable
        Dim strPar() As String = {"@operation", "@soperation", "search", "datefrom", "dateto"}
        Dim strVal() As String = {0, soperation, search, dateFrom, dateTo}
        Return GenericDA.ManageQuery(strPar, strVal, "spUserLog", 0)
    End Function
    Public Shared Function logsFindermonthly(ByVal search As String, ByVal dateFrom As Long, ByVal dateTo As Long, Optional ByVal soperation As Integer = 0, Optional ByVal yr As Long = 0) As DataTable
        Dim strPar() As String = {"@operation", "@soperation", "search", "@datefrom1", "@dateto1", "@dateyr"}
        Dim strVal() As String = {0, soperation, search, dateFrom, dateTo, yr}
        Return GenericDA.ManageQuery(strPar, strVal, "spUserLog", 0)
    End Function
    Public Sub saveLogs()
        Dim strPar() As String = {"@operation", _
                                  "@referenceno", _
                                  "@module", _
                                  "@logdate", _
                                  "@username", _
                                  "@action"}
        Dim strVal() As String = {1, _
                                  referenceno, _
                                  usermodule, _
                                  logdate, _
                                  username, _
                                  action}
        GenericDA.ManageQuery(strPar, strVal, "spUserLog", 1)
    End Sub
#End Region
End Class
