namespace SoundPlay.BLL.ViewModels.Customer
{
    public sealed class BasketPosition
    {
        private decimal _sum;
        public Guid BasketPositionId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductPictureUrl { get; set; }
        public byte Count { get; set; }
        public decimal Sum
        {
            get => _sum;
            private set => _sum = ProductPrice*Count;
        }

        public BasketPosition()
        {
            BasketPositionId = Guid.NewGuid();
        }

    }
}
