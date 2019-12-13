using BuildingGraphic.Models;
using BuildingGraphic.Services;
using System.Web.Mvc;

namespace BuildingGraphic.Controllers
{
    public class HomeController : Controller
    {
        MathematicaServices services;

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index (EquationDTO equationDTO)
        {
            if (ModelState.IsValid)
            {
                services = new MathematicaServices(equationDTO);

                if (services.GetValid())
                {
                    services.BuildingVisualisation();
                    ViewBag.Message = "☺Valid";
                    ViewBag.x = services.StrReqestDataX;

                    ViewBag.y = services.StrResponseDataY;
                    ViewBag.size = services.amountOfPoints;

                    return PartialView("IndexPartial");
                }
                ViewBag.Message = "data isn't Valid for Mathematica";

            }
            else
            {
                ViewBag.Message = "Non Valid";
            }
            return PartialView("ErrorPartialAjax");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("input");
        }

        [HttpPost]
        public ActionResult About(EquationDTO equationDTO)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Valid";

                return RedirectToAction("Contact");
            }
            ViewBag.Message = "Non Valid";

            return View("input");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}