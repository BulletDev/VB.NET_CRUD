Imports System.Data.SqlClient

Public Class Database

    Public Property myConnection As New SqlConnection("Server=.;Database=people;Trusted_Connection=True;")

    Public Sub New()
        If myConnection.State = ConnectionState.Closed Then
            myConnection.Open()
        End If
    End Sub

End Class
