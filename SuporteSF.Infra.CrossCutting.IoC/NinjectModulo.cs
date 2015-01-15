using Ninject.Modules;
using SuporteSF.Application.Interfaces;
using SuporteSF.Domain.Interfaces.Repository;
//using SuporteSF.Domain.Interfaces.Repository.ADO;
//using SuporteSF.Domain.Interfaces.Repository.ReadOnly;
using SuporteSF.Domain.Interfaces.Services;
using SuporteSF.Domain.Services;
using SuporteSF.Infra.Data.Context;
using SuporteSF.Infra.Data.Interfaces;
using SuporteSF.Infra.Data.Repositories;
//using SuporteSF.Infra.Data.Repositories.ADO;
//using SuporteSF.Infra.Data.Repositories.ReadOnly;
using SuporteSF.Infra.Data.UoW;
using SuporteSF.Application.Services;

namespace SuporteSF.Infra.CrossCutting.IoC
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            // app
            Bind<ISuporteAppService>().To<SuporteAppService>();

            // service
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<ISuporteService>().To<SuporteService>();

            // data repos
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<,>));
            Bind<ISuporteRepository>().To<SuporteRepository>();

            // data repos read only
            //Bind<IClienteReadOnlyRepository>().To<ClienteReadOnlyRepository>();
            //Bind<IFornecedorReadOnlyRepository>().To<FornecedorReadOnlyRepository>();
            //Bind<IVendaReadOnlyRepository>().To<VendaReadOnlyRepository>();
            //Bind<IProdutoReadOnlyRepository>().To<ProdutoReadOnlyRepository>();

            // ado repos only
            //Bind<IClienteADORepository>().To<ClienteADORepository>();

            // data configs
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind<IDbContext>().To<SuporteContext>();
            Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>));

        }
    }
}
