using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AData.SQLServer.Model.Models.Mapping
{
    public class ShopMap : EntityTypeConfiguration<Shop>
    {
        public ShopMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ShopId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ZCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ContactName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Shops");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ShopId).HasColumnName("ShopId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.ZCode).HasColumnName("ZCode");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
            this.Property(t => t.ShopManager).HasColumnName("ShopManager");
            this.Property(t => t.RegionId).HasColumnName("RegionId");
        }
    }
}
