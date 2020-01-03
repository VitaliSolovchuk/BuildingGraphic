using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PresentLayer.Controllers;


namespace PresentLayer.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        Mock<IBuildingGraphicService> mock;

        [TestInitialize]
        public void SetupService()
        {
            mock = new Mock<IBuildingGraphicService>();
            mock.Setup(a => a.GetGraphic(new UserDataDTO()))
                .Returns(new UserDataDTO() { PointList = new List<PointDTO>() });
        }
        [TestMethod]
        public void Index()
        {
   
            // Arrange
            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
