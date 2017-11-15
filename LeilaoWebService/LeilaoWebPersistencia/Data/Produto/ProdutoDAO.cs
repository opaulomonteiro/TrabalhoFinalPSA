using LeilaoWebPersistencia.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace LeilaoWebPersistencia.Data
{
    public class ProdutoDAO : IProdutoDAO
    {
        public Produto Add(Produto produto)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    Produto produtoAcidionado;
                    produtoAcidionado = contexto.Produto.Add(produto);
                    contexto.SaveChanges();
                    return produtoAcidionado;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao salvar o produto no banco", e.Source);
                return null;
            }
        }

        public IEnumerable<Produto> GetAll()
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    IEnumerable<Produto> produtos = contexto.Produto.ToList();
                    return produtos;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao buscar os produtos do banco", e.Source);
                return new List<Produto>();
            }
        }

        public Produto GetById(int id)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var listaDeProdutos = contexto.Produto.ToList();
                    return listaDeProdutos.Find(p => p.ID.Equals(id));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao buscar o produto pelo Id", e.Source);
                return null;
            }
        }

        public void Remove(int id)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var produto  = contexto.Produto.ToList().Find(p => p.ID.Equals(id));
                    if (produto != null)
                    {
                        contexto.Produto.Attach(produto);
                        contexto.Produto.Remove(produto);

                        contexto.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao remover um produto", e.Source);
            }
        }

        public bool Update(Produto produto)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var listaDeProdutos = contexto.Produto.ToList();
                    Produto produtoDoBanco = listaDeProdutos.Where(u => u.ID.Equals(produto.ID)).First();
                    if (produtoDoBanco != null)
                    {
                        produtoDoBanco.BreveDescricao = produto.BreveDescricao;
                        produtoDoBanco.Categoria = produto.Categoria;
                        produtoDoBanco.DescricaoCompleta = produto.DescricaoCompleta;

                        contexto.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao fazer o update do produto", e.Source);
                return false;
            }
        }
    }
}
