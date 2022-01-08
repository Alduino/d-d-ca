using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security;
using DDCA.NameSorter.Loader;
using DDCA.NameSorter.Output;
using DDCA.NameSorter.Parser;
using DDCA.NameSorter.Serialiser;

namespace DDCA.NameSorter
{
    class Program
    {
        private const string OutputPath = "sorted-names-list.txt";
        
        private static void Main(string[] args)
        {
            var path = ReadPathFromArgs(args);
            var names = ReadNamesFromPath(path);

            var comparer = new FullNameComparer();

            var namesList = names.ToList();
            namesList.Sort(comparer);

            var serialiser = new FullNameStandardStringSerialiser();
            var stdOutput = new FullNameStandardOutput(serialiser);
            var fileOutput = new FullNameFileLinesOutput(serialiser, OutputPath);

            stdOutput.WriteToOutput(namesList);
            fileOutput.WriteToOutput(namesList);
        }

        private static void DisplayUsage()
        {
            var appName = AppDomain.CurrentDomain.FriendlyName;

            Console.Error.WriteLine("=-=-= Name Sorter Usage =-=-=");
            Console.Error.WriteLine($"{appName} [file]");
            Console.Error.WriteLine("file: Path to a line-separated file of full names");
        }

        private static void Exit(int code = 0)
        {
            Environment.Exit(code);
        }

        private static IEnumerable<IFullName> ReadNamesFromPath(string path)
        {
            try
            {
                var parser = new FullNameStringParser();
                var loader = new FullNameStringLoader(parser);
                var reader = new FullNameFileReader(loader);

                return reader.ReadFromFileLines(path);
            }
            catch (Exception ex) when (ex is ArgumentException or IOException or SecurityException
                                           or UnauthorizedAccessException)
            {
                Console.Error.WriteLine("Could not read input file: {0}", ex.Message);
                Exit();

                // should never happen
                return null;
            }
        }

        private static string ReadPathFromArgs(string[] args)
        {
            var parser = new CommandLineParser(args);

            try
            {
                parser.AssertMaximumParameterCount(1);
                return parser.ReadParameter(0, "file");
            }
            catch (Exception ex) when (ex is ConstraintException or IndexOutOfRangeException)
            {
                Console.Error.WriteLine("Invalid usage: {0}", ex.Message);
                Console.Error.WriteLine();
                DisplayUsage();
                Exit();

                // should never happen
                return null;
            }
        }
    }
}