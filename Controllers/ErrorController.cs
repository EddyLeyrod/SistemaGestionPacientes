using System.Web.Mvc;

namespace SistemaGestionPacientes.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error/NotFound
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        // GET: Error/ServerError
        public ActionResult ServerError()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}