﻿Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.Http
Imports Application
Imports ClassLibrary1

Public Class ProductController
    Inherits ApiController
    Private ReadOnly _service As ProductManager

    Public Sub New(service As IProductService(Of Product))
        _service = service
    End Sub
    ' GET api/<controller>
    <HttpGet, Route("123")>
    Public Async Function GetValues() As Task(Of List(Of Product))

        Dim result = Await _service.GetAllAsync()

        Return result

    End Function

    ' GET api/<controller>/5
    <HttpGet, Route("product/GetbyId/{id}")>
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/<controller>
    Public Async Function PostValue(<FromBody> ByVal value As Product) As Task(Of Boolean)
        Dim Response = Await _service.Add(value)

        Return Response
    End Function

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
