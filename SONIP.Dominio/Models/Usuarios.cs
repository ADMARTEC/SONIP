using SONIP.Common.Resource.Erros;
using SONIP.Common.Validacao;
using System;
using System.Collections.Generic;

namespace SONIP.Dominio.Models
{
    public class Usuarios : Pessoa
    {
        #region - Construtor -
        protected Usuarios() { }
        public Usuarios(string _Login , string _Password )
        {
            this.Login = _Login;
            this.Password = _Password;

            Funcionarios = new List<Funcionarios>();
            // Movimentos = new List<Movimentos>();
        }
        #endregion

        #region - Propriedades -
        public int UsuarioID { get; set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        #endregion

        #region - Relacionamento -       
        public virtual ICollection<Funcionarios> Funcionarios { get; set; }

        // public virtual ICollection<Movimentos> Movimentos { get; set; }
        #endregion

        #region - Metodos -
        public void SetPassword(string Password, string Confirmar)
        {
            AssertionConcern.AssertArgumentNotNull(Password, Base.TagSenhaNull);
            AssertionConcern.AssertArgumentNotNull(Confirmar, Base.TagSenhaNull);
            AssertionConcern.AssertArgumentEquals(Password, Confirmar, Base.TagSenhaDiferentes);
            AssertionConcern.AssertArgumentLength(Password, 4, 20, Base.TagSenhaTamanho);

            this.Password = PasswordAssertionConcern.Encrypt(Password);
        }
        public string ResetPassword()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            this.Password = PasswordAssertionConcern.Encrypt(password);

            return password;
        }
        public void ChangeName(string nome)
        {
            this.Nome = nome;
        }
        public void Validar()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, Base.TagNomeNull);
            AssertionConcern.AssertArgumentLength(this.Nome, 6, 250, Base.TagNomeTamanho);
            AssertionConcern.AssertArgumentNotEmpty(this.Login, Base.TagLoginNull);
            AssertionConcern.AssertArgumentNotNull(this.Login, Base.TagLoginNull);
            AssertionConcern.AssertArgumentLength(this.Login, 4, 20, Base.TagLoginTamanho);
            PasswordAssertionConcern.AssertIsValid(this.Password);
        }
        #endregion
    }
}
