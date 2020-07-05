using System.Collections.Generic;
using System.IO;
using Garage.Model;

namespace Garage.Util
{
    public class FileExporterCsv : IFileExporter
    {
        public void Export(IEnumerable<GatekeeperReport> report, string fileName)
        {
            using (var stream = File.CreateText(fileName))
            {
                stream.WriteLine($"Vevő;Engedmény;Rendszám;-tól;-ig;Időtartam");
                foreach (var line in report)
                {
                    stream.WriteLine($"{line.Partner};{line.Discount};{line.LicensePlate};{line.Begin};{line.End};{line.Offset}");
                }
            }
        }
    }
}