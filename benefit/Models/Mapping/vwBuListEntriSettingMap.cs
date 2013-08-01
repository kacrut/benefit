using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class vwBuListEntriSettingMap : EntityTypeConfiguration<vwBuListEntriSetting>
    {
        public vwBuListEntriSettingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.KDKC, t.NMKC, t.PKSKD, t.PKSNM });

            // Properties
            this.Property(t => t.KDKC)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.NMKC)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.PKSKD)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.PKSNM)
                .IsRequired()
                .HasMaxLength(75);

            // Table & Column Mappings
            this.ToTable("vwBuListEntriSetting");
            this.Property(t => t.KDKC).HasColumnName("KDKC");
            this.Property(t => t.NMKC).HasColumnName("NMKC");
            this.Property(t => t.PKSKD).HasColumnName("PKSKD");
            this.Property(t => t.PKSNM).HasColumnName("PKSNM");
        }
    }
}
