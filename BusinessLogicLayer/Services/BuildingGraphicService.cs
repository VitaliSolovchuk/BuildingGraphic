using System.Collections.Generic;
using AutoMapper;
using BusinessLogicLayer.BusinessModels;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services
{
    public class BuildingGraphicService : IBuildingGraphicService
    {
        private MathematicaBusinessModel mathematica;
        IUnitOfWork Database { get; set; }

        public BuildingGraphicService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;         
        }

        private UserDataDTO MakeGraphic(UserDataDTO userDataDTO)
        {
            mathematica = new MathematicaBusinessModel(userDataDTO);
            if (!mathematica.GetValid())
            {
                throw new ValidationException("UserData non valid", "");
            }             
            return mathematica.BuildingVisualisation();


        }

        public UserDataDTO GetGraphic(UserDataDTO userDataDTO)
        {
            UserData saveUserData;
            List<UserData> usersTempData;
            //вытащил
            usersTempData = Database.UserDatasRepository.Find( u => u.CoefficientSecondDegrees == userDataDTO.CoefficientSecondDegrees 
            && u.CoefficientFirstDegrees == userDataDTO.CoefficientFirstDegrees
            && u.CoefficientZeroDegrees == userDataDTO.CoefficientZeroDegrees
            && u.RangeFrom == userDataDTO.RangeFrom
            && u.RangeTo == userDataDTO.RangeTo
            && u.Step == userDataDTO.Step);

            //проверить
            if (usersTempData.Count == 0)
            {
                
                userDataDTO = MakeGraphic(userDataDTO); //create data 
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDataDTO, UserData>()
                .ForMember("PointList", opt => opt.Ignore())).CreateMapper();
                saveUserData = mapper.Map<UserDataDTO, UserData>(userDataDTO);
                Database.UserDatasRepository.Create(saveUserData);
                Database.Save();//save graphic

                usersTempData = Database.UserDatasRepository.Find(u => u.CoefficientSecondDegrees == userDataDTO.CoefficientSecondDegrees
                && u.CoefficientFirstDegrees == userDataDTO.CoefficientFirstDegrees
                && u.CoefficientZeroDegrees == userDataDTO.CoefficientZeroDegrees
                && u.RangeFrom == userDataDTO.RangeFrom
                && u.RangeTo == userDataDTO.RangeTo
                && u.Step == userDataDTO.Step);

                saveUserData = usersTempData[0]; // get ID

                foreach (PointDTO pointDTO in userDataDTO.PointList)
                {
                    Database.PointesRepository.Create(new Point
                    {
                        PointX = pointDTO.PointX,
                        PointY = pointDTO.PointY,
                        UserDataId = saveUserData.Id
                    });
                }
                Database.Save(); //save point

                saveUserData = Database.UserDatasRepository.Get(saveUserData.Id);
            }
            else if(usersTempData.Count == 1)
            {
                saveUserData = usersTempData[0];
            }
            else
            {
                throw new ValidationException("get graphic err", "");
            }

            return ConvertUserDataInUserDataDto(saveUserData);
        }

        public IEnumerable<UserDataDTO> GetGraphics()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        private PointDTO ConvertPointInPointDto(Point point)
        {
            PointDTO pointDTO = new PointDTO();
            pointDTO.PointX = point.PointX;
            pointDTO.PointX = point.PointY;
            return pointDTO;
        }
        private UserDataDTO ConvertUserDataInUserDataDto(UserData userData)
        {
            UserDataDTO userDataDTO = new UserDataDTO();
            userDataDTO.CoefficientSecondDegrees = userData.CoefficientSecondDegrees;
            userDataDTO.CoefficientFirstDegrees = userData.CoefficientFirstDegrees;
            userDataDTO.CoefficientZeroDegrees = userData.CoefficientZeroDegrees;
            userDataDTO.RangeFrom = userData.RangeFrom;
            userDataDTO.RangeTo = userData.RangeTo;
            userDataDTO.Step = userData.Step;

            ICollection<PointDTO> PointList = new List<PointDTO>();
            foreach (Point point in userData.PointList)
            {
                PointList.Add(ConvertPointInPointDto(point));
            }

            userDataDTO.PointList = PointList;
            return userDataDTO;
        }
    }
}

/*
new UserData
                {
                    CoefficientSecondDegrees = userDataDTO.CoefficientSecondDegrees,
                    CoefficientFirstDegrees = userDataDTO.CoefficientFirstDegrees,
                    CoefficientZeroDegrees = userDataDTO.CoefficientZeroDegrees,
                    RangeFrom = userDataDTO.RangeFrom,
                    RangeTo = userDataDTO.RangeTo,
                    Step = userDataDTO.Step
                } */ 