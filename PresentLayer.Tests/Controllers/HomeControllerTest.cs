using System.Collections.Generic;
using System.Web.Mvc;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PresentLayer.Controllers;
using PresentLayer.Models;

namespace PresentLayer.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        Mock<IBuildingGraphicService> mock;
        HomeController controller;
        
        UserDataViewModel userDataViewModelInput;
        UserDataViewModel userDataViewModelOutput;
        List<PointViewModel> listPointViewModel;

        UserDataDTO userDataDtoOut;
        List<PointDTO> listPointDTO;

       [TestInitialize]
        public void SetupService()
        {
            // Arrange
            userDataViewModelInput = new UserDataViewModel()
            {
                CoefficientSecondDegrees = 0,
                CoefficientFirstDegrees = 0,
                CoefficientZeroDegrees = 1,
                RangeFrom = 1,
                RangeTo = 2,
                Step = 1
            };

            listPointViewModel = new List<PointViewModel>(); 
            listPointViewModel.Add(new PointViewModel() { PointX = 1, PointY = 1 });
            listPointViewModel.Add(new PointViewModel() { PointX = 2, PointY = 1 });
            userDataViewModelOutput = new UserDataViewModel()
            {
                CoefficientSecondDegrees = 0,
                CoefficientFirstDegrees = 0,
                CoefficientZeroDegrees = 1,
                RangeFrom = 1,
                RangeTo = 2,
                Step = 1,
                PointList = listPointViewModel
            };

            listPointDTO = new List<PointDTO>();
            listPointDTO.Add(new PointDTO() { PointX = 1, PointY = 1 });
            listPointDTO.Add(new PointDTO() { PointX = 2, PointY = 1 });
            userDataDtoOut = new UserDataDTO()
            {
                CoefficientSecondDegrees = 0,
                CoefficientFirstDegrees = 0,
                CoefficientZeroDegrees = 1,
                RangeFrom = 1,
                RangeTo = 2,
                Step = 1,
                PointList = listPointDTO
            };

            mock = new Mock<IBuildingGraphicService>();
            mock.Setup(a => a.GetGraphic(userDataDtoOut))
                .Returns(userDataDtoOut);

            controller = new HomeController(mock.Object);
        }
        [TestMethod]
        public void Index()
        {
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Building()
        {
            // Act
            ViewResult result = controller.Index(userDataViewModelInput) as ViewResult;
            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void About()
        {
            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
