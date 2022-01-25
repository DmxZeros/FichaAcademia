using System;
using System.Collections.Generic;
using System.Text;

namespace FichaAcademia.Dominio.Models
{
    public class Administrador
    {
        public int AdministradorID { get; set; }
        public string Nome { set; get; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
