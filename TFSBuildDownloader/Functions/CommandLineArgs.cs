using System;

namespace TFSBuildDownloader.Functions
{
    internal class CommandLineArgs
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CollectionURL { get; set; }
        public string ProjectName { get; set; }
        public string BuildNumber { get; set; }
        public string OutputFile { get; set; }
        public bool IsDownload { get; set; }
        internal CommandLineArgs(string[] args)
        {
            foreach (string arg in args)
            {
                if(arg.StartsWith("-"))
                {
                    if(arg == "-n")     //user name
                    {
                        UserName = args[1];
                    }
                    if(arg == "-p")     //password
                    {
                        Password = args[3];
                    }
                    if(arg == "-c")     //collection url
                    {
                        CollectionURL = args[5];
                    }
                    if(arg == "-t")     //project name
                    {
                        ProjectName = args[7];
                    }
                    if(arg == "-b")     //build number
                    {
                        BuildNumber = args[9];
                    }
                    if (arg == "-o")     //output file
                    {
                        OutputFile = args[11];
                    }
                    if (arg == "-d")      //no output on console. Just start download
                    {
                        IsDownload = true;
                    }
                }
            }
        }
    }
}
