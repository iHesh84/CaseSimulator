public class InventoryItem
{
    public int ItemId { get; }
    public int Quantity { get; }

    public InventoryItem(int itemId, int quantity)
    {
        ItemId = itemId;
        Quantity = quantity;
    }
}