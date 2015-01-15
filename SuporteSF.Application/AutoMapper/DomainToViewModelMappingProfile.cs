using AutoMapper;
using SuporteSF.Application.ViewModels;
using SuporteSF.Domain.Entities;

namespace SuporteSF.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Suporte, SuporteViewModel>();
        }
    }
}