using SONIP.Dominio.Contracts.Repositorios;
using SONIP.Dominio.Models;
using SONIP.Infraestrutura.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SONIP.Infraestrutura.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private DataContext _context;
        public FuncionarioRepositorio(DataContext context)
        {
            this._context = context;
        }
        public async Task<Funcionarios> Get(int ID)
        {
            return await _context.Funcionario.Where(x => x.FuncionarioID == ID).FirstOrDefaultAsync();
        }
        public async Task<Funcionarios> GetNome(string value)
        {
            return await _context.Funcionario.Where(x => x.Nome == value).FirstOrDefaultAsync();
        }
        public async Task<Funcionarios> GetCartao(string value)
        {
            return await _context.Funcionario.Where(x => x.Cartao == value).FirstOrDefaultAsync();
        }
        public async Task<Funcionarios> GetSap(string value)
        {
            return await _context.Funcionario.Where(x => x.SAP == value).FirstOrDefaultAsync();
        }
        public async void Create(Funcionarios funcionario)
        {
            _context.Funcionario.Add(funcionario);
            await _context.SaveChangesAsync();
        }
        public async void Update(Funcionarios funcionario)
        {
            _context.Entry<Funcionarios>(funcionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async void Delete(Funcionarios funcionario)
        {
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
