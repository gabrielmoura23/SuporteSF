using SuporteSF.Infra.Data.Interfaces;

namespace SuporteSF.Application.Interfaces
{
    public interface IAppServiceBase<TContext> where TContext : IDbContext
    {
        void BeginTransaction();
        void Commit();
    }
}