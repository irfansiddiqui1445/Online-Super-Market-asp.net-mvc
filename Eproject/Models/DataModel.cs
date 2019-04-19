namespace Eproject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<brand> brands { get; set; }
        public virtual DbSet<cart> carts { get; set; }
        public virtual DbSet<catagory> catagories { get; set; }
        public virtual DbSet<product> products { get; set; }
        
        public virtual DbSet<publicuseraccount> publicuseraccounts { get; set; }
        
        public virtual DbSet<shop_vendor> shop_vendor { get; set; }
        public void UpdateProduct(product p) {


            string query = "";
        
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<brand>()
                .Property(e => e.Brand_Id)
                .IsUnicode(false);

            modelBuilder.Entity<brand>()
                .Property(e => e.Brand_Name)
                .IsUnicode(false);

            modelBuilder.Entity<brand>()
                .Property(e => e.Brand_Discription)
                .IsUnicode(false);

            modelBuilder.Entity<brand>()
                .Property(e => e.Brand_Logo)
                .IsUnicode(false);

            modelBuilder.Entity<cart>()
                .Property(e => e.Cart_ID)
                .IsUnicode(false);

            modelBuilder.Entity<cart>()
                .Property(e => e.Product_ID)
                .IsUnicode(false);

            modelBuilder.Entity<cart>()
                .Property(e => e.Date_Time)
                .IsUnicode(false);

            modelBuilder.Entity<cart>()
                .Property(e => e.User_ID)
                .IsUnicode(false);

            modelBuilder.Entity<cart>()
                .Property(e => e.Quantity)
                .IsUnicode(false);

            modelBuilder.Entity<catagory>()
                .Property(e => e.Cat_ID)
                .IsUnicode(false);

            modelBuilder.Entity<catagory>()
                .Property(e => e.Sub_ID)
                .IsUnicode(false);

            modelBuilder.Entity<catagory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<catagory>()
                .Property(e => e.Des)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Pro_ID)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Pro_Name)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Catogary)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Brand)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Shop)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Des)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Price)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Date_Time)
                .IsUnicode(false);

           

            modelBuilder.Entity<publicuseraccount>()
                .Property(e => e.User_ID)
                .IsUnicode(false);

            modelBuilder.Entity<publicuseraccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<publicuseraccount>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<publicuseraccount>()
                .Property(e => e.UserType)
                .IsUnicode(false);

            modelBuilder.Entity<publicuseraccount>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<publicuseraccount>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<publicuseraccount>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<publicuseraccount>()
                .Property(e => e.CCN)
                .IsUnicode(false);

            modelBuilder.Entity<publicuseraccount>()
                .Property(e => e.CCEx)
                .IsUnicode(false);


            modelBuilder.Entity<shop_vendor>()
                .Property(e => e.Shop_Id)
                .IsUnicode(false);

            modelBuilder.Entity<shop_vendor>()
                .Property(e => e.Shop_Name)
                .IsUnicode(false);

            modelBuilder.Entity<shop_vendor>()
                .Property(e => e.Shopkeeper_Name)
                .IsUnicode(false);

            modelBuilder.Entity<shop_vendor>()
                .Property(e => e.Shop_Address)
                .IsUnicode(false);

            modelBuilder.Entity<shop_vendor>()
                .Property(e => e.Shopkeeper_Refference_ID)
                .IsUnicode(false);

            modelBuilder.Entity<shop_vendor>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<shop_vendor>()
                .Property(e => e.Shop_Logo)
                .IsUnicode(false);

            modelBuilder.Entity<shop_vendor>()
                .Property(e => e.Catagory)
                .IsUnicode(false);
        }
    }
}
