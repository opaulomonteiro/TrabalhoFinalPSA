using LeilaoWebService.Data;
using LeilaoWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeilaoWebService.Service
{
    public class LeilaoService
    {
        static readonly ILeilaoDAO repository = new LeilaoDAO();

        public IEnumerable<Leilao> GetAll()
        {
            return repository.GetAll();
        }

        public Leilao GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}