using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDesarrollo.Models;

public partial class ClinicaC : DbContext
{
    public ClinicaC()
    {
    }

    public ClinicaC(DbContextOptions<ClinicaC> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Secretarium> Secretaria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-5TTFTD8\\SQLEXPRESS02;Initial Catalog=PROYECTO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK__ADMINIST__0FE822AA7CB4BBD5");

            entity.ToTable("ADMINISTRADOR");

            entity.HasIndex(e => e.DniAdministrador, "UQ__ADMINIST__0F874A882AFF34F2").IsUnique();

            entity.HasIndex(e => e.UsuAdministrador, "UQ__ADMINIST__C3A5B482B2D8F82C").IsUnique();

            entity.Property(e => e.IdAdministrador).HasColumnName("id_administrador");
            entity.Property(e => e.ApeAdministrador)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ape_administrador");
            entity.Property(e => e.ContraAdministrador)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contra_administrador");
            entity.Property(e => e.DniAdministrador)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("dni_administrador");
            entity.Property(e => e.NomAdministrador)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nom_administrador");
            entity.Property(e => e.UsuAdministrador)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usu_administrador");

            entity.HasMany(d => d.Doctors).WithMany(p => p.Administradors)
                .UsingEntity<Dictionary<string, object>>(
                    "AdministradorDoctor",
                    r => r.HasOne<Doctor>().WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ADMINISTR__docto__5AEE82B9"),
                    l => l.HasOne<Administrador>().WithMany()
                        .HasForeignKey("AdministradorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ADMINISTR__admin__59FA5E80"),
                    j =>
                    {
                        j.HasKey("AdministradorId", "DoctorId").HasName("PK__ADMINIST__D71030799C727B6F");
                        j.ToTable("ADMINISTRADOR_DOCTOR");
                        j.IndexerProperty<int>("AdministradorId").HasColumnName("administrador_id");
                        j.IndexerProperty<int>("DoctorId").HasColumnName("doctor_id");
                    });

            entity.HasMany(d => d.Pacientes).WithMany(p => p.Administradors)
                .UsingEntity<Dictionary<string, object>>(
                    "AdministradorPaciente",
                    r => r.HasOne<Paciente>().WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ADMINISTR__pacie__5CD6CB2B"),
                    l => l.HasOne<Administrador>().WithMany()
                        .HasForeignKey("AdministradorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ADMINISTR__admin__5BE2A6F2"),
                    j =>
                    {
                        j.HasKey("AdministradorId", "PacienteId").HasName("PK__ADMINIST__FC464C4A9EB38E68");
                        j.ToTable("ADMINISTRADOR_PACIENTE");
                        j.IndexerProperty<int>("AdministradorId").HasColumnName("administrador_id");
                        j.IndexerProperty<int>("PacienteId").HasColumnName("paciente_id");
                    });

            entity.HasMany(d => d.Secretaria).WithMany(p => p.Administradors)
                .UsingEntity<Dictionary<string, object>>(
                    "AdministradorSecretarium",
                    r => r.HasOne<Secretarium>().WithMany()
                        .HasForeignKey("SecretariaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ADMINISTR__secre__5EBF139D"),
                    l => l.HasOne<Administrador>().WithMany()
                        .HasForeignKey("AdministradorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ADMINISTR__admin__5DCAEF64"),
                    j =>
                    {
                        j.HasKey("AdministradorId", "SecretariaId").HasName("PK__ADMINIST__93B768143A572499");
                        j.ToTable("ADMINISTRADOR_SECRETARIA");
                        j.IndexerProperty<int>("AdministradorId").HasColumnName("administrador_id");
                        j.IndexerProperty<int>("SecretariaId").HasColumnName("secretaria_id");
                    });
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCitas).HasName("PK__CITAS__B0CEEC7CE832F35B");

            entity.ToTable("CITAS");

