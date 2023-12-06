Imports ClassLibrary1

Public Interface IGenericService(Of T As BaseEntity)


    Function GetAllAsync() As Task(Of List(Of T))
    Function Add(entity As T) As Task(Of Boolean)

End Interface
