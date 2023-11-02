using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public interface IEspecialidad
    {
        void addE(Especialidad especialidad);
        public IEnumerable<Especialidad> GetDistinctEspecialidad();
        public IEnumerable<Especialidad> GetEspecialidadDoc();
        public int cantidadEspecilidadesporDoctor();
    }
}
