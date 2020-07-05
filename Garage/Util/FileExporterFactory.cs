using System;

namespace Garage.Util
{
    public class FileExporterFactory : IFileExporterFactory
    {
        public IFileExporter Create(FileFormat fileFormat)
        {
            switch (fileFormat)
            {
                case FileFormat.Csv:
                    return new FileExporterCsv();
                case FileFormat.Xml:
                    return new FileExporterXml();
                case FileFormat.Json:
                    return new FileExporterJson();

                default:
                    throw new ArgumentOutOfRangeException(nameof(fileFormat), "Unsupported file format");
            }
        }
    }
}