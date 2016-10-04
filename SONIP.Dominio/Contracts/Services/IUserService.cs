using SONIP.Dominio.Models;
using System;

namespace SONIP.Dominio.Contracts.Services
{
    public interface IUserService : IDisposable
    {
        Usuarios Autenticacao(string login, string password);
        Usuarios GetLogin(string value);
        void Registrar(string nome, string login, string password, string confirmar);
        void AlterarInfo(string nome, string login);
        void AlterarPassword(string login, string Oldpassword, string Newpassword, string ConfirmaNewpassword);
        string ResetarPassword(string login);

    }
}
