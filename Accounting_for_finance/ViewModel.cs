using Accounting_for_finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Accounting_for_finance
{
    class ViewModel
    {
        public List<Operation> op {get;set;}
        public List<Statistic> statistics { get; set; }
        public ViewModel(int k, DateTime d1, DateTime d2)
        {
            var cat = DbService.LoadAllCategory();
            op = DbService.LoadAllOper(k, d1, d2);
            IEnumerable<DateTime> D1 = (from o in op select o.date).Distinct();
            List<DateTime> D = D1.ToList();
            int count = D.Count;

            statistics = new List<Statistic>();
            for (int i = 0; i < count; i++)
            {
                statistics.Add(new Statistic(D[i], DbService.LoadAmountForData(D[i], k)));
            }
        }
    }
}
