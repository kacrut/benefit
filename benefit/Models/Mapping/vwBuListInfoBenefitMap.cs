using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class vwBuListInfoBenefitMap : EntityTypeConfiguration<vwBuListInfoBenefit>
    {
        public vwBuListInfoBenefitMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PKSKD, t.PKSNM });

            // Properties
            this.Property(t => t.KDKC)
                .HasMaxLength(4);

            this.Property(t => t.PKSKD)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.NOMOR)
                .HasMaxLength(25);

            this.Property(t => t.PKSNM)
                .IsRequired()
                .HasMaxLength(75);

            this.Property(t => t.PKSTGLML)
                .HasMaxLength(30);

            this.Property(t => t.PKSTGLAKH)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("vwBuListInfoBenefit");
            this.Property(t => t.KDKC).HasColumnName("KDKC");
            this.Property(t => t.PKSKD).HasColumnName("PKSKD");
            this.Property(t => t.NOMOR).HasColumnName("NOMOR");
            this.Property(t => t.PKSNM).HasColumnName("PKSNM");
            this.Property(t => t.PKSTGLML).HasColumnName("PKSTGLML");
            this.Property(t => t.PKSTGLAKH).HasColumnName("PKSTGLAKH");
        }
    }
}
