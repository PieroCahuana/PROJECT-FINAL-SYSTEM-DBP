using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class Especialidad
{
    public int IdEspecialidad { get; set; }

    public string NomEspecialidad { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
