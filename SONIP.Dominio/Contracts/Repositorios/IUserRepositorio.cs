using SONIP.Dominio.Models;
using System;
using System.Threading.Tasks;

namespace SONIP.Dominio.Contracts.Repositorios
{
    public interface IUserRepositorio : IDisposable
    {
        Task<Usuarios> GetLogin(string login);
        Task<Usuarios> Get(int ID);
        void Create(Usuarios user);
        void Update(Usuarios user);
        void Delete(Usuarios user);
    }
}
