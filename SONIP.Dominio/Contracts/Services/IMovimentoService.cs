using SONIP.Dominio.Models;
using System;

namespace SONIP.Dominio.Contracts.Services
{
    public interface IMovimentoService : IDisposable
    {
        Movimentos Get(int value);
        Movimentos GetFuncionario(int value);
        Movimentos GetPeriodo(int funcionario, int horario, DateTime data);
        void Registrar(int funcionario, int usuario, int horario, DateTime data);
    }
}
