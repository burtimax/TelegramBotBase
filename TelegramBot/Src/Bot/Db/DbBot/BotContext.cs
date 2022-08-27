using BotApplication.Bot.Db.DbMethods;
using Microsoft.EntityFrameworkCore;

namespace BotApplication.Bot.Db.DbBot
{
    public class BotContext : DbContext
    {
        // "Server=(localdb)\\mssqllocaldb;Database=MarathonTelegramBot;Trusted_Connection=True;"

        private string schema = "bot";
        
        //Lazy load Methods object
        public IBotContextDbMethods _methods;
        public IBotContextDbMethods Methods
        {
            get
            {
                if (this._methods == null)
                {
                    this._methods = new BotContextDbMethods(this);
                }

                return this._methods;
            }
            private set { this._methods = value; }
        }


        public DbSet<User> User { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }

        private string _connection;

        // public BotContext(string connection)
        // {
        //     _connection = connection;
        //     //Database.EnsureCreated();
        // }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>().ToTable("chats", schema);
            modelBuilder.Entity<Chat>().Property(e => e.CreateTime).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Message>().ToTable("messages", schema);
            modelBuilder.Entity<Message>().Property(e => e.CreateTime).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            
            modelBuilder.Entity<User>().ToTable("users", schema);
            modelBuilder.Entity<User>().Property(e => e.CreateTime).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_connection
            optionsBuilder.UseNpgsql(AppConstants.DbConnection);
        }
    }
}
