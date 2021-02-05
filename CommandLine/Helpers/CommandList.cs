using System;
using System.Collections.Generic;
using System.Text;

namespace CommandLine.helpers
{
    public static class CommandList
    {
        public const string Touch = "touch [filename] = Creates a new file with the following name and extension";
        public const string Mv = "mv [file1] [file2] = Changes file name, mv [path1] [path2] = Moves file to another directory";
        public const string Ls = "Show files in directory";
        public const string LsRecursive = "Shows recursively files in directory";
        public const string Cd = "allows to navigate throw different directories";
        public const string NotFound = "Command not found, ex: help touch";
    }
}
