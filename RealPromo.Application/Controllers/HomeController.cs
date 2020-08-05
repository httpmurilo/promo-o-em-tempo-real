using Microsoft.AspNetCore.Mvc;

namespace RealPromo.Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Promocao()
        {
            return View();
        }

        public ActionResult CadastrarPromocao()
        {
            return View();
        }
    }
}