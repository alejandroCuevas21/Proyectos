namespace AplicacionEmpleados.Models
{
    public class HorarioModel
    {
        public int Id { get; set; }
        public int IdMateria {get;set;}
        public int IdProfesor { get;set;}
        public DateTime HoraInicio {get;set;}
        public DateTime HoraFin { get;set;}
        public int Estatus {get;set;}

    }
}
