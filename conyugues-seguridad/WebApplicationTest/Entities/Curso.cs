using System.Collections.Generic;

namespace WebApplicationTest.Entities
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int NumeroCreditos { get; set; }
        public List<Empleado> Participantes { get; set; }
        public Institucion Institucion { get; set; }
    }
}
