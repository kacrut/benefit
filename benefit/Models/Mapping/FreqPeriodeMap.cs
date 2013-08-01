using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class FreqPeriodeMap : EntityTypeConfiguration<FreqPeriode>
    {
        public FreqPeriodeMap()
        {
            // Primary Key
            this.HasKey(t => t.FreqPeriodeID);

            // Properties
            this.Property(t => t.FreqPeriodeName)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("FreqPeriode");
            this.Property(t => t.FreqPeriodeID).HasColumnName("FreqPeriodeID");
            this.Property(t => t.FreqPeriodeName).HasColumnName("FreqPeriodeName");
        }
    }
}
