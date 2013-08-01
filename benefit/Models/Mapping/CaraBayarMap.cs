using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace benefit.Models.Mapping
{
    public class CaraBayarMap : EntityTypeConfiguration<CaraBayar>
    {
        public CaraBayarMap()
        {
            // Primary Key
            this.HasKey(t => t.CaraBayarID);

            // Properties
            this.Property(t => t.CaraBayarName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CaraBayar");
            this.Property(t => t.CaraBayarID).HasColumnName("CaraBayarID");
            this.Property(t => t.CaraBayarName).HasColumnName("CaraBayarName");
        }
    }
}
