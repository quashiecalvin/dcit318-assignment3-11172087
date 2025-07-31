using System;
using Question3.Interfaces;
using Question3.Models;
using Question3.Repositories;
using Question3.Exceptions;
using System.Collections.Generic;

namespace Question3
{
    public class WareHouseManager
    {
        private InventoryRepository<ElectronicItem> _electronics = new InventoryRepository<ElectronicItem>();
        private InventoryRepository<GroceryItem> _groceries = new InventoryRepository<GroceryItem>();

        public void SeedData()
        {
            try
            {
                _electronics.AddItem(new ElectronicItem(1, "Smartphone", 10, "Infinix", 24));
                _electronics.AddItem(new ElectronicItem(2, "Laptop", 5, "Apple", 12));
                _electronics.AddItem(new ElectronicItem(3, "TV", 2, "Hisense", 36));

                _groceries.AddItem(new GroceryItem(1, "Sardine", 50, DateTime.Now.AddDays(7)));
                _groceries.AddItem(new GroceryItem(2, "Ideal Milk", 20, DateTime.Now.AddDays(3)));
                _groceries.AddItem(new GroceryItem(3, "Milo", 30, DateTime.Now.AddDays(2)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error seeding data: {ex.Message}");
            }
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            List<T> items = repo.GetAllItems();
            if (items.Count == 0)
            {
                Console.WriteLine("No items found.");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                T item = repo.GetItemById(id);
                repo.UpdateQuantity(id, item.Quantity + quantity);
                Console.WriteLine($"Updated quantity for item ID {id} to {item.Quantity + quantity}");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Item not found: {ex.Message}");
            }
            catch (InvalidQuantityException ex)
            {
                Console.WriteLine($"Invalid quantity: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.WriteLine($"Item with ID {id} removed.");
            }
            catch (ItemNotFoundException ex)
            {
                Console.WriteLine($"Remove failed: {ex.Message}");
            }
        }

        // These methods are needed to give access in Main
        public InventoryRepository<ElectronicItem> GetElectronicsRepo() => _electronics;
        public InventoryRepository<GroceryItem> GetGroceriesRepo() => _groceries;
    }
}
