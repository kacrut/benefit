using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class InfoBenefitBUMap : EntityTypeConfiguration<InfoBenefitBU>
    {
        public InfoBenefitBUMap()
        {
            // Primary Key
            this.HasKey(t => t.InfoBenefitBUID);

            // Properties
            this.Property(t => t.POLIS)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.PKSKD)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.KDPROD)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("InfoBenefitBU");
            this.Property(t => t.InfoBenefitBUID).HasColumnName("InfoBenefitBUID");
            this.Property(t => t.POLIS).HasColumnName("POLIS");
            this.Property(t => t.PKSKD).HasColumnName("PKSKD");
            this.Property(t => t.KDPROD).HasColumnName("KDPROD");
            this.Property(t => t.KDKLSRWT).HasColumnName("KDKLSRWT");
            this.Property(t => t.ManfaatInManfaatItemID).HasColumnName("ManfaatInManfaatItemID");
            this.Property(t => t.IsCaseLess).HasColumnName("IsCaseLess");
            this.Property(t => t.IsReimburse).HasColumnName("IsReimburse");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.ManfaatPISAID).HasColumnName("ManfaatPISAID");
            this.Property(t => t.FreqCaseID).HasColumnName("FreqCaseID");
            this.Property(t => t.FreqPeriodeID).HasColumnName("FreqPeriodeID");
            this.Property(t => t.FreqCount).HasColumnName("FreqCount");

            // Relationships
            this.HasRequired(t => t.FreqCase)
                .WithMany(t => t.InfoBenefitBUs)
                .HasForeignKey(d => d.FreqCaseID);
            this.HasRequired(t => t.FreqPeriode)
                .WithMany(t => t.InfoBenefitBUs)
                .HasForeignKey(d => d.FreqPeriodeID);
            this.HasRequired(t => t.ManfaatInManfaatItem)
                .WithMany(t => t.InfoBenefitBUs)
                .HasForeignKey(d => d.ManfaatInManfaatItemID);
            this.HasRequired(t => t.ManfaatPISA)
                .WithMany(t => t.InfoBenefitBUs)
                .HasForeignKey(d => d.ManfaatPISAID);

        }
    }
}
