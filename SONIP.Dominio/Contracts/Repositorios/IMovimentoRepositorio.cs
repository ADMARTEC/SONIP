using SONIP.Dominio.Models;
using System;
using System.Threading.Tasks;

namespace SONIP.Dominio.Contracts.Repositorios
{
    public interface IMovimentoRepositorio : IDisposable
    {
        Task<Movimentos> Get(int ID);
        Task<Movimentos> GetFuncionario(int funcionarioID);
        Task<Movimentos> GetPeriodoMovim(int funcionario, int horario, DateTime data);
        void Create(Movimentos movimento);
        void Update(Movimentos movimento);
        void Delete(Movimentos movimento);
    }
}
