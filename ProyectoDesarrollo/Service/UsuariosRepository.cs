using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ProyectoDesarrollo.Models;
using System.Numerics;
using System.Linq;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDesarrollo.Service
{
    public class UsuariosRepository : IUsuarios
    {
        private ClinicaC conexion = new ClinicaC();

        public string VerificarA(string usuA, string contraA)
        {
            var usuencontrado = conexion.Administradors.SingleOrDefault(tdoc => tdoc.UsuAdministrador == usuA);

            if (usuencontrado != null)
            {

                if (usuencontrado.ContraAdministrador == contraA)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "false";
            }
        }

        public string VerificarD(string usuD, string contraD)
        { 
                var usuencontrado = conexion.Doctors.SingleOrDefault(tdoc => tdoc.UsuDoctor == usuD);

                if (usuencontrado != null)
                {

                    if (usuencontrado.ContraDoctor == contraD)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }
                else
                {
                    return "false";
                }
        }

        public string VerificarP(string usuP, string contraP)
        {
            var usuencontrado = conexion.Pacientes.SingleOrDefault(tdoc => tdoc.UsuPaciente == usuP);

            if (usuencontrado != null)
            {

                if (usuencontrado.ContraPaciente == contraP)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "false";
            }
        }
        public string VerificarS(string usuS, string contraS)
        {
            var usuencontrado = conexion.Secretaria.SingleOrDefault(tdoc => tdoc.UsuSecretaria == usuS);

            if (usuencontrado != null)
            {

                if (usuencontrado.ContraSecretaria == contraS)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "false";
            }
        }
    }
}
