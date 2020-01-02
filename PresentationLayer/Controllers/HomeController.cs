using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using PresentationLayer.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        IBuildingGraphicService buildingService;
        public HomeController(IBuildingGraphicService buildingGraphicService)
        {
            buildingService = buildingGraphicService;
        }

        public ActionResult Index()
        {
            //Отображение формочки
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserDataViewModel userDataViewModel)
        {
            if (ModelState.IsValid)
            {
                var mapperInDto = new MapperConfiguration(cfg => cfg.CreateMap<UserDataViewModel, UserDataDTO>()).CreateMapper();
                var mapperInView = new MapperConfiguration(cfg => cfg.CreateMap<UserDataDTO, UserDataViewModel>()
                .ForMember("PointList", opt => opt.Ignore())).CreateMapper();
                UserDataDTO saveUserData = mapperInDto.Map<UserDataViewModel, UserDataDTO>(userDataViewModel);

                saveUserData = buildingService.GetGraphic(saveUserData);
                userDataViewModel = mapperInView.Map<UserDataDTO, UserDataViewModel>(saveUserData);
                
                ICollection<PointViewModel> pointViewModelList = new List<PointViewModel>();
                foreach(PointDTO pointDTO in saveUserData.PointList)
                {
                    pointViewModelList.Add(new PointViewModel()
                    {
                        PointX = pointDTO.PointX,
                        PointY = pointDTO.PointY
                    });
                }
                userDataViewModel.PointList = pointViewModelList;
            }

            return View("Building", userDataViewModel);
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