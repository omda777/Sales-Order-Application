using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSystem
{
    public class Customers
    { 
        private List<Customer> customers ;

        public Customers (List<Customer> customers)
        {
            this.customers = customers;
        }
        public Customers ()
        {
            customers = new List<Customer> ();
        }

        public void AddCustomer(Customer item)
        {
            var customer = customers.Find((p) => p.Id == item.Id);
            if (customer == null)
            {
                customers.Add(item);
                Console.WriteLine("Customer is added successfully");
            }
            else
                Console.WriteLine("Customer is exixt !!");
        }
        public void UpdateCustomer(int cus_id, Action<Customer> updateAction)
        {
            var customer = customers.Find((p) => p.Id == cus_id);
            if (customer != null)
            {
                updateAction(customer);
            }
            else
                Console.WriteLine("Customer doesn't exixt !!");
        }

        public void DeleteCustomer(int cus_id)
        {
            var Customer = customers.Find((p) => p.Id == cus_id);
            if (Customer != null)
            {
                customers.Remove(Customer);
                Console.WriteLine("Customer  is deleted successfully");
            }
            else
                Console.WriteLine("Customer  doesn't exixt !!");
        }

        

        public Customer GetCustomer(int Cus_id)
        {
            var customer = customers.Find((p) => p.Id == Cus_id);
            if (customer != null)
            {
                return customer;
            }
            else
                Console.WriteLine("Customer  doesn't exixt !!");
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"The total number of customer : {customers.Count()}\n");

            foreach (var item in customers) 
            {
              sb.Append(item.ToString());
                sb.Append("\n*********************************\n");
            }
            return sb.ToString();   
        }
    }
}
