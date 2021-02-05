using System;
using System.IO;
using System.Text;

namespace CommandLine.helpers
{
    public class Command
    {
        /// <summary>
        /// creates a file in directory
        /// </summary>
        /// <param name="command"></param>
        public void TouchFile(string command)
        {
            var fileName = command.Replace("touch ", "");
            try
            {
                using (FileStream fs = File.Create(Directory.GetCurrentDirectory() + "/" + fileName))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("test");
                    fs.Write(info, 0, info.Length);
                }
                using (FileStream fs = File.Create(Directory.GetCurrentDirectory() + "/" + fileName))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("test");
                    fs.Write(info, 0, info.Length);
                }
                Console.WriteLine("File " + fileName + " Created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Moves file to another directory if a directory is specified, otherwise it changes file's name
        /// </summary>
        /// <param name="command"></param>
        public void ChangeFile(string command)
        {
            string[] files = command.Split(" ");
            try
            {
                File.Move(files[1], files[2]);
                FileAttributes attr = File.GetAttributes(files[1]);

                if (attr.HasFlag(FileAttributes.Directory))
                    Console.WriteLine("Directory " + files[1] + " changed to " + files[2]);
                else
                    Console.WriteLine("File  " + files[1] + " renamed to " + files[2]);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// lists all the files in the directory
        /// </summary>
        public void ListFiles()
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// lists all the files in directory with its children
        /// </summary>
        public void ListFilesRecursive()
        {
            var directory = Directory.GetCurrentDirectory();
            try
            {
                foreach (string file in Directory.GetFiles(
                directory, "*", SearchOption.AllDirectories))
                {
                    Console.WriteLine(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Changes to the specified directory
        /// </summary>
        /// <param name="command"></param>
        public void ChangeDirectory(string command)
        {
            var directory = command.Replace("cd ", "");
            try
            {
                Directory.SetCurrentDirectory(directory);
                Console.WriteLine("Directory is now pointing to " + Directory.GetCurrentDirectory());
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("The specified directory does not exist. {0}", e);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// shows all the available commands
        /// </summary>
        /// <param name="command"></param>
        public void HelpCommand(string command)
        {
            switch (command.Replace("help ", ""))
            {
                case "touch":
                    Console.WriteLine(CommandList.Touch);
                    break;
                case "mv":
                    Console.WriteLine(CommandList.Mv);
                    break;
                case "ls":
                    Console.WriteLine(CommandList.Ls);
                    break;
                case "ls -R":
                    Console.WriteLine(CommandList.LsRecursive);
                    break;
                case "cd":
                    Console.WriteLine(CommandList.Cd);
                    break;
                default:
                    Console.WriteLine(CommandList.NotFound);
                    break;
            }
            Console.WriteLine();
        }

        public void NotFound(string command)
        {
            Console.WriteLine("The command " + command + " was not found");
            Console.WriteLine();
        }

        /// <summary>
        /// exit the application
        /// </summary>
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
