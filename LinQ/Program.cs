using System;
using System.Collections.Generic; //Para poder usar Generics
using System.Linq; //Para poder usar LinQ
namespace LinQ
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
                }
            };
            foreach (var cerveza in cervezas)
                Console.WriteLine(cerveza);

            Console.WriteLine("\n----------LINQ----------\n");

            //Select. Para seleccionar elementos
            //Creamos una lista nueva con LinQ. Donde solo extraemos el nombre, longitud y creamos un dato fijo.
            var cervezasName = from c in cervezas
                               select new
                               {    //Tipos Anonimos. Porque no estan en la clase Beer
                                   Name = c.Name, //Nombre de cada cerveza en la lista
                                   Longitud = c.Name.Length, //Tamaño del nombre
                                   Fixed = 1 //Tipo fijo, no extraemos ningun dato
                               };
            foreach (var cerveza in cervezasName)
                Console.WriteLine($"Nombre: {cerveza.Name}. Tamaño de nombre: {cerveza.Longitud}. Dato fijo: {cerveza.Fixed}");
            Console.WriteLine("\n----------LINQ----------\n");
//Creamos una nueva lista apartir de la lista anterior. Siendo las 2 lista un tipo anonimo de la interfaz IEnumerable
            var cervezasNameReal = from c in cervezasName
                                   select new
                                   {
                                       Name = c.Name // Solo extraemos el nombre
                                   };
            foreach(var cerveza in cervezasNameReal)
                Console.WriteLine(cerveza.Name);
            Console.WriteLine("\n----------LINQ----------\n");
            //where -> Donde, para indicar donde quiero buscar/extraer informacion
            var cervezasMexico = from c in cervezas
                                 where c.Country == "Mexico"
                                 || c.Country == "Alemania"
                                 select c; //Seleccionamos toda la coleccion
            foreach(var cerveza in cervezasMexico)
                Console.WriteLine(cerveza);
            Console.WriteLine("\n----------LINQ----------\n");
            //orderby. Ordenar datos
            var ordenCervezas = from c in cervezas
                                orderby c.Country
                                select c;
            foreach(var cerveza in ordenCervezas)
                Console.WriteLine(cerveza);
            Console.WriteLine("\n----------LINQ----------\n");
            //orderby. Ordenar datos. descendig para ordenar de forma descendente
            var ordenCervezasDescendente = from c in cervezas
                                orderby c.Country descending
                                select c;
            foreach (var cerveza in ordenCervezasDescendente)
                Console.WriteLine(cerveza);

        } //Main


    } //Class Program


    public class Beer
    {
        public string Name { get; set; }
        public string Country { get; set; }


        //Modificacion de ToString
        public override string ToString()
        {
            return $"Nombre: {Name}, País: {Country} ";
        }
    }

}//namespace
   