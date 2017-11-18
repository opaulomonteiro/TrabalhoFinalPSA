using System.Net;
using System.Web.Mvc;
using LeilaoWebNegocio.Model;
using LeilaoWebNegocio.Fachada;

namespace LeilaoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioFachada fachada = new UsuarioFachada();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(fachada.GetAll());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioModel usuarioModel = fachada.GetById(id.Value);
            if (usuarioModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioModel);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Cpf,Cnpj,Email")] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                fachada.Add(usuarioModel);
                return RedirectToAction("Index");
            }

            return View(usuarioModel);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioModel usuarioModel = fachada.GetById(id.Value);
            if (usuarioModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioModel);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Cpf,Cnpj,Email")] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                fachada.Update(usuarioModel);
                return RedirectToAction("Index");
            }
            return View(usuarioModel);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioModel usuarioModel = fachada.GetById(id.Value);
            if (usuarioModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fachada.Remove(id);
            return RedirectToAction("Index");
        }        
    }
}
