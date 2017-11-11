namespace LeilaoWebService.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LeilaoWebService.Data.LeilaoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LeilaoWebService.Data.LeilaoContext context)
        {

            var produtos = new List<Produto>
        {
            new Produto { BreveDescricao = "Item para exemplo 1", DescricaoCompleta = "Exemplo de descrição 1", Categoria = "Exemplo 1"  },
            new Produto { BreveDescricao = "Item para exemplo 2", DescricaoCompleta = "Exemplo de descrição 2", Categoria = "Exemplo 2"  },
            new Produto { BreveDescricao = "Item para exemplo 3", DescricaoCompleta = "Exemplo de descrição 3 ", Categoria = "Exemplo 3"  }
        };
            produtos.ForEach(s => context.Produto.AddOrUpdate(p => p.BreveDescricao, s));


            var lotes = new List<Lote> { new Lote { Produtos = produtos } };
            lotes.ForEach(s => context.Lote.AddOrUpdate(l => l.LoteID, s));

            var usuario = new Usuario { Nome= "Paulo" ,Cpf = "12345678912" , Cnpj = "", Email = "paulo@exemplo.com" };
            context.Usuario.AddOrUpdate(u => u.Nome, usuario);


            var leiloes = new List<Leilao>
            {
                new Leilao { Natureza = "Oferta", Forma = "Aberto", DataDeInicio = DateTime.Today,
                    DataDeFim = new DateTime(2017, 11,14), Usuario = usuario ,
                    LanceMinimo = 150.00,  LanceMaximo= 1500.00, Lotes = lotes
                }
            };

            leiloes.ForEach(s => context.Leilao.AddOrUpdate(leilao => leilao.Natureza, s));
            context.SaveChanges();
        }
    }
}
