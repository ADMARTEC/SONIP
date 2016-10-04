using SONIP.Dominio.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace SONIP.Infraestrutura.Data.Map
{
    public class MovimentoMap : EntityTypeConfiguration<Movimentos>
    {
        public MovimentoMap()
        {
            ToTable("Movimentos");

            this.HasKey(x => x.MovimentoID);

            Property(x => x.MovimentoID)
                .HasColumnOrder(1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.FuncionarioID)
                .HasColumnOrder(2)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UQ_MovmHora", 1) { IsUnique = true }));


            Property(x => x.UsuarioID)
                .HasColumnOrder(3);

            Property(x => x.HorarioID)
               .IsRequired()
               .HasColumnOrder(4)
               .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UQ_MovmHora", 2) { IsUnique = true }));


            Property(x => x.DataRegisto)
                .HasColumnOrder(5)
                .HasColumnType("Datetime");
        }
    }
}
