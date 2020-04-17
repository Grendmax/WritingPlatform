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
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace WritingPlatform.Controllers
{
    [Authorize]
    public class WorksController : Controller
    {
        IWorks workServ;
        IGenres genreServ;
        IUsers userServ;
        IComments commentServ;
        IRatings ratingServ;
        public WorksController(IGenres serv, IWorks serv1, IUsers serv2, IComments serv3, IRatings serv4)
        {
            commentServ = serv3;
            userServ = serv2;
            workServ = serv1;
            genreServ = serv;
            ratingServ = serv4;
        }



        public ActionResult Create()
        {
            ViewBag.GenreList = new SelectList(genreServ.GetGenres().ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(WorksViewModel model)
        {
            HttpCookie cookieReq = Request.Cookies["My localhost cookie"];

            int ids = 0;
            if (cookieReq != null)
            {
                ids = Convert.ToInt32(cookieReq["ids"]);
            }
            else {
                FormsAuthentication.SignOut();
                return RedirectToActionPermanent("Index", "Works");
            }
         
            model.UserId = ids;
            model.DateOfPublication = DateTime.Now;
            if (ModelState.IsValid)
            {
                WorksBO newWork = AutoMapper<WorksViewModel, WorksBO>.Map(model);

                workServ.Create(newWork);
                return RedirectToActionPermanent("Index", "Works");
            }
            return View();

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string filter){
            ViewBag.filter = filter;
            return View();
        }


        public ActionResult GetWorks(string filter=null) {

            var workList = workServ.GetWorks().Join(userServ.GetUsers(),
                w => w.UserId,
                u => u.Id, (w, u) => new { Id = w.Id, Name = w.Name, DateOfPublication = w.DateOfPublication, Content = w.Content, IsDelete = u.IsDelete, Username = u.Login, GenreId = w.GenreId }).Join(genreServ.GetGenres(),
                w => w.GenreId,
                g => g.Id, (w, g) => new InfoModel { Id = w.Id, Name = w.Name, DateOfPublication = w.DateOfPublication.Date, Content = w.Content, UserName = w.Username, GenreName = g.Name, IsDelete = w.IsDelete }).ToList();

            foreach (var item in workList)
            {
                if (item.IsDelete == true)
                {
                    item.UserName = "anonymous";
                }
            }


            ViewBag.WorksList = filter == null ? workList : workList.Where(x => x.Name.Contains(filter) || x.GenreName.Contains(filter) || x.UserName.Contains(filter));

            return View("_WorksTable", filter==null ? AutoMapper<IEnumerable<WorksBO>, List<WorksViewModel>>.Map(workServ.GetWorks())  : AutoMapper<IEnumerable<WorksBO>, List<WorksViewModel>>.Map(workServ.GetWorks().Where(x=>x.Name.Contains(filter)).ToList()));

        }



        public ActionResult GetComments(WorksViewModel work)
        {
            HttpCookie cookieReqs = Request.Cookies["My localhost cookie"];
            int idsWork= work.Id;

            int idsUser = 0;
            if (cookieReqs != null)
            {
                idsUser = Convert.ToInt32(cookieReqs["ids"]);
            }
            else {
                FormsAuthentication.SignOut();
            }

            if (work.UserId != 0)
            {
                RatingsBO userRatingForWork = ratingServ.GetRatings().Where(x => x.UserId == idsUser && x.WorkId == idsWork).FirstOrDefault();

                RatingsBO newRating = new RatingsBO();
                newRating.Rank = work.UserId;
                newRating.UserId = idsUser;
                newRating.WorkId = idsWork;

                if (userRatingForWork != null)
                {
                    RatingsBO old = ratingServ.GetRating(userRatingForWork.Id);
                    ratingServ.DeleteRating(old.Id);
                    ratingServ.Create(newRating);
                }
                else
                {
                    ratingServ.Create(newRating);
                }
            }
           


            if (work.Name != null)
            {
                CommentsBO newComment = new CommentsBO();
                newComment.Comment = work.Name;
                newComment.UserId = idsUser;
                newComment.WorkId = idsWork;
                CommentsBO test = commentServ.GetComments().Where(x => x.UserId == idsUser && x.WorkId == idsWork).FirstOrDefault();

                if (commentServ.GetComments().Where(x => x.UserId == idsUser && x.WorkId == idsWork).FirstOrDefault() != null)
                {
                    CommentsBO old = commentServ.GetComment(test.Id);
                    commentServ.DeleteComment(old.Id);
                    commentServ.Create(newComment);

                }
                else
                {
                    commentServ.Create(newComment);
                }
            }

            var commentList = commentServ.GetComments().Join(workServ.GetWorks(),
            c => c.WorkId,
            w => w.Id, (c, w) => new { Id = c.Id, Comment = c.Comment, UserId = c.UserId, WorkId = c.WorkId }).Join(userServ.GetUsers(),
            c => c.UserId,
            u => u.Id, (c, u) => new InfoModelWithComments { Id = c.Id, UserName = u.Login, Comment = c.Comment, WorkId = c.WorkId, IsDelete = u.IsDelete }).ToList();

            foreach (var item in commentList)
            {
                if (item.IsDelete == true)
                {
                    item.UserName = "anonymous";
                }
            }
            ViewBag.CommentsList = commentList.Where(c => c.WorkId == idsWork).ToList();
            


            List<RatingsBO> lst = ratingServ.GetRatings().Where(x => x.WorkId == idsWork).Join(userServ.GetUsers(),
               c => c.UserId,
               u => u.Id, (c, u) => new RatingsBO { Id = c.Id, Rank = c.Rank, UserId = c.UserId, WorkId = c.WorkId, IsDeleteCheck = u.IsDelete }).Where(x => x.IsDeleteCheck == false).ToList();

            if (lst.Count != 0)
            {
                int sum = 0;
                int rating = 0;
                foreach (var item in lst)
                {
                    sum += item.Rank;
                }
                rating = sum / lst.Count;
                ViewBag.Ratings = rating;
            }
            else
            {
                ViewBag.Ratings = 0;
            }          
            return View("_CommentsTable");
        }




        public ActionResult Update(int id)
        {
            ViewBag.GenreList = new SelectList(genreServ.GetGenres().ToList(), "Id", "Name");
            WorksViewModel work = AutoMapper<WorksBO, WorksViewModel>.Map(workServ.GetWork, (int)id);
            return View(work);
        }

        [HttpPost]
        public ActionResult Update(WorksViewModel user)
        {
            WorksBO newUser = AutoMapper<WorksViewModel, WorksBO>.Map(user);
            workServ.Update(newUser);
            return RedirectToActionPermanent("Index", "Works");
        }

        public ActionResult Delete(int id)
        {
            HttpCookie cookieReqs = Request.Cookies["My localhost cookie"];

            int idsUser = 0;

            int thisWorkUserId = workServ.GetWork(id).UserId;

            if (cookieReqs != null)
            {
                idsUser = Convert.ToInt32(cookieReqs["ids"]);
                if (idsUser == thisWorkUserId)
                {
                    List<CommentsBO> workCommentsList = commentServ.GetComments().Where(x => x.WorkId == id).ToList();
                    List<RatingsBO> workRatingList = ratingServ.GetRatings().Where(x => x.WorkId == id).ToList();
                    foreach (var item in workCommentsList)
                    {
                        commentServ.DeleteComment(item.Id);
                    }
                    foreach (var item in workRatingList)
                    {
                        ratingServ.DeleteRating(item.Id);
                    }
                    workServ.DeleteWork(id);

                    return RedirectToAction("Index", "Works");
                }
                else
                {
                    return RedirectToAction("Index", "Works");
                }
            }
            else {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Works");
            }

            
        }

        public ActionResult PersonalProfile()
        {
            return View();
        }

        
        public ActionResult Details(int id)
        {
            WorksViewModel work = AutoMapper<WorksBO, WorksViewModel>.Map(workServ.GetWork, (int)id);
            work.Name = "";
            work.UserId = 1;
            return View(work);
        }


        [HttpPost]
        public ActionResult Details(WorksViewModel user)
        {
            HttpCookie cookieReq = Request.Cookies["My localhost cookie"];

            int ids = 0;
            if (cookieReq != null)
            {
                ids = Convert.ToInt32(cookieReq["ids"]);
            }
          
            WorksBO newUser = AutoMapper<WorksViewModel, WorksBO>.Map(user);

            CommentsBO newComment = new CommentsBO();

            newComment.Comment = newUser.Name;
            newComment.WorkId = newUser.Id;
            newComment.UserId = ids;

            
            return RedirectToActionPermanent("Index", "Works");
        }

       



    }
}