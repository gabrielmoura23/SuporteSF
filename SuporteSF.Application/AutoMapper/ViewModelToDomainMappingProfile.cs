using AutoMapper;
using SuporteSF.Application.ViewModels;
using SuporteSF.Domain.Entities;

namespace SuporteSF.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<SuporteViewModel, Suporte>();
        }
    }
}