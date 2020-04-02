namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priceTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.priceModels",
                c => new
                    {
                        priceID = c.Int(nullable: false, identity: true),
                        MyPmain_item_idroperty = c.Int(nullable: false),
                        price = c.Single(nullable: false),
                        qty = c.Int(nullable: false),
                        unitName = c.String(),
                    })
                .PrimaryKey(t => t.priceID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.priceModels");
        }
    }
}
