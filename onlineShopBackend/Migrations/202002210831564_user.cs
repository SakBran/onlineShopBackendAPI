namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.userModels", "userName", c => c.String(nullable: false));
            AlterColumn("dbo.userModels", "userPhone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.userModels", "userPhone", c => c.String());
            AlterColumn("dbo.userModels", "userName", c => c.String());
        }
    }
}
