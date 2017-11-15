using LeilaoWebPersistencia.Data;
using LeilaoWebPersistencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeilaoWebNegocio.Service
{
    class ProdutoService
    {
        ProdutoDAO produtoDAO = new ProdutoDAO();

        public Produto Add(Produto produto)
        {
            return produtoDAO.Add(produto);
        }

        public IEnumerable<Produto> GetAll()
        {
            return produtoDAO.GetAll();
        }

        public Produto GetById(int id)
        {
            return produtoDAO.GetById(id);
        }

        public void Remove(int id)
        {
            produtoDAO.Remove(id);
        }

        public bool Update(Produto produto)
        {
            return produtoDAO.Update(produto);
        }
    }
}
