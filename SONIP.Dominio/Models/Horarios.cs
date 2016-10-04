using SONIP.Common.Resource.Erros;
using SONIP.Common.Validacao;
using System;
using System.Collections.Generic;

namespace SONIP.Dominio.Models
{
    public class Horarios
    {
        #region - Contrutor -       
        public Horarios()
        {
            Movimentos = new List<Movimentos>();
        }
        #endregion

        #region - Propriedades -      
        public int HorarioID { get; set; }
        public string Designacao { get; set; }
        public TimeSpan Hora { get; set; }
        #endregion

        #region - Relacionamento -
        public virtual ICollection<Movimentos> Movimentos { get; set; }
        #endregion

        #region - Metodos -   
        public void SetHorario(string designacao, TimeSpan hora)
        {
            this.Designacao = designacao;
            this.Hora = hora;
        }
        public void Validar()
        {
            AssertionConcern.AssertArgumentNotNull(this.Designacao, Base.TagDesignacaoNull);
            AssertionConcern.AssertArgumentLength(this.Designacao, 5, 250, Base.TagDesignacaoTamanho);
            AssertionConcern.AssertArgumentNotEmpty(this.Designacao, Base.TagDesignacaoNull);
        }
        #endregion
    }
}
