using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Garage.Model;

namespace Garage.Util
{
    public class FileExporterJson : IFileExporter
    {
        public void Export(IEnumerable<GatekeeperReport> report, string fileName)
        {
            string content = JsonSerializer.Serialize(report);
            File.WriteAllText(fileName, content);
        }
    }
}