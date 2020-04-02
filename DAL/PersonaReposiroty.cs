using System;
using System.Collections.Generic;
using System.IO;
using Entity;

namespace DAL
{
    public class PersonaReposiroty
    {
        private string ruta = @"Persona.txt";
        public List<Persona> personas = new List<Persona>();
        public void Guardar(Persona persona)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(persona.ToString());
            writer.Close();
            fileStream.Close();
        }
        public List<Persona> Consultar()
        {
            personas.Clear();
            FileStream fileStream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileStream);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {
                Persona persona = MapearPersona(linea);
                personas.Add(persona);
            }
            fileStream.Close();
            reader.Close();
            return personas;
        }
        public void Eliminar(string identificacion)
        {
            personas.Clear();
            personas = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in personas)
            {
                if (item.Identificacion!=identificacion)
                {
                    Guardar(item);
                }
            }
        }
        public void Modificar(Persona persona)
        {
            personas.Clear();
            personas = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in personas)
            {
                if (item.Identificacion != persona.Identificacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(persona);
                }
            }
        }
        public Persona Buscar(string identificacion)
        {
            personas.Clear();
            personas = Consultar();
            foreach (var item in personas)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;
        }
        public Persona MapearPersona(string linea)
        {
            Persona persona = new Persona();
            string[] datos = linea.Split(';');
            persona.Identificacion = datos[0];
            persona.Nombre = datos[1];
            persona.Edad = int.Parse(datos[2]);
            persona.Sexo = datos[3];
            persona.Pulsacion = int.Parse(datos[4]);
            return persona;
        }
    }
}