namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderIDinDeliveryQTyModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.debtQtypModels", "orderID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.debtQtypModels", "orderID");
        }
    }
}
