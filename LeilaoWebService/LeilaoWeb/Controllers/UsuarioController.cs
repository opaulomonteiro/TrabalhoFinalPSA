using System.Net;
using System.Web.Mvc;
using LeilaoWebPersistencia.Models;
using LeilaoWebNegocio;

namespace LeilaoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private LeilaoWebFachada leilaoFachada = new LeilaoWebFachada();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(leilaoFachada.BuscarToDosUsuarios());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = leilaoFachada.BuscarUsuarioPorId(id.Value);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
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
        public ActionResult Create([Bind(Include = "UsuarioID,Nome,Cpf,Cnpj,Email")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                leilaoFachada.CriarUsuario(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = leilaoFachada.BuscarUsuarioPorId(id.Value);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioID,Nome,Cpf,Cnpj,Email")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                leilaoFachada.EditarUsuario(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = leilaoFachada.BuscarUsuarioPorId(id.Value);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            leilaoFachada.ExcluirUsuario(id);
            return RedirectToAction("Index");
        }
    }
}
