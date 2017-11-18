using System.Net;
using System.Web.Mvc;
using LeilaoWebNegocio.Model;
using LeilaoWebNegocio.Fachada;

namespace LeilaoWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoFachada fachada = new ProdutoFachada();

        // GET: Produto
        public ActionResult Index()
        {
            return View(fachada.GetAll());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoModel produtoModel = fachada.GetById(id.Value);
            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoModel);
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
        public ActionResult Create([Bind(Include = "ID,BreveDescricao,DescricaoCompleta,Categoria")] ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                fachada.Add(produtoModel);
                return RedirectToAction("Index");
            }

            return View(produtoModel);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoModel produtoModel = fachada.GetById(id.Value);
            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoModel);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BreveDescricao,DescricaoCompleta,Categoria")] ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                fachada.Update(produtoModel);
                return RedirectToAction("Index");
            }
            return View(produtoModel);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoModel produtoModel = fachada.GetById(id.Value);
            if (produtoModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fachada.Remove(id);
            return RedirectToAction("Index");
        }       
    }
}
