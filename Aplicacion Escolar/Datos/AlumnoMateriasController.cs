using AplicacionEmpleados.Models;
using AplicacionEmpresas2.Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionEmpleados.Datos
{
    public class AlumnoMateriasController : Controller
    {
        EscolarDatos _contactoDatos = new EscolarDatos();
        public ActionResult AlumnosMaterias()
        {
            return View();
        }


        public IActionResult ObtenerMateriasHorariosMaestro()
        {

            var ListaHorarioMateriasHorario = _contactoDatos.ObtenerMateriasHorariosMaestro();
            return new JsonResult(ListaHorarioMateriasHorario);

        }


        public IActionResult GuardarAsignacionMaterias(List<AlumnosMateriasModel> ListaMateriasAlumno)
        {

            var ListaError = _contactoDatos.GuardarAsignacionMateriasAlumnos(ListaMateriasAlumno);
            return new JsonResult(ListaError);

        }


        public IActionResult ObtenerListadoAlumnosMateria(int IdAlumno)
        {
            var ListaListadoAlumnoMateria = _contactoDatos.ObtenerListadoAlumnosMateria(IdAlumno);
            return new JsonResult(ListaListadoAlumnoMateria);

        }

     


    }
}
