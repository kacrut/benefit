using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class FreqCaseMap : EntityTypeConfiguration<FreqCase>
    {
        public FreqCaseMap()
        {
            // Primary Key
            this.HasKey(t => t.FreqCaseID);

            // Properties
            this.Property(t => t.FreqCaseName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FreqCase");
            this.Property(t => t.FreqCaseID).HasColumnName("FreqCaseID");
            this.Property(t => t.FreqCaseName).HasColumnName("FreqCaseName");
        }
    }
}
