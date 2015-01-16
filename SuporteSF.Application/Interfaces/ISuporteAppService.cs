using System;
using System.Collections.Generic;
using SuporteSF.Application.Validation;
using SuporteSF.Application.ViewModels;

namespace SuporteSF.Application.Interfaces
{
    public interface ISuporteAppService : IDisposable
    {
        ValidationAppResult Add(SuporteViewModel modelViewModel);
        SuporteViewModel GetById(Guid id);
        SuporteViewModel GetByIdTipoInteiro(int id);
        IEnumerable<SuporteViewModel> GetAll();
        void Update(SuporteViewModel modelViewModel);
        void Remove(SuporteViewModel modelViewModel);
        IEnumerable<SuporteViewModel> BuscarPorDescricao(string descricao);
        ValidationAppResult CancelarSuporte(SuporteViewModel modelViewModel, Guid IdUsuarioAlteracao);
    }
}
