namespace SoundPlay.BLL.ViewModels.Customer
{
    public sealed class Basket
    {
        private byte _totalCount;
        private decimal _totalSum;
        public List<BasketPosition>? ProductList { get; set; }
        public byte TotalCount
        {
            get => _totalCount;
            private set => _totalCount = (byte)ProductList!.Sum(product => product.Count);
        }
        public decimal TotalSum
        {
            get => _totalSum;
            private set => _totalSum = ProductList!.Sum(product => product.Sum);
        }

        public Basket()
        {
            ProductList= new();
        }
    }
}
