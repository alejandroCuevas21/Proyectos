using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionEscolar.Datos
{
    public class PedidosController : Controller
    {
        // GET: PedidosController
        public ActionResult Pedidos()
        {
            return View();
        }

       
    }
}
