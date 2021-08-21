using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CovidCasesReports.APIConsumption;
using Microsoft.AspNetCore.Mvc.Rendering;
using Utils.APIConsumption;

namespace CovidCasesReports.Models
{

    public class Reports
    {
        public ReportsDatum[] data { get; set; }
        
    }

    public class ReportsDatum
    {
        public string date { get; set; }
        public int confirmed { get; set; }
        public int deaths { get; set; }
        public int recovered { get; set; }
        public int confirmed_diff { get; set; }
        public int deaths_diff { get; set; }
        public int recovered_diff { get; set; }
        public string last_update { get; set; }
        public int active { get; set; }
        public int active_diff { get; set; }
        public float fatality_rate { get; set; }
        public Region region { get; set; }
    }


    public class Region
    {
        public string iso { get; set; }
        public string name { get; set; }
        public string province { get; set; }
        public string lat { get; set; }
        public string _long { get; set; }
        public City[] cities { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string date { get; set; }
        public int? fips { get; set; }
        public string lat { get; set; }
        public string _long { get; set; }
        public int confirmed { get; set; }
        public int deaths { get; set; }
        public int confirmed_diff { get; set; }
        public int deaths_diff { get; set; }
        public string last_update { get; set; }
    }

}
