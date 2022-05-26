using System.ComponentModel.DataAnnotations;
namespace AplicacionEmpresas2.Models
{
    public class EmpleadoModel
    {
        public int Empleado_Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre compañia es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo apellido paterno es obligatorio")]
        public string Apellido_Paterno { get; set; }
        [Required(ErrorMessage = "El campo apellido materno es obligatorio")]
        public string Apellido_Materno { get; set; }
        [Required(ErrorMessage = "El campo fecha nacimiento es obligatorio")]
        public DateTime Fecha_Nacimiento { get; set; }

        [Required(ErrorMessage = "El campo estatus es obligatorio")]
        public int Estatus_Id { get; set; }
        public string DescEstatus { get; set; }
          public Boolean Error { get; set; }
        public string MsjError { get; set; }

    }
}
