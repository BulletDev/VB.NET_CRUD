Public Class FormPerson

    Dim _personLogic As IPersonLogic = New PersonLogic
    Private Sub FormPerson_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ClearFields()
        EnableFields()
        btnSave.Text = "Save"
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            Dim person As IPersonModel = New PersonModel()
            person.FirstName = txtFirstName.Text
            person.MiddleName = txtMiddleName.Text
            person.LastName = txtLastName.Text
            person.Age = numAge.Value
            person.Gender = cboGender.SelectedItem.ToString()
            person.Address = txtAddress.Text
            person.ContactNumber = txtContactNumber.Text
            _personLogic.InsertPerson(person)
            btnSave.Text = "Save"
            ClearFields()
            DisableFields()
            LoadData()
            MessageBox.Show("Person successully added")
        ElseIf btnSave.Text = "Update" Then
            Dim Id = personGridView.CurrentRow.Cells(0).Value
            Dim person As IPersonModel = New PersonModel()
            person.Id = Id
            person.FirstName = txtFirstName.Text
            person.MiddleName = txtMiddleName.Text
            person.LastName = txtLastName.Text
            person.Age = numAge.Value
            person.Gender = cboGender.SelectedItem.ToString()
            person.Address = txtAddress.Text
            person.ContactNumber = txtContactNumber.Text
            _personLogic.UpdatePerson(person)
            btnSave.Text = "Save"
            ClearFields()
            DisableFields()
            LoadData()
            MessageBox.Show("Person successully updated")
        End If
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
         Dim Id = personGridView.CurrentRow.Cells(0).Value
        txtFirstName.Text = personGridView.CurrentRow.Cells(1).Value
        txtMiddleName.Text = personGridView.CurrentRow.Cells(2).Value
        txtLastName.Text = personGridView.CurrentRow.Cells(3).Value
        numAge.Value = personGridView.CurrentRow.Cells(4).Value
        cboGender.Text = personGridView.CurrentRow.Cells(5).Value
        txtAddress.Text = personGridView.CurrentRow.Cells(6).Value
        txtContactNumber.Text = personGridView.CurrentRow.Cells(7).Value
        EnableFields()
        btnSave.Text = "Update"
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If personGridView.SelectedRows.Count > 0 Or personGridView.SelectedCells.Count > 0 Then
            If MessageBox.Show("Confirm Delete?", "Delete", MessageBoxButtons.YesNo) = MsgBoxResult.Yes Then
                Dim Id = personGridView.CurrentRow.Cells(0).Value
                _personLogic.DeletePerson(Id)
                LoadData()
            End If
        End If
    End Sub
    Private Sub EnableFields()
        txtFirstName.Enabled = True
        txtMiddleName.Enabled = True
        txtLastName.Enabled = True
        numAge.Enabled = True
        cboGender.Enabled = True
        txtAddress.Enabled = True
        txtContactNumber.Enabled = True
        btnSave.Enabled = True
    End Sub
    Private Sub DisableFields()
        txtFirstName.Enabled = False
        txtMiddleName.Enabled = False
        txtLastName.Enabled = False
        numAge.Enabled = False
        cboGender.Enabled = False
        txtAddress.Enabled = False
        txtContactNumber.Enabled = False
        btnSave.Enabled = False
    End Sub
    Private Sub ClearFields()
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        numAge.Value = 0
        cboGender.Text = ""
        txtAddress.Text = ""
        txtContactNumber.Text = ""
    End Sub
    Private Sub LoadData()
        personGridView.DataSource = _personLogic.GetPerson()
        personGridView.Columns(0).IsVisible = False
        personGridView.Columns(1).HeaderText = "First Name"
        personGridView.Columns(1).TextAlignment = ContentAlignment.MiddleCenter
        personGridView.Columns(2).HeaderText = "Middle Name"
        personGridView.Columns(2).TextAlignment = ContentAlignment.MiddleCenter
        personGridView.Columns(3).HeaderText = "Last Name"
        personGridView.Columns(3).TextAlignment = ContentAlignment.MiddleCenter
        personGridView.Columns(4).HeaderText = "Age"
        personGridView.Columns(4).TextAlignment = ContentAlignment.MiddleCenter
        personGridView.Columns(5).HeaderText = "Gender"
        personGridView.Columns(5).TextAlignment = ContentAlignment.MiddleCenter
        personGridView.Columns(6).HeaderText = "Address"
        personGridView.Columns(6).TextAlignment = ContentAlignment.MiddleCenter
        personGridView.Columns(7).HeaderText = "Contact Number"
        personGridView.Columns(7).TextAlignment = ContentAlignment.MiddleCenter
        personGridView.Refresh()
    End Sub
End Class
