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
            List<UserData> userLoadData;
            //          
            userLoadData = Database.UserDatasRepository.Find( u => u.CoefficientSecondDegrees == userDataDTO.CoefficientSecondDegrees 
            && u.CoefficientFirstDegrees == userDataDTO.CoefficientFirstDegrees
            && u.CoefficientZeroDegrees == userDataDTO.CoefficientZeroDegrees
            && u.RangeFrom == userDataDTO.RangeFrom
            && u.RangeTo == userDataDTO.RangeTo
            && u.Step == userDataDTO.Step);

            //проверить
            if (userLoadData.Count == 0)
            {
                
                userDataDTO = MakeGraphic(userDataDTO); //create data 
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDataDTO, UserData>()
                .ForMember("PointList", opt => opt.Ignore())).CreateMapper();
                saveUserData = mapper.Map<UserDataDTO, UserData>(userDataDTO);

                Database.UserDatasRepository.Create(saveUserData);
                Database.Save();//save graphic

                userLoadData = Database.UserDatasRepository.Find(u => u.CoefficientSecondDegrees == userDataDTO.CoefficientSecondDegrees
                && u.CoefficientFirstDegrees == userDataDTO.CoefficientFirstDegrees
                && u.CoefficientZeroDegrees == userDataDTO.CoefficientZeroDegrees
                && u.RangeFrom == userDataDTO.RangeFrom
                && u.RangeTo == userDataDTO.RangeTo
                && u.Step == userDataDTO.Step);

                saveUserData = userLoadData[0]; // get ID

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
            else if(userLoadData.Count == 1)
            {
                saveUserData = userLoadData[0];
            }
            else
            {
                throw new ValidationException("get graphic err", "");
            }

            userDataDTO = ConvertUserDataInUserDataDto(saveUserData);
            return userDataDTO;
        }

        public IEnumerable<UserDataDTO> GetGraphics()
        {
            IEnumerable<UserData> usersLoadDatas;
            usersLoadDatas = Database.UserDatasRepository.GetAll();
            if (usersLoadDatas != null)
            {
                IList<UserDataDTO> userSaveDatas = new List<UserDataDTO>();
                foreach (UserData userData in usersLoadDatas)
                {
                    userSaveDatas.Add(ConvertUserDataInUserDataDto(userData));
                }
                return userSaveDatas;
            }

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
            pointDTO.PointY = point.PointY;
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

            IList<PointDTO> newPointList = new List<PointDTO>();
            PointDTO newPointDto;

            foreach (Point point in userData.PointList)
            {
                newPointDto = ConvertPointInPointDto(point);
                newPointList.Add(newPointDto);
            }

            userDataDTO.PointList = newPointList;
            return userDataDTO;
        }
    }
}
