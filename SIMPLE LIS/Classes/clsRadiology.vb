Imports System.Data.SqlClient
Public Class clsRadiology

#Region "members and properties"
#Region "Default"

    Public dlabradiologydefaultid As Long
    Public ditemcode As String
    Public dnormalresultdesc As String
    Public ditemcodefilm As String
    Public dqtyfilm As Long


    Public Property Ddlabradiologydefaultid() As Long
        Get
            Return Dlabradiologydefaultid
        End Get
        Set(ByVal value As Long)
            dlabradiologydefaultid = value
        End Set
    End Property
    Public Property Dditemcode() As String
        Get
            Return ditemcode
        End Get
        Set(ByVal value As String)
            ditemcode = value
        End Set
    End Property
    Public Property Ddnormalresultdesc() As String
        Get
            Return dnormalresultdesc
        End Get
        Set(ByVal value As String)
            dnormalresultdesc = value
        End Set
    End Property
    Public Property Dditemcodefilm() As String
        Get
            Return ditemcodefilm
        End Get
        Set(ByVal value As String)
            ditemcodefilm = value
        End Set
    End Property
    Public Property Ddqtyfilm() As Long
        Get
            Return dqtyfilm
        End Get
        Set(ByVal value As Long)
            dqtyfilm = value
        End Set
    End Property

#End Region
#Region "Variables"
    Private operation As Integer
    Public soperation As Integer
    Private mOldlabradiologyid As Long
    Private mlabexaminationno As Long
    Private mresultdescription As String
    Private mpatientrequestdetailno As Long
    Private madmissionid As Long
    Private mitemcode As String
    Private mfilmcount As Integer
    Private mfilmspoil As Integer
    Private mremarks As String
    Private mItemcodeFilm As String

    Private mOldimageid As Long
    Private mimageid As Long
    Private mlabradiologyid As Long
    Private mimage As String
    Private mdescription As String

#End Region
#Region "Properties"
    Public Property Oldlabradiologyid() As Long
        Get
            Return mOldlabradiologyid
        End Get
        Set(ByVal value As Long)
            mOldlabradiologyid = value
        End Set
    End Property
    Public Property labexaminationno() As Long
        Get
            Return mlabexaminationno
        End Get
        Set(ByVal value As Long)
            mlabexaminationno = value
        End Set
    End Property
    Public Property resultdescription() As String
        Get
            Return mresultdescription
        End Get
        Set(ByVal value As String)
            mresultdescription = value
        End Set
    End Property
    Public Property patientrequestdetailno() As Long
        Get
            Return mpatientrequestdetailno
        End Get
        Set(ByVal value As Long)
            mpatientrequestdetailno = value
        End Set
    End Property
    Public Property admissionid() As String
        Get
            Return madmissionid
        End Get
        Set(ByVal value As String)
            madmissionid = value
        End Set
    End Property
    Public Property itemcode() As String
        Get
            Return mitemcode
        End Get
        Set(ByVal value As String)
            mitemcode = value
        End Set
    End Property
    Public Property filmcount() As Long
        Get
            Return mfilmcount
        End Get
        Set(ByVal value As Long)
            mfilmcount = value
        End Set
    End Property
    Public Property filmspoil() As Long
        Get
            Return mfilmspoil
        End Get
        Set(ByVal value As Long)
            mfilmspoil = value
        End Set
    End Property
    Public Property remarks() As String
        Get
            Return mremarks
        End Get
        Set(ByVal value As String)
            mremarks = value
        End Set
    End Property
    Public Property ItemCodeFilm() As String
        Get
            Return mItemcodeFilm
        End Get
        Set(ByVal value As String)
            mItemcodeFilm = value
        End Set
    End Property


    Public Property Oldimageid() As Long
        Get
            Return mOldimageid
        End Get
        Set(ByVal value As Long)
            mOldimageid = value
        End Set
    End Property
    Public Property imageid() As Long
        Get
            Return mimageid
        End Get
        Set(ByVal value As Long)
            mimageid = value
        End Set
    End Property
    Public Property labradiologyid() As Long
        Get
            Return mlabradiologyid
        End Get
        Set(ByVal value As Long)
            mlabradiologyid = value
        End Set
    End Property
    Public Property image() As String
        Get
            Return mimage
        End Get
        Set(ByVal value As String)
            mimage = value
        End Set
    End Property
    Public Property description() As String
        Get
            Return mdescription
        End Get
        Set(ByVal value As String)
            mdescription = value
        End Set
    End Property
