using LeilaoWebPersistencia.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LeilaoWebPersistencia.Data
{
    class LeilaoContext : DbContext
    {
        public LeilaoContext() : base("LeilaoContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        //Removendo pluralização dos nomes das tabelas
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Leilao> Leilao { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Lote> Lote { get; set; }
              
    }
}
