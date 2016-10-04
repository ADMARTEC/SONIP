using SONIP.Common.Resource.Erros;
using SONIP.Common.Validacao;
using System;
using System.Collections.Generic;

namespace SONIP.Dominio.Models
{
    public class Subsidiarias
    {
        #region - Contrutor -
        public Subsidiarias()
        {
            Funcionarios = new List<Funcionarios>();
        }
        #endregion

        #region - Propriedades -
        public int SubsidiariaID { get; set; }
        public string Designacao { get; private set; }
        public string Email { get; private set; }
        public string Logotipo { get; set; }
        #endregion

        #region - Relacionamento -
        public virtual ICollection<Funcionarios> Funcionarios { get; set; }
        #endregion

        #region - Metodos -
        public void SetSubsidiaria(string _Designacao, string email, string logotipo)
        {
            AssertionConcern.AssertArgumentNotNull(_Designacao, Base.TagDesignacaoNull);
            AssertionConcern.AssertArgumentNotEmpty(_Designacao, Base.TagDesignacaoNull);
            AssertionConcern.AssertArgumentLength(_Designacao, 250, Base.TagDesignacaoTamanho);

            this.Designacao = _Designacao;

            this.SetEmail(email);

            this.Logotipo = logotipo;
        }

        public void SetEmail(string _email)
        {
            AssertionConcern.AssertArgumentNotNull(_email, Base.TagEmailNull);
            AssertionConcern.AssertArgumentNotEmpty(_email, Base.TagEmailNull);
            AssertionConcern.AssertArgumentTrue(EmailAssertionConcern.IsValidEmail(_email), Base.TagEmailInvalido);
            AssertionConcern.AssertArgumentLength(_email, 250, Base.TagEmailTamanho);

            this.Email = _email;
        }

        #endregion
    }
}
