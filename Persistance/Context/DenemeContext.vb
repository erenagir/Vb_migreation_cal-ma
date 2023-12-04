Imports System.Data.Entity
Imports ClassLibrary1

Public Class DenemeContext
    Inherits DbContext




    Public Property Persons As DbSet(Of Person)
    Public Property PersonDetails As DbSet(Of PersonDetail)


    Public Sub New()
        MyBase.New("Server=.\SQLEXPRESS;Database=denemedb;Trusted_Connection=True;TrustServerCertificate=True")
    End Sub
    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        modelBuilder.Configurations.Add(New PersonMapping)
        modelBuilder.Configurations.Add(New PersonDetailMapping)

    End Sub





End Class

