using CovidCasesReports.APIConsumption;
using CovidCasesReports.Models;
using CovidCasesReports.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using Utils.APIConsumption;

namespace CovidCasesReports.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ReportsCollector _ReportsCollector = new ReportsCollector();
        private DataPreparation _DataPreparation = new DataPreparation();
        private ByteArrayMaker _ByteArrayMaker = new ByteArrayMaker();

        private static List<ReportsDatum> _Regions = new List<ReportsDatum>();
        private static List<ReportsDatum> _Pronvinces = new List<ReportsDatum>();

        private List<SimpleRegionReport> _RegionsToDownload = new List<SimpleRegionReport>();
        private List<SimpleProvinceReport> _ProvincesToDownload = new List<SimpleProvinceReport>();

        private static string province = "";

  

        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.regions = _ReportsCollector.GetGlobalReport();
            model.provinces = null;
            model.display = "Regions";

            _Regions = model.regions;

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string selectedRegions, string submitButton)
        {
            submitButton = submitButton == null || submitButton == "" ? "reports" : submitButton;
            selectedRegions = selectedRegions == null || selectedRegions == "" ? "Regions" : selectedRegions;

            switch (submitButton)
            {   
                case "reports":
                    break;
                case "JSON":
                    return DownloadJSON();
                case "XML":
                    return DownloadXML();
                case "PDF":
                    return DownloadPDF();
                default:
                    break;


            }

            dynamic model = new ExpandoObject();
            model.regions = _ReportsCollector.GetGlobalReport();
            _Regions = model.regions;
            model.provinces = null;

            if (selectedRegions.Contains("Regions"))
            {
                model.display = "Regions";
                _Pronvinces = new List<ReportsDatum>();
                province = "";
            }
            else
            {
                model.display = "Provinces of " + selectedRegions;
                province = selectedRegions;
                model.provinces = _ReportsCollector.GetGlobalReportByRegion(selectedRegions);
                _Pronvinces = model.provinces;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult DownloadJSON()
        {
            string fileName = "";          
            byte[] download = new byte[] { };

            if(_Pronvinces.Count > 0)
            {
                _ProvincesToDownload = _DataPreparation.getListForProvincesReportDownload(_Pronvinces);
                download = _ByteArrayMaker.SerializeJson(_ProvincesToDownload, new JsonSerializerSettings());
                fileName = "provinceReport.json";
            }
            else
            {
                _RegionsToDownload = _DataPreparation.getListForRegionReportDownload(_Regions);
                download = _ByteArrayMaker.SerializeJson(_RegionsToDownload, new JsonSerializerSettings());
                fileName = "regionReport.json";
            }
         
            return File(download, "application/json", fileName);
        }

        [HttpPost]
        public IActionResult DownloadXML()
        {
            byte[] download = new byte[] { };
            string fileName = "";

            if (_Pronvinces.Count > 0)
            {
                _ProvincesToDownload = _DataPreparation.getListForProvincesReportDownload(_Pronvinces);
                download = _ByteArrayMaker.CreateProvincesXML(_ProvincesToDownload);
                fileName = "provinceReport.xml";
            }
            else
            {
                _RegionsToDownload = _DataPreparation.getListForRegionReportDownload(_Regions);
                download = _ByteArrayMaker.CreateRegionsXML(_RegionsToDownload);               
                fileName = "regionReport.xml";
            }

            return File(download, "application/xml", fileName);
        }

        [HttpPost]
        public IActionResult DownloadPDF()
        {
            byte[] download = new byte[] { };
            string fileName = "";

            if (_Pronvinces.Count > 0)
            {
                _ProvincesToDownload = _DataPreparation.getListForProvincesReportDownload(_Pronvinces);
                download = _ByteArrayMaker.GenerateProvincesPDF(_ProvincesToDownload, province);
                fileName = "provinceReport.pdf";
            }
            else
            {
                _RegionsToDownload = _DataPreparation.getListForRegionReportDownload(_Regions);
                download = _ByteArrayMaker.GenerateRegionPDF(_RegionsToDownload);
                fileName = "regionReport.pdf";
            }



            return File(download, "application/pdf", fileName);
        }
    }
}
