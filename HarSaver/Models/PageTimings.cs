using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HarSaver.Models
{
    public class PageTimings
    {
        [JsonProperty("onContentLoad")]
        public double OnContentLoad { get;  set; }
        [JsonProperty("onLoad")]
        public double OnLoad { get;  set; }
        [JsonProperty("comment")]
        public string Comment { get;  set; }

    }
}
