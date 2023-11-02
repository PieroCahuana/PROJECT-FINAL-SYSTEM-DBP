using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string NomGenero { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
