using SONIP.Dominio.Contracts.Repositorios;
using SONIP.Dominio.Models;
using SONIP.Infraestrutura.Data;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SONIP.Infraestrutura.Repositorios
{
    public class UsuarioRepositorio : IUserRepositorio
    {
        private DataContext _context;

        public UsuarioRepositorio(DataContext context)
        {
            this._context = context;
        }

        public Task<Usuarios> Get(int ID)
        {
            return _context.Usuario.Where(x => x.UsuarioID == ID).FirstOrDefaultAsync();
        }

        public Task<Usuarios> GetLogin(string login)
        {
            return _context.Usuario.Where(x => x.Login == login).FirstOrDefaultAsync();
        }

        public async void Update(Usuarios user)
        {
            _context.Entry<Usuarios>(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async void Create(Usuarios user)
        {
            _context.Usuario.Add(user);
            await _context.SaveChangesAsync();
        }

        public async void Delete(Usuarios user)
        {
            _context.Usuario.Remove(user);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.Collect();
        }


    }
}
