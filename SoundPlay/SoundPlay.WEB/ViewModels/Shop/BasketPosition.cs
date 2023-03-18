namespace SoundPlay.Web.ViewModels.Shop;

public sealed class BasketPosition
{
    public Guid BasketPositionId { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string? ProductPictureUrl { get; set; }
    public byte Count { get; set; }
    public decimal Sum
    {
        get => ProductPrice * Count;
    }

    public BasketPosition()
    {
        BasketPositionId = Guid.NewGuid();
    }
}