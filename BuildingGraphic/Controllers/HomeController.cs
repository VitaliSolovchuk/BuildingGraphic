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
                ViewBag.Message = "non Valid";
            }
            return PartialView("ErrorPartialAjax");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Это очень красивое и практичное что-то";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "contact page.";

            return View();
        }
    }
}