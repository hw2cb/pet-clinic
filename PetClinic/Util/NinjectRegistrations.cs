using Ninject.Modules;
using PetClinic.BLL;
using PetClinic.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetClinic.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnimalsService>().To<AnimalsService>().InSingletonScope();
            Bind<IOwnersService>().To<OwnersService>().InSingletonScope();
            Bind<IVisitsService>().To<VisitsService>().InSingletonScope();
        }
    }
}