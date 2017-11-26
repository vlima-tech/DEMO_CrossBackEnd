
using AutoMapper;

using CrossBackEnd.GeoLocation.Application.Interfaces;
using CrossBackEnd.GeoLocation.Application.ViewModels;
using CrossBackEnd.GeoLocation.Domain.Interfaces.Services;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.Shared.Kernel.Core.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Collections;

namespace CrossBackEnd.GeoLocation.Application.AppServices
{
    public class CountryAppService : BaseAppService<CountryViewModel, Country>, ICountryAppService
    {
        private readonly ICountryService _countryService;

        public CountryAppService(ICountryService countryService, IMapper mapper) : base(countryService, mapper)
        {
            this._countryService = countryService;
        }

        internal override CountryViewModel ConvertModelToViewModel(Country model)
        {
            return new CountryViewModel
            {
                CountryId = model.CountryId,
                Name = model.Name,
                Abbreviation = model.Abbreviation
            };
        }

        internal override IBaseCollection<CountryViewModel> ConvertModelToViewModel(IBaseCollection<Country> model)
        {
            var viewModels = new BaseCollection<CountryViewModel>();

            model.ForEach(x => viewModels.Add(ConvertModelToViewModel(x)));

            return viewModels;
        }

        internal override Country ConvertViewModelToModel(CountryViewModel viewModel)
        {
            return Country.CreateNew(viewModel.CountryId, viewModel.Name, viewModel.Abbreviation);
        }

        internal override IBaseCollection<Country> ConvertViewModelToModel(IBaseCollection<CountryViewModel> viewModel)
        {
            var models = new BaseCollection<Country>();

            viewModel.ForEach(x => models.Add(ConvertViewModelToModel(x)));

            return models;
        }
    }
}