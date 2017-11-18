using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using LeilaoWebNegocio.Model;
using LeilaoWebNegocio;
using System.Net.Http;
using LeilaoWebPersistencia.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using LeilaoWebNegocio.Builder;

namespace LeilaoWeb.Controllers
{
    public class LeilaoController : Controller
    {
        private LeilaoWebFachada leilaoFachada = new LeilaoWebFachada();

        // GET: Leilao
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50992/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Leilao> leilao = null;
            HttpResponseMessage response = await client.GetAsync("api/leilao");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                leilao = JsonConvert.DeserializeObject<IEnumerable<Leilao>>(content);
            }

            IEnumerable<LeilaoModel> leiloesModel = new LeilaoDAOToLeilaoModel().ConvertList(leilao);

            return View(leiloesModel);
        }

        // GET: Leilao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeilaoModel leilao = leilaoFachada.BuscarLeilaoPorId(id.Value);
            if (leilao == null)
            {
                return HttpNotFound();
            }
            return View(leilao);
        }

        // GET: Leilao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leilao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoteID,Natureza,Forma,DataDeInicio,DataDeFim,LanceMinimo,LanceMaximo")] LeilaoModel leilaoModel)
        {
            if (ModelState.IsValid)
            {
                leilaoFachada.CriarLeilao(leilaoModel);
                return RedirectToAction("Index");
            }

            return View(leilaoModel);
        }

        // GET: Leilao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeilaoModel leilao = leilaoFachada.BuscarLeilaoPorId(id.Value);
            if (leilao == null)
            {
                return HttpNotFound();
            }
            return View(leilao);
        }

        // POST: Leilao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoteID,Natureza,Forma,DataDeInicio,DataDeFim,LanceMinimo,LanceMaximo")] LeilaoModel leilaoModel)
        {
            if (ModelState.IsValid)
            {
                leilaoFachada.EditarLeilao(leilaoModel);
                return RedirectToAction("Index");
            }
            return View(leilaoModel);
        }

        // GET: Leilao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeilaoModel leilao = leilaoFachada.BuscarLeilaoPorId(id.Value);
            if (leilao == null)
            {
                return HttpNotFound();
            }
            return View(leilao);
        }

        // POST: Leilao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            leilaoFachada.ExcluirLeilao(id);
            return RedirectToAction("Index");
        }
    }
}
