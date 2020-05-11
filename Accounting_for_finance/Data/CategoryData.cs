using Accounting_for_finance.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting_for_finance.Data
{
    public class CategoryData
    {
        public static List<Category> Categorys { get; set; }

        static CategoryData()
        {
            Categorys = new List<Category>();
        }
    }
}
