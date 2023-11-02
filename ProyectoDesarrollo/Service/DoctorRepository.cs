using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public class DoctorRepository : IDoctor
    {
        private ClinicaC conexion = new ClinicaC();
        public void addD(Doctor doc)
        {
            conexion.Doctors.Add(doc);
            conexion.SaveChanges();
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return conexion.Doctors.Include(d => d.IdEspecialidadNavigation).ToList();
        }
        public void RemoveD(int id)
        {
            var encontrado = (from tdoc in conexion.Doctors
                              where tdoc.IdDoctor == id
                              select tdoc).Single();
            conexion.Doctors.Remove(encontrado);
            conexion.SaveChanges();
        }
        public Doctor DoctorId(int id)
        {
            var obj = (from tsec in conexion.Doctors
                       where tsec.IdDoctor == id
                       select tsec).Single();
            return obj;

        }
        public void editDetails(Doctor obj)
        {
            var objAModificar = (from tsec in conexion.Doctors.Include(d => d.IdEspecialidadNavigation).ToList()
                                 where tsec.IdDoctor == obj.IdDoctor
                                 select tsec).FirstOrDefault();
            objAModificar.NomDoctor = obj.NomDoctor;
            objAModificar.ApeDoctor = obj.ApeDoctor;
            objAModificar.DniDoctor = obj.DniDoctor;
            objAModificar.TelDoctor = obj.TelDoctor;
            objAModificar.IdEspecialidad = obj.IdEspecialidad;
            objAModificar.UsuDoctor = obj.UsuDoctor;
            objAModificar.ContraDoctor = obj.ContraDoctor;
            conexion.SaveChanges();
        }
        public Doctor PerfilD(string usuD)
        {
            var usuencontrado = conexion.Doctors.Include(d => d.IdEspecialidadNavigation).ToList().Single(tdoc => tdoc.UsuDoctor == usuD);
            return usuencontrado;
        }
        public int CantidadDoctores()
        {
            return conexion.Doctors.Count();
        }
        public  IEnumerable<Doctor> GetDoctoresPorEspecialidad(int especialidadId)
        {
            var doctores = conexion.Doctors.Where(d => d.IdEspecialidad == especialidadId).ToList();
            return doctores;
        }
    }
}
