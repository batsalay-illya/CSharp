using System;

namespace Lab6
{
    internal class Student
    {
        //task 5-6
        private int age;
        private string gender;
        private int scholarship;
        //---

        //task 4
        public Student()
        {
            age = 0;
            gender = "None";
            scholarship = 0;
        }
        public Student(int age)
        {
            this.age = age;
            gender = "None";
            scholarship = 0;
        }
        public Student(int age, string gender)
        {
            this.age = age;
            this.gender = gender;
            scholarship = 0;
        }
        public Student(int age, string gender, int scholarship)
        {
            this.age = age;
            this.gender = gender;
            this.scholarship = scholarship;
        }

        ~Student() { Console.WriteLine($"Student age:{age}, gender:{gender}, scholarship:{scholarship} - has deleted"); }
        //---

        public void PrintData() { Console.WriteLine($"Age: {age}, gender: {gender}, scholarship: {scholarship}"); }

        public void SetAge(int age) => this.age = age;
        public void SetGender(string gender) => this.gender = gender;
        public void SetScholarship(int scholarship) => this.scholarship = scholarship;

        public int GetAge() { return age; }
        public string GetGender() { return gender; }
        public int GetScholarship() { return scholarship; }
    }
}
