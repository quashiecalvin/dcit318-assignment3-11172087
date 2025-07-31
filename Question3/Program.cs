using System;

namespace Question3
{
    class Program
    {
        static void Main(string[] args)
        {
            WareHouseManager manager = new WareHouseManager();
            manager.SeedData();

            Console.WriteLine("---- ELECTRONIC ITEMS ----");
            manager.PrintAllItems(manager.GetElectronicsRepo());

            Console.WriteLine("\n---- GROCERY ITEMS ----");
            manager.PrintAllItems(manager.GetGroceriesRepo());

            Console.WriteLine("\n---- INCREASING STOCK FOR ELECTRONICS (ID = 1, +5 units) ----");
            manager.IncreaseStock(manager.GetElectronicsRepo(), 1, 5);

            Console.WriteLine("\n---- INCREASING STOCK FOR GROCERIES (ID = 2, +10 units) ----");
            manager.IncreaseStock(manager.GetGroceriesRepo(), 2, 10);

            Console.WriteLine("\n---- REMOVING ELECTRONIC ITEM (ID = 3) ----");
            manager.RemoveItemById(manager.GetElectronicsRepo(), 3);

            Console.WriteLine("\n---- FINAL ELECTRONIC ITEMS ----");
            manager.PrintAllItems(manager.GetElectronicsRepo());
        }
    }
}
