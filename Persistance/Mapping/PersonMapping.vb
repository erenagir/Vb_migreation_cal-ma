

Imports ClassLibrary1

Public Class PersonMapping
    Inherits BaseEntityMapping(Of Person)

    Public Overrides Sub ConfigureDerivedEntity(builder As Entity.ModelConfiguration.EntityTypeConfiguration(Of Person))
        builder.Property(Function(e) e.Name) _
            .HasColumnName("NAME") _
            .HasColumnType("nvarchar(50)")
        builder.Property(Function(e) e.Surname) _
            .HasColumnName("SURNAME") _
            .HasColumnType("nvarchar(50)")
        builder.ToTable("PERSON")
    End Sub
End Class