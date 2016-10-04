using SONIP.Common.Resource.Erros;
using SONIP.Common.Resource.Funcoes;
using SONIP.Common.Validacao;
using SONIP.Dominio.Contracts.Repositorios;
using SONIP.Dominio.Contracts.Services;
using SONIP.Dominio.Models;
using System;

namespace SONIP.Business.Service
{
    public class UserService : IUserService
    {
        private IUserRepositorio _repository;

        public UserService(IUserRepositorio repositorio)
        {
            this._repository = repositorio;
        }

        public Usuarios Autenticacao(string login, string password)
        {
            var usuario = GetLogin(login);

            if (usuario.Password != PasswordAssertionConcern.Encrypt(password))
            {
                throw new Exception(Base.TagCredencialInvalida);
            }

            return usuario;
        }

        public Usuarios GetLogin(string value)
        {
            var usuario = _repository.GetLogin(value).Result;

            if (usuario == null)

                throw new Exception(Base.TagUsuarioNotFound);

            return usuario;

        }

        public void Registrar(string nome, string login, string password, string confirmar)
        {
            var usuario = _repository.GetLogin(login).Result;

            if (usuario != null)
                throw new Exception(Base.TagLoginDuplicado);

            var Usuario = new Usuarios(login, password);

            Usuario.SetPassword(password, confirmar);

            Usuario.Nome = nome;

            Usuario.Validar();

            _repository.Create(Usuario);
        }

        public void AlterarInfo(string nome, string login)
        {
            var usuario = GetLogin(login);

            usuario.ChangeName(nome);

            usuario.Validar();

            _repository.Update(usuario);
        }

        public void AlterarPassword(string login, string Oldpassword, string Newpassword, string ConfirmaNewpassword)
        {
            var usuario = Autenticacao(login, Oldpassword);
            usuario.SetPassword(Newpassword, ConfirmaNewpassword);

            usuario.Validar();

            _repository.Update(usuario);
        }

        public string ResetarPassword(string login)
        {
            var usuario = GetLogin(login);
            var password = usuario.ResetPassword();
            usuario.Validar();

            return password;

        }


        public void Dispose()
        {
            _repository.Dispose();
            GC.Collect();
        }
    }
}
