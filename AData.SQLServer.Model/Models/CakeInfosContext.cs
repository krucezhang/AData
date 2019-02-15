using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AData.SQLServer.Model.Models.Mapping;

namespace AData.SQLServer.Model.Models
{
    public partial class CakeInfosContext : DbContext
    {
        static CakeInfosContext()
        {
            Database.SetInitializer<CakeInfosContext>(null);
        }

        public CakeInfosContext()
            : base("Name=CakeInfosContext")
        {
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RegionMap());
            modelBuilder.Configurations.Add(new ShopMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
