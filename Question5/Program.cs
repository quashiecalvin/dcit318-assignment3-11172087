class Program
{
    static void Main()
    {
        string filePath = "inventory.json";
        var app = new InventoryApp(filePath);

        app.SeedSampleData();
        app.SaveData();

        Console.WriteLine("\nSimulating new session...\n");

        var newApp = new InventoryApp(filePath);
        newApp.LoadData();
        newApp.PrintAllItems();
    }
}
