using ShoppingApp.Application.Configuration.Commands;

namespace ShoppingApp.Application.Orders.CreateOrder
{
    public class CreateNewOrderCommand : ICommand
    {
        public CreateNewOrderCommand(string orderName)
        {
            OrderName = orderName;
        }

        public string OrderName { get; private set; }
    }
}
