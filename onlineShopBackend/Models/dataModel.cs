namespace onlineShopBackend.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class dataModel : DbContext
    {
        // Your context has been configured to use a 'dataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'onlineShopBackend.Models.dataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'dataModel' 
        // connection string in the application configuration file.
        public dataModel()
            : base("name=dataModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<categoryModel> CategoryModels{ get; set; }
        public virtual DbSet<subCategoryModel> SubCategoryModels { get; set; }
        public virtual DbSet<mainItemModel> MainItemModels { get; set; }
        public virtual DbSet<subItemModel> SubItemModels { get; set; }
        public virtual DbSet<priceModel> PriceModels { get; set; }

        public virtual DbSet<inputQtyModel> InputQtyModels { get; set; }
        public virtual DbSet<outputQtyModel> OutputQtyModels { get; set; }

        public virtual DbSet<categoryImage> CategoryImages { get; set; }

        public virtual DbSet<debtQtypModel> DebtQtypModels { get; set; }
        public virtual DbSet<orderQtyModel> OrderQtyModels { get; set; }
        public virtual DbSet<OrderModel> OrderModels { get; set; }
        public virtual DbSet<deliveryModel> DeliveryModels { get; set; }
        public virtual DbSet<userModel> UserModels { get; set; }
    }
}

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
