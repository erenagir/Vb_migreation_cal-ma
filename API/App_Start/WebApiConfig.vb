Imports System.Data.Entity
Imports System.Web.Http
Imports System.Web.UI.WebControls.Expressions
Imports Application
Imports ClassLibrary1
Imports Persistance
Imports Unity
Imports Unity.WebApi

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services


        Dim container As New UnityContainer()

        container.RegisterType(Of IUnitOfWork, UnitOfWork)
        container.RegisterType(GetType(IRepository(Of)), GetType(Repository(Of)))
        container.RegisterType(Of IProductService(Of Product), ProductManager)
        container.RegisterType(Of DbContext, DenemeContext)()





        config.DependencyResolver = New UnityDependencyResolver(container)




        ' Web API routes
        config.MapHttpAttributeRoutes()

        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )
    End Sub
End Module
