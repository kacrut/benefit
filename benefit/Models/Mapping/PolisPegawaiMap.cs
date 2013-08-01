using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class PolisPegawaiMap : EntityTypeConfiguration<PolisPegawai>
    {
        public PolisPegawaiMap()
        {
            // Primary Key
            this.HasKey(t => t.PolisPegawaiID);

            // Properties
            this.Property(t => t.PolisPegawaiName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PolisPegawai");
            this.Property(t => t.PolisPegawaiID).HasColumnName("PolisPegawaiID");
            this.Property(t => t.PolisPegawaiName).HasColumnName("PolisPegawaiName");
        }
    }
}
