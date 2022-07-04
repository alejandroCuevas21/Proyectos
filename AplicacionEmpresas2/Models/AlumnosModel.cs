namespace AplicacionEmpleados.Models
{
    public class AlumnosModel
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Estatus { get; set; }
        public string DescEstatus { get; set; }
        public Boolean Error { get; set; }
        public string MsjError { get; set; }

    }
}
