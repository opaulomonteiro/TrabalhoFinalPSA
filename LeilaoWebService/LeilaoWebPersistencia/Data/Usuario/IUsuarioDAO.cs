using LeilaoWebPersistencia.Models;
using System.Collections.Generic;

namespace LeilaoWebPersistencia.Data
{
    interface IUsuarioDAO
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        Usuario Add(Usuario usuario);
        void Remove(int id);
        bool Update(Usuario usuario);
    }
}
