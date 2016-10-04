using Microsoft.Practices.Unity;
using SONIP.Dominio.Contracts.Services;
using SONIP.Startup;
using System;
using System.Globalization;
using System.Threading;

namespace SONIP.UI.DOS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Referencia Linguistica actual da app
            CultureInfo ci = new CultureInfo("pt-PT");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            // Resolução de independencia iniciada
            var container = new UnityContainer();
            DependencyResolver.Resolver(container);

            Usuario(container);
        }

        public static void Usuario(UnityContainer user)
        {
            // Controlo de dependencia
            var service = user.Resolve<IUserService>();          

            try
            {
                //service.Autenticacao("RayShadai", "martina");

                //  service.GetLogin("Rayane");

                service.Registrar ("Adilson Lukeny","Binario","1234","1234");

                Console.WriteLine("Usuario cadastrado com sucesso...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                service.Dispose();
            }
        }
    }
}
