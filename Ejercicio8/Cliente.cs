using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio8
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public int NroCuenta { get; set; }

        public Cliente() //constructor simple 
        {
        }
        public Cliente(string nombre,string apellido,int nroCuenta) //constructor parametrizado
        {
            Nombre = nombre;
            Apellido = apellido;
            NroCuenta=nroCuenta;
        }
    }
}
