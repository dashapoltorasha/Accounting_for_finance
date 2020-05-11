using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting_for_finance.Models
{
    public class Statistic
    {
            public DateTime Date { get; set; }
            public List<int> Amount { get; set; }

        public Statistic(DateTime Date, List<int> Amount)
        {
            this.Date = Date;
            this.Amount = Amount;
        }
    }
}
