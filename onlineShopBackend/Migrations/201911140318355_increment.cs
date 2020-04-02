namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class increment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.subCategoryModels", "sub_cat_id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.subCategoryModels", "sub_cat_id", c => c.Int(nullable: false, identity: true));
        }
    }
}
