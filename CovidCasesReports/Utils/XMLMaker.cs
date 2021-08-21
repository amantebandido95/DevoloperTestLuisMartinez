using CovidCasesReports.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace CovidCasesReports.Utils
{
    public class XMLMaker
    {
        public byte[] CreateRegionsXML(List<SimpleRegionReport> _Regions)
        {
            byte[] fileContent;

            using (var ms = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = (" "),
                    ConformanceLevel = ConformanceLevel.Fragment,
                    CloseOutput = true,
                    OmitXmlDeclaration = true
                };

                using (XmlWriter writer = XmlWriter.Create(ms, settings))
                {
                    writer.WriteStartElement("Regions");
                    foreach (SimpleRegionReport region in _Regions)
                    {
                        writer.WriteStartElement("Region");
                        writer.WriteAttributeString("RegionName", region.regionName);
                        writer.WriteAttributeString("Iso", region.iso);
                        writer.WriteAttributeString("Cases", region.cases.ToString());
                        writer.WriteAttributeString("Deaths", region.deaths.ToString());
                        writer.WriteEndElement();

                    }
                    writer.WriteEndElement();
                    writer.Flush();
                    fileContent = ms.GetBuffer();
                    writer.Close();

                }

            }
            return fileContent;
        }

        public byte[] CreateProvincesXML(List<SimpleProvinceReport> _Provinces)
        {
            byte[] fileContent;

            using (var ms = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = ("\t"),
                    ConformanceLevel = ConformanceLevel.Fragment,
                    CloseOutput = true,
                    OmitXmlDeclaration = true
                };

                using (XmlWriter writer = XmlWriter.Create(ms, settings))
                {
                    writer.WriteStartElement("Provinces");
                    foreach (SimpleProvinceReport province in _Provinces)
                    {
                        writer.WriteStartElement("Province");
                        writer.WriteAttributeString("RegionName", province.regionName);
                        writer.WriteAttributeString("Province", province.provinceName);
                        writer.WriteAttributeString("Cases", province.cases.ToString());
                        writer.WriteAttributeString("Deaths", province.deaths.ToString());
                        writer.WriteEndElement();

                    }
                    writer.WriteEndElement();
                    writer.Flush();
                    fileContent = ms.GetBuffer();
                    writer.Close();
                }

            }

            return fileContent;
        }
    }
}
