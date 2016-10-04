using SONIP.Dominio.Models;
using System;

namespace SONIP.Dominio.Contracts.Services
{
    public interface IFuncionarioService : IDisposable
    {
        Funcionarios Get(int id);
        Funcionarios GetNome(string nome);
        Funcionarios GetSap(string value);
        Funcionarios GetCartao(string value);
        void Registar(string nome, int usuario, int subsidiaria, string sap, string cartao, int periodo);
        void AlterarInfo(string nome, string sap, string cartao);
        void AlterarPeriodo(int id,int periodo);
    }
}
