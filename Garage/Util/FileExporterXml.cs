using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Garage.Model;

namespace Garage.Util
{
    public class FileExporterXml : IFileExporter
    {
        public void Export(IEnumerable<GatekeeperReport> report, string fileName)
        {
            var reportList = report.ToList();
            var serializer = new XmlSerializer(typeof(List<GatekeeperReport>));
            serializer.Serialize(File.CreateText(fileName), reportList);
        }
    }
}