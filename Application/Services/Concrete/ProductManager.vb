Imports ClassLibrary1
Imports Persistance

Public Class ProductManager
    Implements IProductService(Of Product)

    Private ReadOnly _uow As UnitOfWork
    Sub New(uow As IUnitOfWork)
        _uow = uow
    End Sub

    Public Async Function GetAllAsync() As Task(Of List(Of Product)) Implements IGenericService(Of Product).GetAllAsync

        Dim Product = Await _uow.GetRepository(Of Product)().GetAllAsync()

        Dim result = Product.ToList()

        Return result


    End Function

    Public Async Function Add(entity As Product) As Task(Of Boolean) Implements IGenericService(Of Product).Add
        _uow.GetRepository(Of Product)().Add(entity)

        Dim Result = Await _uow.CommitAsync()

        Return Result

    End Function
End Class

