using LeilaoWebNegocio.Builder;
using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Data;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;

namespace LeilaoWebNegocio.Fachada
{
    public class LoteFachada
    {
        private LoteDAO loteDAO = new LoteDAO();
        private LoteDAOToLoteModel convertToModel = new LoteDAOToLoteModel();
        private LoteModelToLoteDAO convertToDAO = new LoteModelToLoteDAO();

        private LoteModel getLoteModel(Lote lote)
        {
            return convertToModel.Convert(lote);
        }

        private Lote getLoteDAO(LoteModel loteModel)
        {
            return convertToDAO.Convert(loteModel);
        }

        public LoteModel Add(LoteModel lote)
        {
            Lote loteSaved = loteDAO.Add(getLoteDAO(lote));
            return getLoteModel(loteSaved);
        }

        public IEnumerable<LoteModel> GetAll()
        {
            IEnumerable<Lote> lotes = loteDAO.GetAll();

            return convertToModel.ConvertList(lotes);
        }

        public LoteModel GetById(int id)
        {
            return getLoteModel(loteDAO.GetById(id));
        }

        public void Remove(int id)
        {
            loteDAO.Remove(id);
        }

        public bool Update(LoteModel lote)
        {
            return loteDAO.Update(getLoteDAO(lote));
        }
    }
}
