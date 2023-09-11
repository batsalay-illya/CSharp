using System;

namespace OOP
{
    public class Human
    {
        private string name;
        private string surname;
        private int age;

        private Address address;

        public Human(string name, string surname, int age, Address address)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;

            this.address = address;
        }

        public virtual void PrintData()
        {
            Console.WriteLine($"Name:{name}\nSurname:{surname}\nAge:{age}\n" +
                              $"Country:{address.country}\nCity:{address.city}");
        }
        public string GetName()
        {
            return name;
        }
        public string GetSurname()
        {
            return surname;
        }
    }
}
