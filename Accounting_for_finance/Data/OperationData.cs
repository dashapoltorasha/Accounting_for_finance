using Accounting_for_finance.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting_for_finance.Data
{
    public class OperationData
    {
        public static List<Operation> Operations { get; set; }

        static OperationData()
        {
            Operations = new List<Operation>();
        }
    }
    public class YearComparer : IComparer<Operation>
    {
        public int Compare(Operation op1, Operation op2)
        {

            if (op1.date > op2.date)
            {
                return 1;
            }
            else if (op1.date < op2.date)
            {
                return -1;
            }
            return 0;
        }
    }
}
