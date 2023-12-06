Imports System.Linq.Expressions

Public Interface IRepository(Of T As BaseEntity)

    'Function GetAllAsync() As Task(Of List(Of T))
    Function GetAllAsync(ParamArray includeColumns As String()) As Task(Of IQueryable(Of T))
    Function GetByFilterAsync(filter As Expression(Of Func(Of T, Boolean)), ParamArray includeColumns As String()) As Task(Of IQueryable(Of T))
    Function GetSingleByFilterAsyn(filter As Expression(Of Func(Of T, Boolean)), ParamArray includeColumns As String()) As Task(Of T)
    Function AnyAsync(filter As Expression(Of Func(Of T, Boolean))) As Task(Of Boolean)
    Sub Add(entity As T)
    Sub Delete(entity As T)
    Sub Update(entity As T)





End Interface
