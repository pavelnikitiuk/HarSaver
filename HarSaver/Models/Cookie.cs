using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HarSaver.Models
{
    /// <summary>
    /// Cookie of object
    /// </summary>
    public class Cookie
    {
        /// <summary>
        /// The name of the cookie
        /// </summary>
        [JsonProperty("name")]
        public string Name { get;  set; }
        /// <summary>
        /// The cookie value
        /// </summary>
        [JsonProperty("value")]
        public string Value { get;  set; }
        /// <summary>
        /// The path pertaining to the cookie
        /// </summary>
        [JsonProperty("path")]
        public string Path { get;  set; }
        /// <summary>
        /// The host of the cookie
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get;  set; }
        /// <summary>
        /// Cookie expiration time. (ISO 8601 - YYYY-MM-DDThh:mm:ss.sTZD,
        /// e.g. 2009-07-24T19:20:30.123+02:00)
        /// </summary>
        [JsonProperty("expires")]
        public string Expires { get;  set; }
        /// <summary>
        /// internal set to true if the cookie is HTTP only, false otherwise
        /// </summary>
        [JsonProperty("httpOnly")]
        public bool HttpOnly { get;  set; }
        /// <summary>
        /// True if the cookie was transmitted over ssl, false otherwise
        /// </summary>
        [JsonProperty("secure")]
        public bool Secure { get;  set; }
        /// <summary>
        ///  A comment provided by the user or the application
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get;  set; }

    }
}
