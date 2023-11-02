using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public TimeSpan? Hora { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
