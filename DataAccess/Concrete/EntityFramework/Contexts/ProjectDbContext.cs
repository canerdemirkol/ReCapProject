using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Configuration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    /// <summary>
    /// Because this context is followed by migration for more than one provider
    /// works on PostGreSql db by default. If you want to pass sql
    /// When adding AddDbContext, use MsDbContext derived from it.
    /// </summary>
    public class ProjectDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;


        /// <summary>
        /// in constructor we get IConfiguration, parallel to more than one db
        /// we can create migration.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options, IConfiguration configuration)
                                                                                : base(options)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Let's also implement the general version.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        protected ProjectDbContext(DbContextOptions options, IConfiguration configuration)
                                                                        : base(options)
        {
            Configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

  

            modelBuilder.ApplyConfiguration(new MapKeyConfiguration());
            modelBuilder.ApplyConfiguration(new MobileAppVersionConfiguration());
            modelBuilder.ApplyConfiguration(new OperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserOperationClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserAllowedToUseAPIConfiguration());
            modelBuilder.ApplyConfiguration(new SistemOnayKodKontrolConfiguration());
            modelBuilder.ApplyConfiguration(new IlConfiguration());
            modelBuilder.ApplyConfiguration(new AdresTipConfiguration());
            modelBuilder.ApplyConfiguration(new BolgeConfiguration());
            modelBuilder.ApplyConfiguration(new CsmbConfiguration());
            modelBuilder.ApplyConfiguration(new IlceConfiguration());
            modelBuilder.ApplyConfiguration(new IletisimTipConfiguration());
            modelBuilder.ApplyConfiguration(new AdresTipConfiguration());
            modelBuilder.ApplyConfiguration(new KonumRequestConfiguration());
            modelBuilder.ApplyConfiguration(new MahalleConfiguration());
            modelBuilder.ApplyConfiguration(new MobileAppVersionConfiguration());
            modelBuilder.ApplyConfiguration(new KurumSmsConfiguration());



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //  base.OnConfiguring(optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DArchPgContext")).EnableSensitiveDataLogging());
                //base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SobeMsContext")));

                var MsSqlConfiguration = Configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration");
                base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RecapMsContext")));
            }
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MOBILE_APP_VERSION> MOBILE_APP_VERSION { get; set; }
        public DbSet<SISTEM_ONAY_KOD_KONTROL> SISTEM_ONAY_KOD_KONTROL { get; set; }
        public DbSet<UserAllowedToUseAPI> UsersAllowedToUseAPI { get; set; }
        public DbSet<IL> ILLER { get; set; }
        public DbSet<ADRES_TIP> ADRES_TIPLERI { get; set; }
        public DbSet<BOLGE> BOLGELER { get; set; }
        public DbSet<CSBM> CSBMs { get; set; }
        public DbSet<ILCE> ILCELER { get; set; }
        public DbSet<ILETISIM_TIP> ILETISIM_TIPLERI { get; set; }
        public DbSet<KONUM_REQUEST> KONUM_REQUEST { get; set; }
        public DbSet<MAHALLE> MAHALLELERs { get; set; }
        public DbSet<MAP_KEY> MAP_KEY { get; set; }
    }
}




