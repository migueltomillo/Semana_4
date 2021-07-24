using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplicationTest.Data;
using WebApplicationTest.Entities;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
    [Authorize]
    public class ConsultasController : Controller
    {
        readonly ApplicationDbContext _context;
        public ConsultasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EmpleadoSimple> Empleados()
        {
            IQueryable<Empleado> consulta = _context.Empleados.Include(e => e.Cursos);
            List<Empleado> empleados = consulta.ToList();
            return empleados.Select(
                e => e.ConvertirEnEmpleadoSimple());
        }

        public IEnumerable<EmpleadoSimple> EmpleadosPaginados(int pagina, int tamanio)
        {
            var salto = (pagina - 1) * tamanio;
            var empleados = _context.Empleados.Skip(salto).Take(tamanio).ToList();

            return empleados.Select(
                e => e.ConvertirEnEmpleadoSimple());
        }

        public Empleado[] Data()
        {
            var resultado = from x in _context.Empleados
                            where x.Apellido == "Muñoz"
                            select x;
            return resultado.ToArray();

            //var resultado1 = _context.Empleados.Where(x => x.Apellido == "Muñoz");
            //return resultado1.ToList();
        }

        public object Ejemplo1()
        {
            var consulta = from e in _context.Empleados
                           from h in _context.Hijos
                           where e.EmpleadoId == h.EmpleadoId
                           select e;
            return consulta.ToList();

            var consulta0 = from e in _context.Empleados
                            join h in _context.Hijos
                            on e.EmpleadoId equals h.EmpleadoId
                            select new { e.Apellido, NumeroHijos = e.Hijos.Count };
            return consulta0.ToArray();

            var consulta1 = from e in _context.Empleados
                            from h in _context.Hijos
                            where e.EmpleadoId == h.EmpleadoId
                            select new { e.Apellido, NumeroHijos = e.Hijos.Count };
            return consulta1.ToArray();

            var consulta2 = _context.Empleados
                            .Include(e => e.Hijos)
                            .Select(e => new { e.Apellido, NumeroHijos = e.Hijos.Count });
        }

        public Empleado Crear([Bind("EmpleadoId, Salario, Nombre, Apellido, DepartamentoId")] Empleado empleado)
        {
            _context.Add(empleado);
            _context.SaveChanges();

            //LazyLoad
            //LangerLoader
            //ExplicityLoad
            _context.Entry(empleado).Collection(e => e.Hijos).Load();
            _context.Entry(empleado).Reference(e => e.Departamento).Load();

            return empleado;
        }

        public void Samples()
        {
            using (var otroContexto = new ApplicationDbContext(null))
            {
                if (otroContexto.Cursos.Any(c => c.NumeroCreditos > 100))
                {

                }
            }
        }
    }
}
