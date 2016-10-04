using SONIP.Common.Resource.Erros;
using SONIP.Dominio.Contracts.Repositorios;
using SONIP.Dominio.Contracts.Services;
using SONIP.Dominio.Models;
using System;

namespace SONIP.Business.Service
{
    public class MovimentoService : IMovimentoService
    {
        private IMovimentoRepositorio _repository;

        public MovimentoService(IMovimentoRepositorio repositorio)
        {
            this._repository = repositorio;
        }

        public Movimentos Get(int value)
        {
            var movimento = _repository.Get(value).Result;

            if (movimento == null)

                throw new Exception(Base.TagMovimentoInvalid);

            return movimento;
        }

        public Movimentos GetFuncionario(int value)
        {
            var movimento = _repository.GetFuncionario(value).Result;

            if (movimento == null)

                throw new Exception(Base.TagFuncionarioInvalid);

            return movimento;

        }

        public Movimentos GetPeriodo(int funcionario, int usuario, DateTime data)
        {
            return _repository.GetPeriodoMovim(funcionario, usuario, data).Result;
        }

        public void Registrar(int funcionario, int usuario, int horario, DateTime data)
        {
            var movimento = GetPeriodo(funcionario, horario, data.Date);

            if (movimento != null)
                throw new Exception(Base.TagMovimentoDuplicado);

            var Movimento = new Movimentos();

            Movimento.SetMovimento(funcionario, usuario, horario, data);

            Movimento.Validar();

            _repository.Create(Movimento);
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.Collect();
        }

    }
}
