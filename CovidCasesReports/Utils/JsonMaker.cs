using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidCasesReports.Utils
{
    public class JsonMaker
    {
        public byte[] SerializeJson(object value, JsonSerializerSettings jsonSerializerSettings)
        {
            var result = JsonConvert.SerializeObject(value, jsonSerializerSettings);

            result = JsonConvert.SerializeObject(value, Formatting.Indented);

            return Encoding.UTF8.GetBytes(result);
        }

    }
}
