using SONIP.Dominio.Models;
using System;
using System.Threading.Tasks;

namespace SONIP.Dominio.Contracts.Repositorios
{
    public interface IFuncionarioRepositorio : IDisposable
    {
        Task<Funcionarios> Get(int ID);
        Task<Funcionarios> GetNome(string value);
        Task<Funcionarios> GetSap(string value);
        Task<Funcionarios> GetCartao(string value);         
        void Create(Funcionarios funcionario);
        void Update(Funcionarios funcionario);
        void Delete(Funcionarios funcionario);
    }
}
