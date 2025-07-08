using Actividad_11_y_12.Medicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_11_y_12
{
    internal class GestorFarmacia
    {
        static List<Medicina> inventario = new List<Medicina>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("SISTEMA DE GESTIÓN DE FARMACIA");
                Console.WriteLine("1. Registrar nuevo medicamento");
                Console.WriteLine("2. Consultar datos restringidos");
                Console.WriteLine("3. Salir del sistema");
                Console.Write("\nSeleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarMedicamento();
                        break;
                    case "2":
                        ConsultarDatosPrivados();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Presione ENTER para continuar.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void RegistrarMedicamento()
        {
            Console.Clear();
            Console.WriteLine("REGISTRO DE MEDICAMENTO");

            Console.Write("Código del producto: ");
            string codigo = Console.ReadLine();

            Console.Write("Nombre comercial: ");
            string nombre = Console.ReadLine();

            Console.Write("Laboratorio: ");
            string laboratorio = Console.ReadLine();

            Console.Write("Categoría terapéutica: ");
            string categoria = Console.ReadLine();

            Console.Write("Precio unitario: ");
            decimal precio = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Número de lote: ");
            string lote = Console.ReadLine();

            Console.Write("Fecha de expiración (dd/mm/yyyy): ");
            DateTime fechaExp = DateTime.Parse(Console.ReadLine());

            Console.Write("Clave de seguridad (solo para administradores): ");
            string clave = Console.ReadLine();

            inventario.Add(new Medicina(codigo, nombre, laboratorio, categoria, precio, lote, fechaExp, clave));

            Console.WriteLine("\nMedicamento registrado exitosamente. Presione ENTER para volver al menú.");
            Console.ReadLine();
        }

        static void ConsultarDatosPrivados()
        {
            Console.Clear();
            Console.WriteLine("CONSULTA DE DATOS RESTRINGIDOS");

            Console.Write("Ingrese el código del medicamento: ");
            string codigo = Console.ReadLine();

            Medicina med = inventario.Find(m => m.Codigo == codigo);

            if (med == null)
            {
                Console.WriteLine("Medicamento no encontrado. Presione ENTER para volver.");
                Console.ReadLine();
                return;
            }

            while (true)
            {
                Console.Write("Ingrese la clave de seguridad: ");
                string clave = Console.ReadLine();

                if (med.VerificarClave(clave))
                {
                    Console.WriteLine("\nACCESO PERMITIDO");
                    Console.WriteLine("Número de lote: " + med.ObtenerLote());
                    Console.WriteLine("Fecha de expiración: " + med.ObtenerFechaExpiracion().ToShortDateString());
                    break;
                }
                else
                {
                    Console.WriteLine("Clave incorrecta. Intente de nuevo.\n");
                }
            }

            Console.WriteLine("\nPresione ENTER para regresar al menú principal.");
            Console.ReadLine();
        }
    }
}
