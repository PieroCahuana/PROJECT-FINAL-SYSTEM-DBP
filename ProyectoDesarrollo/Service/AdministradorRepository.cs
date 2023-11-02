using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public class AdministradorRepository : IAdministrador
    {
        private ClinicaC conexion = new ClinicaC();
        public void addA(Administrador admin)
        {
            conexion.Administradors.Add(admin);
            conexion.SaveChanges();
        }
        public IEnumerable<Administrador> GetAdministradors()
        {
            return conexion.Administradors;
        }
        public Administrador PerfilA(string usuA)
        {
            var usuencontrado = conexion.Administradors.Single(tdoc => tdoc.UsuAdministrador == usuA);
            return usuencontrado;
        }
        public int CantidadAdministradores()
        {
            return conexion.Administradors.Count();
        }
        public Administrador AdminId(int id)
        {
            var obj = (from tcita in conexion.Administradors
                       where tcita.IdAdministrador == id
                       select tcita).Single();
            return obj;
        }
        public void editDetails(Administrador obj)
        {
            var objAModificar = (from tcita in conexion.Administradors
                                 where tcita.IdAdministrador == obj.IdAdministrador
                                 select tcita).FirstOrDefault();
            objAModificar.NomAdministrador = obj.NomAdministrador;
            objAModificar.ApeAdministrador = obj.ApeAdministrador;
            objAModificar.DniAdministrador = obj.DniAdministrador;
            objAModificar.UsuAdministrador = obj.UsuAdministrador;
            objAModificar.ContraAdministrador = obj.ContraAdministrador;
            conexion.SaveChanges();
        }
    }
}
