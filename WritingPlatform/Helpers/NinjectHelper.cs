using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WritingPlatform.BusinessLayer.BInterfaces;
using WritingPlatform.BusinessLayer.BusinessObjects;
using WritingPlatform.BusinessLayer.Helpers;

namespace WritingPlatform.Helpers
{
    public class NinjectHelper : NinjectModule
    {
        public override void Load()
        {
            Bind<IComments>().To<CommentsHelper>();
            Bind<IRatings>().To<RatingsHelper>();
            Bind<IWorks>().To<WorksHelper>();
            Bind<IGenres>().To<GenresHelper>();
            Bind<IUsers>().To<UsersHelper>();
            Bind<IAuthen>().To<UserAuthentication>();
        }
    }
}