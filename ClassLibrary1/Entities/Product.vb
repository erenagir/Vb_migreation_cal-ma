Public Class Product
    Inherits BaseEntity
    Public Property Name As String
    Public Property Detail As String
    Public Property Stock As Decimal
    Public Property CategoryId As Int64

    Public Property Category As Category
End Class
