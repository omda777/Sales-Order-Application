using System;
using OrderSystem;

namespace PaymentSystem
{
    public class Transaction
    {
        public Order Order { get; set; }
        public Payment Payment { get; set; }

        public Transaction(Order order, Payment payment)
        {
            Order = order;
            Payment = payment;
        }

        public override string ToString()
        {
            return $"Transaction for Order #{Order.OrderNumber}, Payment: {Payment}";
        }

    }

    public class Transactions
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction(Transaction transaction) => transactions.Add(transaction);
        public void PrintTransactions() => transactions.ForEach(t => Console.WriteLine(t));

        public Order GetOrder(int orderId)
        {
            Order order = transactions.Find(p=> p.Order.OrderNumber == orderId).Order;
            if (order == null)
            {
                Console.WriteLine("The order doesn't exist");
                return null;
            }
            return order ;
        }
    }
}

