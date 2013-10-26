namespace MyLaptopSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManufacturerIdtoLaptopmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Laptops", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.Laptops", new[] { "Manufacturer_Id" });
            RenameColumn(table: "dbo.Laptops", name: "Manufacturer_Id", newName: "ManufacturerId");
            AlterColumn("dbo.Laptops", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Laptops", "ManufacturerId");
            AddForeignKey("dbo.Laptops", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Laptops", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Laptops", new[] { "ManufacturerId" });
            AlterColumn("dbo.Laptops", "ManufacturerId", c => c.Int());
            RenameColumn(table: "dbo.Laptops", name: "ManufacturerId", newName: "Manufacturer_Id");
            CreateIndex("dbo.Laptops", "Manufacturer_Id");
            AddForeignKey("dbo.Laptops", "Manufacturer_Id", "dbo.Manufacturers", "Id");
        }
    }
}
