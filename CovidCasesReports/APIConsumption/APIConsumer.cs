using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CovidCasesReports.Models;
using Utils.APIConsumption;

namespace CovidCasesReports.APIConsumption
{
 

        public class APIConsumer
        {
            public Reports _Reports { get; set; } = new Reports();
            private RequestMaker _RequestMaker = new RequestMaker();

            /// <summary>
            /// This methods gets the global report of cases by region
            /// </summary>
            /// <returns></returns>
            public async Task<Reports> GetGlobalReports()
            {
                string url = "https://covid-19-statistics.p.rapidapi.com/reports";
                var client = new HttpClient();
                var request = _RequestMaker.APIRequestMaker(url);

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var json = await response.Content.ReadAsStringAsync();
                    _Reports = JsonConvert.DeserializeObject<Reports>(json);

                 return _Reports;
                }


            }

        /// <summary>
        /// This method gets the whole report of cases by region
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        public async Task<Reports> GetGlobalReportsByRegion(string iso)
        {
            string url = "https://covid-19-statistics.p.rapidapi.com/reports?iso=" + iso;
            var client = new HttpClient();
            var request = _RequestMaker.APIRequestMaker(url);

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                _Reports = JsonConvert.DeserializeObject<Reports>(json);

                return _Reports;
            }


        }
    }
    
}
