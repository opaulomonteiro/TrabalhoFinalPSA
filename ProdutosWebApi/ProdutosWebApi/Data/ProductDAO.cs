using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProdutosWebApi.Models;

namespace ProdutosWebApi.Data
{
    public class ProductDAO : IProductDAO
    {
                     
        public Product Add(Product item)
        {
            Product produto;
            using (var contexto = new ProductContext())
            {
                produto = contexto.Products.Add(item);
                contexto.SaveChanges();
                return produto;
            }
        }

        public Product Get(int id)
        {
            using(var contexto = new ProductContext())
            {
                var productList = contexto.Products.ToList();
                return productList.Find(p => p.Id.Equals(id));
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (var contexto = new ProductContext())
            {
                return contexto.Products.ToList();
            }
        }

        public void Remove(int id)
        {
            using(var contexto = new ProductContext())
            {
                var product = contexto.Products.ToList().Find(p => p.Id.Equals(id));
                if(product != null){
                    contexto.Products.Attach(product);
                    contexto.Products.Remove(product);

                    contexto.SaveChanges();
                }
                else
                {
                    throw new Exception("Produto não encontrado");
                }
            }
        }

        public bool Update(Product item)
        {
            using(var contexto = new ProductContext())
            {
                var productList = contexto.Products.ToList();
                Product produto = productList.Where(p => p.Id.Equals(item.Id)).First();
                if (produto != null)
                {
                    produto = item;
                    contexto.SaveChanges();
                    return true;
                } else
                {
                    return false;
                }
            }
        }
    }
}