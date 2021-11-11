using System;

namespace BethanysPieShopHRM.HR
{
    public class Manager : Employee
    {
        public Manager(int id, string first, string last, string em, DateTime bd, double? rate) : base(id, first, last, em, bd, rate)
        {
        }

        public void AttendManagementMeeting()
        {
            NumberOfHoursWorked += 10;
            Console.WriteLine($"Manager {FirstName} {LastName} is now attending a long meeting that could have been an email!");
        }

        public override void GiveBonus()
        {
            if (NumberOfHoursWorked > 5)
                Console.WriteLine($"Manager {FirstName} {LastName} received a management bonus of 500!");
            else
                Console.WriteLine($"Manager {FirstName} {LastName} received a management bonus of 250!");
        }
    }
}
