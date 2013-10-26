namespace LibrarySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovecategoryId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Books", name: "CategoryId", newName: "Category_Id");
            AlterColumn("dbo.Books", "Category_Id", c => c.Int());
            CreateIndex("dbo.Books", "Category_Id");
            AddForeignKey("dbo.Books", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "Category_Id" });
            AlterColumn("dbo.Books", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Books", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.Books", "CategoryId");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
