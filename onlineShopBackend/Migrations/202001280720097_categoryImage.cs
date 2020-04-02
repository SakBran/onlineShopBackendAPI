namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categoryImages",
                c => new
                    {
                        catImageID = c.Int(nullable: false, identity: true),
                        catImageName = c.String(),
                        cat_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.catImageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.categoryImages");
        }
    }
}
