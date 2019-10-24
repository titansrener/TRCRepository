using Microsoft.EntityFrameworkCore;
using TRC.Core.Modelo;
using TRC.Data.Configuration;

namespace TRC.Data
{
    public class TrcContext : DbContext
    {
        private const string CONNECTIONSTRING = @"Data Source=DELL-NT\\SQLEXPRESS;Initial Catalog=TRC_BD;User ID=usr_trc;Password=123456";
        public TrcContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Estado> Estados { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EstadoConfiguration());
        }
    }
}
