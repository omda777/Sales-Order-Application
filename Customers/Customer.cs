using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSystem
{
    public class Customer : Person
    {
        public int Id { get; set; } 
        public string Phone { get; set; }

        public Customer(int id ,string name , string address, string phone) : base (name , address)
        {
            Id = id;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"ID      : {Id}\n"+base.ToString()+ $"\nPhone   : {Phone}";
        }
    }
}
