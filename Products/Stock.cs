using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class Stock
    {
        public int count { get; private set; }

        private List<Product> products;
        public Stock()
        {
            count = 0;
            products = new List<Product>();
        }
        public Stock(int id, int count, List<Product> products)
        {
            this.count = count;
            this.products = products;
        }

        public void AddProduct(Product item)
        {
            var product = products.Find((p) => p.Id == item.Id);
            if (product == null)
            {
                count++;
                products.Add(item);
                Console.WriteLine("product is added successfully");
            }
            else
                Console.WriteLine("Product exixt in stock !!");
        }
        public void UpdateProduct(int Product_id, Action<Product> updateAction)
        {
            var product = products.Find((p) => p.Id == Product_id);
            if (product != null)
            {
                updateAction(product);
            }
            else
                Console.WriteLine("Product doesn't exixt in stock !!");
        }

        public void DeleteProduct(int Product_id)
        {
            var product = products.Find((p) => p.Id == Product_id);
            if (product != null)
            {
                count--;
                products.Remove(product);
                Console.WriteLine("product is deleted successfully");
            }
            else
                Console.WriteLine("Product doesn't exixt in stock !!");
        }

        public Product GetProduct(int Product_id)
        {
            var product = products.Find((p) => p.Id == Product_id);
            if (product != null)
            {
                return product;
            }
            else
                Console.WriteLine("Product doesn't exixt in stock !!");
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("  welecom in the stock\n");
            sb.Append($"Proudcs in stock  : {count}\n");
            sb.Append("***************************************\n");
            int cnt = 1;
            foreach (var item in products)
            {
                sb.Append($"Product  : {cnt}\n");
                sb.Append(item.ToString());
                sb.Append("\n***************************************\n");
                cnt++;
            }
            return sb.ToString();
        }
    }
}
