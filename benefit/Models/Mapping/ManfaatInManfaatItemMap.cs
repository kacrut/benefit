using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class ManfaatInManfaatItemMap : EntityTypeConfiguration<ManfaatInManfaatItem>
    {
        public ManfaatInManfaatItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ManfaatInManfaatItemID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ManfaatInManfaatItem");
            this.Property(t => t.ManfaatInManfaatItemID).HasColumnName("ManfaatInManfaatItemID");
            this.Property(t => t.ManfaatID).HasColumnName("ManfaatID");
            this.Property(t => t.ManfaatItemID).HasColumnName("ManfaatItemID");

            // Relationships
            this.HasRequired(t => t.Manfaat)
                .WithMany(t => t.ManfaatInManfaatItems)
                .HasForeignKey(d => d.ManfaatID);
            this.HasRequired(t => t.ManfaatItem)
                .WithMany(t => t.ManfaatInManfaatItems)
                .HasForeignKey(d => d.ManfaatItemID);

        }
    }
}
