namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.userModels", "password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.userModels", "password");
        }
    }
}
