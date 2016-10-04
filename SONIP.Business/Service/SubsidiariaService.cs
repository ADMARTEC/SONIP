using SONIP.Dominio.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SONIP.Dominio.Models;
using SONIP.Dominio.Contracts.Repositorios;

namespace SONIP.Business.Service
{
    public class SubsidiariaService : ISubsidiariaService
    {
        private ISubsidiariaRepositorio _repository;

        public SubsidiariaService(ISubsidiariaRepositorio repositorio)
        {
            this._repository = repositorio;
        }


        public Subsidiarias Get(int value)
        {
            return _repository.Get(value).Result;
        }

        public Subsidiarias GetDesignacao(string value)
        {
            return _repository.GetDesignacao(value).Result;
        }

        public Subsidiarias GetEmail(string value)
        {
            throw new NotImplementedException();
        }

        public void Registrar(string designacao, string email = null, string logotipo = null)
        {
            throw new NotImplementedException();
        }
        public void Actualizar(int id, string designacao, string email = null, string logotipo = null)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
