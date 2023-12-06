Imports ClassLibrary1

Public Class CategoryMapping
    Inherits BaseEntityMapping(Of Category)

    Public Overrides Sub ConfigureDerivedEntity(builder As Entity.ModelConfiguration.EntityTypeConfiguration(Of Category))
        builder.ToTable("CATEGORY")


        builder.Property(Function(e) e.Name) _
            .HasColumnName("NAMEE") _
            .HasColumnType("nvarchar(150)")
    End Sub
End Class
