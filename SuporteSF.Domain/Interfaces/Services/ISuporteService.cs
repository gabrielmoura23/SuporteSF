using System.Collections.Generic;
using SuporteSF.Domain.Entities;
using SuporteSF.Domain.ValueObjects;
using System;

namespace SuporteSF.Domain.Interfaces.Services
{
    public interface ISuporteService : IServiceBase<Suporte>
    {
        ValidationResult AdicionarSuporte(Suporte model);
        IEnumerable<Suporte> BuscarPorDescricao(string descricao);
        ValidationResult CancelarSuporte(Suporte model, Guid IdUsuarioAlteracao);
    }
}
