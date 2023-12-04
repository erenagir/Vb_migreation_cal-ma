Imports ClassLibrary1


Public Class PersonDetailMapping
    Inherits BaseEntityMapping(Of PersonDetail)

    Public Overrides Sub ConfigureDerivedEntity(builder As Entity.ModelConfiguration.EntityTypeConfiguration(Of PersonDetail))
        builder.Property(Function(e) e.Email) _
            .HasColumnName("EMAIL") _
            .HasColumnType("nvarchar(150)")
        builder.Property(Function(e) e.PersonId) _
           .HasColumnName("PERSON_ID")

        ' builder.HasOptional(Function(e) e.Person).WithOptionalDependent(Function(e) e.PersonDetail).Map(Function(e) e.MapKey("PersonId"))


        '  HasRequired(Function(t) t.Person).WithMany(Function(p) p.PersonDetail).HasForeignKey(Function(t) t.PersonId)

    End Sub
End Class
