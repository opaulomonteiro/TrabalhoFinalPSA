using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoWebNegocio.Builder
{
    public class LeilaoDAOToLeilaoModel
    {
        public LeilaoModel Convert(Leilao leilaoFromDB)
        {
            LeilaoModel model = new LeilaoModel();
            model.ID = leilaoFromDB.LeilaoID;
            model.Forma = leilaoFromDB.Forma;
            model.DataDeInicio = leilaoFromDB.DataDeInicio;
            model.DataDeFim = leilaoFromDB.DataDeFim;
            model.Lote = getLoteModel(leilaoFromDB.Lote);
            model.Natureza = leilaoFromDB.Natureza;
            model.LanceMinimo = leilaoFromDB.LanceMinimo;
            model.LanceMaximo = leilaoFromDB.LanceMaximo;
            model.Usuario = getUsuarioModel(leilaoFromDB.Usuario);
            return model;
        }

        private LoteModel getLoteModel(Lote loteFromDB)
        {
            LoteDAOToLoteModel converter = new LoteDAOToLoteModel();
            return converter.Convert(loteFromDB);
        }

        private UsuarioModel getUsuarioModel(Usuario usuarioFromDB)
        {
            UsuarioDAOToUsuarioModel converter = new UsuarioDAOToUsuarioModel();
            return converter.Convert(usuarioFromDB);
        }

        public IEnumerable<LeilaoModel> ConvertList(IEnumerable<Leilao> leiloesDB)
        {
            List<LeilaoModel> leiloesModel = new List<LeilaoModel>();
            
            leiloesDB.ToList().ForEach(p => leiloesModel.Add(Convert(p)));
            return leiloesModel.AsEnumerable();
        }
    }
}
