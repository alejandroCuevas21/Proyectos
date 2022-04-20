using System.ComponentModel.DataAnnotations;
namespace AplicacionEmpresas2.Models
{
    public class ContactoModel
    {
        public int IdContacto { get; set; }

        [Required(ErrorMessage = "El campo Nombre compañia es obligatorio")]
        public string NombreCompañia { get; set; }
        public string NombreCalle { get; set; }
        public string NoExterior { get; set; }
        public string NoPuerta { get; set; }
        public string Colonia { get; set; }
        public int Provincia { get; set; }
        public string DescProvincia { get; set; }
        public string Ciudad { get; set; }
        public int CP { get; set; }
        public int IdPais { get; set; }

        public string DescPais { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico {get;set;}
        public string SitioWeb { get; set; }
        public string RFC { get; set; }
        public string RegistroCompañia { get; set; }

        [Required(ErrorMessage = "El campo Moneda es obligatorio")]
        public string Moneda { get; set; }
        public string DescMoneda { get; set; }


    }
}
