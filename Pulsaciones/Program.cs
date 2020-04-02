using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;

namespace Pulsaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonaService personaService = new PersonaService();
            Persona persona = new Persona();
            string mensaje;
            Console.WriteLine("Digite su identificacion");
            persona.Identificacion = Console.ReadLine();
            Console.WriteLine("Digite su nombre");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("Digite su sexo F/M");
            persona.Sexo = Console.ReadLine();
            Console.WriteLine("Digite su edad");
            persona.Edad = int.Parse(Console.ReadLine());

            persona.CalcularPulsacion();
            mensaje = personaService.Guardar(persona);
            Console.WriteLine(persona.ToString());
            Console.WriteLine(mensaje);
            //mensaje = personaService.Modificar("1003241124");
            Console.WriteLine(persona.ToString());
            Console.WriteLine(mensaje);
            //mensaje = personaService.Eliminar("1003241124");
            Console.WriteLine(persona.ToString());
            Console.WriteLine(mensaje);
            Console.WriteLine($"Sus pulsaciones: {persona.Pulsacion}");
            personaService.Consultar();
            Console.ReadKey();
        }
    }
}
