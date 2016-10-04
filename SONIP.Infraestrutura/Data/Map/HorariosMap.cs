using SONIP.Dominio.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace SONIP.Infraestrutura.Data.Map
{
    public class HorariosMap : EntityTypeConfiguration<Horarios>
    {
        public HorariosMap()
        {
            ToTable("Horarios");

            this.HasKey(x => x.HorarioID);

            Property(x => x.HorarioID)
                .HasColumnOrder(1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Designacao)
                .HasColumnOrder(2)
                .HasMaxLength(250)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UQ_Designacao") { IsUnique = true }));

            Property(x => x.Hora)
                .HasColumnOrder(3)
                .HasColumnType("Time")
                .IsRequired();

        }
    }
}
