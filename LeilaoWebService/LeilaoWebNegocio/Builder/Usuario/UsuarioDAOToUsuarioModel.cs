using LeilaoWebNegocio.Model;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoWebNegocio.Builder
{
    class UsuarioDAOToUsuarioModel
    {
        public UsuarioModel Convert(Usuario usuarioFromDB)
        {
            UsuarioModel model = new UsuarioModel();
            model.ID = usuarioFromDB.UsuarioID;
            model.Nome = usuarioFromDB.Nome;
            model.Cpf = usuarioFromDB.Cpf;
            model.Cnpj = usuarioFromDB.Cnpj;
            model.Email = usuarioFromDB.Email;
            return model;
        }

        public IEnumerable<UsuarioModel> ConvertList(IEnumerable<Usuario> usuariosDB)
        {
            IEnumerable<UsuarioModel> usuariosModel = new List<UsuarioModel>();

            usuariosDB.ToList().ForEach(u => usuariosModel.ToList().Add(Convert(u)));
            return usuariosModel;
        }
    }
}
