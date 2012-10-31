using System;
using System.Globalization;
using System.IO;
using System.Net;

namespace Generator2
{
    public static class Utilities
    {
        public static string FetchUrl(this string url, string filePath)
        {
            string path = Path.GetFullPath(filePath);

            string content = null;
            if (File.Exists(path))
            {
                Console.WriteLine("File exists {0}", path);

                content = File.ReadAllText(path);
            }
            else
            {
                Console.WriteLine("Fetching url {0}", url);
                WebClient c = new WebClient();
                content = c.DownloadString(url);
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                }

                Console.WriteLine("saving to {0}", path);
                File.WriteAllText(path, content);

            }
            return content;
        }
        public static string PascalCase(this string name)
        {
            TextInfo tinfo = new CultureInfo("en-US", false).TextInfo;
            string FixedName = name.Replace("_", " ").Replace("-", " ");
            FixedName = tinfo.ToTitleCase(FixedName).Replace(" ", "");
            return FixedName;
        }


    }
}