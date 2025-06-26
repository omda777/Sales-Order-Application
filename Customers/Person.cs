namespace CustomerSystem
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public Person() { }
        public Person(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"Name    : {Name}\nAddress :{Address}";
        }
    }

}
