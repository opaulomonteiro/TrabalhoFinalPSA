using System;
using System.Collections.Generic;
using System.Linq;
using LeilaoWebPersistencia.Models;

namespace LeilaoWebPersistencia.Data
{
    public class UsuarioDAO : IUsuarioDAO
    {
        public Usuario Add(Usuario usuario)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    Usuario usuarioAdicionado;
                    usuarioAdicionado = contexto.Usuario.Add(usuario);
                    contexto.SaveChanges();
                    return usuarioAdicionado;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao salvar o usuario no banco", e.Source);
                return null;
            }

        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    IEnumerable < Usuario > usuarios = contexto.Usuario.ToList();
                    return usuarios;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao buscar os usuarios do banco", e.Source);
                return new List<Usuario>();
            }

        }

        public Usuario GetById(int id)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var listaDeUsuarios = contexto.Usuario.ToList();
                    return listaDeUsuarios.Find(u => u.UsuarioID.Equals(id));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao buscar o usuario pelo Id", e.Source);
                return null;
            }

        }

        public void Remove(int id)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var usuario = contexto.Usuario.ToList().Find(u => u.UsuarioID.Equals(id));
                    if (usuario != null)
                    {
                        contexto.Usuario.Attach(usuario);
                        contexto.Usuario.Remove(usuario);

                        contexto.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao remover um usuario", e.Source);
            }

        }

        public bool Update(Usuario usuario)
        {
            try
            {
                using (var contexto = new LeilaoContext())
                {
                    var listaDeUsuarios = contexto.Usuario.ToList();
                    Usuario usuarioDoBanco = listaDeUsuarios.Where(u => u.UsuarioID.Equals(usuario.UsuarioID)).First();
                    if (usuarioDoBanco != null)
                    {
                        usuarioDoBanco.Nome = usuario.Nome;
                        usuarioDoBanco.Cpf = usuario.Cpf;
                        usuarioDoBanco.Cnpj = usuario.Cnpj;
                        usuarioDoBanco.Email = usuario.Email;

                        contexto.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao fazer o update do usuario", e.Source);
                return false;
            }
        }
    }
}
