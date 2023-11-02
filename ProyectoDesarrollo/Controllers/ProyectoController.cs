using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoDesarrollo.Models;
using ProyectoDesarrollo.Service;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Numerics;

namespace ProyectoDesarrollo.Controllers
{
    public class ProyectoController : Controller
    {
        private readonly IUsuarios _IUsuarios;
        private readonly IDoctor _IDoctor;
        private readonly ISecretaria _ISecretaria;
        private readonly IAdministrador _IAdministrador;
        private readonly IPaciente _IPaciente;
        private readonly IEspecialidad _IEspecialidad;
        private readonly IEstados _IEstados;
        private readonly IHorario _Horario;
        private readonly ICita _ICita;
        private readonly IGenero _IGenero;
        public ProyectoController(IUsuarios usu, IDoctor doc, ISecretaria sec, IAdministrador admin, IPaciente pac, IEspecialidad especialidad, IEstados estados, IHorario horario, ICita cita, IGenero genero)
        {
            _IUsuarios = usu;
            _IDoctor = doc;
            _ISecretaria = sec;
            _IAdministrador = admin;
            _IPaciente = pac;
            _IEspecialidad = especialidad;
            _IEstados = estados;
            _Horario = horario;
            _ICita = cita;
            _IGenero = genero;
        }

        public IActionResult Inicio()
        {
            return View();
        }
        /*Iniciar sesion - Secretaria*/
        public IActionResult InSecretaria(string usuS, string contraS)
        {
            var resultado = _IUsuarios.VerificarS(usuS, contraS);
            if (resultado == "true")
            {
                return Redirect($"/Proyecto/PrincipalSecretaria?usuS={usuS}#Inicios");
            }
            else
            {
                return View();
            }
        }
        /*Iniciar sesion - Doctor*/
        public IActionResult InDoctor(string usuD, string contraD)
        {
            var resultado = _IUsuarios.VerificarD(usuD, contraD);
            if (resultado == "true")
            {
                return Redirect($"/Proyecto/PrincipalDoctor?usuD={usuD}#Inicios");
            }
            else
            {
                return View();
            }
        }
        /*Iniciar sesion - Paciente*/
        public IActionResult InPaciente(string usuP, string contraP)
        {
            var resultado = _IUsuarios.VerificarP(usuP, contraP);
            if (resultado == "true")
            {
                return Redirect($"/Proyecto/PrincipalPaciente?usuP={usuP}#Inicios");
            }
            else
            {
                return View();
            }
        }
        /*Iniciar sesion - Administrador*/
        public IActionResult InAdministrador(string usuA, string contraA)
        {
            var resultado = _IUsuarios.VerificarA(usuA, contraA);
            if (resultado == "true")
            {
                return Redirect($"/Proyecto/PrincipalAdministrador?usuA={usuA}#Inicios");
            }
            else
            {
                return View();
            }
        }
        /*Pagina principal - Secretaria*/
        public IActionResult PrincipalSecretaria(string usuS)
        {
            if (string.IsNullOrEmpty(usuS))
            {
                usuS = TempData["usuS"] as string;
            }
            TempData["usuS"] = usuS;
            ViewBag.perfil = _ISecretaria.PerfilS(usuS);
            ViewBag.especialidad = _IEspecialidad.GetDistinctEspecialidad();
            ViewBag.genero = _IPaciente.GetDistinctGeneros();
            ViewBag.doctor = _IDoctor.GetDoctors();
            ViewBag.pacientes = _IPaciente.GetPacientes();
            ViewBag.citas = _ICita.GetCitas();
            ViewBag.estados = _IEstados.GetDistinctEstado();
            ViewBag.horario = _Horario.GetHorarios();
            ViewBag.especDoc = _IEspecialidad.GetEspecialidadDoc();
            ViewBag.contadorDoctor = _IDoctor.CantidadDoctores();
            ViewBag.contadorPaciente = _IPaciente.CantidadPacientes();
            ViewBag.contadorCitas = _ICita.CantidadCitas();
            ViewBag.contadorEspecilidades = _IEspecialidad.cantidadEspecilidadesporDoctor();
            return View();
        }

