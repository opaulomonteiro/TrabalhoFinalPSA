using LeilaoWebPersistencia.Models;
using System.Collections.Generic;

namespace LeilaoWebPersistencia.Data
{
    interface ILoteDAO
    {
        IEnumerable<Lote> GetAll();
        Lote GetById(int id);
        Lote Add(Lote lote);
        void Remove(int id);
        bool Update(Lote lote);
    }
}
