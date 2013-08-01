using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class ManfaatMap : EntityTypeConfiguration<Manfaat>
    {
        public ManfaatMap()
        {
            // Primary Key
            this.HasKey(t => t.ManfaatID);

            // Properties
            this.Property(t => t.NamaManfaat)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Manfaat");
            this.Property(t => t.ManfaatID).HasColumnName("ManfaatID");
            this.Property(t => t.NamaManfaat).HasColumnName("NamaManfaat");
        }
    }
}
