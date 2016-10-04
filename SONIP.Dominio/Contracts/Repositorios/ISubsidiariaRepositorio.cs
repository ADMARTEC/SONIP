using SONIP.Dominio.Models;
using System;
using System.Threading.Tasks;

namespace SONIP.Dominio.Contracts.Repositorios
{
    public interface ISubsidiariaRepositorio : IDisposable
    {
        Task<Subsidiarias> GetDesignacao(string value);
        Task<Subsidiarias> Get(int ID);
        Task<Subsidiarias> GetEmail(string value);
        void Create(Subsidiarias subsidiaria);
        void Update(Subsidiarias subsidiaria);
        void Delete(Subsidiarias subsidiaria);
    }
}
