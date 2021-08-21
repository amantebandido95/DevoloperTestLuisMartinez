using CovidCasesReports.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace CovidCasesReports.Utils
{
    public class ByteArrayMaker
    {
        public byte[] SerializeJson(object value, JsonSerializerSettings jsonSerializerSettings)
        {
            byte[] fileContent;
            JsonMaker _JsonMaker = new JsonMaker();

            fileContent = _JsonMaker.SerializeJson(value, jsonSerializerSettings);

            return fileContent;
        }

        public byte[] CreateRegionsXML(List<SimpleRegionReport> _Regions)
        {
            byte[] fileContent;
            XMLMaker _XMLMaker = new XMLMaker();

            fileContent = _XMLMaker.CreateRegionsXML(_Regions);

            return fileContent;
        }

        public byte[] CreateProvincesXML(List<SimpleProvinceReport> _Provinces)
        {
            byte[] fileContent;
            XMLMaker _XMLMaker = new XMLMaker();

            fileContent = _XMLMaker.CreateProvincesXML(_Provinces);

            return fileContent;

        }

        public byte[] GenerateRegionPDF(List<SimpleRegionReport> _Regions)
        {
            byte[] file;
            PdfMaker _PdfMaker = new PdfMaker();

            file = _PdfMaker.GenerateRegionPDF(_Regions);

            return file;

        }

        public byte[] GenerateProvincesPDF(List<SimpleProvinceReport> _Pronvinces, string iso)
        {
            byte[] file;
            PdfMaker _PdfMaker = new PdfMaker();

            file = _PdfMaker.GenerateProvincesPDF(_Pronvinces, iso);

            return file;
        }
    }
}
