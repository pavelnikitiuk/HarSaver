using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HarSaver.Models
{
    public class Browser
    {
        /// <summary>
        /// The name of the browser that created the log.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get;  set; }
        /// <summary>
        /// The version number of the browser that created the log.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get;  set; }
        /// <summary>
        /// A comment provided by the user or the browser.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get;  set; }
    }
}
