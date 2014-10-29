using System;
using System.IO;

namespace Rovers.Test
{
    // NOTE: Normally one would use a testing tool (MSTest, NUnit. etc) instead of a custom executable.
    // For the sake of not depending on external tools which might be not available on target machine, this simple test is implemented as standalone commandline executable.
    class Program
    {
        static void Main(string[] args)
        {
            TestAll();

            Console.WriteLine();
            Console.WriteLine("Press Any Key To Exit");
            Console.Read();
        }

        private static void TestAll()
        {
            var dir = new DirectoryInfo(@"..\..\Input");
            var files = dir.GetFiles(@"*.txt");
            foreach (var file in files)
            {
                try
                {
                    WriteSeparation();
                    Console.WriteLine(file.Name + ":\n");
                    WriteSeparation();

                    var outFile = GenerateOutputFileName(file);
                    var app = new Rovers.App.RoversApplication(file.FullName, outFile);
                    app.CalculateFinalRoversDeployment();
                    PrintFile(outFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void PrintFile(string outFile)
        {
            Console.WriteLine(File.ReadAllText(outFile));
        }

        private static string GenerateOutputFileName(FileInfo file)
        {
            return Path.GetFileNameWithoutExtension(file.FullName) + ".out.txt";
        }

        private static void WriteSeparation()
        {
            Console.WriteLine(new string('-', 20));
        }
    }
}
