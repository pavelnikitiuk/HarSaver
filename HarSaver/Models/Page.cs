using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HarSaver.Models
{
    public class Page
    {
        [JsonProperty("startedDateTime")]
        public string StartedDateTime { get;  set; }
        [JsonProperty("id")]
        public string Id { get;  set;}
        [JsonProperty("title")]
        public string Title { get;  set; }
        [JsonProperty("pageTimings")]
        public PageTimings PageTimings {get;  set;}
        [JsonProperty("comment")]
        public string Comment { get;  set; }
    }
}
