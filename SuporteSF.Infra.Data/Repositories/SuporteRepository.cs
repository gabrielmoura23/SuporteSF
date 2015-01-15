using SuporteSF.Domain.Entities;
using SuporteSF.Domain.Interfaces.Repository;
using SuporteSF.Infra.Data.Context;
using System.Collections.Generic;

namespace SuporteSF.Infra.Data.Repositories
{
    public class SuporteRepository : RepositoryBase<Suporte, SuporteContext>, ISuporteRepository
    {
        public IEnumerable<Suporte> BuscarPorDescricao(string descricao)
        {
            return base.Find(c => c.Descricao == descricao);
        }
    }
}