            entity.Property(e => e.IdCitas).HasColumnName("id_citas");
            entity.Property(e => e.FechaCitas)
                .HasColumnType("date")
                .HasColumnName("fecha_citas");
            entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");
            entity.Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");
            entity.Property(e => e.IdEstados).HasColumnName("id_estados");
            entity.Property(e => e.IdHorario).HasColumnName("id_horario");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdDoctor)
                .HasConstraintName("FK__CITAS__id_doctor__5FB337D6");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("FK__CITAS__id_especi__60A75C0F");

            entity.HasOne(d => d.IdEstadosNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdEstados)
                .HasConstraintName("FK__CITAS__id_estado__619B8048");

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdHorario)
                .HasConstraintName("FK__CITAS__id_horari__628FA481");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("FK__CITAS__id_pacien__6383C8BA");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PK__DOCTOR__34D8A305527556C9");

            entity.ToTable("DOCTOR");

            entity.HasIndex(e => e.DniDoctor, "UQ__DOCTOR__9F459A616739CABA").IsUnique();

            entity.HasIndex(e => e.UsuDoctor, "UQ__DOCTOR__EC3905E47CB02EF6").IsUnique();

            entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");
            entity.Property(e => e.ApeDoctor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ape_doctor");
            entity.Property(e => e.ContraDoctor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contra_doctor");
            entity.Property(e => e.DniDoctor)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("dni_doctor");
            entity.Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");
            entity.Property(e => e.NomDoctor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nom_doctor");
            entity.Property(e => e.TelDoctor)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tel_doctor");
            entity.Property(e => e.UsuDoctor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usu_doctor");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("FK__DOCTOR__id_espec__6477ECF3");

            entity.HasMany(d => d.Pacientes).WithMany(p => p.Doctors)
                .UsingEntity<Dictionary<string, object>>(
                    "DoctorPaciente",
                    r => r.HasOne<Paciente>().WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__DOCTOR_PA__pacie__66603565"),
                    l => l.HasOne<Doctor>().WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__DOCTOR_PA__docto__656C112C"),
                    j =>
                    {
                        j.HasKey("DoctorId", "PacienteId").HasName("PK__DOCTOR_P__87F6DA01C5EA4E82");
                        j.ToTable("DOCTOR_PACIENTE");
                        j.IndexerProperty<int>("DoctorId").HasColumnName("doctor_id");
                        j.IndexerProperty<int>("PacienteId").HasColumnName("paciente_id");
                    });
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PK__ESPECIAL__C1D137634643BF0B");

            entity.ToTable("ESPECIALIDAD");

            entity.HasIndex(e => e.NomEspecialidad, "IX_ESPECIALIDAD").IsUnique();

            entity.Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");
            entity.Property(e => e.NomEspecialidad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nom_especialidad");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstados).HasName("PK__ESTADOS__3F2F290DBDE67E5F");

            entity.ToTable("ESTADOS");

            entity.Property(e => e.IdEstados).HasColumnName("id_estados");
            entity.Property(e => e.NomEstados)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nom_estados");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__GENERO__99A8E4F976321141");

            entity.ToTable("GENERO");

            entity.Property(e => e.IdGenero).HasColumnName("id_genero");
            entity.Property(e => e.NomGenero)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nom_genero");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("PK__HORARIO__C5836D698E441AFE");

            entity.ToTable("HORARIO");

            entity.Property(e => e.IdHorario).HasColumnName("id_horario");
            entity.Property(e => e.Hora).HasColumnName("hora");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__PACIENTE__2C2C72BBC47FE25C");

            entity.ToTable("PACIENTE");

            entity.HasIndex(e => e.DniPaciente, "UQ__PACIENTE__2FCD317A9D6BF15A").IsUnique();

            entity.HasIndex(e => e.UsuPaciente, "UQ__PACIENTE__8E90F7A7256B3069").IsUnique();

            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.ApePaciente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ape_paciente");
            entity.Property(e => e.ContraPaciente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contra_paciente");
            entity.Property(e => e.DniPaciente)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("dni_paciente");
            entity.Property(e => e.IdGenero).HasColumnName("id_genero");
            entity.Property(e => e.NacPaciente)
                .HasColumnType("date")
                .HasColumnName("nac_paciente");
            entity.Property(e => e.NomPaciente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nom_paciente");
            entity.Property(e => e.TelPaciente)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tel_paciente");
            entity.Property(e => e.UsuPaciente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usu_paciente");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("FK__PACIENTE__id_gen__6754599E");
        });

        modelBuilder.Entity<Secretarium>(entity =>
        {
            entity.HasKey(e => e.IdSecretaria).HasName("PK__SECRETAR__9029585527726553");

            entity.ToTable("SECRETARIA");

            entity.HasIndex(e => e.DniSecretaria, "UQ__SECRETAR__4FA547178CE27D6C").IsUnique();

            entity.HasIndex(e => e.UsuSecretaria, "UQ__SECRETAR__5CE3AEE9031C85A7").IsUnique();

            entity.Property(e => e.IdSecretaria).HasColumnName("id_secretaria");
            entity.Property(e => e.NomSecretaria)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nom_secretaria");
            entity.Property(e => e.ApeSecretaria)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ape_secretaria");
            entity.Property(e => e.ContraSecretaria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("contra_secretaria");
            entity.Property(e => e.DniSecretaria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dni_secretaria");
            entity.Property(e => e.TelSecretaria)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tel_secretaria");
            entity.Property(e => e.UsuSecretaria)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("usu_secretaria");

            entity.HasMany(d => d.Doctors).WithMany(p => p.Secretaria)
                .UsingEntity<Dictionary<string, object>>(
                    "SecretariaDoctor",
                    r => r.HasOne<Doctor>().WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__SECRETARI__docto__68487DD7"),
                    l => l.HasOne<Secretarium>().WithMany()
                        .HasForeignKey("SecretariaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__SECRETARI__secre__693CA210"),
                    j =>
                    {
                        j.HasKey("SecretariaId", "DoctorId").HasName("PK__SECRETAR__E6D520E63CA23494");
                        j.ToTable("SECRETARIA_DOCTOR");
                        j.IndexerProperty<int>("SecretariaId").HasColumnName("secretaria_id");
                        j.IndexerProperty<int>("DoctorId").HasColumnName("doctor_id");
                    });

            entity.HasMany(d => d.Pacientes).WithMany(p => p.Secretaria)
                .UsingEntity<Dictionary<string, object>>(
                    "SecretariaPaciente",
                    r => r.HasOne<Paciente>().WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__SECRETARI__pacie__6A30C649"),
                    l => l.HasOne<Secretarium>().WithMany()
                        .HasForeignKey("SecretariaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__SECRETARI__secre__6B24EA82"),
                    j =>
                    {
                        j.HasKey("SecretariaId", "PacienteId").HasName("PK__SECRETAR__CD835CD5A7A9B6D2");
                        j.ToTable("SECRETARIA_PACIENTE");
                        j.IndexerProperty<int>("SecretariaId").HasColumnName("secretaria_id");
                        j.IndexerProperty<int>("PacienteId").HasColumnName("paciente_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
