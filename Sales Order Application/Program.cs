using CustomerSystem;
using OrderSystem;
using PaymentSystem;
using Products;
namespace Sales_Order_Application
{
    internal class Program
    { 
       static Stock stock = new Stock();
       static Customers customers = new Customers ();
       static Transactions transactions = new Transactions ();
       
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("=-=-=-= Sales Order System Menu =-=-=-=");
                Console.WriteLine("1. Data Entry");
                Console.WriteLine("2. Sales Process");
                Console.WriteLine("3. Print");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DataEntryMenu();
                        break;
                    case "2":
                        SalesProcessMenu();
                        break;
                    case "3":
                        PrintMenu();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }


        static void DataEntryMenu()
        {
            Console.WriteLine("\nData Entry Menu:");
            Console.WriteLine("1. Add/Update/Delete Customer");
            Console.WriteLine("2. Add/Update/Delete Product in Stock");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            switch (choice)
            {
                case "1":
                {   Console.WriteLine("1. Add Customer");
                    Console.WriteLine("2. Update Customer");
                    Console.WriteLine("3. Delete Customer");
                    Console.WriteLine("4. EXIt this Menu");
                        Console.Write("Select an option: ");
                        string secondChoice = Console.ReadLine();   

                    switch (secondChoice)
                    {
                        case "1":
                        {
                           AddNewCustomerMenu();
                           break;
                        }

                        case "2":
                        {
                            UpdateCustomerMenu();
                            break;
                        }


                        case "3":
                        {        Console.Write("Enter Customer ID: ");
                                int custId = int.Parse(Console.ReadLine());
                                customers.DeleteCustomer(custId);
                                break;
                        }

                        case "4":
                        { break; }
                    }

                    break;
                }



                case "2":
                    {
                        Console.WriteLine("1. Add Product in Stock");
                        Console.WriteLine("2. Update Product in Stock");
                        Console.WriteLine("3. Delete Product in Stock");
                        Console.WriteLine("4. EXIt this Menu");
                        Console.Write("Select an option: ");
                        string secondChoice = Console.ReadLine();
                        switch (secondChoice)
                        {
                            case "1":
                                {
                                    AddNewproductMenu();
                                    break;
                                }

                            case "2":
                                {
                                    UpdateProductMenu();
                                    break;
                                }


                            case "3":
                                {
                                    Console.Write("Enter Product ID: ");
                                    int prodId = int.Parse(Console.ReadLine());
                                    stock.DeleteProduct(prodId);
                                    break;
                                }

                            case "4":
                                { break; }
                        }

                        break ;
                    }
               

            }

        }
        
