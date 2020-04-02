using System;

namespace Entity
{
    public class Persona
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public decimal Pulsacion { get; set; }
        public override string ToString()
        {
            return $"{Identificacion};{Nombre};{Edad};{Sexo};{Pulsacion}";
        }
        public void CalcularPulsacion()
        {
            if (Sexo.ToUpper() == "F")
            {
                Pulsacion = (220 - Edad) / 10;
            }
            else if (Sexo.ToUpper() == "M")
            {
                Pulsacion = (210 - Edad) / 10;
            }
            else
            {
                Pulsacion = 0;
            }
        }
    }
}
