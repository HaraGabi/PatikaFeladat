using System.Collections.Generic;
using Garage.Model;

namespace Garage.Util
{
    public interface IFileExporter
    {
        void Export(IEnumerable<GatekeeperReport> report, string fileName);
    }
}