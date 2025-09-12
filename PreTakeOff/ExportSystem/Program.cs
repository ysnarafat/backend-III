using ExportSystem;

public class Program
{
    public static void Main(string[] args)
    {
        ExportReport(DataType.Sales, ExportFormat.Pdf, "sales_report.pdf");
        ExportReport(DataType.Inventory, ExportFormat.Excel, "inventory_report.xlsx");
        ExportReport(DataType.Analytics, ExportFormat.Csv, "analytics_report.csv");
    }

    private static void ExportReport(DataType source, ExportFormat format, string destination)
    {
        var provider = DataProviderFactory.GetDataProvider(source);
        var data = provider.GetData();

        var exporter = ExporterFactory.GetExporter(format);
        exporter.Export(data, destination);
    }
}