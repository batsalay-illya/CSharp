using System;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task 1
            //class Student
            //---

            //task 2
            Student student_1 = new Student(20, "Male", 1000);
            Student student_2 = new Student(19, "Female", 1100);
            student_1.PrintData();
            student_2.PrintData();
            //---

            //task 3
            student_1.SetAge(22);
            Console.WriteLine(student_1.GetAge());

            student_2.SetScholarship(1300);
            Console.WriteLine(student_2.GetScholarship());
            //---

            //task 4
            //Student.cs
            //---

            //task 5-6
            //Student.cs
            //---

            //task 7
            Student student_first = new Student();
            Student student_second = new Student();

            student_first.SetAge(20);
            student_first.SetGender("Male");
            student_first.SetScholarship(1500);

            student_second.SetAge(25);
            student_second.SetGender("Female");
            student_second.SetScholarship(1500);

            Console.WriteLine($"first student: age:{student_first.GetAge()}, gender:{student_first.GetGender()}, scholarship:{student_first.GetScholarship()}");
            Console.WriteLine($"second student: age:{student_second.GetAge()}, gender:{student_second.GetGender()}, scholarship:{student_second.GetScholarship()}");

            Console.WriteLine($"Mid age:{(student_first.GetAge() + student_second.GetAge()) / 2}");
            Console.WriteLine($"Scholarsip sum:{student_first.GetScholarship() + student_second.GetScholarship()}");
            //---

            //task 8
            Date date_now = new Date();
            date_now.SetDay(3);
            date_now.SetMonth(10);
            date_now.SetYear(2023);

            date_now.PrintDateTypeDot();
            date_now.PrintDateTypeSlash();
            date_now.PrintDateTypeUS();
            //---

            Console.ReadKey();
        }
    }
}
