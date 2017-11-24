
using System;

using CrossBackEnd.Shared.Kernel.Core.Interfaces.Domain;
using CrossBackEnd.Shared.Kernel.Core.ValueObjects;

namespace CrossBackEnd.GeoLocation.Domain.Models
{
    public class City : IModel
    {
        public Guid CityId { get; private set; }
        public Guid StateId { get; private set; }
        public string Name { get; private set; }
        public bool IsCapital { get; private set; }
        public int Population { get; private set; }

        private State state { get; set; }

        #region Gets and Sets

        public State State
        {
            get { return this.state; }
            private set
            {
                if(value != null)
                {
                    this.State = value;
                    this.StateId = value.StateId;
                }
            }
        }

        #endregion

        #region Constructors

        public City()
        { this.CityId = Guid.NewGuid(); }

        public City(Guid idCity, Guid idState, string name)
        {
            this.CityId = idCity;
            this.StateId = idState;
            this.Name = name;
        }

        public City(Guid idState, string name) : this()
        {
            this.StateId = idState;
            this.Name = name;
        }

        public City(Guid idCity, string name, State state)
        {
            this.CityId = idCity;
            this.StateId = state.StateId;
            this.Name = name;
            this.State = state;
        }

        public City(State state, string name) : this()
        {
            this.StateId = state.StateId;
            this.Name = name;
            this.State = state;
        }

        public City(State state, string name, bool isCapital) : this()
        {
            this.StateId = state.StateId;
            this.Name = name;
            this.IsCapital = IsCapital;
            this.State = state;
        }

        #endregion

        #region Factories

        public City CreateNew(Guid idCity, Guid idState, string name)
        {
            City city = new City
            {
                CityId = idCity,
                StateId = idState,
                Name = name
            };

            return city;
        }

        public City CreateNew(Guid idState, string name)
        {
            City city = new City
            {
                StateId = idState,
                Name = name
            };

            return city;
        }

        public City CreateNew(Guid idCity, string name, State state)
        {
            City city = new City
            {
                CityId = idCity,
                StateId = state.StateId,
                Name = name,
                State = state
            };

            return city;
        }

        public City CreateNew(State state, string name)
        {
            City city = new City
            {
                StateId = state.StateId,
                Name = name,
                State = state
            };

            return city;
        }

        #endregion

        public void Dispose()
        {
            GC.Collect(0, GCCollectionMode.Forced);
        }

        public ExecutionResult<bool> IsValid()
        {
            var isValid = new ExecutionResult<bool>();
            //bool isValid = true;
            
            return isValid;
        }

        public void DefineName(string name)
        { this.Name = name; }
        
        public void DefinePopulation(int population)
        { this.Population = population; }

        public void AssignState(State state)
        { this.State = state; }
    }
}
