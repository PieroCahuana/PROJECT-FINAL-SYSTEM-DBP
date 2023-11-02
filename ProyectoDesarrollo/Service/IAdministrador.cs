using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public interface IAdministrador
    {
        void addA(Administrador admin);
        IEnumerable<Administrador> GetAdministradors();
        public Administrador PerfilA(string usuA);
        public int CantidadAdministradores();
        public Administrador AdminId(int id);
        public void editDetails(Administrador obj);
    }
}
