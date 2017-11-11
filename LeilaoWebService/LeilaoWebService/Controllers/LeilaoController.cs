using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LeilaoWebService.Data;
using LeilaoWebService.Models;
using LeilaoWebService.Service;

namespace LeilaoWebService.Controllers
{
    public class LeilaoController : ApiController
    {
        private LeilaoService service = new LeilaoService();

        // GET: api/leilao
        public IEnumerable<Leilao> GetLeiloes()
        {
            return service.GetAll();
        }

        // GET: /api/leilao/id
        public Leilao GetLeilao(int id)
        {
            Leilao leilao = service.GetById(id);
            if (leilao == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return leilao;
        }               
    }
}