namespace ExportSystem
{
    public class SalesDataProviderService : IDataProviderService
    {
        public IEnumerable<object> GetData()
        {
            return
            [
                new { OrderId = 1001, Customer = "Alice", Amount = 250.00, Date = DateTime.UtcNow.AddDays(-3) },
                new { OrderId = 1002, Customer = "Bob", Amount = 150.75, Date = DateTime.UtcNow.AddDays(-2) },
                new { OrderId = 1003, Customer = "Charlie", Amount = 999.99, Date = DateTime.UtcNow.AddDays(-1) }
            ];
        }
    }

    public class InventoryDataProviderService : IDataProviderService
    {
        public IEnumerable<object> GetData()
        {
            return
            [
                new { ProductId = 1, Name = "Laptop", Stock = 15, LastUpdated = DateTime.UtcNow.AddHours(-5) },
                new { ProductId = 2, Name = "Mouse", Stock = 120, LastUpdated = DateTime.UtcNow.AddHours(-3) },
                new { ProductId = 3, Name = "Keyboard", Stock = 75, LastUpdated = DateTime.UtcNow.AddHours(-1) }
            ];
        }
    }

    public class AnalyticsDataProviderService : IDataProviderService
    {
        public IEnumerable<object> GetData()
        {
            return
            [
                new { UserId = 1, SessionLength = 35, PagesVisited = 7, Date = DateTime.UtcNow },
                new { UserId = 2, SessionLength = 12, PagesVisited = 3, Date = DateTime.UtcNow },
                new { UserId = 3, SessionLength = 58, PagesVisited = 12, Date = DateTime.UtcNow }
            ];
        }
    }
}
