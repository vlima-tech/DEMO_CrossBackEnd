
using System;
using System.ComponentModel.DataAnnotations;

using CrossBackEnd.Shared.Kernel.Core.MVVM;

namespace CrossBackEnd.GeoLocation.Application.ViewModels
{
    public class CountryViewModel : BaseViewModel<CountryViewModel>
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        /*
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
            set { name = value; }
        }

        [Required(ErrorMessage = "Informar abreviatura do país é obrigatório.")]
        [MinLength(2, ErrorMessage = "A abreviatura deve ter ao menos 2 caracteres")]
        public string Abbreviation
        {
            get { return abbreviation; }
            set { abbreviation = value; }
        }

        #endregion
        */
    }
}