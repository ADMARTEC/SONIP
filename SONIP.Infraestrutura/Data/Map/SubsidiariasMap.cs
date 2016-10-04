using SONIP.Dominio.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace SONIP.Infraestrutura.Data.Map
{
    public class SubsidiariasMap: EntityTypeConfiguration<Subsidiarias>
    {
        public SubsidiariasMap()
        {
            ToTable("Subsidiarias");

            this.HasKey(x => x.SubsidiariaID);

            Property(x => x.SubsidiariaID)
                .HasColumnOrder(1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Designacao)
                .HasColumnOrder(2)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UQ_Designacao") { IsUnique = true }));

            Property(x => x.Email)
                .HasColumnOrder(3)
                .IsOptional()
                .HasMaxLength(250);

            Property(x => x.Logotipo)
              .HasColumnOrder(4)
              .IsOptional()
              .HasColumnType("nvarchar(max)");
        }
    }
}
