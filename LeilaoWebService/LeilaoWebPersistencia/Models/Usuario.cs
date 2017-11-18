
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeilaoWebPersistencia.Models
{
    public class Usuario
    {
        [Key, ForeignKey("Leilao"), Column("IDdoLeilao")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID;
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
    }
}
