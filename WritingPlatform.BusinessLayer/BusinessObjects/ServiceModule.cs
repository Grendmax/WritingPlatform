using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WritingPlatform.DataLayer.UnitOfWork;
using Autofac;

namespace WritingPlatform.BusinessLayer.BusinessObjects
{
    public class ServiceModule : Module
    {
        string connection;
        public ServiceModule(string connection)
        {
            this.connection = connection;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UnitOfWork(connection)).As<IUnitOfWork>();
        }
    }
}
