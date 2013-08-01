using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class vwRekapBuListInfoSettingMap : EntityTypeConfiguration<vwRekapBuListInfoSetting>
    {
        public vwRekapBuListInfoSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.NMKC);

            // Properties
            this.Property(t => t.NMKC)
                .IsRequired()
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("vwRekapBuListInfoSetting");
            this.Property(t => t.NMKC).HasColumnName("NMKC");
            this.Property(t => t.TotalProduction).HasColumnName("TotalProduction");
            this.Property(t => t.TotalUpload).HasColumnName("TotalUpload");
        }
    }
}
