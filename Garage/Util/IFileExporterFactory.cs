namespace Garage.Util
{
    public interface IFileExporterFactory
    {
        IFileExporter Create(FileFormat fileFormat);
    }
}