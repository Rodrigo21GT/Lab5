using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso__1
{
    internal class Empleado
    {
        int noEmpleado;
        string nombre;
        decimal sueldo;

        public int NoEmpleado { get => noEmpleado; set => noEmpleado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Sueldo { get => sueldo; set => sueldo = value; }
    }
}
