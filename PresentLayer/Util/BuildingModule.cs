using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Ninject.Modules;


namespace PresentLayer.Util
{
    public class BuildingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBuildingGraphicService>().To<BuildingGraphicService>();
        }
    }
}