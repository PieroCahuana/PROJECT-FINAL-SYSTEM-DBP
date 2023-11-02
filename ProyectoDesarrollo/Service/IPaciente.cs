using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public interface IPaciente
    {
        void addP(Paciente paciente);
        IEnumerable<Paciente> GetPacientes();
        void RemoveP(int id);
        public Paciente PacienteId(int id);

        public void editDetails(Paciente obj);
        public IEnumerable<Genero> GetDistinctGeneros();
        public Paciente PerfilP(string usuP);
        public int CantidadPacientes();
    }
}
