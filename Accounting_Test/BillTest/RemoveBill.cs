using Accounting_for_finance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting_Test
{
    [TestClass]
    public class RemoveBill
    {
        [TestCleanup()]
        public void MyTestCleanup()
        {
            // обновить базу данных
            DbService.ClearAll();
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            DbService.ClearAll();
            DbService.RefrashDb();
        }

        [TestMethod]
        public void RemoveOne()
        {
            Bill bill = new Bill
            {
                Id = 16,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            };
            DbService.AddBill(bill);
   
            DbService.RemoveBill(bill);
            int count = DbService.LoadAllBills().Count;

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void RemoveEmpty()
        {
            Bill bill = new Bill
            {
                Id = 17,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            };
            DbService.AddBill(bill);

            Bill empnote = null;
            DbService.RemoveBill(empnote);

            int count = DbService.LoadAllBills().Count;

            Assert.AreEqual(1, count);
        }
    }
}
