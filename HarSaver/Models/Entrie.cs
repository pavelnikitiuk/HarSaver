using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HarSaver.Models
{

    public class Entrie
    {

        /// <summary>
        /// Reference to the parent page. Leave out this field if the application does not support grouping by pages.
        /// </summary>
        [JsonProperty("pageref")]
        public string Pageref { get;  set; }
        /// <summary>
        /// Date and time stamp of the request start (ISO 8601 - YYYY-MM-DDThh:mm:ss.sTZD).
        /// </summary>
        [JsonProperty("startedDateTime")]
        public string StartedDateTime { get;  set; }
        /// <summary>
        /// Total elapsed time of the request in milliseconds. This is the sum of all timings available in the timings object (i.e. not including -1 values) .
        /// </summary>
        [JsonProperty("time")]
        public double Time { get;  set; }
        /// <summary>
        /// Detailed info about the request.
        /// </summary>
        [JsonProperty("request")]
        public Request Request { get;  set; }
        /// <summary>
        /// Detailed info about the response.
        /// </summary>
        [JsonProperty("response")]
        public Response Response { get;  set; }
        public string Connection { get;  set; }
    }
}
