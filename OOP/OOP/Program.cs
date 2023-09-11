using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HumanList humanList = new HumanList();
            StudentList studentList = new StudentList();

            humanList.AddToList(
            new Human(name: "Tom", surname: "Philips", age: 23,
            new Address(country: "USA",
                        city: "New York City")
            ));

            humanList.AddToList(
            new Human(name: "Mike", surname: "Adams", age: 20,
            new Address(country: "United Kingdom",
                        city: "Scotland")
            ));

            humanList.AddToList(
            new Human(name: "Lina", surname: "Brown", age: 26,
            new Address(country: "Ukraine",
                        city: "Kherson")
            ));

            studentList.AddToList(
                new Student(241, 2, specialization: Student.Specialization.IT, name: "Mike", surname: "Adams", age: 20,
                new Address(country: "United Kingdom",
                            city: "Scotland")));

            //Console.WriteLine("Список, до видалення елементу:");
            //humanList.PrintList();
            //humanList.RemoveFromList(name: "Mike", surname: "Adams");
            //
            //Console.WriteLine("Список, після видалення елементу:");
            //humanList.PrintList();

            studentList.PrintList();
            Console.ReadKey();
        }
}
    
    public class HumanList
    {
        private List<Human> humans = new List<Human>();

        public void AddToList(Human human)
        {
            humans.Add(human);
        }
        public void RemoveFromList(string name, string surname)
        {
            Human toRemove = null;
            foreach (Human human in humans)
            {
                if (human.GetName() == name && human.GetSurname() == surname)
                {
                    toRemove = human;
                }
            }
            humans.Remove(toRemove);
        }
        public void PrintList()
        {
            foreach (Human human in humans)
            {
                human.PrintData();
            }
        }
    }
    public class StudentList
    {
        private List<Student> students = new List<Student>();
        public void AddToList(Student student)
        {
            students.Add(student);
        }
        public void RemoveFromList(string name, string surname, int group)
        {
            Student toRemove = null;
            foreach (Student student in students)
            {
                if (student.GetName() == name && student.GetSurname() == surname)
                {
                    toRemove = student;
                }
            }
            students.Remove(toRemove);
        }
        public void PrintList()
        {
            foreach (Student student in students)
            {
                student.PrintData();
            }
        }
    }
}
