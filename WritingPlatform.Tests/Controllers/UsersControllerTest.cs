using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WritingPlatform.BusinessLayer.BInterfaces;
using Moq;
using System.Collections.Generic;
using WritingPlatform.BusinessLayer.BusinessObjects;
using WritingPlatform.Controllers;
using System.Web.Mvc;
using WritingPlatform.Models;
using WritingPlatform.BusinessLayer;

namespace WritingPlatform.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        [TestMethod]
        public void IndexViewModelNotNull()
        {
            // Arrange
            var mock = new Mock<IUsers>();
            mock.Setup(a => a.GetUsers()).Returns(new List<UsersBO>());
            UsersController controller = new UsersController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreatePostAction_ModelError()
        {
            // arrange
            string expected = "Create";
            var mock = new Mock<IUsers>();
            UsersViewModel user = new UsersViewModel();
            UsersController controller = new UsersController(mock.Object);
            controller.ModelState.AddModelError("Login", "Имя пользователя модели не установлено");
            // act
            ViewResult result = controller.Create(user) as ViewResult;
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }

        [TestMethod]
        public void CreatePostAction_RedirectToIndexView()
        {
            // arrange
            string expected = "Index";
            var mock = new Mock<IUsers>();
            UsersViewModel user = new UsersViewModel();
            UsersController controller = new UsersController(mock.Object);
            // act
            RedirectToRouteResult result = controller.Create(user) as RedirectToRouteResult;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        public void CreatePostAction_SaveModel()
        {
            // arrange
            var mock = new Mock<IUsers>();
            UsersViewModel user = new UsersViewModel();
            UsersController controller = new UsersController(mock.Object);
            // act
            RedirectToRouteResult result = controller.Create(user) as RedirectToRouteResult;
            // assert
            mock.Verify(a => a.Create(It.IsAny<UsersBO>()));
        }




    }
}
