Imports Swashbuckle.Application
Imports System.Web.Http

Public Class SwaggerConfig
    Public Shared Sub Register(ByVal config As HttpConfiguration)
        ' Swagger konfigürasyonunu yapma
        config.EnableSwagger(Function(c)
                                 c.SingleApiVersion("v1", "My API")

                             End Function).
            EnableSwaggerUi()
    End Sub
End Class
