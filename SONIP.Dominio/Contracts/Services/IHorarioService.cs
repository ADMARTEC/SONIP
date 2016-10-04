using SONIP.Dominio.Models;
using System;

namespace SONIP.Dominio.Contracts.Services
{
    public interface IHorarioService : IDisposable
    {
        Horarios Get(int value);
        Horarios GetByDesignacao(string designacao);        
        void Registrar(string designacao, TimeSpan hora);
        void AlterarInfo(string desginacao, TimeSpan hora);
    }
}
