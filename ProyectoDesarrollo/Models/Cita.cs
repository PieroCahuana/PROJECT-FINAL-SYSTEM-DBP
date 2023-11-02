using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class Cita
{
    public int IdCitas { get; set; }

    public DateTime FechaCitas { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdEstados { get; set; }

    public int? IdDoctor { get; set; }

    public int? IdHorario { get; set; }

    public int? IdEspecialidad { get; set; }

    public virtual Doctor? IdDoctorNavigation { get; set; }

    public virtual Especialidad? IdEspecialidadNavigation { get; set; }

    public virtual Estado? IdEstadosNavigation { get; set; }

    public virtual Horario? IdHorarioNavigation { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }
}
