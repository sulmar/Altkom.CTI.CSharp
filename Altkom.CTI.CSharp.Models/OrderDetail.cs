namespace Altkom.CTI.CSharp.Models
{
    public class OrderDetail
    {
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public Item Item { get; set; }

        public OrderDetail(Item item, int quantity, decimal unitPrice)
        {
            this.Item = item;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
        }

        public OrderDetail(Item item, int quantity = 1)
            : this(item, quantity, item.UnitPrice)
        {

        }
    }

}
