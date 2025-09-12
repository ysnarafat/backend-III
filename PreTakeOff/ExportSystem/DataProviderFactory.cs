namespace ExportSystem
{
    public class DataProviderFactory
    {
        public static IDataProviderService GetDataProvider(DataType dataType) => dataType switch
        {
            DataType.Sales => new SalesDataProviderService(),
            DataType.Inventory => new InventoryDataProviderService(),
            DataType.Analytics => new AnalyticsDataProviderService(),
            _ => throw new NotSupportedException($"Data type {dataType} is not supported.")
        };
    }

    public enum DataType
    {
        Sales,
        Inventory,
        Analytics
    }
}
