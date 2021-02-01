Public Class PersonModel
    Implements IPersonModel

    Public Property Id() As Integer Implements IPersonModel.Id
    Public Property FirstName() As String Implements IPersonModel.FirstName
    Public Property MiddleName() As String Implements IPersonModel.MiddleName
    Public Property LastName() As String Implements IPersonModel.LastName
    Public Property Age() As Integer Implements IPersonModel.Age
    Public Property Gender() As String Implements IPersonModel.Gender
    Public Property Address() As String Implements IPersonModel.Address
    Public Property ContactNumber() As String Implements IPersonModel.ContactNumber

End Class
