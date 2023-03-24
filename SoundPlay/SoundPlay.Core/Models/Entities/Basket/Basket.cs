namespace SoundPlay.Core.Models.Entities.Basket
{
    public sealed class Basket : Entity
    {
        public string BuyerId { get; private set; }
        public List<BasketItem> Items { get; private set; }
        public int TotalItems => Items.Sum(i => i.Quantity);
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }

        public Basket(string buyerId)
        {
            BuyerId = buyerId;
            CreateDate = DateTime.Now;
        }

        public void SetNewBuyerId(string buyerId) => BuyerId = buyerId;

        public void AddItem(int productId, decimal unitPrice, string productType, int quantity = 1)
        {
            if (!Items.Any(i => i.ProductId == productId && i.ProductType.Equals(productType, StringComparison.OrdinalIgnoreCase)))
            {
                Items.Add(new BasketItem(productId, quantity, unitPrice, productType));
            }
            else
            {
                var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
                existingItem!.AddQuantity(quantity);
            }

            UpdateDate = DateTime.Now;
        }

        public void RemoveEmptyItems()
        {
            Items.RemoveAll(i => i.Quantity == 0);

            UpdateDate = DateTime.Now;
        }
    }
}
