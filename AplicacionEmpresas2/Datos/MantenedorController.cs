using Microsoft.AspNetCore.Mvc;
using AplicacionEmpresas2.Datos;
using AplicacionEmpresas2.Models;
using System.ComponentModel.DataAnnotations;

namespace AplicacionEmpresas2.Controllers
{
    public class MantenedorController : Controller
    {
        EmpleadosDatos _contactoDatos = new EmpleadosDatos();
        public IActionResult Listar(int respuesta)
        {

            // La vista mostrara una lista de contactos

           ViewData["Contacto"] = respuesta;
            return View();
            //return View(oLista);

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

        [HttpPost]
        public IActionResult Guardar(EmpleadoModel oContacto)
        {


            if (ModelState.IsValid)
            {
                var respuesta = _contactoDatos.Guardar(oContacto);

                return View();        
            }
            else
            {
                return View();
            }
        }



        public IActionResult GuardarEmpleado(EmpleadoModel Empleado)
        {
            EmpleadoModel RespuestaGuarda;
            if (Empleado.Empleado_Id == 0) { 
            
              RespuestaGuarda = _contactoDatos.Guardar(Empleado);
            }
            else
            {
               RespuestaGuarda = _contactoDatos.ActualizaEmpleado(Empleado);
            }
            return new JsonResult(RespuestaGuarda);

        }
        public IActionResult ObtenerEstatus()
        {
            var CatalogoEstatus = _contactoDatos.ObtenerEstatus();

            return new JsonResult(CatalogoEstatus);

        }


       public IActionResult ConsultarEmpleados()
        {

            var ListaEmpleados = _contactoDatos.ObtenerEmpleados();

            return new JsonResult(ListaEmpleados);

        }

   

    }
}
