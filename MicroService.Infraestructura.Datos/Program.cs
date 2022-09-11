using System;

using MicroService.Infraestructura.Datos.Contextos;

namespace MicroService.Infraestructura.Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la DB si no existe");
            DBContexto db = new DBContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("DB ha sido creada");
            Console.ReadKey();
        }
    }
}