        /*Pagina principal - Doctor*/
        public IActionResult PrincipalDoctor(string usuD)
        {
            if (string.IsNullOrEmpty(usuD))
            {
                usuD = TempData["usuD"] as string;
            }
            TempData["usuD"] = usuD;
            ViewBag.perfil = _IDoctor.PerfilD(usuD);
            ViewBag.genero = _IPaciente.GetDistinctGeneros();
            ViewBag.doctor = _IDoctor.GetDoctors();
            ViewBag.pacientes = _IPaciente.GetPacientes();
            ViewBag.cita = _ICita.GetCitasporDoctor(usuD);
            ViewBag.contadorcitas = _ICita.CantidadCitasporDoctores(usuD);
            ViewBag.contadorPaciente = _IPaciente.CantidadPacientes();
            return View();

        }
        /*Pagina principal - Paciente*/
        public IActionResult PrincipalPaciente(string usuP)
        {
            if (string.IsNullOrEmpty(usuP))
            {
                usuP = TempData["usuP"] as string;
            }
            TempData["usuP"] = usuP;
            ViewBag.perfil = _IPaciente.PerfilP(usuP);
            ViewBag.cita = _ICita.GetCitasByPaciente(usuP);
            ViewBag.contadorcitas = _ICita.CantidadCitasporPacientes(usuP);
            return View();
        }
        /*Pagina principal - Administrador*/
        public IActionResult PrincipalAdministrador(string usuA)
        {
            if (string.IsNullOrEmpty(usuA))
            {
                usuA = TempData["usuA"] as string;
            }
            TempData["usuA"] = usuA;
            ViewBag.perfil = _IAdministrador.PerfilA(usuA);
            ViewBag.especialidad = _IEspecialidad.GetDistinctEspecialidad();
            ViewBag.genero = _IPaciente.GetDistinctGeneros();
            ViewBag.secretarias = _ISecretaria.GetSecretarias();
            ViewBag.doctor = _IDoctor.GetDoctors();
            ViewBag.pacientes = _IPaciente.GetPacientes();
            ViewBag.contadorDoctor = _IDoctor.CantidadDoctores();
            ViewBag.contadorPaciente = _IPaciente.CantidadPacientes();
            ViewBag.contadorSecretaria = _ISecretaria.CantidadSecretarias();
            ViewBag.contadorEspecilidades = _IEspecialidad.cantidadEspecilidadesporDoctor();
            return View();
        }
        /*Eliminar Paciente - A, D Y S*/
        public IActionResult EliminarpacienteA(int id)
        {
            _IPaciente.RemoveP(id);
            return Redirect("/Proyecto/PrincipalAdministrador#Pacientes");
        }
        public IActionResult EliminarpacienteD(int id)
        {
            _IPaciente.RemoveP(id);
            return Redirect("/Proyecto/PrincipalDoctor#Pacientes");
        }
        public IActionResult EliminarpacienteS(int id)
        {
            _IPaciente.RemoveP(id);
            return Redirect("/Proyecto/PrincipalSecretaria#Pacientes");
        }
        /*Eliminar doctor A y S*/
        public IActionResult EliminardoctorA(int id)
        {
            _IDoctor.RemoveD(id);
            return Redirect("/Proyecto/PrincipalAdministrador#Doctores");
        }
        public IActionResult EliminardoctorS(int id)
        {
            _IDoctor.RemoveD(id);
            return Redirect("/Proyecto/PrincipalSecretaria#Doctores");
        }
        /*Eliminar secretaria*/

