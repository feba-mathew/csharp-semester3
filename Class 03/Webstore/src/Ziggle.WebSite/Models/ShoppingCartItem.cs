namespace Ziggle.WebSite.Models
{
    public class ShoppingCartItem
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}