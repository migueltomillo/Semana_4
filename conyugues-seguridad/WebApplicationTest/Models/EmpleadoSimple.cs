using System;
using System.Linq;
using WebApplicationTest.Entities;

namespace WebApplicationTest.Models
{
    //DTO DATA TRANSFER OBJECT
    public class EmpleadoSimple
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get; set; }
        public float Salario { get; set; }
        public DateTime Nacimiento { get; set; }
        public double Edad { get; set; }
        public int Creditos { get; internal set; }

        public static EmpleadoSimple Convertir(Empleado empleado)
        {
            return new EmpleadoSimple
            {
                EmpleadoId = empleado.EmpleadoId,
                Apellido = empleado.Apellido,
                Nombre = empleado.Nombre,
                Edad = empleado.Edad,
                Nacimiento = empleado.Nacimiento,
                NombreCompleto = empleado.NombreCompleto,
                Salario = empleado.Salario,
                Creditos = empleado.Cursos.Sum(x => x.NumeroCreditos)
            };
        }
    }
}
