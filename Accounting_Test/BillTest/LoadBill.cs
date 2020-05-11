using Accounting_for_finance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting_Test
{
    [TestClass]
    public class LoadBill
    {
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            DbService.ClearAll();
            DbService.RefrashDb();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            DbService.ClearAll();
            DbService.RefrashDb();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            // обновить базу данных
            DbService.ClearAll();
            // DbService.RefrashDb(true);
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            DbService.ClearAll();
            DbService.RefrashDb();
        }

        [TestMethod]
        public void LoadMany()
        {
            DbService.AddBill(new Bill
            {
                Id = 13,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            });
            DbService.AddBill(new Bill
            {
                Id = 14,
                Type = true,
                Text = "VTB",
                Description = "Card",
                Balance = 15000,
                Number = "5487"
            });
            DbService.AddBill(new Bill
            {
                Id = 15,
                Type = false,
                Text = "Cash",
                Description = "",
                Balance = 5000,
                Number = ""
            });
  
            var result = DbService.LoadAllBills();

            Assert.AreEqual(3, result.Count);
        }
    }
}
