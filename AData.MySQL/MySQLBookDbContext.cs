namespace AData.MySQL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MySQLBookDbContext : DbContext
    {
        public MySQLBookDbContext()
            : base("name=MySQLContext")
        {
        }

        public virtual DbSet<borrows> borrows { get; set; }
        public virtual DbSet<returnbooks> returnbooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<borrows>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<borrows>()
                .Property(e => e.StudentId)
                .IsUnicode(false);

            modelBuilder.Entity<borrows>()
                .Property(e => e.BookId)
                .IsUnicode(false);

            modelBuilder.Entity<returnbooks>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<returnbooks>()
                .Property(e => e.StudentId)
                .IsUnicode(false);

            modelBuilder.Entity<returnbooks>()
                .Property(e => e.BookId)
                .IsUnicode(false);
        }
    }
}
