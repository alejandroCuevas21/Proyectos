using AplicacionEmpleados.Models;
using AplicacionEmpresas2.Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionEmpleados.Datos
{
    public class AlumnosController : Controller

    {
        EscolarDatos _contactoDatos = new EscolarDatos();
        // GET: AlumnosController
        public ActionResult Alumnos()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GuardarAlumno(AlumnosModel ObjAlumno)
        {
            AlumnosModel RespuestaGuarda;
            if (ObjAlumno.Matricula == 0)
            {

                RespuestaGuarda = _contactoDatos.GuardarAlumno(ObjAlumno);
            }
            else
            {
                RespuestaGuarda = _contactoDatos.ActualizaAlumno(ObjAlumno);
            }
            return new JsonResult(RespuestaGuarda);
        }



        public IActionResult ConsultarAlumnos()
        {

            var ListaAlumnos = _contactoDatos.ObtenerAlumnos();

            return new JsonResult(ListaAlumnos);

        }

    }
}
