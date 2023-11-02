using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Service
{
    public interface IUsuarios
    {
        string VerificarD(string usuD, string contraD);
        string VerificarP(string usuP, string contraP);
        string VerificarA(string usuA, string contraA);
        string VerificarS(string usuS, string contraS);
    }
}
