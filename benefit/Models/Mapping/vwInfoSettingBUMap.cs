using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class vwInfoSettingBUMap : EntityTypeConfiguration<vwInfoSettingBU>
    {
        public vwInfoSettingBUMap()
        {
            // Primary Key
            this.HasKey(t => new { t.InfoSettingBUID, t.KDKC, t.NMKC, t.PKSKD, t.PKSNM, t.PolisPegawaiName, t.PMaxAge, t.PMinAge, t.IMaxAge, t.IMinAge, t.SMaxAge, t.SMinAge, t.AMaxAge, t.AMinAge, t.MaxChild, t.CaraBayarName, t.Installment });

            // Properties
            this.Property(t => t.InfoSettingBUID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.KDKC)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.NMKC)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.NOMOR)
                .HasMaxLength(25);

            this.Property(t => t.PKSKD)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.PKSNM)
                .IsRequired()
                .HasMaxLength(75);

            this.Property(t => t.PolisPegawaiName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PMaxAge)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PMinAge)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IMaxAge)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IMinAge)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SMaxAge)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SMinAge)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AMaxAge)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AMinAge)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MaxChild)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CaraBayarName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Installment)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vwInfoSettingBU");
            this.Property(t => t.InfoSettingBUID).HasColumnName("InfoSettingBUID");
            this.Property(t => t.KDKC).HasColumnName("KDKC");
            this.Property(t => t.NMKC).HasColumnName("NMKC");
            this.Property(t => t.NOMOR).HasColumnName("NOMOR");
            this.Property(t => t.PKSKD).HasColumnName("PKSKD");
            this.Property(t => t.PKSNM).HasColumnName("PKSNM");
            this.Property(t => t.PolisPegawaiName).HasColumnName("PolisPegawaiName");
            this.Property(t => t.PMaxAge).HasColumnName("PMaxAge");
            this.Property(t => t.PMinAge).HasColumnName("PMinAge");
            this.Property(t => t.IMaxAge).HasColumnName("IMaxAge");
            this.Property(t => t.IMinAge).HasColumnName("IMinAge");
            this.Property(t => t.SMaxAge).HasColumnName("SMaxAge");
            this.Property(t => t.SMinAge).HasColumnName("SMinAge");
            this.Property(t => t.AMaxAge).HasColumnName("AMaxAge");
            this.Property(t => t.AMinAge).HasColumnName("AMinAge");
            this.Property(t => t.MaxChild).HasColumnName("MaxChild");
            this.Property(t => t.CaraBayarName).HasColumnName("CaraBayarName");
            this.Property(t => t.Installment).HasColumnName("Installment");
        }
    }
}
