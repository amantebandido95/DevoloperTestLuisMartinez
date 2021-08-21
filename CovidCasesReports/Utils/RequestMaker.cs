using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Utils.APIConsumption
{
    public class RequestMaker
    {
        public HttpRequestMessage APIRequestMaker(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "x-rapidapi-key", "0a81c58c21msh6b27956ad23fba9p116c21jsn4fb7228b1399" },
                    { "x-rapidapi-host", "covid-19-statistics.p.rapidapi.com" },
                },
            };

            return request;
        }
    }
}
