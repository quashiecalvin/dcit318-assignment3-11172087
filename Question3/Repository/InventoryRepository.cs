using System;
using System.Collections.Generic;
using Question3.Interfaces;
using Question3.Exceptions;

namespace Question3.Repositories
{
    public class InventoryRepository<T> where T : IInventoryItem
    {
        private Dictionary<int, T> _items = new Dictionary<int, T>();

        public void AddItem(T item)
        {
            if (_items.ContainsKey(item.Id))
            {
                throw new DuplicateItemException($"Item with ID {item.Id} already exists.");
            }

            _items[item.Id] = item;
        }

        public T GetItemById(int id)
        {
            if (_items.TryGetValue(id, out T item))
            {
                return item;
            }

            throw new ItemNotFoundException($"Item with ID {id} not found.");
        }

        public void RemoveItem(int id)
        {
            if (!_items.Remove(id))
            {
                throw new ItemNotFoundException($"Item with ID {id} not found.");
            }
        }

        public List<T> GetAllItems()
        {
            return new List<T>(_items.Values);
        }

        public void UpdateQuantity(int id, int newQuantity)
        {
            if (newQuantity < 0)
            {
                throw new InvalidQuantityException("Quantity cannot be negative.");
            }

            T item = GetItemById(id);
            item.Quantity = newQuantity;
        }
    }
}
