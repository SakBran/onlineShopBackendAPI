namespace onlineShopBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priceforQTY : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.inputQtyModels", "input_price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.outputQtyModels", "output_price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.outputQtyModels", "output_price");
            DropColumn("dbo.inputQtyModels", "input_price");
        }
    }
}
