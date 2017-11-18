using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Models;

namespace LeilaoWebNegocio.Builder
{
    class UsuarioModelToUsuarioDAO
    {
        public Usuario Convert(UsuarioModel usuarioModel)
        {
            Usuario usuarioDAO = new Usuario();
            usuarioDAO.UsuarioID = usuarioModel.ID;
            usuarioDAO.Nome = usuarioModel.Nome;
            usuarioDAO.Cpf = usuarioModel.Cpf;
            usuarioDAO.Cnpj = usuarioModel.Cnpj;
            usuarioDAO.Email = usuarioModel.Email;
            return usuarioDAO;
        }
    }
}