#End Region




    '#Region "Result"

    '    '    'Private mlabexaminationno As Long
    '    '    'Private mresultdescription As String
    '    '    'Private mimage As Byte
    '    '    'Private mitemcode As String
    '    '    'Private mfilmcount As Integer
    '    '    'Private mfilmspoil As Integer
    '    '    'Private mremarks As String
    '    '    'Private mItemcodeFilm As String
    '    '    Public Property ItemCodeFilm() As String
    '    '        Get
    '    '            Return mItemcodeFilm
    '    '        End Get
    '    '        Set(ByVal value As String)
    '    '            mItemcodeFilm = value
    '    '        End Set
    '    '    End Property
    '    '    Public Property labexaminationno() As Long
    '    '        Get
    '    '            Return mlabexaminationno
    '    '        End Get
    '    '        Set(ByVal value As Long)
    '    '            mlabexaminationno = value
    '    '        End Set
    '    '    End Property

    '    '    Public Property resultdescription() As String
    '    '        Get
    '    '            Return mresultdescription
    '    '        End Get
    '    '        Set(ByVal value As String)
    '    '            mresultdescription = value
    '    '        End Set
    '    '    End Property
    '    '    Public Property image() As Byte
    '    '        Get
    '    '            Return mimage
    '    '        End Get
    '    '        Set(ByVal value As Byte)
    '    '            mimage = value
    '    '        End Set
    '    '    End Property
    '    '    Public Property itemcode() As String
    '    '        Get
    '    '            Return mitemcode
    '    '        End Get
    '    '        Set(ByVal value As String)
    '    '            mitemcode = value
    '    '        End Set
    '    '    End Property
    '    '    Public Property filmcount() As Integer
    '    '        Get
    '    '            Return mfilmcount
    '    '        End Get
    '    '        Set(ByVal value As Integer)
    '    '            mfilmcount = value
    '    '        End Set
    '    '    End Property

    '    '    Public Property filmspoil() As Integer
    '    '        Get
    '    '            Return mfilmspoil
    '    '        End Get
    '    '        Set(ByVal value As Integer)
    '    '            mfilmspoil = value
    '    '        End Set
    '    '    End Property

    '    '    Public Property remarks() As String
    '    '        Get
    '    '            Return mremarks
    '    '        End Get
    '    '        Set(ByVal value As String)
    '    '            mremarks = value
    '    '        End Set
    '    '    End Property
    '    '#End Region

#End Region

