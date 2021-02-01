Public Class PersonLogic
    Implements IPersonLogic

    Dim _personAccess As IPersonAccess = New PersonAccess
    Public Function GetPerson() As DataTable Implements IPersonLogic.GetPerson
        Dim dt As New DataTable
        _personAccess.GetPerson().Fill(dt)
        Return dt
    End Function
    Public Sub InsertPerson(person As IPersonModel) Implements IPersonLogic.InsertPerson
        _personAccess.InsertPerson(person)
    End Sub
    Public Sub UpdatePerson(person As IPersonModel) Implements IPersonLogic.UpdatePerson
        _personAccess.UpdatePerson(person)
    End Sub
    Public Sub DeletePerson(Id As Integer) Implements IPersonLogic.DeletePerson
        _personAccess.DeletePerson(Id)
    End Sub
End Class
