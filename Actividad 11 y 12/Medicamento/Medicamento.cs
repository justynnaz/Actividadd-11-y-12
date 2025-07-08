using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_11_y_12.Medicamento
{
    public class Medicina
    {
        public string Codigo;
        public string Nombre;
        public string Laboratorio;
        public string Categoria;
        public decimal Precio;

        private string Lote;
        private DateTime FechaExpiracion;
        private string ClaveSeguridad;

        public Medicina(string codigo, string nombre, string laboratorio, string categoria,
                           decimal precio, string lote, DateTime fechaExpiracion, string claveSeguridad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Laboratorio = laboratorio;
            Categoria = categoria;
            Precio = precio;
            Lote = lote;
            FechaExpiracion = fechaExpiracion;
            ClaveSeguridad = claveSeguridad;
        }

        public bool VerificarClave(string clave)
        {
            return clave == ClaveSeguridad;
        }

        public string ObtenerLote()
        {
            return Lote;
        }

        public DateTime ObtenerFechaExpiracion()
        {
            return FechaExpiracion;
        }
    }
}
