using LeilaoWebNegocio.Service;
using LeilaoWebPersistencia.Models;
using System.Collections.Generic;

namespace LeilaoWebNegocio
{
    public class LeilaoWebFachada
    {
        UsuarioService usuarioSerive = new UsuarioService();

        public Usuario CriarUsuario(Usuario usuario)
        {
            return usuarioSerive.Add(usuario);
        }

        public IEnumerable<Usuario> BuscarToDosUsuarios()
        {
            return usuarioSerive.GetAll();
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return usuarioSerive.GetById(id);
        }

        public void ExcluirUsuario(int id)
        {
            usuarioSerive.Remove(id);
        }

        public bool EditarUsuario(Usuario usuario)
        {
            return usuarioSerive.Update(usuario);
        }

        ProdutoService produtoService = new ProdutoService();

        public Produto CriarProduto(Produto produto)
        {
            return produtoService.Add(produto);
        }

        public IEnumerable<Produto> BuscarToDosProdutos()
        {
            return produtoService.GetAll();
        }

        public Produto BuscarProdutoPorId(int id)
        {
            return produtoService.GetById(id);
        }

        public void ExcluirProduto(int id)
        {
            produtoService.Remove(id);
        }

        public bool EditarProduto(Produto produto)
        {
            return produtoService.Update(produto);
        }



        LoteService loteService = new LoteService();

        public Lote CriarLote(Lote lote)
        {
            return loteService.Add(lote);
        }

        public IEnumerable<Lote> BuscarTodosLotes()
        {
            return loteService.GetAll();
        }

        public Lote BuscarLotePorId(int id)
        {
            return loteService.GetById(id);
        }

        public void ExcluirLote(int id)
        {
            loteService.Remove(id);
        }

        public bool EditarLote(Lote lote)
        {
            return loteService.Update(lote);
        }

        LeilaoService leilaoService = new LeilaoService();

        public Leilao CriarLeilao(Leilao leilao)
        {
            return leilaoService.Add(leilao);
        }

        public IEnumerable<Leilao> BuscarTodosLeiloes()
        {
            return leilaoService.GetAll();
        }

        public Leilao BuscarLeilaoPorId(int id)
        {
            return leilaoService.GetById(id);
        }

        public void ExcluirLeilao(int id)
        {
            leilaoService.Remove(id);
        }

        public bool EditarLeilao(Leilao leilao)
        {
            return leilaoService.Update(leilao);
        }

    }
}
