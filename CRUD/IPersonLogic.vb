Imports CRUD

Public Interface IPersonLogic
    Sub DeletePerson(Id As Integer)
    Sub InsertPerson(person As IPersonModel)
    Sub UpdatePerson(person As IPersonModel)
    Function GetPerson() As DataTable

End Interface
