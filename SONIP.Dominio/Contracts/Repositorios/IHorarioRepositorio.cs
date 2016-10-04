using SONIP.Dominio.Models;
using System;
using System.Threading.Tasks;

namespace SONIP.Dominio.Contracts.Repositorios
{
    public interface IHorarioRepositorio : IDisposable
    {
        Task<Horarios> Get(int ID);
        Task<Horarios> GetDesignacao(string value);
        void Create(Horarios horario);
        void Update(Horarios horario);
        void Delete(Horarios horario);
    }
}
