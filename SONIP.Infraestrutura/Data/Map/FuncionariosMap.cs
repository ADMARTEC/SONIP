using SONIP.Dominio.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace SONIP.Infraestrutura.Data.Map
{
    public class FuncionariosMap : EntityTypeConfiguration<Funcionarios>
    {
        public FuncionariosMap()
        {
            ToTable("Funcionarios");

            this.HasKey(x => x.FuncionarioID);

            Property(x => x.FuncionarioID)
                .HasColumnOrder(1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.UsuarioID)
                .IsOptional()
                .HasColumnOrder(2);

            Property(x => x.SubsidiariaID)
                .IsRequired()
                .HasColumnOrder(3);           

            Property(x => x.Nome)
                .IsRequired()
                .HasColumnOrder(4)
                .HasMaxLength(250)
                .HasColumnType("nvarchar")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UQ_Nome",1) { IsUnique = true }));
            
            Property(x => x.SAP)
                .IsRequired()
                .HasColumnOrder(5)
                .HasMaxLength(250)
                .HasColumnType("nvarchar")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UQ_Nome",2) { IsUnique = true }))
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UQ_SAP") { IsUnique = true }));
            
            Property(x => x.Cartao)
                .IsOptional()
                .HasColumnOrder(6)
                .HasMaxLength(250)
                .HasColumnType("nvarchar")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UQ_Cartao") { IsUnique = true }));
        }
    }
}
