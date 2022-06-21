using Ninject.Modules;
using PetClinic.DAL.DapperSQL;
using PetClinic.DAL.DapperSQL.Interfaces;
using PetClinic.DAL.Fake;
using PetClinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinic.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string _connectionString;
        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<IConnectionFactory>().To<SqlConnectionFactory>().WithConstructorArgument(_connectionString);

            Bind<IAnimalsDAO>().To<AnimalsDAOSql>().InSingletonScope();
            Bind<IOwnersDAO>().To<OwnersDAOSql>().InSingletonScope();
            Bind<ITypesAnimalDAO>().To<TypesAnimalDAOSql>().InSingletonScope();
            Bind<IRecipesDAO>().To<RecipeDAOSql>().InSingletonScope();
            Bind<IVisitsDAO>().To<VisitsDAOSql>().InSingletonScope();
        }
    }
}
