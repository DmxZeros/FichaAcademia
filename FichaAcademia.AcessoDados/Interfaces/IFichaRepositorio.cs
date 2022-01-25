using FichaAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FichaAcademia.AcessoDados.Interfaces
{
    public interface IFichaRepositorio: IRepositorioGenerico<Ficha>
    {
        Task<IEnumerable<Ficha>> PegarTodasFichasPeloAlunoId(int id);
        Task<Ficha> PegarFichaAlunoId(int id);
        Task<bool> FichaExiste(String Nome);
        Task<bool> FichaExiste(String Nome, int Fichad);
    }
}
