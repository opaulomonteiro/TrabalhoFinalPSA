using System;
using System.ComponentModel.DataAnnotations;

namespace LeilaoWebPersistencia.Models
{
    public class Leilao
    {
        public int LeilaoID { get; set; }
        public string Natureza { get; set; }
        public string Forma { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeFim { get; set; }
        public virtual Usuario Usuario { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double LanceMinimo { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double LanceMaximo { get; set; }
        public virtual Lote Lote { get; set; }
    }
}
