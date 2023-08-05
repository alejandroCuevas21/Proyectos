using AplicacionEmpresas2.Datos;
using AplicacionEmpresas2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionEscolar.Datos
{
    public class ActualizacionPedidoController : Controller
    {
        EscolarDatos _contactoDatos = new EscolarDatos();
        public ActionResult ActualizacionPedido()
        {
            return View();
        }
        public IActionResult ObtenerStatus()
        {

          var Status = _contactoDatos.ObtenerStatus();
        return new JsonResult(Status);

        }
        public IActionResult CargaPedido(string OrdPedido)
        {
            var Pedido = _contactoDatos.ObtenerPedido(OrdPedido);
            return new JsonResult(Pedido);
        }

    }
}
