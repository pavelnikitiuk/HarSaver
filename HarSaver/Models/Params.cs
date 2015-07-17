using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HarSaver.Models
{
    public class Params
    {
        /// <summary>
        /// Name of a posted parameter.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get;  set; }
        /// <summary>
        /// Value of a posted parameter or content of a posted file.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get;  set; }
        /// <summary>
        /// Name of a posted file.
        /// </summary>
        [JsonProperty("fileName")]
        public string FileName { get;  set; }
        /// <summary>
        /// Content type of a posted file.
        /// </summary>
        [JsonProperty("contentType")]
        public string ContentType { get;  set; }
        /// <summary>
        /// A comment provided by the user or the applocation
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get;  set; }
    }
}
