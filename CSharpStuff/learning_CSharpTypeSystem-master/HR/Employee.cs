using System;

namespace BethanysPieShopHRM.HR
{
    public class Employee : IComparable, IEmployee
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;

        private int numberOfHoursWorked;
        private double wage;
        private double? hourlyRate;
        public static double taxRate = 0.15;

        private DateTime birthDay;


        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }
        public int NumberOfHoursWorked
        {
            get { return numberOfHoursWorked; }
            set
            {
                numberOfHoursWorked = value;
            }
        }
        public double Wage
        {
            get { return wage; }
            set
            {
                wage = value;
            }
        }
        public double? HourlyRate
        {
            get { return hourlyRate; }
            set
            {
                hourlyRate = value;
            }
        }
        public DateTime BirthDay
        {
            get { return birthDay; }
            set
            {
                birthDay = value;
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }

        public Employee(int empId, string first, string last, string em, DateTime bd, double? rate) // constructer sets all of the fiels of the object
        {
            Id = empId;
            FirstName = first;
            LastName = last;
            Email = em;
            BirthDay = bd;
            HourlyRate = rate ?? 10;
        }

        public void PerformWork()
        {
            NumberOfHoursWorked++;

            Console.WriteLine($"{FirstName} {LastName} is now working!");
        }


        public void StopWorking()
        {
            Console.WriteLine($"{FirstName} {LastName} has stopped working!");
        }

        public double ReceiveWage()
        {
            double wageBeforeTax = NumberOfHoursWorked * HourlyRate.Value;
            double taxAmount = wageBeforeTax * taxRate;

            Wage = wageBeforeTax - taxAmount;

            Console.WriteLine($"The wage for {NumberOfHoursWorked} hours of work is {Wage}.");
            NumberOfHoursWorked = 0;

            return Wage;
        }

        public virtual void GiveBonus()
        {
            Console.WriteLine($"{FirstName} {LastName} received a generic bonus of 100!");
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"\nID: {Id}\nFirst name: {FirstName}\nLast name: {LastName}\nEmail: {Email}\nBirthday: {BirthDay.ToShortDateString()}\nTax rate: {taxRate}");
        }

        public static void DisplayTaxRate()
        {
            Console.WriteLine($"The current tax rate is {taxRate}");
        }

        public int CompareTo(object obj)
        {
            var otherEmployee = (Employee)obj;
            if (Id > otherEmployee.Id)
                return 1;
            else if (Id < otherEmployee.Id)
                return -1;
            else
                return 0;
        }

        public void GiveCompliment()
        {
            Console.WriteLine($"You've done a great job, {FirstName}");
        }
    }
}
