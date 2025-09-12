namespace ExportSystem
{
    public interface IExporter
    {
        public void Export(IEnumerable<object> data, string destination);
    }
}
