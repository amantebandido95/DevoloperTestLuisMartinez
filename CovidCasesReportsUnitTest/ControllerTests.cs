using CovidCasesReports.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace CovidCasesReportsUnitTest
{   

    public class ControllerTests
    {
        [Fact]
        public void Index()
        {
            HomeController homeController = new HomeController();

            ViewResult result = homeController.Index() as ViewResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void Index2()
        {
            HomeController homeController = new HomeController();

            ViewResult result = homeController.Index("","") as ViewResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void  DownloadJSON()
        {
            HomeController homeController = new HomeController();

            FileContentResult result = homeController.DownloadJSON() as FileContentResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void DownloadXML()
        {
            HomeController homeController = new HomeController();

            FileContentResult result = homeController.DownloadXML() as FileContentResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void DownloadPDF()
        {
            HomeController homeController = new HomeController();

            FileContentResult result = homeController.DownloadPDF() as FileContentResult;

            Assert.NotNull(result);
        }

    }
}
