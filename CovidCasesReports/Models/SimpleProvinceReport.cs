using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCasesReports.Models
{
    public class SimpleProvinceReport
    {
        public string provinceName { get; set; }
        public string regionName { get; set; }
        public int cases { get; set; }
        public int deaths { get; set; }
    }
}