        public IActionResult Eliminarsecretaria(int id)
        {
            _ISecretaria.RemoveS(id);
            return Redirect("/Proyecto/PrincipalAdministrador#Secretarias");
        }
        public IActionResult EliminarCitaD(int id)
        {
            _ICita.RemoveC(id);
            return Redirect("/Proyecto/PrincipalDoctor#Citas");
        }
        public IActionResult EliminarCitaS(int id)
        {
            _ICita.RemoveC(id);
            return Redirect("/Proyecto/PrincipalSecretaria#Reservaciones");
        }
        public IActionResult EliminarCitaP(int id)
        {
            _ICita.RemoveC(id);
            return Redirect("/Proyecto/PrincipalPaciente#ReservarCitas");
        }
        /*Editar secretaria con id*/
        public IActionResult Editarsecretaria(int id)
        {
            return View(_ISecretaria.SecretariaId(id));
        }
        /*Editar secretaria*/
        public IActionResult ModificarSecretaria(Secretarium secretaria)
        {
            _ISecretaria.editDetails(secretaria);
            return Redirect("/Proyecto/PrincipalAdministrador#Secretarias");
        }
        /*Editar doctor con id*/
        public IActionResult Editardoctor(int id)
        {
            ViewBag.especialidad = _IEspecialidad.GetDistinctEspecialidad();
            return View(_IDoctor.DoctorId(id));
        }
        public IActionResult EditardoctorS(int id)
        {
            ViewBag.especialidad = _IEspecialidad.GetDistinctEspecialidad();
            return View(_IDoctor.DoctorId(id));
        }
        /*Editar doctor para administrador*/
        public IActionResult ModificarDoctor(Doctor doc)
        {
            _IDoctor.editDetails(doc);
            return Redirect("/Proyecto/PrincipalAdministrador#Doctores");
        }
        /*Editar doctor para secretaria*/
        public IActionResult ModificarDoctorS(Doctor doc)
        {
            _IDoctor.editDetails(doc);
            return Redirect("/Proyecto/PrincipalSecretaria#Doctores");
        }

        /*Editar paciente con id*/
        public IActionResult EditarpacienteS(int id)
        {
            ViewBag.genero = _IPaciente.GetDistinctGeneros();
            return View(_IPaciente.PacienteId(id));
        }
        public IActionResult EditarpacienteA(int id)
        {
            ViewBag.genero = _IPaciente.GetDistinctGeneros();
            return View(_IPaciente.PacienteId(id));
        }
        public IActionResult EditarpacienteD(int id)
        {
            ViewBag.genero = _IPaciente.GetDistinctGeneros();
            return View(_IPaciente.PacienteId(id));
        }
        /*Editar paciente para secretaria*/
        public IActionResult ModificarPacienteS(Paciente paciente)
        {
            _IPaciente.editDetails(paciente);
            return Redirect("/Proyecto/PrincipalSecretaria#Pacientes");
        }
        /*Editar paciente para administrador*/
        public IActionResult ModificarPacienteA(Paciente paciente)
        {
            _IPaciente.editDetails(paciente);
            return Redirect("/Proyecto/PrincipalAdministrador#Pacientes");
        }
        /*Editar paciente para doctor*/
        public IActionResult ModificarPacienteD(Paciente paciente)
        {
            _IPaciente.editDetails(paciente);
            return Redirect("/Proyecto/PrincipalDoctor#Pacientes");
        }

