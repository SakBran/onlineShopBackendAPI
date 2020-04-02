namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subcat : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.subCategoryModels");
            AddColumn("dbo.subCategoryModels", "sub_cat_id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.subCategoryModels", "sub_cat_name", c => c.String());
            AddColumn("dbo.subCategoryModels", "cat_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.subCategoryModels", "sub_cat_id");
            DropColumn("dbo.subCategoryModels", "subCateogryID");
            DropColumn("dbo.subCategoryModels", "subCateogoryName");
            DropColumn("dbo.subCategoryModels", "categoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.subCategoryModels", "categoryID", c => c.Int(nullable: false));
            AddColumn("dbo.subCategoryModels", "subCateogoryName", c => c.String());
            AddColumn("dbo.subCategoryModels", "subCateogryID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.subCategoryModels");
            DropColumn("dbo.subCategoryModels", "cat_id");
            DropColumn("dbo.subCategoryModels", "sub_cat_name");
            DropColumn("dbo.subCategoryModels", "sub_cat_id");
            AddPrimaryKey("dbo.subCategoryModels", "subCateogryID");
        }
    }
}
