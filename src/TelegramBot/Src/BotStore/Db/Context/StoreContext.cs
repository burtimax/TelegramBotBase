using BotApplication.BotStore.Db.Entities;
using BotApplication.BotStore.Db.Repositories;
using BotApplication.BotStore.Interfaces;
using BotApplication.BotStore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BotApplication.BotStore.Db.Context
{
    public class StoreContext : DbContext, ISantaContext
    {
        private string schema = "store";
        private string _connection;

        // public StoreContext(string connection)
        // {
        //     _connection = connection;
        // }

        public StoreContext()
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        private IRepositoryHub _repositoryHub;
        public IRepositoryHub Repos
        {
            get
            {
                if (_repositoryHub == null)
                {
                    _repositoryHub = new RepositoryHub(this);
                }

                return _repositoryHub;
            }
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(AppConstants.DbConnection); //for MS SQL SERVER
            optionsBuilder.UseNpgsql(AppConstants.DbConnection); //For Postgres
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Order>().ToTable("orders", schema);
            modelBuilder.Entity<Order>().Property(e => e.CreateTime).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().HasQueryFilter(sh => sh.SoftDelete == false);
            
            modelBuilder.Entity<Product>().ToTable("products", schema);
            modelBuilder.Entity<Product>().Property(e => e.CreateTime).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().HasQueryFilter(ui => ui.SoftDelete == false);
            
            modelBuilder.Entity<OrderItem>().ToTable("order_items", schema);
            modelBuilder.Entity<OrderItem>().Property(e => e.CreateTime).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderItem>().HasQueryFilter(uc => uc.SoftDelete == false);
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<BasketItem>().ToTable("basket_items", schema);
            modelBuilder.Entity<BasketItem>().Property(e => e.CreateTime).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            modelBuilder.Entity<BasketItem>().HasQueryFilter(uc => uc.SoftDelete == false);
            base.OnModelCreating(modelBuilder);
        }
    }
}