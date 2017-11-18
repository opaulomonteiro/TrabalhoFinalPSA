using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Models;

namespace LeilaoWebNegocio.Builder
{
    class LeilaoModelToLeilaoDAO
    {
        public Leilao Convert(LeilaoModel model)
        {
            Leilao leilaoDAO = new Leilao();
            leilaoDAO.LeilaoID = model.ID;
            leilaoDAO.Forma = model.Forma;
            leilaoDAO.DataDeInicio = model.DataDeInicio;
            leilaoDAO.DataDeFim = model.DataDeFim;
            leilaoDAO.Lote = getLoteModel(model.Lote);
            leilaoDAO.Natureza = model.Natureza;
            leilaoDAO.LanceMinimo = model.LanceMinimo;
            leilaoDAO.LanceMaximo = model.LanceMaximo;
            leilaoDAO.Usuario = getUsuarioModel(model.Usuario);
            return leilaoDAO;
        }

        private Lote getLoteModel(LoteModel model)
        {
            LoteModelToLoteDAO converter = new LoteModelToLoteDAO();
            return converter.Convert(model);
        }

        private Usuario getUsuarioModel(UsuarioModel model)
        {
            UsuarioModelToUsuarioDAO converter = new UsuarioModelToUsuarioDAO();
            return converter.Convert(model);
        }
    }
}
