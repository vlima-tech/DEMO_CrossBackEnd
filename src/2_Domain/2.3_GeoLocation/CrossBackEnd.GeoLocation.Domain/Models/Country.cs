
using System;

using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.GeoLocation.Domain.Collections;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.GeoLocation.Domain.Models
{
    public class Country : IModel
    {
        public Guid CountryId { get; private set; }
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }

        public StateCollection States { get; private set; }

        #region Constructors

        public Country()
        {
            this.CountryId = Guid.NewGuid();

            this.States = new StateCollection();
        }

        public Country(Guid idCoutry, string name, string abbreviation)
        {
            this.CountryId = idCoutry;
            this.Name = name;
            this.Abbreviation = abbreviation;

            this.States = new StateCollection();
        }

        public Country(string name, string abbreviation) : this()
        {
            this.Name = name;
            this.Abbreviation = abbreviation;
        }

        #endregion

        #region Factories

        public Country CreateNew(Guid idCoutry, string name)
        {
            Country country = new Country
            {
                CountryId = idCoutry,
                Name = name
            };

            return country;
        }

        public Country CreateNew(string name)
        {
            Country country = new Country
            {
                Name = name
            };

            return country;
        }

        #endregion

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }

        public ExecutionResult<bool> IsValid()
        {
            ExecutionResult<bool> isValid = new ExecutionResult<bool>();

            return isValid;
        }
    }
}