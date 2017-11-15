using System.Net;
using System.Web.Mvc;
using LeilaoWebPersistencia.Models;
using LeilaoWebNegocio;

namespace LeilaoWeb.Controllers
{
    public class LoteController : Controller
    {
        private LeilaoWebFachada leilaoFachada = new LeilaoWebFachada();

        // GET: Lote
        public ActionResult Index()
        {
            return View(leilaoFachada.BuscarTodosLotes());
        }

        // GET: Lote/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = leilaoFachada.BuscarLotePorId(id.Value);
            if (lote == null)
            {
                return HttpNotFound();
            }
            return View(lote);
        }

        // GET: Lote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                leilaoFachada.CriarLote(lote);
                return RedirectToAction("Index");
            }

            return View(lote);
        }

        // GET: Lote/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = leilaoFachada.BuscarLotePorId(id.Value);
            if (lote == null)
            {
                return HttpNotFound();
            }
            return View(lote);
        }

        // POST: Lote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                leilaoFachada.EditarLote(lote);
                return RedirectToAction("Index");
            }
            return View(lote);
        }

        // GET: Lote/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = leilaoFachada.BuscarLotePorId(id.Value);
            if (lote == null)
            {
                return HttpNotFound();
            }
            return View(lote);
        }

        // POST: Lote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            leilaoFachada.ExcluirLote(id);
            return RedirectToAction("Index");
        }        
    }
}
