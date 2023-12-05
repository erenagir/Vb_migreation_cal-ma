Imports ClassLibrary1
Imports System.Data.Entity.ModelConfiguration

Public Class ProductMapping
    Inherits BaseEntityMapping(Of Product)





    Public Overrides Sub ConfigureDerivedEntity(builder As EntityTypeConfiguration(Of Product))

        builder.ToTable("PRODUCT")


        builder.Property(Function(e) e.Name).HasColumnName("NAME").HasColumnType("nvarchar(50)")
        builder.Property(Function(e) e.CategoryId).HasColumnName("CATEGORY_ID")
        builder.Property(Function(e) e.Stock).HasColumnName("STOCK")
        builder.Property(Function(e) e.Detail).HasColumnName("DETAIL").HasColumnType("nvarchar(100)")
        builder.HasOptional(Function(x) x.Category).WithMany(Function(x) x.Products).HasForeignKey(Function(x) x.CategoryId)


    End Sub

End Class
