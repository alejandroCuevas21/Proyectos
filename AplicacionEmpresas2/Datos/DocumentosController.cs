using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionEscolar.Datos
{
    public class DocumentosController : Controller
    {
        // GET: DocumentosController
        public ActionResult Documentos()
        {
            return View();
        }


       
    }
}
