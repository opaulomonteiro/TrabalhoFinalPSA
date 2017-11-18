using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoWebNegocio.Builder
{
    class LoteDAOToLoteModel
    {
        public LoteModel Convert(Lote loteFromDB)
        {
            LoteModel model = new LoteModel();
            model.ID = loteFromDB.LoteID;
            model.Produtos = getProdutoModel(loteFromDB.Produto);
            return model;
        }

        private List<ProdutoModel> getProdutoModel(ICollection<Produto> produtosFromDB)
        {
            ProdutoDAOToProdutoModel converter = new ProdutoDAOToProdutoModel();

            List<ProdutoModel> listProdutos = new List<ProdutoModel>();

            produtosFromDB.ToList().ForEach(produto => listProdutos.Add(converter.Convert(produto)) );

            return listProdutos;
        }

        public IEnumerable<LoteModel> ConvertList(IEnumerable<Lote> lotesDB)
        {
            IEnumerable<LoteModel> lotesModel = new List<LoteModel>();

            lotesDB.ToList().ForEach(p => lotesModel.ToList().Add(Convert(p)));
            return lotesModel;
        }
    }
}
