using System;
using System.Collections.Generic;
using System.Text;

namespace BethanysPieShopHRM.HR
{
    public sealed class Developer : Employee
    {
        public Developer(int id, string first, string last, string em, DateTime bd, double? rate) : base(id, first, last, em, bd, rate)
        {
        }

    }

    //public class JuniorDeveloper : Developer
    //{
    //    public JuniorDeveloper(string first, string last, string em, DateTime bd, double? rate) : base(first, last, em, bd, rate)
    //    {
    //    }
    //}
}
