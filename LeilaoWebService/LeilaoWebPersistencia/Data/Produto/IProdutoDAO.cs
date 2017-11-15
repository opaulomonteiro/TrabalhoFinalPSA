using LeilaoWebPersistencia.Models;
using System.Collections.Generic;

namespace LeilaoWebPersistencia.Data
{
    interface IProdutoDAO
    {
        IEnumerable<Produto> GetAll();
        Produto GetById(int id);
        Produto Add(Produto produto);
        void Remove(int id);
        bool Update(Produto produto);
    }
}
