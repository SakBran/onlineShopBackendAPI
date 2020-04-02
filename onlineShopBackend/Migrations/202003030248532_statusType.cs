namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.orderQtyModels", "status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.orderQtyModels", "status", c => c.String());
        }
    }
}
