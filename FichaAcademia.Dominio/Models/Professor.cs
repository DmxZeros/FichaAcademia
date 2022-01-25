using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FichaAcademia.Dominio.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(50, ErrorMessage ="Máximo 50 caracteres")]
        [Remote("ProfessorExiste", "Professores", AdditionalFields = "ProfessorId")]
        public string Nome { get; set; }
        
        public string Foto { get; set; }
        
        [Required(ErrorMessage ="Campo obrigátorio")]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage ="Campo obrigátorio")]
        [StringLength(10, ErrorMessage ="Máximo 10 caracteres")]
        public string Turno { get; set; }
        public ICollection<Aluno> Alunos { get; set; }

    }
}
