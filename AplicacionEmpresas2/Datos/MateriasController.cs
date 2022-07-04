using AplicacionEmpleados.Models;
using AplicacionEmpresas2.Datos;
using AplicacionEmpresas2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionEmpleados.Datos
{
    public class MateriasController : Controller
    {
        // GET: MateriasController
        EscolarDatos _contactoDatos = new EscolarDatos();
        public ActionResult Materias()
        {
            return View();
        }


        public IActionResult ConsultarHorarios()
        {

            var ListaHorarios = _contactoDatos.ObtenerHorarioGeneral();

            return new JsonResult(ListaHorarios);

        }

        public IActionResult ObtenerMaterias()
        {

            var ListaMaterias = _contactoDatos.ObtenerMaterias();

            return new JsonResult(ListaMaterias);

        }

        public IActionResult ObtenerDetalleMateria(string Materias)
        {
            var ListaDetalleMateria = _contactoDatos.ObtenerMateriasDetalle(Materias);

            return new JsonResult(ListaDetalleMateria);
        }

        [HttpPost]

        public IActionResult GuardarAsignacion(DetalleMateriaModel ObJAsignacion)
        {

            var RespuestaGuarda = _contactoDatos.GuardarAsignacion(ObJAsignacion);
            return new JsonResult(RespuestaGuarda);

        }


        [HttpPost]
        public IActionResult GuardarMateria(MateriasModel ObjMateria)
        {
            MateriasModel RespuestaGuarda;
           // if (ObjMateria.Id == 0)
           /// {

                RespuestaGuarda = _contactoDatos.GuardarMateria(ObjMateria);
           // }
           // else
           // {
           //     RespuestaGuarda = _contactoDatos.ActualizaMateria(ObjMateria);
           // }
            return new JsonResult(RespuestaGuarda);
        }



    }
}
