using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public interface IHorario
    {
        public void addH(Horario hora);
        public Horario HoraId(int id);
        public void editDetails(Horario obj);
        public IEnumerable<Horario> GetHorarios();
        public void RemoveH(int id);
    }
}
