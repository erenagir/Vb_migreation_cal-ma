Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq.Expressions
Imports System.Runtime.Remoting.Messaging
Imports ClassLibrary1

Public Class Repository(Of T As BaseEntity)
    Implements IRepository(Of T)

    Private ReadOnly _context As DbContext
    Private ReadOnly _dbSet As DbSet(Of T)

    Public Sub New(context As DbContext)
        _context = context
        _dbSet = _context.Set(Of T)()
    End Sub

    Public Sub Add(entity As T) Implements IRepository(Of T).Add
        _dbSet.Add(entity)
    End Sub

    Public Sub Delete(entity As T) Implements IRepository(Of T).Delete
        _dbSet.Remove(entity)
    End Sub

    Public Sub Update(entity As T) Implements IRepository(Of T).Update
        _dbSet.AddOrUpdate(entity)
    End Sub

    Public Async Function GetAllAsync(ParamArray includeColumns() As String) As Task(Of IQueryable(Of T)) Implements IRepository(Of T).GetAllAsync

        Dim query As IQueryable(Of T) = _dbSet
        If includeColumns.Any() Then
            For Each includecolumn In includeColumns
                query = _dbSet.Include(includecolumn)
            Next
        End If
        Return Await Task.FromResult(query)
    End Function

    Public Async Function GetByFilterAsync(filter As Expression(Of Func(Of T, Boolean)), ParamArray includeColumns() As String) As Task(Of IQueryable(Of T)) Implements IRepository(Of T).GetByFilterAsync
        Dim query As IQueryable(Of T) = _dbSet
        If includeColumns.Any() Then
            For Each includecolumn In includeColumns
                query = _dbSet.Include(includecolumn)
            Next
        End If
        Return Await Task.FromResult(query.Where(filter))
    End Function

    Public Async Function GetSingleByFilterAsyn(filter As Expression(Of Func(Of T, Boolean)), ParamArray includeColumns() As String) As Task(Of T) Implements IRepository(Of T).GetSingleByFilterAsyn
        Dim query As IQueryable(Of T) = _dbSet
        If includeColumns.Any() Then
            For Each includecolumn In includeColumns
                query = _dbSet.Include(includecolumn)
            Next
        End If
        Return Await query.FirstOrDefaultAsync(filter)
    End Function

    Public Async Function AnyAsync(filter As Expression(Of Func(Of T, Boolean))) As Task(Of Boolean) Implements IRepository(Of T).AnyAsync
        Dim query As IQueryable(Of T) = _dbSet
        Return Await query.AnyAsync(filter)
    End Function
End Class
