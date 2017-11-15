using LeilaoWebPersistencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoWebPersistencia.Data
{
    public class LoteDAO : ILoteDAO
    {
        public Lote Add(Lote lote)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    Lote loteAdicionado;
                    loteAdicionado = contexto.Lote.Add(lote);
                    contexto.SaveChanges();
                    return loteAdicionado;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao salvar o lote no banco", e.Source);
                return null;
            }
        }

        public IEnumerable<Lote> GetAll()
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    IEnumerable<Lote> lotes = contexto.Lote.ToList();
                    return lotes;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao buscar os lotes do banco", e.Source);
                return new List<Lote>();
            }
        }

        public Lote GetById(int id)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var listaDeLotes = contexto.Lote.ToList();
                    return listaDeLotes.Find(p => p.ID.Equals(id));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao buscar o lote pelo Id", e.Source);
                return null;
            }
        }

        public void Remove(int id)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var lote = contexto.Lote.ToList().Find(p => p.ID.Equals(id));
                    if (lote != null)
                    {
                        contexto.Lote.Attach(lote);
                        contexto.Lote.Remove(lote);

                        contexto.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao remover um lote", e.Source);
            }
        }

        public bool Update(Lote lote)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var listaDeLotes = contexto.Lote.ToList();
                    Lote loteDoBanco = listaDeLotes.Where(u => u.ID.Equals(lote.ID)).First();
                    if (loteDoBanco != null)
                    {
                        loteDoBanco.Produtos = lote.Produtos;

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
                Console.WriteLine("Ocorreu um erro ao fazer o update do lote", e.Source);
                return false;
            }
        }
    }
}
