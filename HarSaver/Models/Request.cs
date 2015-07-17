using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HarSaver.Models
{
    public class Request
    {
        /// <summary>
        /// Request method (GET, POST, ...)
        /// </summary>
        [JsonProperty("metod")]
        public string Metod { get;  set; }
        /// <summary>
        /// Absolute URL of the request (fragments are not included)
        /// </summary>
        [JsonProperty("url")]
        public string Url { get;  set; }
        /// <summary>
        /// Request HTTP Version
        /// </summary>
        [JsonProperty("httpVersion")]
        public string HttpVersion { get;  set; }
        /// <summary>
        /// List of cookie objects
        /// </summary>
        [JsonProperty("cookies")]
        public List<Cookie> Cookies { get;  set; }
        /// <summary>
        /// List of header objects
        /// </summary>
        [JsonProperty("headers")]
        public List<Header> Headers { get;  set; }
        /// <summary>
        /// List of query parameter objects.
        /// </summary>
        [JsonProperty("queryString")]
        public List<QueryString> QuerySring { get;  set; }
        /// <summary>
        /// Posted data info.
        /// </summary>
        [JsonProperty("postData")]
        public PostData PostData { get;  set; }
        /// <summary>
        /// Total number of bytes from the start of the HTTP 
        /// request message until (and including) the double 
        /// CRLF before the body. internal set to -1 if the info is not 
        /// available.
        /// </summary>
        [JsonProperty("headerSize")]
        public double HeaderSize { get;  set; }
        /// <summary>
        /// Size of the request body (POST data payload) in bytes. internal set to -1 if the info is not available.
        /// </summary>
        [JsonProperty("bodySize")]
        public double BodySize { get;  set; }
        /// <summary>
        /// A comment provided by the user or the application.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get;  set; }

    }
}
