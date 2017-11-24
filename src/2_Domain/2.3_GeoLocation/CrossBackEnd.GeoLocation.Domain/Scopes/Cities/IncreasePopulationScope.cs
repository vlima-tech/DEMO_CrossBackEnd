
using CrossBackEnd.GeoLocation.Domain.Models;

namespace CrossBackEnd.GeoLocation.Domain.Scopes.Cities
{
    public static class IncreasePopulationScope
    {
        public static void IncreasePopulation(this City city, int newsHabitants)
        {
            city.DefinePopulation(city.Population + newsHabitants);
        }
    }
}