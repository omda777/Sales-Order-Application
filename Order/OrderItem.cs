
using Products;
namespace OrderSystem
{
    public class OrderItem
    {

        public Product Product { get; set; }

        private int quantity;

        public double SalesPrice;

        public int Quantity
        {
            get => quantity;

            set
            {
                if(value < 0)
                    throw new ArgumentException("Quantity cannot be negative.");
                if (value > Product.Quantity)
                    throw new InvalidOperationException($"Ordered quantity ({value}) exceeds stock ({Product.Quantity}).");
                quantity = value;
            }
        
        }

        public OrderItem(Product _product , int _quantity , double _salesprice)
        { 
            Product = _product;
            Quantity = _quantity;
            SalesPrice = _salesprice;
     
        }

       public static OrderItem operator ++(OrderItem item) 
        {
            if(item == null) throw new ArgumentNullException();
            if(item.Quantity +1 > item.Product.Quantity)
                throw new InvalidOperationException($"Cannot increment: Ordered quantity ({item.Quantity + 1}) exceeds stock ({item.Product.Quantity}).");
            item.Quantity++;
            return item;
        }

        public static OrderItem operator --(OrderItem item) 
        { 
            if (item == null) throw new ArgumentNullException();
            if (item.Quantity -1 < 0)
                throw new InvalidOperationException("Cannot decrement: Quantity cannot be negative.");
           item.Quantity--;
            return item;
        
        }

        public void IncreaseQuantity(int n)
        {
            if (n < 0)
                throw new ArgumentException("Increase amount cannot be negative.");
            Quantity += n;
            Console.WriteLine("Quantity increased sucssefully");
        }

        public void DecreaseQuantity(int n)
        {
            if (n < 0)
                throw new ArgumentException("Decrease amount cannot be negative.");
            Quantity -= n;
            Console.WriteLine("Quantity decreased sucssefully");
        }
        public void UpdateQuantity(int n)
        {
            if (n < 0)
                throw new ArgumentException("Decrease amount cannot be negative.");
            Quantity = n;
            Console.WriteLine("Quantity decreased sucssefully");
        }


    }
}
