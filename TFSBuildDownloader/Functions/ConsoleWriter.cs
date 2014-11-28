using System;
using TFSBuildDownloader.Objects;

namespace TFSBuildDownloader.Functions
{
    internal class ConsoleWriter
    {
        static ConsoleColor originalColor = ConsoleColor.Gray;
        static ConsoleColor errorColor = ConsoleColor.Red;
        static ConsoleColor successColor = ConsoleColor.Yellow;
        static ConsoleColor infoColor = ConsoleColor.Blue;
        internal static void Write(string message, MessageType msgType)
        {
            switch (msgType)
            {
                case MessageType.Success:
                    Console.ForegroundColor = successColor;
                    Console.WriteLine(message);
                    break;
                case MessageType.Error:
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine(message);
                    break;
                case MessageType.Information:
                    Console.ForegroundColor = infoColor;
                    Console.WriteLine(message);
                    break;
                default:
                    Console.ForegroundColor = originalColor;
                    Console.WriteLine(message);
                    break;
            }
        }
    }
}
