namespace Question3.Interfaces
{
    public interface IInventoryItem
    {
        int Id { get; }
        string Name { get; }
        int Quantity { get; set; }
    }
}
