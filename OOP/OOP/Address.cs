namespace OOP
{
    public class Address
    {
        public string country { get; private set; }
        public string city { get; private set; }
        public Address(string country, string city)
        {
            this.country = country;
            this.city = city;
        }

    }
}
