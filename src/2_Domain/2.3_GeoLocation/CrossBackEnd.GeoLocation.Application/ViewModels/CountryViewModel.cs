
using System;
using System.ComponentModel.DataAnnotations;

using CrossBackEnd.Shared.Kernel.Core.MVVM;

namespace CrossBackEnd.GeoLocation.Application.ViewModels
{
    public class CountryViewModel : BaseViewModel<CountryViewModel>
    {
        private Guid countryId;
        private string name;
        private string abbreviation;
        
        #region Gets and Sets

        [Key]
        public Guid CountryId
        {
            get { return countryId; }
            set { SetProperty(ref countryId, value); }
        }

        [Required(ErrorMessage = "O nome do país é obrigatório.")]
        [MinLength(5, ErrorMessage = "O nome do país deve ter ao menos 5 caracteres")]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        [Required(ErrorMessage = "Informar abreviatura do país é obrigatório.")]
        [MinLength(2, ErrorMessage = "A abreviatura deve ter ao menos 2 caracteres")]
        public string Abbreviation
        {
            get { return abbreviation; }
            set { SetProperty(ref abbreviation, value); }
        }

        #endregion
    }
}