using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AData.SQLServer.Models.Mapping
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.Author)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Publisher)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Books");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.Publisher).HasColumnName("Publisher");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.RecordDate).HasColumnName("RecordDate");
        }
    }
}
