namespace SoundPlay.Web.ViewModels.Shop;

public sealed class Basket
{
    public List<BasketPosition>? ProductList { get; set; }
    public byte TotalCount
    {
        get => (byte)ProductList!.Sum(product => product.Count);
    }
    public decimal TotalSum
    {
        get => ProductList!.Sum(product => product.Sum);
    }

    public Basket()
    {
        ProductList = new();
    }
}
