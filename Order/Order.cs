using  CustomerSystem;
namespace OrderSystem
{
    public enum OrderStatus
    {
        New ,
        Hold ,
        Paid ,
        Canseld
    }
    public class Order
    {
        public int OrderNumber { get; private set; }
        public DateTime OrderDate { get; set; }
        public double TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public Customer Customer { get; set; }  
        private List<OrderItem> Items { get; set; }

        public Order(Customer _customer)
        {
            Random Rand = new Random();
            OrderNumber = Rand.Next(1,1000000);
            OrderDate = DateTime.Now;
            TotalAmount = 0;
            Status = OrderStatus.New;   
            Customer = _customer;
            Items = new List<OrderItem>();
        }

        public void AddOrderItem (OrderItem item)
        {
            Items.Add(item);
            TotalAmount += item.Quantity * item.SalesPrice;
        }

        public void UpdateStatus (OrderStatus status)
        {
            Status = status;
        }

        public void UpdateOrderItemQuantity(int ItemId , int quentity)
        {
           var item = Items.Find(p => p.Product.Id == ItemId);
            if(item == null)
            {
                Console.WriteLine("Product doesn`t exist");
                return;
            }
            TotalAmount -= item.Quantity * item.SalesPrice; 
            item.UpdateQuantity(quentity);
            TotalAmount += item.Quantity * item.SalesPrice;
        }

        public override string ToString()
        {
            return $"Order #{OrderNumber}, Date: {OrderDate}, Customer: {Customer.Name}, Status: {Status}, Total: {TotalAmount:C}";
        }


    }
}
