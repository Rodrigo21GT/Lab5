using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso__1
{
    public partial class Form1 : Form
    {
        List<Empleado> empleados = new List<Empleado>();
        List<Asistencia> asistencias = new List<Asistencia>();
        List<Reporte> reportes = new List<Reporte>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarEmpleados();
            CargarEmpleados();
            MostrarAsistencia();

        }
        private void MostrarEmpleados()
        {

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = empleados;
            dataGridView1.Refresh();
        }
        private void CargarEmpleados()
        {
            string fileName = "Datos.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)

            {
                Empleado empleado = new Empleado();
                empleado.NoEmpleado = Convert.ToInt32(reader.ReadLine());
                empleado.Nombre = reader.ReadLine();
                empleado.Sueldo = Convert.ToDecimal(reader.ReadLine());

                //Guardar el empleado a la lista de empleados
                empleados.Add(empleado);
            }
            reader.Close();
        }
        public void CargarAsistencia()
        {
            string fileName = "Horas.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)

            {
                Asistencia asistencia = new Asistencia();
                asistencia.NoEmpleado = Convert.ToInt32(reader.ReadLine());
                asistencia.HorasMes = Convert.ToInt32(reader.ReadLine());
                asistencia.Mes = Convert.ToInt32(reader.ReadLine());

                //Guardar el empleado a la lista de empleados
                asistencias.Add(asistencia);
            }
        }
        private void MostrarAsistencia()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = asistencias;
            dataGridView2.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Empleado empleado in empleados)
            {
                int noEmpleado = empleado.NoEmpleado;

                foreach(Asistencia asistencia in asistencias)
                {
                    if(empleado.NoEmpleado == asistencia.NoEmpleado)
                    {
                        Reporte reporte = new Reporte();
                        reporte.NombreEmpleado = empleado.Nombre;
                        reporte.Mes = asistencia.Mes;
                        reporte.SueldoMensual = empleado.Sueldo * asistencia.HorasMes;

                        reportes.Add(reporte);
                    }
                }
            }
            dataGridView3.DataSource=null;
            dataGridView3.DataSource = reportes;
            dataGridView3.Refresh();
        }
        private void CargarReporte()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarAsistencia();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "NoEmpleados";
            comboBox1.DataSource = empleados;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int noEmpleados = Convert.ToInt32(comboBox1.SelectedValue); 


            Empleado empleadoEncontrado = empleados.Find(c => c.NoEmpleado == noEmpleados);
            Asistencia asistenciaEncontrada = asistencias.Find(u => u.NoEmpleado == noEmpleados);

            decimal sueldo = empleadoEncontrado.Sueldo = asistenciaEncontrada.HorasMes;
            label1.Text = empleadoEncontrado.Nombre;
            label1.Text = sueldo.ToString();
        }
    }
}
