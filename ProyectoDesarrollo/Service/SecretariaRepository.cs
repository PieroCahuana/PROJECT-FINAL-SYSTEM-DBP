using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public class SecretariaRepository : ISecretaria
    {
        private ClinicaC conexion = new ClinicaC();
        public void addS(Secretarium secre)
        {
            conexion.Secretaria.Add(secre);
            conexion.SaveChanges();
        }
        public IEnumerable<Secretarium> GetSecretarias()
        {
            return conexion.Secretaria;
        }
        public void RemoveS(int id)
        {
            var encontrado = (from tsec in conexion.Secretaria
                              where tsec.IdSecretaria == id
                              select tsec).Single();
            conexion.Secretaria.Remove(encontrado);
            conexion.SaveChanges();
        }
        public Secretarium SecretariaId(int id)
        {

            var obj = (from tsec in conexion.Secretaria
                       where tsec.IdSecretaria == id
                       select tsec).Single();
            return obj;

        }

        public void editDetails(Secretarium obj)
        {
            var objAModificar = (from tsec in conexion.Secretaria
                                 where tsec.IdSecretaria == obj.IdSecretaria
                                 select tsec).FirstOrDefault();
            objAModificar.NomSecretaria = obj.NomSecretaria;
            objAModificar.ApeSecretaria = obj.ApeSecretaria;
            objAModificar.DniSecretaria = obj.DniSecretaria;
            objAModificar.TelSecretaria = obj.TelSecretaria;
            objAModificar.UsuSecretaria = obj.UsuSecretaria;
            objAModificar.ContraSecretaria = obj.ContraSecretaria;
            conexion.SaveChanges();
        }
        public Secretarium PerfilS(string usuS)
        {
            var usuencontrado = conexion.Secretaria.Single(tdoc => tdoc.UsuSecretaria == usuS);
            return usuencontrado;
        }
        public int CantidadSecretarias()
        {
            return conexion.Secretaria.Count();
        }
    }
}
