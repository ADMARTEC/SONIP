using SONIP.Dominio.Contracts.Repositorios;
using SONIP.Dominio.Models;
using SONIP.Infraestrutura.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SONIP.Infraestrutura.Repositorios
{
    public class HorarioRepositorio : IHorarioRepositorio
    {
        private DataContext _context;
        public HorarioRepositorio(DataContext contexto)
        {
            this._context = contexto;
        }

        public async Task<Horarios> Get(int ID)
        {
            return await _context.Horario.Where(x => x.HorarioID == ID).FirstOrDefaultAsync();
        }

        public async Task<Horarios> GetDesignacao(string value)
        {
            return await _context.Horario.Where(x => x.Designacao == value).FirstOrDefaultAsync();
        }

        public async void Create(Horarios horario)
        {
            _context.Horario.Add(horario);
            await _context.SaveChangesAsync();
        }

        public async void Update(Horarios horario)
        {
            _context.Entry<Horarios>(horario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async void Delete(Horarios horario)
        {
            _context.Horario.Remove(horario);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
