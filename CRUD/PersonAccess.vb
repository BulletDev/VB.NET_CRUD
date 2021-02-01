
Imports System.Data.SqlClient

Public Class PersonAccess
    Implements IPersonAccess

    Dim _sql As String
    Dim _da As SqlDataAdapter
    Dim _dt As New DataTable()
    Dim _db As Database
    Dim _cmd As New SqlCommand
    Public Function GetPerson() As SqlDataAdapter Implements IPersonAccess.GetPerson
        Dim _db = New Database()
        _sql = "SELECT * FROM dbo.People"
        _da = New SqlDataAdapter(_sql, _db.myConnection)
        _da.Fill(_dt)
        Return _da
    End Function
    Public Sub InsertPerson(person As IPersonModel) Implements IPersonAccess.InsertPerson
        _db = New Database()
        _sql = "INSERT INTO dbo.People(FirstName, MiddleName, LastName, Age, Gender, Address, ContactNumber) " &
                "VALUES(@IFirstName, @IMiddleName, @ILastName, @IAge, @IGender, @IAddress, @IContactNumber)"
        _cmd.CommandText = _sql
        _cmd.Parameters.AddWithValue("@IFirstName", person.FirstName)
        _cmd.Parameters.AddWithValue("@IMiddleName", person.MiddleName)
        _cmd.Parameters.AddWithValue("@ILastName", person.LastName)
        _cmd.Parameters.AddWithValue("@IAge", person.Age)
        _cmd.Parameters.AddWithValue("@IGender", person.Gender)
        _cmd.Parameters.AddWithValue("@IAddress", person.Address)
        _cmd.Parameters.AddWithValue("@IContactNumber", person.ContactNumber)
        _cmd.Connection = _db.myConnection
        _cmd.ExecuteNonQuery()
    End Sub
    Public Sub UpdatePerson(person As IPersonModel) Implements IPersonAccess.UpdatePerson
        _db = New Database()
        _sql = "UPDATE dbo.People " &
                "SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName," &
                "Age = @Age, Gender = @Gender, Address = @Address, ContactNumber = @ContactNumber " &
                "WHERE Id=@Id"
        _cmd.CommandText = _sql
        _cmd.Parameters.AddWithValue("@FirstName", person.FirstName)
        _cmd.Parameters.AddWithValue("@MiddleName", person.MiddleName)
        _cmd.Parameters.AddWithValue("@LastName", person.LastName)
        _cmd.Parameters.AddWithValue("@Age", person.Age)
        _cmd.Parameters.AddWithValue("@Gender", person.Gender)
        _cmd.Parameters.AddWithValue("@Address", person.Address)
        _cmd.Parameters.AddWithValue("@ContactNumber", person.ContactNumber)
        _cmd.Parameters.AddWithValue("@Id", person.Id)
        _cmd.Connection = _db.myConnection
        _cmd.ExecuteNonQuery()
    End Sub

    Public Sub DeletePerson(Id As Integer) Implements IPersonAccess.DeletePerson
        _db = New Database()
        _sql = "DELETE FROM dbo.People WHERE Id=@Id"
        _cmd.CommandText = _sql
        _cmd.Parameters.AddWithValue("@Id", Id)
        _cmd.Connection = _db.myConnection
        _cmd.ExecuteNonQuery()
    End Sub

End Class
