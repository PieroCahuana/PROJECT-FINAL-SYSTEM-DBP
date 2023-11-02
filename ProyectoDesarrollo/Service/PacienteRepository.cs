using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public class PacienteRepository : IPaciente
    {
        private ClinicaC conexion = new ClinicaC();
        public void addP(Paciente paciente)
        {
            conexion.Pacientes.Add(paciente);
            conexion.SaveChanges();
        }

        public IEnumerable<Paciente> GetPacientes()
        {
            return conexion.Pacientes.Include(d => d.IdGeneroNavigation).ToList();
        }

        public void RemoveP(int id)
        {
            var encontrado = (from tpac in conexion.Pacientes
                              where tpac.IdPaciente == id
                              select tpac).Single();
            conexion.Pacientes.Remove(encontrado);
            conexion.SaveChanges();
        }
        public Paciente PacienteId(int id)
        {

            var obj = (from tsec in conexion.Pacientes
                       where tsec.IdPaciente == id
                       select tsec).Single();
            return obj;

        }

        public void editDetails(Paciente obj)
        {
            var objAModificar = (from tsec in conexion.Pacientes.Include(d => d.IdGeneroNavigation).ToList()
            where tsec.IdPaciente == obj.IdPaciente
                                 select tsec).FirstOrDefault();
            objAModificar.NomPaciente = obj.NomPaciente;
            objAModificar.ApePaciente = obj.ApePaciente;
            objAModificar.NacPaciente = obj.NacPaciente;
            objAModificar.DniPaciente = obj.DniPaciente;
            objAModificar.IdGenero = obj.IdGenero;
            objAModificar.TelPaciente = obj.TelPaciente;
            objAModificar.UsuPaciente = obj.UsuPaciente;
            objAModificar.ContraPaciente = obj.ContraPaciente;
            conexion.SaveChanges();
        }
        public IEnumerable<Genero> GetDistinctGeneros()
        {
            return conexion.Pacientes.Select(p => p.IdGeneroNavigation).Distinct().ToList();
        }
        public Paciente PerfilP(string usuP)
        {
            var usuencontrado = conexion.Pacientes.Include(d => d.IdGeneroNavigation).ToList().Single(tdoc => tdoc.UsuPaciente == usuP);
            return usuencontrado;
        }

        public int CantidadPacientes()
        {
            return conexion.Pacientes.Count();
        }
    }
}
