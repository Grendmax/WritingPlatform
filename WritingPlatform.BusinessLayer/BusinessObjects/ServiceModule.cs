using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.DataLayer.UnitOfWork;

namespace WritingPlatform.BusinessLayer.BusinessObjects
{
    public class ServiceModule : NinjectModule
    {
        string connection;
        public ServiceModule(string connection)
        {
            this.connection = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connection);
        }
    }
}
