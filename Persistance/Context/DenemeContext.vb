Imports System.Data.Entity
Imports ClassLibrary1

Public Class DenemeContext
    Inherits DbContext






    Public Sub New()
        MyBase.New("Server=.\SQLEXPRESS;Database=denemedb;Trusted_Connection=True;TrustServerCertificate=True")
    End Sub
    Public Property Products As DbSet(Of Product)
    Public Property Categories As DbSet(Of Category)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        modelBuilder.Configurations.Add(New CategoryMapping)
        modelBuilder.Configurations.Add(New ProductMapping)

    End Sub
    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        ' Bu metod, bağlam oluşturulduğunda çalışır.
        ' Genel ayarları burada ekleyebilirsiniz.
        ' Örneğin, aşağıdaki gibi bağlantı dizesini burada belirleyebilirsiniz.
        ' optionsBuilder.UseSqlServer("Server=.\SQLEXPRESS;Database=denemedb;Trusted_Connection=True;TrustServerCertificate=True")
    End Sub


End Class

