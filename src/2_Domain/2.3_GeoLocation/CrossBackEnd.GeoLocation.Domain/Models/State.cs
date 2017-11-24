
using CrossBackEnd.GeoLocation.Domain.Collections;
using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;
using System;

namespace CrossBackEnd.GeoLocation.Domain.Models
{
    public class State : IModel
    {
        public Guid StateId { get; private set; }
        public Guid CountryId { get; private set; }
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }

        public CityCollection Cities { get; private set; }
        private Country country { get; set; }

        #region Gets and Sets

        public Country Country
        {
            get { return this.country; }
            private set
            {
                if(value != null)
                {
                    this.country = value;
                    this.CountryId = value.CountryId;
                }
            }
        }

        #endregion

        #region Constructors

        public State()
        {
            this.StateId = Guid.NewGuid();
            this.Cities = new CityCollection();
        }

        public State(Guid idState, Guid idCountry, string name, string abbreviation) : this()
        {
            this.StateId = idState;
            this.CountryId = idCountry;
            this.Name = name;
            this.Abbreviation = abbreviation;
        }

        public State(Guid idCountry, string name, string abbreviation) : this()
        {
            this.CountryId = idCountry;
            this.Name = name;
            this.Abbreviation = abbreviation;
        }

        public State(Guid idState, Country country, string name, string abbreviation) : this()
        {
            this.StateId = idState;
            this.CountryId = country.CountryId;
            this.Name = name;
            this.Country = country;
            this.Abbreviation = abbreviation;
        }

        public State(Country country, string name, string abbreviation) : this()
        {
            this.CountryId = country.CountryId;
            this.Name = name;
            this.Country = country;
            this.Abbreviation = abbreviation;
        }

        #endregion

        #region Factories

        public State CreateNew(Guid idState, Guid idCountry, string name,
            string abbreviation)
        {
            State state = new State
            {
                StateId = idState,
                CountryId = idCountry,
                Name = name,
                Abbreviation = abbreviation
            };

            return state;
        }

        public State CreateNew(Guid idCountry, string name, string abbreviation)
        {
            State state = new State
            {
                CountryId = idCountry,
                Name = name,
                Abbreviation = abbreviation
            };

            return state;
        }

        public State CreateNew(Guid idState, Country country, string name,
            string abbreviation)
        {
            State state = new State
            {
                StateId = idState,
                CountryId = country.CountryId,
                Name = name,
                Abbreviation = abbreviation,
                Country = country
            };

            return state;
        }

        public State CreateNew(Country country, string name, string abbreviation)
        {
            State state = new State
            {
                CountryId = country.CountryId,
                Name = name,
                Abbreviation = abbreviation,
                Country = country
            };

            return state;
        }


        #endregion

        public void Dispose()
        { GC.Collect(0, GCCollectionMode.Forced); }

        public ExecutionResult<bool> IsValid()
        {
            ExecutionResult<bool> isValid = new ExecutionResult<bool>();

            return isValid;
        }

        public void AssignCountry(Country country)
        { this.Country = country; }
    }
}