using LeilaoWebNegocio.Builder;
using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Data;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;

namespace LeilaoWebNegocio
{
    public class LeilaoWebFachada
    {
        private LeilaoDAO leilaoDAO = new LeilaoDAO();
        private LeilaoDAOToLeilaoModel convertToModel = new LeilaoDAOToLeilaoModel();
        private LeilaoModelToLeilaoDAO convertToDAO = new LeilaoModelToLeilaoDAO();


        private LeilaoModel getLeilaoModel(Leilao leilao)
        {
            return convertToModel.Convert(leilao);
        }

        private Leilao getLeilaoDAO(LeilaoModel leilaoModel)
        {
            return convertToDAO.Convert(leilaoModel);
        }

        public LeilaoModel CriarLeilao(LeilaoModel leilao)
        {
            Leilao leilaoSaved = leilaoDAO.Add(getLeilaoDAO(leilao));
            return getLeilaoModel(leilaoSaved);
        }            

        public IEnumerable<LeilaoModel> BuscarTodosLeiloes()
        {
            IEnumerable<Leilao> leiloes = leilaoDAO.GetAll();
            return convertToModel.ConvertList(leiloes);
        }     

        public LeilaoModel BuscarLeilaoPorId(int id)
        {
            return getLeilaoModel(leilaoDAO.GetById(id));
        }

        public void ExcluirLeilao(int id)
        {
            leilaoDAO.Remove(id);
        }

        public bool EditarLeilao(LeilaoModel leilao)
        {
            return leilaoDAO.Update(getLeilaoDAO(leilao));
        }

    }
}
