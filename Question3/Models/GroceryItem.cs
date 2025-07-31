using Question3.Interfaces;

namespace Question3.Models
{
    public class GroceryItem : IInventoryItem
    {
        public int Id { get; }
        public string Name { get; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; }

        public GroceryItem(int id, string name, int quantity, DateTime expiryDate)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            ExpiryDate = expiryDate;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Quantity: {Quantity}, Expiry Date: {ExpiryDate.ToShortDateString()}";
        }
    }
}
