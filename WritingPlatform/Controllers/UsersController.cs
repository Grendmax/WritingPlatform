using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WritingPlatform.BusinessLayer;
using WritingPlatform.BusinessLayer.BInterfaces;
using WritingPlatform.BusinessLayer.BusinessObjects;
using WritingPlatform.Models;

namespace WritingPlatform.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        IUsers userServ;
        IAuthen autServ;
        public UsersController(IUsers serv,IAuthen serv1)
        {
            autServ = serv1;
            userServ = serv;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login() {
            return View(new UsersViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UsersViewModel model,string returnUrl)
        {
            if (ModelState.IsValid) {

                if (autServ.CheckLogin(model.Login, model.Password))
                {

                    if (autServ.GetUserStatus(model.Login, model.Password) == false)
                    {

                        if (autServ.GetUserId(model.Login, model.Password) != 0)
                        {

                            HttpCookie cookie = new HttpCookie("My localhost cookie");
                            cookie["ids"] = autServ.GetUserId(model.Login, model.Password).ToString();
                            cookie.Expires = DateTime.Now.AddHours(1);
                            Response.Cookies.Add(cookie);
                        }

                        FormsAuthentication.SetAuthCookie(model.Login, false);
                        return Redirect(returnUrl ?? Url.Action("Index", "Home"));

                    }
                    else
                    {
                        ModelState.AddModelError("", "Your account deleted");
                    }

                }
                else {
                    ModelState.AddModelError("", "Incorrect login or password");
                    return View();
                }

                
            }
            return View();
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            return View(AutoMapper<IEnumerable<UsersBO>, List<UsersViewModel>>.Map(userServ.GetUsers().Where(x=>x.IsDelete==false)));
        }
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(UsersViewModel user)
        {
            if (ModelState.IsValid)
            {
                UsersBO newUser = AutoMapper<UsersViewModel, UsersBO>.Map(user);
                newUser.IsDelete = false;
                userServ.Create(newUser);               
                return RedirectToActionPermanent("Index", "Users");
            }
            return View();

        }

        public ActionResult Update(int id)
        {
            UsersViewModel user = AutoMapper<UsersBO, UsersViewModel>.Map(userServ.GetUser, (int)id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(UsersViewModel user)
        {
            UsersBO newUser = AutoMapper<UsersViewModel, UsersBO>.Map(user);
            userServ.Update(newUser);
            return RedirectToActionPermanent("Index", "Users");
        }

        public ActionResult Delete(int id)
        {
            userServ.DeleteUser(id);
            return RedirectToAction("Index", "Users");
        }

        public ActionResult PersonalProfile()
        {
            HttpCookie cookieReq = Request.Cookies["My localhost cookie"];

            int ids = 0;
            if (cookieReq != null)
            {
                ids = Convert.ToInt32(cookieReq["ids"]);
            }

            UsersViewModel oldUser = AutoMapper<UsersBO, UsersViewModel>.Map(userServ.GetUser, (int)ids);

            return View(oldUser);
        }

        [HttpPost]
        public ActionResult PersonalProfile(UsersViewModel user)
        {
            UsersBO newUser = AutoMapper<UsersViewModel, UsersBO>.Map(user);
            userServ.Update(newUser);
            return RedirectToActionPermanent("PersonalProfile", "Users");
        }

        public ActionResult DeleteAccount()
        {
            HttpCookie cookieReq = Request.Cookies["My localhost cookie"];

            int ids = 0;
            if (cookieReq != null)
            {
                ids = Convert.ToInt32(cookieReq["ids"]);
            }
            UsersViewModel oldUser = AutoMapper<UsersBO, UsersViewModel>.Map(userServ.GetUser, (int)ids);

            oldUser.IsDelete = true;

            UsersBO newUser = AutoMapper<UsersViewModel, UsersBO>.Map(oldUser);
            //newUser.IsDelete = true;

            userServ.Update(newUser);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        




    }

}