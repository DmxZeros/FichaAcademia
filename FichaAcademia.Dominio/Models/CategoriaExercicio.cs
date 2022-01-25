using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FichaAcademia.Dominio.Models
{
    public class CategoriaExercicio
    {
        public int CategoriaExercicioId { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [Remote("CategoriaExiste", "CategoriasExercicios", AdditionalFields = "CategoriaExercicioId")]
        public string Nome { get; set; }
        public ICollection<Exercicio> Exercicios {get;set;}
    }
}
