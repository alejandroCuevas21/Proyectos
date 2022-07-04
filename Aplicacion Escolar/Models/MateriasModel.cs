namespace AplicacionEmpresas2.Models
{
    public class MateriasModel
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdMaestro { get; set; }
        public int LimiteAlumno { get; set; }
        public int Estatus { get; set; }
        public string[] Horarios { get; set; }  
     
        public string DescEstatus { get; set; }
        public Boolean Error { get; set; }
        public string MsjError { get; set; }
    }
}
