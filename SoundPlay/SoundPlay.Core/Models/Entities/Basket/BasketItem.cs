namespace SoundPlay.Core.Models.Entities.Basket;

public sealed class BasketItem : Entity 
{
    public int BasketId { get; private set; }
    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public string ProductType { get; private set; }

    public BasketItem(int productId, int quantity, decimal unitPrice, string productType)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        SetQuantity(quantity);
        ProductType = productType;
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
