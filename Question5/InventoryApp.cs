using System;

public class InventoryApp
{
    private readonly InventoryLogger<InventoryItem> _logger;

    public InventoryApp(string filePath)
    {
        _logger = new InventoryLogger<InventoryItem>(filePath);
    }

    public void SeedSampleData()
    {
        _logger.Add(new InventoryItem(1, "iPhone 16 Pro", 10, DateTime.Now));
        _logger.Add(new InventoryItem(2, "iPad Air", 5, DateTime.Now));
        _logger.Add(new InventoryItem(3, "AirPods Pro", 25, DateTime.Now));
        _logger.Add(new InventoryItem(4, "Apple Watch", 15, DateTime.Now));
        _logger.Add(new InventoryItem(5, "Macbook Air", 40, DateTime.Now));
    }

    public void SaveData()
    {
        _logger.SaveToFile();
    }

    public void LoadData()
    {
        _logger.LoadFromFile();
    }

    public void PrintAllItems()
    {
        var items = _logger.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded}");
        }
    }
}
