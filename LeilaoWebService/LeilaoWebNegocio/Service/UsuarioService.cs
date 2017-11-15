using LeilaoWebPersistencia.Data;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;

namespace LeilaoWebNegocio.Service
{
    class UsuarioService
    {
        UsuarioDAO usuarioDao = new UsuarioDAO();

        public Usuario Add(Usuario usuario)
        {
            return usuarioDao.Add(usuario);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return usuarioDao.GetAll();
        }

        public Usuario GetById(int id)
        {
            return usuarioDao.GetById(id);
        }

        public void Remove(int id)
        {
            usuarioDao.Remove(id);
        }

        public bool Update(Usuario usuario)
        {
            return usuarioDao.Update(usuario);
        }
    }
}
