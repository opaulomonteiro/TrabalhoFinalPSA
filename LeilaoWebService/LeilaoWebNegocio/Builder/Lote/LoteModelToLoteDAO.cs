using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoWebNegocio.Builder
{
    class LoteModelToLoteDAO
    {
        public Lote Convert(LoteModel model)
        {
            Lote modelFromDB = new Lote();
            modelFromDB.LoteID = model.ID;
            modelFromDB.Produto = getProdutoDAO(model.Produtos);
            return modelFromDB;
        }

        private List<Produto> getProdutoDAO(ICollection<ProdutoModel> produtosModel)
        {
            ProdutoModelToProdutoDAO converter = new ProdutoModelToProdutoDAO();

            List<Produto> listProdutos = new List<Produto>();

            produtosModel.ToList().ForEach(produto => listProdutos.Add(converter.Convert(produto)));

            return listProdutos;
        }
    }
}
