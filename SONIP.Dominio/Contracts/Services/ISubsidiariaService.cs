using SONIP.Dominio.Models;
using System;

namespace SONIP.Dominio.Contracts.Services
{
    public interface ISubsidiariaService : IDisposable
    {
        Subsidiarias Get(int value);
        Subsidiarias GetDesignacao(string value);
        Subsidiarias GetEmail(string value);
        void Registrar(string designacao, string email = null, string logotipo = null);
        void Actualizar(int id, string designacao, string email = null, string logotipo = null);
    }
}
