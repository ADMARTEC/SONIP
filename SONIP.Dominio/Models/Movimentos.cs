using System;

namespace SONIP.Dominio.Models
{
    public class Movimentos
    {
        #region - Construtor -
        public Movimentos(){}
        #endregion

        #region - Propriedade -
        public int MovimentoID { get; set; }
        public int FuncionarioID { get; set; }
        public int HorarioID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime DataRegisto { get; set; }
        #endregion

        #region - Relacionamento -        
        public virtual Funcionarios Funcionario { get; set; }
        public virtual Horarios Horario { get; set; }
        // public virtual Usuarios Usuario { get; set; }
        #endregion

        public void SetMovimento(int funcionario, int usuario, int horario, DateTime data)
        {
            this.FuncionarioID = funcionario;
            this.UsuarioID = usuario;
            this.HorarioID = horario;
            this.DataRegisto = data;
        }

        public void Validar()
        {

        }
    }
}
