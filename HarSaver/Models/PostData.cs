using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HarSaver.Models
{
    public class PostData
    {
        /// <summary>
        /// Mime type of posted data.
        /// </summary>
        [JsonProperty("mimeType")]
        public string MimeType { get;  set; }
        /// <summary>
        ///  List of posted parameters (in case of URL encoded parameters).
        /// </summary>
        [JsonProperty("params")]
        public List<Params> Params { get;  set; }

    }
}
