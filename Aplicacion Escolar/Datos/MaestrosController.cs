using Microsoft.AspNetCore.Mvc;
using AplicacionEmpresas2.Datos;
using AplicacionEmpresas2.Models;
using System.ComponentModel.DataAnnotations;

namespace AplicacionEmpresas2.Controllers
{
    public class MaestrosController : Controller
    {
        EscolarDatos _contactoDatos = new EscolarDatos();
        public IActionResult Listar(int respuesta)
        {

            // La vista mostrara una lista de contactos

           ViewData["Contacto"] = respuesta;
            return View();
      

        }
     
        public IActionResult Guardar()
        {
          
            //Metodo solo devuelve la vista
            return View();
        }

       public IActionResult Modificar(int IdContacto)
        {

            ViewData["Contacto"] = IdContacto;
            return View();

        }

        [HttpPost]
        public IActionResult RedirijeModificar(int IdContacto)
        {

            return RedirectToAction("Modificar", new { IdContacto });

        }


        public IActionResult GuardarMaestro(MaestrosModel ObjMaestro)
        {
            MaestrosModel RespuestaGuarda;
            if (ObjMaestro.Id == 0) { 
            
              RespuestaGuarda = _contactoDatos.GuardarMaestro(ObjMaestro);
            }
            else
            {
               RespuestaGuarda = _contactoDatos.ActualizaMaestro(ObjMaestro);
            }
            return new JsonResult(RespuestaGuarda);

        }

        

         public IActionResult ConsultarMaterias(string IdMaterias)
         {

            var ListaMaterias = _contactoDatos.ObtenerMateriasDetalle(IdMaterias);

            return new JsonResult(ListaMaterias);

         }


        public IActionResult ConsultarMaestros()
        {

            var ListaMaestros = _contactoDatos.ObtenerMaestros();

            return new JsonResult(ListaMaestros);
           
        }

    }
}
