using System;

namespace BethanysPieShopHRM.HR
{
    public class StoreManager : Employee
    {
        public StoreManager(int id, string first, string last, string em, DateTime bd, double? rate) : base(id, first, last, em, bd, rate)
        {
        }

    }
}
