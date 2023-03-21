namespace ShoppingOnline.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        private Cart cart;
        public OrderRepository(AppDbContext context, Cart cart)
        {
            this.context = context;
            this.cart = cart;
        }

        //public IQueryable<Order> Orders => context.Orders;

        public void SaveOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            context.Orders.Add(order);
            context.SaveChanges();
            var CartItems = cart.Items;

            foreach (var item in CartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity = item.Quantity,
                    ProductId = item.Product.ID,
                    OrderId = order.OrderId,
                    Price = item.Product.Price
                };

                context.OrderDetails.Add(orderDetail);
            }
            context.SaveChanges();
        }
    }
}
