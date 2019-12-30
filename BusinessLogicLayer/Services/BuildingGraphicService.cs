using BusinessLogicLayer.BusinessModels;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;

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

        public void MakeGraphic(UserDataDTO userDataDTO)
        {
            mathematica = new MathematicaBusinessModel(userDataDTO);
            //валидация
            if (!mathematica.GetValid())
            {
                throw new ValidationException("UserData non valid", "");
            }
            //Проверка по базе
            //Database.UserDatasRepository.Find
            //или достаём, или считаем
            
        }

        public UserDataDTO SearchGraphic()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
