using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB04.Entities
{
    internal class Alumno
    {
        // Constructor
        public Alumno() { }

        // propiedades automaticas de los atributos
        public String Codigo { get; set; }

        public String Nombre { get; set; }

        public double Promedio { get; set; }

    }
}
