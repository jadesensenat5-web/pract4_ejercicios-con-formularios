using LAB04.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB04.Controllers
{
    internal class AlumnoController
    {
        // Arreglo
        private Alumno[] alumnos = new Alumno[100];
        private int cont = 0;

        // Listar todos los alumnos 
        public Alumno[] ListarTodo() { return alumnos; }

        // Registrar alumnos
        public void Registrar(Alumno alumno)
        {
            alumnos[cont] = alumno;
            cont++;
        }

        // Eliminar alumnos del arreglo 
        public void Eliminar(String codigo)
        {
            int posicion = Array.FindIndex(alumnos, alumno => alumno.Codigo == codigo);

            // Lógica de eliminación
            for (int i = 0; i < cont; i++)
            {
                if (i >= posicion)
                {
                    alumnos[i] = alumnos[i + 1];
                }
            }

            cont--;

        }

        // Método comparación
        private class MetodoComparacion : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                if (((Alumno)x).Promedio < ((Alumno)y).Promedio) return -1; // ordenar de forma ascendente
                else if (((Alumno)x).Promedio == ((Alumno)y).Promedio) return 0;
                else return 1;

            }
        }

        // Ordenar alumnos según su promedio
        public Alumno[] Ordenar()
        {
            Array.Sort(alumnos, 0, cont, new MetodoComparacion());
            return (Alumno[])alumnos;
        }

        // Buscar alumno según su código
        public Alumno[] BuscarPorCodigo(string codigo)
        {
            return Array.FindAll(alumnos, alumno => alumno != null && alumno.Codigo.Contains(codigo));
        }
    }
}

