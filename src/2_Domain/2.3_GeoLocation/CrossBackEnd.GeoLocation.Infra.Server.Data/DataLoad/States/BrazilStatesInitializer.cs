
using CrossBackEnd.GeoLocation.Domain.Collections;
using CrossBackEnd.GeoLocation.Domain.Models;
using CrossBackEnd.GeoLocation.Infra.Server.Data.Context;
using System;
using System.Linq;

namespace CrossBackEnd.GeoLocation.Infra.Server.Data.DataLoad.States
{
    public class BrazilStatesInitializer
    {
        public static void Initializer(GeoLocation_Context context)
        {
            StateCollection states = new StateCollection();

            if (!context.States.Any())
            {
                Country country = null;
                
                country = context.Countries.Where(c => c.Name.ToLower()
                    .Equals("brazil"))
                    .FirstOrDefault();

                if (country != null)
                {
                    states.AddRange(new StateCollection()
                    {
                        new State(country, "Acre", "AC"),
                        new State(country, "Alagoas", "AL"),
                        new State(country, "Amazonas", "AM"),
                        new State(country, "Amapá", "AP"),
                        new State(country, "Bahia", "BA"),
                        new State(country, "Ceará", "CE"),
                        new State(country, "Distrito Federal", "DF"),
                        new State(country, "Espírito Santo", "ES"),
                        new State(country, "Goiânia", "GO"),
                        new State(country, "Maranhão", "MA"),
                        new State(country, "Minas Gerais", "MG"),
                        new State(country, "Mato Grosso do Sul", "MS"),
                        new State(country, "Mato Grosso", "MT"),
                        new State(country, "Pará", "PA"),
                        new State(country, "Paraíba", "PB"),
                        new State(country, "Pernambuco", "PE"),
                        new State(country, "Piauí", "PI"),
                        new State(country, "Paraná", "PR"),
                        new State(country, "Rio de Janeiro", "RJ"),
                        new State(country, "Rio Grande do Norte", "RN"),
                        new State(country, "Rondônia", "RO"),
                        new State(country, "Roraima", "RR"),
                        new State(country, "Rio Grande do Sul", "RS"),
                        new State(country, "Santa Catarina", "SC"),
                        new State(country, "Sergipe", "SE"),
                        new State(country, "São Paulo", "SP"),
                        new State(country, "Tocantins", "TO"),
                    });
                }

                states.ForEach(x => context.Add(x));
            }

            context.SaveChanges();

            states.Dispose();
            states = null;

            GC.Collect(0, GCCollectionMode.Forced);
        }
    }
}