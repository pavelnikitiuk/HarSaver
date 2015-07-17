using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HarSaver.Models
{
    public class Log
    {
        /// <summary>
        /// Version number of the format.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get;  set; }
        /// <summary>
        /// An object of type creator that contains the name and version 
        /// information of the log creator application.
        /// </summary>
        [JsonProperty("creator")]
        public Creator Creator { get;  set; }
        /// <summary>
        /// An object of type browser that contains the name and version
        /// information of the user agent.
        /// </summary>
        [JsonProperty(PropertyName = "browser")]
        public Browser Browser { get;  set; }
        /// <summary>
        /// An array of objects of type page, each representing one exported
        /// (tracked) page. Leave out this field if the application does not
        /// support grouping by pages.
        /// </summary>
        [JsonProperty("pages")]
        public List<Page> Pages { get;  set; }
        /// <summary>
        /// An array of objects of type entry, each representing one exported 
        /// (tracked) HTTP request.
        /// </summary>
        [JsonProperty("entries")]
        public List<Entrie> Entries { get;  set; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get;  set; }
        
    }
}
