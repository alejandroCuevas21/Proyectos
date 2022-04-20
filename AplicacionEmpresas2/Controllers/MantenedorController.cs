using Microsoft.AspNetCore.Mvc;
using AplicacionEmpresas2.Datos;
using AplicacionEmpresas2.Models;
using System.ComponentModel.DataAnnotations;

namespace AplicacionEmpresas2.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _contactoDatos = new ContactoDatos();
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
        public IActionResult Guardar(ContactoModel oContacto)
        {
           
             
            if (ModelState.IsValid)
            {
                var respuesta = _contactoDatos.Guardar(oContacto);

                if (respuesta != 0)
                {
                    return RedirectToAction("Listar", new { respuesta });
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }


      

        [HttpPost]
        public IActionResult ModificarContacto(ContactoModel oContacto)
        {

            var respuesta = _contactoDatos.Modificar(oContacto);
            return RedirectToAction("Guardar");

        }


        [HttpPost]

        public ContactoModel ObtenerSoloLectura(int IdContacto)
        {

            return _contactoDatos.Listar(IdContacto);
            
        }


        public IActionResult ObtenerPaises()
        {
            var catalogoPais = _contactoDatos.ObtenerPaises();

            return new JsonResult(catalogoPais);

        }

        public IActionResult ObtenerProvincia()
        {
            var CatalogoProvincia = _contactoDatos.ObtenerProvincia();

            return new JsonResult(CatalogoProvincia);

        }

    }
}
