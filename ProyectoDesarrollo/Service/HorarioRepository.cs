using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public class HorarioRepository : IHorario
    {
        private ClinicaC conexion = new ClinicaC();

        public void addH(Horario hora)
        {
            conexion.Horarios.Add(hora);
            conexion.SaveChanges();
        }
        public Horario HoraId(int id)
        {
            var obj = (from thora in conexion.Horarios
                       where thora.IdHorario == id
                       select thora).Single();
            return obj;

        }
        public void editDetails(Horario obj)
        {
            var objAModificar = (from thora in conexion.Horarios
                                 where thora.IdHorario == obj.IdHorario
                                 select thora).FirstOrDefault();
            objAModificar.Hora = obj.Hora;
            conexion.SaveChanges();
        }
        public IEnumerable<Horario> GetHorarios()
        {
            return conexion.Horarios;
        }
        public void RemoveH(int id)
        {
            var encontrado = (from thora in conexion.Horarios
                              where thora.IdHorario == id
                              select thora).Single();
            conexion.Horarios.Remove(encontrado);
            conexion.SaveChanges();
        }
    }
}
