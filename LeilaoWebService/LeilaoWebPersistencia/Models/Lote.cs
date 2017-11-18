using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeilaoWebPersistencia.Models
{
    public class Lote
    {
        [Key, ForeignKey("Leilao"), Column("LeilaoID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID;
        public int LoteID { get; set; }
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
