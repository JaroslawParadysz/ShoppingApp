using ShoppingApp.Domain.Products;
using ShoppingApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingApp.Domain.Orders
{
    public class Order : IAggregateRoot
    {
        public Guid OrderId { get; private set; }
        public string Title { get; private set; }

        private ICollection<OrderProduct> _orderProducts;

        private Order()
        {
            _orderProducts = new List<OrderProduct>();
        }

        public static Order Create(string orderTitle)
        {
            return new Order() { Title = orderTitle };
        }

        public void AddProduct(Guid productId, int quantity)
        {
            _orderProducts.Add(OrderProduct.Create(this, productId, quantity));
        }

        public void UpdateTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void UpdateProduct(Guid orderProductId, bool purchased)
        {
            _orderProducts.Single(x => x.OrderProductId == orderProductId).UpdatePurchased(purchased);
        }
    }
}
