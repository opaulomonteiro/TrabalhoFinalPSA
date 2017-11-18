using System.Net;
using System.Web.Mvc;
using LeilaoWebNegocio.Model;
using LeilaoWebNegocio.Fachada;
using System.Collections.Generic;

namespace LeilaoWeb.Controllers
{
    public class LoteController : Controller
    {
        private LoteFachada fachada = new LoteFachada();

        // GET: Lote
        public ActionResult Index()
        {
            IEnumerable<LoteModel> models = fachada.GetAll();
            return View(models);
        }

        // GET: Lote/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteModel loteModel = fachada.GetById(id.Value);
            if (loteModel == null)
            {
                return HttpNotFound();
            }
            return View(loteModel);
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
        public ActionResult Create([Bind(Include = "ID")] LoteModel loteModel)
        {
            if (ModelState.IsValid)
            {
                fachada.Add(loteModel);
                return RedirectToAction("Index");
            }

            return View(loteModel);
        }

        // GET: Lote/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteModel loteModel = fachada.GetById(id.Value);
            if (loteModel == null)
            {
                return HttpNotFound();
            }
            return View(loteModel);
        }

        // POST: Lote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] LoteModel loteModel)
        {
            if (ModelState.IsValid)
            {
                fachada.Update(loteModel);
                return RedirectToAction("Index");
            }
            return View(loteModel);
        }

        // GET: Lote/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteModel loteModel = fachada.GetById(id.Value);
            if (loteModel == null)
            {
                return HttpNotFound();
            }
            return View(loteModel);
        }

        // POST: Lote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fachada.Remove(id);
            return RedirectToAction("Index");
        }        
    }
}
