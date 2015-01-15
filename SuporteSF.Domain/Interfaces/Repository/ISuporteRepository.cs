using SuporteSF.Domain.Entities;
using System.Collections.Generic;

namespace SuporteSF.Domain.Interfaces.Repository
{
    public interface ISuporteRepository : IRepositoryBase<Suporte>
    {
        IEnumerable<Suporte> BuscarPorDescricao(string descricao);
    }
}
