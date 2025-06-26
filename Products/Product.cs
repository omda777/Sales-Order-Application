namespace Products
{
    public enum ProductType
    {
        General = 0,
        Electronics = 1,
        Food = 2,
        Clothing = 3,
        Books = 4,
        Household = 5
    };

    public class Product
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ProductType Type { get; set; }


        public Product() : this(0, "NULL", "Nuknow", 0.0, 0, ProductType.General) { }


        public Product(int id, string number, string name, double price, int quantity, ProductType type)
        {
            Id = id;
            Number = number;
            Name = name;
            Price = price;
            Quantity = quantity;
            Type = type;
        }
        public void update(string number, string name, double price, int quantity, ProductType type)
        {
            Number = number;
            Name = name;
            Price = price;
            Quantity = quantity;
            Type = type;
        }
        public void updateprice(double _price)
        {
            this.Price = _price;
        }

        public void updateName(string _name)
        {
            this.Name = _name;
        }

        public override string ToString()
        {
            return $"ID       : {Id}\nName     : {Name}\nNumber   : {Number}\nPrice    : {Price:f2}\nQuantity : {Quantity}\nType     : {Type}";
        }
    }
}
