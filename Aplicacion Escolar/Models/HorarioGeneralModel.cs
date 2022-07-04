namespace AplicacionEmpleados.Models
{
    public class HorarioGeneralModel
    {
        public int Id { get; set; } 
        public string Hora { get; set; }
        public int Estatus { get; set; }
        public string DescEstatus { get; set; } 
        public Boolean Error { get; set; }
        public string MsjError { get; set; }

    }
}
