using SONIP.Common.Resource.Erros;
using SONIP.Dominio.Contracts.Repositorios;
using SONIP.Dominio.Contracts.Services;
using SONIP.Dominio.Models;
using System;

namespace SONIP.Business.Service
{
    public class HorarioService : IHorarioService
    {
        private IHorarioRepositorio _repository;

        public HorarioService(IHorarioRepositorio repositorio)
        {
            this._repository = repositorio;
        }

        public Horarios Get(int value)
        {
            return _repository.Get(value).Result;
        }

        public Horarios GetByDesignacao(string designacao)
        {
            return _repository.GetDesignacao(designacao).Result;
        }

        public void Registrar(string designacao, TimeSpan hora)
        {
            var horario = GetByDesignacao(designacao);
            if (horario == null)
                throw new Exception(Base.TagPeriodoDuplicado);

            var Horario = new Horarios();

            Horario.SetHorario(designacao, hora);

            Horario.Validar();

            _repository.Create(Horario);

        }

        public void AlterarInfo(string desginacao, TimeSpan hora)
        {
            var horario = GetByDesignacao(desginacao);

            horario.SetHorario(desginacao, hora);

            horario.Validar();

            _repository.Update(horario);

        }

        public void Dispose()
        {
            this._repository.Dispose();
            GC.Collect();
        }

    }
}
