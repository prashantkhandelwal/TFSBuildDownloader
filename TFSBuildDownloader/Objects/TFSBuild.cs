using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSBuildDownloader.Objects
{
    internal class TFSBuild
    {
        public class Drop
        {
            public string location { get; set; }
            public string type { get; set; }
            public string url { get; set; }
            public string downloadUrl { get; set; }
        }

        public class Log
        {
            public string type { get; set; }
            public string url { get; set; }
            public string downloadUrl { get; set; }
        }

        public class LastChangedBy
        {
            public string id { get; set; }
            public string displayName { get; set; }
            public string uniqueName { get; set; }
            public string url { get; set; }
            public string imageUrl { get; set; }
        }

        public class Definition
        {
            public string definitionType { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Queue
        {
            public string queueType { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class RequestedFor
        {
            public string id { get; set; }
            public string displayName { get; set; }
            public string uniqueName { get; set; }
            public string url { get; set; }
            public string imageUrl { get; set; }
        }

        public class Request
        {
            public int id { get; set; }
            public string url { get; set; }
            public RequestedFor requestedFor { get; set; }
        }

        public class Value
        {
            public string uri { get; set; }
            public int id { get; set; }
            public string buildNumber { get; set; }
            public string url { get; set; }
            public string startTime { get; set; }
            public string finishTime { get; set; }
            public string reason { get; set; }
            public string status { get; set; }
            public string dropLocation { get; set; }
            public Drop drop { get; set; }
            public Log log { get; set; }
            public string sourceGetVersion { get; set; }
            public LastChangedBy lastChangedBy { get; set; }
            public bool retainIndefinitely { get; set; }
            public bool hasDiagnostics { get; set; }
            public Definition definition { get; set; }
            public Queue queue { get; set; }
            public List<Request> requests { get; set; }
        }

        public class RootObject
        {
            public List<Value> value { get; set; }
            public int count { get; set; }
        }
    }
}
