using SONIP.Dominio.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SONIP.Dominio.Models;
using SONIP.Dominio.Contracts.Repositorios;
using SONIP.Common.Resource.Erros;
using SONIP.Common.Resource.Funcoes;

namespace SONIP.Business.Service
{
    public class FuncionarioService : IFuncionarioService
    {
        private IFuncionarioRepositorio _repository;

        public FuncionarioService(IFuncionarioRepositorio repositorio)
        {
            this._repository = repositorio;
        }

        public Funcionarios Get(int id)
        {
            var funcionario = _repository.Get(id).Result;
            if (funcionario == null)
                throw new Exception(Base.TagIdInvalid);

            return funcionario;
        }

        public Funcionarios GetNome(string nome)
        {
            var funcionario = _repository.GetNome(nome).Result;
            if (funcionario == null)
                throw new Exception(Base.TagNomeInvalid);

            return funcionario;
        }

        public Funcionarios GetCartao(string value)
        {
            var funcionario = _repository.GetCartao(value).Result;
            if (funcionario == null)
                throw new Exception(Base.TagCartaoInvalid);

            return funcionario;
        }

        public Funcionarios GetSap(string value)
        {
            var funcionario = _repository.GetSap(value).Result;
            if (funcionario == null)
                throw new Exception(Base.TagSapInvalid);

            return funcionario;
        }

        public void Registar(string nome, int usuario, int subsidiaria, string sap, string cartao, int periodo)
        {
            var funcionario = GetCartao(cartao);

            if (funcionario != null)
                throw new Exception(Base.TagCartaoDuplicado);

            funcionario = GetSap(sap);
            if (funcionario != null)
                throw new Exception(Base.TagSapDuplicado);

            var Funcionario = new Funcionarios();
            
            Funcionario.SetFuncionarios(nome, sap, cartao);

            Funcionario.FuncionarioID = usuario;
            Funcionario.SubsidiariaID = subsidiaria;

            Funcionario.Validar();

            _repository.Create(Funcionario);

        }

        public void AlterarInfo(string nome, string sap, string cartao)
        {
            var funcionario = GetNome(nome);

            funcionario.SetFuncionarios(nome, sap, cartao);

            funcionario.Validar();

            _repository.Update(funcionario);
        }

        public void AlterarPeriodo(int id, int periodo)
        {
            var funcionario = Get(id);

       

            funcionario.Validar();

            _repository.Update(funcionario);
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }
    }
}
