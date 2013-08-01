using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class vwInfoBenefitMap : EntityTypeConfiguration<vwInfoBenefit>
    {
        public vwInfoBenefitMap()
        {
            // Primary Key
            this.HasKey(t => new { t.infoBenefitBUID, t.NMKC, t.POLIS, t.PKSKD, t.PKSNM, t.NMPROD, t.NMKLSRWT, t.MANFAAT, t.NamaManfaat, t.ManfaatItemName, t.IsCaseLess, t.IsReimburse, t.ManfaatPISAName, t.FreqCaseName, t.FreqPeriodeName, t.FreqCount });

            // Properties
            this.Property(t => t.infoBenefitBUID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.KDKC)
                .HasMaxLength(4);

            this.Property(t => t.NMKC)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.POLIS)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.PKSKD)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.PKSNM)
                .IsRequired()
                .HasMaxLength(75);

            this.Property(t => t.PKSTGLML)
                .HasMaxLength(30);

            this.Property(t => t.PKSTGLAKH)
                .HasMaxLength(30);

            this.Property(t => t.NMPROD)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.NMKLSRWT)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.MANFAAT)
                .IsRequired()
                .HasMaxLength(103);

            this.Property(t => t.NamaManfaat)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ManfaatItemName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.IsCaseLess)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.IsReimburse)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Amount)
                .HasMaxLength(200);

            this.Property(t => t.ManfaatPISAName)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.FreqCaseName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FreqPeriodeName)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.FreqCount)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vwInfoBenefit");
            this.Property(t => t.infoBenefitBUID).HasColumnName("infoBenefitBUID");
            this.Property(t => t.KDKC).HasColumnName("KDKC");
            this.Property(t => t.NMKC).HasColumnName("NMKC");
            this.Property(t => t.POLIS).HasColumnName("POLIS");
            this.Property(t => t.PKSKD).HasColumnName("PKSKD");
            this.Property(t => t.PKSNM).HasColumnName("PKSNM");
            this.Property(t => t.PKSTGLML).HasColumnName("PKSTGLML");
            this.Property(t => t.PKSTGLAKH).HasColumnName("PKSTGLAKH");
            this.Property(t => t.NMPROD).HasColumnName("NMPROD");
            this.Property(t => t.NMKLSRWT).HasColumnName("NMKLSRWT");
            this.Property(t => t.MANFAAT).HasColumnName("MANFAAT");
            this.Property(t => t.NamaManfaat).HasColumnName("NamaManfaat");
            this.Property(t => t.ManfaatItemName).HasColumnName("ManfaatItemName");
            this.Property(t => t.IsCaseLess).HasColumnName("IsCaseLess");
            this.Property(t => t.IsReimburse).HasColumnName("IsReimburse");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.ManfaatPISAName).HasColumnName("ManfaatPISAName");
            this.Property(t => t.FreqCaseName).HasColumnName("FreqCaseName");
            this.Property(t => t.FreqPeriodeName).HasColumnName("FreqPeriodeName");
            this.Property(t => t.FreqCount).HasColumnName("FreqCount");
        }
    }
}
