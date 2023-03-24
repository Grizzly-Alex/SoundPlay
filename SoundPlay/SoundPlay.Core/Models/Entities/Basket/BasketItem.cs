namespace SoundPlay.Core.Models.Entities.Basket;

public sealed class BasketItem : Entity 
{
    public int BasketId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
   
    public BasketItem(int catalogItemId, int quantity, decimal unitPrice)
    {
        ProductId = catalogItemId;
        UnitPrice = unitPrice;
        SetQuantity(quantity);
    }

    public void SetQuantity(int quantity)
    {
        Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);
        Quantity = quantity;
    }

    public void AddQuantity(int quantity)
    {
        Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);
        Quantity += quantity;
    }
}
