namespace ExportSystem
{
    public class ExporterFactory
    {
        public static IExporter GetExporter(ExportFormat format) => format switch
        {
            ExportFormat.Pdf => new PdfExporter(),
            ExportFormat.Excel => new ExcelExporter(),
            ExportFormat.Csv => new CsvExporter(),
            _ => throw new NotSupportedException($"Format {format} is not supported.")
        };
    }

    public enum ExportFormat
    {
        Pdf,
        Excel,
        Csv
    }
}
