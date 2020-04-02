namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class debtModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.debtQtypModels",
                c => new
                    {
                        debtQty_ID = c.Int(nullable: false, identity: true),
                        outputQty = c.Int(nullable: false),
                        sub_item_id = c.Int(nullable: false),
                        main_item_id = c.Int(nullable: false),
                        output_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        outputDate = c.DateTime(nullable: false),
                        userID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.debtQty_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.debtQtypModels");
        }
    }
}
