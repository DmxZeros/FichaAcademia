using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FichaAcademia.Dominio.Models
{
    public class Ficha
    {
        public int FichaId { get; set; }

        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [Remote("FichaExiste", "Fichas", AdditionalFields = "FichaId")]
        public string Nome { get; set; }

        public DateTime Cadastro { get; set; }

        public DateTime Validade { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public ICollection<ListaExercicio> ListaExercicios { get; set; }
    }
}
