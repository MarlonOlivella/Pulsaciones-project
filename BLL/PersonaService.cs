using System;
using Entity;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class PersonaService
    {
        private PersonaReposiroty personaRepository;

        public PersonaService()
        {
            personaRepository = new PersonaReposiroty();
        }
        public string Guardar(Persona persona)
        {
            try
            {
                if (personaRepository.Buscar(persona.Identificacion) == null)
                {
                    personaRepository.Guardar(persona);
                    return $"Los datos de {persona.Nombre} han sido guardados correctamente";
                }
                return $"No es posible registrar a la persona con cedula {persona.Identificacion}, porque ya se encuentra registrada";                
            } catch (Exception E)
            {
                return "Error de lectura o escritura de archivos" + E.Message;
            }
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                if ((personaRepository.Buscar(identificacion))!=null)
                {
                    personaRepository.Eliminar(identificacion);
                    return $"Los datos de la persona con cedula {identificacion} han sido eliminados correctamente";
                }
                return $"No es posible eliminar a la persona con cedula {identificacion}, porque no se encuentra registrada";
            }
            catch (Exception E)
            {
                return "Error de lectura o escritura de archivos" + E.Message;
            }
        }
        public string Modificar(string identificacion)
        {
            try
            {
                Persona persona = personaRepository.Buscar(identificacion);
                if (persona != null)
                {
                    persona = LlenarDatos(persona);
                    personaRepository.Modificar(persona);
                    return $"Los datos de {persona.Nombre} han sido modificados correctamente";
                }
                return $"No es posible modificar a la persona con cedula {identificacion}, porque no se encuentra registrada";
            }
            catch (Exception E)
            {
                return "Error de lectura o escritura de archivos" + E.Message;
            }
        }
        public void Consultar()
        {
            try
            {
                List<Persona> personas = personaRepository.Consultar();
                if (personas.Count != 0)
                {
                    foreach (var persona in personas)
                    {
                        Console.WriteLine(persona.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No existen personas registradas");
                }
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
            }
        }
        public Persona LlenarDatos(Persona persona)
        {
            Console.WriteLine("Digite su nombre");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("Digite su sexo F/M");
            persona.Sexo = Console.ReadLine();
            Console.WriteLine("Digite su edad");
            persona.Edad = int.Parse(Console.ReadLine());
            return persona;
        }
    }
}