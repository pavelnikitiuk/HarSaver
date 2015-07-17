using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HarSaver.Models
{
    public class QueryString
    {
        [JsonProperty("name")]
        public string Name { get;  set; }
        [JsonProperty("value")]
        public string Value { get;  set; }
        [JsonProperty("comment")]
        public string Comment { get;  set; }
    }
}
