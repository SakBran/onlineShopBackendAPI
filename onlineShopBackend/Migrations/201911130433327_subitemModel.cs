namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subitemModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.subItemModels",
                c => new
                    {
                        sub_item_id = c.Int(nullable: false, identity: true),
                        sub_item_name = c.String(),
                        sub_item_image = c.String(),
                        main_item_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.sub_item_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.subItemModels");
        }
    }
}
