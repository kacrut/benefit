using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class ManfaatPISAMap : EntityTypeConfiguration<ManfaatPISA>
    {
        public ManfaatPISAMap()
        {
            // Primary Key
            this.HasKey(t => t.ManfaatPISAID);

            // Properties
            this.Property(t => t.ManfaatPISAName)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("ManfaatPISA");
            this.Property(t => t.ManfaatPISAID).HasColumnName("ManfaatPISAID");
            this.Property(t => t.ManfaatPISAName).HasColumnName("ManfaatPISAName");
        }
    }
}
