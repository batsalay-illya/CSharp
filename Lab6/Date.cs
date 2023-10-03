using System;

namespace Lab6
{
    internal class Date
    {
        private int day;
        private int month;
        private int year;

        public Date()
        {
            day = 0;
            month = 0;
            year = 0;
        }
        public Date(int day)
        {
            this.day = day;
            month = 0;
            year = 0;
        }
        public Date(int day, int month)
        {
            this.day = day;
            this.month = month;
            year = 0;
        }
        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        ~Date() { Console.WriteLine($"Date {day}.{month}.{year} - has deleted"); }

        public void SetDay(int day)
        {
            if (day > 28 && month == 0)
            {
                Console.WriteLine("Error! You need to set the month if you want to set day>28");
                return;
            }

            if (day <= 0)
                day = 1;

            if (month == 2 && day > 28)
            {
                day = 28;

                if (IsLeapYear())
                    day = 29;
            }

            if (day > 30)
            {
                switch (month)
                {
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        day = 30;
                        break;
                }
            }

            if (day > 31)
            {
                switch (month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        day = 31;
                        break;
                }
            }
            
            this.day = day;
        }
        public void SetMonth(int month)
        {
            if (month <= 0)
                month = 1;

            if (month > 12)
                month = 12;

            this.month =  month;
        }
        public void SetYear(int year)
        {
            if (year <= 0)
                year = 1;

            this.year = year;
        }

        public bool IsLeapYear()
        {
            if (year % 4 == 0 || (year % 100 == 0 && year % 400 == 0))
                return true;

            return false;
        }

        public int GetDay() { return day; }
        public int GetMonth() { return month; }
        public int GetYear() { return year; }


        public void PrintDateTypeDot() { Console.WriteLine($"{day}.{month}.{year}"); }
        public void PrintDateTypeSlash() { Console.WriteLine($"{day}/{month}/{year}"); }
        public void PrintDateTypeUS() { Console.WriteLine($"{month}-{day}-{year}"); }
    }
}
