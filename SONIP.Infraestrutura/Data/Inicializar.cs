using System.Data.Entity;

namespace SONIP.Infraestrutura.Data
{
    public class Inicializar: DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
        }
    }
}
