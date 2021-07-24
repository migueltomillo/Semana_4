using System.Collections.Generic;

namespace WebApplicationTest.Entities
{
    public class Departamento
    { 
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        //public Empleado Director { get; set; }
        public List<Empleado> Empleados { get; set; }
    }
}
