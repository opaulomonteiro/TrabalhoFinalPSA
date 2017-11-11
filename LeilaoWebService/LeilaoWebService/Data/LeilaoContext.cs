using LeilaoWebService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LeilaoWebService.Data
{
    public class LeilaoContext : DbContext
    {
        public LeilaoContext() : base("LeilaoContext")
        {

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