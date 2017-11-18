using System;
using System.ComponentModel.DataAnnotations;

namespace LeilaoWebNegocio.Model
{
    public class LeilaoModel
    {
        public int ID { get; set; }
        public string Natureza { get; set; }
        public string Forma { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeFim { get; set; }
        public UsuarioModel Usuario { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double LanceMinimo { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double LanceMaximo { get; set; }
        public LoteModel Lote { get; set; }
    }
}
