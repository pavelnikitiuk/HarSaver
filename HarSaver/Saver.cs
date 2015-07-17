using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using HarSaver.Models;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

namespace HarSaver
{
    public class Saver
    {
        private Har document;
        private string path;
        private Regex illegalPathRegex;
        private Regex illegalFileRegex;

        private List<Entrie> loadFailed;

        public int FileLoad
        {
            get
            {
                return document.Log.Entries.Count;
            }
        }

        public int FailedLoadCount
        {
            get
            {
                return loadFailed.Count;
            }
        }

        




        public void Load(string json)
        {
            try
            {
                document = JsonConvert.DeserializeObject<Har>(json);
            }
            catch
            {
                throw;
            }
            loadFailed = new List<Entrie>();

        }

        public IEnumerable<string> TryToReload()
        {


            foreach (var entrie in loadFailed.ToList())
            {
                bool hasLoad = true;
                string filePath = "";
                try
                {
                    filePath = AssembleFilePath(entrie.Request.Url);
                    var fileFloder = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(fileFloder);
                    if (Path.GetExtension(filePath) == String.Empty)
                    {
                        var name = CreateFileName(entrie);
                        if (name == String.Empty)
                            continue;
                        filePath += name;
                    }
                    LoadUrl(entrie.Request.Url, filePath);

                    loadFailed.Remove(entrie);
                }
                catch (WebException)
                {

                    hasLoad = false;
                }


                yield return hasLoad ? filePath : String.Empty;


            }
            yield break;


        }

        public void SaveInFloder(string path)
        {
            if (path == null)
                throw new ArgumentNullException();
            if (document == null)
                throw new NullReferenceException();

            this.path = path.Trim('\\');


            illegalPathRegex = new Regex(string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidPathChars()) + "*")));
            illegalFileRegex = new Regex(string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidFileNameChars())+"*")));


            foreach (var entrie in document.Log.Entries)
            {
                if (entrie.Response.Status > 399 || entrie.Response.Status < 100)
                {
                    loadFailed.Add(entrie);
                    continue;
                }
                var filePath = AssembleFilePath(entrie.Request.Url);

                if (Path.GetExtension(filePath) == String.Empty)
                {
                    var fileName = CreateFileName(entrie);
                    if (fileName == String.Empty)
                    {
                        loadFailed.Add(entrie);
                        continue;
                    }
                    filePath += fileName;
                }

                filePath = illegalPathRegex.Replace(filePath, "");

                Save(filePath, entrie);
            }
        }
        #region PrivateMetods

        private void Save(string filePath, Entrie entrie)
        {
            var floderPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(floderPath))
                Directory.CreateDirectory(floderPath);

            if (entrie.Response.Content.Text != null)
                if (entrie.Response.Content.Encoding == null)
                    SaveFile(filePath, entrie.Response.Content.Text);
                else
                    SaveByte(filePath, entrie.Response.Content.Text);
        }

        private void LoadUrl(string url, string filePath)
        {
            using (var myWebClient = new WebClient())
            {
                myWebClient.Headers["User-Agent"] = "MOZILLA/5.0 (WINDOWS NT 6.1; WOW64) APPLEWEBKIT/537.1 (KHTML, LIKE GECKO) CHROME/21.0.1180.75 SAFARI/537.1";
                myWebClient.DownloadFile(url, filePath);
            }
        }

        private string CreateFileName(Entrie entrie)
        {
            string name = "";
            string extension = "";
            switch (entrie.Response.Content.MimeType)
            {
                case "text/html":
                    if (entrie.Response.Content.Text != null)
                    {
                        name = ExtractTitle(entrie.Response.Content.Text);
                        extension = ".html";
                    }

                    else
                        return String.Empty;
                    break;

                case "text/javascript":
                    name = "";
                    extension = ".js";
                    break;
                case "x-unknown":
                    name = "";
                    extension = "";
                    break;
                default:
                    name = entrie.StartedDateTime;
                    extension = String.Format(".{0}", entrie.Response.Content.MimeType.Split('/')[1]);
                    break;
            }
            return String.Format("\\{0}{1}", illegalFileRegex.Replace(name, ""), extension);
        }

        private string ExtractTitle(string html)
        {
            return Regex.Match(html, @"\<title\>(.*)\</title\>").Groups[1].ToString();
        }

        private void SaveByte(string path, string content)
        {
            var encodingContent = Convert.FromBase64String(content);
            File.WriteAllBytes(path, encodingContent);
        }
        private void SaveFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        private string AssembleFilePath(string url)
        {
            var uriPath = new Uri(url);

            StringBuilder localPath = new StringBuilder();

            localPath.Append(path);
            localPath.Append('\\');
            localPath.Append(uriPath.Host);
            for (int i = 0; i < uriPath.Segments.Length; i++)
            {
                var segment = uriPath.Segments[i].Replace('/', '\\');
                if (uriPath.Segments[i].Length > 30)
                    segment = segment.Substring(0, 30);
                localPath.Append(segment);
            }

            return localPath.ToString();
        }

        #endregion
    }
}
