using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FichaAcademia.Dominio.Models
{
   public  class Exercicio
    {
        public int ExercicioId { get; set; }
        
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [Remote("ExercicioExiste", "Exercicios", AdditionalFields ="ExercicioId")]
        public string Nome { get; set; }
        public int CategoriaExercicioId { get; set; }
        public CategoriaExercicio CategoriaExercicio { get; set; }
        public ICollection<ListaExercicio> ListaExercicios { get; set; }
    }
}
