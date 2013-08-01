using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using benefit.Models.Mapping;

namespace benefit.Models
{
    public partial class BENEFITContext : DbContext
    {
        static BENEFITContext()
        {
            Database.SetInitializer<BENEFITContext>(null);
        }

        public BENEFITContext()
            : base("Name=BENEFITContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<CaraBayar> CaraBayars { get; set; }
        public DbSet<FreqCase> FreqCases { get; set; }
        public DbSet<FreqPeriode> FreqPeriodes { get; set; }
        public DbSet<InfoBenefitBU> InfoBenefitBUs { get; set; }
        public DbSet<InfoSettingBU> InfoSettingBUs { get; set; }
        public DbSet<Manfaat> Manfaats { get; set; }
        public DbSet<ManfaatInManfaatItem> ManfaatInManfaatItems { get; set; }
        public DbSet<ManfaatItem> ManfaatItems { get; set; }
        public DbSet<ManfaatPISA> ManfaatPISAs { get; set; }
        public DbSet<PolisPegawai> PolisPegawais { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<vwBuListEntriBenefit> vwBuListEntriBenefits { get; set; }
        public DbSet<vwBuListEntriSetting> vwBuListEntriSettings { get; set; }
        public DbSet<vwBuListInfoBenefit> vwBuListInfoBenefits { get; set; }
        public DbSet<vwInfoBenefit> vwInfoBenefits { get; set; }
        public DbSet<vwInfoSettingBU> vwInfoSettingBUs { get; set; }
        public DbSet<vwRekapBuListInfoBenefit> vwRekapBuListInfoBenefits { get; set; }
        public DbSet<vwRekapBuListInfoSetting> vwRekapBuListInfoSettings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CaraBayarMap());
            modelBuilder.Configurations.Add(new FreqCaseMap());
            modelBuilder.Configurations.Add(new FreqPeriodeMap());
            modelBuilder.Configurations.Add(new InfoBenefitBUMap());
            modelBuilder.Configurations.Add(new InfoSettingBUMap());
            modelBuilder.Configurations.Add(new ManfaatMap());
            modelBuilder.Configurations.Add(new ManfaatInManfaatItemMap());
            modelBuilder.Configurations.Add(new ManfaatItemMap());
            modelBuilder.Configurations.Add(new ManfaatPISAMap());
            modelBuilder.Configurations.Add(new PolisPegawaiMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new vwBuListEntriBenefitMap());
            modelBuilder.Configurations.Add(new vwBuListEntriSettingMap());
            modelBuilder.Configurations.Add(new vwBuListInfoBenefitMap());
            modelBuilder.Configurations.Add(new vwInfoBenefitMap());
            modelBuilder.Configurations.Add(new vwInfoSettingBUMap());
            modelBuilder.Configurations.Add(new vwRekapBuListInfoBenefitMap());
            modelBuilder.Configurations.Add(new vwRekapBuListInfoSettingMap());
        }
    }
}
