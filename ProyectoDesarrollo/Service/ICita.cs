using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public interface ICita
    {
        void addC(Cita cita);
        IEnumerable<Cita> GetCitas();
        void RemoveC(int id);
        public IEnumerable<Doctor> GetDoctoresPorEspecialidad(int IdEspecialidad);
        public Cita CitaId(int id);
        public void editDetails(Cita obj);
        public IEnumerable<Cita> GetCitasporDoctor(string usuD);
        public List<Cita> GetCitasByPaciente(string usuP);
        public int CantidadCitasporDoctores(string usuD);
        public int CantidadCitasporPacientes(string usuP);
        public int CantidadCitas();
    }
}
