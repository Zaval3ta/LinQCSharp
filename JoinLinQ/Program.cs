using System;
using System.Linq;

namespace JoinLinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var cervezas = new List<Beer>()
            {
                new Beer()
                {
                    Name = "Victoria", Country = "Mexico"
                },
                new Beer()
                {
                    Name = "Delirium", Country = "Belgica"
                },
                new Beer()
                {
                    Name = "Erdinger", Country = "Alemania"
                },
                new Beer()
                {
                    Name = "Negra Modelo", Country = "Mexico"
                },
            };

            var continentes = new List<Country>()
            {
                new Country()
                {
                    Name = "Mexico", Continent = "America"
                },
                new Country()
                {
                    Name = "Belgica", Continent = "Europa"
                },
                new Country()
                {
                    Name = "Alemania", Continent = "Europa"
                }
            };

            var cervezasConContinente = from cervezasC in cervezas
                                        join country in continentes
                                        on cervezasC.Country equals country.Name
                                        select new
                                        {
                                            Name = cervezasC.Name,
                                            Country = cervezasC.Country,
                                            Continent = country.Continent
                                        };
            foreach(var CervezasC in cervezasConContinente)
                Console.WriteLine($"Nombre: {CervezasC.Name}, País: {CervezasC.Country}, Continente: {CervezasC.Continent}");


        }//Fin de Main


    }//Fin de Program

    public class Beer
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public string Continent { get; set; }
    }


}//Fin de namespace