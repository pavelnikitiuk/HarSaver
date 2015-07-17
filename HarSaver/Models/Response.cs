using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HarSaver.Models
{
    public class Response
    {
        /// <summary>
        /// Response status.
        /// </summary>
        [JsonProperty("status")]
        public int Status { get;  set; }
        /// <summary>
        /// Response status description.
        /// </summary>
        [JsonProperty("statusText")]
        public string StatusText { get;  set; }
        /// <summary>
        /// Response HTTP Version.
        /// </summary>
        [JsonProperty("httpVersion")]
        public string HttpVersion { get;  set; }
        /// <summary>
        /// List of cookie objects.
        /// </summary>
        [JsonProperty("cookies")]
        public List<Cookie> Cookies { get;  set; }
        /// <summary>
        /// List of header objects.
        /// </summary>
        [JsonProperty("headers")]
        public List<Header> Headers { get;  set; }
        /// <summary>
        /// Details about the response body.
        /// </summary>
        [JsonProperty("content")]
        public Content Content { get;  set; }
        [JsonProperty("headerSize")]
        public int HeadersSize { get;  set; }
        [JsonProperty("bodySize")]
        public int BodySize { get;  set; }
        [JsonProperty("_transferSize")]
        public int TransferSize { get;  set; }
        [JsonProperty("_error")]
        public string Error { get;  set; }

    }
}
