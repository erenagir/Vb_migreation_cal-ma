Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration
Imports ClassLibrary1

Public MustInherit Class BaseEntityMapping(Of T As BaseEntity)
    Inherits EntityTypeConfiguration(Of T)


    Public MustOverride Sub ConfigureDerivedEntity(builder As EntityTypeConfiguration(Of T))

    Public Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Dim builder = modelBuilder.Entity(Of T)()

        builder.HasKey(Function(e) e.Id)
        builder.Property(Function(e) e.Id).
            HasColumnName("ID")

        ConfigureDerivedEntity(builder)
    End Sub
End Class
