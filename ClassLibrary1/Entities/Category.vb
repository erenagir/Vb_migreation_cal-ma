Public Class Category
    Inherits BaseEntity

    Public Property Name As String
    Public Property Products As ICollection(Of Product)
End Class
