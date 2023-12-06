Imports ClassLibrary1
Imports System.Data.Entity.ModelConfiguration

Public Class ProductMapping
    Inherits BaseEntityMapping(Of Product)





    Public Overrides Sub ConfigureDerivedEntity(builder As EntityTypeConfiguration(Of Product))

        builder.ToTable("PRODUCT")


        builder.Property(Function(e) e.Name) _
            .HasColumnName("NAMEE") _
            .HasColumnType("nvarchar(50)")
        builder.Property(Function(e) e.CategoryId) _
            .HasColumnName("CATEGORY_ID")
        builder.Property(Function(e) e.Stock) _
               .HasColumnName("STOCK")
        builder.Property(Function(e) e.Detail) _
            .HasColumnName("DETAIL") _
            .HasColumnType("nvarchar(100)")
        builder.HasOptional(Function(x) x.Category) _
            .WithMany(Function(x) x.Products) _
            .HasForeignKey(Function(x) x.CategoryId)


    End Sub

End Class
