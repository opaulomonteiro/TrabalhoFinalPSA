using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeilaoWebService.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string BreveDescricao { get; set; }
        public string DescricaoCompleta { get; set; }
        public string Categoria { get; set; }
    }
}