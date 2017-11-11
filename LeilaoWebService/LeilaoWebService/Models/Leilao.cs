using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeilaoWebService.Models
{
    public class Leilao
    {
        public int LeilaoID { get; set; }
        public string Natureza { get; set; }
        public string Forma { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeFim { get; set; }
        public virtual Usuario Usuario { get; set; }
        public double LanceMinimo { get; set; }
        public double LanceMaximo { get; set; }
        public virtual ICollection<Lote> Lotes { get; set; }
    }
}