using SONIP.Dominio.Contracts.Repositorios;
using SONIP.Dominio.Models;
using SONIP.Infraestrutura.Data;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SONIP.Infraestrutura.Repositorios
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        private DataContext _context;

        public MovimentoRepositorio(DataContext context)
        {
            this._context = context;
        }

        public async Task<Movimentos> Get(int ID)
        {
            return await _context.Movimento.Where(x => x.MovimentoID == ID).FirstOrDefaultAsync();
        }

        public async Task<Movimentos> GetPeriodoMovim(int funcionario, int horario, DateTime data)
        {
            return await _context.Movimento.Where(x => x.FuncionarioID == funcionario && x.HorarioID == horario && x.DataRegisto.Date == data.Date).FirstOrDefaultAsync();
        }

        public async Task<Movimentos> GetFuncionario(int funcionarioID)
        {
            return await _context.Movimento.Where(x => x.FuncionarioID == funcionarioID).FirstOrDefaultAsync();
        }

        public async void Create(Movimentos movimento)
        {
            _context.Movimento.Add(movimento);
            await _context.SaveChangesAsync();
        }

        public async void Update(Movimentos movimento)
        {
            _context.Entry<Movimentos>(movimento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async void Delete(Movimentos movimento)
        {
            _context.Movimento.Remove(movimento);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
