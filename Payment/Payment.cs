namespace PaymentSystem
{
    public abstract class Payment
    {
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }

        protected Payment(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative.");
            Amount = amount;
            PaymentDate = DateTime.Now; 
        }
        protected Payment(DateTime _PaymentDate, double _amount)
        {
            if (_amount < 0)
                throw new ArgumentException("Amount cannot be negative.");
            Amount = _amount;
            PaymentDate = _PaymentDate; 
        }

        public abstract override string ToString();
    }

    // cash
    public class CashPayment : Payment
    {
        public CashPayment(double amount) : base(amount) { }
        public CashPayment(DateTime _datepayment,   double amount) : base(_datepayment ,amount) { }

        public override string ToString()
        {
           return $"Cash Payment: Amount: {Amount:C}, Date: {PaymentDate:yyyy-MM-dd HH:mm:ss}";
        }
    }

    // credit
    public class CreditPayment : Payment
    {
        public string CreditCardNumber { get; set; }

        public CreditPayment(double amount, string creditCardNumber) : base(amount)
        {
            CreditCardNumber = creditCardNumber ?? throw new ArgumentNullException(nameof(creditCardNumber));
        }

        public override string ToString() =>
            $"Credit Payment: Amount: {Amount:C}, Date: {PaymentDate:yyyy-MM-dd HH:mm:ss}, Card Number: {CreditCardNumber}";
    }

    public class CheckPayment : Payment
    {
        public string CheckNumber { get; set; }

        public CheckPayment(double amount, string checkNumber) : base(amount)
        {
            CheckNumber = checkNumber ?? throw new ArgumentNullException(nameof(checkNumber));
        }

        public override string ToString() =>
            $"Check Payment: Amount: {Amount:C}, Date: {PaymentDate:yyyy-MM-dd HH:mm:ss}, Check Number:{CheckNumber}";
    }
}
