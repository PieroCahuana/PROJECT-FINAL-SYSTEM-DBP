using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class Estado
{
    public int IdEstados { get; set; }

    public string NomEstados { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
