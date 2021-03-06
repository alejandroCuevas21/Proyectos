//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibreriaDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BdEscolarEntities : DbContext
    {
        public BdEscolarEntities()
            : base("name=BdEscolarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<AlumnosHorario> AlumnosHorario { get; set; }
        public virtual DbSet<GruposAlumnos> GruposAlumnos { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<HorarioGeneral> HorarioGeneral { get; set; }
        public virtual DbSet<Maestros> Maestros { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
        public virtual DbSet<Calificaciones> Calificaciones { get; set; }
    
        public virtual int ActualizarAlumnos(Nullable<int> matricula, string nombre, string apePaterno, string apeMaterno, string telefono, string email, Nullable<int> estatus)
        {
            var matriculaParameter = matricula.HasValue ?
                new ObjectParameter("Matricula", matricula) :
                new ObjectParameter("Matricula", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apePaternoParameter = apePaterno != null ?
                new ObjectParameter("ApePaterno", apePaterno) :
                new ObjectParameter("ApePaterno", typeof(string));
    
            var apeMaternoParameter = apeMaterno != null ?
                new ObjectParameter("ApeMaterno", apeMaterno) :
                new ObjectParameter("ApeMaterno", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarAlumnos", matriculaParameter, nombreParameter, apePaternoParameter, apeMaternoParameter, telefonoParameter, emailParameter, estatusParameter);
        }
    
        public virtual int ActualizarMaestros(Nullable<int> id, string nombre, string apePaterno, string apeMaterno, string telefono, string email, Nullable<int> estatus)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apePaternoParameter = apePaterno != null ?
                new ObjectParameter("ApePaterno", apePaterno) :
                new ObjectParameter("ApePaterno", typeof(string));
    
            var apeMaternoParameter = apeMaterno != null ?
                new ObjectParameter("ApeMaterno", apeMaterno) :
                new ObjectParameter("ApeMaterno", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarMaestros", idParameter, nombreParameter, apePaternoParameter, apeMaternoParameter, telefonoParameter, emailParameter, estatusParameter);
        }
    
        public virtual int AsignarMaestroMateria(Nullable<int> id, Nullable<int> idMaestro)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var idMaestroParameter = idMaestro.HasValue ?
                new ObjectParameter("IdMaestro", idMaestro) :
                new ObjectParameter("IdMaestro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AsignarMaestroMateria", idParameter, idMaestroParameter);
        }
    
        public virtual ObjectResult<BuscaCalificacionesAlumno_Result> BuscaCalificacionesAlumno(Nullable<int> matricula)
        {
            var matriculaParameter = matricula.HasValue ?
                new ObjectParameter("Matricula", matricula) :
                new ObjectParameter("Matricula", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscaCalificacionesAlumno_Result>("BuscaCalificacionesAlumno", matriculaParameter);
        }
    
        public virtual int InsertarAlumnos(string nombre, string apePaterno, string apeMaterno, string telefono, string email, Nullable<int> estatus)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apePaternoParameter = apePaterno != null ?
                new ObjectParameter("ApePaterno", apePaterno) :
                new ObjectParameter("ApePaterno", typeof(string));
    
            var apeMaternoParameter = apeMaterno != null ?
                new ObjectParameter("ApeMaterno", apeMaterno) :
                new ObjectParameter("ApeMaterno", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarAlumnos", nombreParameter, apePaternoParameter, apeMaternoParameter, telefonoParameter, emailParameter, estatusParameter);
        }
    
        public virtual int InsertarCalificaciones(Nullable<int> idMateria, Nullable<int> matriculaAlumno, Nullable<decimal> calificacion)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            var matriculaAlumnoParameter = matriculaAlumno.HasValue ?
                new ObjectParameter("MatriculaAlumno", matriculaAlumno) :
                new ObjectParameter("MatriculaAlumno", typeof(int));
    
            var calificacionParameter = calificacion.HasValue ?
                new ObjectParameter("Calificacion", calificacion) :
                new ObjectParameter("Calificacion", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarCalificaciones", idMateriaParameter, matriculaAlumnoParameter, calificacionParameter);
        }
    
        public virtual int InsertarHorarios(Nullable<int> idMateria, Nullable<int> idProfesor, Nullable<System.TimeSpan> horaInicio, Nullable<System.TimeSpan> horaFin, Nullable<int> estatus)
        {
            var idMateriaParameter = idMateria.HasValue ?
                new ObjectParameter("IdMateria", idMateria) :
                new ObjectParameter("IdMateria", typeof(int));
    
            var idProfesorParameter = idProfesor.HasValue ?
                new ObjectParameter("IdProfesor", idProfesor) :
                new ObjectParameter("IdProfesor", typeof(int));
    
            var horaInicioParameter = horaInicio.HasValue ?
                new ObjectParameter("HoraInicio", horaInicio) :
                new ObjectParameter("HoraInicio", typeof(System.TimeSpan));
    
            var horaFinParameter = horaFin.HasValue ?
                new ObjectParameter("HoraFin", horaFin) :
                new ObjectParameter("HoraFin", typeof(System.TimeSpan));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarHorarios", idMateriaParameter, idProfesorParameter, horaInicioParameter, horaFinParameter, estatusParameter);
        }
    
        public virtual int InsertarMaestro(string nombre, string apePaterno, string apeMaterno, string telefono, string email, Nullable<int> estatus)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apePaternoParameter = apePaterno != null ?
                new ObjectParameter("ApePaterno", apePaterno) :
                new ObjectParameter("ApePaterno", typeof(string));
    
            var apeMaternoParameter = apeMaterno != null ?
                new ObjectParameter("ApeMaterno", apeMaterno) :
                new ObjectParameter("ApeMaterno", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarMaestro", nombreParameter, apePaternoParameter, apeMaternoParameter, telefonoParameter, emailParameter, estatusParameter);
        }
    
        public virtual int InsertarMaterias(string nombre, string idMaestro, string limiteAlumno, Nullable<int> estatus)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var idMaestroParameter = idMaestro != null ?
                new ObjectParameter("IdMaestro", idMaestro) :
                new ObjectParameter("IdMaestro", typeof(string));
    
            var limiteAlumnoParameter = limiteAlumno != null ?
                new ObjectParameter("LimiteAlumno", limiteAlumno) :
                new ObjectParameter("LimiteAlumno", typeof(string));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarMaterias", nombreParameter, idMaestroParameter, limiteAlumnoParameter, estatusParameter);
        }
    
        public virtual ObjectResult<ObtenerAlumnos_Result> ObtenerAlumnos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerAlumnos_Result>("ObtenerAlumnos");
        }
    
        public virtual ObjectResult<ObtenerMaestros_Result> ObtenerMaestros()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerMaestros_Result>("ObtenerMaestros");
        }
    
        public virtual ObjectResult<ObtenerMaterias_Result> ObtenerMaterias()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerMaterias_Result>("ObtenerMaterias");
        }
    }
}
