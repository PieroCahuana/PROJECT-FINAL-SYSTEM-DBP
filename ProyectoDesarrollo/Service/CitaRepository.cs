using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public class CitaRepository : ICita
    {
        private ClinicaC conexion = new ClinicaC();

        public void addC(Cita cita)
        {
            conexion.Citas.Add(cita);
            conexion.SaveChanges();
        }
        public Cita CitaId(int id)
        {
            var obj = (from tcita in conexion.Citas.Include(d => d.IdEspecialidadNavigation).Include(d => d.IdDoctorNavigation).Include(d => d.IdEstadosNavigation).Include(d => d.IdPacienteNavigation).Include(d => d.IdHorarioNavigation).ToList()
                       where tcita.IdCitas == id
                       select tcita).Single();
            return obj;

        }
        public void editDetails(Cita obj)
        {
            var objAModificar = (from tcita in conexion.Citas.Include(d => d.IdEspecialidadNavigation).Include(d => d.IdDoctorNavigation).Include(d => d.IdEstadosNavigation).Include(d => d.IdPacienteNavigation).Include(d => d.IdHorarioNavigation).ToList()
                                 where tcita.IdCitas == obj.IdCitas
                                 select tcita).FirstOrDefault();
            objAModificar.FechaCitas = obj.FechaCitas;
            objAModificar.IdEspecialidad = obj.IdEspecialidad;
            objAModificar.IdDoctor = obj.IdDoctor;
            objAModificar.IdEstados = obj.IdEstados;
            objAModificar.IdHorario = obj.IdHorario;
            objAModificar.IdPaciente = obj.IdPaciente;
            conexion.SaveChanges();
        }
        public IEnumerable<Cita> GetCitas()
        {
            return conexion.Citas.Include(d => d.IdEspecialidadNavigation).Include(d => d.IdDoctorNavigation).Include(d => d.IdEstadosNavigation).Include(d => d.IdPacienteNavigation).Include(d => d.IdHorarioNavigation).ToList();
        }
        public void RemoveC(int id)
        {
            var encontrado = (from tcita in conexion.Citas.Include(d => d.IdEspecialidadNavigation).Include(d => d.IdDoctorNavigation).Include(d => d.IdEstadosNavigation).Include(d => d.IdPacienteNavigation).Include(d => d.IdHorarioNavigation).ToList()
                              where tcita.IdCitas == id
                              select tcita).Single();
            conexion.Citas.Remove(encontrado);
            conexion.SaveChanges();
        }
        public IEnumerable<Doctor> GetDoctoresPorEspecialidad(int IdEspecialidad)
        {
            return conexion.Doctors.Include(d => d.IdEspecialidadNavigation).ToList()
                .Where(d => d.IdEspecialidad == IdEspecialidad)
                .ToList();
        }
        public IEnumerable<Cita> GetCitasporDoctor(string usuD)
        {
            return conexion.Citas.Include(d => d.IdEspecialidadNavigation).Include(d => d.IdDoctorNavigation).Include(d => d.IdEstadosNavigation).Include(d => d.IdPacienteNavigation).Include(d => d.IdHorarioNavigation).ToList()
                .Where(d => d.IdDoctorNavigation?.UsuDoctor == usuD)
                .ToList();
        }
        public List<Cita> GetCitasByPaciente(string usuP)
        {
            return conexion.Citas.Include(d => d.IdEspecialidadNavigation).Include(d => d.IdDoctorNavigation).Include(d => d.IdEstadosNavigation).Include(d => d.IdPacienteNavigation).Include(d => d.IdHorarioNavigation).ToList()
                .Where(d => d.IdPacienteNavigation?.UsuPaciente == usuP)
                .ToList();
        }

        public int CantidadCitasporDoctores(string usuD)
        {
            return conexion.Citas.Include(d => d.IdEspecialidadNavigation).Include(d => d.IdDoctorNavigation).Include(d => d.IdEstadosNavigation).Include(d => d.IdPacienteNavigation).Include(d => d.IdHorarioNavigation).ToList()
                .Where(d => d.IdDoctorNavigation?.UsuDoctor == usuD).Count();
        }
        public int CantidadCitasporPacientes(string usuP)
        {
            return conexion.Citas.Include(d => d.IdEspecialidadNavigation).Include(d => d.IdDoctorNavigation).Include(d => d.IdEstadosNavigation).Include(d => d.IdPacienteNavigation).Include(d => d.IdHorarioNavigation).ToList()
                .Where(d => d.IdPacienteNavigation?.UsuPaciente == usuP).Count();
        }
        public int CantidadCitas()
        {
            return conexion.Citas.Count();
        }
    }
}
