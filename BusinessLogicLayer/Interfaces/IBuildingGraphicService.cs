using System.Collections.Generic;
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Interfaces
{
    public interface IBuildingGraphicService
    {
        IEnumerable<UserDataDTO> GetGraphics();
        //возвращать набор точек или UserData
        UserDataDTO GetGraphic(UserDataDTO userDataDTO);
        void Dispose();
    }
}
