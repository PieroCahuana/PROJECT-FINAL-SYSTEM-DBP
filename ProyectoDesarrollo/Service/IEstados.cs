using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public interface IEstados
    {
        public void addE(Estado estado);
        public IEnumerable<Estado> GetDistinctEstado();
    }
}
