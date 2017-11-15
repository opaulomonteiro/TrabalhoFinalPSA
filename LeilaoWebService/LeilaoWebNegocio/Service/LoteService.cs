using LeilaoWebPersistencia.Data;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;

namespace LeilaoWebNegocio.Service
{
    class LoteService
    {
        LoteDAO loteDAO = new LoteDAO();

        public Lote Add(Lote lote)
        {
            return loteDAO.Add(lote);
        }

        public IEnumerable<Lote> GetAll()
        {
            return loteDAO.GetAll();
        }

        public Lote GetById(int id)
        {
            return loteDAO.GetById(id);
        }

        public void Remove(int id)
        {
            loteDAO.Remove(id);
        }

        public bool Update(Lote lote)
        {
            return loteDAO.Update(lote);
        }
    }
}
