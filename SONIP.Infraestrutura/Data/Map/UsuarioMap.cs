using SONIP.Dominio.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace SONIP.Infraestrutura.Data.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuarios>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            this.HasKey(x => x.UsuarioID);

            Property(x => x.UsuarioID)                
                .HasColumnOrder(1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)                
                .HasColumnOrder(2)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UQ_Nome",1) { IsUnique = true }));

            Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnOrder(3)                
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UQ_Login") { IsUnique = true }))
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UQ_Nome",2) { IsUnique = true }));

            Property(x => x.Password)
                .HasColumnOrder(4)
                .IsRequired()               
                .HasMaxLength(250);
        }

    }
}
