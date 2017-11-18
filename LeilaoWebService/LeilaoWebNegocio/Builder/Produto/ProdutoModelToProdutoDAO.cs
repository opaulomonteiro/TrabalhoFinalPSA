using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Models;

namespace LeilaoWebNegocio.Builder
{
    class ProdutoModelToProdutoDAO
    {
        public Produto Convert(ProdutoModel model)
        {
            Produto produtoFromDB = new Produto();
            produtoFromDB.ID = model.ID;
            produtoFromDB.BreveDescricao = model.BreveDescricao;
            produtoFromDB.DescricaoCompleta = model.DescricaoCompleta;
            produtoFromDB.Categoria = model.Categoria;
            return produtoFromDB;
        }
    }
}
