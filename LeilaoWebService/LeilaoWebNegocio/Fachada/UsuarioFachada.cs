using LeilaoWebNegocio.Builder;
using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Data;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;

namespace LeilaoWebNegocio.Fachada
{
    public class UsuarioFachada
    {
        private UsuarioDAO usuarioDao = new UsuarioDAO();
        private UsuarioDAOToUsuarioModel convertToModel = new UsuarioDAOToUsuarioModel();
        private UsuarioModelToUsuarioDAO convertToDAO = new UsuarioModelToUsuarioDAO();

        private UsuarioModel getUsuarioModel(Usuario usuario)
        {
            return convertToModel.Convert(usuario);
        }

        private Usuario getUsuarioDAO(UsuarioModel usuarioModel)
        {
            return convertToDAO.Convert(usuarioModel);
        }

        public UsuarioModel Add(UsuarioModel usuario)
        {
            Usuario usuarioSaved = usuarioDao.Add(getUsuarioDAO(usuario));
            return getUsuarioModel(usuarioSaved);
        }

        public IEnumerable<UsuarioModel> GetAll()
        {
            IEnumerable<Usuario> usuarios = usuarioDao.GetAll();

            return convertToModel.ConvertList(usuarios);
        }

        public UsuarioModel GetById(int id)
        {
            return getUsuarioModel(usuarioDao.GetById(id));
        }

        public void Remove(int id)
        {
            usuarioDao.Remove(id);
        }

        public bool Update(UsuarioModel usuario)
        {
            return usuarioDao.Update(getUsuarioDAO(usuario));
        }
    }
}
