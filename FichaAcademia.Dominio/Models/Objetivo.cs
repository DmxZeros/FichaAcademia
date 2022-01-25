using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FichaAcademia.Dominio.Models
{
    public class Objetivo
    {
        public int ObjetivoId { get; set; }
        
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(50,ErrorMessage ="Máximo 50 caracteres")]
        [Remote("ObjetivoExiste", "Objetivos", AdditionalFields ="ObjetivoId")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(500,ErrorMessage ="Máximo 500 caracteres")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        public ICollection<Aluno> Alunos { get; set; }
    }
}
