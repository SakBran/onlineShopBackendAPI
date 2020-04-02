namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.userModels",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        userType = c.Int(nullable: false),
                        userPhone = c.String(),
                        UserEmail = c.String(),
                    })
                .PrimaryKey(t => t.userID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.userModels");
        }
    }
}
