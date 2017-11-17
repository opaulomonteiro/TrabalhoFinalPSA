using LeilaoWebPersistencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoWebPersistencia.Data
{
    public class LeilaoDAO : ILeilaoDAO
    {
        public Leilao Add(Leilao leilao)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    Leilao leilaoAdicionado;
                    leilaoAdicionado = contexto.Leilao.Add(leilao);
                    contexto.SaveChanges();
                    return leilaoAdicionado;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao salvar o leilao no banco", e.Source);
                return null;
            }
        }

        public IEnumerable<Leilao> GetAll()
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    //fazendo load das entidades filhas
                    var leiloes = contexto.Leilao
                        .Include("Lotes.Produtos")
                        .Include("Usuario")
                        .ToList();
                    return leiloes;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao buscar os leiloes do banco", e.Source);
                return new List<Leilao>();
            }
        }

        public Leilao GetById(int id)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var leilao = contexto.Leilao
                     .Include("Lotes.Produtos")
                     .Include("Usuario")
                     .ToList()
                     .Find(l => l.ID.Equals(id));
                    return leilao;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao buscar o leilao pelo Id", e.Source);
                return null;
            }
        }

        public void Remove(int id)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var leilao = contexto.Leilao.ToList().Find(p => p.ID.Equals(id));
                    if (leilao != null)
                    {
                        contexto.Leilao.Attach(leilao);
                        contexto.Leilao.Remove(leilao);

                        contexto.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao remover um leilao", e.Source);
            }
        }

        public bool Update(Leilao leilao)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var listaDeLeiloes = contexto.Leilao.ToList();
                    Leilao leilaoDoBanco = listaDeLeiloes.Where(u => u.ID.Equals(leilao.ID)).First();
                    if (leilaoDoBanco != null)
                    {
                        leilaoDoBanco.Usuario = leilao.Usuario;
                        leilaoDoBanco.Natureza = leilao.Natureza;
                        leilaoDoBanco.Lote = leilao.Lote;
                        leilaoDoBanco.Forma = leilao.Forma;
                        leilaoDoBanco.DataDeFim = leilao.DataDeFim;
                        leilaoDoBanco.DataDeInicio = leilao.DataDeInicio;
                        leilaoDoBanco.LanceMaximo = leilao.LanceMaximo;
                        leilaoDoBanco.LanceMinimo = leilao.LanceMinimo;

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
                Console.WriteLine("Ocorreu um erro ao fazer o update do leilao", e.Source);
                return false;
            }
        }
    }
}
