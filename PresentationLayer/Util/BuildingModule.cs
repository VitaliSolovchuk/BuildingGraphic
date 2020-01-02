using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Util
{
    public class BuildingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBuildingGraphicService>().To<BuildingGraphicService>();
        }
    }
}