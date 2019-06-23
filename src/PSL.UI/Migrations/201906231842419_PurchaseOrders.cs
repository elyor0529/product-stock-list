namespace PSL.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "ProductId", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "ProductId" });
            CreateTable(
                "dbo.PurchaseInOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(),
                        ProductId = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId)
                .Index(t => t.PurchaseId)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Purchases", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Purchases", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "ProductId", c => c.Int());
            DropForeignKey("dbo.PurchaseInOrders", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseInOrders", "ProductId", "dbo.Products");
            DropIndex("dbo.PurchaseInOrders", new[] { "ProductId" });
            DropIndex("dbo.PurchaseInOrders", new[] { "PurchaseId" });
            DropColumn("dbo.Purchases", "TotalAmount");
            DropTable("dbo.PurchaseInOrders");
            CreateIndex("dbo.Purchases", "ProductId");
            AddForeignKey("dbo.Purchases", "ProductId", "dbo.Products", "Id");
        }
    }
}
