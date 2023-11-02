using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public class EspecialidadRepository:IEspecialidad
    {
        private ClinicaC conexion = new ClinicaC();
        public void addE(Especialidad especialidad)
        {
            conexion.Especialidads.Add(especialidad);
            conexion.SaveChanges();
        }
        public IEnumerable<Especialidad> GetDistinctEspecialidad()
        {
            return conexion.Especialidads.ToList();
        }
        public int CantidadEspecialidades()
        {
            return conexion.Doctors.Include(d => d.IdEspecialidadNavigation).Select(d => d.IdEspecialidadNavigation).ToList().Count();
        }
        public IEnumerable<Especialidad> GetEspecialidadDoc()
        {
            return conexion.Doctors.Select(p => p.IdEspecialidadNavigation).Distinct().ToList();
        }
        public int cantidadEspecilidadesporDoctor()
        {
            return conexion.Doctors.Select(p => p.IdEspecialidadNavigation).Distinct().Count();
        }
    }
}
