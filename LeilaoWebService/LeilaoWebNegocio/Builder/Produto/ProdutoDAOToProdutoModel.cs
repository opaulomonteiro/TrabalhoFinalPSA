using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoWebNegocio.Builder
{
    class ProdutoDAOToProdutoModel
    {
        public ProdutoModel Convert(Produto produtoFromDB)
        {
            ProdutoModel model = new ProdutoModel();
            model.ID = produtoFromDB.ID;
            model.BreveDescricao = produtoFromDB.BreveDescricao;
            model.DescricaoCompleta = produtoFromDB.DescricaoCompleta;
            model.Categoria = produtoFromDB.Categoria;
            return model;
        }

        public IEnumerable<ProdutoModel> ConvertList(IEnumerable<Produto> produtosDB)
        {
            IEnumerable<ProdutoModel> produtosModel = new List<ProdutoModel>();

            produtosDB.ToList().ForEach(p => produtosModel.ToList().Add(Convert(p)));
            return produtosModel;
        }
    }
}
