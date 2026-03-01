using LAB04.Controllers;
using LAB04.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB04
{
    public partial class Form1 : Form
    {
        // Llamar al controlador
        private AlumnoController alumnoController = new AlumnoController();
        public Form1()
        {
            InitializeComponent();
        }

        //Mostrar
        private void MostrarAlumnos(Alumno[] alumnos)
        {
            dgAlumnos.DataSource = null;
            dgAlumnos.DataSource = alumnos;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Validar campos de entrada
            if (tbCodigo.Text == "" || tbNombre.Text == "" || tbPromedio.Text == "")
            {
                MessageBox.Show("Ingrese todos los campos");
                return;
            }

            //Crear el alumno
            Alumno alumno = new Alumno()
            {
                Codigo = tbCodigo.Text,
                Nombre = tbNombre.Text,
                Promedio = double.Parse(tbPromedio.Text)
            };

            // Registrar alumno en el arreglo
            alumnoController.Registrar(alumno);

            //Mostrar los alumnos
            MostrarAlumnos(alumnoController.ListarTodo());

            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
            tbCodigo.Clear();
            tbNombre.Clear();
            tbPromedio.Clear();
            tbBuscar.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Validacion de seleccion de fila
            if (dgAlumnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar");
                return;
            }

            // Obtener el codigo
            String codigo = dgAlumnos.SelectedRows[0].Cells[0].Value.ToString();

            // Eliminar la fila seleccionada
            alumnoController.Eliminar(codigo);

            // Mostrar 
            MostrarAlumnos(alumnoController.ListarTodo());

                      
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            MostrarAlumnos(alumnoController.Ordenar());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Validar campo
            if(tbBuscar.Text == "")
            {
                MessageBox.Show("Ingrese el codigo a buscar");
                return;
            }

            // Obtener el codigo
            String codigo = tbBuscar.Text;

            // Mostrar los alumnos de la busqueda
            MostrarAlumnos(alumnoController.BuscarPorCodigo(codigo));
        }
    }
    
}
