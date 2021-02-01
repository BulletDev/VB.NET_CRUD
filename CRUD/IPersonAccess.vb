Imports System.Data.SqlClient
Imports CRUD

Public Interface IPersonAccess
    Sub DeletePerson(Id As Integer)
    Sub InsertPerson(person As IPersonModel)
    Sub UpdatePerson(person As IPersonModel)
    Function GetPerson() As SqlDataAdapter

End Interface
