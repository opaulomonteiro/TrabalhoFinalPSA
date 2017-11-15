using System.Collections.Generic;

namespace LeilaoWebPersistencia.Models
{
    public class Lote
    {
        public int ID { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
