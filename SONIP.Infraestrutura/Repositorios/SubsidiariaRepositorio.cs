using SONIP.Dominio.Contracts.Repositorios;
using SONIP.Dominio.Models;
using SONIP.Infraestrutura.Data;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SONIP.Infraestrutura.Repositorios
{
    public class SubsidiariaRepositorio : ISubsidiariaRepositorio
    {
        private DataContext _context;

        public SubsidiariaRepositorio(DataContext context)
        {
            this._context = context;
        }

        public Subsidiarias Get(int ID)
        {
            return _context.Subsidiaria.Where(x => x.SubsidiariaID == ID).FirstOrDefault();
        }

        public Subsidiarias GetDesignacao(string value)
        {
            return _context.Subsidiaria.Where(x => x.Designacao == value).FirstOrDefault();
        }

        public Subsidiarias GetEmail(string value)
        {
            return _context.Subsidiaria.Where(x => x.Email == value).FirstOrDefault();
        }

        public async void Create(Subsidiarias subsidiaria)
        {
            _context.Subsidiaria.Add(subsidiaria);
            await _context.SaveChangesAsync();
        }

        public async void Update(Subsidiarias subsidiaria)
        {
            _context.Entry<Subsidiarias>(subsidiaria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async void Delete(Subsidiarias subsidiaria)
        {
            _context.Subsidiaria.Remove(subsidiaria);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        Task<Subsidiarias> ISubsidiariaRepositorio.GetDesignacao(string value)
        {
            throw new NotImplementedException();
        }

        Task<Subsidiarias> ISubsidiariaRepositorio.Get(int ID)
        {
            throw new NotImplementedException();
        }

        Task<Subsidiarias> ISubsidiariaRepositorio.GetEmail(string value)
        {
            throw new NotImplementedException();
        }
    }
}
