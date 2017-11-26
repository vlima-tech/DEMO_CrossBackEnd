
using AutoMapper;

using CrossBackEnd.GeoLocation.Application.ViewModels;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.MVVM;

namespace CrossBackEnd.GeoLocation.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CountryViewModel, Country>();
        }
    }

    /*
    public class ViewModelToDomainMappingProfile<TViewModel, TModel> : Profile
        where TViewModel : IBaseViewModel
        where TModel : IModel
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TViewModel, TModel>();
        }
    }
    */
}