using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.HR
{
    public interface IEmployee
    {
        double ReceiveWage();
        void GiveBonus();
        void PerformWork();
        void StopWorking();
        void DisplayEmployeeDetails();

        void GiveCompliment();
    }
}