        /*Crear pacientes - doctor*/
        public IActionResult GrabarpacienteD(Paciente paciente)
        {
            string usuD = TempData["usuD"] as string;
            _IPaciente.addP(paciente);
            TempData["usuD"] = usuD;
            return Redirect($"/Proyecto/PrincipalDoctor?usuD={usuD}#Pacientes");
        }
        /*Crear pacientes - secretaria*/
        public IActionResult GrabarpacienteS(Paciente paciente)
        {
            string usuS = TempData["usuS"] as string;
            _IPaciente.addP(paciente);
            return Redirect($"/Proyecto/PrincipalSecretaria?usuS={usuS}#Pacientes");
        }
        /*Crear pacientes - admin*/
        public IActionResult GrabarpacienteA(Paciente paciente)
        {
            string usuA = TempData["usuA"] as string;
            _IPaciente.addP(paciente);
            return Redirect($"/Proyecto/PrincipalAdministrador?usuA={usuA}#Pacientes");
        }
        /*Crear doctores - secretaria*/
        public IActionResult GrabardoctorS(Doctor doctor)
        {
            string usuS = TempData["usuS"] as string;
            _IDoctor.addD(doctor);
            return Redirect($"/Proyecto/PrincipalSecretaria?usuS={usuS}#Doctores");
        }
        /*Crear doctores - admin*/
        public IActionResult GrabardoctorA(Doctor doctor)
        {
            string usuA = TempData["usuA"] as string;
            _IDoctor.addD(doctor);
            return Redirect($"/Proyecto/PrincipalAdministrador?usuA={usuA}#Doctores");
        }
        /*Crear secretarias - admin*/
        public IActionResult Grabarsecretaria(Secretarium secretaria)
        {
            string usuA = TempData["usuA"] as string;
            _ISecretaria.addS(secretaria);
            return Redirect($"/Proyecto/PrincipalAdministrador?usuA={usuA}#Secretarias");
        }
        /*Crear consultorios - admin*/
        public IActionResult Grabarespecialidad(string nombreEspecialidad)
        {
            string usuA = TempData["usuA"] as string;
            Especialidad especialidad = new Especialidad { NomEspecialidad = nombreEspecialidad };
            _IEspecialidad.addE(especialidad);
            return Redirect($"/Proyecto/PrincipalAdministrador?usuA={usuA}#Consultorios");
        }
        /*Crear consultorios - Secretaria*/
        public IActionResult GrabarespecialidadS(string nombreEspecialidad)
        {
            string usuS = TempData["usuS"] as string;
            Especialidad especialidad = new Especialidad { NomEspecialidad = nombreEspecialidad };
            _IEspecialidad.addE(especialidad);
            return Redirect($"/Proyecto/PrincipalSecretaria?usuS={usuS}#Consultorios");
        }
        public IActionResult GrabarCita(Cita cita)
        {
            string usuS = TempData["usuS"] as string;
            _ICita.addC(cita);
            return Redirect($"/Proyecto/PrincipalSecretaria?usuS={usuS}#Reservaciones");
        }
        /*Editar secretaria perfil*/
        public IActionResult EditarSecretariaP(int id)
        {
            return View(_ISecretaria.SecretariaId(id));
        }
        public IActionResult ModificarSecretariaP(Secretarium secretaria)
        {
            _ISecretaria.editDetails(secretaria);
            return Redirect("/Proyecto/PrincipalSecretaria#Perfil");
        }
        /*Editar Doctor perfil*/
        public IActionResult EditarDoctorP(int id)
        {
            ViewBag.especialidad = _IEspecialidad.GetDistinctEspecialidad();
            return View(_IDoctor.DoctorId(id));
        }
        public IActionResult ModificarDoctorP(Doctor doctor)
        {
            _IDoctor.editDetails(doctor);
            return Redirect("/Proyecto/PrincipalDoctor#Perfil");
        }
        /*Editar Paciente perfil*/
        public IActionResult EditarPacienteP(int id)
        {
            ViewBag.genero = _IPaciente.GetDistinctGeneros();
            return View(_IPaciente.PacienteId(id));
        }
        public IActionResult ModificarPacienteP(Paciente paciente)
        {
            _IPaciente.editDetails(paciente);
            return Redirect("/Proyecto/PrincipalPaciente#Perfil");
        }
        /*Editar Admin perfil*/
        public IActionResult EditarAdminP(int id)
        {
            return View(_IAdministrador.AdminId(id));
        }
        /*Editar secretaria*/
        public IActionResult ModificarAdminP(Administrador admin)
        {
            _IAdministrador.editDetails(admin);
            return Redirect("/Proyecto/PrincipalAdministrador#Perfil");
        }
        /*Editar Cita - secretaria*/
        public IActionResult EditarCitaS(int id)
        {
            ViewBag.genero = _IPaciente.GetDistinctGeneros();
            ViewBag.doctor = _IDoctor.GetDoctors();
            ViewBag.pacientes = _IPaciente.GetPacientes();
            ViewBag.citas = _ICita.GetCitas();
            ViewBag.estados = _IEstados.GetDistinctEstado();
            ViewBag.horario = _Horario.GetHorarios();
            ViewBag.especDoc = _IEspecialidad.GetEspecialidadDoc();
            return View(_ICita.CitaId(id));
        }
        public IActionResult ModificarCitaS(Cita cita)
        {
            _ICita.editDetails(cita);
            return Redirect("/Proyecto/PrincipalSecretaria#Reservaciones");
        }
    }
}
