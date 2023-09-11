using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP
{
    public class Student : Human
    {
        private int group;
        private int course;

        public enum Specialization
        {
            IT, Math, Language, None
        }
        Specialization specialization = Specialization.None;

        public Student(int group, int course, Specialization specialization, string name, string surname, int age, Address address):base(name, surname, age, address)
        {
            this.group = group;
            this.course = course;
            this.specialization = specialization;
        }
        private int GetGroup()
        {
            return group;
        }
        private int GetCourse()
        {
            return course;
        }
        public override void PrintData()
        {
            base.PrintData();
            Console.WriteLine($"Group:{group}\nCourse:{course}\nSpecialization:{specialization.ToString()}");
        }
    }
}
