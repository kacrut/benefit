using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class ManfaatItemMap : EntityTypeConfiguration<ManfaatItem>
    {
        public ManfaatItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ManfaatItemID);

            // Properties
            this.Property(t => t.ManfaatItemName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ManfaatItem");
            this.Property(t => t.ManfaatItemID).HasColumnName("ManfaatItemID");
            this.Property(t => t.ManfaatItemName).HasColumnName("ManfaatItemName");
        }
    }
}
