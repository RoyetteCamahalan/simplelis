
Public Class Patient
    Public Property patientid As Long
    Public Property firstname As String
    Public Property middlename As String
    Public Property lastname As String
    Public Property suffixname As String

    Private _patientfullname As String
    Public Property patientfullname As String
        Get
            If _patientfullname = "" Then
                _patientfullname = String.Format("{0} {1} {2} {3}", firstname, middlename, lastname, suffixname)
            End If
            Return _patientfullname
        End Get
        Set(value As String)
            _patientfullname = value
        End Set
    End Property

    Public Property birthdate As Date
    Public Property mobileno As String
    Public Property email As String
    Public Property hospitalno As String
    Public Property homeaddress As String
    Public Property civilstatus As String
    Public Property nationality As String
    Public Property height As String
    Public Property weight As String
End Class
