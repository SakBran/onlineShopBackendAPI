namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Again : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categoryModels",
                c => new
                    {
                        cat_id = c.Int(nullable: false, identity: true),
                        cat_name = c.String(),
                    })
                .PrimaryKey(t => t.cat_id);
            
            CreateTable(
                "dbo.mainItemModels",
                c => new
                    {
                        main_item_id = c.Int(nullable: false, identity: true),
                        main_item_name = c.String(),
                        sub_category_id = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                        image_url = c.String(),
                        brand = c.String(),
                        Descriptions = c.String(),
                    })
                .PrimaryKey(t => t.main_item_id);
            
            CreateTable(
                "dbo.subCategoryModels",
                c => new
                    {
                        subCateogryID = c.Int(nullable: false, identity: true),
                        subCateogoryName = c.String(),
                        categoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.subCateogryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.subCategoryModels");
            DropTable("dbo.mainItemModels");
            DropTable("dbo.categoryModels");
        }
    }
}
