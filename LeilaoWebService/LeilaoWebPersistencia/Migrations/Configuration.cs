namespace LeilaoWebPersistencia.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LeilaoWebPersistencia.Data.LeilaoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LeilaoWebPersistencia.Data.LeilaoContext context)
        {
            var produtos = new List<Produto>
        {
            new Produto { BreveDescricao = "Item para exemplo 1", DescricaoCompleta = "Exemplo de descrição 1", Categoria = "Exemplo 1"  },
            new Produto { BreveDescricao = "Item para exemplo 2", DescricaoCompleta = "Exemplo de descrição 2", Categoria = "Exemplo 2"  },
            new Produto { BreveDescricao = "Item para exemplo 3", DescricaoCompleta = "Exemplo de descrição 3 ", Categoria = "Exemplo 3"  }
        };
            produtos.ForEach(s => context.Produto.AddOrUpdate(p => p.BreveDescricao, s));


            var lote = new Lote { Produtos = produtos };
            context.Lote.AddOrUpdate(u => u.ID, lote);


            var usuario = new Usuario { Nome = "Paulo", Cpf = "12345678912", Cnpj = "", Email = "paulo@exemplo.com" };
            context.Usuario.AddOrUpdate(u => u.Nome, usuario);


            var leiloes = new List<Leilao>
            {
                new Leilao { Natureza = "Oferta", Forma = "Aberto", DataDeInicio = DateTime.Today,
                    DataDeFim = new DateTime(2017, 11,14), Usuario = usuario ,
                    LanceMinimo = 150.00,  LanceMaximo= 1500.00, Lote = lote
                }
            };

            leiloes.ForEach(s => context.Leilao.AddOrUpdate(leilao => leilao.Natureza, s));
            context.SaveChanges();
        }
    }
}
