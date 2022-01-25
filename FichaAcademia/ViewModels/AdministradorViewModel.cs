using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FichaAcademia.ViewModels
{
    public class AdministradorViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
