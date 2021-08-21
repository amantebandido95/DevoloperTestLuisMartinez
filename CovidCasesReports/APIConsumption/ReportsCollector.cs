using CovidCasesReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils.APIConsumption;

namespace CovidCasesReports.APIConsumption
{
    public class ReportsCollector
    {
        private APIConsumer _APIConsumer = new APIConsumer();
        private DataPreparation _DataPreparation = new DataPreparation();

        public List<ReportsDatum> GetGlobalReport()
        {

            Reports ReporteRegion = _APIConsumer.GetGlobalReports().Result;

            List<ReportsDatum> ReporteRegionLista = new List<ReportsDatum>(ReporteRegion.data);

            //Top ten regions
            ReporteRegionLista = _DataPreparation.GetTopTenRegion(ReporteRegionLista);

            return ReporteRegionLista;
        }

        public List<ReportsDatum> GetGlobalReportByRegion(string iso)
        {

            Reports ReporteRegion = _APIConsumer.GetGlobalReportsByRegion(iso).Result;

            List<ReportsDatum> ReporteRegionLista = new List<ReportsDatum>(ReporteRegion.data);

            //Top ten regions
            ReporteRegionLista = _DataPreparation.GetTopTenRegion(ReporteRegionLista);

            return ReporteRegionLista;
        }
    }
}
