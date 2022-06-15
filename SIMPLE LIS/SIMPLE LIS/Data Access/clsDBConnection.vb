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

            gServername = ConfigurationManager.AppSettings("gServername")
            gDatabasename = ConfigurationManager.AppSettings("gDatabasename")
            gUsername = ConfigurationManager.AppSettings("gUsername")
            gPassword = Decrypt(ConfigurationManager.AppSettings("gPassword"))
            gAuthType = ConfigurationManager.AppSettings("gAuthType")


            Dim ConnectionString As String
            If gAuthType = 1 Then
                ConnectionString = "Data Source=" & gServername & _
                                        ";Database=" & gDatabasename & _
                                        ";User ID=" & gUsername & _
                                        ";Password=" & gPassword & "; Pooling=True; Max Pool Size=30;Min Pool Size=0; Pooling=True;Connect Timeout=90;"


            Else
                ConnectionString = "Data Source=" & gServername & ";Initial Catalog=" & gDatabasename & ";Trusted_Connection=True;Connection Timeout=60"

            End If
            DBCon.ConnectionString = ConnectionString
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

    Public Function Decrypt(ByVal constring As String) As String
        Dim KEY_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
        Dim IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC

        Dim enc As System.Text.UTF8Encoding
        Dim decryptor As ICryptoTransform

        enc = New System.Text.UTF8Encoding
        decryptor = symmetricKey.CreateDecryptor(KEY_128, IV_128)

        Dim cypherTextBytes As Byte() = Convert.FromBase64String(constring)
        Dim memoryStream As MemoryStream = New MemoryStream(cypherTextBytes)
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
        Dim plainTextBytes(cypherTextBytes.Length) As Byte
        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
        memoryStream.Close()
        cryptoStream.Close()
        Return enc.GetString(plainTextBytes, 0, decryptedByteCount)
    End Function
#End Region
End Class
