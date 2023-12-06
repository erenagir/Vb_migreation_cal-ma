Imports System.Runtime.CompilerServices
Imports ClassLibrary1

Public Class UnitOfWork
    Implements IUnitOfWork

    Private _repositories As New Dictionary(Of Type, Object)()
    Private ReadOnly _context As DenemeContext

    Sub New(_contexy As DenemeContext)
        _context = _contexy
        _repositories = New Dictionary(Of Type, Object)
    End Sub





    Public Async Function CommitAsync() As Task(Of Boolean) Implements IUnitOfWork.CommitAsync
        Dim result As Boolean = False
        Using transaction = _context.Database.BeginTransaction()
            Try
                Await _context.SaveChangesAsync()
                transaction.Commit()
                result = True
            Catch ex As Exception

                transaction.Rollback()
                Throw
            End Try

        End Using
        Return result
    End Function

    Public Function GetRepository(Of T As BaseEntity)() As IRepository(Of T) Implements IUnitOfWork.GetRepository
        If _repositories.ContainsKey(GetType(IRepository(Of T))) Then
            Return DirectCast(_repositories(GetType(IRepository(Of T))), IRepository(Of T))

        End If
        Dim repo As IRepository(Of T) = New Repository(Of T)(_context)
        _repositories.Add(GetType(IRepository(Of T)), repo)
        Return repo
    End Function



End Class
