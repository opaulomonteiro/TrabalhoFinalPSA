namespace ProdutosWebApi.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProdutosWebApi.Models.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProdutosWebApi.Models.ProductContext context)
        {
            var products = new List<Product> {
                new Product { Name = "Tomato soup", Category = "Groceries", Price = 1.39M },
                new Product { Name = "Yo-yo", Category = "Toys", Price = 3.75M },
                new Product { Name = "Hammer", Category = "Hardware", Price = 16.99M }
            };

            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}
