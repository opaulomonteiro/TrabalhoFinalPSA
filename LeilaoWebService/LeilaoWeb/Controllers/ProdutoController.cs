using System.Net;
using System.Web.Mvc;
using LeilaoWebPersistencia.Models;
using LeilaoWebNegocio;

namespace LeilaoWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private LeilaoWebFachada leilaoFachada = new LeilaoWebFachada();

        // GET: Produto
        public ActionResult Index()
        {
            return View(leilaoFachada.BuscarToDosProdutos());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = leilaoFachada.BuscarProdutoPorId(id.Value);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BreveDescricao,DescricaoCompleta,Categoria")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                leilaoFachada.CriarProduto(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = leilaoFachada.BuscarProdutoPorId(id.Value);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BreveDescricao,DescricaoCompleta,Categoria")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                leilaoFachada.EditarProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = leilaoFachada.BuscarProdutoPorId(id.Value);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            leilaoFachada.ExcluirProduto(id);
            return RedirectToAction("Index");
        }        
    }
}
