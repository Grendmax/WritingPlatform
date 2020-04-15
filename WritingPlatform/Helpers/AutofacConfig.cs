using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using WritingPlatform.BusinessLayer.BInterfaces;
using WritingPlatform.BusinessLayer.BusinessObjects;
using WritingPlatform.BusinessLayer.Helpers;

namespace WritingPlatform.Helpers
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {

            var builder = new ContainerBuilder();


            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            builder.RegisterType<CommentsHelper>().As<IComments>();
            builder.RegisterType<RatingsHelper>().As<IRatings>();
            builder.RegisterType<WorksHelper>().As<IWorks>();
            builder.RegisterType<GenresHelper>().As<IGenres>();
            builder.RegisterType<UsersHelper>().As<IUsers>();
            builder.RegisterType<UserAuthentication>().As<IAuthen>();
            builder.RegisterModule(new ServiceModule("Model1"));

            var container = builder.Build();


            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}