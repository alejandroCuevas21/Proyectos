namespace AplicacionEmpleados.Models
{
    public class AlumnosMateriasModel
    {
    
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public string NomMateria { get; set; }
        public int IdMaestro { get; set; }
        public string NomMaestros { get; set; }
        public int MatriculaAlumno { get; set; }
        
        public int IdHora { get; set; }
        public string NomHora { get; set; } 
        public int LimiteAlumno { get; set; } 
        public int IdHorarioMaestro { get; set; }
        public Boolean Error { get; set; }
        public string MsjError { get; set; }

    }
}
