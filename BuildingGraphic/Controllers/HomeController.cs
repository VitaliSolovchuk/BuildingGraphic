using BuildingGraphic.Models;
using System.Web.Mvc;

namespace BuildingGraphic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index (EquationDTO equationDTO)
        {
            string stringa = "text mesage";
            return PartialView(stringa);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}