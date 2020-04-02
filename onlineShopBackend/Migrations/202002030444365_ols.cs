namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ols : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.deliveryModels",
                c => new
                    {
                        deliveryID = c.Int(nullable: false, identity: true),
                        orderID = c.Int(nullable: false),
                        status = c.String(),
                        deliveryMan = c.String(),
                        deliveryMan_phone = c.String(),
                    })
                .PrimaryKey(t => t.deliveryID);
            
            CreateTable(
                "dbo.OrderModels",
                c => new
                    {
                        orderID = c.Int(nullable: false, identity: true),
                        clientID = c.Int(nullable: false),
                        orderDate = c.DateTime(nullable: false),
                        userID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderID);
            
            CreateTable(
                "dbo.orderQtyModels",
                c => new
                    {
                        orderQty_ID = c.Int(nullable: false, identity: true),
                        outputQty = c.Int(nullable: false),
                        sub_item_id = c.Int(nullable: false),
                        main_item_id = c.Int(nullable: false),
                        output_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        orderID = c.Int(nullable: false),
                        status = c.String(),
                        userID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderQty_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.orderQtyModels");
            DropTable("dbo.OrderModels");
            DropTable("dbo.deliveryModels");
        }
    }
}
