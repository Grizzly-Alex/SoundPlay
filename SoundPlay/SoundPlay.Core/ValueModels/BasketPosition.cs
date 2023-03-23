namespace SoundPlay.Core.ValueModels;

public sealed class BasketPosition
{
    #region Product properties
    public int ProductId { get; set; } 
    public string? ProductName { get; set; }
    public string? ProductPictureUrl { get; set; }
    public decimal ProductPrice { get; set; }
    public string? ProductDescription { get; set; }
    public string? DataType { get; set; }
    #endregion
    public Guid PositionId { get; set; }
    public byte Count { get; set; }
    public decimal TotalPrice
    {
        get => ProductPrice * Count;
    }

    public BasketPosition()
    {
		PositionId = Guid.NewGuid();
    }
}