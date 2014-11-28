using System;
using System.Collections.Generic;
using System.Linq;

using TFSBuildDownloader.Objects;
using TFSBuildDownloader.Functions;

namespace TFSBuildDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineArgs command = new CommandLineArgs(args);

            if(command.IsDownload && string.IsNullOrWhiteSpace(command.BuildNumber))
            {
                ConsoleWriter.Write("Cannot download build. Enter a valid build ID to download.", MessageType.Error);
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }
            if(string.IsNullOrWhiteSpace(command.ProjectName) && !string.IsNullOrWhiteSpace(command.BuildNumber))
            {
                ConsoleWriter.Write("No project name specified.", MessageType.Error);
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            TFS _tfs = new TFS(command.UserName, command.Password, command.CollectionURL, command.ProjectName, command.BuildNumber);
            TFSBuild.RootObject obj = _tfs.GetBuilds().Result;

            if (obj != null)
            {
                List<TFSBuild.Value> v = obj.value;

                if (command.IsDownload)
                {
                    TFSBuild.Value buildDef = v.Single(x => x.buildNumber == command.BuildNumber);
                    if (!string.IsNullOrEmpty(command.OutputFile))
                    {
                        ConsoleWriter.Write("Download destination: " + command.OutputFile, MessageType.Information);
                        ConsoleWriter.Write("Initiating download..." + command.OutputFile, MessageType.Information);
                        DownloadBuild _buildDownloader = new DownloadBuild(buildDef.drop.downloadUrl, command.OutputFile + command.BuildNumber + ".zip");
                        
                        _buildDownloader.Download();
                        ConsoleWriter.Write("Download Successfull!!" + command.OutputFile, MessageType.Information);
                    }
                    else
                    {
                        ConsoleWriter.Write("Download destination: " + command.OutputFile, MessageType.Information);
                        DownloadBuild _buildDownloader = new DownloadBuild(buildDef.drop.downloadUrl, command.BuildNumber + ".zip");
                        _buildDownloader.Download();
                        ConsoleWriter.Write("Download Successfull!!" + command.OutputFile, MessageType.Information);
                    }
                }
                else
                {
                    foreach (var _value in v)
                    {
                        ConsoleWriter.Write("Build Number: " + _value.buildNumber, MessageType.Success);
                        ConsoleWriter.Write("Download URL: " + _value.drop.downloadUrl, MessageType.Success);
                        ConsoleWriter.Write("------------------------------------------------------------------", MessageType.Success);
                    }
                }
            }
            //restore the original console foreground color
            ConsoleWriter.Write("Press any key to exit..." + command.OutputFile, MessageType.Information);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }
    }
}
