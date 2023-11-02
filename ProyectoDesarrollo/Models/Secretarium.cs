using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class Secretarium
{
    public int IdSecretaria { get; set; }

    public string NomSecretaria { get; set; } = null!;

    public string ApeSecretaria { get; set; } = null!;

    public string DniSecretaria { get; set; } = null!;

    public string TelSecretaria { get; set; } = null!;

    public string UsuSecretaria { get; set; } = null!;

    public string ContraSecretaria { get; set; } = null!;

    public virtual ICollection<Administrador> Administradors { get; set; } = new List<Administrador>();

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
