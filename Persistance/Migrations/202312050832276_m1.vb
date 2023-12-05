Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class m1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Categories",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Name = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.Products",
                Function(c) New With
                    {
                        .Id = c.Long(nullable := False, identity := True),
                        .Name = c.String(),
                        .Detail = c.String(),
                        .Stock = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .CategoryId = c.Long(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Categories", Function(t) t.CategoryId, cascadeDelete := True) _
                .Index(Function(t) t.CategoryId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories")
            DropIndex("dbo.Products", New String() { "CategoryId" })
            DropTable("dbo.Products")
            DropTable("dbo.Categories")
        End Sub
    End Class
End Namespace
