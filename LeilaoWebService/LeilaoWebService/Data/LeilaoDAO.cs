using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeilaoWebService.Models;

namespace LeilaoWebService.Data
{
    public class LeilaoDAO : ILeilaoDAO
    {
        public IEnumerable<Leilao> GetAll()
        {
            using (var contexto = new LeilaoContext())
            {
                //fazendo load das entidades filhas
                var leilao = contexto.Leilao
                    .Include("Lotes.Produtos")
                    .Include("Usuario")
                    .ToList();
                return leilao;
            }
        }

        public Leilao GetById(int id)
        {
            using (var contexto = new LeilaoContext())
            {                
                var leilao = contexto.Leilao
                    .Include("Lotes.Produtos")
                    .Include("Usuario")
                    .ToList()
                    .Find(l => l.LeilaoID.Equals(id));
                return leilao;
            }
        }
    }
}