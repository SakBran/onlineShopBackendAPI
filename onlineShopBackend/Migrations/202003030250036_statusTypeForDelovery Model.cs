namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusTypeForDeloveryModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.deliveryModels", "status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.deliveryModels", "status", c => c.String());
        }
    }
}
