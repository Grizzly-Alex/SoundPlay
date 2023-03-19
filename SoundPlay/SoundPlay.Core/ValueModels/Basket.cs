namespace SoundPlay.Core.ValueModels;

public sealed class Basket
{
    public IList<BasketPosition>? ProductList { get; set; }
    public byte TotalCount
    {
        get => (byte)ProductList!.Sum(product => product.Count);
    }
    public decimal TotalPrice
    {
        get => ProductList!.Sum(product => product.TotalPrice);
    }

    public Basket()
    {
        ProductList = Array.Empty<BasketPosition>();
    }
}
