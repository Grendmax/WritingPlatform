using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WritingPlatform.BusinessLayer;
using WritingPlatform.BusinessLayer.BInterfaces;
using WritingPlatform.BusinessLayer.BusinessObjects;
using WritingPlatform.Models;

namespace WritingPlatform.Controllers
{
    public class GenresController : Controller
    {
        //IUsers userServ;
        //public GenresController(IUsers serv)
        //{

        //    userServ = serv;
        //}
        //public ActionResult Index()
        //{
        //    return View(AutoMapper<IEnumerable<UsersBO>, List<UsersViewModel>>.Map(userServ.GetUsers()));
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(UsersViewModel user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UsersBO newUser = AutoMapper<UsersViewModel, UsersBO>.Map(user);
        //        userServ.Create(newUser);
        //        return RedirectToActionPermanent("Index", "Users");
        //    }
        //    return View();

        //}

        //public ActionResult Update(int id)
        //{
        //    UsersViewModel user = AutoMapper<UsersBO, UsersViewModel>.Map(userServ.GetUser, (int)id);
        //    return View(user);
        //}

        //[HttpPost]
        //public ActionResult Update(UsersViewModel user)
        //{
        //    UsersBO newUser = AutoMapper<UsersViewModel, UsersBO>.Map(user);
        //    userServ.Update(newUser);
        //    return RedirectToActionPermanent("Index", "Users");
        //}

        //public ActionResult Delete(int id)
        //{
        //    userServ.DeleteUser(id);
        //    return RedirectToAction("Index", "Users");
        //}

        //public ActionResult SignIn()
        //{
        //    return View();
        //}




    }
}