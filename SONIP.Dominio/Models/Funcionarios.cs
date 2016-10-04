using SONIP.Common.Resource.Erros;
using SONIP.Common.Validacao;
using System.Collections.Generic;

namespace SONIP.Dominio.Models
{
    public class Funcionarios : Pessoa
    {    

        #region - Contrutor -
        public Funcionarios()
        {
            Movimentos = new List<Movimentos>();
        }
        #endregion

        #region - Propriedade -              

        public int FuncionarioID { get; set; }
        public int UsuarioID { get; set; }
        public int SubsidiariaID { get; set; }
        public string SAP { get; private set; }
        public string Cartao { get; private set; }

        #endregion

        #region - Relacionamento
        public virtual Subsidiarias Subsidiaria { get; set; }
        public virtual Usuarios Usuario { get; set; }
        public virtual ICollection<Movimentos> Movimentos { get; set; }
        #endregion

        #region - Metodos -
        /// <summary>
        /// Atribuição dos dados dos funcionarios
        /// </summary>
        /// <param name="_Nome"></param>
        /// <param name="_Sap"></param>
        /// <param name="_Cartao"></param>
        public void SetFuncionarios(string _Nome, string _Sap, string _Cartao)
        {
            this.Nome = _Nome;
            this.SAP = _Sap;
            this.Cartao = _Cartao;
        }

        public void Validar()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, Base.TagNomeNull);
            AssertionConcern.AssertArgumentNotEmpty(this.Nome, Base.TagNomeNull);
            AssertionConcern.AssertArgumentLength(this.Nome, 250, Base.TagNomeTamanho);


            AssertionConcern.AssertArgumentNotNull(this.SAP, Base.TagSapNull);
            AssertionConcern.AssertArgumentNotEmpty(this.SAP, Base.TagSapNull);
            AssertionConcern.AssertArgumentLength(this.SAP, 250, Base.TagSapTamanho);


            AssertionConcern.AssertArgumentNotNull(this.Cartao, Base.TagCartaoNull);
            AssertionConcern.AssertArgumentNotEmpty(this.Cartao, Base.TagCartaoNull);
            AssertionConcern.AssertArgumentLength(this.Cartao, 250, Base.TagCartaoTamanho);

        }

        #endregion
    }
}