#Region "Methods"
    Public Shared Function genericcls(ByVal soperation As Integer, ByVal search As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As Object = {0, soperation, search}
        Return GenericDA.ManageQuery(strPar, strVal, "spRadiology", 0)
    End Function
    Public Shared Function getRadiologyResults(ByVal varSearch As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search", "officecode"}
        Dim strVal() As Object = {0, 0, varSearch, modGlobal.sourceOfficeCode}

        Return GenericDA.ManageQuery(strPar, strVal, "spRadiology", 0)
    End Function

    Public Shared Function getLabRadiologyDefault(ByVal soperation As Integer, ByVal varSearch As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As Object = {0, soperation, varSearch}

        Return GenericDA.ManageQuery(strPar, strVal, "spLabRadiologyDefault", 0)
    End Function
    Public Shared Function getRadiologyResultDetails(ByVal requestdetailno As String, ByVal isNew As Integer) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As Object = {0, isNew, requestdetailno}
        Return GenericDA.ManageQuery(strPar, strVal, "spRadiology", 0)
    End Function
    Public Shared Function getRadiologyResultDetailsImages(ByVal requestdetailno As String, ByVal isNew As Integer) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As Object = {0, isNew, requestdetailno}
        Return GenericDA.ManageQuery(strPar, strVal, "spRadiology", 0)
    End Function
    Public Shared Function getRadiologist(ByVal vEmployeeID As String) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As Object = {0, 3, vEmployeeID}
        Return GenericDA.ManageQuery(strPar, strVal, "spRadiology", 0)
    End Function
    Public Shared Function getLabResultID(ByVal requestdetailno As String, ByVal isNew As Integer) As DataTable
        Dim strPar() As String = {"operation", "soperation", "search"}
        Dim strVal() As Object = {0, isNew, requestdetailno}
        Return GenericDA.ManageQuery(strPar, strVal, "spRadiology", 0)
    End Function
    Public Shared Function removeImages(ByVal d As String) As Boolean
        Dim myConnection As New clsDBConnection
        Dim okdelete As Boolean = False
        Try
            myConnection.CreateOpenConnection()
        Catch ex As Exception
            Throw New Exception("Could not open the database connection.", ex)
        End Try
        Try
            Dim strSQL As String = "DELETE FROM [dbo].[images] WHERE [imageid] =  " + d + " "
            Dim cmd As New SqlCommand(strSQL, myConnection.GDBConn)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            okdelete = True
        Catch ex As Exception
            Throw New Exception("Could not read the records from the database table.", ex)
        Finally
            Try
                myConnection.CloseDestroyConnection()
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End Try
        Return okdelete
    End Function
    Public Shared Function removeChargeDetails(ByVal d As String) As Boolean
        Dim myConnection As New clsDBConnection
        Dim okdelete As Boolean = False
        Try
            myConnection.CreateOpenConnection()
        Catch ex As Exception
            Throw New Exception("Could not open the database connection.", ex)
        End Try
        Try
            Dim strSQL As String = "DELETE FROM [dbo].[chargedetails] WHERE [chargedetailsid] =  " + d + " "
            Dim cmd As New SqlCommand(strSQL, myConnection.GDBConn)
            cmd.CommandType = CommandType.Text
            cmd.ExecuteNonQuery()
            okdelete = True
        Catch ex As Exception
            Throw New Exception("Could not read the records from the database table.", ex)
        Finally
            Try
                myConnection.CloseDestroyConnection()
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End Try
        Return okdelete
    End Function
    'Public Shared Function getRadiologyRequestInfo(ByVal requestdetailno As String) As DataTable
    '    Dim strPar() As String = {"operation", "soperation", "search"}
    '    Dim strVal() As Object = {0, 1, requestdetailno}

    '    Return GenericDA.ManageQuery(strPar, strVal, "spRadiology", 0)
    'End Function

    'Public Function Save(ByVal isNew As Boolean) As DataTable
    '    Dim operation As Integer

    '    If isNew Then
    '        operation = 1
    '    Else
    '        operation = 2
    '    End If

    '    'Dim strPar() As String = {"operation", _
    '    '                            "soperation", _
    '    '                            "labexaminationno", _
    '    '                            "resultdescription", _
    '    '                            "image", _
    '    '                            "itemcode", _
    '    '                            "filmcount", _
    '    '                            "filmspoil", _
    '    '                            "remarks", "ItemCodeFilm"}

    '    'Dim strVal() As Object = {operation, 0, varlabexamno, _
    '    '                          resultdescription, _
    '    '                          image, _
    '    '                          itemcode, _
    '    '                          filmcount, _
    '    '                          filmspoil, _
    '    '                          remarks, ItemCodeFilm}
    '    If isNew Then
    '        operation = 1
    '    Else
    '        operation = 2
    '    End If
    '    Dim strPar() As String = {"@operation", "@soperation", "@Oldlabradiologyid", "@labexaminationno", "@resultdescription", "@patientrequestdetailno", _
    '                              "@admissionid", "@itemcode", "@filmcount", "@filmspoil", "@remarks", "@itemcodefilm"}
    '    Dim strVal() As String = {Me.operation, 0, Me.Oldlabradiologyid, Me.newlabexaminationno, Me.newresultdescription, Me.patientrequestdetailno, _
    '                              Me.admissionid, Me.newitemcode, Me.newfilmcount, Me.newfilmspoil, Me.newremarks, Me.newItemCodeFilm}
    '    Return GenericDA.ManageQuery(strPar, strVal, "spRadiology", 2)
    'End Function
    Public Function Save(ByVal isNew As Boolean) As String
        If isNew Then
            operation = 1
        Else
            operation = 2
        End If
        Dim strPar() As String = {"@operation", "@soperation", "@Oldlabradiologyid", "@labexaminationno", "@resultdescription", "@patientrequestdetailno", _
                                  "@admissionid", "@itemcode", "@filmcount", "@filmspoil", "@remarks", "@itemcodefilm"}
        Dim strVal() As String = {Me.operation, Me.soperation, Me.Oldlabradiologyid, Me.labexaminationno, Me.resultdescription, Me.patientrequestdetailno, _
                                  Me.admissionid, Me.itemcode, Me.filmcount, Me.filmspoil, Me.remarks, Me.ItemCodeFilm}
        Return GenericDA.ManageQuery(strPar, strVal, "spRadiology", 2)
    End Function
    Public Function saveImage(ByVal isNew As Boolean) As String
        If isNew Then
            operation = 1
        Else
            operation = 2
        End If
        Dim strPar() As String = {"@operation", "@Oldimageid", "@imageid", "@labradiologyid", "@image", "@description"}
        Dim strVal() As String = {Me.operation, Me.Oldimageid, Me.imageid, Me.labradiologyid, Me.image, Me.description}
        Return GenericDA.ManageQuery(strPar, strVal, "spimages", 2)
    End Function
    Public Function SaveLabDefault(ByVal isNew As Boolean) As String
        If isNew Then
            operation = 1
        Else
            operation = 2
        End If
        Dim strPar() As String = {"@operation", "@labradiologydefaultid", "@itemcode", "@normalresultdesc", "@itemcodefilm", _
                                  "@qtyfilm "}
        Dim strVal() As String = {Me.operation, Me.Ddlabradiologydefaultid, Me.Dditemcode, Me.Ddnormalresultdesc, Me.Dditemcodefilm, _
                                  Me.Ddqtyfilm}
        Return GenericDA.ManageQuery(strPar, strVal, "spLabRadiologyDefault", 2)
    End Function
#End Region
End Class
