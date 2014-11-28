using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TFSBuildDownloader.Objects;

namespace TFSBuildDownloader.Functions
{
    internal class Utils
    {
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static T DeserializeJSON<T>(string JsonResponse) where T : class
        {
            return JsonConvert.DeserializeObject<T>(JsonResponse);
        }

        //Stole from http://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc
        public static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }
    }
}
