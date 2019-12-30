using BusinessLogicLayer.DTO;


namespace BusinessLogicLayer.Interfaces
{
    public interface IBuildingGraphicService
    {
        void MakeGraphic(UserDataDTO userDataDTO);
        UserDataDTO SearchGraphic();
        void Dispose();

    }
}
