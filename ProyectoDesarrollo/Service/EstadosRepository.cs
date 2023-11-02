using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public class EstadosRepository : IEstados
    {
        private ClinicaC conexion = new ClinicaC();
        public void addE(Estado estado)
        {
            conexion.Estados.Add(estado);
            conexion.SaveChanges();
        }
        public IEnumerable<Estado> GetDistinctEstado()
        {
            return conexion.Estados.ToList();
        }
    }
}
