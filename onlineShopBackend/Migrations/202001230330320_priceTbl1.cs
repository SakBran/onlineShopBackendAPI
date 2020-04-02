namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priceTbl1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.priceModels", "main_item_id", c => c.Int(nullable: false));
            DropColumn("dbo.priceModels", "MyPmain_item_idroperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.priceModels", "MyPmain_item_idroperty", c => c.Int(nullable: false));
            DropColumn("dbo.priceModels", "main_item_id");
        }
    }
}
