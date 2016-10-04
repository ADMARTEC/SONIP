using SONIP.Dominio.Models;
using SONIP.Infraestrutura.Data.Map;
using System.Data.Entity;

namespace SONIP.Infraestrutura.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("ConexaoStrinng")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            // Database.SetInitializer(new Inicializar());
        }

        #region - Tabelas -

        public DbSet<Usuarios> Usuario { get; set; }

        public DbSet<Funcionarios> Funcionario { get; set; }

        public DbSet<Subsidiarias> Subsidiaria { get; set; }

        public DbSet<Movimentos> Movimento { get; set; }

        public DbSet<Horarios> Horario { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region - Mapeamento -

            modelBuilder.Configurations.Add(new HorariosMap());
            modelBuilder.Configurations.Add(new SubsidiariasMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new FuncionariosMap());
            modelBuilder.Configurations.Add(new MovimentoMap());

            #endregion

            #region - Relacionamento -  

            //modelBuilder.Entity<Usuarios>()
            //    .HasRequired<Funcionarios>(s => s.Funcionarios)
            //    .WithMany(s => s.Usuario)
            //    .HasForeignKey(s => s.UsuarioID);

            //modelBuilder.Entity<Usuarios>()
            //   .HasRequired<Movimentos>(s => s.Movimentos)
            //   .WithMany(s => s.Usuario)
            //   .HasForeignKey(s => s.UsuarioID);

            //modelBuilder.Entity<Subsidiarias>()
            //  .HasRequired<Funcionarios>(s => s.Funcionarios)
            //  .WithMany(s => s.Subsidiaria)
            //  .HasForeignKey(s => s.SubsidiariaID);

            //modelBuilder.Entity<Funcionarios>()
            // .HasRequired<Movimentos>(s => s.Movimentos)
            // .WithMany(s => s.Funcionario)
            // .HasForeignKey(s => s.FuncionarioID);

            #endregion

            // base.OnModelCreating(modelBuilder);
        }
    }
}
