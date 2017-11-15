using LeilaoWebPersistencia.Data;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;

namespace LeilaoWebNegocio.Service
{
    class LeilaoService
    {
        LeilaoDAO leilaoDAO = new LeilaoDAO();

        public Leilao Add(Leilao leilao)
        {
            return leilaoDAO.Add(leilao);
        }

        public IEnumerable<Leilao> GetAll()
        {
            return leilaoDAO.GetAll();
        }

        public Leilao GetById(int id)
        {
            return leilaoDAO.GetById(id);
        }

        public void Remove(int id)
        {
            leilaoDAO.Remove(id);
        }

        public bool Update(Leilao leilao)
        {
            return leilaoDAO.Update(leilao);
        }
    }
}
