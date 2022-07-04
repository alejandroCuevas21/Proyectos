using System.ComponentModel.DataAnnotations;
namespace AplicacionEmpresas2.Models
{
    public class MaestrosModel
    {
        public int Id { get; set; }

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
