namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class address : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.userModels", "userAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.userModels", "userAddress");
        }
    }
}
