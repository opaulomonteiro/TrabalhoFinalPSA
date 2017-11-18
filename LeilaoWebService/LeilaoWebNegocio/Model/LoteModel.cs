using System.Collections.Generic;

namespace LeilaoWebNegocio.Model
{
    public class LoteModel
    {
        public int ID { get; set; }
        public ICollection<ProdutoModel> Produtos { get; set; }
    }
}
