using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public interface IGenero
    {
        public void addG(Genero genero);
        public IEnumerable<Genero> GetGeneros();
        public void RemoveG(int id);
        public Genero GenerosId(int id);
        public void editDetails(Genero obj);
    }
}
