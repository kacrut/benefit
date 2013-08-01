using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class InfoSettingBUMap : EntityTypeConfiguration<InfoSettingBU>
    {
        public InfoSettingBUMap()
        {
            // Primary Key
            this.HasKey(t => t.InfoSettingBUID);

            // Properties
            this.Property(t => t.POLIS)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.PKSKD)
                .IsRequired()
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("InfoSettingBU");
            this.Property(t => t.InfoSettingBUID).HasColumnName("InfoSettingBUID");
            this.Property(t => t.POLIS).HasColumnName("POLIS");
            this.Property(t => t.PKSKD).HasColumnName("PKSKD");
            this.Property(t => t.PolisPegawaiID).HasColumnName("PolisPegawaiID");
            this.Property(t => t.PMaxAge).HasColumnName("PMaxAge");
            this.Property(t => t.PMinAge).HasColumnName("PMinAge");
            this.Property(t => t.IMaxAge).HasColumnName("IMaxAge");
            this.Property(t => t.IMinAge).HasColumnName("IMinAge");
            this.Property(t => t.SMaxAge).HasColumnName("SMaxAge");
            this.Property(t => t.SMinAge).HasColumnName("SMinAge");
            this.Property(t => t.AMaxAge).HasColumnName("AMaxAge");
            this.Property(t => t.AMinAge).HasColumnName("AMinAge");
            this.Property(t => t.MaxChild).HasColumnName("MaxChild");
            this.Property(t => t.CaraBayarID).HasColumnName("CaraBayarID");
            this.Property(t => t.Installment).HasColumnName("Installment");

            // Relationships
            this.HasRequired(t => t.CaraBayar)
                .WithMany(t => t.InfoSettingBUs)
                .HasForeignKey(d => d.CaraBayarID);
            this.HasRequired(t => t.PolisPegawai)
                .WithMany(t => t.InfoSettingBUs)
                .HasForeignKey(d => d.PolisPegawaiID);

        }
    }
}
