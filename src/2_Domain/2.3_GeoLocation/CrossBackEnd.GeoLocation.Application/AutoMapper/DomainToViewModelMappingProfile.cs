
using AutoMapper;
using CrossBackEnd.GeoLocation.Application.ViewModels;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.MVVM;

namespace CrossBackEnd.GeoLocation.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Country, CountryViewModel>();
        }
    }

    /*
    public class DomainToViewModelMappingProfile<TModel, TViewModel> : Profile
        where TModel : IModel
        where TViewModel : IBaseViewModel
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<TModel, TViewModel>();
        }
    }
    */
}