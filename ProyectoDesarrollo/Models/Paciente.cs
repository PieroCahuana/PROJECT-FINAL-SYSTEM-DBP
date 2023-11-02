using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public string NomPaciente { get; set; } = null!;

    public string ApePaciente { get; set; } = null!;

    public string DniPaciente { get; set; } = null!;

    public DateTime NacPaciente { get; set; }

    public int? IdGenero { get; set; }

    public string TelPaciente { get; set; } = null!;

    public string UsuPaciente { get; set; } = null!;

    public string ContraPaciente { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Genero? IdGeneroNavigation { get; set; }

    public virtual ICollection<Administrador> Administradors { get; set; } = new List<Administrador>();

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<Secretarium> Secretaria { get; set; } = new List<Secretarium>();
}
