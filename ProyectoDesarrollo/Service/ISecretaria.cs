using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public interface ISecretaria
    {
        void addS(Secretarium secre);
        IEnumerable<Secretarium> GetSecretarias();
        public void RemoveS(int id);
        public Secretarium SecretariaId(int id);

        public void editDetails(Secretarium obj);
        public Secretarium PerfilS(string usuS);
        public int CantidadSecretarias();
    }
}
