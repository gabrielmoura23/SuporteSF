using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SuporteSF.Application.Interfaces;
using SuporteSF.Application.Validation;
using SuporteSF.Application.ViewModels;
using SuporteSF.Domain.Entities;
using SuporteSF.Domain.Interfaces.Services;
using SuporteSF.Infra.Data.Context;

namespace SuporteSF.Application.Services
{
    public class SuporteAppService : AppServiceBase<SuporteContext>, ISuporteAppService
    {
        private readonly ISuporteService _modelService;

        public SuporteAppService(ISuporteService modelService)
        {
            _modelService = modelService;
        }

        public ValidationAppResult Add(SuporteViewModel modelViewModel)
        {
            var model = Mapper.Map<SuporteViewModel, Suporte>(modelViewModel);

            BeginTransaction();

            var result = _modelService.AdicionarSuporte(model);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public SuporteViewModel GetById(Guid id)
        {
            return Mapper.Map<Suporte, SuporteViewModel>(_modelService.GetById(id));
        }

        public SuporteViewModel GetByIdTipoInteiro(int id)
        {
            return Mapper.Map<Suporte, SuporteViewModel>(_modelService.GetByIdTipoInteiro(id));
        }

        public IEnumerable<SuporteViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Suporte>, IEnumerable<SuporteViewModel>>(_modelService.GetAll());
        }

        public IEnumerable<SuporteViewModel> BuscarPorDescricao(string descricao)
        {
            return Mapper.Map<IEnumerable<Suporte>, IEnumerable<SuporteViewModel>>(_modelService.BuscarPorDescricao(descricao));
        }

        public void Update(SuporteViewModel modelViewModel)
        {
            var model = Mapper.Map<SuporteViewModel, Suporte>(modelViewModel);

            BeginTransaction();
            _modelService.Update(model);
            Commit();
        }

        public void Remove(SuporteViewModel modelViewModel)
        {
            var model = Mapper.Map<SuporteViewModel, Suporte>(modelViewModel);

            BeginTransaction();
            _modelService.Remove(model);
            Commit();
        }

        public void Dispose()
        {
            _modelService.Dispose();
        }
    }
}
