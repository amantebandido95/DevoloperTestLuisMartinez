using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidCasesReports.Models;

namespace Utils.APIConsumption
{
    public class DataPreparation
    {   
        /// <summary>
        /// Return the top 10 of region with more cases
        /// </summary>
        /// <param name="fullReportList"></param>
        /// <returns></returns>
        public List<ReportsDatum> GetTopTenRegion(List<ReportsDatum> fullReportList)
        {
            List<ReportsDatum> topTenRegionList = new List<ReportsDatum>();

             topTenRegionList = fullReportList.OrderByDescending(x => x.confirmed).Take(10).ToList();
            
     
            return topTenRegionList;

        }

        public List<SimpleRegionReport> getListForRegionReportDownload(List<ReportsDatum> _Regiones)
        {
            List<SimpleRegionReport> simpleRegionReport = new List<SimpleRegionReport>();

            foreach(ReportsDatum region in _Regiones)
            {
                SimpleRegionReport simpleRegion = new SimpleRegionReport();

                simpleRegion.regionName = region.region.name;
                simpleRegion.iso = region.region.iso;
                simpleRegion.cases = region.confirmed;
                simpleRegion.deaths = region.deaths;

                simpleRegionReport.Add(simpleRegion);
            }


            return simpleRegionReport;
        }

        public List<SimpleProvinceReport> getListForProvincesReportDownload(List<ReportsDatum> _Provinces)
        {
            List<SimpleProvinceReport> simpleProvincesReport = new List<SimpleProvinceReport>();

            foreach (ReportsDatum province in _Provinces)
            {
                SimpleProvinceReport simpleProvince = new SimpleProvinceReport();

                simpleProvince.regionName = province.region.name;
                simpleProvince.provinceName = province.region.province == "" ? province.region.name : province.region.province;
                simpleProvince.cases = province.confirmed;
                simpleProvince.deaths = province.deaths;

                simpleProvincesReport.Add(simpleProvince);
            }


            return simpleProvincesReport;
        }

    }
}
