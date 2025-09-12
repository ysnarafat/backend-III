namespace ExportSystem
{
    public class PdfExporter : IExporter
    {
        public void Export(IEnumerable<object> data, string destination)
        {
            Console.WriteLine($"Exporting in {destination} to PDF with {data.Count()} records...");
        }
    }

    public class ExcelExporter : IExporter
    {
        public void Export(IEnumerable<object> data, string destination)
        {
            Console.WriteLine($"Exporting in {destination} to Excel with {data.Count()} records...");
        }
    }

    public class CsvExporter : IExporter
    {
        public void Export(IEnumerable<object> data, string destination)
        {
            Console.WriteLine($"Exporting in {destination} to CSV with {data.Count()} records...");
        }
    }
}
