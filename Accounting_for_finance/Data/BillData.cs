using Accounting_for_finance.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting_for_finance.Data
{
    public class BillData
    {
        public static List<Bill> Bills { get; set; }

        static BillData()
        {
            Bills = new List<Bill>();
        }
    }
}
