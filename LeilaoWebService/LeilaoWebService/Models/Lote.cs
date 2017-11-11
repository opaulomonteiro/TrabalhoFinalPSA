using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeilaoWebService.Models
{
    public class Lote
    {
        public int LoteID { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}