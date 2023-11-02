using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public interface IDoctor
    {
        void addD(Doctor doc);
        IEnumerable<Doctor> GetDoctors();
        void RemoveD(int id);
        public Doctor DoctorId(int id);
        public void editDetails(Doctor obj);
        public Doctor PerfilD(string usuD);
        public int CantidadDoctores();
        public IEnumerable<Doctor> GetDoctoresPorEspecialidad(int especialidadId);
    }
}
