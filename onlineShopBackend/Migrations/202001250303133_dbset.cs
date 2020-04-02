namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.inputQtyModels",
                c => new
                    {
                        inputQty_ID = c.Int(nullable: false, identity: true),
                        inputQty = c.Int(nullable: false),
                        sub_item_id = c.Int(nullable: false),
                        main_item_id = c.Int(nullable: false),
                        inputDate = c.DateTime(nullable: false),
                        userID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.inputQty_ID);
            
            CreateTable(
                "dbo.outputQtyModels",
                c => new
                    {
                        outputQty_ID = c.Int(nullable: false, identity: true),
                        outputQty = c.Int(nullable: false),
                        sub_item_id = c.Int(nullable: false),
                        main_item_id = c.Int(nullable: false),
                        outputDate = c.DateTime(nullable: false),
                        userID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.outputQty_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.outputQtyModels");
            DropTable("dbo.inputQtyModels");
        }
    }
}
