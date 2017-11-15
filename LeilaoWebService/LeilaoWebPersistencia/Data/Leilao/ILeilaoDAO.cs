using LeilaoWebPersistencia.Models;
using System.Collections.Generic;

namespace LeilaoWebPersistencia.Data
{
    interface ILeilaoDAO
    {
        IEnumerable<Leilao> GetAll();
        Leilao GetById(int id);
        Leilao Add(Leilao leilao);
        void Remove(int id);
        bool Update(Leilao leilao);
    }
}
