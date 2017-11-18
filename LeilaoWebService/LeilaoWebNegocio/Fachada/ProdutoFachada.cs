using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Data;
using LeilaoWebNegocio.Builder;     
using System.Collections.Generic;
using LeilaoWebPersistencia.Models;

namespace LeilaoWebNegocio.Fachada
{
    public class ProdutoFachada
    {
        ProdutoDAO produtoDAO = new ProdutoDAO();
        private ProdutoDAOToProdutoModel convertToModel = new ProdutoDAOToProdutoModel();
        private ProdutoModelToProdutoDAO convertToDAO = new ProdutoModelToProdutoDAO();

        private ProdutoModel getProdutoModel(Produto produto)
        {
            return convertToModel.Convert(produto);
        }

        private Produto getProdutoDAO(ProdutoModel usuarioModel)
        {
            return convertToDAO.Convert(usuarioModel);
        }

        public ProdutoModel Add(ProdutoModel produto)
        {
            Produto produtoSaved = produtoDAO.Add(getProdutoDAO(produto));
            return getProdutoModel(produtoSaved);
        }

        public IEnumerable<ProdutoModel> GetAll()
        {
            IEnumerable<Produto> produtos = produtoDAO.GetAll();
            return convertToModel.ConvertList(produtos);
        }


        public ProdutoModel GetById(int id)
        {
            return getProdutoModel(produtoDAO.GetById(id));            
        }

        public void Remove(int id)
        {
            produtoDAO.Remove(id);
        }

        public bool Update(ProdutoModel produto)
        {
            return produtoDAO.Update(getProdutoDAO(produto));
        }
    }
}
