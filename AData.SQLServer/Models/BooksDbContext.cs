using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AData.SQLServer.Models.Mapping;

namespace AData.SQLServer.Models
{
    public partial class BooksDbContext : DbContext
    {
        static BooksDbContext()
        {
            Database.SetInitializer<BooksDbContext>(null);
        }

        public BooksDbContext()
            : base("Name=SQLServerBookDbContext")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new StudentMap());
        }
    }
}
