using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class Doctor
{
    public int IdDoctor { get; set; }

    public string NomDoctor { get; set; } = null!;

    public string ApeDoctor { get; set; } = null!;

    public string DniDoctor { get; set; } = null!;

    public string TelDoctor { get; set; } = null!;

    public string UsuDoctor { get; set; } = null!;

    public string ContraDoctor { get; set; } = null!;

    public int? IdEspecialidad { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Especialidad? IdEspecialidadNavigation { get; set; }

    public virtual ICollection<Administrador> Administradors { get; set; } = new List<Administrador>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public virtual ICollection<Secretarium> Secretaria { get; set; } = new List<Secretarium>();
}
