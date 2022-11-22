using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEINT_Ej9_Ficheros_Serializacion_XML.Modelo
{
    internal class Cliente
    {
        public String dni { get; set; }
        public String nombre { get; set; }
        public String direccion { get; set; }
        public int edad { get; set; }
        public int telefono { get; set; }
        public String num_cuenta_corriente { get; set; }

        public Cliente(String dni, String nombre, String direccion, int edad, int telefono, String num_cuenta_corriente)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.direccion = direccion;
            this.edad = edad;
            this.telefono = telefono;
            this.num_cuenta_corriente = num_cuenta_corriente;
        }

    }
}
