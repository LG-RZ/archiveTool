using CommandLine;
using igArchiveLib;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace archiveTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(ProcessOptions);
        }

        static void ProcessOptions(Options options)
        {
            if (options.Directory == null && options.ArchivePath == null)
                throw new Exception("No mode specified");
            if (options.Directory != null && options.ArchivePath != null)
                throw new Exception("Can't have directory and archive at the same time!");

            if (options.ArchivePath != null)
                ProcessIGA(options.ArchivePath, options.Path, options.UseLogicalName);
            else
                ProcessWrite(options.Directory, options.Path, options.CompressionMode);
        }

        static void ProcessIGA(string ArchivePath, string ExtractTo, bool UseLogicalName = true)
        {
            if (!File.Exists(ArchivePath))
                throw new Exception("igArchive doesn't exist!");

            Console.WriteLine("Opening igArchive.");

            igArchive archive = new igArchive();
            archive.open(ArchivePath);
            
            Console.WriteLine("Extracting Files.");

            //Stopwatch watch = Stopwatch.StartNew();

            for(int i = 0; i < archive._fileInfoTable.Length; i++)
            {
                string DesiredPath = Path.Combine(ExtractTo, UseLogicalName ? archive._logicalNameTable[i] : archive._nameTable[i]);
                Directory.CreateDirectory(Path.GetDirectoryName(DesiredPath));
                File.WriteAllBytes(DesiredPath, archive.read(archive._fileInfoTable[i]));
            }
            archive.close();
            //watch.Stop();

            Console.WriteLine("Archive extraction complete!");
            //Console.WriteLine("Time elapsed: {0}s", watch.Elapsed.TotalSeconds);
        }

        static void ProcessWrite(string Directory, string ArchivePath, int CompressionMode)
        {
            if (CompressionMode > 3 || CompressionMode < 0)
                throw new Exception("Invalid Compression Mode!");

            Console.WriteLine("Creating igArchive.");
            igArchive archive = new igArchive();
            archive.createFromDirectory(ArchivePath, Path.GetDirectoryName(Directory), (igArchive.CompressionType)CompressionMode, PercentageReport: (percentage) =>
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.Write("\rProcessed: {0}% of Files.", (int)(percentage * 100f));
            });
            Console.WriteLine();
            Console.WriteLine("igArchive has been created sucessfully.");
            archive.close();
        }
    }
}