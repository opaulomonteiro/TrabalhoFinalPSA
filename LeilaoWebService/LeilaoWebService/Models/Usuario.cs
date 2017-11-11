using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeilaoWebService.Models
{
    public class Usuario
    { 
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
    }
}