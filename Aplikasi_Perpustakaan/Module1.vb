Imports System.Data.SqlClient
Module Module1
    Public CONN As SqlConnection
    Public DA As SqlDataAdapter
    Public DS As New DataSet
    Public CMD As SqlCommand
    Public DR As SqlDataReader
    Public STR As String

    Sub Koneksi()
        STR = "data source=susilawati-PC;initial catalog=Perpus;integrated security =true"
        CONN = New SqlConnection(STR)
        If CONN.State = ConnectionState.Closed Then
            CONN.Open()
        End If

    End Sub
End Module