        static void SalesProcessMenu()
        {
            Console.WriteLine("\nSales Process Menu:");
            Console.WriteLine("1. Add Transaction");
            Console.WriteLine("2. Update Order");
            Console.WriteLine("3. Pay Order");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice) 
            {
                case "1":
                    {
                        Console.Write("Enter Customer ID: ");
                        int custId = int.Parse(Console.ReadLine());
                        var customer = customers.GetCustomer(custId);
                        
                        Order order = new Order(customer);

                        while (true)
                        {
                            Console.Write("Enter Product ID: ");
                            int prodId = int.Parse(Console.ReadLine());
                            var product = stock.GetProduct(prodId);

                            Console.Write("Enter Quantity: ");
                            int qty = int.Parse(Console.ReadLine());

                            Console.Write("Enter Sale Price: ");
                            double salePrice = double.Parse(Console.ReadLine());
                            order.AddOrderItem(new OrderItem(product, qty, salePrice));

                            Console.Write("Add Anthor Product (yes / no) :");
                            string input = Console.ReadLine();
                            if(input.ToUpper() == "NO")
                                break ;
                        }

                        Console.Write("Enter Status Of Order (New/Hold/Paid/Canceled): ");
                        Enum.TryParse(Console.ReadLine(), out OrderStatus status);
                        order.UpdateStatus(status);

                        Console.Write("Enter Payment Type (Credit / Cash / Check): ");
                        string paymentType = Console.ReadLine();
                        Console.Write("Enter Payment Amount: ");
                        double amount = double.Parse(Console.ReadLine());
                        Payment payment = null;
                        switch(paymentType.ToLower())
                        {
                            case "credit":
                                {
                                    Console.Write("Enter Credit Card Number : ");
                                    string ccn = Console.ReadLine();
                                    payment = new CreditPayment(amount, ccn);
                                    break;
                                }

                            case "cash":
                                {
                                    payment = new CashPayment(amount);
                                    break ;
                                }
                            case "check":
                                {
                                    Console.Write("Enter Check Number : ");
                                    string checnumber = Console.ReadLine();
                                    payment = new CheckPayment(amount, checnumber);
                                    break;
                                }
                        }

                        if(payment != null) 
                         transactions.AddTransaction(new Transaction (order, payment));

                        break;

                    }
                    case "2":
                    {
                        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                        Console.Write("Enter Order Number : ");
                        int order_number = int.Parse(Console.ReadLine());

                        Order order = transactions.GetOrder(order_number);
                        Console.WriteLine("1. Update Status");
                        Console.WriteLine("2. Update Quantity");
                        Console.Write("Select an option: ");
                        int cho = int.Parse(Console.ReadLine());

                        switch (cho)
                        {
                            case 1:
                                {
                                    Console.Write("Enter Status Of Order (New/Hold/Paid/Canceled): ");
                                    Enum.TryParse(Console.ReadLine(), out OrderStatus status);
                                    order.UpdateStatus(status);
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write("Enter the Id of item int the Order : ");
                                    int item_id = int.Parse(Console.ReadLine());    

                                    Console.Write("Enter the new Quantity : ");
                                    int quantity  = int.Parse(Console.ReadLine());
                                    order.UpdateOrderItemQuantity(item_id ,quantity);
                                    break;
                                }
                        }


                        break;
                    }
                    case "3":
                    {
                        Console.WriteLine("all Order are paied");
                        break ;
                    }
            
            
            }
        }
        
        
        static void PrintMenu()
        {
            Console.WriteLine("\nPrint Menu:");
            Console.WriteLine("1. Customers");
            Console.WriteLine("2. Stock Data");
            Console.WriteLine("3. Transactions");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine(customers.ToString());
                    break;
                case "2":
                    Console.WriteLine(stock);
                    break;
                case "3":
                    transactions.PrintTransactions();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void AddNewCustomerMenu()
        {
            Console.Write("Enter Customer ID: ");
            int custId = int.Parse(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Customer Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter Customer Phone: ");
            string phone = Console.ReadLine();

            customers.AddCustomer(new Customer(custId, name, address, phone));
            Console.WriteLine("Customer added.");
        }

        static void UpdateCustomerMenu()
        {
            Console.Write("Enter Customer ID: ");
            int custId = int.Parse(Console.ReadLine());
            bool Updateloop = true;
            while (Updateloop)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=");

                Console.WriteLine("     1. Update Name");
                Console.WriteLine("     2. Update Address");
                Console.WriteLine("     3. Update Phone");
                Console.WriteLine("     4. EXIt this Menu");
                string cho = Console.ReadLine();

                switch (cho)
                {
                    case "1":
                        {
                            Console.Write("Enter New Customer Name: ");
                            string name = Console.ReadLine();
                            customers.UpdateCustomer(custId, (Customer cusr) => cusr.Name = name);
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Enter New Customer Address: ");
                            string address = Console.ReadLine();
                            customers.UpdateCustomer(custId, (Customer cusr) => cusr.Address = address);
                            break;
                        }
                    case "3":
                        {
                            Console.Write("Enter New Customer Phone: ");
                            string phone = Console.ReadLine();
                            customers.UpdateCustomer(custId, (Customer cusr) => cusr.Phone = phone);
                            break;
                        }
                    case "4":
                        {
                            Updateloop = false;
                            break;
                        }

                }
            }

        }


        static void AddNewproductMenu()
        {
            Console.Write("Enter Product ID: ");
            int prodId = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Number: ");
            string prodNumber = Console.ReadLine();
            Console.Write("Enter Product Name: ");
            string prodName = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter Product Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Type ( General / Electronics / Food / Clothing / Books / Household )");
            string prodType = Console.ReadLine();   
            stock.AddProduct(new Product(prodId, prodNumber , prodName, price, quantity , (ProductType)Enum.Parse(typeof(ProductType) , prodType)));

        }

        static void UpdateProductMenu()
        {

            Console.Write("Enter Product ID: ");
            int ProdId = int.Parse(Console.ReadLine());
            bool Updateloop = true;
            while (Updateloop)
            {
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=");

                Console.WriteLine("     1. Update Name");
                Console.WriteLine("     2. Update Number");
                Console.WriteLine("     3. Update Price");
                Console.WriteLine("     4. Update Quantity");
                Console.WriteLine("     5. Update Type");
                Console.WriteLine("     6. EXIt this Menu");
                string cho = Console.ReadLine();

                switch (cho)
                {
                    case "1":
                        {
                            Console.Write("Enter New Product Name: ");
                            string name = Console.ReadLine();
                            stock.UpdateProduct(ProdId , p => p.Name = name);

                            break;
                        }
                    case "2":
                        {
                            Console.Write("Enter New Product Number: ");
                            string num = Console.ReadLine();
                            stock.UpdateProduct(ProdId, p => p.Number = num);
                            break;
                        }
                    case "3":
                        {
                            Console.Write("Enter New Product Price: ");
                            double price = Convert.ToDouble(Console.ReadLine());
                            stock.UpdateProduct(ProdId , p=> p.Price = price);
                            break;
                        }

                    case "4":
                        {
                            Console.Write("Enter New Product Quantity: ");
                            int quantity = int.Parse(Console.ReadLine());   
                            stock.UpdateProduct(ProdId, p => p.Quantity = quantity);
                            break;
                        }
                    case "5":
                        {
                            Console.Write("Enter New Product Type (General / Electronics / Food / Clothing / Books / Household): ");
                            string type = Console.ReadLine();
                            stock.UpdateProduct(ProdId , p => p.Type = (ProductType)Enum.Parse(typeof(ProductType), type));
                            break;
                        }
                    case "6":
                        {
                            Updateloop = false;
                            break;
                        }

                }
            }

        }
    }
    
}
