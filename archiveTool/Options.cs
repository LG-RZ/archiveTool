using CommandLine;

namespace archiveTool
{
    public class Options
    {
        [Option('d', "directory", Required = false, HelpText = "The path of the Directory you want to archive.")]
        public string Directory { get; set; }

        [Option('i', "iga", Required = false, HelpText = "The path of the desired igArchive.")]
        public string ArchivePath { get; set; }

        [Option('p', "path", Required = true, HelpText = "The path of where you want to write an igArchive or extract files from an igArchive.")]
        public string Path { get; set; }

        [Option('c', "compression", Default = 2, Required = false, HelpText = "The desired compression mode for writing an igArchive: " +
            "\n0: No compression." +
            "\n1: Zlib compression (average compression ratio, average decompression performance)." +
            "\n2: Lzma compression (best compression ratio, slowest decompression performance)." +
            "\n3: Lz4 compression (poorest compression ratio, fastest decompression performance).")]
        public int CompressionMode { get; set; }

        [Option('l', "logicalName", Default = true, Required = false, HelpText = "Use the logical name of the files when extracting from an igArchive.")]
        public bool UseLogicalName { get; set; }
    }
}
