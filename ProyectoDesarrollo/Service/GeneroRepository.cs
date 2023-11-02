using Microsoft.EntityFrameworkCore;
using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public class GeneroRepository : IGenero
    {
        private ClinicaC conexion = new ClinicaC();
        public void addG(Genero genero)
        {
            conexion.Generos.Add(genero);
            conexion.SaveChanges();
        }
        public IEnumerable<Genero> GetGeneros()
        {
            return conexion.Generos.ToList();
        }
        public void RemoveG(int id)
        {
            var encontrado = (from tdoc in conexion.Generos
                              where tdoc.IdGenero == id
                              select tdoc).Single();
            conexion.Generos.Remove(encontrado);
            conexion.SaveChanges();
        }
        public Genero GenerosId(int id)
        {

            var obj = (from tsec in conexion.Generos
                       where tsec.IdGenero == id
                       select tsec).Single();
            return obj;

        }
        public void editDetails(Genero obj)
        {
            var objAModificar = (from tsec in conexion.Generos
                                 where tsec.IdGenero == obj.IdGenero
                                 select tsec).FirstOrDefault();
            objAModificar.NomGenero = obj.NomGenero;
            conexion.SaveChanges();
        }
    }
}
