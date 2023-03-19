namespace SoundPlay.Core.ValueModels;

public sealed class BasketPosition
{
    public Guid Id { get; set; }
    public Product Product { get; set; }
    public Type Type { get; set; }
    //public int ProductId { get; set; }
    //public string? ProductName { get; set; }
    //public decimal ProductPrice { get; set; }
    //public string? ProductPictureUrl { get; set; }
    public byte Count { get; set; }
    public decimal TotalPrice
    {
        get => Product.Price * Count;
    }

    public BasketPosition()
    {
		Id = Guid.NewGuid();
    }
}