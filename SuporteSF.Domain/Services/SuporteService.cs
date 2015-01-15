using System;
using System.Collections.Generic;
using System.Linq;
using SuporteSF.Domain.Entities;
using SuporteSF.Domain.Interfaces.Repository;
//using SuporteSF.Domain.Interfaces.Repository.ADO;
//using SuporteSF.Domain.Interfaces.Repository.ReadOnly;
using SuporteSF.Domain.Interfaces.Services;
using SuporteSF.Domain.ValueObjects;

namespace SuporteSF.Domain.Services
{
    public class SuporteService : ServiceBase<Suporte>, ISuporteService
    {
        private readonly ISuporteRepository _modelRepository;
        //private readonly IEstudanteReadOnlyRepository _estudanteReadOnlyRepository;
        //private readonly IEstudanteADORepository _estudanteAdoRepository;

        //public EstudanteService(
        //    IEstudanteRepository estudanteRepository, 
        //    IClienteReadOnlyRepository clienteReadOnlyRepository, 
        //    IClienteADORepository clienteAdoRepository)
        //    : base(clienteRepository)
        //{
        //    _estudanteRepository = estudanteRepository;
        //    _estudanteReadOnlyRepository = clienteReadOnlyRepository;
        //    _estudanteAdoRepository = clienteAdoRepository;
        //}

        public SuporteService(
            ISuporteRepository modelRepository)
            : base(modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public override Suporte GetById(Guid id)
        {
            return _modelRepository.GetById(id);
        }

        public override IEnumerable<Suporte> GetAll()
        {
            return _modelRepository.GetAll();
        }

        public IEnumerable<Suporte> BuscarPorDescricao(string descricao)
        {
            return _modelRepository.BuscarPorDescricao(descricao);
        }

        public ValidationResult AdicionarSuporte(Suporte model)
        {
            var resultadoValidacao = new ValidationResult();

            if (!model.IsValid())
            {
                resultadoValidacao.AdicionarErro(model.ResultadoValidacao);
                return resultadoValidacao;
            }

            base.Add(model);

            return resultadoValidacao;
        }
    }
}
