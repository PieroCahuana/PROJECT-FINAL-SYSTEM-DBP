using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class Administrador
{
    public int IdAdministrador { get; set; }

    public string NomAdministrador { get; set; } = null!;

    public string ApeAdministrador { get; set; } = null!;

    public string DniAdministrador { get; set; } = null!;

    public string UsuAdministrador { get; set; } = null!;

    public string ContraAdministrador { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    public virtual ICollection<Secretarium> Secretaria { get; set; } = new List<Secretarium>();
}
