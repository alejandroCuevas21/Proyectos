namespace AplicacionEmpleados.Models
{
    public class DetalleMateriaModel
    {

        public int IdDetalle { get; set; }
        public int IdHorarioMaestro { get; set; }
        public string Nombre { get; set; }
        public int LimiteAlumno { get; set; }
        public int IdHorario { get; set; }  
        public string Horario { get; set; }
        public int IdMaestro { get; set; }
        public string Maestro { get; set; }
        public int Estatus { get; set; }
        public string DescEstatus { get; set; } 
        public Boolean Error { get; set; }
        public string MsjError { get; set; }


  
    }
}
