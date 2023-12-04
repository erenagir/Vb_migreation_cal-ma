Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class m2
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.PersonDetails",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .PersonId = c.Long(nullable := False),
                        .Email = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.People",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Name = c.String(),
                        .Surname = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.People")
            DropTable("dbo.PersonDetails")
        End Sub
    End Class
End Namespace
