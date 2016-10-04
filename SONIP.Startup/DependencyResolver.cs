using Microsoft.Practices.Unity;
using SONIP.Business.Service;
using SONIP.Dominio.Contracts.Repositorios;
using SONIP.Dominio.Contracts.Services;
using SONIP.Dominio.Models;
using SONIP.Infraestrutura.Data;
using SONIP.Infraestrutura.Repositorios;

namespace SONIP.Startup
{
    public class DependencyResolver
    {
        public static void Resolver(UnityContainer container)
        {
            container.RegisterType<DataContext, DataContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserRepositorio, UsuarioRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IFuncionarioRepositorio, FuncionarioRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IHorarioRepositorio, HorarioRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IMovimentoRepositorio, MovimentoRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<ISubsidiariaRepositorio, SubsidiariaRepositorio>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFuncionarioService, FuncionarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<IHorarioService, HorarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<IMovimentoService, MovimentoService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISubsidiariaService, SubsidiariaService>(new HierarchicalLifetimeManager());

            container.RegisterType<Usuarios, Usuarios>(new HierarchicalLifetimeManager());
            container.RegisterType<Funcionarios, Funcionarios>(new HierarchicalLifetimeManager());
            container.RegisterType<Horarios, Horarios>(new HierarchicalLifetimeManager());
            container.RegisterType<Movimentos, Movimentos>(new HierarchicalLifetimeManager());
            container.RegisterType<Subsidiarias, Subsidiarias>(new HierarchicalLifetimeManager());            
        }
    }
}
