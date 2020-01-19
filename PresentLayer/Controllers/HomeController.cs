using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using PresentLayer.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PresentLayer.Controllers
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
            ViewBag.Message = "Красивое приложение";
            return View("Index");
        }
        [HttpPost]
        public ActionResult Index(UserDataViewModel userDataViewModel)
        {
            if (ModelState.IsValid)
            {         
                UserDataDTO saveUserData = ConvertUserDataViewModelInDTO(userDataViewModel);
                saveUserData = buildingService.GetGraphic(saveUserData);
                userDataViewModel = ConvertUserDataDtoInViewModel(saveUserData);
            }
            else
            {
                return PartialView("ErrorPartial");
            }

            string stringaX,stringaY;
            AlterationPointListInTwoString(userDataViewModel.PointList, out stringaX, out stringaY);

            ViewBag.x = stringaX;
            ViewBag.y = stringaY;
            ViewBag.Message = "Вот ваш график:";
            return PartialView("IndexPartial");
        }
        
        public ActionResult About()
        {
            IEnumerable<UserDataDTO> saveUserData;
            saveUserData = buildingService.GetGraphics();
            IList<UserDataViewModel> userDataViewModel = new List<UserDataViewModel>();
            foreach(UserDataDTO userDataDTO in saveUserData)
            {
                userDataViewModel.Add(ConvertUserDataDtoInViewModel(userDataDTO));
            }
            
            ViewBag.Message = "You have opportunity visualize graph by dint of my application.";
            return View("About",userDataViewModel);
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        private void AlterationPointListInTwoString(IList<PointViewModel> pointsViewModels, out string stringaX, out string stringaY)
        {
            stringaX = null;
            stringaY = null;
            foreach (PointViewModel pointViewModel in pointsViewModels)
            {
                stringaX += pointViewModel.PointX + ", ";
                stringaY += pointViewModel.PointY + ", ";
            }

        }
        private UserDataDTO ConvertUserDataViewModelInDTO(UserDataViewModel userDataViewModel)
        {
            var mapperInDto = new MapperConfiguration(cfg => cfg.CreateMap<UserDataViewModel, UserDataDTO>()
            .ForMember("PointList", opt => opt.Ignore())).CreateMapper();           

            UserDataDTO userDataDTO = mapperInDto.Map<UserDataViewModel, UserDataDTO>(userDataViewModel);
            return userDataDTO;
        }
        private UserDataViewModel ConvertUserDataDtoInViewModel(UserDataDTO userDataDTO)
        {
            var mapperInView = new MapperConfiguration(cfg => cfg.CreateMap<UserDataDTO, UserDataViewModel>()
            .ForMember("PointList", opt => opt.Ignore())).CreateMapper();
            UserDataViewModel userDataViewModel = mapperInView.Map<UserDataDTO, UserDataViewModel>(userDataDTO);
            
            //Ручная перепись точек
            IList<PointViewModel> pointViewModelList = new List<PointViewModel>();
            foreach (PointDTO pointDTO in userDataDTO.PointList)
            {
                pointViewModelList.Add(new PointViewModel()
                {
                    PointX = pointDTO.PointX,
                    PointY = pointDTO.PointY
                });
            }
            userDataViewModel.PointList = pointViewModelList;
            return userDataViewModel;
        }
    }
}