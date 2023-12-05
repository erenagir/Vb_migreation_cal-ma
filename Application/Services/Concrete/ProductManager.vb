Imports ClassLibrary1

Public Class ProductManager
    Implements IProductService(Of Product)

    Private ReadOnly _uow As IUnitOfWork
    Sub New(uow As IUnitOfWork)
        _uow = uow
    End Sub

    Public Async Function GetAllAsync() As Task(Of List(Of Product)) Implements IGenericService(Of Product).GetAllAsync
        Return Await _uow.GetRepository(Of Product)().GetAllAsync()

    End Function

    Public Function Add(entity As Product) As Object Implements IGenericService(Of Product).Add
        Throw New NotImplementedException()
    End Function
End Class
