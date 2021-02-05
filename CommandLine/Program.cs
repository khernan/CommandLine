using CommandLine.helpers;
using System;

namespace CommandLine
{
    class Program
    {
        static void Main()
        {
            Execute();
            Main();
        }

        /// <summary>
        /// Starts the command line functionality
        /// </summary>
        static void Execute()
        {
            Command commands = new Command();
            var input = "";
            Console.WriteLine("Introduce a command: ex: 'ls', type 'exit' to leave the application ");
            input = Console.ReadLine();

            switch (input)
            {
                case string s when s.StartsWith("touch "):
                    commands.TouchFile(input);
                    break;
                case string s when s.StartsWith("mv "):
                    commands.ChangeFile(input);
                    break;                
                case string s when s.StartsWith("ls"):
                    commands.ListFiles();
                    break;
                case string s when s.StartsWith("ls -R"):
                    commands.ListFilesRecursive();
                    break;
                case string s when s.StartsWith("cd "):
                    commands.ChangeDirectory(input);
                    break;
                case string s when s.StartsWith("help "):
                    commands.HelpCommand(input);
                    break;
                case "exit":
                    commands.Exit();
                    break;
                default:
                    commands.NotFound(input);
                    break;
            }
        }
    }
}